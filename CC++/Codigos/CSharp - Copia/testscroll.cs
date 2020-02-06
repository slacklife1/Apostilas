TestScroll.cs

using System;
using NUnit.Framework;

namespace Notepad
{
  [TestFixture] public class TestScroll: Assertion
  {
    public TestScroll()
    {
    }

    [Test] public void HookUp() {
      Assert("hooked up", true);
    }

    [Test] public void ScrollHappens() {
      int selectionStart = 1;
      string[] lines = new String[] { "hello", "world" };
      MockTextBox mock = new MockTextBox();
      XMLNotepad notepad = new XMLNotepad();
      Assert("no scroll", !mock.Scrolled);
      notepad.PutText(mock, lines, selectionStart);
      Assert("scroll happens", mock.Scrolled);
    }
  }
}
