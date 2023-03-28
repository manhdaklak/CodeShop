
(function (app) {
    app.controller('homeController', homeController);
    app.config(['$qProvider', function ($qProvider) {
        $qProvider.errorOnUnhandledRejections(false);
    }]);
    function homeController() {

    }
})(angular.module('myapp'));