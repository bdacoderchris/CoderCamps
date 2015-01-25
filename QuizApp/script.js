var Quiz = [
     {
         question: "What is your favorite color?",
         options: ["Red", "Blue", "Green", "None of the Above"],
         answer: "Blue"
     },
      {
          question: "What is your favorite color",
          options: ["Red", "Blue", "Green", "None of the Above"],
          answer: "Blue"
      },
       {
           question: "What is your favorite color",
           options: ["Red", "Blue", "Green", "None of the Above"],
           answer: "Blue"
       },
        {
            question: "What is your favorite color",
            options: ["Red", "Blue", "Green", "None of the Above"],
            answer: "Blue"
        },
         {
             question: "What is your favorite color",
             options: ["Red", "Blue", "Green", "None of the Above"],
             answer: "Blue"
         }
];




var $ = function (id) {
    return document.getElementById(id);
};

var content = $("content"),
    questionContainer = $("question"),
    choiceContainer = $("options"),
    submitContainer = $("submit"),
    scoreContainer = $("score");

var currentQuestion = 0,
    currentScore = 0,
    askingQuestion = true;

function askQuestion() {
    var choices =
        Quiz[currentQuestion].options,
        choicesForQuestion = "";
    var question =
        Quiz[currentQuestion].question,
        questionDisplay = "";

    for (var i = 0; i < choices.length; i++) {
        choiceContainer.innerHTML += '<input type="radio" name="answerRadio"' + currentQuestion + 'id="choices"' + (i + 1) + 'value=' + choices[i] + '>' +
        '<label for="choices"' + (i + 1) + '>' + choices[i] + '</label><br/>';
    }

    //choiceContainer.textContent = Quiz[currentQuestion].options;
    questionContainer.textContent = "Question " + (currentQuestion + 1) + ": " + Quiz[currentQuestion].question;

    //choiceContainer.innerHTML = choicesForQuestion;

    if (currentQuestion === 0) {
        scoreContainer.textContent =
            "Score: 0 Correct Answers out of " + Quiz.length + " Possible.";

    }
}

var submitAnswer = function () {
    //function check() {
    //   var radioChecked = document.getElementById("choices").check
    //}
    var radioChecked = document.getElementsByClassName("answerRadio"),
        userAnswer = "",
        formQuestion = document.getElementsByClassName("quizContent")
        ;
    var len = document.quizContent.answerRadio.length;

    for (var i = 0; i < len; i++) {
        if (document.quizContent.answerRadio[i].checked) {
            userAnswer=document.quizContent.answerRadio[i].value
        }
    }
    if (userAnswer = "") {
        alert("Please select an answer")
    } else {
        if (document.quizContent.answerRadio[1].checked === true) {
            alert("You are correct! Blue is the best color");
        } else {
            alert("I'm sorry, that is not correct. Blue is way better")
        }
}
    return true;
};
askQuestion();

