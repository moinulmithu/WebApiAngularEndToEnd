app.controller('traineeEntryController', ['$scope', '$resource', function ($scope, $resource) {
    $scope.departments = [];
    function LoadDepartment() {
        var Department = $resource('http://localhost:63817/api/department');
        Department.get().$promise.then(function (response) {
            $scope.departments = response.Data;
            console.log($scope.departments);
        });

    }
    function initializeObjects() {
        $scope.Trainee = { Id: 0, Name: '', Phone: '', DepartmentId: '' }
    }

    

    $scope.save = function() {
        console.log($scope.Trainee);
        //$scope.Trainee.DepartmentId = 1;
        //Send to Server
        var Trainee = $resource('http://localhost:63817/api/Trainee');
        //asynchronous operation
        Trainee.save($scope.Trainee).$promise.then(function(response) {
            if (response.isSuccess) {
                initializeObjects();
            } else {
                alert(response.message);
            }
            
        });
    };

    function initialize() {
        initializeObjects();
        LoadDepartment();
    }
    initialize();

}]);
app.controller('studentListController', ['', function () { }]);
app.controller('departmentEntryController', ['$scope','$resource', function($scope,$resource) {
    $scope.saveDept = function () {
        console.log($scope.Department);
        var Department = $resource();
        Department.saveDept($scope.Department).$promise.then(function(response) {
            if (response.isSuccess) {
                initializeObjects();
            } else {
                alert(response.message);
            }
        });

    }
}]);