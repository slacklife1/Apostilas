using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Reflection;

class test : Form {

[DllImport("user32.dll")]
private static extern int GetSystemMenu(int hwnd, int bRevert);
[DllImport("user32.dll")]
private static extern int AppendMenu(int hMenu,int Flagsw,int IDNewItem,string lpNewItem);

public static void Main() {
   Application.Run(new test());
}

public test() {
   this.Text = "Hello";
   this.Show();
   int Menu1 = GetSystemMenu(this.Handle.ToInt32(), 0);  // get handle to system menu
   AppendMenu(Menu1,0xA00,0,null);   // makes a separator
   AppendMenu(Menu1,0,666,"C# Rules!");
}

protected override void WndProc(ref Message m) {
   base.WndProc(ref m);
   if(m.Msg==0x112) {    // WM_SYSCOMMAND is 0x112
   if(m.WParam.ToInt32()==666) {   // the Menu's ID is 666
       //everything in here will run when menu is clicked
       MessageBox.Show("Yo!");
   }
   }    
}

}