using System;
using System.Windows.Forms;
using System.Drawing;

namespace Chronotron.UI
{
	public class SelectEventArgs : EventArgs
	{
		public SelectEventArgs(int index, bool state) { Index = index; State = state; }
		public readonly int Index;
		public readonly bool State;
		public bool Cancel;
	}

	public delegate void ControlSelectEvent(object sender, SelectEventArgs e);

	/// <summary>
	/// This class implements a simple UI control for selefting beat patterns
	/// </summary>
	public class BeatControl : Control
	{
		public BeatControl()
		{
			Count = 8;
		}
		protected override void OnPaintBackground(PaintEventArgs e)
		{
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			for (int i = 0; i < m_Ticks.Length; i++)
				PaintTick(i, e.Graphics);
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				int w = m_Ticks.Length * e.X / Width;
				if (w >= 0 && w < m_Ticks.Length)
					this[w] = !this[w];
			}
			base.OnMouseDown(e);
		}
		public int Count
		{
			get
			{
				return m_Ticks.Length;
			}
			set
			{
				m_Ticks = new bool[value];
				Invalidate();
			}
		}
		public bool this[int ndx]
		{
			get { return m_Ticks[ndx]; }
			set
			{
				if (value != m_Ticks[ndx])
				{
					SelectEventArgs e = new SelectEventArgs(ndx, value);
					OnBeatControlSelect(e);
					if (!e.Cancel)
					{
						m_Ticks[ndx] = value;
						using (Graphics g = CreateGraphics())
							PaintTick(ndx, g);
					}
				}
			}
		}
		public event ControlSelectEvent BeatControlSelect;

		private bool[] m_Ticks;
		private void PaintTick(int ndx, Graphics g)
		{
			int w = Width / m_Ticks.Length;
			Rectangle r = new Rectangle(ndx * w, 0, w, Height);
			r.Height--;
			g.FillRectangle(new SolidBrush(m_Ticks[ndx] ? ForeColor : BackColor), r);
			g.DrawRectangle(new Pen(Color.Black), r);
		}
		protected void OnBeatControlSelect(SelectEventArgs e)
		{
			if (BeatControlSelect != null)
				BeatControlSelect(this, e);
		}
	}
}
