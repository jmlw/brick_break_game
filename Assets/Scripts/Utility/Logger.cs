using UnityEngine;
using System.Collections.Generic;

public class Logger : MonoBehaviour {

    public enum LogLevel {
        DEBUG,
        ERROR,
        INFO,
        WARN,
        NONE
    } 

    private static LogLevel _logLevel = LogLevel.INFO;

    public static void SetLoggingLevel(LogLevel level) {
        _logLevel = level;
    }

    public static void Debug(string msg) {
        if (_logLevel > LogLevel.DEBUG)
        {
            return;
        }
        string prepend = "<color=white>### DEBUG ###:  ";
        string append = "</color>";
        consoleLog(prepend + msg + append);
    }

    public static void Error(string msg) {
        if (_logLevel > LogLevel.ERROR)
        {
            return;
        }
        string prepend = "<color=red>### ERROR ###:  ";
        string append = "</color>";
        consoleLog(prepend + msg + append);
    }

    public static void Info(string msg) {
        if (_logLevel > LogLevel.INFO)
        {
            return;
        }
        string prepend = "<color=black>### INFO  ###:  ";
        string append = "</color>";
        consoleLog(prepend + msg + append);
    }

    public static void Warn(string msg) {
        if (_logLevel > LogLevel.WARN)
        {
            return;
        }
        string prepend = "<color=yellow>### WARN  ###:  ";
        string append = "</color>";
        consoleLog(prepend + msg + append);
    }

    private static void consoleLog(string msg) {
        print(msg);
    }

//    struct Log
//    {
//        public string message;
//        public string stackTrace;
//        public LogType type;
//    }
//    
//    readonly List<Log> logs = new List<Log>();
//    
//    static readonly Dictionary<LogType, Color> logTypeColors = new Dictionary<LogType, Color>()
//    {
//        { LogType.Assert, Color.white },
//        { LogType.Error, Color.red },
//        { LogType.Exception, Color.red },
//        { LogType.Log, Color.white },
//        { LogType.Warning, Color.yellow },
//    };



//    /// <summary>
//    /// Records a log from the log callback.
//    /// </summary>
//    /// <param name="message">Message.</param>
//    /// <param name="stackTrace">Trace of where the message came from.</param>
//    /// <param name="type">Type of message (error, exception, warning, assert).</param>
//    void HandleLog (string message, string stackTrace, LogType type)
//    {
//        logs.Add(new Log {
//            message = message,
//            stackTrace = stackTrace,
//            type = type,
//        });
//    }
}
