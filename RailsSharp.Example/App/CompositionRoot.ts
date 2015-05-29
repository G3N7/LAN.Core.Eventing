(() => {
	var app = angular.module("app", []);

	var logger = new LogR(logConfig);
	var externalInvoker = new DAL.SignalRExternalInvoker();
	var eventRegistry = new jMess.EventRegistry(logger, (eventToRaise, data) => {
		if (Str.endsWith(eventToRaise, 'Request')) {
			externalInvoker.invoke(eventToRaise, data);
		}
	});
	externalInvoker.responder = (event, data) => {
		eventRegistry.raise(event, data);
	};

	eventRegistry.register(ServerEvents);
	eventRegistry.register(TestEvents);

	app.factory('eventRegistry', () => { return eventRegistry; });

	app.controller('TestCtrl', TestCtrl);
})();