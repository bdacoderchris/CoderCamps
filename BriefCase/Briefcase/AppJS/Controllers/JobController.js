app.controller('JobController', ['$scope', 'AJAXFactory', 'LoginFactory', '$location', '$compile', '$q', 'UserFactory', function ($scope, AJAXFactory, LoginFactory, $location, $compile, $q, UserFactory) {

    $scope.userInfo = {};
    $scope.status = LoginFactory.status;
    $scope.jobStorage = [];
    $scope.tenMore = 20;
    //$scope.user = {
    //    username : '', password : ''
    //}
    $scope.test = "test";
    // Search bar functionality
    $scope.baseUrl = 'http://api.indeed.com/ads/apisearch?publisher=6086980531593213&limit=20&format=json&v=2&q=';
    $scope.customUrl = '';
    $scope.query = '';
    $scope.location = '';

    $scope.urlMaker = function () {
        return $scope.baseUrl + $scope.query + '&l=' + $scope.location;
    }

    $scope.nextTenUrlMaker = function () {
        return $scope.customUrl + '&start=' + $scope.tenMore;
    }


    // Sends api call to indeed
    $scope.search = function () {
        $scope.customUrl = $scope.urlMaker();
        $scope.userInfo = UserFactory.userInfo;
        $location.path('/Home/Search');
        $scope.jobStorage = [];
        $.ajax({
            url: $scope.customUrl,
            dataType: 'JSONP',
            jsonpCallback: 'callback',
            type: 'GET',
            success: function (data) {
                for (var i in data.results) {
                    for (var ii in $scope.userInfo.Jobs) {
                        if (data.results[i].jobkey === $scope.userInfo.Jobs[ii].JobKey) {
                            console.log('match' + data.results[i].jobtitle)
                        }
                    }
                    data.results[i].id = i;
                    $scope.jobStorage.push(data.results[i]);
                    $scope.location = '';
                    $scope.query = '';
                }
                console.log($scope.jobStorage);
                document.getElementById("cardBody").innerHTML = "";

                var test = $compile("<div class='card film art animated flipInY' ng-repeat='job in jobStorage'> " +
                        "<a href='portfolio-item.html' class='thumb'>" +
                            "<span class='overlay'><span class='fa fa-search'></span></span>" +
                        "</a>" +
                        "<div class='card-body'>" +
                            "<h2><a href='{{job.url}}' target='_blank'>{{job.jobtitle}}</a></h2>" +
                            "<p>{{job.formattedLocation}}</p>" +
                        "</div><!-- end card-body -->" +
                        "<div class='card-footer'>" +
                            "<ul class='list-inline filters'>" +
                                "<li><a ng-click='saveJob(job.id)'>Save Job</a></li>" +
                                "<li><a href='{{job.url}}' target='_blank'>Apply <span class='fa fa-external-link' style='font-size: .75em;'></span></a></li>" +
                            "</ul>" +
                        "</div><!-- end card-footer -->" +
                    "</div>" +
                    "<i id='load-more-icon' ng-click='nextTen()' style='-webkit-animation-delay: 2s; -webkit-animation-iteration-count: 2; position: fixed; right: 10px; bottom: 10px; color: #8E8E8E; text-align: center;' class='fa fa-angle-double-down fa-2x animated bounce'><span style='font-size: 16px;'></span></1>")($scope);

                $("#cardBody").append(test);
                $scope.$apply();
                
            },
            error: function (data) {
                console.log('ERROR: ' + data);
            }

        })
    }


    // Enter search key pressed
    $('.enter').keypress(function (e) {
        if (e.which == 13) {
            $scope.search();
        }
    });


    // Gets the next ten search results
    $scope.nextTen = function () {
        $.ajax({
            url: $scope.nextTenUrlMaker(),
            dataType: 'JSONP',
            jsonpCallback: 'callback',
            type: 'GET',
            success: function (data) {
                for (var i in data.results) {
                    data.results[i].id = i;
                    $scope.jobStorage.push(data.results[i]);
                }
                console.log($scope.jobStorage);
                document.getElementById("cardBody").innerHTML = "";

                var test = $compile("<div class='card film art' ng-repeat='job in jobStorage'> " +
                        "<a href='portfolio-item.html' class='thumb'>" +
                            "<span class='overlay'><span class='fa fa-search'></span></span>" +
                        "</a>" +
                        "<div class='card-body'>" +
                            "<h2><a href='{{job.url}}'>{{job.jobtitle}}</a></h2>" +
                            "<p>{{job.formattedLocation}}</p>" +
                        "</div><!-- end card-body -->" +
                        "<div class='card-footer'>" +
                            "<ul class='list-inline filters'>" +
                                "<li><a ng-click='saveJob(job.id)'>Save Job</a></li>" +
                                "<li><a href='{{job.url}}' target='_blank'>Apply <span class='fa fa-external-link' style='font-size: .75em;'></span></a></li>" +
                            "</ul>" +
                        "</div><!-- end card-footer -->" +
                    "</div>" +
                    "<i id='load-more-icon' ng-click='nextTen()' style='-webkit-animation-delay: 2s; -webkit-animation-iteration-count: 2; position: fixed; right: 10px; bottom: 10px; color: #8E8E8E; text-align: center;' class='fa fa-angle-double-down fa-2x animated bounce'><span style='font-size: 16px;'></span></1>")($scope);

                $("#cardBody").append(test);
                $scope.$apply();
                $scope.tenMore += 20;

            },
            error: function (data) {
                console.log('ERROR: ' + data);
            }
        })
    }

    // Update job status
    $scope.updateJobStatus = function () {
        var newStatus = {
            Applied: $scope.applied,
            PhoneInterview: $scope.phoneInterview,
            FirstInterview: $scope.firstInterview,
            SecondInterview: $scope.secondInterview,
            Offer: $scope.offer,
            FollowUp1: $scope.followUp1,
            FollowUp2: $scope.followUp2,
            FollowUp3: $scope.followUp3,
            Notes1: $scope.notes1,
            Notes2: $scope.notes2,
            IsDeleted: $scope.isDeleted
        };
        AJAXFactory.post('api/Jobs/UpdateJobStatus', newStatus);
    }



    // Delete job from view on job details modal 
    $scope.deleteJob = function (id) {
        AJAXFactory.get('api/Users/DeleteUserJob/' + id).then(function () {
            $scope.getUserInfo();
        });

    }

    // Save a job to the job database
    $scope.saveJob = function (id) {
        $scope.jobRef = $scope.jobStorage[id];
        $scope.tempJob = {
            Title: $scope.jobRef.jobtitle,
            Company: $scope.jobRef.company,
            JobKey: $scope.jobRef.jobkey,
            IsActive: !$scope.jobRef.expired,
            Location: $scope.jobRef.formattedLocation
        };
        console.log($scope.tempJob);
        AJAXFactory.post('api/Jobs/CreateJob', $scope.tempJob).then(function () {
            $("#success-alert").alert();
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                $("#success-alert").hide();
            })
        });
    }

    $(document).ready(function () {
        $("#success-alert").hide();
    });

    // Get single job and put info into jobInfo
    $scope.jobInfo = {};
    $scope.getJob = function (id) {
        AJAXFactory.get('api/Jobs/GetJob/' + id).then(function (data) {
            $scope.jobInfo = data;
        });
    }

}]);