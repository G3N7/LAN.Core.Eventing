interface ITestScope extends ng.IScope {
	testState: TestState;
	inititeSingleRequestAndResponseTest(): void;
}

class Status {
	static Unknown = 'Unknown';
	static Success = 'Success';
}

class TestState {
	constructor() {
		this.singleRequestAndResponse = Status.Unknown;
	}

	singleRequestAndResponse: Status;

}

// ReSharper disable once InconsistentNaming
function TestCtrl($scope: ITestScope, eventRegistry: jMess.IEventRegistry) {
	$scope.testState = new TestState();

	$scope.inititeSingleRequestAndResponseTest = () => {
		eventRegistry.raise(TestEvents.TestSingleRequest, {});
	}

	eventRegistry.hook(TestEvents.TestSingleResponse,(reply: TestSingleResponse) => {
		$scope.$apply(() => {
			$scope.testState.singleRequestAndResponse = Status.Success;	
		});
	});
}

TestCtrl.$inject = ['$scope', 'eventRegistry'];