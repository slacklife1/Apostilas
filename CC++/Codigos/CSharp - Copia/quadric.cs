using System;
using System.Drawing;
using System.Windows.Forms;
using CsGL.OpenGL;

public class QDemo : Form
{
	MyView view = new MyView();
	
	public QDemo()
	{
		Text = "GLUQuadric demo !";
		view.Dock = DockStyle.Fill;
		Controls.Add(view);
	}
	
	public static void Main()
	{
		QDemo di = new QDemo();
		Application.Run(di);
	}
}
class MyView : OpenGLControl
{
	public override void glDraw()
	{
		GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);	// Clear Screen And Depth Buffer
		
	    GL.glLoadIdentity();
		GL.glTranslatef( 0f, 0.0f, -10.0f );
		GL.glRotatef(40f, 0.71f, 0, 0.71f);
		GL.glColor3f(1, 1, 1);

#if USECLASS
		Quadric q = new Quadric();
		q.Style = GL.GLU_LINE;
		q.Sphere(5, 20, 20);
#else
		GLUquadric q;
		q = GL.gluNewQuadric();
		GL.gluQuadricDrawStyle(q,GL.GLU_LINE);
		GL.gluSphere(q, 5, 20, 20);
		GL.gluDeleteQuadric(q); // don't forget to free it..
#endif
	}
	protected override void InitGLContext() 
	{
		GL.glShadeModel(GL.GL_SMOOTH);
		GL.glClearColor(0.0f, 0.0f, 0.0f, 0.5f);
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
/**
 * managed Quadric class sample
 */
public class Quadric : GL
{
	GLUquadric q;
	
	public Quadric() { q = gluNewQuadric(); }
	~Quadric() { gluDeleteQuadric(q); }
	
	public uint Style
	{
		set { gluQuadricDrawStyle(q, GLU_LINE); }
	}
	public void Sphere(double radius, int slices, int stacks)
	{
		gluSphere(q, radius, slices, stacks);
	}
}
