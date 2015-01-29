//Global array to store contacts
var superHeroHolder = {};

superHeroHolder.superHeroArray = [];

//placeholder for id tag
var editHero = ""

var objToAdd;

//Remove Hero function

superHeroHolder.removeHero = function () {
    $("#superHeroList" + id).remove();
}


//Object constructor
superHeroHolder.SuperHero = function(name, powers, secretIdentity, city) {
    this.id = null;
    this.name = name;
    this.powers = powers;
    this.secretIdentity = secretIdentity;
    this.city = city;
}


//Submit form button function
$("#superForm").submit(function (event) {
    event.preventDefault();

    $("#superHeroList").empty();

    var superNameSubmit = $("#superHeroNameId").val();
    var superSecretSubmit = $("#secretIdentityId").val();
    var superPowerSubmit = $("#superPowerId").val();
    var city = $("#currentCity").val();

    var tempSuperHolder = new superHeroHolder.SuperHero(superNameSubmit, superPowerSubmit, superSecretSubmit, city);
    superHeroHolder.superHeroArray.push(tempSuperHolder);

    makeCall(tempSuperHolder);
    superHeroHolder.displayHero();

});


//Function to display new contact and dynamically add the table row
superHeroHolder.displayHero = function () {

    $("#superHeroList").empty();

    var len = superHeroHolder.superHeroArray.length,
    superHeroId;
    for (var i = 0; i < len; i++) {
        superHeroId = i
        $("#superHeroList").append("<tr>");
        $("#superHeroList").append("<td>" + superHeroHolder.superHeroArray[i].name + "</td>");
        $("#superHeroList").append("<td>" + superHeroHolder.superHeroArray[i].secretIdentity + "</td>");
        $("#superHeroList").append("<td>" + superHeroHolder.superHeroArray[i].powers + "</td>");
        $("#superHeroList").append("<td>" + superHeroHolder.superHeroArray[i].city + "</td>");
        $("#superHeroList").append("<td><input type='submit' class='icon-large icon-trash' id='Ship' data-toggle='modal' data-target='#myModal' value='Edit' /></td>");
        $("#superHeroList").append("<td><input type='submit' class='icon-large icon-trash' id='Delete' onclick='superHeroHolder.killHero()'   value='Delete' /></td>");
        $("#superHeroList").append("</tr>");
    }
};


//Add items to firebase from webpage
var makeCall = function (data) {
    objToAdd = {};
    var myRequest = new XMLHttpRequest();
    myRequest.open("POST", "https://coder-camp-contact.firebaseio.com/.json", true);
    myRequest.send(JSON.stringify(data));
    myRequest.onload = function () {
        if (this.status >= 200 && this.status <= 400) {
            //console.log(this.response);
            //alert("it worked");
        } else {
            //alert("there was a problem");
        }
    }
};


//Pull Items down from Firebase on page load
var getItems = function (id) {
    var pullFromFireBase = new XMLHttpRequest();
    pullFromFireBase.open("GET", "https://coder-camp-contact.firebaseio.com/.json", true);
    pullFromFireBase.send();
    pullFromFireBase.onload = function () {
        if (this.status >= 200 && this.status <= 400) {
            alert(this.response);
        }
        var data = (JSON.parse(this.response));
        for (var i in data) {
            data[i].id = i;
            superHeroHolder.superHeroArray.push(data[i]);
            superHeroHolder.displayHero();

        }
    };
};

//Edit Items in Modal
superHeroHolder.editItems = function (id) {
    //editHero = id;
    //for (var i = 0; i < superHeroHolder.superHeroArray.length; i++) {
    //    if (superHeroHolder.superHeroArray[i].id == id) {
    $("#editHeroName").val(superHeroHolder.superHeroArray[i].name);
    $("#editPower").val(superHeroHolder.superHeroArray[i].powers);
    $("#editIdentity").val(superHeroHolder.superHeroArray[i].secretIdentity);
    $("#editCity").val(superHeroHolder.superHeroArray[i].city);
    //$("#saveChangesBtn").onclick() = function () { superHeroHolder.saveChanges(id); };
    
};

    



//Save changes to item and "PUT" changes in Firebase
superHeroHolder.saveChanges = function (id) {
    var data = superHeroHolder.superHeroArray[id];
    for (var i = 0; i < superHeroHolder.superHeroArray.length; i++) {
        //if (superHeroHolder.superHeroArray[i].id == id) {
            //        data = new superHeroHolder.SuperHero(name, powers, secretIdentity, city)
            data.name = document.getElementById("editName").value,
            data.power = document.getElementById("editPower").value,
            data.secretIdentity = document.getElementById("editIdentity").value,
            data.city = document.getElementById("editCity").value;
            console.log(data);
        
        }

    //displayHero();



    var request = new XMLHttpRequest(data);
    request.open("PUT", "https://coder-camp-contact.firebaseio.com/.json", true);
    request.send(JSON.stringify(data));
    request.onload = function () {
        if (this.status >= 200 && this.status < 400) {
            alert("it connects");
            $("#myModal").modal("hide");
            displayHero();
        } else {
            alert("error on PUT" + this.response);
            console.log(data);
        }
    };
};

//Delete Super Hero from Firebase
superHeroHolder.killHero = function (id) {
    var hero = superHeroHolder.superHeroArray[id];

    var request = new XMLHttpRequest(hero);
    request.open("DELETE", "https://coder-camp-contact.firebaseio.com/.json", true);
    request.send(JSON.stringify(hero));
    request.onload = function () {
        if (this.status >= 200 && this.status < 400) {
            superHeroHolder.removeHero(id);
            superHeroHolder.displayHero();
        }
    }
};




getItems();
