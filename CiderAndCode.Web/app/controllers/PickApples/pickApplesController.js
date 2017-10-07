app.controller("pickApplesController",["$http","$location", "$scope",function($http, $location, $scope) {
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
            console.log(result);
            $location.url("/showbushels");
        })
        .catch(function (error) {
            console.log(error);    
        });
    };


}]);