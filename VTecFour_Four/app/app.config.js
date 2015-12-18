//Create module             ** module is a kind of namespace means that all of the controllers will run under this namespace

var app = angular.module('vt', ['ngRoute', 'ngResource']);

app.config([
    '$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/', { templateUrl: 'app/views/home.tpl.html' })
            .when('/entry', { templateUrl: 'app/views/entry.tpl.html', controller: 'traineeEntryController' })
            .when('/list', { templateUrl: 'app/views/list.tpl.html', controller: 'studentListController' })
            .when('/DeptHome', { templateUrl: 'app/views/DepartmentHome.tpl.html' })
            .when('/DeptEntry', { templateUrl: 'app/views/DepartmentEntry.tpl.html', controller: 'departmentEntryController' })
            .when('/DeptList', { templateUrl: 'app/views/DepartmentList.tpl.html', controller: 'departmentListController' })
            .when('/CourseHome', { templateUrl: 'app/views/CourseHome.tpl.html' })
            .when('/CourseEntry', { templateUrl: 'app/views/CourseEntry.tpl.html', controller: 'courseEntryController' })
            .when('/CourseList', { templateUrl: 'app/views/CourseList.tpl.html', controller: 'courseListController' })
            .when('/EnrollmentHome', { templateUrl: 'app/views/EnrollmentHome.tpl.html' })
            .when('/EnrollmentEntry', { templateUrl: 'app/views/EnrollmentEntry.tpl.html', controller: 'enrollmentEntryController' })
            .when('/EnrollmentList', { templateUrl: 'app/views/EnrollmentList.tpl.html', controller: 'enrollmentListController' });
    }
]);



//Preapare the routing throuh the configuration function
//app.config(['Dependency Class Name',function(variable name of the object) {

//}]);