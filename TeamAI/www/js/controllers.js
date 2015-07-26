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
	
	$scope.map = "img/map.png";

	ble.isEnabled(
		function() {
			ble.startScan(
				[],
				function(device) {
					if(device.id=="D0:5F:B8:30:E3:F1")
						alert("Look Around you! we found some bananas!");
				},
				function() {
					//alert("nope!");
				}
			);
			
			setTimeout(ble.stopScan,
				30000,
				function() { console.log("Scan complete"); },
				function() { console.log("stopScan failed"); }
			);
		},
		function() {
			alert("Bluetooth is *not* enabled");
		}
	);
	
 
})

.controller('ScanCtrl', function($scope) {
	$scope.text = "scan!";
	
	//$scope.showSelectValue = function(mySelect) {
	//  console.log(mySelect);
	//}
})

.controller('SearchCtrl', function($scope) {
		
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

      $scope.healthMeter = null;
      $scope.budgetMeter = null;
      $scope.showMeters = function() {
        $scope.healthMeter = c3.generate({
          bindto: '#healthMeter',
          data: {
            columns: [
              ['data', 91.4]
            ],
            type: 'gauge',
          },
          color: {
            pattern: ['#FF0000','#FF8000', '#008000'],
            threshold: {
              values: [10, 80, 100]
            }
          },
          size: {
            height: 180
          }

        });

        $scope.budgetMeter = c3.generate({
          bindto: '#budgetMeter',
          data: {
            columns: [
              ['data', 110]
            ],
            type: 'gauge',
          },
          color: {
            pattern: ['#008000','#FF8000', '#FF0000'],
            threshold: {
              values: [90, 100]
            }
          },
          
          size: {
            height: 180
          }

        });

        $scope.healthMeter.setTimeout(function () {
          $scope.healthMeter.load({
            columns: [['data', 10]]
          });
          $scope.budgetMeter.load({
            columns: [['data', 10]]
          });
        }, 3000);

      };
})
	
.controller('ShoppingListCtrl', function($scope, $http) {	

	//$scope.shoppinglist = "tempValue";
	
	$http.get('http://testazure.cloudapp.net/Service1.svc/GetProductsInShoppingList').
	success(function (data) {
		$scope.shoppinglist = data;	
		
		$scope.impVars = {};
		$scope.impVars.TotalPrice = 0;
		$scope.impVars.HealthyCount = 0;
		$scope.impVars.Budget = 10;
		
		for (var i = 0; i < $scope.shoppinglist.length; i++) {
			$scope.impVars.TotalPrice = $scope.impVars.TotalPrice + ($scope.shoppinglist[i].Quantity * $scope.shoppinglist[i].Product.PricePerUnit);
			if($scope.shoppinglist[i].Product.IsHealthy == true)
			{
				$scope.impVars.HealthyCount = $scope.impVars.HealthyCount + 1;
			}
		}
	}).
	error(function (data, status, headers, config) {
		$scope.shoppinglist = status ;
	});	
	
	$scope.removeProduct = function($id) {		
		for (var i = 0; i < $scope.shoppinglist.length; i++) {
			if ($scope.shoppinglist[i].ShoppingListProductId == $id) {
				if($scope.shoppinglist[i].Product.IsHealthy == true)
				{					
					$scope.impVars.HealthyCount = $scope.impVars.HealthyCount - 1;					
				}
				
				$scope.impVars.TotalPrice = $scope.impVars.TotalPrice - ($scope.shoppinglist[i].Quantity * $scope.shoppinglist[i].Product.PricePerUnit);
				$scope.shoppinglist.splice(i--, 1);
			}
		}
	}	
})

.controller('ProductCtrl', function($scope, $stateParams) {
})
;