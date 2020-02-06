private void button1_Click_1(object sender, System.EventArgs e)
{
System.Object nullObject = 0;
string str = "";
System.Object nullObjStr = str;
Cursor.Current = Cursors.WaitCursor;
axWebBrowser1.Navigate(textBox1.Text, ref nullObject, ref nullObjStr, ref nullObjStr, ref nullObjStr);
Cursor.Current = Cursors.Default;
}  



Here is code for toolbar button click. 



private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
{
if ( e.Button == tb1 )
{
axWebBrowser1.GoHome();
}
if ( e.Button == tb2 )
{
axWebBrowser1.Refresh();
}
if ( e.Button == tb3 )
{
axWebBrowser1.GoBack();
}
if ( e.Button == tb4 )
{
axWebBrowser1.GoForward();
}
if ( e.Button == tb5 )
{
axWebBrowser1.Stop();
}
}  
