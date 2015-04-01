app.factory('AuthFactory', ['$q', '$window', function ($q, $window) {
    return {
        request: function (config) {
            config.headers = config.headers || {};
            if ($window.localStorage.getItem('token')) {
                config.headers.Authorization = 'Bearer ' + localStorage.getItem('token');
            }
            return config || $q.when(config);
        }
    }
}]);