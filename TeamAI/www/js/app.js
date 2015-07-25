// Ionic Starter App

// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
// 'starter.controllers' is found in controllers.js
angular.module('starter', ['ionic', 'starter.controllers'])

.run(function($ionicPlatform) {
  $ionicPlatform.ready(function() {
    // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
    // for form inputs)
    if (window.cordova && window.cordova.plugins.Keyboard) {
      cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
      cordova.plugins.Keyboard.disableScroll(true);

    }
    if (window.StatusBar) {
      // org.apache.cordova.statusbar required
      StatusBar.styleDefault();
    }
  });
})

.config(function($stateProvider, $urlRouterProvider) {
  $stateProvider

    .state('app', {
    url: '/app',
    abstract: true,
    templateUrl: 'templates/menu.html',
    controller: 'AppCtrl'
  })

    .state('app.userprofile', {
      url: '/userprofile',
      views: {
        'menuContent': {
          templateUrl: 'templates/userprofile.html',
          controller: 'UserProfileCtrl'
        }
      }
    })

  
.state('app.shoppinglist', {
    url: '/shoppinglist',
    views: {
      'menuContent': {
        templateUrl: 'templates/shoppinglist.html',
        controller: 'ShoppingListCtrl'
      }
    }
  })
  
  .state('app.single', {
    url: '/shoppinglist/:productid',
    views: {
      'menuContent': {
        templateUrl: 'templates/product.html',
        controller: 'ProductCtrl'
      }
    }
  })

  .state('app.trend', {
      url: '/trend',
      views: {
        'menuContent': {
          templateUrl: 'templates/trend.html'

        }
      }
    })
	
	.state('app.busyness', {
      url: '/busyness',
      views: {
        'menuContent': {
          templateUrl: 'templates/busyness.html'
        }
      }
    })

    .state('app.settings', {
      url: '/settings',
      views: {
        'menuContent': {
  	    templateUrl: 'templates/settings.html',
  	    controller: 'SettingsCtrl'
        }
      }
    })

    .state('app.additems', {
      url: '/additems',
      views: {
        'menuContent': {
  	    templateUrl: 'templates/additems.html',
  	    controller: 'AddItemsCtrl'
        }
      }
    })

    .state('app.map', {
      url: '/map',
      views: {
        'menuContent': {
  	    templateUrl: 'templates/map.html',
  	    controller: 'MapCtrl'
        }
      }
    })

    .state('app.scan', {
      url: '/scan',
      views: {
        'menuContent': {
  	    templateUrl: 'templates/scan.html',
  	    controller: 'ScanCtrl'
        }
      }
    })

    .state('app.search', {
      url: '/search',
      views: {
        'menuContent': {
  	    templateUrl: 'templates/search.html',
  	    controller: 'SearchCtrl'
        }
      }
    })

    .state('app.done', {
      url: '/done',
      views: {
        'menuContent': {
  	    templateUrl: 'templates/done.html',
  	    controller: 'DoneCtrl'
        }
      }
    })


  //  .state('app.playlists', {
  //    url: '/playlists',
  //    views: {
  //      'menuContent': {
  //        templateUrl: 'templates/playlists.html',
  //        controller: 'PlaylistsCtrl'
  //      }
  //    }
  //  })
  //
  //.state('app.single', {
  //  url: '/playlists/:playlistId',
  //  views: {
  //    'menuContent': {
  //      templateUrl: 'templates/playlist.html',
  //      controller: 'PlaylistCtrl'
  //    }
  //  }
  //}
  //);
  // if none of the above states are matched, use this as the fallback
  $urlRouterProvider.otherwise('/app/shoppinglist');
});
