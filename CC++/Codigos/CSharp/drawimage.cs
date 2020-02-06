using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using CsGL.OpenGL;
using CsGL.Util;

/**
 * for still unsolved reason this big in 16bit color mode.
 * You should run it with 32 bit color.
 */
public class DrawImage : Form
{
	PictureBox box = new PictureBox();
	
	public DrawImage()
	{
		Text = "This is a pregenerated Image !";
		box.BorderStyle = BorderStyle.Fixed3D;
		box.Dock = DockStyle.Fill;
		box.SizeMode = PictureBoxSizeMode.StretchImage;
		Controls.Add(box);
		
		Bitmap b = new Bitmap("FingerRight.gif");
		Cursor = Mouse.CreateCursor(b, 18, 8);
	}
	
	public static void Main()
	{
		DrawImage di = new DrawImage();
		di.box.Image = image();
		Application.Run(di);
	}
	public static Image image()
	{
		Bitmap b = new Bitmap(100, 100);
		Graphics gdi = Graphics.FromImage(b);
		GDIGLContext ctxt = new GDIGLContext(gdi);
		ctxt.Create(new DisplayType(DisplayFlags.DRAW_TO_BITMAP, true), null);
		
		ctxt.Grab();
			MyModel model = new MyModel();
			model.Init();
			model.Draw();
			GL.glFinish();
		ctxt.Dispose();
		gdi.Dispose();
		
		b.RotateFlip(RotateFlipType.RotateNoneFlipY);
		return b;
	}
}
public class MyModel : GL
{
	public void Init()
	{
		glMatrixMode(GL_PROJECTION);
		glLoadIdentity();
		gluPerspective(45.0f, 1, 0.1f, 100.0f);
	
		glMatrixMode(GL_MODELVIEW);
		glLoadIdentity();
		glClearColor(0, 0, 0, 0);
	}
	public void Draw()
	{
		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);	// Clear Screen And Depth Buffer
		glLoadIdentity();									// Reset The Current Modelview Matrix
		glTranslatef(-1.5f,0.0f,-6.0f);						// Move Left 1.5 Units And Into The Screen 6.0
		glBegin(GL_TRIANGLES);								// Drawing Using Triangles
			glColor3f(1.0f,0.0f,0.0f);						// Set The Color To Red
			glVertex3f( 0.0f, 1.0f, 0.0f);					// Top
			glColor3f(0.0f,1.0f,0.0f);						// Set The Color To Green
			glVertex3f(-1.0f,-1.0f, 0.0f);					// Bottom Left
			glColor3f(0.0f,0.0f,1.0f);						// Set The Color To Blue
			glVertex3f( 1.0f,-1.0f, 0.0f);					// Bottom Right
		glEnd();											// Finished Drawing The Triangle
		glTranslatef(3.0f,0.0f,0.0f);						// Move Right 3 Units
		glColor3f(0.5f,0.5f,1.0f);							// Set The Color To Blue One Time Only
		glBegin(GL_QUADS);									// Draw A Quad
			glVertex3f(-1.0f, 1.0f, 0.0f);					// Top Left
			glVertex3f( 1.0f, 1.0f, 0.0f);					// Top Right
			glVertex3f( 1.0f,-1.0f, 0.0f);					// Bottom Right
			glVertex3f(-1.0f,-1.0f, 0.0f);					// Bottom Left
		glEnd();											// Done Drawing The Quad
	}
}
