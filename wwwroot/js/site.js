// Write your JavaScript code.
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

function registerToken(formData) {
    $.ajax({
        type: "POST",
        url: "/Account/Register",
        dataType: "json",
        data: formData, // seems like the data must be in json format
        success: function (data) {
            console.log("Register returned data:");
            console.log(data);
        },
        error: function (textStatus) {
            return textStatus;
        }
    });
    var success = getToken(formData);
    return success;
}

function clearToken() {
    if (sessionStorage.getItem("token") == null) {
        return false;
    }
    else {
        userSignout();
    }
    sessionStorage.clear('token');
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
