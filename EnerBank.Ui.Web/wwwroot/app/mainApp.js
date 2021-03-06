﻿var app = angular.module('EnerBankApp',
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
                templateUrl: "app/views/home.html",
                controller: "resultController",
                controllerAs: "result"
            }).
            when('/home', {
                templateUrl: "app/views/home.html",
                controller: "resultController",
                controllerAs: "result"
            }).
            when("/about", {
                templateUrl: "app/views/about.html",
            }).
            otherwise({
                redirectTo: '/',
                templateUrl: "app/views/home.html",
                controller: "resultController",
                controllerAs: "result"
            });
            
            $locationProvider.html5Mode(true);
               // .hashPrefix('!');
            
      }]);


