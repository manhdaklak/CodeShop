/// <reference path="../../../scripts/angularui/ui-router.min.js" />
(function (app) {

    
    app.factory('apiService', apiService);
    apiService.$inject = ['$http'];
    function apiService($http) {
        return {
            get: get
        }
        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }), function (error) {
                failure(error);
            };
        }
    }
})(angular.module('myapp.common'));