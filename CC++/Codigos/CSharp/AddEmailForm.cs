using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace OuthouseUtility
{
	/// <summary>
	/// Summary description for AddEmailForm.
	/// </summary>
	public class AddEmailForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button ok;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox fromBox;
		public System.Windows.Forms.TextBox toBox;
		public System.Windows.Forms.TextBox subjectBox;
		public System.Windows.Forms.TextBox bodyBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddEmailForm( string baseToString, string baseFromString )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.fromBox.Text = baseFromString;
			this.toBox.Text = baseToString;
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
			this.fromBox = new System.Windows.Forms.TextBox();
			this.toBox = new System.Windows.Forms.TextBox();
			this.subjectBox = new System.Windows.Forms.TextBox();
			this.bodyBox = new System.Windows.Forms.TextBox();
			this.ok = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// fromBox
			// 
			this.fromBox.Location = new System.Drawing.Point(56, 8);
			this.fromBox.Name = "fromBox";
			this.fromBox.Size = new System.Drawing.Size(416, 20);
			this.fromBox.TabIndex = 0;
			this.fromBox.Text = "spam@hotmail.com";
			// 
			// toBox
			// 
			this.toBox.Location = new System.Drawing.Point(56, 32);
			this.toBox.Name = "toBox";
			this.toBox.Size = new System.Drawing.Size(416, 20);
			this.toBox.TabIndex = 1;
			this.toBox.Text = "ken@kenisafatty.com";
			// 
			// subjectBox
			// 
			this.subjectBox.Location = new System.Drawing.Point(56, 56);
			this.subjectBox.Name = "subjectBox";
			this.subjectBox.Size = new System.Drawing.Size(416, 20);
			this.subjectBox.TabIndex = 2;
			this.subjectBox.Text = "RE: It really workz!";
			// 
			// bodyBox
			// 
			this.bodyBox.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.bodyBox.Location = new System.Drawing.Point(8, 96);
			this.bodyBox.Multiline = true;
			this.bodyBox.Name = "bodyBox";
			this.bodyBox.Size = new System.Drawing.Size(464, 152);
			this.bodyBox.TabIndex = 3;
			this.bodyBox.Text = "How would you like to gain 2 inches in justk 1 day time???!?";
			// 
			// ok
			// 
			this.ok.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ok.Location = new System.Drawing.Point(8, 256);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(168, 24);
			this.ok.TabIndex = 4;
			this.ok.Text = "OK";
			// 
			// cancel
			// 
			this.cancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(304, 256);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(168, 24);
			this.cancel.TabIndex = 5;
			this.cancel.Text = "Cancel";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 6;
			this.label1.Text = "From:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "To:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Subject:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "Message Body:";
			// 
			// AddEmailForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 286);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label4,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.cancel,
																		  this.ok,
																		  this.bodyBox,
																		  this.subjectBox,
																		  this.toBox,
																		  this.fromBox});
			this.Name = "AddEmailForm";
			this.Text = "New Email";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
