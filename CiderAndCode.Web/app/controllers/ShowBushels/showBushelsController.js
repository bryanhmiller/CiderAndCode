app.controller("showBushelsController", ["$http", "$scope", function ($http, $scope) {
    $scope.bushels = [];


    $scope.showBushels = () => {
        $http.get("/api/Bushels")
        .then(function (result) {
            $scope.bushels = result.data;
        });
    }

    $scope.showBushels();

    $scope.stealApples = (id) => {
        $http.delete(`/api/Bushels/${id}`)
        .then(function (result) {
            $scope.showBushels();
        });
    }
}]);