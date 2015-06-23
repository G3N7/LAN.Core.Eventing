var TestState = (function () {
    function TestState() {
        this.singleRequestAndResponse = false;
        this.requestThatResultsInError = false;
    }
    return TestState;
})();
// ReSharper disable once InconsistentNaming
function TestCtrl($scope, eventRegistry) {
    $scope.testState = new TestState();
    $scope.inititeSingleRequestAndResponseTest = function () {
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
        eventRegistry.raise(TestEvents.TestFailedRequest, {});
    };
    eventRegistry.hook(ServerEvents.OnError, function (error) {
        $scope.$apply(function () {
            if (errorTestRunning) {
                $scope.testState.requestThatResultsInError = true;
            }
        });
    });
}
TestCtrl.$inject = ['$scope', 'eventRegistry'];
//# sourceMappingURL=TestCtrl.js.map