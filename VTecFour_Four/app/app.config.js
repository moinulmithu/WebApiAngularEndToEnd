//Create module             ** module is a kind of namespace means that all of the controllers will run under this namespace
var app = angular.module('vt', ['ngRoute']);

//Preapare the routing throuh the configuration function
//app.config(['Dependency Class Name',function(variable name of the object) {
    
//}]);
app.config([
    '$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/', { templateUrl: 'app/views/home.tpl.html' })
            .when('/entry', { templateUrl: 'app/views/entry.tpl.html', controller: 'studentEntryController' })
            .when('/list', { templateUrl: 'app/views/list.tpl.html', controller: 'studentListController' });
    }
]);