$(function () {
    let API_URL = 'https://632158b682f8687273afe9c3.mockapi.io/MatchList';  // URL for fetching the match data (replace with actual API URL)
    let matches = [];  // Array to store the match data fetched from the API

    /**
     * Function: FetchMatches
     * Description: Fetches match data from the API and displays it on the page.
     */
    function FetchMatches() {
        $.ajax({
            url: API_URL,  // API URL for fetching match data
            method: 'GET',  // HTTP GET request to fetch the data
            success: function (data) {  // On success, store the fetched data and display matches
                matches = data;
                DisplayMatches(matches);  // Calls DisplayMatches to render fetched matches
            },
            error: function () {  // On failure, show an error message
                alert('Error fetching match data');
            }
        });
    }

    /**
     * Function: DeleteMatch
     * Description: Handles the deletion of a match when the delete button is clicked.
     */
    $(document).on("click", ".deleteBtn", function(e) {
        e.preventDefault(); // Prevent the default behavior of the button
        
        let swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-success",
                cancelButton: "btn btn-danger"
            },
            buttonsStyling: true
        });

        swalWithBootstrapButtons.fire({
            title: "Confirmation!!",
            text: "Are you sure you want to delete?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                let matchID = $(this).data('id');
                let deleteURL = API_URL + '/' + matchID;

                $.ajax({
                    url: deleteURL,
                    method: 'DELETE',
                    success: function(response) {
                        swalWithBootstrapButtons.fire({
                            title: "Deleted!",
                            text: "Record has been deleted.",
                            icon: "success"
                        });

                        setTimeout(function() {
                            window.location.reload();
                        }, 1000);
                    },
                    error: function(error) {
                        console.log('Error fetching data', error);
                    }
                });
            } 
            else if (result.dismiss) {
                Swal.fire({
                    title: "Cancelled",
                    icon: "error"
                });
            }
        });
    });

    /**
     * Function: EditMatchRedirect
     * Description: Redirects the user to the "Add Match" page with the selected match's ID in the query parameter.
     */
    $(document).on('click', '.editBtn', function() {
        let matchID = $(this).data('id');
        window.location.href = `add_match.html?matchID=${matchID}`;
    });

    /**
     * Function: StartCountdown
     * Description: Starts a countdown timer for each match.
     */
    function StartCountdown(matchDateTime, elementId) {
        let targetDate = new Date(matchDateTime);
        setInterval(function() {
            let now = new Date();
            let timeDiff = targetDate - now;

            if (timeDiff <= 0) {
                document.getElementById(elementId).innerHTML = "Match Over!";
            } else {
                let days = Math.floor(timeDiff / (1000 * 60 * 60 * 24));
                let hours = Math.floor((timeDiff % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                let minutes = Math.floor((timeDiff % (1000 * 60 * 60)) / (1000 * 60));
                let seconds = Math.floor((timeDiff % (1000 * 60)) / 1000);
                document.getElementById(elementId).innerHTML = `${days}d ${hours}h ${minutes}m ${seconds}s`;
            }
        }, 1000);
    }

    /**
     * Function: DisplayMatches
     * Description: Displays the list of matches on the page.
     */
    function DisplayMatches(matches) {
        $('#matchList').html('');
        matches.forEach(match => {
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
            StartCountdown(match.date, countdownId);
        });
    }

    /**
     * Event: FilterMatches
     * Description: Filters the displayed matches based on the selected criteria.
     */
    $('#filterButton').click(function () {
        let team1 = $('#team1Filter').val();
        let team2 = $('#team2Filter').val();
        let venue = $('#venueFilter').val();

        let filteredMatches = matches.filter(match => {
            return (team1 ? match.team1 === team1 : true) &&  
                   (team2 ? match.team2 === team2 : true) &&  
                   (venue ? match.venue === venue : true);  
        });

        DisplayMatches(filteredMatches);
    });

    FetchMatches();
});
