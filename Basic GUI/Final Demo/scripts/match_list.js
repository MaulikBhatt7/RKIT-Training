$(function () {
    let API_URL = 'https://632158b682f8687273afe9c3.mockapi.io/MatchList';  // URL for fetching the match data (replace with actual API URL)
    
    class MatchManager {
        constructor(apiUrl) {
            this.apiUrl = apiUrl;
            this.matches = [];
            this.FetchMatches();
        }

        /**
         * Method: FetchMatches
         * Description: Fetches match data from the API and displays it on the page.
         * Parameters: None
         * Returns: None
         * From: Called on page load to fetch initial match data.
         */
        async FetchMatches() {
            try {
                let response = await $.ajax({ url: this.apiUrl, method: 'GET' });
                this.matches = response;

                let team1 = localStorage.getItem('team1Filter');
                let team2 = localStorage.getItem('team2Filter');
                let venue = localStorage.getItem('venueFilter');

                if (team1 || team2 || venue) {
                    $('#team1Filter').val(team1);
                    $('#team2Filter').val(team2);
                    $('#venueFilter').val(venue);
                    
                    this.FilterMatches(team1, team2, venue);
                }
                else{
                    this.DisplayMatches(this.matches);
                }
               
            } catch (error) {
                console.error('Error fetching match data:', error);
                alert('Error fetching match data');
            }
        }

        /**
         * Method: DeleteMatch
         * Description: Confirms deletion and deletes a match from the API.
         * Parameters: MatchID - the ID of the match to delete.
         * Returns: None
         * From: Triggered when the user clicks the delete button on a match.
         */
        async DeleteMatch(MatchID) {
            let confirmed = await this.ShowConfirmationDialog("Are you sure you want to delete?");
            if (!confirmed) return;

            try {
                await $.ajax({ url: `${this.apiUrl}/${MatchID}`, method: 'DELETE' });
                this.ShowAlert("Deleted!", "Record has been deleted.", "success");
                this.FetchMatches();
            } catch (error) {
                console.error('Error deleting match:', error);
                alert('Error deleting match');
            }
        }

        /**
         * Method: EditMatchRedirect
         * Description: Redirects the user to the "Add Match" page with the selected match's ID in the query parameter.
         * Parameters: MatchID - the ID of the match to edit.
         * Returns: None
         * From: Triggered when the user clicks the edit button on a match.
         */
        EditMatchRedirect(MatchID) {
            window.location.href = `add_match.html?matchID=${MatchID}`;
        }

        /**
         * Method: StartCountdown
         * Description: Starts a countdown timer for each match.
         * Parameters: MatchDateTime - the date and time of the match, ElementID - the element ID to update with the countdown.
         * Returns: None
         * From: Called by DisplayMatches for each match card.
         */
        StartCountdown(MatchDateTime, ElementID) {
            let targetDate = new Date(MatchDateTime);
            setInterval(() => {
                let now = new Date();
                let timeDiff = targetDate - now;

                if (timeDiff <= 0) {
                    document.getElementById(ElementID).innerHTML = "Match Over!";
                } else {
                    let days = Math.floor(timeDiff / (1000 * 60 * 60 * 24));
                    let hours = Math.floor((timeDiff % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                    let minutes = Math.floor((timeDiff % (1000 * 60 * 60)) / (1000 * 60));
                    let seconds = Math.floor((timeDiff % (1000 * 60)) / 1000);
                    document.getElementById(ElementID).innerHTML = `${days}d ${hours}h ${minutes}m ${seconds}s`;
                }
            }, 1000);
        }

        /**
         * Method: DisplayMatches
         * Description: Renders the list of matches on the page.
         * Parameters: Matches - array of match objects to display.
         * Returns: None
         * From: Called after data is fetched from the API to render matches.
         */
        DisplayMatches(Matches) {
            $('#matchList').html('');
            Matches.forEach(match => {
                let countdownId = `countdown-${match.id}`;
                let matchCard = `
                    <div class="card">
                        <div class="card-body">
                            <img src="../images/${match.team1}.png" alt="${match.team1}">
                            <h5>${match.team1}</h5>
                            <div class="vs">vs</div>
                            <img src="../images/${match.team2}.png" alt="${match.team2}">
                            <h5>${match.team2}</h5>
                            <p class="mt-4"><strong>Date:</strong> ${match.date}</p>
                            <p><strong>Venue:</strong> ${match.venue}</p>
                            <p><strong>Time Remains:</strong></p>
                            <p id="${countdownId}" class="countdown"></p>
                            <div class="mt-4">
                                <button class="btn btn-secondary editBtn m-2" data-id="${match.id}">Edit</button>
                                <button class="btn btn-danger deleteBtn m-2" data-id="${match.id}">Delete</button>
                            </div>
                        </div>
                    </div>
                `;
                $('#matchList').append(matchCard);
                this.StartCountdown(match.date, countdownId);
            });
        }

        /**
         * Method: ShowConfirmationDialog
         * Description: Displays a confirmation dialog.
         * Parameters: Message - the confirmation message to display.
         * Returns: Boolean - True if confirmed, False if canceled.
         * From: Called in DeleteMatch to confirm the deletion action.
         */
        ShowConfirmationDialog(Message) {
            return Swal.fire({
                title: "Confirmation!",
                text: Message,
                icon: "warning",
                showCancelButton: true,
                confirmButtonText: "Yes",
                cancelButtonText: "No"
            }).then(result => result.isConfirmed);
        }

        /**
         * Method: ShowAlert
         * Description: Shows an alert with a message.
         * Parameters: Title - the title of the alert, Message - the alert message, Icon - the icon type (success, error, etc.)
         * Returns: None
         * From: Called after deletion or any action requiring an alert message.
         */
        ShowAlert(Title, Message, Icon) {
            Swal.fire({ title: Title, text: Message, icon: Icon });
        }

        /**
         * Method: FilterMatches
         * Description: Filters the displayed matches based on selected criteria.
         * Parameters: Team1 - filter by team 1, Team2 - filter by team 2, Venue - filter by venue.
         * Returns: None
         * From: Triggered by clicking the filter button on the page.
         */
        FilterMatches(Team1, Team2, Venue) {
            let filteredMatches = this.matches.filter(match => {
                return (Team1 ? match.team1 === Team1 : true) &&
                       (Team2 ? match.team2 === Team2 : true) &&
                       (Venue ? match.venue === Venue : true);
            });
            this.DisplayMatches(filteredMatches);
        }
    }

    let matchManager = new MatchManager(API_URL);

    /**
     * Event: Clear Filters
     * Description: Clear the filters 
     * Parameters: None
     * Returns: None
     * From: Triggered by clicking the clear filter button on the page.
     */
    $("#clear-filter").click(async function(){

        // Clear Local Storage
        localStorage.clear();

        // Clear selected values from filter
        $("#team1Filter").val("")
        $("#team2Filter").val("")
        $("#venueFilter").val("")

        // Fetch all matches after clearing filter
        await matchManager.FetchMatches();

    })

    // Event bindings
    $(document).on("click", ".deleteBtn", function() {
        let matchID = $(this).data('id');
        matchManager.DeleteMatch(matchID);
    });

    $(document).on('click', '.editBtn', function() {
        let matchID = $(this).data('id');
        matchManager.EditMatchRedirect(matchID);
    });

    $('#filterButton').click(function () {
        let team1 = $('#team1Filter').val();
        let team2 = $('#team2Filter').val();
        let venue = $('#venueFilter').val();

        // Save filter preferences in localStorage
        localStorage.setItem('team1Filter', team1);
        localStorage.setItem('team2Filter', team2);
        localStorage.setItem('venueFilter', venue);
        matchManager.FilterMatches(team1, team2, venue);
    });
});
