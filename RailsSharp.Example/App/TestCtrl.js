var TestState = (function () {
    function TestState() {
        this.singleRequestAndResponse = false;
        this.requestThatResultsInError = false;
    }
    return TestState;
}());
// ReSharper disable once InconsistentNaming
function TestCtrl($scope, eventRegistry) {
    $scope.testState = new TestState();
    $scope.inititeSingleRequestAndResponseTest = function () {
        $scope.testState.singleRequestAndResponse = false;
        eventRegistry.raise(TestEvents.TestSingleRequest, {});
    };
    eventRegistry.hook(TestEvents.TestSingleResponse, function (reply) {
        $scope.$apply(function () {
            $scope.testState.singleRequestAndResponse = true;
        });
    });
    var errorTestRunning = false;
    $scope.inititeRequestThatResultsInErrorTest = function () {
        errorTestRunning = true;
        $scope.testState.requestThatResultsInError = false;
        eventRegistry.raise(TestEvents.TestFailedRequest, {});
    };
    var unauthorizedTestRunning = false;
    $scope.inititeRequestThatResultsInUnauthorizedErrorTest = function () {
        unauthorizedTestRunning = true;
        $scope.testState.requestThatResultsInUnauthorizedError = false;
        eventRegistry.raise(TestEvents.TestUnauthorizedRequest, {});
    };
    eventRegistry.hook(ServerEvents.OnError, function (error) {
        $scope.$apply(function () {
            if (errorTestRunning) {
                $scope.testState.requestThatResultsInError = true;
            }
            if (unauthorizedTestRunning) {
                $scope.testState.requestThatResultsInUnauthorizedError = true;
            }
        });
    });
}
TestCtrl.$inject = ['$scope', 'eventRegistry'];
//# sourceMappingURL=TestCtrl.js.map