app.controller("pickApplesController",["$http","$scope",function($http, $scope) {
    $scope.bushel = {};
    $scope.users = [];

    $http.get("/api/users/list")
        .then(function (result) {
            $scope.users = result.data;
        });


    $scope.pickApples = function () {
        var bushel = $scope.bushel
        $http.post("/api/PickApples", {
            Type: bushel.appleType,
            NumberOfBushels: bushel.numberOfBushels,
            UserId: bushel.userId
        })
        .then(function (result) {
            console.log(result)
        })
        .catch(function (error) {
            console.log(error);    
        });
    };


}]);