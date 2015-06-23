interface ITestScope extends ng.IScope {
	testState: TestState;
	inititeSingleRequestAndResponseTest(): void;
	inititeRequestThatResultsInErrorTest(): void;
}

class TestState {
	constructor() {
		this.singleRequestAndResponse = false;
		this.requestThatResultsInError = false;
	}
	singleRequestAndResponse: boolean;
	requestThatResultsInError: boolean;
}

// ReSharper disable once InconsistentNaming
function TestCtrl($scope: ITestScope, eventRegistry: jMess.IEventRegistry) {
	$scope.testState = new TestState();

	$scope.inititeSingleRequestAndResponseTest = () => {
		eventRegistry.raise(TestEvents.TestSingleRequest, {});
	}

	eventRegistry.hook(TestEvents.TestSingleResponse,(reply: TestSingleResponse) => {
		$scope.$apply(() => {
			$scope.testState.singleRequestAndResponse = true;
		});
	});

	var errorTestRunning = false;
	$scope.inititeRequestThatResultsInErrorTest = () => {
		errorTestRunning = true;
		eventRegistry.raise(TestEvents.TestFailedRequest, {});
	}

	eventRegistry.hook(ServerEvents.OnError,(error) => {
		$scope.$apply(() => {
			if (errorTestRunning) {
				$scope.testState.requestThatResultsInError = true;
			}
		});
	});

}

TestCtrl.$inject = ['$scope', 'eventRegistry'];