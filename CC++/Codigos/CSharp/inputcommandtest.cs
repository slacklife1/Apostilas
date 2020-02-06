InputCommandTest.cs

using System;
using NUnit.Framework;
using System.IO;

namespace Notepad
{
  [TestFixture] public class InputCommandTest : Assertion
  {
    private InputCommand command;

    [Test] public void EmptyCommand() {
      command = new InputCommand(new StringReader(""));
      AssertEquals(0, command.CleanLines().Count);
    }

    [Test] public void OneLineCommand() {
      String oneLineString = 

@"one line
*end";
      StringReader reader = new StringReader(oneLineString);
      command = new InputCommand(reader);
      AssertEquals(1, command.CleanLines().Count);
      AssertEquals(8,command.SelectionStart());
    }

    [Test] public void OneDirtyLine() {
      command = new InputCommand(new StringReader("a|b\n*end"));
      AssertEquals("ab", command.CleanLines()[0]);
      AssertEquals(1,command.SelectionStart());
    }
  }
}
