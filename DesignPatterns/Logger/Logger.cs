using Microsoft.Extensions.Logging;
using System;
using System.Net.NetworkInformation;

public sealed class Logger
{
    private static ILogger? instance = null;
    private static readonly object lockObj = new object();
    private static ILoggerFactory? loggerFactory = null;

    private Logger()
    {
        
    }

    public static ILogger Instance
    {
        get
        {
            if (instance == null) 
            {
                lock (lockObj) 
                {
                    if (instance == null) 
                    {
                        loggerFactory = LoggerFactory.Create(builder =>
                        {
                            builder.AddConsole();
                        });
                        instance = loggerFactory.CreateLogger<Logger>();
                    }
                }
            }
            return instance;
        }
    }

    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now}] {message}");
    }
}
