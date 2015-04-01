var app = angular.module('app', ['ngRoute']);

app.config(['$routeProvider', '$httpProvider', function ($routeProvider, $httpProvider) {
    $routeProvider
    .when('/', {
        templateUrl: '/AppJS/Views/Home.html',
    })
    .when('/Home/Main', {
        templateUrl: '/AppJS/Views/Test.html'
    })
    .when('/Home/Search', {
        templateUrl: '/AppJS/Views/Search.html'
    })
    .when('/Calendar', {
        templateUrl: '/AppJS/Views/Calendar.Html'
    })
    .when('/Home/Details', {
        templateUrl: '/AppJS/Views/Details.html'
    })
    .otherwise({
        redirectTo: '/'
    })
    $httpProvider.interceptors.push('AuthFactory');
}])

