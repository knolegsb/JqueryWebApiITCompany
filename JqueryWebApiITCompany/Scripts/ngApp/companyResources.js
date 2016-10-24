var companyResources = angular.module("companyResources", ['ngResource']);

companyResources.factory('Comps', function Comps($resource) {
    return $resource('/api/companies', {}, {
        query: { method: 'GET', params: {}, isArray: true }
    });
});