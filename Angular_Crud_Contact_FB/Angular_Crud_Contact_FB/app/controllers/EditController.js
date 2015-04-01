app.controller('EditController', function ($scope, $http, ContactFactory) {
    $scope.showArray = ContactFactory.getContacts();
    $scope.test;
    
    ContactFactory.showContacts();
    console.log($scope.showArray);

    $scope.editClick = function (val) {
        $scope.test = val;
        $scope.nameObj = ContactFactory.editClick(val);
        $scope.modelName = $scope.nameObj.name;
        $scope.modelAddress = $scope.nameObj.address;
        $scope.modelPhone = $scope.nameObj.phone;
        $scope.modelEmail = $scope.nameObj.email;
        //console.log($scope.nameObj);
    };
    
    $scope.editContacts = function (val) {
        $scope.nameObj.name = $scope.modelName;
        $scope.nameObj.address = $scope.modelAddress;
        $scope.nameObj.phone =$scope.modelPhone;
        $scope.nameObj.email =$scope.modelEmail;
        $scope.editConfirm = ContactFactory.editContact(val)
        .then(function () {
            console.log("from edit controler", ContactFactory.getContacts());
            //ContactFactory.getContacts();
            //ContactFactory.showContacts();
            $scope.showArray = ContactFactory.getContacts();

        })
        
        
    }

    $scope.deleteContacts = function (val) {
        $scope.deleteConfirm = ContactFactory.deleteContact(val);
        $scope.showArray = ContactFactory.getContacts();

        
    }

})