var app = angular.module('EnerBankApp',
                            [
                                'mainControllers',
                                'ngRoute',
                            ]);
    // rewrite url
    // http://geekswithblogs.net/shaunxu/archive/2014/06/10/host-angularjs-html5mode-in-asp.net-vnext.aspx
    app.config(['$routeProvider', '$locationProvider',
      function ($routeProvider, $locationProvider) {
          $routeProvider.
            when('/', {
                templateUrl: "JsApp/views/home.html",
                controller: "resultController",
                controllerAs: "result"
            }).
            when('/home', {
                templateUrl: "JsApp/views/home.html",
                controller: "resultController",
                controllerAs: "result"
            }).
            when("/about", {
                templateUrl: "JsApp/views/about.html",
            }).
            otherwise({
                redirectTo: '/',
                templateUrl: "JsApp/views/home.html",
                controller: "resultController",
                controllerAs: "result"
            });
            
            $locationProvider.html5Mode(true);
               // .hashPrefix('!');
            
      }]);


