app.controller("showCidersController", ["$http", "$scope", function ($http, $scope) {
    $scope.ciders = [];


    $scope.showciders = () => {
        $http.get("/api/cider")
            .then(function (result) {
                $scope.ciders = result.data;
            });
    }

    $scope.showciders();

}]);