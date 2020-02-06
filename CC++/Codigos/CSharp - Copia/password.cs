private void Zip_Click(object sender, System.EventArgs e)
{
	Zip zip = new Zip();
	zip.UnlockComponent(unlockCode);
	zip.PasswordProtect = true;
	zip.SetPassword(Password.Text);
	zip.NewZip(ZipFilename.Text);


	// Progress monitoring events are demonstrated in CreateZip.cs
	// For simplicity, we are not showing progress in this event.
	createStatus.Text = "Creating Zip, please wait...";
	createStatus.Refresh();

	if (!zip.AppendFiles(FilePattern.Text,true))
	{
		createStatus.Text = "Failed to append files, check errors.xml";
		zip.SaveLastError("errors.xml");
		return;
	}
	if (!zip.WriteZipAndClose())
	{
		createStatus.Text = "Failed to write Zip, check errors.xml";
		zip.SaveLastError("errors.xml");
		return;
	}

	createStatus.Text = "Zip file created";
}