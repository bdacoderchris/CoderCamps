app.controller('HomeController', ['$scope', '$timeout', 'LoginFactory', 'AJAXFactory', 'UserFactory', '$location', '$compile', '$controller', '$http', function ($scope, $timeout, LoginFactory, AJAXFactory, UserFactory, $location, $compile, $controller, $http) {

    var jobController = $scope.$new();
    $controller('JobController', { $scope: jobController });

    $scope.jobDetails = {
        Title: "This is where your saved jobs will show up!",
        Company: "Do a search to find jobs,",
        Location: "and save them to your profile.",
        Applied: false,
        FirstInterview: null,
        FollowUp1: null,
        FollowUp2: null,
        FollowUp3: null,
        IsActive: true,
        IsDeleted: false,
        JobId: null,
        JobKey: "",
        Notes1: null,
        Notes2: null,
        Offer: false,
        PhoneInterview: null,
        PocId: null,
        PocId2: null,
        SecondInterview: null,
        StatusId: ""
    };

    $scope.states = [];

    $scope.backendJobDetails = {};


    $scope.hasApplied = false;

    $scope.deleteJob = function (id) {
        jobController.deleteJob(id);
    }

    $scope.status = LoginFactory.status;
    $scope.user = {
        username: '', password: ''
    }
    //Login and get User information
    $scope.userInfo = {};

    $scope.login = function () {
        $scope.user.username = $scope.email;
        $scope.user.password = $scope.password;
        console.log($scope.user);
        LoginFactory.login($scope.user)
        .then(function () {
            $scope.getUserInfo();
            $scope.email = "";
            $scope.password = "";
            $location.path('/');
        })
        
    }

    // Enter Login key pressed
    $('.enter-login').keypress(function (e) {
        if (e.which == 13) {
            $scope.login();
        }
    });

    $scope.updateUserInfo = function () {
        AJAXFactory.post('api/Users/UpdateUser', $scope.userInfo)
        .then(function () {
            $scope.getUserInfo();
        });
    }

    $scope.logout = function () {
        LoginFactory.logout();
    }
    $scope.getUserInfo = function () {
        LoginFactory.getInfo().then(function (data) {
            $scope.userInfo = data;
            UserFactory.userInfo = data;
            if ($scope.userInfo.Jobs.length < 1) {
                $scope.userInfo.Jobs.push({
                    Title: "This is where your saved jobs will show up!",
                    Company: "Do a search to find jobs,",
                    Location: "and save them to your profile."
                });
            }
            if ($scope.userInfo.Addresses[0].City === null && $scope.userInfo.Addresses[0].State.StateAbbreviation === null) {
                $scope.userInfo.Addresses[0].City = "City";
                $scope.userInfo.Addresses[0].State.StateAbbreviation = "State";
            }
            if ($scope.userInfo.Image == null || $scope.userInfo.Image == 0) {
                $scope.userInfo.Image = "../../\img/DefaultImage.jpg"
            }
            $scope.states = data.States;
        })
    }

    if ($scope.status.loggedIn) $scope.getUserInfo();

    $scope.appliedToggle = function () {
        $scope.hasApplied = !$scope.hasApplied;
    }

    $scope.backendGetJob = function (id) {
        AJAXFactory.get('api/Jobs/GetJob/' + id)
        .then(function (data) {
            $scope.backendJobDetails = data;
            $scope.hasApplied = $scope.backendJobDetails.Applied;
            console.log($scope.backendJobDetails);
        });
    }

    $scope.getSingleJob = function (jobkey) {
        $location.path('/Home/Details');
        $scope.customUrl = "http://api.indeed.com/ads/apigetjobs?publisher=6086980531593213&v=2&format=json&jobkeys=" + jobkey;
        $.ajax({
            url: $scope.customUrl,
            dataType: 'JSONP',
            jsonpCallback: 'callback',
            type: 'GET',
            success: function (data) {
                $scope.jobDetails = data.results;

                document.getElementById("jobDetails").innerHTML = "";
                if ($scope.jobDetails.length < 1) {
                    var test = $compile(
                    "<div>" +
                        "<h5>This is where you'll be able to see details for your jobs and add events, like interviews!</h5>" +
                    "</div>"
                    )($scope);
                    $("#jobDetails").append(test);
                    $scope.$apply();
                } else {
                    var test = $compile(
                    "<div>" +
                        "<h2>Job Details</h2>" +
                        "<h4><a href='{{jobDetails[0].url}}' target='_blank' style='text-decoration: none;'>{{jobDetails[0].jobtitle}} <span class='fa fa-external-link' style='font-size: .75em;'></span></a></h4>" +
                        "<h5>{{jobDetails[0].company}}</h5>" +
                        "<h5>{{jobDetails[0].formattedLocation}}</h5>" +
                        "<button class='btn btn-success' ng-hide='hasApplied' ng-click='appliedToggle(); haveApplied()'>I have applied</button>" +
                        "<button class='btn btn-danger' ng-show='hasApplied' ng-click='appliedToggle(); haveApplied()'>Oops, I haven't applied, actually</button>" +
                        "<div ng-show='hasApplied'>" +
                            "<h5>Phone Interview: {{backendJobDetails.PhoneInterview  | date:'MM/dd/yyyy'}}</h5>" +
                            "<h5>First In-Person Interview: {{backendJobDetails.FirstInterview | date:'MM/dd/yyyy'}}</h5>" +
                            "<h5>Second In-Person Interview: {{backendJobDetails.SecondInterview | date:'MM/dd/yyyy'}}</h5>" +
                            "<button class='btn btn-default' data-target='#event-modal' data-toggle='modal'>Add An Event</button>" +
                        "</div>" +

                    "</div>"
                    )($scope);
                    $("#jobDetails").append(test);
                    $scope.$apply();
                }
            }
        })
    }


    //Send email
    $scope.sendEmail = function () {
        $http.get('api/Emails/WelcomeEmail');
    }

    //Update applied status
    $scope.haveApplied = function () {
        $scope.backendJobDetails.Applied = !$scope.backendJobDetails.Applied;
        AJAXFactory.post('api/Jobs/UpdateJobStatus', $scope.backendJobDetails);
    }

    //Add event to job status
    $scope.updateJobStatus = function () {
        AJAXFactory.post('api/Jobs/UpdateJobStatus', $scope.backendJobDetails)
        .then(function () {
            $scope.getSingleJob($scope.backendJobDetails.JobKey);
        });
    }

    //Create a new User
    $scope.createUser = function () {
        if ($scope.password === $scope.confirmPassword) {
            AJAXFactory.post('api/Users/CreateUser', { firstname: $scope.firstName, lastname: $scope.lastName, email: $scope.email, password: $scope.password, confirmPassword: $scope.confirmPassword })
            .then(function (data) {
                $scope.login();
                $scope.getUserInfo();
                $scope.firstName = "";
                $scope.lastName = "";
                $scope.email = "";
                $scope.password = "";
                $scope.confirmPassword = "";
            });
        } else {
            alert("Passwords don't match");
        }
        
    }

    //Enter Login key pressed
    $('.enter-register').keypress(function (e) {
        if (e.which == 13) {
            $scope.createUser();
        }
    });



    //Create a new POC for a saved job
    $scope.createContact = function () {
        AJAXFactory.post('api/Users/CreateContact', { firstname: $scope.contactFirstName, lastname: $scope.contactLastName, email: $scope.contactEmail, phone: $scope.contactPhone })
        .then(function (data) {

        })
    }
    //Update User account information
    $scope.updateUser = function () {
        AJAXFactory.post('api/Users/UpdateUser', { firstname: $scope.firstName, lastname: $scope.lastName, email: $scope.email, password: $scope.password, confirmPassword: $scope.confirmPassword })
            .then(function (data) {
                $scope.getUserInfo();
            })
    }
    //Update POC at a saved job
    $scope.updateContact = function () {
        AJAXFactory.post('api/Users/UpdateContact', { firstname: $scope.contactFirstName, lastname: $scope.contactLastName, email: $scope.contactEmail, phone: $scope.contactPhone })
            .then(function (data) {

            })
    }
    //Delete User Account
    $scope.deleteUser = function () {
        AJAXFactory.get('api/Users/DeleteUser').then(function () {
            $scope.logout();
            //$location.path('/')
        })
    }
    //Delete POC at a saved job
    $scope.deleteContact = function () {
        AJAXFactory.get('api/Users/DeleteContact').then(function () {

        })
    }

    $("#profile-picture").change(function (e) {
        e.preventDefault();

        function getBase64Image(img) {
            // Create an empty canvas element
            var canvas = document.createElement("canvas");
            canvas.width = img.width;
            canvas.height = img.height;

            // Copy the image contents to the canvas
            var ctx = canvas.getContext("2d");
            ctx.drawImage(img, 0, 0);

            var dataURL = canvas.toDataURL("image/png");

            return dataURL.replace(/^data:image\/(png|jpg);base64,/, "");
        }

        var file = this.files[0],
            reader = new FileReader();

        reader.onload = function (event) {
            var img = new Image();

            img.src = event.target.result;
            //img.width = 150;
            //img.height = 150;

            $('#avatar-image').html(img);

            var i = getBase64Image(img);

            $.ajax({
                url: 'https://api.imgur.com/3/image',
                type: 'POST',
                headers: {
                    Authorization: 'Client-ID 1f801d155c44221'
                },
                data: {
                    type: 'base64',
                    name: 'briefcase-image.jpg',
                    title: $scope.user.username + "-BC-Image",
                    description: 'http://briefcase.azurewebsites.net/',
                    image: i
                },
                dataType: 'json'
            }).success(function (data) {
                $('#save-avatar').removeClass('disabled');
                var url = 'http://imgur.com/' + data.data.id;
                $scope.userInfo.Image = url + '.jpg';
                $scope.updateUserInfo();
            });
        }
        reader.readAsDataURL(file);


    });


}])