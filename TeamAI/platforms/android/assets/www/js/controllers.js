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
  $scope.flybuys = '6373 6765 2131 4623';
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

.controller('SettingsCtrl', function($scope) {
	$scope.healthmeter = true;
	$scope.budgetmeter = false;
	$scope.ethicmeter = true;

	//$scope.showSelectValue = function(mySelect) {
	//  console.log(mySelect);
	//}

})

.controller('AddItemsCtrl', function($scope) {
	$scope.text = "add items!";
	
	//$scope.showSelectValue = function(mySelect) {
	//  console.log(mySelect);
	//}
})

.controller('MapCtrl', function($scope) {
	$scope.text = "map!";
	
	//$scope.showSelectValue = function(mySelect) {
	//  console.log(mySelect);
	//}
})

.controller('DoneCtrl', function($scope) {
      $scope.chart = null;
      $scope.showGraph = function() {
        $scope.chart = c3.generate({
          bindto: '#chart',
          data: {
            columns: [
              ['number of cats', 30, 200, 100, 400, 150, 250],
              ['data2', 50, 20, 10, 40, 15, 25]
            ]
          }
        });
      };
})
	
.controller('ShoppingListCtrl', function($scope, $http) {	
	$http.get('http://testazure.cloudapp.net/Service1.svc/GetProductsInShoppingList').
	success(function (data) {
		//alert("Success" + data);
		$scope.shoppinglist = data;	
	}).
	error(function (data, status, headers, config) {
		//alert("Fail" + data);
		$scope.shoppinglist = status ;
	});	  	  
})

.controller('ProductCtrl', function($scope, $stateParams) {
})
;