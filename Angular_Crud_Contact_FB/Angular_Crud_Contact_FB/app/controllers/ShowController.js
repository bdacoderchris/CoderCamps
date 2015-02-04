app.controller("ShowController", function ($scope, $http, ContactFactory) {
    $scope.contacts;
    $scope.showContacts = function () {
        $http.get("https://coder-camp-contact.firebaseio.com/.json").success(function (data) {
            for (var i in data) {
                //ContactFactory.addContacts[i];

                console.log(data);
                ContactFactory.addContacts[i];

            }
            $scope.contacts = ContactFactory.getContacts;
        }).error(function (data) {
            alert("Oh noes")
        })
    }
});



//    $scope.showContacts = function () {
//        $http.get("https://coder-camp-contact.firebaseio.com/.json").success(function (data) {
//            for (item in data) {
//                ContactFactory.addContacts[item];
//                console.log(data);
//            }
//        })
//    }
//});

//$scope.contacts;
//$scope.getContacts = function () {
//    $http({
//        url: "https://coder-camp-contact.firebaseio.com/.json",
//        method: "GET",
//    }).success(function (data) {
//        for (var i in data) {
//            ContactFactory.addContacts(data[i]);
//            alert(data);
//        }
//        $scope.contacts = ContactFactory.getContacts;
//    }).error(function (data) {
//        alert(data);
//    })
//}





        
        

    
