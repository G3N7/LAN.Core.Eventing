

	declare class TestSingleRequest {
			}
	declare class TestSingleResponse {
							}

	class TestEvents {
					
		static TestSingleRequest : string = 'TestTestSingleRequest';
					
		static TestSingleResponse : string = 'TestTestSingleResponse';
			}

var ServerEvents = {
	OnError: "ServerOnError",
	OnWarn: "ServerOnWarn",
	OnNotification: "ServerOnNotification",
};

