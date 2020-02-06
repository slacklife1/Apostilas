ITestTextBox.cs

using System;

namespace Notepad {
  interface ITestTextBox {
    string[] Lines {get; set;}
    int SelectionStart { get; set;}
    void ScrollToCaret();
  }
}