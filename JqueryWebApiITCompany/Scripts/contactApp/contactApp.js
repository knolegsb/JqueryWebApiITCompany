var app = angular.module('contactApp', ['angularUtils.directives.dirPagination']);
var baseAddress = '/Api/Companies/';
var url = "";

//app.factory('contactFactory', function ($http) {
//    return {
//        getContactsList: function () {
//            url = baseAddress + "GetContactList";
//            return $http.get(url);
//        },
//        getContact: function (contact) {
//            url = baseAddress + "GetContact/" + contact.id;
//            return $http.get(url);
//        },
//        addContact: function (contact) {
//            url = baseAddress + "AddContact";
//            return $http.post(url, contact);
//        },
//        deleteContact: function (contact) {
//            url = baseAddress + "DeleteContact/" + contact.id;
//            return $http.delete(url);
//        },
//        updateContact: function (contact) {
//            url = baseAddress + "ModifyContact/" + contact.id;
//            return $http.put(url, contact);
//        }
//    };
//});


app.factory('contactFactory', function ($http) {
    return {
        getContactsList: function () {
            url = baseAddress;
            return $http.get(url);
        },
        getContact: function (contact) {
            url = baseAddress + contact.id;
            return $http.get(url);
        },
        addContact: function (contact) {
            url = baseAddress;
            return $http.post(url, contact);
        },
        deleteContact: function (contact) {
            url = baseAddress + contact.id;
            return $http.delete(url);
        },
        updateContact: function (contact) {
            url = baseAddress + contact.id;
            return $http.put(url, contact);
        }
    };
});

app.controller('contactController', function PostController($scope, contactFactory) {
    $scope.currentPage = 1;
    $scope.pageSize = 10;
    $scope.contacts = [];
    $scope.contact = null;
    $scope.editMode = false;

    // get Contact
    $scope.get = function () {
        $scope.contact = this.contact;
        $('#viewModal').modal('show');
    };

    // get all Contacts
    $scope.getAll = function () {
        contactFactory.getContactsList().success(function (data) {
            $scope.contacts = data;
            //console.log(data);
        }).error(function (data) {
            $scope.error = "An Error has occured while Loading users! " + data.ExceptionMessage;
        });
    };

    // add Contact
    $scope.add = function () {
        var currentContact = this.contact;
        if (currentContact != null && currentContact.name != null && currentContact.address && currentContact.phone) {
            contactFactory.addContact(currentContact).success(function (data) {
                $scope.addMode = false;
                currentContact.id = data;
                $scope.contacts.push(currentContact);

                // reset form
                $scope.contact = null;
                // $scope.adduserform.$setPristine(); // for form reset

                $('#contactModel').modal('hide');
            }).error(function (data) {
                $scope.error = "An Error has occured while Adding contact! " + data.ExceptionMessage;
            });
        }
    };

    // edit contact
    $scope.edit = function () {
        $scope.contact = this.contact;
        $scope.editMode = true;
        $('#contactModel').modal('show');
    };

    // update contact
    $scope.update = function () {
        var currentContact = this.contact;
        contactFactory.updateContact(currentContact).success(function (data) {
            currentContact.editMode = false;

            $('#contactModel').modal('hide');
        }).error(function (data) {
            $scope.error = "An Error has occured while Updating contact! " + data.ExceptionMessage;
        });
    };

    // delete contact
    $scope.delete = function () {
        currentContact = $scope.contact;
        contactFactory.deleteContact(currentContact).success(function (data) {
            $('#confirmModal').modal('hide');
            $scope.contacts.pop(currentContact);
        }).error(function (data) {
            $scope.error = "An Error has occured while Deleting contact! " + data.ExceptionMessage;

            $('#confirmModal').modal('hide');
        });
    };

    // Model popup events
    $scope.showadd = function () {
        $scope.user = null;
        $scope.editMode = false;
        $('#contactModel').modal('show');
    };

    $scope.showedit = function () {
        $('#contactModel').modal('show');
    };

    $scope.showconfirm = function (data) {
        $scope.contact = data;
        console.log(data);
        $('#confirmModal').modal('show');
    };

    $scope.cancel = function () {
        $scope.contact = null;
        $('#contactModel').modal('hide');
    }

    // initialize your contacts data
    $scope.getAll();
});