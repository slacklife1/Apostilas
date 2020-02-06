using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Xml.Serialization;

using OuthouseUtility;

namespace AddEmailToServer
{
	[Serializable]
	public class Message
	{
		private string to;
		private string from;
		private string subject;
		private string body;

		public Message( )
		{
		}

		public Message( string from, string to, string subject, string body )
		{
			this.to = to;
			this.from = from;
			this.subject = subject;
			this.body = body;
		}

		public string From
		{
			get
			{
				return this.from;
			}
			set
			{
				this.from = value;
			}
		}

		public string Body
		{
			get
			{
				return this.body;
			}
			set
			{
				this.body = value;
			}
		}

		public string Subject
		{
			get
			{
				return this.subject;
			}
			set
			{
				this.subject = value;
			}
		}

		public string To
		{
			get
			{
				return this.to;
			}
			set
			{
				this.to = value;
			}
		}
	}

	/// <summary>
	/// Summary description for MailServerStoreForm.
	/// </summary>
	public class MailServerStoreForm : System.Windows.Forms.Form
	{
		// The file we store the mail in.
		private string mailFile;
		private ArrayList messages;
		private System.Windows.Forms.ListView mailItemList;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.ColumnHeader From;
		private System.Windows.Forms.ColumnHeader Subject;
		private System.Windows.Forms.Button btnClearAll;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MailServerStoreForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.messages = new ArrayList( );	
		}

		private void LoadMessages( )
		{
			// Open a file selection dialog.
			OpenFileDialog openDialog = new OpenFileDialog( );
			openDialog.CheckFileExists = false;
			openDialog.InitialDirectory = this.mailFile;
			openDialog.RestoreDirectory = true;
			if( openDialog.ShowDialog() != DialogResult.OK )
			{
				return;
			}
			this.mailFile = openDialog.FileName;

			// Load the messages out of the messages file for this folder.
			XmlSerializer serializer = new XmlSerializer( typeof( Message[] ) );
			FileStream tempStream;
			try
			{
				tempStream = new FileStream( this.mailFile, FileMode.Open );
			}
			catch( Exception )
			{
				// Unable to load the config file.
				return;
			}
			
			try
			{
				Message[] tempMessages = (Message[])serializer.Deserialize( tempStream );
				for( int count = 0; count < tempMessages.GetLength( 0 ); ++count )
				{
					this.messages.Add( tempMessages[ count ] );
				}
			}
			catch( Exception )
			{
				//MessageBox.Show( string.Format( "Unable to open the file {0}. Error = {1}", this.mailFile, e.Message ), "Deserialization Error" );
			}
			finally
			{
				tempStream.Close( );
			}

			RefreshList( );
		}

		private void SaveMessages( )
		{
			Message[] outArray = new Message[ this.messages.Count ];
			int count = 0;
			foreach( Message mess in this.messages )
			{
				outArray[ count ] = mess;
				++count;
			}
			
			XmlSerializer serializer = new XmlSerializer( typeof( Message[] ) );
			StreamWriter writer = new StreamWriter( this.mailFile );
			try
			{
				serializer.Serialize( writer, outArray );
			}
			finally
			{
				writer.Close( );
			}
		}

		private void RefreshList( )
		{
			// Clear the list.
			this.mailItemList.Items.Clear( );

			// Add all the new messages to the list.
			foreach( Message mess in this.messages )
			{
				ListViewItem newItem = new ListViewItem( new string[] { mess.From, mess.Subject } );
				this.mailItemList.Items.Add( newItem );
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.mailItemList = new System.Windows.Forms.ListView();
			this.From = new System.Windows.Forms.ColumnHeader();
			this.Subject = new System.Windows.Forms.ColumnHeader();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnClearAll = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnLoad
			// 
			this.btnLoad.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.btnLoad.Location = new System.Drawing.Point(8, 336);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(96, 24);
			this.btnLoad.TabIndex = 0;
			this.btnLoad.Text = "Load Mail File...";
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.btnSave.Location = new System.Drawing.Point(112, 336);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(96, 24);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Save Mail File";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// mailItemList
			// 
			this.mailItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.From,
																						   this.Subject});
			this.mailItemList.FullRowSelect = true;
			this.mailItemList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.mailItemList.Location = new System.Drawing.Point(8, 8);
			this.mailItemList.Name = "mailItemList";
			this.mailItemList.Size = new System.Drawing.Size(488, 320);
			this.mailItemList.TabIndex = 2;
			this.mailItemList.View = System.Windows.Forms.View.Details;
			// 
			// From
			// 
			this.From.Text = "From";
			this.From.Width = 94;
			// 
			// Subject
			// 
			this.Subject.Text = "Subject";
			this.Subject.Width = 390;
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.btnAdd.Location = new System.Drawing.Point(216, 336);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(96, 24);
			this.btnAdd.TabIndex = 3;
			this.btnAdd.Text = "Add Mail...";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnClearAll
			// 
			this.btnClearAll.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.btnClearAll.Location = new System.Drawing.Point(320, 336);
			this.btnClearAll.Name = "btnClearAll";
			this.btnClearAll.Size = new System.Drawing.Size(176, 24);
			this.btnClearAll.TabIndex = 4;
			this.btnClearAll.Text = "Clear All Messages";
			this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
			// 
			// MailServerStoreForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 366);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnClearAll,
																		  this.btnAdd,
																		  this.mailItemList,
																		  this.btnSave,
																		  this.btnLoad});
			this.Name = "MailServerStoreForm";
			this.Text = "Current Mail On Server";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MailServerStoreForm());
		}

		private void btnLoad_Click(object sender, System.EventArgs e)
		{
			LoadMessages( );
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			SaveMessages( );
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			AddEmailForm addForm = new AddEmailForm( "fatboy@alumni.utexas.edu", "" );
			DialogResult result = addForm.ShowDialog( this );
			if( result != DialogResult.OK )
			{
				return;
			}

			this.messages.Add( new Message( addForm.fromBox.Text, addForm.toBox.Text, addForm.subjectBox.Text, addForm.bodyBox.Text ) );

			RefreshList( );
		}

		private void btnClearAll_Click(object sender, System.EventArgs e)
		{
			this.messages.Clear( );

			RefreshList( );
		}
	}
}
