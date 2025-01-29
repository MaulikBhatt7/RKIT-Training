$(function () {
    class MatchFormHandler {
        /**
         * Method: Constructor Initialization
         * Description: Initializes the API URL and retrieves match ID from URL parameters.
         * This setup is used for differentiating between add and edit operations.
         * Parameters: ApiUrl (string) - The base API URL for match data operations.
         * Returns: None
         * From: Called when creating a new MatchFormHandler instance.
         */
        constructor(ApiUrl) {
            this.APIUrl = ApiUrl;
            this.MatchID = new URLSearchParams(window.location.search).get('matchID');
            this.init();
        }

        /**
         * Method: Form Initialization
         * Description: Sets up the page text for adding or editing and binds the form submission event.
         * If match ID is present, fetches existing match data to pre-fill the form.
         * Parameters: None
         * Returns: None
         * From: Called by constructor during initialization.
         */
        async init() {
            this.SetupPageText();
            this.ClearValidationMessages();

            if (this.MatchID) {
                await this.PopulateFormData();
            }

            $('#addMatchForm').on('submit', (e) => this.HandleFormSubmit(e));
        }

        /**
         * Method: Setup Page Text
         * Description: Updates the heading and submit button text based on add or edit mode.
         * Parameters: None
         * Returns: None
         * From: Called during initialization.
         */
        SetupPageText() {
            let headingOfAddPage = document.getElementById("heading-of-addPage");
            let textOfSubmitBtn = document.getElementById("text-of-submit-btn");

            if (this.MatchID) {
                headingOfAddPage.innerHTML = "Edit Match Schedule";
                textOfSubmitBtn.innerHTML = "Edit Match";
            }
        }

        /**
         * Method: Populate Form Data
         * Description: Fetches existing match data from the API for editing and pre-fills form fields.
         * Parameters: None
         * Returns: None
         * From: Called during initialization if editing a match.
         */
        async PopulateFormData() {
            let editDataURL = `${this.APIUrl}/${this.MatchID}`;
            try {
                let response = await $.ajax({
                    url: editDataURL,
                    method: 'GET',
                    dataType: 'json'
                });
                $('#team1').val(response.team1);
                $('#team2').val(response.team2);
                $('#matchDate').val(response.date);
                $('#venue').val(response.venue);
            } catch (error) {
                console.error('Error fetching match details:', error);
            }
        }

        /**
         * Method: Add/Edit Match Form Submission
         * Description: Handles the form submission to add or edit a match.
         * Validates the form fields and then sends the data to the API based on add or edit mode.
         * On success, displays a success message and redirects.
         * Parameters: Event (Event) - The form submission event.
         * Returns: None
         * From: User submitting the "Add/Edit Match" form.
         */
        async HandleFormSubmit(Event) {
            Event.preventDefault();
            this.ClearValidationMessages();
            let Team1 = $('#team1').val();
            let Team2 = $('#team2').val();
            let MatchDate = $('#matchDate').val();
            let Venue = $('#venue').val();

            let IsValid = true;

            if (!Team1) {
                this.ShowValidationMessage('team1', "Select Team 1");
                IsValid = false;
            }
            if (!Team2) {
                this.ShowValidationMessage('team2', "Select Team 2");
                IsValid = false;
            }
            if (!MatchDate) {
                this.ShowValidationMessage('matchDate', "Select Date-Time");
                IsValid = false;
            }
            if (!Venue) {
                this.ShowValidationMessage('venue', "Select Venue");
                IsValid = false;
            }

            if (IsValid) {
                if (Team1 === Team2) {
                    Swal.fire({
                        title: "Team 1 and Team 2 are the same!",
                        icon: "warning"
                    });
                    return;
                }

                let NewMatch = { team1: Team1, team2: Team2, date: MatchDate, venue: Venue };
                let url = this.MatchID ? `${this.APIUrl}/${this.MatchID}` : this.APIUrl;
                let method = this.MatchID ? 'PUT' : 'POST';
                let successMessage = this.MatchID ? "Match Successfully Edited!" : "Match Successfully Added!";

                await this.SubmitMatchData(url, method, NewMatch, successMessage);
            }
        }

        /**
         * Method: Submit Match Data
         * Description: Submits match data to the API, either for adding or editing, and shows success or error message.
         * Parameters: 
         *      URL (string) - The API endpoint to send data to.
         *      Method (string) - The HTTP method, 'POST' for adding, 'PUT' for editing.
         *      Data (object) - The match data object to send.
         *      SuccessMessage (string) - The message to display on success.
         * Returns: None
         * From: Called by HandleFormSubmit for adding/editing a match.
         */
        async SubmitMatchData(URL, Method, Data, SuccessMessage) {
            try {
                await $.ajax({
                    url: URL,
                    method: Method,
                    data: Data
                });
                Swal.fire({
                    title: SuccessMessage,
                    icon: "success"
                });
                setTimeout(() => {
                    window.location.href = '../screens/match_list.html';
                }, 2000);
            } catch (error) {
                alert(`Error ${Method === 'POST' ? 'adding' : 'editing'} match`);
            }
        }

        /**
         * Method: Show Validation Message
         * Description: Displays a validation error message for a specific field.
         * Parameters: Field (string) - The ID of the field to validate.
         *              Message (string) - The validation message to display.
         * Returns: None
         * From: Called during validation in HandleFormSubmit.
         */
        ShowValidationMessage(Field, Message) {
            let messageSpan = document.getElementById(`${Field}_error`);
            messageSpan.textContent = Message;
            messageSpan.style.display = 'block';
        }

        /**
         * Method: Clear Validation Messages
         * Description: Clears any displayed validation messages from the form.
         * Parameters: None
         * Returns: None
         * From: Called at the beginning of form validation.
         */
        ClearValidationMessages() {
            let errorSpans = document.querySelectorAll('.error-message');
            errorSpans.forEach(span => {
                span.textContent = '';
                span.style.display = 'none';
            });
        }
    }

    // Initialize MatchFormHandler with the API URL
    new MatchFormHandler('https://632158b682f8687273afe9c3.mockapi.io/MatchList'); // Replace 'url' with the actual API URL
});
