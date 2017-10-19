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
        })
        .when("/makecider",
        {
            templateUrl: "/app/views/makeCider/makeCider.html",
            controller: "makeCiderController"
        })
        .when("/showciders",
        {
            templateUrl: "/app/views/showCiders/showCiders.html",
            controller: "showCidersController"
        })
        .otherwise("/pickapples")
}]);