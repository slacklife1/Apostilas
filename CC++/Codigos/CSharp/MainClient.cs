using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using OuthouseObjectModel;
using OuthouseUtility;

namespace Outhouse
{
	/// <summary>
	/// Summary description for MailClientForm.
	/// </summary>
	public class MailClientForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox messageBody;
		private System.Windows.Forms.ListView folderList;
		private System.Windows.Forms.ListView messageList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;

		private OuthouseApplication app;
		private MacroManager macroMgr;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuQuit;
		private System.Windows.Forms.MenuItem menuActions;
		private System.Windows.Forms.MenuItem menuGetNewMail;
		private System.Windows.Forms.MenuItem menuComposeNew;
		private System.Windows.Forms.MenuItem menuDeleteMessage;
		private System.Windows.Forms.MenuItem menuRunMacro;
		private System.Windows.Forms.MenuItem menuMacroEditor;
		private System.Windows.Forms.MenuItem menuMacros;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.MenuItem menuEnableDebugging; 
		private bool canDeleteMessage;

		public MailClientForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Bind the menu to this form.
			this.Menu = mainMenu1;

			// Create our applicaiton.
			this.app = new OuthouseApplication( );
			this.macroMgr = new MacroManager( this.app );

			// Update the UI.
			UpdateUI( );

			// Update the macro UI.
			UpdateMacroUI( );

			// Update the debugging setting.
			this.menuEnableDebugging.Checked = this.macroMgr.MakeDebugBuild;
		}

		// Used to clear just the message body.
		private void ClearMessageBody( )
		{
			this.messageBody.Text = "< Please select a message to display the body of... >";
		}

		// Used to reset the message list and body parts.
		private void ClearMessageParts( )
		{
			// Clear the message list as well as the message body.
			this.messageList.Items.Clear( );
			ClearMessageBody( );
		}

		// This is called to see if anything changed. If it did, we will update everything.
		private void UpdateUI( )
		{
			// Clear the message field.
			ClearMessageParts( );

			// Store the previous folder selection.
			string previousFolderSelected = "";
			if( this.folderList.SelectedItems.Count > 0	)
			{
				IFolder tempFolder = this.folderList.SelectedItems[ 0 ].Tag as IFolder;
				if( tempFolder != null )
				{
					previousFolderSelected = tempFolder.Name;
				}
			}

			// Enumerate the folders.
			// Clear the list.
			this.folderList.Items.Clear( );

			// Add all the folders to the list.
			foreach( IFolder folder in app.EnumerateFolders( ) )
			{
				ListViewItem newItem = new ListViewItem( new string[] { folder.Name, folder.EnumerateMessages( ).GetLength( 0 ).ToString( ) } );
				newItem.Tag = folder;
				this.folderList.Items.Add( newItem );
			}

			// Select the old folder if one was selected.
			if( previousFolderSelected.Length > 0 )
			{
				foreach( ListViewItem item in this.folderList.Items )
				{
					if( item.Text == previousFolderSelected )
					{
						item.Selected = true;
					}
				}
			}
		}

		/// <summary>
		/// Called to update the UI when we get macro changes.
		/// </summary>
		private void UpdateMacroUI( )
		{
			// Clear the old immediate macros.
			this.menuRunMacro.MenuItems.Clear( );

			// Add in these new macros as part of the immediate ones.
			string[] immediateMacroNames = this.macroMgr.EnumerateImmediateMacros( );
			Array.Sort( immediateMacroNames );
			int count, size = immediateMacroNames.GetLength( 0 );
			MenuItem[] items = new MenuItem[ size ];
			for( count = 0; count < size; ++count )
			{
                MenuItem tempItem = new MenuItem();
				tempItem.Text = immediateMacroNames[ count ];
				items[ count ] = tempItem;
				tempItem.Click += new System.EventHandler(this.menuImmediateMacro_Click);
			}

			// Add these in.
			this.menuRunMacro.MenuItems.AddRange( items );
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
			this.messageBody = new System.Windows.Forms.TextBox();
			this.folderList = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.messageList = new System.Windows.Forms.ListView();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuQuit = new System.Windows.Forms.MenuItem();
			this.menuActions = new System.Windows.Forms.MenuItem();
			this.menuGetNewMail = new System.Windows.Forms.MenuItem();
			this.menuComposeNew = new System.Windows.Forms.MenuItem();
			this.menuDeleteMessage = new System.Windows.Forms.MenuItem();
			this.menuMacros = new System.Windows.Forms.MenuItem();
			this.menuRunMacro = new System.Windows.Forms.MenuItem();
			this.menuMacroEditor = new System.Windows.Forms.MenuItem();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.menuEnableDebugging = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// messageBody
			// 
			this.messageBody.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.messageBody.Location = new System.Drawing.Point(144, 280);
			this.messageBody.Multiline = true;
			this.messageBody.Name = "messageBody";
			this.messageBody.ReadOnly = true;
			this.messageBody.Size = new System.Drawing.Size(504, 248);
			this.messageBody.TabIndex = 2;
			this.messageBody.Text = "";
			// 
			// folderList
			// 
			this.folderList.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left);
			this.folderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.columnHeader1,
																						 this.columnHeader2});
			this.folderList.FullRowSelect = true;
			this.folderList.HideSelection = false;
			this.folderList.Location = new System.Drawing.Point(8, 8);
			this.folderList.MultiSelect = false;
			this.folderList.Name = "folderList";
			this.folderList.Size = new System.Drawing.Size(136, 520);
			this.folderList.TabIndex = 3;
			this.folderList.View = System.Windows.Forms.View.Details;
			this.folderList.SelectedIndexChanged += new System.EventHandler(this.folderList_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Folder Name";
			this.columnHeader1.Width = 93;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Msgs";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 39;
			// 
			// messageList
			// 
			this.messageList.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.messageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.columnHeader3,
																						  this.columnHeader4});
			this.messageList.FullRowSelect = true;
			this.messageList.GridLines = true;
			this.messageList.HideSelection = false;
			this.messageList.Location = new System.Drawing.Point(144, 8);
			this.messageList.MultiSelect = false;
			this.messageList.Name = "messageList";
			this.messageList.Size = new System.Drawing.Size(504, 272);
			this.messageList.TabIndex = 4;
			this.messageList.View = System.Windows.Forms.View.Details;
			this.messageList.SelectedIndexChanged += new System.EventHandler(this.messageList_SelectedIndexChanged);
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "From";
			this.columnHeader3.Width = 96;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Subject";
			this.columnHeader4.Width = 404;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuFile,
																					  this.menuActions,
																					  this.menuMacros});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuQuit});
			this.menuFile.Text = "&File";
			// 
			// menuQuit
			// 
			this.menuQuit.DefaultItem = true;
			this.menuQuit.Index = 0;
			this.menuQuit.Text = "&Quit";
			this.menuQuit.Click += new System.EventHandler(this.menuQuit_Click);
			// 
			// menuActions
			// 
			this.menuActions.Index = 1;
			this.menuActions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.menuGetNewMail,
																						this.menuComposeNew,
																						this.menuDeleteMessage});
			this.menuActions.Text = "&Actions";
			// 
			// menuGetNewMail
			// 
			this.menuGetNewMail.Index = 0;
			this.menuGetNewMail.Text = "&Get New Mail";
			this.menuGetNewMail.Click += new System.EventHandler(this.menuGetNewMail_Click);
			// 
			// menuComposeNew
			// 
			this.menuComposeNew.DefaultItem = true;
			this.menuComposeNew.Index = 1;
			this.menuComposeNew.Text = "Compose &New";
			this.menuComposeNew.Click += new System.EventHandler(this.menuComposeNew_Click);
			// 
			// menuDeleteMessage
			// 
			this.menuDeleteMessage.Index = 2;
			this.menuDeleteMessage.Text = "&Delete Message";
			this.menuDeleteMessage.Click += new System.EventHandler(this.menuDeleteMessage_Click);

			// 
			// menuMacros
			// 
			this.menuMacros.Index = 2;
			this.menuMacros.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuRunMacro,
																					   this.menuMacroEditor,
																					   this.menuEnableDebugging});
			this.menuMacros.Text = "&Macros";
			// 
			// menuRunMacro
			// 
			this.menuRunMacro.Index = 0;
			this.menuRunMacro.Text = "&Run Macro";
			// 
			// menuMacroEditor
			// 
			this.menuMacroEditor.DefaultItem = true;
			this.menuMacroEditor.Index = 1;
			this.menuMacroEditor.Text = "Macro &Editor...";
			this.menuMacroEditor.Click += new System.EventHandler(this.menuMacroEditor_Click);
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 536);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(656, 22);
			this.statusBar.TabIndex = 5;
			this.statusBar.Text = "Ready";
			// 
			// menuEnableDebugging
			// 
			this.menuEnableDebugging.Index = 2;
			this.menuEnableDebugging.Text = "Enable Macro &Debugging";
			this.menuEnableDebugging.Click += new System.EventHandler(this.menuEnableDebugging_Click);
			// 
			// MailClientForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(656, 558);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.statusBar,
																		  this.messageList,
																		  this.folderList,
																		  this.messageBody});
			this.Name = "MailClientForm";
			this.Text = "Outhouse";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MailClientForm());
		}

		private void folderList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Default this.
			this.canDeleteMessage = false;
			this.menuDeleteMessage.Enabled = this.canDeleteMessage;

			if( this.folderList.SelectedItems.Count > 0	)
			{
				IFolder tempFolder = this.folderList.SelectedItems[ 0 ].Tag as IFolder;
				if( tempFolder != null )
				{
					this.app.ActiveFolder = tempFolder;
					ClearMessageParts( );
					foreach( IMessage message in tempFolder.EnumerateMessages( ) )
					{
						ListViewItem newItem = new ListViewItem( new string[] { message.From, message.Subject } );
						newItem.Tag = message;
						this.messageList.Items.Add( newItem );
					}

					// Is the active folder NOT Deleted Items OR Sent Items?
					if( tempFolder.Name != "Deleted Items" && tempFolder.Name != "Sent Items" )
					{
						this.canDeleteMessage = true;
					}
				}
			}
		}

		private void messageList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.menuDeleteMessage.Enabled = false;
			if( this.messageList.SelectedItems.Count > 0 )
			{
				IMessage message = this.messageList.SelectedItems[ 0 ].Tag as IMessage;
				if( message != null )
				{
					this.app.ActiveMessage = message;
					this.messageBody.Text = message.Body;

					// Should we enable the delete message?
					this.menuDeleteMessage.Enabled = this.canDeleteMessage;
					return;
				}
			}
			
			ClearMessageBody( );
		}

		private void menuQuit_Click(object sender, System.EventArgs e)
		{
			Close( );
		}

		private void menuGetNewMail_Click(object sender, System.EventArgs e)
		{
			// Try to load all the specified messages.
			this.app.CheckForNewMessages( );

			// Now check to see if anything new was added (and update everything.)
			UpdateUI( );
		}

		private void menuComposeNew_Click(object sender, System.EventArgs e)
		{
			// Make a new mail message.
			AddEmailForm addForm = new AddEmailForm( "", "fatboy@alumni.utexas.edu" );
			DialogResult result = addForm.ShowDialog( this );
			if( result != DialogResult.OK )
			{
				return;
			}

			// Add it in.
			this.app.SendMessage( new Message( addForm.fromBox.Text, addForm.toBox.Text, addForm.subjectBox.Text, addForm.bodyBox.Text ) );

			// Now check to see if anything new was added.
			UpdateUI( );
		}

		private void menuDeleteMessage_Click(object sender, System.EventArgs e)
		{
			if( this.app.ActiveFolder == null )
				return;
			this.app.ActiveFolder.RemoveMessage( this.app.ActiveMessage );
			IFolder deleted = this.app.GetFolder( "Deleted Items" );
			if( deleted != null )
			{
				deleted.AddMessage( this.app.ActiveMessage );
			}
			this.app.ActiveMessage = null;

			// Now check to see if anything new was added.
			UpdateUI( );
		}

		private void menuMacroEditor_Click(object sender, System.EventArgs e)
		{
			// Bring up the script editor.
			ScriptEditor editScriptForm = new ScriptEditor( this.macroMgr );
			DialogResult result = editScriptForm.ShowDialog( this );
			if( result != DialogResult.OK )
			{
				return;
			}

			// Update our list of macros and such.
			UpdateMacroUI( );
		}

		private void menuImmediateMacro_Click(object sender, System.EventArgs e)
		{
			MenuItem item = sender as MenuItem;
			if( item != null )
			{
				this.macroMgr.ExecuteImmediateMacro( item.Text );

				// Update the UI, in case the macro did something.
				UpdateUI( );
			}
		}

		private void menuEnableDebugging_Click(object sender, System.EventArgs e)
		{
			this.menuEnableDebugging.Checked = !this.macroMgr.MakeDebugBuild;
			this.macroMgr.MakeDebugBuild = !this.macroMgr.MakeDebugBuild;
		}
	}
}
