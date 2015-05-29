
class Str {
	public static endsWith(input: string, suffix: string): boolean {
		return input.indexOf(suffix, input.length - suffix.length) !== -1;
	}

	public static trim(str: string) {
		return str.replace(/^\s\s*/, '').replace(/\s\s*$/, '');
	}

	public static format(formatString) {
		var args = arguments;
		return formatString.replace(/{(\d+)}/g,(match, number) => {
			var replacementIndex = parseInt(number, 10) + 1;
			return typeof args[replacementIndex] != 'undefined' ? args[replacementIndex] : match;
		});
	}
}

module DAL {

	export class BaseExternalInvoker {
		public invoke = (event: string, data: Object) => {
			if (event == null) throw 'event is null or undefined';
			if (data == null) throw 'data is null or undefined';
			throw 'Invoker.invoke has not been implemented, or you are using the base invoker.';
		};
		public responder = (event: string, data: Object) => {
			if (event == null) throw 'event is null or undefined';
			if (data == null) throw 'data is null or undefined';
			throw 'Invoker.responder delegate was not provided.';
		};
	}

	export class SignalRExternalInvoker extends BaseExternalInvoker {
		constructor() {
			super();
			var intervalLoop;
			var connection = $.hubConnection();
			var queue: QueueItem[] = [];

			var hub = connection.createHubProxy('eventHub');
			hub.on('eventReceived',(...msgs) => {
				var event = msgs[0], data = msgs[1];
				writeTransportLog(' ↓ Reply ↓ ', 'Event: ' + event);
				this.responder(event, data);
			});

			var writeConnectionLog = (connectionState) => {
				var prefix = !logConfig.SupportCustomLogs ? '' : '%c';
				var suffix = !logConfig.SupportCustomLogs ? '' : 'background: #222; color: #bada55';
				logR.custom(prefix + ' © ' + connectionState + ' © ', suffix);
			};

			var writeTransportLog = (transportType, details) => {
				var prefix = !logConfig.SupportCustomLogs ? '' : '%c';
				var suffix = !logConfig.SupportCustomLogs ? '' : 'background: #222; color: #bada55';
				logR.custom(prefix + transportType, suffix, details);
			};

			connection.stateChanged(change=> {
				var newState = change.newState;
				switch (newState) {
					case $.signalR.connectionState.reconnecting:
						writeConnectionLog('Re-connecting');
						stopQueue();
						break;
					case $.signalR.connectionState.connected:
						writeConnectionLog('Connected');
						startQueue();
						break;
					case $.signalR.connectionState.disconnected:
						writeConnectionLog('Disconnected');
						stopQueue();
						break;
					default:
				}
			});
			connection.start();

			var stopQueue = () => {
				writeTransportLog(' ! Queue Stopped ! ', DateTime.NowString());
				clearInterval(intervalLoop);
			};

			var startQueue = () => {
				var sendRequest = (qi: QueueItem) => {
					if ($.signalR.connectionState.connected) {
						writeTransportLog(' ↑ Request ↑ ', 'Event: ' + qi.Event);
						hub.invoke('raiseEvent', qi.Event, qi.Data);
					} else {
						stopQueue();
					}
				};

				var process = () => {
					for (var i = 0; i < queue.length; i++) {
						var qi = queue.splice(0, 1)[0];
						if (qi) {
							sendRequest(qi);
						} else {
							break;
						}
					}
				};

				intervalLoop = setInterval(process, 10);
			};

			this.invoke = (event: string, data: any) => {
				queue.push({
					Event: event,
					Data: data
				});
			};
		}
	}

	class QueueItem {
		Event: string;
		Data: any;
	}
}

class DateTime {
	public static NowString() {
		var now = new Date();
		var hoursTwentyForFormat = now.getHours();
		var hoursTwelveFormat;
		if (hoursTwentyForFormat == 0) {
			hoursTwelveFormat = 12;
		} else {
			hoursTwelveFormat = hoursTwentyForFormat > 12 ? hoursTwentyForFormat - 12 : hoursTwentyForFormat;
		}

		function addZero(num) {
			return (num >= 0 && num < 10) ? "0" + num : num + "";
		}
		var dateBits = addZero(now.getMonth() + 1) + '/' + addZero(now.getDate()) + '/' + now.getFullYear();
		var timeBits = addZero(hoursTwelveFormat) + ':' + addZero(now.getMinutes());
		var todBits = now.getHours() >= 12 ? "PM" : "AM";
		var strDateTime = dateBits + ' ' + timeBits + ' ' + todBits;

		return strDateTime;
	}
}