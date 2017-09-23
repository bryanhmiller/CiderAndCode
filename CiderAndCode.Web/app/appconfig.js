app.config(["$routeProvider",function($routeProvider) {
    $routeProvider
        .when("/pickapples",
        {
            templateUrl: "/app/views/PickApples/pickApples.html",
            controller: "pickApplesController"
        })
        .when("/showbushels",
        {
            templateUrl: "/app/views/showBushels/showBushels.html",
            controller: "showBushelsController"
        });
}]);