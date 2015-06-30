interface ITestScope extends ng.IScope {
	testState: TestState;
	inititeSingleRequestAndResponseTest(): void;
	inititeRequestThatResultsInErrorTest(): void;
	inititeRequestThatResultsInUnauthorizedErrorTest(): void;
}

class TestState {
	constructor() {
		this.singleRequestAndResponse = false;
		this.requestThatResultsInError = false;
	}
	singleRequestAndResponse: boolean;
	requestThatResultsInError: boolean;
	requestThatResultsInUnauthorizedError: boolean;
}

// ReSharper disable once InconsistentNaming
function TestCtrl($scope: ITestScope, eventRegistry: jMess.IEventRegistry) {
	$scope.testState = new TestState();

	$scope.inititeSingleRequestAndResponseTest = () => {
		$scope.testState.singleRequestAndResponse = false;
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
		$scope.testState.requestThatResultsInError = false;
		eventRegistry.raise(TestEvents.TestFailedRequest, {});
	}

	var unauthorizedTestRunning = false;
	$scope.inititeRequestThatResultsInUnauthorizedErrorTest = () => {
		unauthorizedTestRunning = true;
		$scope.testState.requestThatResultsInUnauthorizedError = false;
		eventRegistry.raise(TestEvents.TestUnauthorizedRequest, {});
	}
	
	eventRegistry.hook(ServerEvents.OnError,(error) => {
		$scope.$apply(() => {
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