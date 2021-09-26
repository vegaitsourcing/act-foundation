angular.module("umbraco").controller("CustomNewsletterDashboardController", function ($scope, $http) {
        $http.get("/umbraco/backoffice/subscriptions/getall")
        .then(function (response) {
            $scope.subscriptions = response.data
        }, function errorCallback(response) {
            alert(response)
        });

        $scope.Remove = function (id) {
                $http({
                    url: `/umbraco/backoffice/subscriptions/remove?id=${id}`,
                    method: "POST"
                })
                .then(function (response) {
                    $scope.subscriptions = $scope.subscriptions.filter(s => s.Id !== id)
                }, function errorCallback(response) {
                    alert(response)
                });
        }
});