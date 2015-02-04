app.controller('AddController', function ($scope, $http, ContactFactory) {

    $scope.postToFb = function () {
        $http.post("https://coder-camp-contact.firebaseio.com/.json", { name: $scope.newName, address: $scope.newAddress, phone: $scope.newPhone, email: $scope.newEmail }).success(function (data) {
            //$scope.myContacts = data;
            ContactFactory.addContacts({ name: $scope.newName, address: $scope.newAddress, phone: $scope.newPhone, email: $scope.newEmail });


            $scope.newName = "";
            $scope.newAddress = "";
            $scope.newPhone = "";
            $scope.newEmail = "";

        })

        }
})
        


//    $http({
//        //verbs and URL goes here
//        url: "https://coder-camp-contact.firebaseio.com/.json",
//        method: "POST",
//        data: $scope.myContacts,
//    }).success(function (data) {
//        ContactFactory.addContacts(data)
//        alert(data);
//    }).error(function () {

//    })
//})



