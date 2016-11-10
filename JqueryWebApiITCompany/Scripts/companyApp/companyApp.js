var app = angular.module('companyApp', ['angularUtils.directives.dirPagination']);
var baseAddress = '/Api/Companies/';
var url = "";

//app.factory('companyFactory', function ($http) {
//    return {
//        getCompaniesList: function () {
//            url = baseAddress + "GetCompanyList";
//            return $http.get(url);
//        },
//        getCompany: function (company) {
//            url = baseAddress + "GetCompany/" + company.id;
//            return $http.get(url);
//        },
//        addCompany: function (company) {
//            url = baseAddress + "AddCompany";
//            return $http.post(url, company);
//        },
//        deleteCompany: function (company) {
//            url = baseAddress + "DeleteCompany/" + company.id;
//            return $http.delete(url);
//        },
//        updateCompany: function (company) {
//            url = baseAddress + "ModifyCompany/" + company.id;
//            return $http.put(url, company);
//        }
//    };
//});


app.factory('companyFactory', function ($http) {
    return {
        getCompaniesList: function () {
            url = baseAddress;
            return $http.get(url);
        },
        getCompany: function (company) {
            url = baseAddress + company.id;
            return $http.get(url);
        },
        addCompany: function (company) {
            url = baseAddress;
            return $http.post(url, company);
        },
        deleteCompany: function (company) {
            url = baseAddress + company.id;
            return $http.delete(url);
        },
        updateCompany: function (company) {
            url = baseAddress + company.id;
            return $http.put(url, company);
        }
    };
});

app.controller('companyController', function PostController($scope, companyFactory) {
    $scope.currentPage = 1;
    $scope.pageSize = 10;
    $scope.companies = [];
    $scope.company = null;
    $scope.editMode = false;

    // get Company
    $scope.get = function () {
        $scope.company = this.company;
        $('#viewModal').modal('show');
    };

    // get all Companies
    $scope.getAll = function () {
        companyFactory.getCompaniesList().success(function (data) {
            $scope.companies = data;
            //console.log(data);
        }).error(function (data) {
            $scope.error = "An Error has occured while Loading users! " + data.ExceptionMessage;
        });
    };

    // add Company
    $scope.add = function () {
        var currentCompany = this.company;
        if (currentCompany != null) {
            companyFactory.addCompany(currentCompany).success(function (data) {
                $scope.addMode = false;
                currentCompany = data;
                $scope.companies.push(currentCompany);

                // reset form
                $scope.company = null;
                // $scope.adduserform.$setPristine(); // for form reset

                $('#companyModel').modal('hide');
            }).error(function (data) {
                $scope.error = "An Error has occured while Adding company! " + data.ExceptionMessage;
            });
        }
    };

    // edit company
    $scope.edit = function () {
        $scope.company = this.company;
        $scope.editMode = true;
        $('#companyModel').modal('show');
    };

    // update company
    $scope.update = function () {
        var currentCompany = this.company;
        companyFactory.updateCompany(currentCompany).success(function (data) {
            currentCompany.editMode = false;

            $('#companyModel').modal('hide');
        }).error(function (data) {
            $scope.error = "An Error has occured while Updating company! " + data.ExceptionMessage;
        });
    };

    // delete company
    $scope.delete = function () {
        currentCompany = $scope.company;
        companyFactory.deleteCompany(currentCompany).success(function (data) {
            $('#confirmModal').modal('hide');
            $scope.companies.pop(currentCompany);
        }).error(function (data) {
            $scope.error = "An Error has occured while Deleting company! " + data.ExceptionMessage;

            $('#confirmModal').modal('hide');
        });
    };

    // Model popup events
    $scope.showadd = function () {
        $scope.user = null;
        $scope.editMode = false;
        $('#companyModel').modal('show');
    };

    $scope.showedit = function () {
        $('#companyModel').modal('show');
    };

    $scope.showconfirm = function (data) {
        $scope.company = data;
        console.log(data);
        $('#confirmModal').modal('show');
    };

    $scope.cancel = function () {
        $scope.company = null;
        $('#companyModel').modal('hide');
    }

    // initialize your companies data
    $scope.getAll();
});