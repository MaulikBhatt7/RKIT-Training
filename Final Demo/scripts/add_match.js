$(function () {
    let API_URL = 'https://632158b682f8687273afe9c3.mockapi.io/MatchList';  // URL for the API to add new match data (replace with actual API URL)

    /**
     * Event: Add Match Form Submission
     * Description: Handles the form submission to add a new match.
     * It validates the form fields to ensure all are filled. If not, it shows an alert.
     * On success, it sends the new match data via AJAX to the API, and shows a success message.
     * On failure, it shows an error message.
     * Parameters: None
     * Returns: None
     * From: User submitting the "Add Match" form
     */
    $('#addMatchForm').submit(function (e) {
        e.preventDefault();  // Prevent the default form submission behavior (which would reload the page)

        // Retrieve the form values
        let team1 = $('#team1').val();
        let team2 = $('#team2').val();
        let matchDate = $('#matchDate').val();
        let venue = $('#venue').val();

        // Validate that all fields are filled out
        if (!team1 || !team2 || !matchDate || !venue) {
            alert('Please fill out all fields');  // Alert if any field is missing
            return;
        }

        // Same team alert
        if(team1===team2){
            Swal.fire({
                title: "Team 1 and Team 2 are same!",
                icon: "warning"
            });
            return;
        }

        // Construct the new match object
        let newMatch = {
            team1: team1,
            team2: team2,
            date: matchDate,
            venue: venue,
            team1Flag: team1.toLowerCase().replace(/\s+/g, '') + '.png',  // Convert team1 name to lowercase and replace spaces, e.g., "india.png"
            team2Flag: team2.toLowerCase().replace(/\s+/g, '') + '.png',  // Convert team2 name to lowercase and replace spaces, e.g., "australia.png"
        };

        // AJAX call to send the new match data to the API
        $.ajax({
            url: API_URL,  // API URL where the match data is to be posted
            method: 'POST',  // HTTP POST request to send data
            data: newMatch,  // The new match data to be sent to the API
            success: function () {  // On successful submission
                // Show a success message using Swal (SweetAlert)
                Swal.fire({
                    title: "Match Successfully Added!",
                    icon: "success"
                });
                // Redirect to the match list page after a delay
                setTimeout(function(){
                    window.location.href = '../screens/match_list.html';  // Redirect to match list page after 2 seconds
                }, 2000);
            },
            error: function () {  // On failure, show an error message
                alert('Error adding match');
            }
        });
    });
});
