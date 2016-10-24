var serviceModule = angular.module("serviceModule", []);

serviceModule.service('companyService', function ($http) {
    this.getCompanies = function () {
        return $http.get("/api/companies");
    };
});