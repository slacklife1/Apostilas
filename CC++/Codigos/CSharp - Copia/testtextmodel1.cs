TestTextModel1.cs

using System;
using System.Collections;
using NUnit.Framework;

namespace Notepad {

  [TestFixture] public class TestTextModel : Assertion {

    private TextModel model;

    [SetUp] public void CreateModel() {
      model = new TextModel();
    }

    [Test] public void TestNoLines() {
      model.SetLines(new String[0]);
      AssertEquals(0, model.Lines.Count);
    }
    [Test] public void TestNoProcessing() {
      model.SetLines(new String[3] { "hi", "there", "chet"});
      AssertEquals(3, model.Lines.Count);
    }
    [Test] public void TestOneEnter() {
      model.SetLines(new String[1] {"hello world" });
      model.SelectionStart = 5;
      model.InsertParagraphTag();
      AssertEquals(3, model.Lines.Count);
      AssertEquals(18, model.SelectionStart);
    }
    [Test] public void TestEmptyText() {
      model.Lines = new ArrayList(new String[0]);
      model.InsertParagraphTag();
      AssertEquals(1, model.Lines.Count);
      AssertEquals(3, model.SelectionStart);
    }

    // Chet comments that he hates the comments

    [Test] public void InsertWithCursorAtLineStart () {
      model.Lines = new ArrayList(new String[3] { "<P>one</P>", "", "<P>two</P>"});
      model.SelectionStart = 14;
      model.InsertParagraphTag();
      AssertEquals("<P>two</P>", model.Lines[2]);
    }

    [Test] public void TestLineContainingCursorDirectly() {
      // todo?
    }
    [Test] public void ControlTwo() {
      model.SetLines(new String[1] {"<P>The Heading</P>" });
      model.ChangeToH2();
      AssertEquals("<H2>The Heading</H2>", model.Lines[0]);
    }
  }
}
