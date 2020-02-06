XMLNotepad.cs

using System;
using System.Drawing;
using System.Windows.Forms;
using NUnit.Framework;
using System.Collections;
using System.Text.RegularExpressions;

namespace Notepad
{
  class XMLNotepad : NotepadCloneNoMenu
  {
    private TextModel model;
    [STAThread]
    static void Main(string[] args)
    {
      Application.Run(new XMLNotepad());
    }

    public XMLNotepad() {
      Text = "XML Notepad";
      textbox.KeyDown += new KeyEventHandler(XMLKeyDownHandler);
      textbox.KeyPress += new KeyPressEventHandler(XMLKeyPressHandler);
      model = new TextModel();
    }

    private void InitializeComponent() {
      this.SuspendLayout();
      // 
      // textbox
      // 
      this.textbox.Visible = true;
      // 
      // XMLNotepad
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                      this.textbox});
      this.Name = "XMLNotepad";
      this.ResumeLayout(false);

    }

    void XMLKeyPressHandler(object objSender, KeyPressEventArgs kea) {
      if ((int) kea.KeyChar == (int) Keys.Enter) {
        kea.Handled = true;
        // this code is here to avoid putting extra enters in the window.
        // if removed, when you hit enter, the new <P> line breaks in two:
        // <P>
        // |</P>  like that.
      }
    }

    void XMLKeyDownHandler(object objSender, KeyEventArgs kea) {
      model.SetLines(textbox.Lines);
      model.SelectionStart = textbox.SelectionStart;
      if (kea.KeyCode == Keys.Enter) {
        model.Enter();
        kea.Handled = true;
      }
      PutText(textbox, model.LinesArray(), model.SelectionStart);
    } 

    public void PutText(ITestTextBox textbox, string[] lines, int selectionStart) {
      // this is Feature Envy big time.
      textbox.Lines = lines;
      textbox.SelectionStart = selectionStart;
      textbox.ScrollToCaret();
    }
  }
}