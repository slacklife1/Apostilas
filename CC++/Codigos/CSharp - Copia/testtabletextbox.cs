TestableTextBox.cs

using System;
using System.Windows.Forms;

namespace Notepad
{
  /// <summary>
  /// Dummy class allowing use of the ITestTextBox interface in testing.
  ///   (See TestScroll.cs and MockTextBox.cs)
  /// </summary>

  class TestableTextBox: TextBox, ITestTextBox {
  }
}
