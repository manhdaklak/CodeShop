
/// <reference path="../scripts/angular.js" />

(function () {
    angular.module('myapp', ['myapp.products',
        'myapp.product_categories',
        'myapp.common'
    ]).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('home', {
                url: '/admin',
                templateUrl: "/app/components/home/home.html",
                controller: 'homeController'
            });
        $urlRouterProvider.otherwise("/admin");
    }
})();