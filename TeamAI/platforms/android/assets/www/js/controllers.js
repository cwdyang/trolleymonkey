angular.module('starter.controllers', [])

.controller('AppCtrl', function($scope, $ionicModal, $timeout) {

  // With the new view caching in Ionic, Controllers are only called
  // when they are recreated or on app start, instead of every page change.
  // To listen for when this page is active (for example, to refresh data),
  // listen for the $ionicView.enter event:
  //$scope.$on('$ionicView.enter', function(e) {
  //});

  // Form data for the login modal
  $scope.loginData = {};

  // Create the login modal that we will use later
  $ionicModal.fromTemplateUrl('templates/login.html', {
    scope: $scope
  }).then(function(modal) {
    $scope.modal = modal;
  });

  // Triggered in the login modal to close it
  $scope.closeLogin = function() {
    $scope.modal.hide();
  };

  // Open the login modal
  $scope.login = function() {
    $scope.modal.show();
  };

  // Perform the login action when the user submits the login form
  $scope.doLogin = function() {
    console.log('Doing login', $scope.loginData);

    // Simulate a login delay. Remove this and replace with your login
    // code if using a login system
    $timeout(function() {
      $scope.closeLogin();
    }, 1000);
  };
})

.controller('UserProfileCtrl', function($scope) {
        $scope.profilename = "Madeleine Bird";
      $scope.profilephoto = "img/profilephoto.jpg";
      $scope.gender = 'F';
      $scope.dateofbirth = '25/07/2015';
      $scope.flybuys = '40E0FE20-1C92-4AEF-8C17-B17067E9F98B';
      $scope.address = "210 Federal St\nAuckland\nNew Zealand";
      $scope.VegetarianYN = false;
      $scope.VeganYN = false;
      $scope.GreenYN = false;
      $scope.EuropeanYN = false;
      $scope.AsianYN = false;
      $scope.IndianYN = false;
      $scope.phone = "0212312314";
        $scope.store = 20;
      //$scope.showSelectValue = function(mySelect) {
      //  console.log(mySelect);
      //}

    })

    .controller('ShoppingListCtrl', function($scope, $http) {
      $scope.testVar = "Test value";
      $http.get('http://testazure.cloudapp.net/Service1.svc/Get1DataNoParams').
          success(function (data) {
            $scope.testVar = "SUCCESS" ;
            alert("Success" + data);
          }).
          error(function (data, status, headers, config) {
            $scope.testVar = status ;
            alert("Fail" + data);
          });


    })


.controller('PlaylistsCtrl', function($scope) {
  $scope.playlists = [
    { title: 'Reggae', id: 1 },
    { title: 'Chill', id: 2 },
    { title: 'Dubstep', id: 3 },
    { title: 'Indie', id: 4 },
    { title: 'Rap', id: 5 },
    { title: 'Cowbell', id: 6 }
  ];
})

.controller('PlaylistCtrl', function($scope, $stateParams) {
});
