using System;
using System.Collections;
using System.Drawing.Imaging;
using System.Text;
using System.Xml;

namespace System.Drawing
{
	/// <summary>
	/// Summary description for ParticleSystem.
	/// </summary>
	public class ParticleSystem
	{
		private class Particle
		{
			public PointF Position,Velocity;
			public SizeF Size;
			public float Angle,RotationRange;
			public int Life,LifeD;
		}
		private string name;
		private Bitmap shape;
		private string shapename;
		private Color color0,color1;
		private int emission,numparticles;
		private PointF position,positionrange;
		private SizeF size,sizerange;
		private float angle,anglerange,gravityangle,windangle;
		private float velocity,velocityrange,gravity,wind;
		private float chaos,zoom0,zoom1,windchaos;
		private float rotation,rotationrange;
		private int life,liferange;
		private bool direction,oldback;
		private ArrayList particlelist;
		private Random rnd=new Random();

		public ParticleSystem()
		{
			name="Untitled";
			shape=null;
			color0=color1=Color.White;
			zoom0=zoom1=1f;
			chaos=0f;
			emission=5;
			numparticles=1;
			rotation=rotationrange=0f;
			direction=oldback=false;
			particlelist=new ArrayList();
		}
		public ParticleSystem(string filename)
		{
			int cr,cg,cb,ca;float x,y;

			XmlTextReader r=new XmlTextReader(filename);
			
			r.ReadStartElement("ParticleSystem");
				r.ReadStartElement("Name");
					name=r.ReadString();
				r.ReadEndElement();
				r.ReadStartElement("Shape");
					shapename=r.ReadString();
				r.ReadEndElement();
				r.ReadStartElement("Color0");
					r.ReadStartElement("Red");
						cr=int.Parse(r.ReadString());
					r.ReadEndElement();
					r.ReadStartElement("Green");
						cg=int.Parse(r.ReadString());
					r.ReadEndElement();
					r.ReadStartElement("Blue");
						cb=int.Parse(r.ReadString());
					r.ReadEndElement();
					r.ReadStartElement("Alpha");
						ca=int.Parse(r.ReadString());
					r.ReadEndElement();
				r.ReadEndElement();
				color0=Color.FromArgb(ca,cr,cg,cb);
				r.ReadStartElement("Color1");
					r.ReadStartElement("Red");
						cr=int.Parse(r.ReadString());
					r.ReadEndElement();
					r.ReadStartElement("Green");
						cg=int.Parse(r.ReadString());
					r.ReadEndElement();
					r.ReadStartElement("Blue");
						cb=int.Parse(r.ReadString());
					r.ReadEndElement();
					r.ReadStartElement("Alpha");
						ca=int.Parse(r.ReadString());
					r.ReadEndElement();
				r.ReadEndElement();
				color1=Color.FromArgb(ca,cr,cg,cb);
				r.ReadStartElement("Zoom0");
					zoom0=float.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("Zoom1");
					zoom1=float.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("Emission");
					emission=int.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("NumParticles");
					numparticles=int.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("Position");
					r.ReadStartElement("X");
						x=float.Parse(r.ReadString());
					r.ReadEndElement();
					r.ReadStartElement("Y");
						y=float.Parse(r.ReadString());
					r.ReadEndElement();
				r.ReadEndElement();
				position=new PointF(x,y);
				r.ReadStartElement("PositionRange");
					r.ReadStartElement("X");
						x=float.Parse(r.ReadString());
					r.ReadEndElement();
					r.ReadStartElement("Y");
						y=float.Parse(r.ReadString());
					r.ReadEndElement();
				r.ReadEndElement();
				positionrange=new PointF(x,y);
				r.ReadStartElement("Size");
					r.ReadStartElement("Width");
						x=float.Parse(r.ReadString());
					r.ReadEndElement();
					r.ReadStartElement("Height");
						y=float.Parse(r.ReadString());
					r.ReadEndElement();
				r.ReadEndElement();
				size=new SizeF(x,y);
				r.ReadStartElement("SizeRange");
					r.ReadStartElement("Width");
						x=float.Parse(r.ReadString());
					r.ReadEndElement();
					r.ReadStartElement("Height");
						y=float.Parse(r.ReadString());
					r.ReadEndElement();
				r.ReadEndElement();
				sizerange=new SizeF(x,y);
				r.ReadStartElement("Angle");
					angle=float.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("AngleRange");
					anglerange=float.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("Velocity");
					velocity=float.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("VelocityRange");
					velocityrange=float.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("Chaos");
					chaos=float.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("Rotation");
					rotation=float.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("RotationRange");
					rotationrange=float.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("Direction");
					direction=bool.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("Life");
					life=int.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("LifeRange");
					liferange=int.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("OldBack");
					oldback=bool.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("Gravity");
					gravity=float.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("GravityAngle");
					gravityangle=float.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("Wind");
					wind=float.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("WindAngle");
					windangle=float.Parse(r.ReadString());
				r.ReadEndElement();
				r.ReadStartElement("WindChaos");
					windchaos=float.Parse(r.ReadString());
				r.ReadEndElement();
			r.ReadEndElement();
			
			r.Close();

			Bitmap bitmap=new Bitmap(shapename);
			shape=(Bitmap)bitmap.Clone();
			for(int i=0;i<shape.Width;i++)
			{
				for(int j=0;j<shape.Height;j++)
				{
					Color col=shape.GetPixel(i,j);
					shape.SetPixel(i,j,Color.FromArgb((col.R+col.G+col.B)/3,col));
				}
			}
			bitmap.Dispose();

			particlelist=new ArrayList();
		}

		public void CreateShape(int width,int height,float a,float b)
		{
			shape=new Bitmap(width,height);
			for(int x=0;x<shape.Width;x++)
			{
				for(int y=0;y<shape.Height;y++)
				{
					float dx=x-width/2;
					float dy=y-height/2;
					int f=(int)(b*Math.Exp(-a*Math.Sqrt(dx*dx+dy*dy))*255f);
					if(f<0)
						f=0;
					if(f>255)
						f=255;
					shape.SetPixel(x,y,Color.FromArgb(f,f,f,f));
				}
			}
		}
		public void Save(string filename)
		{
			XmlTextWriter w=new XmlTextWriter(filename,Encoding.Default);
			w.Formatting=Formatting.Indented;
			w.WriteStartElement("ParticleSystem");
				w.WriteStartElement("Name");
					w.WriteString(name);
				w.WriteEndElement();
				w.WriteStartElement("Shape");
					w.WriteString(shapename);
				w.WriteEndElement();
				w.WriteStartElement("Color0");
					w.WriteStartElement("Red");
						w.WriteString(color0.R.ToString());
					w.WriteEndElement();
					w.WriteStartElement("Green");
						w.WriteString(color0.G.ToString());
					w.WriteEndElement();
					w.WriteStartElement("Blue");
						w.WriteString(color0.B.ToString());
					w.WriteEndElement();
					w.WriteStartElement("Alpha");
						w.WriteString(color0.A.ToString());
					w.WriteEndElement();
				w.WriteEndElement();
				w.WriteStartElement("Color1");
					w.WriteStartElement("Red");
						w.WriteString(color1.R.ToString());
					w.WriteEndElement();
					w.WriteStartElement("Green");
						w.WriteString(color1.G.ToString());
					w.WriteEndElement();
					w.WriteStartElement("Blue");
						w.WriteString(color1.B.ToString());
					w.WriteEndElement();
					w.WriteStartElement("Alpha");
						w.WriteString(color1.A.ToString());
					w.WriteEndElement();
				w.WriteEndElement();
				w.WriteStartElement("Zoom0");
					w.WriteString(zoom0.ToString());
				w.WriteEndElement();
				w.WriteStartElement("Zoom1");
					w.WriteString(zoom1.ToString());
				w.WriteEndElement();
				w.WriteStartElement("Emission");
					w.WriteString(emission.ToString());
				w.WriteEndElement();
				w.WriteStartElement("NumParticles");
					w.WriteString(numparticles.ToString());
				w.WriteEndElement();
				w.WriteStartElement("Position");
					w.WriteStartElement("X");
						w.WriteString(position.X.ToString());
					w.WriteEndElement();
					w.WriteStartElement("Y");
						w.WriteString(position.Y.ToString());
					w.WriteEndElement();
				w.WriteEndElement();
				w.WriteStartElement("PositionRange");
					w.WriteStartElement("X");
						w.WriteString(positionrange.X.ToString());
					w.WriteEndElement();
					w.WriteStartElement("Y");
						w.WriteString(positionrange.Y.ToString());
					w.WriteEndElement();
				w.WriteEndElement();
				w.WriteStartElement("Size");
					w.WriteStartElement("Width");
						w.WriteString(size.Width.ToString());
					w.WriteEndElement();
					w.WriteStartElement("Height");
						w.WriteString(size.Height.ToString());
					w.WriteEndElement();
				w.WriteEndElement();
				w.WriteStartElement("SizeRange");
					w.WriteStartElement("Width");
						w.WriteString(sizerange.Width.ToString());
					w.WriteEndElement();
					w.WriteStartElement("Height");
						w.WriteString(sizerange.Height.ToString());
					w.WriteEndElement();
				w.WriteEndElement();
				w.WriteStartElement("Angle");
					w.WriteString(angle.ToString());
				w.WriteEndElement();
				w.WriteStartElement("AngleRange");
					w.WriteString(anglerange.ToString());
				w.WriteEndElement();
				w.WriteStartElement("Velocity");
					w.WriteString(velocity.ToString());
				w.WriteEndElement();
				w.WriteStartElement("VelocityRange");
					w.WriteString(velocityrange.ToString());
				w.WriteEndElement();
				w.WriteStartElement("Chaos");
					w.WriteString(chaos.ToString());
				w.WriteEndElement();
				w.WriteStartElement("Rotation");
					w.WriteString(rotation.ToString());
				w.WriteEndElement();
				w.WriteStartElement("RotationRange");
					w.WriteString(rotationrange.ToString());
				w.WriteEndElement();
				w.WriteStartElement("Direction");
					w.WriteString(direction.ToString());
				w.WriteEndElement();
				w.WriteStartElement("Life");
					w.WriteString(life.ToString());
				w.WriteEndElement();
				w.WriteStartElement("LifeRange");
					w.WriteString(liferange.ToString());
				w.WriteEndElement();
				w.WriteStartElement("OldBack");
					w.WriteString(oldback.ToString());
				w.WriteEndElement();
				w.WriteStartElement("Gravity");
					w.WriteString(gravity.ToString());
				w.WriteEndElement();
				w.WriteStartElement("GravityAngle");
					w.WriteString(gravityangle.ToString());
				w.WriteEndElement();
				w.WriteStartElement("Wind");
					w.WriteString(wind.ToString());
				w.WriteEndElement();
				w.WriteStartElement("WindAngle");
					w.WriteString(windangle.ToString());
				w.WriteEndElement();
				w.WriteStartElement("WindChaos");
					w.WriteString(windchaos.ToString());
				w.WriteEndElement();
			w.WriteEndElement();
			
			w.Flush();
			w.Close();
		}
		public void Reset()
		{
			particlelist=new ArrayList();
		}
		public void Update()
		{
			for(int i=0;i<particlelist.Count;i++)
			{
				Particle particle=(Particle)particlelist[i];
				if(particle.LifeD<particle.Life)
				{
					float a=windangle+((float)rnd.NextDouble()*2f-1f)*windchaos;
					particle.Velocity.X+=((float)Math.Cos(gravityangle*Math.PI/180f)*gravity+(float)Math.Cos(a*Math.PI/180f)*wind);
					particle.Velocity.Y+=((float)Math.Sin(gravityangle*Math.PI/180f)*gravity+(float)Math.Sin(a*Math.PI/180f)*wind);
					particle.Position.X+=particle.Velocity.X;
					particle.Position.Y+=particle.Velocity.Y;
					particle.LifeD++;
				}
				else
					particlelist.Remove(particle);
			}
			if(rnd.Next(emission)==0)
			{
				for(int i=0;i<numparticles;i++)
				{
					Particle particle=new Particle();
					particle.Position=new PointF(position.X+((float)rnd.NextDouble()*positionrange.X-positionrange.X/2f),position.Y+((float)rnd.NextDouble()*positionrange.Y-positionrange.Y/2f));
					particle.Size=new SizeF(size.Width+((float)rnd.NextDouble()*sizerange.Width-sizerange.Width/2f),size.Height+((float)rnd.NextDouble()*sizerange.Height-sizerange.Height/2f));
					particle.Angle=angle+((float)rnd.NextDouble()*anglerange-anglerange/2f);
					float vel=velocity+((float)rnd.NextDouble()*velocityrange-velocityrange/2f);
					particle.Velocity=new PointF((float)Math.Cos(particle.Angle*Math.PI/180f)*vel,(float)Math.Sin(particle.Angle*Math.PI/180f)*vel);
					particle.RotationRange=((float)rnd.NextDouble()*rotationrange-rotationrange/2f);
					particle.Life=life+rnd.Next(-liferange/2,liferange/2);
					particle.LifeD=0;
					particlelist.Add(particle);
				}
			}
		}
		public void Draw(Graphics g)
		{
			if(shape!=null)
			{
				if(oldback)
				{
					for(int i=0;i<particlelist.Count;i++)
					{
						Particle particle=(Particle)particlelist[i];
						float l=(float)particle.LifeD/(float)particle.Life;
						float z=zoom0*(1f-l)+zoom1*l;
						float w=((float)particle.Size.Width)*z;
						float h=((float)particle.Size.Height)*z;
						float x=particle.Position.X+(float)Math.Cos((particle.Angle-90f)*Math.PI/180f)*((float)rnd.NextDouble()*2f-1f)*chaos;
						float y=particle.Position.Y+(float)Math.Sin((particle.Angle-90f)*Math.PI/180f)*((float)rnd.NextDouble()*2f-1f)*chaos;
						ColorMatrix cm=new ColorMatrix();
						cm.Matrix00=(((float)color0.R)*(1f-l)+((float)color1.R)*l)/255f;
						cm.Matrix11=(((float)color0.G)*(1f-l)+((float)color1.G)*l)/255f;
						cm.Matrix22=(((float)color0.B)*(1f-l)+((float)color1.B)*l)/255f;
						cm.Matrix33=(((float)color0.A)*(1f-l)+((float)color1.A)*l)/255f;
						cm.Matrix44=1f;
						ImageAttributes ia=new ImageAttributes();
						ia.SetColorMatrix(cm);
						g.ResetTransform();
						g.TranslateTransform(x,y);
						if(direction)
							g.RotateTransform(particle.Angle);
						g.RotateTransform(rotation+l*particle.RotationRange);
						g.DrawImage(shape,new Rectangle((int)(-w/2f),(int)(-h/2f),(int)w,(int)h),0f,0f,shape.Width,shape.Height,GraphicsUnit.Pixel,ia);
					}
				}
				else
				{
					for(int i=particlelist.Count-1;i>=0;i--)
					{
						Particle particle=(Particle)particlelist[i];
						float l=(float)particle.LifeD/(float)particle.Life;
						float z=zoom0*(1f-l)+zoom1*l;
						float w=((float)particle.Size.Width)*z;
						float h=((float)particle.Size.Height)*z;
						float x=particle.Position.X+(float)Math.Cos((particle.Angle-90f)*Math.PI/180f)*((float)rnd.NextDouble()*2f-1f)*chaos;
						float y=particle.Position.Y+(float)Math.Sin((particle.Angle-90f)*Math.PI/180f)*((float)rnd.NextDouble()*2f-1f)*chaos;
						ColorMatrix cm=new ColorMatrix();
						cm.Matrix00=(((float)color0.R)*(1f-l)+((float)color1.R)*l)/255f;
						cm.Matrix11=(((float)color0.G)*(1f-l)+((float)color1.G)*l)/255f;
						cm.Matrix22=(((float)color0.B)*(1f-l)+((float)color1.B)*l)/255f;
						cm.Matrix33=(((float)color0.A)*(1f-l)+((float)color1.A)*l)/255f;
						cm.Matrix44=1f;
						ImageAttributes ia=new ImageAttributes();
						ia.SetColorMatrix(cm);
						g.ResetTransform();
						g.TranslateTransform(x,y);
						if(direction)
							g.RotateTransform(particle.Angle);
						g.RotateTransform(rotation+l*particle.RotationRange);
						g.DrawImage(shape,new Rectangle((int)(-w/2f),(int)(-h/2f),(int)w,(int)h),0f,0f,shape.Width,shape.Height,GraphicsUnit.Pixel,ia);
					}
				}
				g.ResetTransform();
			}
		}

		public string Name
		{
			set
			{
				name=value;
			}
			get
			{
				return name;
			}
		}
		public string Shape
		{
			set
			{
				shapename=value;
				Bitmap bitmap=new Bitmap(shapename);
				shape=(Bitmap)bitmap.Clone();
				for(int i=0;i<shape.Width;i++)
				{
					for(int j=0;j<shape.Height;j++)
					{
						Color col=shape.GetPixel(i,j);
						shape.SetPixel(i,j,Color.FromArgb((col.R+col.G+col.B)/3,col));
					}
				}
				bitmap.Dispose();
			}
			get
			{
				return shapename;
			}
		}
		public Color Color0
		{
			set
			{
				color0=value;
			}
			get
			{
				return color0;
			}
		}
		public Color Color1
		{
			set
			{
				color1=value;
			}
			get
			{
				return color1;
			}
		}
		public float Zoom0
		{
			set
			{
				zoom0=value;
			}
			get
			{
				return zoom0;
			}
		}
		public float Zoom1
		{
			set
			{
				zoom1=value;
			}
			get
			{
				return zoom1;
			}
		}
		public int Emission
		{
			set
			{
				emission=value;
			}
			get
			{
				return emission;
			}
		}
		public int NumParticles
		{
			set
			{
				numparticles=value;
			}
			get
			{
				return numparticles;
			}
		}
		public PointF Position
		{
			set
			{
				position=value;
			}
			get
			{
				return position;
			}
		}
		public PointF PositionRange
		{
			set
			{
				positionrange=value;
			}
			get
			{
				return positionrange;
			}
		}
		public SizeF Size
		{
			set
			{
				size=value;
			}
			get
			{
				return size;
			}
		}
		public SizeF SizeRange
		{
			set
			{
				sizerange=value;
			}
			get
			{
				return sizerange;
			}
		}
		public float Angle
		{
			set
			{
				angle=value;
			}
			get
			{
				return angle;
			}
		}
		public float AngleRange
		{
			set
			{
				anglerange=value;
			}
			get
			{
				return anglerange;
			}
		}
		public float Velocity
		{
			set
			{
				velocity=value;
			}
			get
			{
				return velocity;
			}
		}
		public float VelocityRange
		{
			set
			{
				velocityrange=value;
			}
			get
			{
				return velocityrange;
			}
		}
		public float Chaos
		{
			set
			{
				chaos=value;
			}
			get
			{
				return chaos;
			}
		}
		public float Rotation
		{
			set
			{
				rotation=value;
			}
			get
			{
				return rotation;
			}
		}
		public float RotationRange
		{
			set
			{
				rotationrange=value;
			}
			get
			{
				return rotationrange;
			}
		}
		public bool Direction
		{
			set
			{
				direction=value;
			}
			get
			{
				return direction;
			}
		}
		public int Life
		{
			set
			{
				life=value;
			}
			get
			{
				return life;
			}
		}
		public int LifeRange
		{
			set
			{
				liferange=value;
			}
			get
			{
				return liferange;
			}
		}
		public bool OldBack
		{
			set
			{
				oldback=value;
			}
			get
			{
				return oldback;
			}
		}
		public float Gravity
		{
			set
			{
				gravity=value;
			}
			get
			{
				return gravity;
			}
		}
		public float GravityAngle
		{
			set
			{
				gravityangle=value;
			}
			get
			{
				return gravityangle;
			}
		}
		public float Wind
		{
			set
			{
				wind=value;
			}
			get
			{
				return wind;
			}
		}
		public float WindAngle
		{
			set
			{
				windangle=value;
			}
			get
			{
				return windangle;
			}
		}
		public float WindChaos
		{
			set
			{
				windchaos=value;
			}
			get
			{
				return windchaos;
			}
		}
	}
}
