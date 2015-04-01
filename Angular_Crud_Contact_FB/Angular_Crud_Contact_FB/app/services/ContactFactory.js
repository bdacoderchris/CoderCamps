app.factory('ContactFactory', function ($http, $q) {
    var myContacts = [];

    //var deferred = $q.defer();
    
    function Contact(name, address, phone, email, id) {
        this.name = name;
        this.address = address;
        this.phone = phone;
        this.email = email;
        this.id = id;
    }
    
    //var pushContacts = myContacts;

    var getContacts = function () {
        return myContacts;
    }

    var addContacts = function (data) {
        myContacts.push(data);
        //console.log(myContacts);
    }

    // READ
    var showContacts = function (data) {
        //console.log("show contacts func");
        $http.get("https://coder-camp-contact.firebaseio.com/.json").success(function (data) {
            if (myContacts.length > 0) {
                myContacts = [];
            }
            for (var i in data) {
                data[i].id = i;
                
                addContacts(data[i]);
                //console.log(myContacts);
                getContacts();
            }
        })
    }
    // UPDATE
    var editClick = function (val) {
        var currContact = myContacts[val];
        
        for (var i in myContacts) {
            if (currContact.id === myContacts[i].id) {
                return myContacts[i];
            }
        };
        
    }


    var editContact = function (val) {
        var currContact = myContacts[val].id;
        var customUrl = "https://coder-camp-contact.firebaseio.com/" + currContact + "/.json";

        var deferred = $q.defer();
        $http.put(customUrl, myContacts[val])
            .success(function (data) {
                console.log(myContacts);
                //myContacts.splice(val, 1, data);
                //return data;
                console.log(myContacts);
                deferred.resolve();
            }).error(function () {
                alert("help");
            })
        return deferred.promise;
    }

 

//DELETE
    var deleteContact = function (val) {
        var currContact = myContacts[val];
        var currDeleteId = currContact.id;
        
        var customUrl = "https://coder-camp-contact.firebaseio.com/" + currDeleteId + "/.json";
        $http.delete(customUrl).success(function () {
            //var currDelete = val;
            myContacts.splice(val, 1);
            console.log(currContact);
            //showContacts();
        })
    }


return {
    getContacts: getContacts,
    addContacts: addContacts,
    showContacts: showContacts,
    editContact: editContact,
    deleteContact: deleteContact,
    editClick: editClick
};
});
