InputCommand.cs

using System;
using System.IO;
using System.Collections;

namespace Notepad
{
  /// <summary>
  /// 
  /// </summary>
  public class InputCommand
  {
    private ArrayList lines;

    public InputCommand(StringReader reader) {
      ReadLines(reader);
    }

    private void ReadLines(StringReader reader) {
      lines = new ArrayList();
      String line = reader.ReadLine();
      while (line != null && line != "*end") {
        lines.Add(line.TrimEnd());
        line = reader.ReadLine();
      }
    }

    public ArrayList CleanLines() {
      ArrayList cleanLines = new ArrayList();
      foreach ( String line in lines) {
        cleanLines.Add(CleanTheLine(line));
      }
      return cleanLines;
    }

    private String CleanTheLine(String dirty) {
      return dirty.Replace("|", "");
    }

    public int SelectionStart() {
      int charactersSoFar = 0;
      foreach (String line in lines) {
        int index = line.IndexOf("|");
        if (index != -1)
          return charactersSoFar + index;
        else
          charactersSoFar += line.Length + Environment.NewLine.Length;
      }
      return charactersSoFar - Environment.NewLine.Length;
    }
  }
}
