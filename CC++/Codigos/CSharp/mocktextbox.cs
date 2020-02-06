MockTextBox.cs

using System;

namespace Notepad
{
  public class MockTextBox: ITestTextBox
  {
    private Boolean scrolled = false;
    public MockTextBox()
    {
    }

    public int SelectionStart {
      get { return 1; }
      set {}
    }

    public string[] Lines {
      get { return new string[0]; }
      set { scrolled = false; }
    }

    public void ScrollToCaret() {
      scrolled = true;
    }

      public Boolean Scrolled {
      get {
        return scrolled;
      }
    }
  }
}
