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

.controller('AddItemsCtrl', function($rootScope, $scope,$state) {
	$scope.text = "add items!";
	
	//$scope.showSelectValue = function(mySelect) {
	//  console.log(mySelect);
	//}
	
	$scope.addItem = function(code,name,imageUrl,qty,price){
		var newProd = JSON.parse("{\"Product\":{\"ImageUrl\":\""+imageUrl+"\",\"IsHealthy\":false,\"PricePerUnit\":"+price+",\"ProductId\":"+code+",\"QuantityUnit\":\"1 unit\",\"ShortDescription\":\""+name+"\"},\"Quantity\":"+qty+",\"ShoppingListProductId\":"+code+"}");
		$rootScope.shoppinglist.push(newProd);
		
		
		
		$state.go('app.shoppinglist');
	};
	
	$scope.scan = function() {
		cordova.plugins.barcodeScanner.scan(
		function (result) {
		
		/*
		alert("We got a barcode\n" +
		"Result: " + result.text + "\n" +
		"Format: " + result.format + "\n" +
		"Cancelled: " + result.cancelled);
		*/
		
		$rootScope.addedbarcode = result.text;
		
		//alert($rootScope.shoppinglist.length);
		
		//alert(JSON.stringify($rootScope.shoppinglist[0]));
		
		var newProd = JSON.parse("{\"Product\":{\"ImageUrl\":\"http:\/\/web-images.chacha.com\/images\/Gallery\/4711\/do-you-know-pirate-lingo-1405104939-sep-18-2012-1-600x400.jpg\",\"IsHealthy\":false,\"PricePerUnit\":33.633,\"ProductId\":233,\"QuantityUnit\":\"1 litre\",\"ShortDescription\":\"Mystery Item\"},\"Quantity\":1,\"ShoppingListProductId\":224}");
	
		//alert(newProd);	
		
		$rootScope.shoppinglist.push(newProd);
		
		//alert($rootScope.shoppinglist.length);
		
		
		
		
		$state.go('app.shoppinglist');
		
			
		},
		function (error) {
		alert("Scanning failed: " + error);
		}
		);
	};
	
})

.controller('BusyCtrl',function($scope){
	$scope.busyMeter1 = null;
      $scope.busyMeter2 = null;
      $scope.showMeters = function() {
        $scope.busyMeter1 = c3.generate({
          bindto: '#busyMeter1',
          data: {
            columns: [
              ['data', 45]
            ],
            type: 'gauge',
          },
          color: {
            pattern: ['#00ff00','#FF8000', '#ff3300'],
            threshold: {
              values: [10, 40, 80]
            }
          },
          size: {
            height: 100
          }

        });

        $scope.busyMeter2 = c3.generate({
          bindto: '#busyMeter2',
          data: {
            columns: [
              ['data', 32]
            ],
            type: 'gauge',
          },
          color: {
            pattern: ['#00ff00','#FF8000', '#ff3300'],
            threshold: {
              values: [10,40, 80]
            }
          },
          
          size: {
            height: 100
          }

        });

        $scope.busyMeter1.setTimeout(function () {
          $scope.busyMeter1.load({
            columns: [['data', 10]]
          });
          $scope.busyMeter2.load({
            columns: [['data', 10]]
          });
        }, 1000);

      };
})

.controller('MapCtrl', function($scope) {
	$scope.text = "map!";
	
	//$scope.showSelectValue = function(mySelect) {
	//  console.log(mySelect);
	//}
	
	$scope.map = "img/map.png";

	ble.isEnabled(
				function() {
					
					  
					  
					var timer = setInterval(function(){
					
					ble.stopScan;
					ble.startScan(
						[],
						function(device) {
							//$scope.broadcast("foundItemEvent",["Device"]);

							//alert("Xx");
							$scope.$apply( function() {
								//alert("cc");
								switch(device.id)
								{
									case "D0:5F:B8:30:E3:F1":
										$scope.foundItem = "Banana";
										break;
									case "D0:5F:B8:30:DE:AC":
										$scope.foundItem = "Wine";
										break;
								};
								 
							});
							
							alert("Found some: " + $scope.foundItem);
							//ble.disconnect(device.id, function(data){}, function(data){});
						},
						function() {
							//alert("nope!");
						}
					);
					
					},
						3000 /*,
						function() { console.log("Scan complete"); },
						function() { console.log("stopScan failed"); }*/
					);
					
					$scope.$on('$ionicView.beforeLeave', function(){
						clearInterval(timer);
						//alert("Before Leaving Map");
					});
					
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

.controller('DoneCtrl', function($rootScope,$scope) {
      $scope.chart = null;
      $scope.showGraph = function() {
        $scope.chart = c3.generate({
          bindto: '#chart',
          data: {
            columns: [
              ['Health', 30, 200, 100, 400, 150, 250],
              ['Budget', 50, 20, 10, 40, 15, 25]
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
              ['data', ($rootScope.impVars.HealthyCount /$rootScope.impVars.ItemCount)*100]
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
              ['data', ($rootScope.impVars.TotalPrice/$rootScope.impVars.Budget ) * 100]
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
        }, 1000);

      };
})
	
.controller('ShoppingListCtrl', function($rootScope, $scope, $http) {	
	//watch the shopping list and update the total
	
	
	
	$http.get('http://testazure.cloudapp.net/Service1.svc/GetProductsInShoppingList').
		success(function (data) {
			$rootScope.shoppinglist = data;	
			
			
			
			$rootScope.impVars = {};
			$rootScope.impVars.TotalPrice = 0;
			$rootScope.impVars.HealthyCount = 0;
			$rootScope.impVars.Budget = 100;
			$rootScope.impVars.ItemCount = 0;
			$rootScope.impVars.BudgetHealthColor = "green";
			
			
			for (var i = 0; i < $rootScope.shoppinglist.length; i++) {
				//$rootScope.impVars.TotalPrice +=  ($rootScope.shoppinglist[i].Quantity * $rootScope.shoppinglist[i].Product.PricePerUnit);  //
				if($rootScope.shoppinglist[i].Product.IsHealthy)
				{
					$rootScope.impVars.HealthyCount += 1;
				}
				$rootScope.impVars.ItemCount += 1;
				
			}
			
			
			var timerTotalCheck = setInterval(function(){
				 
					$rootScope.impVars.TotalPrice = 0;

					for (var i = 0; i < $rootScope.shoppinglist.length; i++) {
						$rootScope.impVars.TotalPrice +=  ($rootScope.shoppinglist[i].Quantity * $rootScope.shoppinglist[i].Product.PricePerUnit);
					}
					
					$rootScope.impVars.BudgetHealthColor = (($rootScope.impVars.TotalPrice/$rootScope.impVars.Budget)>.9)?"Red":((($rootScope.impVars.TotalPrice/$rootScope.impVars.Budget)>.5)?"Orange":"Green");
				}
			,1500);
			
			
			
			$rootScope.$watchCollection(function() {
				return $rootScope.shoppinglist;
			}, function() {
					$rootScope.impVars.TotalPrice = 0;
					
					for (var i = 0; i < $rootScope.shoppinglist.length; i++) {
						$rootScope.impVars.TotalPrice +=  ($rootScope.shoppinglist[i].Quantity * $rootScope.shoppinglist[i].Product.PricePerUnit);
					}
					
			});

			
			/*
			$rootScope.TotalPrice = $rootScope.impVars.TotalPrice;
			$rootScope.Budget = $rootScope.impVars.Budget;
			$rootScope.HealthyCount = $rootScope.impVars.HealthyCount;
			$rootScope.ItemCount = $rootScope.impVars.ItemCount;
			*/
			
			
			
			ble.isEnabled(
				function() {
					
					  
					  
					var timer = setInterval(function(){
					
					ble.stopScan;
					ble.startScan(
						[],
						function(device) {
							//$scope.broadcast("foundItemEvent",["Device"]);

							//alert("Xx");
							$scope.$apply( function() {
								//alert("cc");
								switch(device.id)
								{
									case "D0:5F:B8:30:E3:F1":
										$scope.foundItem = "Banana";
										break;
									case "D0:5F:B8:30:DE:AC":
										$scope.foundItem = "Wine";
										break;
								};
								 
							});
							
							//alert("Found some: " + $scope.foundItem);
							//ble.disconnect(device.id, function(data){}, function(data){});
						},
						function() {
							//alert("nope!");
						}
					);
					
					},
						3000 /*,
						function() { console.log("Scan complete"); },
						function() { console.log("stopScan failed"); }*/
					);
					
					/*
					$scope.$on('$ionicView.beforeLeave', function(){
						clearInterval(timer);
						//alert("Before Leaving Map");
					});
					*/
				},
				function() {
					alert("Bluetooth is *not* enabled");
				}
			);
			
			/*
			$scope.$on('$ionicView.beforeLeave', function(){
						clearInterval(timerTotalCheck);
					});
			*/
			
		}).
		error(function (data, status, headers, config) {
			$scope.shoppinglist = status ;
		}
	);	
		
		
	
	$scope.removeProduct = function($id) {		
		for (var i = 0; i < $rootScope.shoppinglist.length; i++) {
			if ($rootScope.shoppinglist[i].ShoppingListProductId == $id) {
				if($rootScope.shoppinglist[i].Product.IsHealthy == true)
				{					
					$rootScope.impVars.HealthyCount = $rootScope.impVars.HealthyCount - 1;					
				}
				
				//$rootScope.impVars.TotalPrice = $rootScope.impVars.TotalPrice - ($rootScope.shoppinglist[i].Quantity * $rootScope.shoppinglist[i].Product.PricePerUnit);
				$rootScope.shoppinglist.splice(i--, 1);
			}
		}
	};	
	
	
})

.controller('ProductCtrl', function($scope, $stateParams) {
})
;