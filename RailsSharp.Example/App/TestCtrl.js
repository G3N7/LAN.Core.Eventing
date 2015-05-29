var Status = (function () {
    function Status() {
    }
    Status.Unknown = 'Unknown';
    Status.Success = 'Success';
    return Status;
})();
var TestState = (function () {
    function TestState() {
        this.singleRequestAndResponse = Status.Unknown;
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
            $scope.testState.singleRequestAndResponse = Status.Success;
        });
    });
}
TestCtrl.$inject = ['$scope', 'eventRegistry'];
//# sourceMappingURL=TestCtrl.js.map