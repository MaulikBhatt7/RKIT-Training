$(function () {
    const API_URL = 'https://632158b682f8687273afe9c3.mockapi.io/MatchList';

    // Handle form submission
    $('#addMatchForm').submit(function (e) {
        e.preventDefault();

        const team1 = $('#team1').val();
        const team2 = $('#team2').val();
        const matchDate = $('#matchDate').val();
        const venue = $('#venue').val();

        if (!team1 || !team2 || !matchDate || !venue) {
            alert('Please fill out all fields');
            return;
        }

        const newMatch = {
            team1: team1,
            team2: team2,
            date: matchDate,
            venue: venue,
            team1Flag: team1.toLowerCase().replace(/\s+/g, '') + '.png', // Example: india.png
            team2Flag: team2.toLowerCase().replace(/\s+/g, '') + '.png', // Example: australia.png
        };

        // AJAX call to add the new match to the API
        $.ajax({
            url: API_URL,
            method: 'POST',
            data: newMatch,
            success: function () {
                alert('Match successfully added!');
                window.location.href = './match_list.html'; // Redirect back to the match list page
            },
            error: function () {
                alert('Error adding match');
            }
        });
    });
});
