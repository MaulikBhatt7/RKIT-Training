$(function () {
    const API_URL = 'https://632158b682f8687273afe9c3.mockapi.io/MatchList';
    let matches = [];

    // Fetch and display all matches on page load
    function fetchMatches() {
        $.ajax({
            url: API_URL,
            method: 'GET',
            success: function (data) {
                matches = data;
                displayMatches(matches);
            },
            error: function () {
                alert('Error fetching match data');
            }
        });
    }

    // Display the matches on the page
    function displayMatches(matches) {
        $('#matchList').html('');
        matches.forEach(match => {
            const matchCard = `
                <div class="card">
                    <div class="card-body">
                        <img src="images/${match.team1}.png" alt="${match.team1}">
                        <h5>${match.team1}</h5>
                        <div class="vs">vs</div>
                        <img src="images/${match.team2}.png" alt="${match.team2}">
                        <h5>${match.team2}</h5>
                        <p><strong>Date:</strong> ${match.date}</p>
                        <p><strong>Venue:</strong> ${match.venue}</p>
                    </div>
                </div>
            `;
            $('#matchList').append(matchCard);
        });
    }

    // Filter matches based on selected criteria
    $('#filterButton').click(function () {
        const team1 = $('#team1Filter').val();
        const team2 = $('#team2Filter').val();
        const venue = $('#venueFilter').val();

        const filteredMatches = matches.filter(match => {
            return (team1 ? match.team1 === team1 : true) &&
                   (team2 ? match.team2 === team2 : true) &&
                   (venue ? match.venue === venue : true);
        });

        displayMatches(filteredMatches);
    });

    // Initial load of all matches
    fetchMatches();
});
