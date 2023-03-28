/// <reference path="../../../scripts/angular.js" />

(function () {
    angular.module('myapp.product_categories', ["myapp.common"]).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_categories', {
            url: '/product-categories',
            templateUrl: '/app/components/product_categories/productCategoryListView.html',
            controller:'productCategoryListController'
        });
    }
})();