(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope', 'apiService'];
    function productCategoryListController($scope, apiService) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.search = search;
        $scope.getProductCategories = getProductCategories;
        function search() {
            getProductCagories();
        }
        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    page: 0,
                    pageSize: 2
                }
            }
            apiService.get('/api/productcategory/getall', config, function (result) {
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('load error')
            });
        }
        $scope.getProductCategories();
    };
})(angular.module('myapp.product_categories'));