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
            console.log(result);
            $scope.showBushels();
        });
    }

//    $scope.showBushels = function () {
//        var bushels = $scope.bushels
//        $http.get("/api/Bushels", {
//            Type: bushel.appleType,
//            NumberOfBushels: bushel.numberOfBushels,
//            UserId: bushel.userId
//        })
//            .then(function (result) {
//                console.log(result)
//            })
//            .catch(function (error) {
//                console.log(error);
//            });
//        };


}]);