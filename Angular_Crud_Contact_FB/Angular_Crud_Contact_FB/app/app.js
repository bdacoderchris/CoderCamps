var app = angular.module("myApp", ['ngRoute']);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: 'app/views/Home.html',
        controller: 'HomeController'
    })
     .when('/AddContacts', {
         templateUrl: 'app/views/AddContacts.html',
         controller: 'AddController'
     })
     .when('/EditContacts', {
         templateUrl: 'app/views/EditContacts.html',
         controller: 'EditController'
     })
     .when('/ShowContacts', {
         templateUrl: 'app/views/ShowContacts.html',
         controller: 'ShowController'
     })
    .otherwise({
        redirectTo: '/'
    });
}]);