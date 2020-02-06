// This example will show how to handle each event when unzipping a Zip.
// You do not have to implement them, only the events you wish to receive.

// This event is called when Extract begins.
private void OnUnzipBegin(object source, EventArgs args)
{
	listBox1.Items.Add("Unzip begin...");
	unzipStatus.Text = "Unzipping...";
	unzipStatus.Refresh();
}

// This event is called just before a file is to be unzipped.
// You can abort the Unzip by setting args.Abort to true.
private void OnToBeUnzipped(object source, ToBeUnzippedEventArgs args)
{
	//args.Abort = true;
	listBox1.Items.Add("Unzipping " + args.FileName + "(file size: " + args.FileSize + " bytes, compressed size: " + args.CompressedSize + " bytes)");
	unzipStatus.Text = "Unzipping " + args.FileName + "(file size: " + args.FileSize + " bytes, compressed size: " + args.CompressedSize + " bytes)";
	unzipStatus.Refresh();
}

// This event is called just after a file has been unzipped.
// You can abort the Unzip by setting args.Abort to true.
private void OnFileUnzipped(object source, FileUnzippedEventArgs args)
{
	//args.Abort = true;
	listBox1.Items.Add("Unzipped " + args.FileName + "(file size: " + args.FileSize + " bytes, compressed size: " + args.CompressedSize + " bytes)");
	unzipStatus.Text = "Unzipped " + args.FileName + "(file size: " + args.FileSize + " bytes, compressed size: " + args.CompressedSize + " bytes)";
	unzipStatus.Refresh();
}

// This event is called when Extract ends.
private void OnUnzipEnd(object source, EventArgs args)
{
	listBox1.Items.Add("Unzip finished.");
	unzipStatus.Text = "Unzip finished.";
	unzipStatus.Refresh();
}

// Handle the event for getting the progress while writing the Zip.
private void OnUnzipPercentDone(object source, UnzipPercentDoneEventArgs args)
{
	progressBar1.Value = args.PercentDone;
}

private void Browse_Click(object sender, System.EventArgs e)
{
	openFileDialog1.ShowDialog();
	ZipFilename.Text = openFileDialog1.FileName;
}

private void UnzipButton_Click(object sender, System.EventArgs e)
{
	Zip zip = new Zip();
	zip.UnlockComponent(unlockCode);

   // Enable events.  (Events are disabled by default)
   zip.EnableEvents = true;

	// These are not required, but for the example we will show how to implement
	// each unzip event offered by Chilkat Zip.NET
	zip.OnUnzipBegin += new Zip.UnzipBeginEventHandler(OnUnzipBegin);
	zip.OnToBeUnzipped += new Zip.ToBeUnzippedEventHandler(OnToBeUnzipped);
	zip.OnFileUnzipped += new Zip.FileUnzippedEventHandler(OnFileUnzipped);
	zip.OnUnzipPercentDone += new Zip.UnzipPercentDoneEventHandler(OnUnzipPercentDone);
	zip.OnUnzipEnd += new Zip.UnzipEndEventHandler(OnUnzipEnd);

	if (PwdProtected.Checked) 
	{
		zip.PasswordProtect = true;
	}
	else if (AesEncrypted.Checked)
	{
		// 0 = no encryption, 1 = Blowfish, 2 = Twofish, 3 = AES
		zip.Encryption = 3;		
		zip.EncryptKeyLength = 128;
	}
	zip.SetPassword(Password.Text);
	zip.OpenZip(ZipFilename.Text);

	if (zip.Extract(UnzipDir.Text))
	{
		unzipStatus.Text = "Unzip successful!";
	}
	else
	{
		unzipStatus.Text = "There were errors, check errors.xml";
		zip.SaveLastError("errors.xml");
	}

}