//Create module             ** module is a kind of namespace means that all of the controllers will run under this namespace

var app = angular.module('vt', ['ngRoute', 'ngResource']);

app.config([
    '$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/', { templateUrl: 'app/views/home.tpl.html' })
            .when('/entry', { templateUrl: 'app/views/entry.tpl.html', controller: 'studentEntryController' })
            .when('/list', { templateUrl: 'app/views/list.tpl.html', controller: 'studentListController' })
            .when('/DeptHome', { templateUrl: 'app/views/DepartmentHome.tpl.html' })
            .when('/DeptEntry', { templateUrl: 'app/views/DepartmentEntry.tpl.html', controller: 'studentEntryController' })
            .when('/DeptList', { templateUrl: 'app/views/DepartmentList.tpl.html', controller: 'studentListController' });
    }
]);



//Preapare the routing throuh the configuration function
//app.config(['Dependency Class Name',function(variable name of the object) {

//}]);