// Write your JavaScript code.
$(document).ready(function () {
    var token = sessionStorage.getItem('token');
    if (token == null) {
        var Email = localStorage.getItem('Email');
        var Password = localStorage.getItem('Password');
        console.log(Email + Password);
        if (Email != undefined && Password != undefined) {
            var formObject = {
                Email: Email,
                Password: Password
            }
            var token = getToken(formObject);
            if (token == true) {
                console.log("Token has been set");
            }
        }
    }
});

function getToken(formData) {
    console.log(formData);
    $.ajax({
        type: "POST",
        url: "/api/token",
        dataType: "json",
        data: formData, // seems like the data must be in json format
        success: function (data) {
            sessionStorage.setItem('token', data.access_token);
            return true;
        },
        error: function (textStatus) {
            return textStatus;
        }
    });
}

function registerUser(formData) {
    $.ajax({
        type: "POST",
        url: "/Account/Register",
        dataType: "json",
        data: formData, // seems like the data must be in json format
        success: function (data) {
            console.log("Register returned data:");
            console.log(data);
            return true;
        },
        error: function (textStatus) {
            return textStatus;
        }
    });
    return true;
}

function clearToken() {
    if (sessionStorage.getItem("token") == null) {
        return false;
    }
    else {
        userSignout();
    }
    sessionStorage.clear('token');
    localStorage.clear('Email');
    localStorage.clear('Password');
    return true;
}

function userSignout() {
    $.ajax({
        type: "GET",
        url: "/api/Secure/Signout",
        beforeSend: function (xhr) { xhr.setRequestHeader('Authorization', 'Bearer ' + sessionStorage.getItem("token")); },
        success: function (data) {
            console.log("Register returned data:");
            console.log(data);
        },
        error: function (textStatus) {
            return textStatus;
        }
    });
}
