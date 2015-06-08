using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;

public class Logger : MonoBehaviour {

    public enum LogLevel {
        DEBUG,
        INFO,
        WARN,
        ERROR,
        NONE
    } 

    private static LogLevel _logLevel = LogLevel.DEBUG;

    public static void SetLoggingLevel(LogLevel level) {
        _logLevel = level;
    }

    public static void Debug(string msg) {
        if (_logLevel > LogLevel.DEBUG)
        {
            return;
        }
        string prepend = "<color=black>### DEBUG ###:  ";
        string append = "</color>";
        StackFrame frame = new StackFrame(1);
        var method = frame.GetMethod();
        consoleLog(prepend + msg + "\nMETHOD: " + method + append);
    }

    public static void Error(string msg) {
        if (_logLevel > LogLevel.ERROR)
        {
            return;
        }
        string prepend = "<color=red>### ERROR ###:  ";
        string append = "</color>";
        StackFrame frame = new StackFrame(1);
        var method = frame.GetMethod();
        consoleLog(prepend + msg + "\nMETHOD: " + method + append);
    }

    public static void Info(string msg) {
        if (_logLevel > LogLevel.INFO)
        {
            return;
        }
        string prepend = "<color=black>### INFO  ###:  ";
        string append = "</color>";
        StackFrame frame = new StackFrame(1);
        var method = frame.GetMethod();
        consoleLog(prepend + msg + "\nMETHOD: " + method + append);
    }

    public static void Warn(string msg) {
        if (_logLevel > LogLevel.WARN)
        {
            return;
        }
        string prepend = "<color=yellow>### WARN  ###:  ";
        string append = "</color>";
        StackFrame frame = new StackFrame(1);
        var method = frame.GetMethod();
        consoleLog(prepend + msg + "\nMETHOD: " + method + append);
    }

    private static void consoleLog(string msg) {
        print(msg);
    }

}
