var TestEvents = (function () {
    function TestEvents() {
    }
    TestEvents.TestSingleRequest = 'TestTestSingleRequest';
    TestEvents.TestSingleResponse = 'TestTestSingleResponse';
    TestEvents.TestFailedRequest = 'TestTestFailedRequest';
    TestEvents.TestFailedResponse = 'TestTestFailedResponse';
    TestEvents.TestUnauthorizedRequest = 'TestTestUnauthorizedRequest';
    TestEvents.TestUnauthorizedResponse = 'TestTestUnauthorizedResponse';
    TestEvents.TestSingleLegacyRequest = 'TestTestSingleLegacyRequest';
    TestEvents.TestSingleLegacyResponse = 'TestTestSingleLegacyResponse';
    TestEvents.TestDoubleARequest = 'TestTestDoubleARequest';
    TestEvents.TestDoubleAResponse = 'TestTestDoubleAResponse';
    TestEvents.TestDoubleBRequest = 'TestTestDoubleBRequest';
    TestEvents.TestDoubleBResponse = 'TestTestDoubleBResponse';
    return TestEvents;
})();
var ServerEvents = {
    OnError: "ServerOnError",
    OnWarn: "ServerOnWarn",
    OnNotification: "ServerOnNotification",
};
//# sourceMappingURL=TypeScriptEvents.js.map