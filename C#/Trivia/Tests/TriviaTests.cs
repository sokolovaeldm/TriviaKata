using System;
using System.IO;
using System.Runtime.CompilerServices;
using Trivia;
using Xunit;

namespace Tests;

public class TriviaTests
{
    [Fact]
    public void Test()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);

        string[] emptyStringArray = Array.Empty<string>();
        GameRunner.Main(emptyStringArray);

        string thisPath = GetThisFilePath();
        string thisDirectory = Path.GetDirectoryName(thisPath);
        string expectedLogPath = thisDirectory + "/goldenmaster.txt";

        var goldenMaster = File.ReadAllText(expectedLogPath);
        
        Assert.Equal(goldenMaster, writer.ToString());
    }
    
    private static string GetThisFilePath([CallerFilePath] string path = null)
    {
        return path;
    }
}