app.controller('studentEntryController', ['$scope', function ($scope) {
    $scope.Departments = [];

    function initializeObjects() {
        $scope.Trainee = { Id: 0, Name: '', Phone: '', DepartmentId: '' }
    }

     
    $scope.save = function() {
        console.log($scope.Trainee);
    };
    initializeObjects();

}]);
app.controller('studentListController', ['', function () { }]);