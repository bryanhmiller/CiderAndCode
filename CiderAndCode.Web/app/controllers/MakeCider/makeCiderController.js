app.controller("makeCiderController", ["$http", "$scope", function ($http, $scope) {
    $scope.bushels = [];


    $scope.showBushels = () => {
        $http.get("/api/Bushels")
            .then(function (result) {
                $scope.bushels = result.data;
            });
    }

    $scope.showBushels();

    $scope.makeCider = (id) => {
        $http.post("/api/cider", {
            BushelId: bushel.Id
        })
        .then(function (result) {
            console.log(result)
            $scope.showBushels();
        })
        .catch(function (error) {
            console.log(error);
        });
    };
}]);