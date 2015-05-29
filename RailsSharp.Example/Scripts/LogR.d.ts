declare class LogConfig {
    public FontFamily: string;
    public PieceOfFlair: string;
    public WarnColor: string;
    public ErrorColor: string;
    public TraceColor: string;
    public InfoColor: string;
    public WarnHeaders: string;
    public ErrorHeaders: string;
    public TraceHeaders: string;
    public InfoHeaders: string;
    public WarnOn: boolean;
    public ErrorOn: boolean;
    public TraceOn: boolean;
    public InfoOn: boolean;
    public CustomOn: boolean;
    public SupportCustomLogs: boolean;
}
interface ILogR {
    info(...args: any[]): void;
    warn(...args: any[]): void;
    error(...args: any[]): void;
    trace(...args: any[]): void;
    custom(...args: any[]): void;
}
declare class LogR implements ILogR {
    constructor(config: LogConfig);
    private _config;
    private _doLog(...args);
    private _addBackgroundColorAndText(color, text, inputArgs);
    public info(...args: any[]): void;
    public warn(...args: any[]): void;
    public custom(...args: any[]): void;
    public error(...args: any[]): void;
    public trace(...args: any[]): void;
}
declare var logConfig: LogConfig;
declare var logR: LogR;
