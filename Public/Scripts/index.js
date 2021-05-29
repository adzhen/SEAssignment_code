$(document).ready(function() {

    $("#logout-button").click(function(event) {
        event.preventDefault();
        location.reload(true);
    });

    $("#login-button").click(function(event) {
        event.preventDefault();
        var username = $("#username").val();
        var password = $("#password").val();

        var url = "/api/Employee/GetEmployeeDetail?username=" + username + "&pwd=" + password;
        $.ajax({
                headers: {
                    "Accept": "application/json"
                },
                url: url,
                success: function(response) {
                    var bank;
                    var employee;
                    var branch;
                    var status = response.status;
                    if (status == 200) {
                        $.each(response, function(key, data) { // The contents inside stars
                            if (key == "bank") {
                                bank = data;
                            }
                            if (key == "employee") {
                                employee = data;
                            }
                            if (key == "branch") {
                                branch = data;
                            }

                        });
                        console.log(bank)
                        console.log(employee)
                        console.log(branch)

                        $('form').fadeOut(300);
                        $('.wrapper').addClass('form-success');
                        $('.table-info').fadeIn(3000);

                        var photo = employee.Photo;
                        var name = employee.Name;
                        var email = employee.Email;
                        var bank = bank.Name;
                        var branch = branch.Name;

                        $('#image').attr('src', 'data:image/png;base64,' + photo);
                        $('#profile-name').html(name);
                        $('#profile-email').html(email);
                        $('#profile-bank').html(bank + " - " + branch);
                    } else {
                        alert("Invalid user");
                    }
                }
            }).done(function() {

            })
            .fail(function() {
                alert("Invalid action");
            });

    });
});