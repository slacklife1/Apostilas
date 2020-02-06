using System;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

public class AutoRedrawForm : Form {

private Bitmap b;

public AutoRedrawForm() {
   b = new Bitmap(this.ClientSize.Width,this.ClientSize.Height);
   this.Resize += new EventHandler(this_Resize);
   this.Paint += new PaintEventHandler(this_Paint);
}

private void this_Paint(object s,PaintEventArgs e) {
   if(autoredraw) {
       Graphics g = base.CreateGraphics();
       g.DrawImage(b,0,0);
   }
}

private void this_Resize(object s,EventArgs e) {
   if(this.ClientSize.Width>b.Width && this.ClientSize.Height>b.Height) {
       Bitmap c = new Bitmap(this.ClientSize.Width,this.ClientSize.Height);
       Graphics g = Graphics.FromImage(c);
       g.DrawImage(b,0,0);
       b = c;
       g.Dispose();
   }
}

private bool autoredraw;
public bool AutoRedraw {
   get { return autoredraw; }
   set { autoredraw = value; }
}

public new Graphics CreateGraphics() {
   if(autoredraw) {
       return Graphics.FromImage(b);
   }
   return base.CreateGraphics();
}

}