TextModel.cs

using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;


namespace Notepad {
  class TextModel {
    private ArrayList lines;
    private int selectionStart;

    public TextModel() {
      lines = new ArrayList();
    }

    private int LineContainingCursor() {
      int length = 0;
      int lineNr = 0;
      int cr = Environment.NewLine.Length;
      foreach ( String s in lines) {
        if (length <= selectionStart
          && selectionStart < length+s.Length + cr )
          break;
        length += s.Length + cr;
        lineNr++;
      }
      return lineNr;
    }

    public void Enter() {
      InsertParagraphTag();
    }

    public void InsertParagraphTag() {
      //
      // On Enter, we change the TextModel lines to insert, after the line containing 
      // the cursor, a blank line, and a line with <P></P>. We set the new cursor
      // location to be between the P tags: <P>|</P>.
      //
      // handle empty array special case (yucch)
      if ( lines.Count == 0 ) {
        lines.Add( "<P></P>" );
        selectionStart = 3;
        return;
      }

      lines.InsertRange(LineContainingCursor()+1, NewParagraph());

      // set cursor location
      selectionStart = NewSelectionStart(LineContainingCursor() + 2);
    }

    private int NewSelectionStart(int cursorLine) {
      int length = 0;
      for (int i = 0; i < cursorLine; i++)
        length += ((String)lines[i]).Length + Environment.NewLine.Length;
      return length + "<p>".Length;
    }

    public ArrayList NewParagraph() {
      ArrayList temp = new ArrayList();
      temp.Add("");
      temp.Add("<P></P>");
      return temp;
    }

    public ArrayList Lines {
      get {
        return lines;
      }
      set {
        lines = value;
      }
    }

    public void SetLines(String[] lines) {
      this.Lines = new ArrayList(lines);
    }

    public String[] LinesArray() {
      String[] result = new String[lines.Count];
      lines.CopyTo(result);
      return result;
    }

    public String TestText {
      get {
        StringBuilder b = new StringBuilder();
        foreach(String s in lines) {
          b.Append(s);
          b.Append(System.Environment.NewLine);
        }
        b.Insert(SelectionStart,"|");
        return b.ToString();
      }
    }

    public int SelectionStart {
      get {
        return selectionStart;
      }
      set {
        selectionStart = value;
      }
    }
   public void ChangeToH2() {
    ArrayList linesList = Lines;
    String oldLine = (String) linesList[LineContainingCursor()];
    Regex r = new Regex("<(?<prefix>.*)>(?<body>.*)</(?<suffix>.*)>");
    Match m = r.Match(oldLine);
    String newLine = "<H2>" + m.Groups["body"] + "</H2>";
    linesList[LineContainingCursor()] = newLine;
    Lines = linesList;
    }
  }
}
