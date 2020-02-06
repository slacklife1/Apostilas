using System;
using System.Drawing;
using System.Windows.Forms;
using CsGL.OpenGL;

public class PDemo : Form
{
	MyView view = new MyView();
	
	public PDemo()
	{
		Text = "Palette demo !";
		view.Dock = DockStyle.Fill;
		Controls.Add(view);
	}
	
	[STAThread]
	public static void Main()
	{
		System.Console.WriteLine("Caution: This example program doesn't work, as the palette code so far...");
		PDemo di = new PDemo();
		Application.Run(di);
	}
}
class MyView : OpenGLControl
{
	bool isPaletized;
	protected override OpenGLContext CreateContext()
	{
		ControlGLContext ctxt = new ControlGLContext(this);
		int i,n=ctxt.NumPixelFormats;
		// try hard to have a palette...
		for(i=0; i<n; i++) {
			DisplayType dt = ctxt.GetPixelFormat(i);
			if(!dt.isRgba && dt.cColorBits<=16) {
				if((int)(dt.flags&DisplayFlags.DRAW_TO_WINDOW)==0)
					continue;
				ctxt.Create(i, null);
				break;
			}
		}
		if(i==n)
			ctxt.Create(new DisplayType(0,0), null);
		Console.WriteLine(ctxt.PixelFormat);
		
		Palette pal = ctxt.Palette;
		if(pal!=null) {
			pal[23] = new Palette.Color(0, 128, 0);
			pal.Sync();
			isPaletized = true;
		}
		else
			isPaletized = false;
		Console.WriteLine(isPaletized ? "use palette" : "no palette");
		ctxt.Grab();
		InitGLContext();
		return ctxt;
	}
	public override void glDraw()
	{
		GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
		GL.glLoadIdentity();				
		GL.glTranslatef(0.0f,0.0f,-6.0f);	
		GL.glBegin(GL.GL_TRIANGLES);
			if(isPaletized) GL.glIndexi(23);
			else GL.glColor3f(1.0f,0.0f,0.0f);
			GL.glVertex3f( 0.0f, 1.0f, 0.0f);
		
			if(isPaletized) GL.glIndexi(46);
			else GL.glColor3f(0.0f,1.0f,0.0f);
			GL.glVertex3f(-1.0f,-1.0f, 0.0f);
		
			if(isPaletized) GL.glIndexi(69);
			else GL.glColor3f(0.0f,0.0f,1.0f);
			GL.glVertex3f( 1.0f,-1.0f, 0.0f);
		GL.glEnd();
	}
	protected override void InitGLContext() 
	{
		GL.glShadeModel(GL.GL_SMOOTH);
		if(isPaletized)
			GL.glClearIndex(82);
		else
			GL.glClearColor(0, 0, 0, 0);
		GL.glClearDepth(1.0f);
		GL.glEnable(GL.GL_DEPTH_TEST);
		GL.glDepthFunc(GL.GL_LEQUAL);
		GL.glHint(GL.GL_PERSPECTIVE_CORRECTION_HINT, GL.GL_NICEST);
	}
	protected override void OnSizeChanged(EventArgs e)
	{
		base.OnSizeChanged(e);
		
		Size s = Size;
		double aspect_ratio = (double)s.Width /(double) s.Height;

	    GL.glMatrixMode(GL.GL_PROJECTION);
	    GL.glLoadIdentity();
		GL.gluPerspective(45.0f, aspect_ratio, 0.1f, 100.0f);
	
	    GL.glMatrixMode(GL.GL_MODELVIEW);
	    GL.glLoadIdentity();
	}
}
