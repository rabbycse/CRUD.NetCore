app.controller('SalesController', ['$scope', '$http', 'appMessage', function ($scope, $http, appMessage) {
    $scope.Sales = {};
    $scope.alerts = [];
    $scope.appMessage = appMessage;
    $scope.Sales.Id = 0;

    //=========================== Alerts ==================

    $scope.closeAlert = function (index) {
        $scope.alerts.splice(index, 1);
    };

    $scope.changeFocus = function (fieldName) {

        var field = document.getElementsByName(fieldName);
        field[0].focus();
        field[0].select();
    };

    //================ Get Param Id from Url ==============
    var paramId = location.search.substr(4);

    $scope.CalculateTotalAmount = function () {
        var rate = parseFloat($scope.Sales.ItemRate) || 0;
        var qty = parseFloat($scope.Sales.ItemQuantity) || 0;
        var totalAmount = rate * qty;
        $scope.Sales.TotalAmount = totalAmount;
    }

    //================ Save Sales ==============
    $scope.SaveSales = function () {
        var url = " ";
        if ($scope.Sales.Id > 0) {
            url = "/Sales/UpdateSales";
        }
        else {
            url = "/Sales/SaveSales";
        }
        $http({
            method: 'POST',
            url: url,
            data: { "sale": $scope.Sales} 
        }).success(function (response) {
            $scope.submitted = false;
            $scope.Sales.Id = response.Id;
        }).error(function (response) {
            $scope.alerts.push({ 'type': 'danger', 'msg': $scope.appMessage.failure });
        });
    };
    //============ Get Sales Information By Id ==============
    $scope.GetSalesById = function () {
        $http({
            method: "GET",
            url: "/Sales/GetSalesById?Id=" + paramId

        }).success(function (response) {
            $scope.Sales = response;
        }).error(function (response) {
            $scope.alerts.push({ 'type': 'danger', 'msg': $scope.appMessage.fetch_Warning });
        });
    };

    //============ Update Sales Information =================
    $scope.UpdateSales = function () {
        $http({
            method: "POST",
            url: "/Ipd/Bed/UpdateSales",
            data: $scope.Sales

        }).success(function (response) {
            $scope.Sales.Id = response.Id;
            $scope.Success = response.Success;
            if ($scope.Bed.Id > 0 && $scope.Success == true) {
                $scope.alerts.push({ 'type': 'success', 'msg': $scope.appMessage.update });
            }
        }).error(function (response) {
            $scope.alerts.push({ 'type': 'danger', 'msg': $scope.appMessage.failure });
        });
    };
    //=========Call The Method When Param Value is not = 0 =========
    if (paramId != "") {
        $scope.GetSalesById();
    }

    //============ Get All Sales Information ==============
    $scope.salesData = [];
    $scope.GetAllSalesData = function () {
        $http({
            method: "GET",
            url: "/Sales/GetAllSalesData"

        }).success(function (response) {
            $scope.salesData = response;
        }).error(function (response) {
            $scope.alerts.push({ 'type': 'danger', 'msg': $scope.appMessage.fetch_Warning });
        });
    };
    $scope.GetAllSalesData();
}]);

