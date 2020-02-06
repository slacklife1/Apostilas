using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Microsoft.Win32;
using System.Security.Permissions;
using System.Threading;
using System.Runtime.InteropServices;

namespace HSRsoft.HSRPopBlok
{
	/// <summary>
	/// HSRPopBlokForm - main form for the popup blocker.
	/// </summary>
	public sealed class HSRPopBlokForm : System.Windows.Forms.Form
	{
		#region Member Variables

		private System.Timers.Timer timer;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ContextMenu contextMenu;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemAbout;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItemUpdateList;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ListBox listBoxBlocked;
		private System.Windows.Forms.ListBox listBoxOpen;
		private System.ComponentModel.IContainer components;

		private ArrayList blockedList = new ArrayList();
		private ArrayList browserList = new ArrayList();

		private string ieWindowTitle = " - ";
		private System.Windows.Forms.Button btnUnblockAll;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnBlockAll;
		private bool changeMade = false;
		private bool paused = false;
		private System.Windows.Forms.Button btnNonIEBrowsers;
		private System.Windows.Forms.Button btnRefresh;
		private bool aboutVisible = false;
		private System.Windows.Forms.Label lCount;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnWildcard;
		private System.Windows.Forms.MenuItem menuItemEnable;
		private int closedCount = 0;

		public delegate bool CallBack(IntPtr hWnd, IntPtr lParam);

		#endregion

		#region Win32 API

		[DllImport("user32.dll")]
		private static extern bool EnumWindows(CallBack cb, IntPtr lParam);

		[DllImport("user32.dll")]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder title, int length);

		[DllImport("User32.dll")] 
		private static extern int IsWindowVisible(IntPtr hWnd);

		[DllImport("User32.dll")] 
		private static extern int GetParent(IntPtr hWnd);

		[DllImport("User32.dll")]
		private static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

		#endregion

		/// <summary>
		/// Constructor for the popup blocker.
		/// </summary>
		public HSRPopBlokForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Make sure we don't take up too much time.
			Thread.CurrentThread.Priority = ThreadPriority.Lowest;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if(disposing)
			{
				if (components != null) 
				{
					components.Dispose();
				}
				// Ensure we clean up properly.
				if (this.notifyIcon.Icon != null)
				{
					this.notifyIcon.Icon.Dispose();
				}
				this.notifyIcon.Dispose();
				this.timer.Dispose();
				if (this.pictureBox1.Image != null)
				{
					this.pictureBox1.Image.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(HSRPopBlokForm));
			this.timer = new System.Timers.Timer();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenu = new System.Windows.Forms.ContextMenu();
			this.menuItemAbout = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItemEnable = new System.Windows.Forms.MenuItem();
			this.menuItemUpdateList = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItemExit = new System.Windows.Forms.MenuItem();
			this.btnClose = new System.Windows.Forms.Button();
			this.listBoxBlocked = new System.Windows.Forms.ListBox();
			this.listBoxOpen = new System.Windows.Forms.ListBox();
			this.btnUnblockAll = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnWildcard = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnBlockAll = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnNonIEBrowsers = new System.Windows.Forms.Button();
			this.lCount = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.timer)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer
			// 
			this.timer.Interval = 1000;
			this.timer.SynchronizingObject = this;
			this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenu = this.contextMenu;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "HSRPopBlok";
			this.notifyIcon.Visible = true;
			this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
			// 
			// contextMenu
			// 
			this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.menuItemAbout,
																						this.menuItem1,
																						this.menuItemEnable,
																						this.menuItemUpdateList,
																						this.menuItem3,
																						this.menuItemExit});
			// 
			// menuItemAbout
			// 
			this.menuItemAbout.Index = 0;
			this.menuItemAbout.Text = "&About HSRPopBlok...";
			this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.Text = "-";
			// 
			// menuItemEnable
			// 
			this.menuItemEnable.Checked = true;
			this.menuItemEnable.Index = 2;
			this.menuItemEnable.Text = "&Enable Popup Blocking";
			this.menuItemEnable.Click += new System.EventHandler(this.menuItemEnable_Click);
			// 
			// menuItemUpdateList
			// 
			this.menuItemUpdateList.DefaultItem = true;
			this.menuItemUpdateList.Index = 3;
			this.menuItemUpdateList.Text = "&Update Blocked List...";
			this.menuItemUpdateList.Click += new System.EventHandler(this.menuItemUpdateList_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 4;
			this.menuItem3.Text = "-";
			// 
			// menuItemExit
			// 
			this.menuItemExit.Index = 5;
			this.menuItemExit.Text = "E&xit";
			this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Location = new System.Drawing.Point(381, 488);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 7;
			this.btnClose.Text = "Hide";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// listBoxBlocked
			// 
			this.listBoxBlocked.BackColor = System.Drawing.Color.SeaShell;
			this.listBoxBlocked.Location = new System.Drawing.Point(8, 24);
			this.listBoxBlocked.Name = "listBoxBlocked";
			this.listBoxBlocked.Size = new System.Drawing.Size(432, 108);
			this.listBoxBlocked.Sorted = true;
			this.listBoxBlocked.TabIndex = 0;
			this.listBoxBlocked.DoubleClick += new System.EventHandler(this.listBoxBlocked_DoubleClick);
			// 
			// listBoxOpen
			// 
			this.listBoxOpen.BackColor = System.Drawing.Color.White;
			this.listBoxOpen.Location = new System.Drawing.Point(8, 24);
			this.listBoxOpen.Name = "listBoxOpen";
			this.listBoxOpen.Size = new System.Drawing.Size(432, 108);
			this.listBoxOpen.Sorted = true;
			this.listBoxOpen.TabIndex = 0;
			this.listBoxOpen.DoubleClick += new System.EventHandler(this.listBoxOpen_DoubleClick);
			// 
			// btnUnblockAll
			// 
			this.btnUnblockAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnUnblockAll.Location = new System.Drawing.Point(360, 136);
			this.btnUnblockAll.Name = "btnUnblockAll";
			this.btnUnblockAll.Size = new System.Drawing.Size(80, 24);
			this.btnUnblockAll.TabIndex = 2;
			this.btnUnblockAll.Text = "Unblock All";
			this.btnUnblockAll.Click += new System.EventHandler(this.btnUnblockAll_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btnUnblockAll,
																					this.listBoxBlocked,
																					this.btnWildcard});
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(8, 312);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(448, 168);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// btnWildcard
			// 
			this.btnWildcard.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnWildcard.Location = new System.Drawing.Point(248, 136);
			this.btnWildcard.Name = "btnWildcard";
			this.btnWildcard.Size = new System.Drawing.Size(96, 23);
			this.btnWildcard.TabIndex = 1;
			this.btnWildcard.Text = "Add Wildcard...";
			this.btnWildcard.Click += new System.EventHandler(this.btnWildcard_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btnBlockAll,
																					this.listBoxOpen,
																					this.btnRefresh});
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Location = new System.Drawing.Point(8, 136);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(448, 168);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			// 
			// btnBlockAll
			// 
			this.btnBlockAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnBlockAll.Location = new System.Drawing.Point(360, 136);
			this.btnBlockAll.Name = "btnBlockAll";
			this.btnBlockAll.Size = new System.Drawing.Size(80, 24);
			this.btnBlockAll.TabIndex = 2;
			this.btnBlockAll.Text = "Block All";
			this.btnBlockAll.Click += new System.EventHandler(this.btnBlockAll_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRefresh.Location = new System.Drawing.Point(272, 136);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.TabIndex = 1;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnNonIEBrowsers
			// 
			this.btnNonIEBrowsers.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnNonIEBrowsers.Location = new System.Drawing.Point(8, 488);
			this.btnNonIEBrowsers.Name = "btnNonIEBrowsers";
			this.btnNonIEBrowsers.Size = new System.Drawing.Size(112, 23);
			this.btnNonIEBrowsers.TabIndex = 6;
			this.btnNonIEBrowsers.Text = "Non-IE Browsers...";
			this.btnNonIEBrowsers.Click += new System.EventHandler(this.btnNonIEBrowsers_Click);
			// 
			// lCount
			// 
			this.lCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lCount.Location = new System.Drawing.Point(89, 16);
			this.lCount.Name = "lCount";
			this.lCount.Size = new System.Drawing.Size(288, 16);
			this.lCount.TabIndex = 0;
			this.lCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.lCount});
			this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox3.Location = new System.Drawing.Point(8, 88);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(448, 40);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(192, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Blocked Counter";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Location = new System.Drawing.Point(150, 136);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(166, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Active Sites (double click to block)";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label3.Location = new System.Drawing.Point(140, 312);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(186, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Blocked Sites (double click to unblock)";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(52, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(362, 74);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 15;
			this.pictureBox1.TabStop = false;
			// 
			// HSRPopBlokForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(466, 520);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pictureBox1,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.groupBox3,
																		  this.btnNonIEBrowsers,
																		  this.groupBox2,
																		  this.groupBox1,
																		  this.btnClose});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HSRPopBlokForm";
			this.Opacity = 0;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "HSRPopBlok";
			this.TopMost = true;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.HSRPopBlokForm_Closing);
			this.Load += new System.EventHandler(this.HSRPopBlokForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.timer)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			HSRPopBlokForm f = new HSRPopBlokForm();
			Application.Run(f);
			f.Dispose();
		}

		/// <summary>
		/// Form_Load - get the title of IE and load in our list of blocked titles.
		/// Then, kick off the timer, having hidden ourselves.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HSRPopBlokForm_Load(object sender, System.EventArgs e)
		{
			// Get the title of IE and load the blocked list.
			LoadIEWindowTitle();
			LoadData();

			// Start the timer off
			this.timer.Start();
		}


		/// <summary>
		/// Notify icon was double clicked - show the lists.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void notifyIcon_DoubleClick(object sender, System.EventArgs e)
		{
			menuItemUpdateList_Click(null, EventArgs.Empty);
		}
		
		/// <summary>
		/// On closing, ensure both timers are deactivated.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HSRPopBlokForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// Ensure we stop all processing now.
			this.paused = true;
			this.timer.Stop();
		}

		/// <summary>
		/// Update list required.  Stop the timer, load in the blocked list (if required).
		/// Get a list of all currently running IE main window titles and list them.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemUpdateList_Click(object sender, System.EventArgs e)
		{
			if (this.Opacity == 1.0)
			{
				this.Select();
				// We're already being displayed.
				return;
			}

			this.timer.Stop();
			this.changeMade = false;

			System.IO.Stream s = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("HSRsoft.HSRPopBlok.Image.gif");
			this.pictureBox1.Image = new System.Drawing.Bitmap(s);
			s.Close();

			this.Text = this.notifyIcon.Text;

			// Add in the blocked list (if we haven't already).
			if (this.listBoxBlocked.Items.Count == 0)
			{
				foreach (string blocked in this.blockedList)
				{
					this.listBoxBlocked.Items.Add(blocked);
				}
			}

			// Add in the list of active.
			this.listBoxOpen.Items.Clear();
			CallBack cb = new CallBack(ListWindowsProc);
			EnumWindows(cb, IntPtr.Zero);

			this.btnUnblockAll.Enabled = (this.listBoxBlocked.Items.Count > 0);
			this.btnBlockAll.Enabled = (this.listBoxOpen.Items.Count > 0);
			this.lCount.Text = this.closedCount.ToString("N0");

			this.menuItemEnable.Enabled = false;

			this.Opacity = 1.0;
			this.Select();
		}

		/// <summary>
		/// Timer kicked in.  Check all running instances of IE.  Check their main window titles
		/// against our list.  If a match is found, close that window.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			// Stop the timer.
			this.timer.Stop();

			if (this.blockedList.Count == 0)
			{
				// Don't restart the timer if there's nothing in the blocked list.
				return;
			}

			// Check for blocked popup windows.
			CallBack cb = new CallBack(DestroyWindowsProc);
			EnumWindows(cb, IntPtr.Zero);

			// Only restart the timer if we are currently running and not paused.
			if (!this.paused)
			{
				this.timer.Start();
			}
		}

		#region Button Clicks

		/// <summary>
		/// Close the form.  Don't close the application.  Update our blocked list (if anything
		/// has changed), save it (if anything has changed) hide ourselves and start the timer again.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClose_Click(object sender, System.EventArgs e)
		{
			if (this.changeMade)
			{
				// Clear the current list.  Then repopulate.
				this.blockedList.Clear();
				foreach (string blocked in this.listBoxBlocked.Items)
				{
					this.blockedList.Add(blocked);
				}
				SaveData();
			}

			this.menuItemEnable.Enabled = true;
			
			this.pictureBox1.Image.Dispose();
			this.pictureBox1.Image = null;

			// Only restart the timer if we are currently running and not paused.
			if (!this.paused)
			{
				this.timer.Start();
			}
			this.Opacity = 0.0;
		}

		/// <summary>
		/// Manage the list of browsers to check against.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnNonIEBrowsers_Click(object sender, System.EventArgs e)
		{
			NonIEBrowsersForm nbf = new NonIEBrowsersForm();

			nbf.BrowserTitles = this.browserList;
			nbf.ShowDialog(this);
			// Only update our list if the user changed something.
			if (nbf.WasUpdated)
			{
				this.browserList = nbf.BrowserTitles;
				this.changeMade = true;
			}
			nbf.Dispose();
			
			btnRefresh_Click(null, EventArgs.Empty);
		}

		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			this.listBoxOpen.Items.Clear();
			CallBack cb = new CallBack(ListWindowsProc);
			EnumWindows(cb, IntPtr.Zero);
		}

		private void btnWildcard_Click(object sender, System.EventArgs e)
		{
			WildcardForm wf = new WildcardForm();
			if (wf.ShowDialog(this) == DialogResult.OK)
			{
				// Valid wildcard.  Get it and add it to our list.
				this.listBoxBlocked.Items.Add(wf.WildcardTitle);
				this.changeMade = true;
			}
			wf.Dispose();
		}

		#endregion

		#region Menu Clicks
				
		/// <summary>
		/// Exit the application.  Stop the timer and exit the application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemExit_Click(object sender, System.EventArgs e)
		{
			this.timer.Stop();
			Application.Exit();
		}

		/// <summary>
		/// About button clicked - show the about form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemAbout_Click(object sender, System.EventArgs e)
		{
			// Only display it if we're not already.
			if (!this.aboutVisible)
			{
				this.aboutVisible = true;
				AboutForm af = new AboutForm();
				af.ShowDialog(this);
				af.Dispose();
				this.aboutVisible = false;
				// Activate (select) ourselves if the form is visible.
				if (this.Opacity == 1.0)
				{
					this.Select();
				}
			}
		}
	
	
		private void menuItemEnable_Click(object sender, System.EventArgs e)
		{
			string resName = "";
			if (this.paused)
			{
				this.timer.Start();
				this.paused = false;
				this.notifyIcon.Text = "HSRPopBlok";
				resName = "HSRsoft.HSRPopBlok.Running.ico";
			}
			else
			{
				this.timer.Stop();
				this.paused = true;
				this.notifyIcon.Text = "HSRPopBlok - (Disabled)";
				resName = "HSRsoft.HSRPopBlok.Paused.ico";
			}
			System.IO.Stream s = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resName);
			this.notifyIcon.Icon.Dispose();
			this.notifyIcon.Icon = new System.Drawing.Icon(s);
			s.Close();

			this.menuItemEnable.Checked = !this.paused;
		}
		#endregion
		
		#region Enumerate Windows Methods

		/// <summary>
		/// Called when enumerating the windows.  If the criteria match up, the window is destroyed.
		/// This is not case-sensitive.
		/// </summary>
		/// <param name="hWnd"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		private bool DestroyWindowsProc(IntPtr hWnd, IntPtr lParam)
		{
			string windowName = this.GetComparisonText(hWnd);
			if ((windowName != null) && (windowName.Length > 0))
			{
				foreach (string block in this.blockedList)
				{
					if (block[block.Length - 1] == '*')
					{
						if (windowName.StartsWith(block.Substring(0, block.Length - 1)))
						{
							// Post a close method to the window.
							// Can't use DestroyWindow() if we didn't create the window.
							// 0x0010 = Close
							PostMessage(hWnd, (uint)0x0010, IntPtr.Zero, IntPtr.Zero);
							this.closedCount++;
							break;
						}
					}
					else
					{
						if (String.Equals(windowName, block))
						{
							// Post a close method to the window.
							// Can't use DestroyWindow() if we didn't create the window.
							// 0x0010 = Close
							PostMessage(hWnd, (uint)0x0010, IntPtr.Zero, IntPtr.Zero);
							this.closedCount++;
							break;
						}
					}
				}
			}

			// If we've paused ourselves, we need to stop processing.
			return !this.paused;
		}

		/// <summary>
		/// Procedure when enumerating the windows.  If valid, and it is an IE window,
		/// then it is added to the form's open IE list.
		/// </summary>
		/// <param name="hWnd"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		private bool ListWindowsProc(IntPtr hWnd, IntPtr lParam)
		{
			string title = GetComparisonText(hWnd);
			if ((title != null) && (title.Length > 0))
			{
				this.listBoxOpen.Items.Add(title);
			}

			// If we've paused ourselves, we need to stop processing.
			return !this.paused;
		}

		/// <summary>
		/// Takes a window handle and returns back the part of the window
		/// text to compare (for destruction).  If nothing is returned, there is nothing
		/// to compare (not an IE window).
		/// The text is only checked if the window is visible and has a parent.
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		private string GetComparisonText(IntPtr hWnd)
		{
			// Window must be visible otherwise we get lots of rubbish back from lots of hidden
			// process windows.
			if ((IsWindowVisible(hWnd) != 0) && (GetParent(hWnd) == 0))
			{
				StringBuilder result = new StringBuilder(100);

				if (GetWindowText(hWnd, result, 100) > 0)
				{
					string windowTitle = result.ToString();
					int index = windowTitle.LastIndexOf(this.ieWindowTitle);
					if (index > 0)
					{
						return windowTitle.Substring(0, index);
					}
					// Now check against the non-IE browser titles.
					foreach (string browserTitle in this.browserList)
					{
						index = windowTitle.LastIndexOf(browserTitle);
						if (index > 0)
						{
							return windowTitle.Substring(0, index);
						}
					}
				}
			}
			return null;
		}

		#endregion

		#region Blocking and Unblocking Clicks

		private void btnUnblockAll_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show(this, "Are you sure you want to remove all sites from the blocked list?", "Confirm Unblock All", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.listBoxBlocked.Items.Clear();
			}
		}

		private void btnBlockAll_Click(object sender, System.EventArgs e)
		{
			this.listBoxBlocked.BeginUpdate();
			foreach (string site in this.listBoxOpen.Items)
			{
				this.listBoxBlocked.Items.Add(site);
			}
			this.listBoxBlocked.EndUpdate();

			this.listBoxOpen.Items.Clear();
		}

		/// <summary>
		/// Remove the item from the blocked list.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listBoxBlocked_DoubleClick(object sender, System.EventArgs e)
		{
			// Remove blocked popup.
			int index = this.listBoxBlocked.SelectedIndex;
			if (index > -1)
			{
				this.listBoxBlocked.Items.RemoveAt(index);
			}
			this.changeMade = true;
		}

		/// <summary>
		/// Add an item to the blocked list from the list of open windows.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listBoxOpen_DoubleClick(object sender, System.EventArgs e)
		{
			// Add blocked popup.
			int index = this.listBoxOpen.SelectedIndex;
			if (index > -1)
			{
				this.listBoxBlocked.Items.Add(this.listBoxOpen.Items[index]);
				this.listBoxOpen.Items.RemoveAt(index);
			}
			this.changeMade = true;
		}

		#endregion
		
		#region Load IE Window Title

		/// <summary>
		/// Load IE Window title from registry
		/// </summary>
		private void LoadIEWindowTitle()
		{
			RegistryKey localUsr = null;
			RegistryKey ours = null;
			RegistryPermission rp = null;

			this.ieWindowTitle = " - ";

			try
			{
				// Get read permission.
				rp = new RegistryPermission(RegistryPermissionAccess.Read, 
					"HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Internet Explorer\\Main");

				// Open the local machine key.
				localUsr = Registry.CurrentUser;
				ours = localUsr.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main");

				this.ieWindowTitle += ours.GetValue("Window Title");
			}
			catch (ArgumentException) {}
		}

		#endregion

		#region Load and Save

		/// <summary>
		/// Load in the list of browser titles and blocked window titles.
		/// </summary>
		private void LoadData()
		{
			StreamReader sr = null;
			string line;

			try
			{
				sr = new StreamReader("Blokd.dat", Encoding.ASCII);
				this.blockedList.Clear();
				this.browserList.Clear();

				if (sr.Peek() > -1)
				{
					// Ignore the first line titled <!-BROWSERS-!>
					sr.ReadLine();

					// Now read until we hit <!-BLOCKED-!>
					while ((sr.Peek() > -1) && (!String.Equals((line = sr.ReadLine()), "<!-BLOCKED-!>")))
					{
						this.browserList.Add(" - " + line);
					}

					// Now read until the end of the file...
					while (sr.Peek() > -1)
					{
						this.blockedList.Add(sr.ReadLine());
					}
				}
			}
			catch {}
			finally
			{
				if (sr != null)
				{
					sr.Close();
				}
			}
		}

		/// <summary>
		/// Save the list of browser titles and blocked window titles.
		/// </summary>
		private void SaveData()
		{
			StreamWriter sw = null;

			try
			{
				sw = new StreamWriter("Blokd.dat", false, Encoding.ASCII);

				sw.WriteLine("<!-BROWSERS-!>");
				foreach (string browser in this.browserList)
				{
					// Don't write out the " - " part which was appended for performance reasons
					// when the list was loaded in.
					sw.WriteLine(browser.Substring(3));
				}

				sw.WriteLine("<!-BLOCKED-!>");
				foreach (string block in this.blockedList)
				{
					sw.WriteLine(block);
				}
			}
			catch {}
			finally
			{
				if (sw != null)
				{
					sw.Flush();
					sw.Close();
				}
			}
		}

		#endregion
	}
}
