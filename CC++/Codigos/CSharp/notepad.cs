Notepad.cs

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Notepad {

  class NotepadCloneNoMenu : Form
  {
    public TestableTextBox textbox;

    public NotepadCloneNoMenu() {
      Text = "Notepad Clone No Menu";

      textbox = new TestableTextBox();
      textbox.Parent = this;
      textbox.Dock = DockStyle.Fill;
      textbox.BorderStyle = BorderStyle.None;
      textbox.Multiline = true;
      textbox.ScrollBars = ScrollBars.Both;
      textbox.AcceptsTab = true;
    }
  }
}
