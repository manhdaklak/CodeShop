/// <reference path="../../../scripts/angular.js" />

(function () {
    angular.module('myapp.products', ["myapp.common"]).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: '/product',
            templateUrl: '/app/components/product/productListView.html',
            contronller: 'productListController'
        }).state('product_add', {
            url: '/product-add',
            templateUrl: '/app/components/product/productAddView.html',
            contronller: 'productAddController'
        }).state('produc_edit', {
            url: '/product-edit',
            templateUrl: '/app/components/product/productEditView.html',
            contronller: 'productEditController'
        });
    }
})();