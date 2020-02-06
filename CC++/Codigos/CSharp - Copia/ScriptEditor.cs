using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Outhouse
{
	/// <summary>
	/// Summary description for ScriptEditor.
	/// </summary>
	public class ScriptEditor : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox scriptName;
		private System.Windows.Forms.ComboBox typeCombo;
		private System.Windows.Forms.RichTextBox scriptEdit;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ComboBox scriptsCombo;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnDelete;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button buttonCompileCode;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.ListView errorList;
		private System.Windows.Forms.Button buttonOn;
		private MacroManager macroMgr;
		private Macro activeMacro;
		private bool ignoreCodeTextChange;

		public ScriptEditor( MacroManager macroMgr )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Default the ignore text change.
			this.ignoreCodeTextChange = false;

			// Disable the compile button.
			this.buttonCompileCode.Enabled = false;

			// Store the passed in macro manager, and fill out the UI.
			this.macroMgr = macroMgr;

			UpdateScriptsCombo( );
			if( this.scriptsCombo.Items.Count > 0 )
			{
				this.scriptsCombo.SelectedIndex = 0;
			}
		}

		public void UpdateScriptsCombo( )
		{
			// Clear them.
			this.scriptsCombo.Items.Clear( );

			// Run through all the scripts and fill in their names.
			string[] names = new string[ this.macroMgr.macros.Count ];
			int count = 0;
			foreach( DictionaryEntry entry in this.macroMgr.macros )
			{
				Macro tempMacro = entry.Value as Macro;
				names[ count ] = tempMacro.name;
				++count;
			}

			Array.Sort( names );

			foreach( string name in names )
			{
				this.scriptsCombo.Items.Add( name );
			}

			// If there is nothing, add a comment.
			if( this.scriptsCombo.Items.Count == 0 )
			{
				this.scriptName.Text = "";
				this.scriptEdit.Text = "Please choose a script to edit from the Scripts combo box above...";
			}
		}

		public void UpdateActiveMacroUI( )
		{
			this.scriptName.Text = this.activeMacro.name;
			this.ignoreCodeTextChange = true;
			this.scriptEdit.Text = this.activeMacro.code;
			this.ignoreCodeTextChange = false;
			this.typeCombo.SelectedIndex = (int)this.activeMacro.type;
			this.buttonCompileCode.Enabled = this.activeMacro.needsToBeCompiled;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.label1 = new System.Windows.Forms.Label();
			this.scriptName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.typeCombo = new System.Windows.Forms.ComboBox();
			this.scriptEdit = new System.Windows.Forms.RichTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.errorList = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.buttonOn = new System.Windows.Forms.Button();
			this.scriptsCombo = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnNew = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.buttonCompileCode = new System.Windows.Forms.Button();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Name:";
			// 
			// scriptName
			// 
			this.scriptName.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.scriptName.Location = new System.Drawing.Point(56, 50);
			this.scriptName.Name = "scriptName";
			this.scriptName.Size = new System.Drawing.Size(368, 20);
			this.scriptName.TabIndex = 2;
			this.scriptName.Text = "";
			this.scriptName.TextChanged += new System.EventHandler(this.scriptName_TextChanged);
			// 
			// label2
			// 
			this.label2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.label2.Location = new System.Drawing.Point(432, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Type:";
			// 
			// typeCombo
			// 
			this.typeCombo.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.typeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.typeCombo.Items.AddRange(new object[] {
														   "Immediate",
														   "Immediate Raw",
														   "Startup"});
			this.typeCombo.Location = new System.Drawing.Point(472, 50);
			this.typeCombo.Name = "typeCombo";
			this.typeCombo.Size = new System.Drawing.Size(168, 21);
			this.typeCombo.TabIndex = 4;
			this.typeCombo.SelectedIndexChanged += new System.EventHandler(this.typeCombo_SelectedIndexChanged);
			// 
			// scriptEdit
			// 
			this.scriptEdit.AcceptsTab = true;
			this.scriptEdit.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.scriptEdit.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.scriptEdit.HideSelection = false;
			this.scriptEdit.Location = new System.Drawing.Point(8, 80);
			this.scriptEdit.Name = "scriptEdit";
			this.scriptEdit.Size = new System.Drawing.Size(632, 320);
			this.scriptEdit.TabIndex = 6;
			this.scriptEdit.Text = "Please choose a script to edit from the Scripts combo box above...";
			this.scriptEdit.WordWrap = false;
			this.scriptEdit.TextChanged += new System.EventHandler(this.scriptEdit_TextChanged);
			// 
			// label5
			// 
			this.label5.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label5.Location = new System.Drawing.Point(8, 440);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "Errors:";
			// 
			// errorList
			// 
			this.errorList.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.errorList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader4,
																						this.columnHeader5});
			this.errorList.FullRowSelect = true;
			this.errorList.GridLines = true;
			this.errorList.Location = new System.Drawing.Point(8, 456);
			this.errorList.Name = "errorList";
			this.errorList.Size = new System.Drawing.Size(632, 96);
			this.errorList.TabIndex = 10;
			this.errorList.View = System.Windows.Forms.View.Details;
			this.errorList.SelectedIndexChanged += new System.EventHandler(this.errorList_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Problem Description";
			this.columnHeader1.Width = 388;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Line";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Column";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Warning";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Error #";
			// 
			// buttonOn
			// 
			this.buttonOn.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.buttonOn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOn.Location = new System.Drawing.Point(8, 568);
			this.buttonOn.Name = "buttonOn";
			this.buttonOn.Size = new System.Drawing.Size(632, 24);
			this.buttonOn.TabIndex = 11;
			this.buttonOn.Text = "OK";
			this.buttonOn.Click += new System.EventHandler(this.buttonOn_Click);
			// 
			// scriptsCombo
			// 
			this.scriptsCombo.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.scriptsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.scriptsCombo.Location = new System.Drawing.Point(56, 8);
			this.scriptsCombo.Name = "scriptsCombo";
			this.scriptsCombo.Size = new System.Drawing.Size(384, 21);
			this.scriptsCombo.TabIndex = 12;
			this.scriptsCombo.SelectedIndexChanged += new System.EventHandler(this.scriptsCombo_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 13;
			this.label3.Text = "Macros:";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(8, 40);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(632, 1);
			this.pictureBox1.TabIndex = 15;
			this.pictureBox1.TabStop = false;
			// 
			// btnNew
			// 
			this.btnNew.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnNew.Location = new System.Drawing.Point(448, 8);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(88, 24);
			this.btnNew.TabIndex = 16;
			this.btnNew.Text = "New...";
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnDelete.Location = new System.Drawing.Point(544, 8);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(88, 24);
			this.btnDelete.TabIndex = 17;
			this.btnDelete.Text = "Delete...";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// buttonCompileCode
			// 
			this.buttonCompileCode.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.buttonCompileCode.Location = new System.Drawing.Point(8, 408);
			this.buttonCompileCode.Name = "buttonCompileCode";
			this.buttonCompileCode.Size = new System.Drawing.Size(632, 24);
			this.buttonCompileCode.TabIndex = 18;
			this.buttonCompileCode.Text = "Compile Code";
			this.buttonCompileCode.Click += new System.EventHandler(this.buttonCompileCode_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox2.Location = new System.Drawing.Point(8, 560);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(632, 1);
			this.pictureBox2.TabIndex = 19;
			this.pictureBox2.TabStop = false;
			// 
			// ScriptEditor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(648, 598);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pictureBox2,
																		  this.buttonCompileCode,
																		  this.btnDelete,
																		  this.btnNew,
																		  this.pictureBox1,
																		  this.label3,
																		  this.scriptsCombo,
																		  this.buttonOn,
																		  this.errorList,
																		  this.label5,
																		  this.scriptEdit,
																		  this.typeCombo,
																		  this.label2,
																		  this.scriptName,
																		  this.label1});
			this.Name = "ScriptEditor";
			this.Text = "Macro Editor";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			// Add a brand new macro.
			string newName = "New Macro";
			int count = 2;
			while( this.macroMgr.macros[ newName ] != null )
			{
				newName = string.Format( "New Macro ({0})", count );
				++count;
			}

			// Make the default script string.
			string defaultCode = MacroManager.prologueCode + "			// Insert Code Here." + MacroManager.epilogueCode;

			// Add this stuff in.
			Macro newMacro = new Macro( newName, defaultCode, MacroType.Immediate_Raw );
			this.macroMgr.macros[ newName ] = newMacro;

			// Add an select it.
			UpdateScriptsCombo( );
			this.scriptsCombo.SelectedItem = newName;
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if( this.scriptsCombo.SelectedItem == null )
			{
				return;
			}

			// Delete this macro from there.
			string macroToDelete = this.scriptsCombo.SelectedItem as string;
			this.macroMgr.macros.Remove( macroToDelete );

			// Update the UI.
			UpdateScriptsCombo( );
			if( this.scriptsCombo.Items.Count > 0 )
			{
				this.scriptsCombo.SelectedIndex = 0;
			}
		}

		private void buttonCompileCode_Click(object sender, System.EventArgs e)
		{
			if( this.activeMacro == null )
			{
				return;
			}

			// Do the compilation and get the errors.
			this.errorList.Items.Clear( );
			CompilerResults compResults;
			if( !this.macroMgr.CompileCode( this.activeMacro, out compResults ) )
			{
				foreach( CompilerError err in compResults.Errors )
				{
					int actualLineNumber = err.Line;
					int actualColNumber = err.Column;
					MacroManager.TransformLineNumber( this.activeMacro, ref actualLineNumber, ref actualColNumber );
					ListViewItem newItem = new ListViewItem( new string[] { err.ErrorText, actualLineNumber.ToString( ), actualColNumber.ToString( ), err.IsWarning ? "Yes" : "No", err.ErrorNumber } );
					this.errorList.Items.Add( newItem );
				}
			}

			// Set the compile button state.
			this.buttonCompileCode.Enabled = this.activeMacro.needsToBeCompiled;
		}

		private void errorList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if( this.errorList.SelectedItems.Count >= 1 )
			{
				// Go to the error of the first.
				int lineNumber = Convert.ToInt32( this.errorList.SelectedItems[ 0 ].SubItems[ 1 ].Text );
				int columnNumber = Convert.ToInt32( this.errorList.SelectedItems[ 0 ].SubItems[ 2 ].Text );

				// Find the text offset of where this line starts.
				int offset = 0;
				--lineNumber;
				while( lineNumber > 0 )
				{
					offset = this.scriptEdit.Text.IndexOf( '\n', offset ) + 1;
					--lineNumber;
				}

				// If we ran out, then bail.
				if( offset == -1 )
				{
					return;
				}

				// Add in the number of columns.
				offset += columnNumber - 1;

				// If we are at the end, select back one.
				if( offset == this.scriptEdit.Text.Length - 1 )
				{
					--offset;
				}

				if( offset < 0 )
				{
					offset = 0;
				}

				// Select a bit after the error, so that it will show up.
				this.scriptEdit.Select( offset, 1 );
			}
		}

		private void buttonOn_Click(object sender, System.EventArgs e)
		{
			// Save everything.
			this.macroMgr.SaveMacros( );

			// Load all the startup guys we can.
			this.macroMgr.LoadStartupGuys( );

			// We are done.
			Close( );
		}

		private void scriptsCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Get the name.
			string macroName = this.scriptsCombo.SelectedItem as string;

			// Get this macro, make it the active one.
			this.activeMacro = this.macroMgr.macros[ macroName ] as Macro;
			if( this.activeMacro != null )
			{
				// Update the active macro UI.
				UpdateActiveMacroUI( );
			}
		}

		private void scriptName_TextChanged(object sender, System.EventArgs e)
		{
			if( this.activeMacro == null )
			{
				return;
			}

			string oldName = this.activeMacro.name;
			this.activeMacro.name = this.scriptName.Text;
			this.macroMgr.macros.Remove( oldName );
			this.macroMgr.macros[ this.activeMacro.name ] = this.activeMacro;
			
			UpdateScriptsCombo( );

			this.scriptsCombo.SelectedItem = this.scriptName.Text;
		}

		private void scriptEdit_TextChanged(object sender, System.EventArgs e)
		{
			if( this.activeMacro == null || this.ignoreCodeTextChange )
			{
				return;
			}

			this.activeMacro.code = this.scriptEdit.Text;
			this.activeMacro.needsToBeCompiled = true;
			this.buttonCompileCode.Enabled = true;
		}

		private void typeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if( this.activeMacro == null )
			{
				return;
			}

			this.activeMacro.type = (MacroType)this.typeCombo.SelectedIndex;
		}
	}
}
