using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

class TextBoxDemo:Form
{
  public TextBoxDemo()
  {
    NumberBox n1=new NumberBox();
    n1.TabIndex=0;
    Button b1=new Button();
    n1.Location=new Point(10,10);
    b1.Location=new Point(n1.Left+n1.Width+20,10);
    b1.Size=new Size(150,24);
    b1.Text="Wanna Give me Focus";    
    this.Controls.Add(n1);
    this.Controls.Add(b1);
  }
  public static void Main()
  {
    Application.Run(new TextBoxDemo());
  }
}

class NumberBox:TextBox
{
  public NumberBox()
  {
    this.CausesValidation=true;
    this.Validating+=new CancelEventHandler(TextBox_Validation);
  }

  private void TextBox_Validation(object sender,CancelEventArgs ce)
  {
    try
    {
      int value=Int32.Parse(this.Text);
    }
    catch(Exception)
    {
      ce.Cancel=true;
      MessageBox.Show("Please Enter Numeric Value");
    }
  }
}


-----------------------------7d13713714024a--
