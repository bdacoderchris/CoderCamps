// Factory to handle user login
app.factory('LoginFactory', ['$http', '$q', function ($http, $q) {
    // logged in or logged out status
    var status = {};

    // If there is a user token, change status to loggedIn
    if (localStorage.getItem('token')) {
        status.loggedIn = true;
    } else {
        status.loggedIn = false;
    }

    // Function to log user in
    var login = function (user) {
        var def = $q.defer();
        $http({
            method: 'POST',
            url: '/Token',
            data: 'username=' + user.username + '&password=' + user.password + '&grant_type=password',
            contentType: 'application/x-www-form-urlencoded'
        }).success(function (data) {
            localStorage.setItem('token', data.access_token);
            status.loggedIn = true;
            def.resolve();
        }).error(function (data) {
            logout();
            def.reject();
        })
        return def.promise;
    }

    // Function to log user out
    var logout = function () {
        localStorage.removeItem('token');
        status.loggedIn = false;
    }

    // Gets user info
    var getInfo = function () {
        var def = $q.defer();
        $http({
            url: 'api/Users/GetUser',
            method: 'GET'
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        })
        return def.promise;
    }

    return {
        status: status,
        login: login,
        logout: logout,
        getInfo: getInfo
    }
}]);