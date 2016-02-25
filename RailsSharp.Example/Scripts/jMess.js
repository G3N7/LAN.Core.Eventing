var jMess;
(function (jMess) {
    var EventRegistry = (function () {
        function EventRegistry(logR, onRaise, timeout) {
            this._events = {};
            this._registry = {};
            this._logR = logR;
            this._onRaise = onRaise;
            this._timeout = timeout ? timeout : setTimeout;
        }
        EventRegistry.prototype.getAvailableEvents = function () {
            var eventCopy = _.clone(this._events);
            return _.values(eventCopy);
        };
        EventRegistry.prototype.getHooksForEvent = function (eventName) {
            return this._registry[eventName];
        };
        EventRegistry.prototype.hook = function (eventToHook, delegate) {
            if (eventToHook == null)
                throw 'You must provide an event to hook, have you define the event object yet? "...oh you have to write the code! -Scott Hanselman"';
            if (delegate == null)
                throw 'You must provide an delegate to run when the event is raised';
            if (!this._eventExists(eventToHook))
                throw 'The event "' + eventToHook + '" your trying to hook to does not exist, make sure you have registered the events with the EventRegistry, the available events are ' + _.map(_.values(this._events), function (x) { return '\n' + x; });
            this._logR.trace('Registering hook: ', eventToHook);
            if (this._registry[eventToHook] == null) {
                this._registry[eventToHook] = [delegate];
            }
            else {
                this._registry[eventToHook].push(delegate);
            }
            var cancelation = (function (r, e, d) {
                return function () {
                    logR.trace("Removing hook: ", e);
                    var indexOfDelegate = r[e].indexOf(d);
                    r[e].splice(indexOfDelegate, 1);
                };
            })(this._registry, eventToHook, delegate);
            return cancelation;
        };
        EventRegistry.prototype.hookOnce = function (eventToHook, delegate) {
            if (eventToHook == null)
                throw 'You must provide an event to hook, have you define the event object yet? "...oh you have to write the code! -Scott Hanselman"';
            if (delegate == null)
                throw 'You must provide an delegate to run when the event is raised';
            if (!this._eventExists(eventToHook))
                throw 'The event "' + eventToHook + '" your trying to hook to does not exist, make sure you have registered the events with the EventRegistry, the available events are ' + _.map(_.values(this._events), function (x) { return '\n' + x; });
            if (this._registry[eventToHook] == null) {
                this._registry[eventToHook] = new Array();
            }
            var indexOfDelegate = this._registry[eventToHook].length;
            this._logR.trace('Registering hook ' + eventToHook + "[" + indexOfDelegate + "]");
            var cancelation = (function (r, e, i) {
                return function () {
                    logR.trace("Removing hook " + e + "[" + indexOfDelegate + "]");
                    r[e].splice(i, 1);
                };
            })(this._registry, eventToHook, indexOfDelegate);
            this._registry[eventToHook].push(function () {
                cancelation();
                delegate(arguments);
            });
        };
        EventRegistry.prototype.raise = function (eventToRaise, data) {
            var _this = this;
            if (eventToRaise == null)
                throw 'The event you provided to raise is null, are you sure you have defined the event?';
            if (data == null)
                throw 'data was null, consumers of events should feel confident they will never get null data.';
            if (!this._eventExists(eventToRaise))
                throw 'The event "' + eventToRaise + '" your trying to raise does not exist, make sure you have registered the event with the EventRegistry, the available events are ' + _.map(_.values(this._events), function (x) { return '\n' + x; });
            this._logR.info('Raise: ', eventToRaise, data);
            var asyncInvokation = function (delegate) {
                var logr = _this._logR;
                _this._timeout.call(window, function () {
                    try {
                        delegate(data);
                    }
                    catch (ex) {
                        logr.error('An exception was thrown when', eventToRaise, 'was Raised with', data, ex);
                    }
                }, 100);
            };
            var eventDelegates = this._registry[eventToRaise];
            _.each(eventDelegates, asyncInvokation);
            this._timeout.call(window, function () {
                _this._onRaise(eventToRaise, data);
            });
        };
        EventRegistry.prototype.register = function (eventsToRegister) {
            if (eventsToRegister == null)
                throw 'Your events where null, we must have something';
            this._logR.trace('Register: ', eventsToRegister);
            if (eventsToRegister instanceof Array) {
                this._registerArrayOfEvents(eventsToRegister);
            }
            else if (eventsToRegister instanceof Object) {
                this._registerEventsObject(eventsToRegister);
            }
            else {
                this._registerSingleEvent(eventsToRegister);
            }
        };
        EventRegistry.prototype._registerEventsObject = function (eventsObj) {
            for (var key in eventsObj) {
                if (eventsObj.hasOwnProperty(key)) {
                    var value = eventsObj[key];
                    if (typeof value == "string") {
                        this._registerSingleEvent(value);
                    }
                }
            }
        };
        EventRegistry.prototype._registerArrayOfEvents = function (eventsArray) {
            if (eventsArray.length === 0)
                throw 'The array of events was empty :(';
            for (var i = 0; i < eventsArray.length; i++) {
                var eventToRegister = eventsArray[i];
                if (eventToRegister === '')
                    throw 'the event at ' + i + ' index was just an empty string :(';
                this._registerSingleEvent(eventsArray[i]);
            }
        };
        EventRegistry.prototype._registerSingleEvent = function (eventToRegister) {
            if (typeof eventToRegister !== 'string') {
                this._logR.warn('The event being registered is not a string, its value is ', eventToRegister);
                return;
            }
            if (eventToRegister === '')
                throw 'the event was just an empty string :(';
            if (this._eventExists(eventToRegister))
                throw 'the event you are trying to register "' + eventToRegister + '" is already registered, either you are duplicating logic or need to be more specific in your event naming';
            this._events[eventToRegister] = eventToRegister;
        };
        EventRegistry.prototype._eventExists = function (eventName) {
            return _.contains(_.values(this._events), eventName);
        };
        return EventRegistry;
    })();
    jMess.EventRegistry = EventRegistry;
})(jMess || (jMess = {}));
