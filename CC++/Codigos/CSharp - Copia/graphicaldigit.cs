using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Graphical_Digit
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private long m_Counter = 0;

		private Color bgColor = System.Drawing.Color.Gold;
		private Color fgColor = System.Drawing.Color.Navy;
		private System.Windows.Forms.TextBox Input;
		private Graphical_Digit.SingleDigit TensDigit;
		private Graphical_Digit.SingleDigit HundredsDigit;
		private System.Windows.Forms.Label label1;
		private Graphical_Digit.SingleDigit OnesDigit;
		private Graphical_Digit.SingleDigit HundresCounter;
		private System.Windows.Forms.Label label2;
		private Graphical_Digit.SingleDigit TensCounter;
		private Graphical_Digit.SingleDigit SingleCounter;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Timer timer1;
		private Graphical_Digit.SingleDigit ThousandsCounter;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private Graphical_Digit.SingleDigit singleDigit1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel bgColorPanel;
		private System.Windows.Forms.Panel fgColorPanel;
		private System.Windows.Forms.Button ChangebgColor;
		private System.Windows.Forms.Button ChangefgColor;
		private System.Windows.Forms.ColorDialog bgColorDialog;
		private System.Windows.Forms.ColorDialog fgColorDialog;
		private System.ComponentModel.IContainer components;

		public Form1()
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
			this.components = new System.ComponentModel.Container();
			this.Input = new System.Windows.Forms.TextBox();
			this.OnesDigit = new Graphical_Digit.SingleDigit();
			this.TensDigit = new Graphical_Digit.SingleDigit();
			this.HundredsDigit = new Graphical_Digit.SingleDigit();
			this.label1 = new System.Windows.Forms.Label();
			this.ThousandsCounter = new Graphical_Digit.SingleDigit();
			this.HundresCounter = new Graphical_Digit.SingleDigit();
			this.label2 = new System.Windows.Forms.Label();
			this.TensCounter = new Graphical_Digit.SingleDigit();
			this.SingleCounter = new Graphical_Digit.SingleDigit();
			this.bgColorDialog = new System.Windows.Forms.ColorDialog();
			this.ChangebgColor = new System.Windows.Forms.Button();
			this.ChangefgColor = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.singleDigit1 = new Graphical_Digit.SingleDigit();
			this.label4 = new System.Windows.Forms.Label();
			this.bgColorPanel = new System.Windows.Forms.Panel();
			this.fgColorPanel = new System.Windows.Forms.Panel();
			this.fgColorDialog = new System.Windows.Forms.ColorDialog();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// Input
			// 
			this.Input.Location = new System.Drawing.Point(24, 136);
			this.Input.MaxLength = 3;
			this.Input.Name = "Input";
			this.Input.Size = new System.Drawing.Size(24, 20);
			this.Input.TabIndex = 2;
			this.Input.Text = "000";
			this.Input.TextChanged += new System.EventHandler(this.Input_TextChanged);
			// 
			// OnesDigit
			// 
			this.OnesDigit.bgColor = System.Drawing.Color.Gold;
			this.OnesDigit.DigitPlaceHolder = ((long)(1));
			this.OnesDigit.fgColor = System.Drawing.Color.Navy;
			this.OnesDigit.Location = new System.Drawing.Point(48, 112);
			this.OnesDigit.Name = "OnesDigit";
			this.OnesDigit.Number = ((long)(0));
			this.OnesDigit.NumberStr = "0";
			this.OnesDigit.Size = new System.Drawing.Size(8, 16);
			this.OnesDigit.TabIndex = 4;
			// 
			// TensDigit
			// 
			this.TensDigit.bgColor = System.Drawing.Color.Gold;
			this.TensDigit.DigitPlaceHolder = ((long)(10));
			this.TensDigit.fgColor = System.Drawing.Color.Navy;
			this.TensDigit.Location = new System.Drawing.Point(32, 112);
			this.TensDigit.Name = "TensDigit";
			this.TensDigit.Number = ((long)(0));
			this.TensDigit.NumberStr = "0";
			this.TensDigit.Size = new System.Drawing.Size(8, 16);
			this.TensDigit.TabIndex = 5;
			// 
			// HundredsDigit
			// 
			this.HundredsDigit.bgColor = System.Drawing.Color.Gold;
			this.HundredsDigit.DigitPlaceHolder = ((long)(100));
			this.HundredsDigit.fgColor = System.Drawing.Color.Navy;
			this.HundredsDigit.Location = new System.Drawing.Point(16, 112);
			this.HundredsDigit.Name = "HundredsDigit";
			this.HundredsDigit.Number = ((long)(0));
			this.HundredsDigit.NumberStr = "0";
			this.HundredsDigit.Size = new System.Drawing.Size(8, 16);
			this.HundredsDigit.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "Enter In a Number";
			// 
			// ThousandsCounter
			// 
			this.ThousandsCounter.bgColor = System.Drawing.Color.Gold;
			this.ThousandsCounter.DigitPlaceHolder = ((long)(1000));
			this.ThousandsCounter.fgColor = System.Drawing.Color.Navy;
			this.ThousandsCounter.Location = new System.Drawing.Point(16, 32);
			this.ThousandsCounter.Name = "ThousandsCounter";
			this.ThousandsCounter.Number = ((long)(0));
			this.ThousandsCounter.NumberStr = "0";
			this.ThousandsCounter.Size = new System.Drawing.Size(8, 16);
			this.ThousandsCounter.TabIndex = 8;
			// 
			// HundresCounter
			// 
			this.HundresCounter.bgColor = System.Drawing.Color.Gold;
			this.HundresCounter.DigitPlaceHolder = ((long)(100));
			this.HundresCounter.fgColor = System.Drawing.Color.Navy;
			this.HundresCounter.Location = new System.Drawing.Point(32, 32);
			this.HundresCounter.Name = "HundresCounter";
			this.HundresCounter.Number = ((long)(0));
			this.HundresCounter.NumberStr = "0";
			this.HundresCounter.Size = new System.Drawing.Size(8, 16);
			this.HundresCounter.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 24);
			this.label2.TabIndex = 10;
			this.label2.Text = "Automatic Counter";
			// 
			// TensCounter
			// 
			this.TensCounter.bgColor = System.Drawing.Color.Gold;
			this.TensCounter.DigitPlaceHolder = ((long)(10));
			this.TensCounter.fgColor = System.Drawing.Color.Navy;
			this.TensCounter.Location = new System.Drawing.Point(48, 32);
			this.TensCounter.Name = "TensCounter";
			this.TensCounter.Number = ((long)(0));
			this.TensCounter.NumberStr = "0";
			this.TensCounter.Size = new System.Drawing.Size(8, 16);
			this.TensCounter.TabIndex = 11;
			// 
			// SingleCounter
			// 
			this.SingleCounter.bgColor = System.Drawing.Color.Gold;
			this.SingleCounter.DigitPlaceHolder = ((long)(1));
			this.SingleCounter.fgColor = System.Drawing.Color.Navy;
			this.SingleCounter.Location = new System.Drawing.Point(64, 32);
			this.SingleCounter.Name = "SingleCounter";
			this.SingleCounter.Number = ((long)(0));
			this.SingleCounter.NumberStr = "0";
			this.SingleCounter.Size = new System.Drawing.Size(8, 16);
			this.SingleCounter.TabIndex = 12;
			// 
			// ChangebgColor
			// 
			this.ChangebgColor.Location = new System.Drawing.Point(168, 24);
			this.ChangebgColor.Name = "ChangebgColor";
			this.ChangebgColor.Size = new System.Drawing.Size(80, 24);
			this.ChangebgColor.TabIndex = 13;
			this.ChangebgColor.Text = "Digit bgColor";
			this.ChangebgColor.Click += new System.EventHandler(this.ChangebgColor_Click);
			// 
			// ChangefgColor
			// 
			this.ChangefgColor.Location = new System.Drawing.Point(168, 56);
			this.ChangefgColor.Name = "ChangefgColor";
			this.ChangefgColor.Size = new System.Drawing.Size(80, 24);
			this.ChangefgColor.TabIndex = 14;
			this.ChangefgColor.Text = "Digit fgColor";
			this.ChangefgColor.Click += new System.EventHandler(this.ChangefgColor_Click);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(136, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 16);
			this.label3.TabIndex = 15;
			this.label3.Text = "Change Colors";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(200, 118);
			this.numericUpDown1.Maximum = new System.Decimal(new int[] {
																		   9,
																		   0,
																		   0,
																		   0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(16, 20);
			this.numericUpDown1.TabIndex = 16;
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// singleDigit1
			// 
			this.singleDigit1.bgColor = System.Drawing.Color.Gold;
			this.singleDigit1.DigitPlaceHolder = ((long)(1));
			this.singleDigit1.fgColor = System.Drawing.Color.Navy;
			this.singleDigit1.Location = new System.Drawing.Point(184, 120);
			this.singleDigit1.Name = "singleDigit1";
			this.singleDigit1.Number = ((long)(0));
			this.singleDigit1.NumberStr = "0";
			this.singleDigit1.Size = new System.Drawing.Size(8, 16);
			this.singleDigit1.TabIndex = 17;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(120, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 32);
			this.label4.TabIndex = 18;
			this.label4.Text = "Increment / Decrement counter";
			// 
			// bgColorPanel
			// 
			this.bgColorPanel.BackColor = System.Drawing.Color.Gold;
			this.bgColorPanel.Location = new System.Drawing.Point(128, 24);
			this.bgColorPanel.Name = "bgColorPanel";
			this.bgColorPanel.Size = new System.Drawing.Size(24, 24);
			this.bgColorPanel.TabIndex = 19;
			// 
			// fgColorPanel
			// 
			this.fgColorPanel.BackColor = System.Drawing.Color.Navy;
			this.fgColorPanel.Location = new System.Drawing.Point(128, 56);
			this.fgColorPanel.Name = "fgColorPanel";
			this.fgColorPanel.Size = new System.Drawing.Size(24, 24);
			this.fgColorPanel.TabIndex = 20;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(256, 165);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.fgColorPanel,
																		  this.bgColorPanel,
																		  this.singleDigit1,
																		  this.numericUpDown1,
																		  this.label4,
																		  this.label3,
																		  this.ChangefgColor,
																		  this.ChangebgColor,
																		  this.SingleCounter,
																		  this.TensCounter,
																		  this.label2,
																		  this.HundresCounter,
																		  this.ThousandsCounter,
																		  this.label1,
																		  this.HundredsDigit,
																		  this.TensDigit,
																		  this.OnesDigit,
																		  this.Input});
			this.Name = "Form1";
			this.Text = "Panel Digits";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Input_TextChanged(object sender, System.EventArgs e)
		{
			ApplyNumberUpdate();
		}

		private void ApplyNumberUpdate()
		{
			HundredsDigit.NumberStr = Input.Text;
			TensDigit.NumberStr = Input.Text;
			OnesDigit.NumberStr = Input.Text;
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			ApplyColorUpdate();
			ApplyNumberUpdate();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			m_Counter++;

			ThousandsCounter.Number = m_Counter;
			HundresCounter.Number = m_Counter;
			TensCounter.Number = m_Counter;
			SingleCounter.Number = m_Counter;
		}

		private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
		{
			singleDigit1.Number = (long)numericUpDown1.Value;
		}

		private void ApplyColorUpdate()
		{
			singleDigit1.bgColor		= bgColorPanel.BackColor;
			singleDigit1.fgColor		= fgColorPanel.BackColor;

			ThousandsCounter.bgColor	= bgColorPanel.BackColor;
			ThousandsCounter.fgColor	= fgColorPanel.BackColor;
			HundresCounter.bgColor		= bgColorPanel.BackColor;
			HundresCounter.fgColor		= fgColorPanel.BackColor;
			TensCounter.bgColor			= bgColorPanel.BackColor;
			TensCounter.fgColor			= fgColorPanel.BackColor;
			SingleCounter.bgColor		= bgColorPanel.BackColor;
			SingleCounter.fgColor		= fgColorPanel.BackColor;

			HundredsDigit.bgColor		= bgColorPanel.BackColor;
			HundredsDigit.fgColor		= fgColorPanel.BackColor;
			TensDigit.bgColor			= bgColorPanel.BackColor;
			TensDigit.fgColor			= fgColorPanel.BackColor;
			OnesDigit.bgColor			= bgColorPanel.BackColor;
			OnesDigit.fgColor			= fgColorPanel.BackColor;

			this.Refresh();
		}

		private void ChangebgColor_Click(object sender, System.EventArgs e)
		{
			DialogResult bgResult = bgColorDialog.ShowDialog();

			if(bgResult == DialogResult.OK)
			{
				bgColorPanel.BackColor = bgColorDialog.Color;

				ApplyColorUpdate();
			}
		}

		private void ChangefgColor_Click(object sender, System.EventArgs e)
		{
			DialogResult fgResult = fgColorDialog.ShowDialog();

			if(fgResult == DialogResult.OK)
			{
				fgColorPanel.BackColor = fgColorDialog.Color;

				ApplyColorUpdate();
			}
		}
	}
}
