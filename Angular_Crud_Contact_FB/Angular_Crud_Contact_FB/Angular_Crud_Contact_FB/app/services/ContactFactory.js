app.factory('ContactFactory', function ($http) {
    var myContacts = [];
    
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
        
        console.log(myContacts[i]);
        console.log(currContact.id);
    }

    //var addId = function () {
    //    for (var i in myContacts) {

    //        var tempContact = myContacts[i];

    //        var newContact = new Contact(tempContact.name, tempContact.address, tempContact.phone, tempContact.email);

    //        newContact.__proto__ = { id: i };
    //}

    

    var editContact = function (val) {
        //var currContact = myContacts[val];
        //var currEditId = currContact.id;
        var currContact = myContacts[val];
        var currEditId = currContact.id;

            var customUrl = "https://coder-camp-contact.firebaseio.com/" + currEditId + "/.json";
            $http.put(customUrl).success(function (val) {
                if (myContacts.length > 0) {
                    myContacts = [];
                }
                
            })
        }


    var deleteContact = function (val) {
        var currContact = myContacts[val];
        var currDeleteId = currContact;

        var customUrl = "https://coder-camp-contact.firebaseio.com/" + currDeleteId + "/.json";
        $http.delete(customUrl).success(function (val) {
            var currDelete = val;
            myContacts.splice(val, 1);
            //console.log(currDeleteId);
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
