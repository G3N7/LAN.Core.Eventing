declare module jMess {
    class EventRegistry implements IEventRegistry {
        private _events;
        private _registry;
        private _logR;
        private _timeout;
        private _onRaise;
        constructor(logR: ILogR, onRaise: (event: string, data: Object) => void, timeout?: (delegate: () => void, delay: number) => void);
        getAvailableEvents(): string[];
        getHooksForEvent(eventName: string): Function[];
        hook(eventToHook: string, delegate: Function): () => void;
        hookOnce(eventToHook: string, delegate: Function): void;
        raise(eventToRaise: string, data: Object): void;
        register(eventsToRegister: string | string[] | Object): void;
        private _registerEventsObject(eventsObj);
        private _registerArrayOfEvents(eventsArray);
        private _registerSingleEvent(eventToRegister);
        private _eventExists(eventName);
    }
}
declare module jMess {
    interface IEventRegistry {
        getAvailableEvents(): string[];
        hook(eventName: string, onRaise: Function): () => void;
        hookOnce(eventToHook: string, delegate: Function): any;
        raise(eventToRaise: string, data: Object): void;
        register(eventsToRegister: any): void;
    }
}
