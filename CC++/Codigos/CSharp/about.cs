/*	Project		:	AnimateTray
 *	File Name	:	AboutDlg.cs
 *	Purpose		:	About Window and Version information
 *	Author		:	K.Niranjan Kumar
 *	Date		:	16/06/2001
 *	Company		:	Cognizant Technology Solutions.
 *	e-Mail		:	KNiranja@chn.cognizant.com
 */

namespace AnimateTray
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>
    ///    Summary description for AboutDlg.
    /// </summary>
    public class AboutDlg : System.Windows.Forms.Form
    {
        /// <summary>
        ///    Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.LinkLabel m_linkLabelWebsite;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolTip m_toolTip;
		private System.Windows.Forms.LinkLabel m_linkLabelEMail;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button m_bnClose;
		private System.Windows.Forms.PictureBox m_pictureBoxLogo;

        public AboutDlg()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        ///    Clean up any resources being used.
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

        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager (typeof(AboutDlg));
			this.components = new System.ComponentModel.Container ();
			this.label1 = new System.Windows.Forms.Label ();
			this.groupBox1 = new System.Windows.Forms.GroupBox ();
			this.label2 = new System.Windows.Forms.Label ();
			this.m_bnClose = new System.Windows.Forms.Button ();
			this.m_linkLabelEMail = new System.Windows.Forms.LinkLabel ();
			this.m_toolTip = new System.Windows.Forms.ToolTip (this.components);
			this.m_pictureBoxLogo = new System.Windows.Forms.PictureBox ();
			this.m_linkLabelWebsite = new System.Windows.Forms.LinkLabel ();
			//@this.TrayHeight = 90;
			//@this.TrayLargeIcon = false;
			//@this.TrayAutoArrange = true;
			label1.Location = new System.Drawing.Point (19, 134);
			label1.Text = "Designed and Developed by :";
			label1.Size = new System.Drawing.Size (156, 16);
			label1.TabIndex = 2;
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			groupBox1.Location = new System.Drawing.Point (2, 114);
			groupBox1.TabIndex = 6;
			groupBox1.TabStop = false;
			groupBox1.Size = new System.Drawing.Size (440, 7);
			label2.Location = new System.Drawing.Point (100, 154);
			label2.Text = "Web Site :";
			label2.Size = new System.Drawing.Size (75, 15);
			label2.TabIndex = 4;
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			m_bnClose.Location = new System.Drawing.Point (362, 176);
			m_bnClose.Size = new System.Drawing.Size (75, 23);
			m_bnClose.TabIndex = 1;
			m_bnClose.Text = "&Close";
			m_bnClose.Click += new System.EventHandler (this.OnClickClose);
			m_linkLabelEMail.Text = "Niranjan Kumar. K";
			m_linkLabelEMail.Size = new System.Drawing.Size (100, 17);
			m_toolTip.SetToolTip (m_linkLabelEMail, "KNiranja@chn.cognizant.com");
			m_linkLabelEMail.TabIndex = 3;
			m_linkLabelEMail.TabStop = true;
			m_linkLabelEMail.Location = new System.Drawing.Point (185, 133);
			m_linkLabelEMail.BackColor = System.Drawing.SystemColors.Control;
			m_linkLabelEMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler (this.OnClickEmail);
			//@m_toolTip.SetLocation (new System.Drawing.Point (7, 7));
			m_toolTip.Active = true;
			m_pictureBoxLogo.Cursor = System.Windows.Forms.Cursors.Hand;
			m_toolTip.SetToolTip (m_pictureBoxLogo, "Where do you want to go today?");
			m_pictureBoxLogo.Size = new System.Drawing.Size (453, 114);
			m_pictureBoxLogo.TabIndex = 0;
			m_pictureBoxLogo.TabStop = false;
			m_pictureBoxLogo.Image = (System.Drawing.Image) resources.GetObject ("m_pictureBoxLogo.Image");
			m_pictureBoxLogo.Click += new System.EventHandler (this.OnClickPictureBoxLogo);
			m_linkLabelWebsite.Text = "Cognizant Technology Solutions Ltd.";
			m_linkLabelWebsite.Size = new System.Drawing.Size (194, 19);
			m_toolTip.SetToolTip (m_linkLabelWebsite, "www.cognizant.com");
			m_linkLabelWebsite.TabIndex = 5;
			m_linkLabelWebsite.TabStop = true;
			m_linkLabelWebsite.Location = new System.Drawing.Point (185, 155);
			m_linkLabelWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler (this.OnClickWebsite);
			this.Text = "About FTP Explorer Beta 1";
			this.MaximizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleBaseSize = new System.Drawing.Size (5, 13);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.ShowInTaskbar = false;
			this.Icon = null;
			this.MinimizeBox = false;
			this.ClientSize = new System.Drawing.Size (445, 210);
			this.Controls.Add (this.groupBox1);
			this.Controls.Add (this.m_linkLabelWebsite);
			this.Controls.Add (this.label2);
			this.Controls.Add (this.m_linkLabelEMail);
			this.Controls.Add (this.label1);
			this.Controls.Add (this.m_bnClose);
			this.Controls.Add (this.m_pictureBoxLogo);
		}

		protected void OnClickClose (object sender, System.EventArgs e)
		{
			this.Close();
		}

		protected void OnClickPictureBoxLogo (object sender, System.EventArgs e)
		{
			System.Diagnostics.Process.Start("http://msdn.microsoft.com/net");
		}

		protected void OnClickWebsite (object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_linkLabelWebsite.LinkVisited = true;
			System.Diagnostics.Process.Start("http://www.cognizant.com");
		}

		protected void OnClickEmail (object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_linkLabelWebsite.LinkVisited = true;
			System.Diagnostics.Process.Start("mailto:KNiranja@chn.cognizant.com");
		}
    }
}
