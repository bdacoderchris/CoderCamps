var superHeroArray = [];

var editHero = ""

function superHero(name, powers, secretIdentity, city) {
    this.name = name;
    this.powers = powers;
    this.secretIdentity = secretIdentity;
    this.city = city;
}



$("#superForm").submit(function (event) {
    event.preventDefault();

    $("#superHeroList").empty();

    var superNameSubmit = $("#superHeroNameId").val();
    var superSecretSubmit = $("#secretIdentityId").val();
    var superPowerSubmit = $("#superPowerId").val();
    var city = $("#currentCity").val();

    var tempSuperHolder = new superHero(superNameSubmit, superSecretSubmit, superPowerSubmit, city);
    superHeroArray.push(tempSuperHolder);

    makeCall(tempSuperHolder);
    displayHero();

});

var displayHero = function () {

    $("#superHeroList").empty();

    var len = superHeroArray.length,
    superHeroId;
    for (var i = 0; i < len; i++) {
        superHeroId = i
        $("#superHeroList").append("<tr>");
        $("#superHeroList").append("<td>" + superHeroArray[i].name + "</td>");
        $("#superHeroList").append("<td>" + superHeroArray[i].secretIdentity + "</td>");
        $("#superHeroList").append("<td>" + superHeroArray[i].powers + "</td>");
        $("#superHeroList").append("<td>" + superHeroArray[i].city + "</td>");
        $("#superHeroList").append("<td><input type='submit' class='icon-large icon-trash' id='Ship' data-toggle='modal' data-target='#myModal' value='Edit' /></td>");
        $("#superHeroList").append("</tr>");
    }
};

var makeCall = function (data) {
    var objToAdd = {};
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

var getItems = function (firebaseData) {
    var pullFromFireBase = new XMLHttpRequest();
    pullFromFireBase.open("GET", "https://coder-camp-contact.firebaseio.com/.json", true);
    pullFromFireBase.send();
    pullFromFireBase.onload = function () {
        if (this.status >= 200 && this.status <= 400) {
            console.log(this.response);
        }
        var data = (JSON.parse(this.response));
        for (var i in data) {
            data[i].id = i;
            superHeroArray.push(data[i]);
            displayHero();
        }
    };
};

var editItems = function (id) {
    editHero = id;
    for (var i = 0; i < superHeroArray.length; i++) {
        if (superHeroArray[i].id == id) {
            $("#editHeroName").val(superHeroArray[i].name);
            $("#editPower").val(superHeroArray[i].powers);
            $("#editIdentity").val(superHeroArray[i].secretIdentity);
            $("#editCity").val(superHeroArray[i].city);

        }
    }
}

var saveChanges = function () {
    var data;
    for (var i = 0; i < superHeroArray.length; i++) {
        if (superHeroArray[i].id !== editHero) {
            data = new superHero(
                document.getElementById("editHeroName").value,
                document.getElementById("editPower").value,
                document.getElementById("editIdentity").value,
                document.getElementById("editCity").value)
            superHeroArray[i] = data;
            displayHero();
        }
    }

    var request = new XMLHttpRequest();
    request.open("PUT", "https://coder-camp-contact.firebaseio.com/.json", true);
    request.send(JSON.stringify(data));
    request.onload = function () {
        if (this.status >= 200 && this.status < 400) {
            alert("it connects");
            displayHero();
        } else {
            alert("Error on " + "PUT" + ": " + this.response)
        }
    }
}


getItems();
