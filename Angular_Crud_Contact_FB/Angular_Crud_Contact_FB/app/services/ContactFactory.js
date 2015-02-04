app.factory('ContactFactory', function () {
    var myContacts = [];

    //var pushContacts = myContacts;

    var getContacts = function () {
        return myContacts;
    }

    var addContacts = function (data) {
        myContacts.push(data);
        //console.log(myContacts);
    }

    
    return {
        getContacts: getContacts,
        addContacts: addContacts
    };
});