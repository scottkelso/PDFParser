// See https://aka.ms/new-console-template for more information
using Docnet.Core;
using Docnet.Core.Models;
using Docnet.Core.Readers;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;

// using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
// ILogger logger = factory.CreateLogger("Program");
// logger.LogInformation("Hello World! Logging is {Description}.", "fun");

internal class Program
{
    // Create a logger factory
    private static readonly ILogger Logger;

    
    static Program()
    {
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        Logger = loggerFactory.CreateLogger<Program>();
    }

    private static void Main(string[] args)
    {
        string corpus = ReadPdf();
        CleanCorpus(corpus);
        var info = ExtractInformation(corpus);
        ToExcel(info);
    }

    private static string ReadPdf()
    {
        try
        {
            using (var docReader = DocLib.Instance.GetDocReader(@"test.pdf", new PageDimensions()))
            {
                return ExtractText(docReader);
            }
        }
        catch (FileNotFoundException ex)
        {
            Logger.LogError(ex, "File not found!");
        }
        return "";
    }

    private static string ExtractText(IDocReader docReader)
    {
        string corpus = "";
        for (var i = 0; i < docReader.GetPageCount(); i++)
        {
            using (var pageReader = docReader.GetPageReader(i))
            {
                var text = pageReader.GetText();
                corpus += text;
            }
        }
        Logger.LogDebug("CORPUS:\n" + corpus);
        return corpus;
    }

    private static void CleanCorpus(string corpus)
    {
        Logger.LogInformation("Cleaning corpus...");
    }

    private static object ExtractInformation(string corpus)
    {
        Logger.LogInformation("Extracting Info...");
        return null;
    }

    private static void ToExcel(object info)
    {
        Logger.LogInformation("Writing to Excel doc...");
    }
}

