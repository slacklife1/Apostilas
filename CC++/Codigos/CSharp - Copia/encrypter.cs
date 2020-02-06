private void Zip_Click(object sender, System.EventArgs e)
{
	Zip zip = new Zip();
	zip.UnlockComponent(unlockCode);


	// Rijndael (AES) = 3, Blowfish = 1, Twofish = 2
	zip.Encryption = 3;
	zip.EncryptKeyLength = 128;		// Use 128-bit encryption
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