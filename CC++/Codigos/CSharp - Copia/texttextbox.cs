TextTextBox.cs

using System;
using System.Windows.Forms;
using NUnit.Framework;

namespace Notepad
{
  [TestFixture] public class TestTextBoxEvent : Assertion {
    bool changed;

    [SetUp] public void ClearChanged() {
      changed = false;
    }

    [Test] public void CheckEvent() {
      TestableTextBox text = new TestableTextBox();
      text.Text = "some text";
      Assert(!changed);

      text.TextChanged += new EventHandler(Text_Changed);
      text.Text = "more text";
      Assert(changed);
    }

//    [Test] public void HookForm () {
//      TestableTextBox text = new TestableTextBox();
//      text.TextChanged += new EventHandler(Text_Changed);
//      XMLNotepad xn = new XMLNotepad();
//      xn.textbox = text;
//      text.Text = "some text";
//      xn.PutText();
//      AssertEquals("hello", text.Lines[0]);
//      Assert("changed flag", changed);
//    }

    void Text_Changed(object source, EventArgs args) {
      changed = true;
    }
  }
}
