var localDataService = angular.module('localDataService', ['ngResource']);

var randomize = true;
var urlRandom = "";
if (randomize)
    urlRandom = "?" + +Math.random();

localDataService.factory('ResultData', ['$resource',
  function($resource){
      return $resource('JsApp/moks/data.json' + urlRandom, {}, {
        query: {
            method: 'GET',
            isArray: false
        }
    });
  }]);

localDataService.factory('Menu', ['$resource',
  function ($resource) {
      return $resource('JsApp/moks/menu.json' + urlRandom, {}, {
          query: {
              method: 'GET',
              isArray: true
          }
      });
  }]);

