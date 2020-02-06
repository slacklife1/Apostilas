/* 
 *  Developed By: Robert Snyder
 *				  rsnyder@OnlineToolsTeam.com
 *                http://www.OnlineToolsTeam.com
 *  Started:      11/9/02
 *  Description:  Visually display a single digit using only Panels and BackColor
 */

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Graphical_Digit
{
	/// <summary>
	/// Summary description for SingleDigit.
	/// </summary>
	public class SingleDigit : System.Windows.Forms.UserControl
	{
		private Color m_bgColor = System.Drawing.Color.Gold;
		private Color m_fgColor = System.Drawing.Color.Navy;
		private long m_DigitPlaceHolder = 1;
		private short m_Digit = 8;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel Top1;
		private System.Windows.Forms.Panel Top2;
		private System.Windows.Forms.Panel Middle1;
		private System.Windows.Forms.Panel Middle2;
		private System.Windows.Forms.Panel Middle3;
		private System.Windows.Forms.Panel Bottom1;
		private System.Windows.Forms.Panel Bottom2;
		private System.Windows.Forms.Panel LeftTop1;
		private System.Windows.Forms.Panel LeftTop2;
		private System.Windows.Forms.Panel LeftBottom1;
		private System.Windows.Forms.Panel LeftBottom2;
		private System.Windows.Forms.Panel RightTop1;
		private System.Windows.Forms.Panel RightTop2;
		private System.Windows.Forms.Panel RightBottom1;
		private System.Windows.Forms.Panel RightBottom2;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SingleDigit()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.Top1 = new System.Windows.Forms.Panel();
			this.Top2 = new System.Windows.Forms.Panel();
			this.Middle1 = new System.Windows.Forms.Panel();
			this.Middle2 = new System.Windows.Forms.Panel();
			this.Middle3 = new System.Windows.Forms.Panel();
			this.Bottom1 = new System.Windows.Forms.Panel();
			this.Bottom2 = new System.Windows.Forms.Panel();
			this.LeftTop1 = new System.Windows.Forms.Panel();
			this.LeftTop2 = new System.Windows.Forms.Panel();
			this.LeftBottom1 = new System.Windows.Forms.Panel();
			this.LeftBottom2 = new System.Windows.Forms.Panel();
			this.RightTop1 = new System.Windows.Forms.Panel();
			this.RightTop2 = new System.Windows.Forms.Panel();
			this.RightBottom1 = new System.Windows.Forms.Panel();
			this.RightBottom2 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.Top1,
																				 this.Top2,
																				 this.Middle1,
																				 this.Middle2,
																				 this.Middle3,
																				 this.Bottom1,
																				 this.Bottom2,
																				 this.LeftTop1,
																				 this.LeftTop2,
																				 this.LeftBottom1,
																				 this.LeftBottom2,
																				 this.RightTop1,
																				 this.RightTop2,
																				 this.RightBottom1,
																				 this.RightBottom2});
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(10, 15);
			this.panel1.TabIndex = 1;
			// 
			// Top1
			// 
			this.Top1.BackColor = System.Drawing.SystemColors.Desktop;
			this.Top1.Location = new System.Drawing.Point(1, 0);
			this.Top1.Name = "Top1";
			this.Top1.Size = new System.Drawing.Size(6, 1);
			this.Top1.TabIndex = 0;
			// 
			// Top2
			// 
			this.Top2.BackColor = System.Drawing.SystemColors.Desktop;
			this.Top2.Location = new System.Drawing.Point(2, 1);
			this.Top2.Name = "Top2";
			this.Top2.Size = new System.Drawing.Size(4, 1);
			this.Top2.TabIndex = 0;
			// 
			// Middle1
			// 
			this.Middle1.BackColor = System.Drawing.SystemColors.Desktop;
			this.Middle1.Location = new System.Drawing.Point(2, 6);
			this.Middle1.Name = "Middle1";
			this.Middle1.Size = new System.Drawing.Size(4, 1);
			this.Middle1.TabIndex = 0;
			// 
			// Middle2
			// 
			this.Middle2.BackColor = System.Drawing.SystemColors.Desktop;
			this.Middle2.Location = new System.Drawing.Point(1, 7);
			this.Middle2.Name = "Middle2";
			this.Middle2.Size = new System.Drawing.Size(6, 1);
			this.Middle2.TabIndex = 0;
			// 
			// Middle3
			// 
			this.Middle3.BackColor = System.Drawing.SystemColors.Desktop;
			this.Middle3.Location = new System.Drawing.Point(2, 8);
			this.Middle3.Name = "Middle3";
			this.Middle3.Size = new System.Drawing.Size(4, 1);
			this.Middle3.TabIndex = 0;
			// 
			// Bottom1
			// 
			this.Bottom1.BackColor = System.Drawing.SystemColors.Desktop;
			this.Bottom1.Location = new System.Drawing.Point(1, 14);
			this.Bottom1.Name = "Bottom1";
			this.Bottom1.Size = new System.Drawing.Size(6, 1);
			this.Bottom1.TabIndex = 1;
			// 
			// Bottom2
			// 
			this.Bottom2.BackColor = System.Drawing.SystemColors.Desktop;
			this.Bottom2.Location = new System.Drawing.Point(2, 13);
			this.Bottom2.Name = "Bottom2";
			this.Bottom2.Size = new System.Drawing.Size(4, 1);
			this.Bottom2.TabIndex = 1;
			// 
			// LeftTop1
			// 
			this.LeftTop1.BackColor = System.Drawing.SystemColors.Desktop;
			this.LeftTop1.Location = new System.Drawing.Point(0, 1);
			this.LeftTop1.Name = "LeftTop1";
			this.LeftTop1.Size = new System.Drawing.Size(1, 6);
			this.LeftTop1.TabIndex = 1;
			// 
			// LeftTop2
			// 
			this.LeftTop2.BackColor = System.Drawing.SystemColors.Desktop;
			this.LeftTop2.Location = new System.Drawing.Point(1, 2);
			this.LeftTop2.Name = "LeftTop2";
			this.LeftTop2.Size = new System.Drawing.Size(1, 4);
			this.LeftTop2.TabIndex = 1;
			// 
			// LeftBottom1
			// 
			this.LeftBottom1.BackColor = System.Drawing.SystemColors.Desktop;
			this.LeftBottom1.Location = new System.Drawing.Point(0, 8);
			this.LeftBottom1.Name = "LeftBottom1";
			this.LeftBottom1.Size = new System.Drawing.Size(1, 6);
			this.LeftBottom1.TabIndex = 1;
			// 
			// LeftBottom2
			// 
			this.LeftBottom2.BackColor = System.Drawing.SystemColors.Desktop;
			this.LeftBottom2.Location = new System.Drawing.Point(1, 9);
			this.LeftBottom2.Name = "LeftBottom2";
			this.LeftBottom2.Size = new System.Drawing.Size(1, 4);
			this.LeftBottom2.TabIndex = 1;
			// 
			// RightTop1
			// 
			this.RightTop1.BackColor = System.Drawing.SystemColors.Desktop;
			this.RightTop1.Location = new System.Drawing.Point(7, 1);
			this.RightTop1.Name = "RightTop1";
			this.RightTop1.Size = new System.Drawing.Size(1, 6);
			this.RightTop1.TabIndex = 1;
			// 
			// RightTop2
			// 
			this.RightTop2.BackColor = System.Drawing.SystemColors.Desktop;
			this.RightTop2.Location = new System.Drawing.Point(6, 2);
			this.RightTop2.Name = "RightTop2";
			this.RightTop2.Size = new System.Drawing.Size(1, 4);
			this.RightTop2.TabIndex = 1;
			// 
			// RightBottom1
			// 
			this.RightBottom1.BackColor = System.Drawing.SystemColors.Desktop;
			this.RightBottom1.Location = new System.Drawing.Point(7, 8);
			this.RightBottom1.Name = "RightBottom1";
			this.RightBottom1.Size = new System.Drawing.Size(1, 6);
			this.RightBottom1.TabIndex = 1;
			// 
			// RightBottom2
			// 
			this.RightBottom2.BackColor = System.Drawing.SystemColors.Desktop;
			this.RightBottom2.Location = new System.Drawing.Point(6, 9);
			this.RightBottom2.Name = "RightBottom2";
			this.RightBottom2.Size = new System.Drawing.Size(1, 4);
			this.RightBottom2.TabIndex = 1;
			// 
			// SingleDigit
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1});
			this.Name = "SingleDigit";
			this.Size = new System.Drawing.Size(10, 15);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 1, 10, 100, 1000, ...
		/// </summary>
		public long DigitPlaceHolder
		{
			get
			{
				return m_DigitPlaceHolder;
			}
			set
			{
				m_DigitPlaceHolder = value;
			}
		}

		public long Number
		{
			get
			{
				return m_Digit;
			}

			set
			{
				m_Digit = VerifyDigit(value);

				SetNumber(m_Digit);
			}
		}

		public string NumberStr
		{
			get
			{
				return m_Digit.ToString();
			}

			set
			{
				m_Digit = VerifyDigit(LongParse(value));

				SetNumber(m_Digit);
			}
		}

		public Color bgColor
		{
			get
			{
				return m_bgColor;
			}
			set
			{
				m_bgColor = value;

				//Set the digit again so the color will be updated
				SetNumber(m_Digit);
			}
		}

		public Color fgColor
		{
			get
			{
				return m_fgColor;
			}
			set
			{
				m_fgColor = value;
			}
		}

		private long LongParse(string strDigit)
		{
			try
			{
				return long.Parse(strDigit);
			}
			catch
			{
				return -1;
			}
		}

		private short VerifyDigit(long Digit)
		{
			short myDigit;

			myDigit = (short)( ((Digit % (m_DigitPlaceHolder * 10)) - ((Digit % (m_DigitPlaceHolder)) % 10)) / m_DigitPlaceHolder );
			
			if(	(myDigit < 0) ||
				(myDigit > 9)
				)
			{
				return -1;
			}

			return myDigit;
		}

		private void TopDigit(short Digit)
		{
			bool On = false;
			Color SetColor;

			if( (Digit == 2) ||
				(Digit == 3) ||
				(Digit == 5) ||
				(Digit == 7) ||
				(Digit == 8) ||
				(Digit == 9) ||
				(Digit == 0) 
				)
			{
				On = true;
			}

			SetColor = GetColor(On);

			this.Top1.BackColor = SetColor;
			this.Top2.BackColor = SetColor;
		}

		private void MiddleDigit(short Digit)
		{
			bool On = false;
			Color SetColor;

			if( (Digit == 2) ||
				(Digit == 3) ||
				(Digit == 4) ||
				(Digit == 5) ||
				(Digit == 6) ||
				(Digit == 8) ||
				(Digit == 9) ||
				(Digit == -1) 
				)
			{
				On = true;
			}

			SetColor = GetColor(On);

			this.Middle1.BackColor = SetColor;
			this.Middle2.BackColor = SetColor;
			this.Middle3.BackColor = SetColor;
		}

		private void BottomDigit(short Digit)
		{
			bool On = false;
			Color SetColor;

			if( (Digit == 2) ||
				(Digit == 3) ||
				(Digit == 5) ||
				(Digit == 6) ||
				(Digit == 8) ||
				(Digit == 9) ||
				(Digit == 0) 
				)
			{
				On = true;
			}

			SetColor = GetColor(On);

			this.Bottom1.BackColor = SetColor;
			this.Bottom2.BackColor = SetColor;
		}

		private void LeftTopDigit(short Digit)
		{
			bool On = false;
			Color SetColor;

			if( (Digit == 4) ||
				(Digit == 5) ||
				(Digit == 6) ||
				(Digit == 8) ||
				(Digit == 9) ||
				(Digit == 0)				
				)
			{
				On = true;
			}

			SetColor = GetColor(On);

			this.LeftTop1.BackColor = SetColor;
			this.LeftTop2.BackColor = SetColor;
		}

		private void LeftBottomDigit(short Digit)
		{
			bool On = false;
			Color SetColor;

			if( (Digit == 2) ||
				(Digit == 6) ||
				(Digit == 8) ||
				(Digit == 0) 
				)
			{
				On = true;
			}

			SetColor = GetColor(On);

			this.LeftBottom1.BackColor = SetColor;
			this.LeftBottom2.BackColor = SetColor;
		}

		private void RightTopDigit(short Digit)
		{
			bool On = false;
			Color SetColor;

			if( (Digit == 1) ||
				(Digit == 2) ||
				(Digit == 3) ||
				(Digit == 4) ||
				(Digit == 7) ||
				(Digit == 8) ||
				(Digit == 0) ||
				(Digit == 9) ||
				(Digit == -1) 
				)
			{
				On = true;
			}

			SetColor = GetColor(On);

			this.RightTop1.BackColor = SetColor;
			this.RightTop2.BackColor = SetColor;
		}

		private void RightBottomDigit(short Digit)
		{
			bool On = false;
			Color SetColor;

			if( (Digit == 1) ||
				(Digit == 3) ||
				(Digit == 4) ||
				(Digit == 5) ||
				(Digit == 6) ||
				(Digit == 7) ||
				(Digit == 8) ||
				(Digit == 9) ||
				(Digit == 0) ||
				(Digit == -1) 
				)
			{
				On = true;
			}

			SetColor = GetColor(On);

			this.RightBottom1.BackColor = SetColor;
			this.RightBottom2.BackColor = SetColor;
		}

		private Color GetColor(bool On)
		{
			Color SetColor = m_bgColor;

			if(On)
			{
				SetColor = m_fgColor;
			}

			return SetColor;
		}

		private void SetNumber(short Digit)
		{
			TopDigit(Digit);
			MiddleDigit(Digit);
			BottomDigit(Digit);

			LeftTopDigit(Digit);
			LeftBottomDigit(Digit);
			
			RightTopDigit(Digit);
			RightBottomDigit(Digit);
		}
	}
}
