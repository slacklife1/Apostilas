using System;
using System.IO;
using System.Collections;
using NUnit.Framework;

namespace Notepad

{

  [TestFixture] public class CustomerTest : Assertion {
    private TextModel model;

    [SetUp] public void CreateModel() {
      model = new TextModel();
    }

    [Test] public void EmptyModel() {
      model.Enter();
      AssertEquals("<P>|</P>\r\n", model.TestText);
    }
    
    [Test] public void StringInput() {
      String commands = 
@"*input
some line
*end
*enter
*output
some line

<P>|</P>";
      InterpretCommands(commands, "");
    }

    [Test] public void FileInput() {
      InterpretFileInput(@"c:\data\csharp\notepad\fileInput.test");
    }

    [Test] public void TestAllFiles() {
      String[] testFiles = Directory.GetFiles(@"c:\data\csharp\notepad\", "*.test");
      foreach (String testFilename in testFiles) {
        InterpretFileInput(testFilename);
      }
    }

    private void InterpretFileInput(String fileName) {
      StreamReader stream = File.OpenText(fileName);
      String contents = stream.ReadToEnd();
      stream.Close();
      InterpretCommands(contents, fileName);
    }

    private void InterpretCommands(String commands, String message) {
      StringReader reader = new StringReader(commands);
      String line = reader.ReadLine();
      CreateModel();
      while ( line != null) {
        if ( line == "*enter")
          model.Enter();
        if (line == "*display")
          Console.WriteLine("display\r\n{0}\r\nend", model.TestText);
        if (line == "*output") 
          CompareOutput(reader, message);
        if (line == "*input")
          SetInput(reader);
        line = reader.ReadLine();
      }
    }

    private void CompareOutput(StringReader reader, String message) {
      String expected = ExpectedOutput(reader);
      AssertEquals(message, expected, model.TestText);
    }

    private String ExpectedOutput(StringReader reader) {
      return ReadToEnd(reader);
    }

    private String ReadToEnd(StringReader reader) {
      String result = "";
      String line = reader.ReadLine();
      while (line != null && line != "*end") {
        result += line;
        result += System.Environment.NewLine;
        line = reader.ReadLine();
      }
      return result;
    }

    private void SetInput(StringReader reader) {
      InputCommand input = new InputCommand(reader);
      model.Lines = input.CleanLines();
      model.SelectionStart = input.SelectionStart();
    }
  }
}
