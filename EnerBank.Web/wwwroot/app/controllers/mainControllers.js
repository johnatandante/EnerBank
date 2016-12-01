var mainControllers = angular.module('mainControllers', ['localDataService', 'ui.bootstrap']);

mainControllers.filter('unvisible', function () {
    return function (data, property) {
        var ret = [];
        if (!data)
            return ret;

        var ret = [];
        angular.forEach(data, function (item) {
            if (!item[property])
                ret.push(item);

        });

        return ret;

    }
});

mainControllers.filter('isvisible', function () {
    return function (data, property) {
        var ret = [];
        if (!data)
            return ret;

        angular.forEach(data, function (item) {
            if (item[property])
                ret.push(item);

        });

        return ret;

    }
});

mainControllers.filter('filterimporto', function () {
    return function (data, value) {
        var ret = [];
        if (!data)
            return ret;

        angular.forEach(data, function (item) {
            if (item.importo.toString().indexOf(value) >= 0 
                || item.numero.toString().indexOf(value) >= 0)
                ret.push(item);

        });

        return ret;

    }
});

mainControllers.controller('navController',
    ['$location', 'Menu', function ($location, Menu) {
        var thisObj = this;

        Menu.query(function (data) {
            if (!data) {
                thisObj.locations = [];
                return;
            }

            thisObj.locations = data;

        })

        this.isActive = function (viewLocation) {
            return viewLocation === $location.path()
                && thisObj.locations[viewLocation];
        };

        this.doAction = function (menuItem, userInfo) {
            if (!menuItem.action)
                return;

            menuItem.action();

        };

    }]);

mainControllers.controller('mainController',
    ['$scope', '$location', function ($scope, $location) {
        
        $scope.version = "0.01";
        $scope.appName = "Result viewer"
        $scope.appFullName = $scope.appName + " (for lazy people)";
        
        $scope.mailTo = "dante.delfavero@gmail.com";
        $scope.mailToDescription = "dante.delfavero at gmail.com";
                
    }]);

mainControllers.controller('resultController',
    ['$scope', 'ResultData', function ($scope, ResultData) {
        var thisObj = this;

        thisObj.ElementId = "";
        thisObj.query = "";
        thisObj.selectedFile = { sourceFile: null, filterFile : null };
        var scope = $scope;

        $scope.file_changed = function (element, elementId, $scope) {
            try {
                thisObj.ElementId = elementId;
                thisObj.selectedFile[elementId] = document.getElementById(elementId).files[0].name;                
                scope.$apply();
            } catch (err) {
                thisObj.selectedFile = "";;
            }
        };

        // Mocked Data
        //ResultData.query(function (data) {
        //    if (!data) {
        //        thisObj.data = "";
        //        thisObj.results = [];
        //        return;
        //    }
        
        //    thisObj.results = data.resultItems;
        
        //});
        
        this.Clear = function () {
            thisObj.results = undefined;
            thisObj.selectedFile = { sourceFile: null, filterFile: null };

        };

        this.Upload = function () {
            var data = new FormData();
            var form = $('#inputform')[0];
            data.append('file-0', form['sourceFile'].files[0]);
            data.append('file-1', form['filterFile'].files[0]);
                        
            $.ajax({
                url: 'api/evaluate',
                data: data,
                cache: false,
                processData: false,
                type: 'POST',
                contentType: false,
                mimeType: 'text/csv'
            }).done(function (data) {
                thisObj.results = thisObj.ReadJson(data);
            }).error(function () {
                thisObj.results = [];
            }).fail(function () {
                thisObj.results = [];
            }).always(function () {
                scope.$apply();
            });

        };

        this.UploadLastFile = function () {
            var f = document.getElementById(thisObj.ElementId).files[0],
                r = new FileReader();
            thisObj.selectedFile = f.name;
            r.onloadend = function (e) {
                var data = e.target.result;
                thisObj.results = thisObj.ReadCsv(data);
                scope.$apply();
            }
            r.readAsBinaryString(f);
        };

        this.ReadCsv = function (stream) {
            var records = stream.split("\n");
            var items = [];
            for (var i = 0; i < records.length ; i++) {
                var item = u_csvToArray(records[i]);
                if (item.length > 1)
                    items.push({ importo: item[0], numero: item[1] });
            }

            return items;
             
        };
        this.ReadJson = function (jsonString) {
            var jsonObject = JSON.parse(jsonString);
            var items = [];
            for (var i = 0; i < jsonObject.length ; i++) {
                var item = jsonObject[i];
                if (item.length > 1)
                    items.push({ importo: item[0], numero: item[1] });
            }

            return items;

        };


    }]);

      
