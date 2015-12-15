app.controller('studentEntryController', ['$scope', '$resource', function ($scope, $resource) {
    $scope.departments = [];

    function initializeObjects() {
        $scope.Trainee = { Id: 0, Name: '', Phone: '', DepartmentId: '' }
    }

    function LoadDepartment() {
        var Department = $resource('http://localhost:63817/api/department');
        Department.get().$promise.then(function(response) {
            $scope.departments = response.data;
            console.log($scope.departments);
        });

    } 

    $scope.save = function() {
        console.log($scope.Trainee);
        $scope.Trainee.DepartmentId = 1;
        //Send to Server
        var Student = $resource('http://localhost:63817/api/Trainee');
        //asynchronous operation
        Student.save($scope.Trainee).$promise.then(function(response) {
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