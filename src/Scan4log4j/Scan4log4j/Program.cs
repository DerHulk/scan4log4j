// See https://aka.ms/new-console-template for more information
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Scan4log4j.Tests")]

Console.WriteLine("Hello, World!");

var rootCommand = new RootCommand
            {
                new Option<DirectoryInfo>(
                    "--searchPath",
                    ()=> new DirectoryInfo(@"c:\"),
                    "Path where we start to search."),

                new Option<DirectoryInfo>(
                    "--logPath",
                    ()=> new DirectoryInfo(@"c:\temp\scan4log4j\"),
                    "Path to the log file"),               
            };

rootCommand.Description = "Wakes computers";

// Note that the parameters of the handler method are matched according to the names of the options
rootCommand.Handler = CommandHandler.Create<DirectoryInfo, DirectoryInfo>((searchPath, logPath) =>
{
    if (searchPath == null)
        throw new ArgumentNullException(nameof(searchPath));

    if (logPath == null)
        throw new ArgumentNullException(nameof(logPath));

    if (!searchPath.Exists)
        throw new DirectoryNotFoundException(nameof(searchPath));

    if (!logPath.Exists)
        logPath.Create();


});