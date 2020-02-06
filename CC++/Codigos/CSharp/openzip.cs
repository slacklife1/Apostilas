private void Zip_Click(object sender, System.EventArgs e)
{
	openFileDialog1.ShowDialog();

	Zip zip = new Zip();


	// The call to UnlockComponent is not needed for each new Zip object
	// created, but only once for the entire application.  We're adding it
	// here for extra visibility, so you are aware if it.
	zip.UnlockComponent(unlockCode);


	if (zip.OpenZip(openFileDialog1.FileName))
	{
		OpenStatus.Text = "Opened Zip!";
	}
	else
	{
		OpenStatus.Text = "Failed to open Zip";
	}

	listBox1.Items.Clear();

	ZipEntry entry = zip.FirstEntry();
	while (entry != null)
	{
		listBox1.Items.Add(entry.FileName);
		entry = entry.NextEntry();
	}
	
}


 