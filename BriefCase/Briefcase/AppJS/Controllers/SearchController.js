app.controller('SearchController', ['$scope', function ($scope) {

    $scope.baseUrl = 'http://api.indeed.com/ads/apisearch?publisher=6086980531593213&format=json&v=2&q=';
    $scope.query = '';
    $scope.location = '';

    $scope.urlMaker = function () {
        return $scope.baseUrl + $scope.query + '&l=' + $scope.location;
    }

    $scope.search = function () {
        $.ajax({
            url: $scope.urlMaker(),
            dataType: 'JSONP',
            jsonpCallback: 'callback',
            type: 'GET',
            success: function (data) {
                console.log(data);
            }
        })
    }
}]);