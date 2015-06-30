

	declare class TestFailedRequest {
			}
	declare class TestSingleRequest {
			}
	declare class TestSingleResponse {
							}

	class TestEvents {
					
		static TestSingleRequest : string = 'TestTestSingleRequest';
					
		static TestSingleResponse : string = 'TestTestSingleResponse';
					
		static TestFailedRequest : string = 'TestTestFailedRequest';
					
		static TestFailedResponse : string = 'TestTestFailedResponse';
					
		static TestUnauthorizedRequest : string = 'TestTestUnauthorizedRequest';
					
		static TestUnauthorizedResponse : string = 'TestTestUnauthorizedResponse';
					
		static TestSingleLegacyRequest : string = 'TestTestSingleLegacyRequest';
					
		static TestSingleLegacyResponse : string = 'TestTestSingleLegacyResponse';
					
		static TestDoubleARequest : string = 'TestTestDoubleARequest';
					
		static TestDoubleAResponse : string = 'TestTestDoubleAResponse';
					
		static TestDoubleBRequest : string = 'TestTestDoubleBRequest';
					
		static TestDoubleBResponse : string = 'TestTestDoubleBResponse';
			}

var ServerEvents = {
	OnError: "ServerOnError",
	OnWarn: "ServerOnWarn",
	OnNotification: "ServerOnNotification",
};

