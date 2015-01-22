//Create an input field, an array and 2 buttons.
//One button should push the value of the field into the array.
//Click the second button this should alert each element in the array one by one.
//Question 1
var fruitArray = ["apple", "pear", "orange", "banana"];
console.log(fruitArray);

var callInput = function () {
    var myNewFruit = document.getElementById("favFruit").value
    fruitArray.push(myNewFruit);
    console.log(myNewFruit);
}
var alertInput = function () {
    document.getElementsByTagName(fruitArray).value;
    for (var i = 0; i < fruitArray.length; i++) {
        alert(fruitArray[i]);
    }
    
}

//Question 2
var namesArray = new Array();
var enterNames = function () {
    
    document.getElementById("divNames").innerHTML = "";

    var newVariable = document.getElementById("divNamesInput").value;
    namesArray.push(newVariable);
    for (var i = 0; i < namesArray.length; i++) {
        document.getElementById("divNames").innerHTML += namesArray[i] + "</br>";
        
        console.log(namesArray[i]);
    }
}
//Question 3
var newItemArray = new Array();
var createArrayItem = function () {
    var newItem = document.getElementById("arrayElement").value;
    newItemArray.push(newItem);
    console.log(newItem);
};
var callArrayItem = function () {
    var callItem = document.getElementById("alertItemButton").innerHTML;
    for (var i = 0; i < newItemArray.length; i++) {
        if (document.getElementById("alertItemButton").value == newItemArray[i]); {
            alert(newItemArray[i]);
        }
    }
}
//Question 4
var createItem = new Array();
var addNewItem = function () {
    var newerItem = document.getElementById("newArrayElement").value;
    createItem.push(newerItem);
    console.log(newerItem);
};

var enterNewName = function () {
    var reverseItemArray = document.getElementById("newArrayElement").value;
    
    for (var i = 0; i < createItem.length; i++) {
        document.getElementById("newNamePrint").innerHTML = createItem +  "</br>";
        createItem.reverse();
    }
};

//Question 5
var newArray = new Array();
var addToArray = function () {
    var newestItem = document.getElementById("newerArrayElement").value;
    newArray.push(newestItem);
    console.log(newestItem);
};

var callByArray = function () {
    var arrayNumber = document.getElementById("addNewArrayItem").value;
    for (var i = 0; i < newArray.length; i++) {
        document.getElementById("addNewArrayItem").innerHTML;
    }
}

var printNewName = function () {
    var displayArrayItem = document.getElementById("newerArrayElement").value;
    
    for (var i = 0; i < newArray.length; i++) {
        document.getElementById("newItemPrint").innerHTML = newArray[i] + "</br>";
        newArray.forEach(callByArray);
    }
}




    
