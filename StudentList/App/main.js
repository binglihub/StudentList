var app = angular.module("app", []);
app.controller("main", function ($scope, $http) {
    $scope.studentList = [];
    $scope.newStudent = {};

    $scope.updateStudentList = function () {
        $http.get("api/student/").then(function (response) {
            $scope.studentList = response.data;
        });
    }

    $scope.add = function () {
        $http.post("api/student/", $scope.newStudent).then(function (response) {
            $scope.updateStudentList();
            $scope.newStudent = {};
        });
    }

    $scope.updateStudentList();
});