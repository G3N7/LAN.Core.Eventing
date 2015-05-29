var LogConfig = (function () {
    function LogConfig() {
    }
    return LogConfig;
})();

var LogR = (function () {
    function LogR(config) {
        this._config = config;
    }
    LogR.prototype._doLog = function () {
        var args = [];
        for (var _i = 0; _i < (arguments.length - 0); _i++) {
            args[_i] = arguments[_i + 0];
        }
        if (window.console) {
            try  {
                console.log.apply(console, args);
            } catch (e) {
                logConfig.SupportCustomLogs = false;
                var internalArgs = [];
                for (var i = 0; i < args.length; i++) {
                    internalArgs.push(args[i]);
                }
                console.log(internalArgs.join(", "));
            }
        }
    };

    LogR.prototype._addBackgroundColorAndText = function (color, text, inputArgs) {
        if (logConfig.SupportCustomLogs) {
            [].splice.call(inputArgs, 0, 0, 'background:' + color + ';font-family:"' + logConfig.FontFamily + '"');
        }

        var header = (logConfig.SupportCustomLogs == true ? '%c ' : '') + text + ' ' + logConfig.PieceOfFlair + ' ';
        [].splice.call(inputArgs, 0, 0, header);
    };

    LogR.prototype.info = function () {
        var args = [];
        for (var _i = 0; _i < (arguments.length - 0); _i++) {
            args[_i] = arguments[_i + 0];
        }
        if (logConfig.InfoOn) {
            this._addBackgroundColorAndText(logConfig.InfoColor, logConfig.InfoHeaders, args);
            this._doLog.apply(this._doLog, args);
        }
    };

    LogR.prototype.warn = function () {
        var args = [];
        for (var _i = 0; _i < (arguments.length - 0); _i++) {
            args[_i] = arguments[_i + 0];
        }
        if (logConfig.WarnOn) {
            this._addBackgroundColorAndText(logConfig.WarnColor, logConfig.WarnHeaders, args);
            this._doLog.apply(this._doLog, args);
        }
    };

    LogR.prototype.custom = function () {
        var args = [];
        for (var _i = 0; _i < (arguments.length - 0); _i++) {
            args[_i] = arguments[_i + 0];
        }
        if (logConfig.CustomOn) {
            this._doLog.apply(this._doLog, args);
        }
    };

    LogR.prototype.error = function () {
        var args = [];
        for (var _i = 0; _i < (arguments.length - 0); _i++) {
            args[_i] = arguments[_i + 0];
        }
        if (logConfig.ErrorOn) {
            this._addBackgroundColorAndText(logConfig.ErrorColor, logConfig.ErrorHeaders, args);
            this._doLog.apply(this._doLog, args);
        }
    };

    LogR.prototype.trace = function () {
        var args = [];
        for (var _i = 0; _i < (arguments.length - 0); _i++) {
            args[_i] = arguments[_i + 0];
        }
        if (logConfig.TraceOn) {
            this._addBackgroundColorAndText(logConfig.TraceColor, logConfig.TraceHeaders, args);
            this._doLog.apply(this._doLog, args);
        }
    };
    return LogR;
})();

var logConfig = {
    FontFamily: 'DejaVu Sans Mono',
    PieceOfFlair: '-=~=-',
    WarnColor: '#ffd894',
    ErrorColor: '#ff9494',
    TraceColor: '#94ffb0',
    InfoColor: '#94fdff',
    WarnHeaders: 'WARN',
    ErrorHeaders: 'ERROR',
    TraceHeaders: 'TRACE',
    InfoHeaders: 'INFO',
    WarnOn: true,
    ErrorOn: true,
    TraceOn: true,
    InfoOn: true,
    CustomOn: true,
    SupportCustomLogs: true
};

var logR = new LogR(logConfig);
