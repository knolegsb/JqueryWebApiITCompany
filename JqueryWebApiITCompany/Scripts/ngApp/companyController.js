var companyController = angular.module('companyController', ['serviceModule']);

companyController.controller("GetCompanies", function GetCompanies($scope, companyServices) {
    loadRecords();

    function loadRecords() {
        var promiseGet = companyServices.GetCompanies();

        promiseGet.then(
            function (result) {
                $scope.companies = result.data
            },
            function (errorResult) {
                $log.error('failure loading companies', errorResult);
            });
    }
});

companyController.controller("AddCompany", function ($scope, $http, $location) {
    $scope.company = {
        "rank": "",
        "name": "",
        "industry": "",
        "revenue": "",
        "fiscalYear": "",
        "employees": "",
        "marketCap": "",
        "headquarters": ""
    };
    $scope.Add = function () {
        $http({
            method: "POST",
            data: $scope.company,
            url: "/api/companies"
        })
        .success(function (data, status, headers, config) {
            $scope.companies = data;
            $scope.company = {
                "rank": "",
                "name": "",
                "industry": "",
                "revenue": "",
                "fiscalYear": "",
                "employees": "",
                "marketCap": "",
                "headquarters": ""
            };
        });
        alert("Company added successfully..!!");
        $location.path('/allcompanies');
    }
});

companyController.controller("AllCompanies", function ($scope, $http) {
    $scope.getAll = function () {
        $http({
            method: "GET",
            url: "/api/companies"
        })
        .success(function (data, status, headers, config) {
            $scope.companies = data;
        });
    }
    $scope.getAll();
    $scope.Remove = function (id) {
        $http({
            method: "DELETE",
            url: "/api/companies/" + id
        })
        .success(function () {
            alert("Deleted successfully..!!");
            $scope.getAll();
        });
    }
});