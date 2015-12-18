app.controller('traineeEntryController', ['$scope', '$resource', function ($scope, $resource) {
    $scope.departments = [];

    function ClearText() {
        $scope.Trainee = null;
    }

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
                ClearText();
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

//===================Department=============================
app.controller('departmentEntryController', ['$scope', '$resource', function ($scope, $resource) {
    function ClearText() {
        $scope.Department = null;
    }

    function initializeDeptObj() {
        $scope.Department = {Id:0,Dept_Name:''}
    } 
    $scope.save = function() {
        console.log($scope.Department);
        //$scope.Department.Id = 6;
        var Dept = $resource('http://localhost:63817/api/Department');
        Dept.save($scope.Department).$promise.then(function(response) {
            console.log(response);
            ClearText();
        });
    };
    initializeDeptObj();
    
}]);


//==============Course=====================
app.controller('courseEntryController', ['$scope', '$resource', function ($scope, $resource) {
    $scope.save = function() {
        console.log($scope.Course);
        var Course = $resource('http://localhost:63817/api/Course');
        Course.save($scope.Course).$promise.then(function(response) {
            console.log(response);
            ClearText();
        });
    }

    function ClearText() {
        $scope.Course = null;
    }
}]);

//=====================Enrollment=========================
app.controller('enrollmentEntryController', ['$scope','$resource', function($scope,$resource) {
    $scope.trainess = [];
    $scope.courses = [];
    LoadTrainee();
    LoadCourse();
    $scope.save = function () {
        console.log($scope.Enrollment);
        var Enrollment = $resource('http://localhost:63817/api/Enrollment');
        Enrollment.save($scope.Enrollment).$promise.then(function(response) {
            console.log(response);
        });
    }

    function LoadTrainee() {
        var Trainee = $resource('http://localhost:63817/api/Trainee');
        Trainee.get().$promise.then(function(response) {
            $scope.trainees = response.Data;
            console.log($scope.trainees);
        });
    }

    function LoadCourse() {
        var Course = $resource('http://localhost:63817/api/Course');
        Course.get().$promise.then(function(response) {
            $scope.courses = response.Data;
            console.log($scope.courses);
        });
    }
    }]);