namespace Pong.Core.Loggers;

public static class LoggerCore
{
    private static readonly ILoggerFactory _factory = LoggerFactory.Create(build => build.AddConsole()
    .AddSimpleConsole(options =>
    {
        options.IncludeScopes = true;
        options.SingleLine = true;
        options.TimestampFormat = "HH:mm:ss ";
    }));

    private static readonly ILogger _logger = _factory.CreateLogger("PongNew");

    public static void LogInformation(string message, params object[] args) =>
        _logger.LogInformation(message: message, args: args);

    public static void LogError(string message, params object[] args) =>
        _logger.LogError(message: message, args: args);

    public static void LogWarning(string message, params object[] args) =>
        _logger.LogError(message: message, args: args);
}