app.controller('EditController', function ($scope, $http, ContactFactory) {
    $scope.showArray = ContactFactory.getContacts();

    ContactFactory.showContacts();
    console.log($scope.showArray);

    $scope.editClick = function (val) {
        $scope.nameObj = ContactFactory.editClick(val);
        $scope.modelName = $scope.nameObj.name;
        $scope.modelAddress = $scope.nameObj.address;
        $scope.modelPhone = $scope.nameObj.phone;
        $scope.modelEmail = $scope.nameObj.email;
        console.log($scope.nameObj);
    };
    
    $scope.editContacts = function (val) {
        $scope.editConfirm = ContactFactory.editContact(val);
        $scope.newName = ContactFactory.myContacts[val].name;
        $scope.newAddress = ContactFactory.myContacts[val].address;
        $scope.newPhone = ContactFactory.myContacts[val].phone;
        $scope.newEmail = ContactFactory.myContacts[val].email;
        
        console.log($scope.newName);
    }

})