$(function () {
    let API_URL = 'https://632158b682f8687273afe9c3.mockapi.io/MatchList';  // URL for fetching the match data (replace with actual API URL)
    let matches = [];  // Array to store the match data fetched from the API

    /**
     * Function: fetchMatches
     * Description: Fetches match data from the API and displays it on the page.
     * On success, it stores the match data in the `matches` array and calls the `displayMatches()` function to render the matches.
     * On failure, an alert is shown to inform the user about the error.
     * Parameters: None
     * Returns: None
     * From: Initial page load
     */
    function fetchMatches() {
        $.ajax({
            url: API_URL,  // API URL for fetching match data
            method: 'GET',  // HTTP GET request to fetch the data
            success: function (data) {  // On success, store the fetched data and display matches
                matches = data;
                displayMatches(matches);  // Calls displayMatches to render fetched matches
            },
            error: function () {  // On failure, show an error message
                alert('Error fetching match data');
            }
        });
    }

    /**
     * Function: startCountdown
     * Description: Starts a countdown timer for each match, displaying the remaining time until the match starts.
     * Updates the countdown every second and shows "Match Over!" once the match time is over.
     * Parameters: 
     *   - matchDateTime (string): The date and time of the match.
     *   - elementId (string): The ID of the HTML element where the countdown will be displayed.
     * Returns: None
     * From: displayMatches function (called in the forEach loop for each match)
     */
    function startCountdown(matchDateTime, elementId) {
        let targetDate = new Date(matchDateTime);  // Convert the match date string to a Date object
        setInterval(function() {  // Repeatedly execute this function every second (1000ms)
            let now = new Date();  // Get the current date and time
            let timeDiff = targetDate - now;  // Calculate the difference between the match date and current date

            // If the match time has passed, display "Match Over!"
            if (timeDiff <= 0) {
                document.getElementById(elementId).innerHTML = "Match Over!";
            } else {
                // Otherwise, calculate and display the remaining time in days, hours, minutes, and seconds
                let days = Math.floor(timeDiff / (1000 * 60 * 60 * 24));
                let hours = Math.floor((timeDiff % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                let minutes = Math.floor((timeDiff % (1000 * 60 * 60)) / (1000 * 60));
                let seconds = Math.floor((timeDiff % (1000 * 60)) / 1000);
                document.getElementById(elementId).innerHTML = `${days}d ${hours}h ${minutes}m ${seconds}s`;  // Display the countdown
            }
        }, 1000);  // Update the countdown every second
    }

    /**
     * Function: displayMatches
     * Description: Displays the list of matches on the page.
     * Loops through each match in the `matches` array and generates HTML content for each match.
     * Adds a countdown timer and appends the match details to the page.
     * Parameters: 
     *   - matches (array): The array of match objects to be displayed.
     * Returns: None
     * From: fetchMatches function (called after data is successfully fetched), filter button click (for displaying filtered matches)
     */
    function displayMatches(matches) {
        $('#matchList').html('');  // Clear the existing match list before displaying the new one
        matches.forEach(match => {  // Loop through each match and generate the match card
            let countdownId = `countdown-${match.id}`;  // Generate a unique ID for the countdown element
            let matchCard = `
                <div class="card">  <!-- Match card container -->
                    <div class="card-body">
                        <img src="../images/${match.team1}.png" alt="${match.team1}">  <!-- Image of team 1 -->
                        <h5>${match.team1}</h5>  <!-- Name of team 1 -->
                        <div class="vs">vs</div>  <!-- Separator between teams -->
                        <img src="../images/${match.team2}.png" alt="${match.team2}">  <!-- Image of team 2 -->
                        <h5>${match.team2}</h5>  <!-- Name of team 2 -->
                        <p><strong>Date:</strong> ${match.date}</p>  <!-- Match date -->
                        <p><strong>Venue:</strong> ${match.venue}</p>  <!-- Match venue -->
                        <p><strong>Time Remains:</strong></p>
                        <p id="${countdownId}" class="countdown"></p>  <!-- Countdown element -->
                    </div>
                </div>
            `;
            $('#matchList').append(matchCard);  // Append the match card to the list
            startCountdown(match.date, countdownId);  // Calls startCountdown to display the countdown for each match
        });
    }

    /**
     * Event: Filter Button Click
     * Description: Filters the displayed matches based on the selected criteria (team1, team2, and venue).
     * Once the filter button is clicked, it applies the filters to the `matches` array and updates the displayed matches.
     * Parameters: None
     * Returns: None
     * From: User clicking the filter button on the page
     */
    $('#filterButton').click(function () {
        let team1 = $('#team1Filter').val();  // Get the selected value for team 1
        let team2 = $('#team2Filter').val();  // Get the selected value for team 2
        let venue = $('#venueFilter').val();  // Get the selected value for venue

        // Filter the matches array based on the selected criteria
        let filteredMatches = matches.filter(match => {
            return (team1 ? match.team1 === team1 : true) &&  // Filter by team 1 if selected
                   (team2 ? match.team2 === team2 : true) &&  // Filter by team 2 if selected
                   (venue ? match.venue === venue : true);  // Filter by venue if selected
        });

        displayMatches(filteredMatches);  // Calls displayMatches to update the displayed matches with the filtered results
    });

    // Initial load of all matches when the page is loaded
    fetchMatches();  // Calls fetchMatches to load the match data on page load
});
