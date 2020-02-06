// Developed 2003 by Gustavo Arranhado (garranhado@hotmail.com)

namespace System.Drawing
{
	using System;
	using System.IO;
	using System.Drawing;
	using System.Collections;
	using System.Windows.Forms;
	using Microsoft.DirectX;
	using Microsoft.DirectX.Direct3D;
	/// <summary>
	/// Summary description for Graphics3D.
	/// </summary>
	public sealed class Graphics3D
	{
		private struct G3DPrimitive
		{
			public VertexBuffer VertexBuffer;
			public IndexBuffer IndexBuffer;
			public int Vertices,Indices;
		}
		private struct G3DMesh
		{
			public Mesh Mesh;
			public Material[] Materials;
			public Texture[] Textures;
		}
		// Use for hierarchy mesh materials
		private class G3DAllocateHierarchy : AllocateHierarchy
		{
			public override void SetUserDataInFrame(Frame frame)
			{
			}
			public override void SetUserDataInMeshContainer(MeshContainer meshcontainer)
			{
				G3DMesh g3dmesh=new G3DMesh();
				ExtendedMaterial[] materials=meshcontainer.GetMaterials();

				if(materials!=null)
				{
					g3dmesh.Materials=new Material[materials.Length];
					g3dmesh.Textures=new Texture[materials.Length];
					for(int i=0;i<materials.Length;i++)
					{
						// Load texture from file or resource
						if(materials[i].TextureFilename!=null)
						{
							Texture texture;
							try
							{
								texture=TextureLoader.FromFile(meshcontainer.MeshData.Mesh.Device,materials[i].TextureFilename);
							}
							catch
							{
								try
								{
									texture=TextureLoader.FromStream(meshcontainer.MeshData.Mesh.Device,System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(materials[i].TextureFilename));
								}
								catch
								{
									texture=null;
								}
							}
							g3dmesh.Textures[i]=texture;
						}

						// Load material
						g3dmesh.Materials[i]=materials[i].Material3D;
						g3dmesh.Materials[i].Ambient=g3dmesh.Materials[i].Diffuse;
					}
				}

				g3dmesh.Mesh=meshcontainer.MeshData.Mesh;
				meshcontainer.UserData=g3dmesh;
			}
		}
		private struct G3DHierarchyMesh
		{
			public AnimationRootFrame RootFrame;
			public G3DAllocateHierarchy AllocateHierarchy;
		}
		private struct G3DPointSprites
		{
			public VertexBuffer VertexBuffer;
			public int Vertices;
		}
		private Device device;
		private G3DPrimitive deviceprimitive;
		private G3DMesh devicemesh;
		private G3DHierarchyMesh devicehierarchymesh;
		private G3DPointSprites devicepointsprites;
		private Microsoft.DirectX.Direct3D.Font devicefont;
		private Matrix devicematrix;
		private Texture devicetexture;
		private Sprite devicesprite;
		private SortedList texturelist,materiallist,primitivelist,meshlist,hierarchymeshlist,pointspriteslist;

		public Graphics3D(Control control,int width,int height,bool multisample)
		{
			PresentParameters presentparams;
			presentparams=new PresentParameters();

			presentparams.Windowed=false;
			presentparams.EnableAutoDepthStencil=true;
			presentparams.AutoDepthStencilFormat=DepthFormat.D16;

			// FullScreen Mode
			if(multisample)
				presentparams.SwapEffect=SwapEffect.Discard;
			else
				presentparams.SwapEffect=SwapEffect.Flip;
			presentparams.BackBufferFormat=Manager.Adapters.Default.CurrentDisplayMode.Format;
			presentparams.BackBufferWidth=width;
			presentparams.BackBufferHeight=height;
			presentparams.FullScreenRefreshRateInHz=PresentParameters.DefaultPresentRate;
			presentparams.PresentationInterval=PresentInterval.One;
			
			// Anti-Aliasing
			if(multisample)
			{
				presentparams.MultiSample=MultiSampleType.NonMaskable;
				presentparams.MultiSampleQuality=1;
			}

			// Create Direct3D device
			try
			{
				try
				{
					device=new Device(0,DeviceType.Hardware,control,CreateFlags.HardwareVertexProcessing,presentparams);
				}
				catch
				{
					device=new Device(0,DeviceType.Hardware,control,CreateFlags.SoftwareVertexProcessing,presentparams);
				}
			}
			catch
			{
				try
				{
					device=new Device(0,DeviceType.Software,control,CreateFlags.SoftwareVertexProcessing,presentparams);
				}
				catch
				{
					device=new Device(0,DeviceType.Reference,control,CreateFlags.SoftwareVertexProcessing,presentparams);
				}
			}

			// Create lists
			texturelist=new SortedList();
			materiallist=new SortedList();
			primitivelist=new SortedList();
			meshlist=new SortedList();
			hierarchymeshlist=new SortedList();
			pointspriteslist=new SortedList();
		}
		public Graphics3D(Control control,bool fullscreen,bool multisample)
		{
			PresentParameters presentparams;
			presentparams=new PresentParameters();

			presentparams.Windowed=!fullscreen;
			presentparams.EnableAutoDepthStencil=true;
			presentparams.AutoDepthStencilFormat=DepthFormat.D16;

			if(!fullscreen)
			{
				// Windowed Mode
				if(multisample)
					presentparams.SwapEffect=SwapEffect.Discard;
				else
					presentparams.SwapEffect=SwapEffect.Copy;
			}
			else
			{
				// FullScreen Mode
				if(multisample)
					presentparams.SwapEffect=SwapEffect.Discard;
				else
					presentparams.SwapEffect=SwapEffect.Flip;
				presentparams.BackBufferFormat=Manager.Adapters.Default.CurrentDisplayMode.Format;
				presentparams.BackBufferWidth=Manager.Adapters.Default.CurrentDisplayMode.Width;
				presentparams.BackBufferHeight=Manager.Adapters.Default.CurrentDisplayMode.Height;
				presentparams.FullScreenRefreshRateInHz=Manager.Adapters.Default.CurrentDisplayMode.RefreshRate;
				presentparams.PresentationInterval=PresentInterval.One;
			}

			// Anti-Aliasing
			if(multisample)
			{
				presentparams.MultiSample=MultiSampleType.NonMaskable;
				presentparams.MultiSampleQuality=1;
			}

			// Create Direct3D device
			try
			{
				try
				{
					device=new Device(0,DeviceType.Hardware,control,CreateFlags.HardwareVertexProcessing,presentparams);
				}
				catch
				{
					device=new Device(0,DeviceType.Hardware,control,CreateFlags.SoftwareVertexProcessing,presentparams);
				}
			}
			catch
			{
				try
				{
					device=new Device(0,DeviceType.Software,control,CreateFlags.SoftwareVertexProcessing,presentparams);
				}
				catch
				{
					device=new Device(0,DeviceType.Reference,control,CreateFlags.SoftwareVertexProcessing,presentparams);
				}
			}

			// Create lists
			texturelist=new SortedList();
			materiallist=new SortedList();
			primitivelist=new SortedList();
			meshlist=new SortedList();
			hierarchymeshlist=new SortedList();
			pointspriteslist=new SortedList();
		}

		public void MakeTexture(string name,string filename)
		{
			// Load texture from file or resource
			Texture texture;
			try
			{
				texture=TextureLoader.FromFile(device,filename);
			}
			catch
			{
				texture=TextureLoader.FromStream(device,System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(filename));
			}
			// Add to list
			texturelist.Add(name,texture);
		}
		public void MakeTexture(string name,Bitmap bitmap)
		{
			// Load texture from bitmap
			texturelist.Add(name,(Texture)Microsoft.DirectX.Direct3D.Texture.FromBitmap(device,bitmap,Usage.SoftwareProcessing,Pool.Managed));
		}
		public void MakeMaterial(string name,Color ambient,Color diffuse,Color emissive,Color specular,float specularsharpness)
		{
			// Create material
			Material material=new Material();
			material.Ambient=ambient;
			material.Diffuse=diffuse;
			material.Emissive=emissive;
			material.Specular=specular;
			material.SpecularSharpness=specularsharpness;
			
			// Add to list
			materiallist.Add(name,material);
		}
		public void MakePrimitive(string name,CustomVertex.PositionNormalTextured[] vertices,int[] indices)
		{
			// Create Primitive
			G3DPrimitive g3dprimitive=new G3DPrimitive();

			g3dprimitive.Vertices=vertices.Length;
			g3dprimitive.Indices=indices.Length/3;

			// Vertices
			g3dprimitive.VertexBuffer=new VertexBuffer(vertices[0].GetType(),vertices.Length,device,Usage.WriteOnly,CustomVertex.PositionNormalTextured.Format,Pool.Default);
			g3dprimitive.VertexBuffer.SetData(vertices,0,LockFlags.None);

			//Indices
			g3dprimitive.IndexBuffer=new IndexBuffer(indices[0].GetType(),indices.Length,device,Usage.WriteOnly,Pool.Default);
			g3dprimitive.IndexBuffer.SetData(indices,0,LockFlags.None);

			// Add to list
			primitivelist.Add(name,g3dprimitive);
		}
		public void MakeMesh(string name,string filename,bool computenormals)
		{
			G3DMesh g3dmesh=new G3DMesh();
			ExtendedMaterial[] meshmaterials=null;

			// Load Mesh and materials
			try
			{
				g3dmesh.Mesh=Microsoft.DirectX.Direct3D.Mesh.FromFile(filename,MeshFlags.SystemMemory,device,out meshmaterials);
			}
			catch
			{
				g3dmesh.Mesh=Microsoft.DirectX.Direct3D.Mesh.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(filename),MeshFlags.SystemMemory,device,out meshmaterials);
			}

			// Generate normals
			if(computenormals)
			{
				Mesh temp=g3dmesh.Mesh.Clone(MeshFlags.SystemMemory,(VertexFormats)(g3dmesh.Mesh.VertexFormat|VertexFormats.Normal),device);
				temp.ComputeNormals();
				g3dmesh.Mesh.Dispose();
				g3dmesh.Mesh=temp;
			}

			if(meshmaterials!=null)
			{
				g3dmesh.Materials=new Material[meshmaterials.Length];
				g3dmesh.Textures=new Texture[meshmaterials.Length];
				for(int i=0;i<meshmaterials.Length;i++)
				{
					if(meshmaterials[i].TextureFilename!=null)
					{
						// Load texture from file or resource
						Texture texture;
						try
						{
							texture=TextureLoader.FromFile(device,meshmaterials[i].TextureFilename);
						}
						catch
						{
							try
							{
								texture=TextureLoader.FromStream(device,System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(meshmaterials[i].TextureFilename));
							}
							catch
							{
								texture=null;
							}
						}
						g3dmesh.Textures[i]=texture;
					}

					// Load material
					g3dmesh.Materials[i]=meshmaterials[i].Material3D;
					g3dmesh.Materials[i].Ambient=g3dmesh.Materials[i].Diffuse;
				}
			}

			// Add to list
			meshlist.Add(name,g3dmesh);
		}
		public void MakeMesh(string name,string filename)
		{
			MakeMesh(name,filename,false);
		}
		public void MakeHierarchyMesh(string name,string filename)
		{
			G3DHierarchyMesh g3dhierarchymesh=new G3DHierarchyMesh();
			g3dhierarchymesh.AllocateHierarchy=new G3DAllocateHierarchy();

			// Load hierarchy mesh and materials
			try
			{
				g3dhierarchymesh.RootFrame=Microsoft.DirectX.Direct3D.Mesh.LoadHierarchyFromFile(filename,MeshFlags.SystemMemory,device,g3dhierarchymesh.AllocateHierarchy,null);
			}
			catch
			{
				g3dhierarchymesh.RootFrame=Microsoft.DirectX.Direct3D.Mesh.LoadHierarchy(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(filename),MeshFlags.SystemMemory,device,g3dhierarchymesh.AllocateHierarchy,null);
			}

			// Add to list
			hierarchymeshlist.Add(name,g3dhierarchymesh);
		}
		public void MakePointSprites(string name,CustomVertex.PositionColored[] vertices)
		{
			G3DPointSprites g3dpointsprites=new G3DPointSprites();

			g3dpointsprites.Vertices=vertices.Length;

			// Vertices/Points
			g3dpointsprites.VertexBuffer=new VertexBuffer(vertices[0].GetType(),vertices.Length,device,Usage.WriteOnly,CustomVertex.PositionColored.Format,Pool.Default);
			g3dpointsprites.VertexBuffer.SetData(vertices,0,LockFlags.None);

			// Add to list
			pointspriteslist.Add(name,g3dpointsprites);
		}
		public void MakeDirectionalLight(int index,bool onoff,float dx,float dy,float dz,Color ambient,Color diffuse,Color specular)
		{
			// Set Directional Light
			device.Lights[index].Enabled=onoff;
			device.Lights[index].Type=LightType.Directional;
			device.Lights[index].Direction=new Vector3(dx,dy,dz);
			device.Lights[index].Ambient=ambient;
			device.Lights[index].Diffuse=diffuse;
			device.Lights[index].Specular=specular;
			device.Lights[index].Commit();
		}
		public void MakePointLight(int index,bool onoff,float px,float py,float pz,Color ambient,Color diffuse,Color specular,float att0,float att1,float att2,float range)
		{
			// Set Point Light
			device.Lights[index].Enabled=onoff;
			device.Lights[index].Type=LightType.Point;
			device.Lights[index].Position=new Vector3(px,py,pz);
			device.Lights[index].Ambient=ambient;
			device.Lights[index].Diffuse=diffuse;
			device.Lights[index].Specular=specular;
			device.Lights[index].Attenuation0=att0;
			device.Lights[index].Attenuation1=att1;
			device.Lights[index].Attenuation2=att2;
			device.Lights[index].Range=range;
			device.Lights[index].Commit();
		}
		public void MakeSpotLight(int index,bool onoff,float px,float py,float pz,float dx,float dy,float dz,Color ambient,Color diffuse,Color specular,float att0,float att1,float att2,float range,float inner,float outer,float falloff)
		{
			// Set Spot Light
			device.Lights[index].Enabled=onoff;
			device.Lights[index].Type=LightType.Spot;
			device.Lights[index].Position=new Vector3(px,py,pz);
			device.Lights[index].Direction=new Vector3(dx,dy,dz);
			device.Lights[index].Ambient=ambient;
			device.Lights[index].Diffuse=diffuse;
			device.Lights[index].Specular=specular;
			device.Lights[index].Attenuation0=att0;
			device.Lights[index].Attenuation1=att1;
			device.Lights[index].Attenuation2=att2;
			device.Lights[index].Range=range;
			device.Lights[index].InnerConeAngle=inner;
			device.Lights[index].OuterConeAngle=outer;
			device.Lights[index].Falloff=falloff;
			device.Lights[index].Commit();
		}
		public void MakeFog(bool onoff,Color color,float density,float start,float end,bool exp)
		{
			// Set Fog
			device.RenderState.FogEnable=onoff;
			device.RenderState.FogColor=color;
			device.RenderState.FogDensity=density;
			device.RenderState.FogStart=start;
			device.RenderState.FogEnd=end;
			if(exp)
				device.RenderState.FogTableMode=FogMode.Exp;
			else
				device.RenderState.FogTableMode=FogMode.Linear;
		}
		public void Viewport(Rectangle viewport)
		{
			// Set Viewport
			Viewport vp=new Viewport();
			vp.X=viewport.X;
			vp.Y=viewport.Y;
			vp.Width=viewport.Width;
			vp.Height=viewport.Height;
			vp.MinZ=0f;
			vp.MaxZ=1f;
			device.Viewport=vp;
		}
		public void SceneBegin(Color color,float depth)
		{
			// Clear color and depth buffers
			device.Clear(ClearFlags.Target|ClearFlags.ZBuffer,color,depth,0);
			device.BeginScene();
			// Setup options
			device.RenderState.NormalizeNormals=true;
			device.RenderState.SourceBlend=Blend.SourceAlpha;
			device.RenderState.DestinationBlend=Blend.InvSourceAlpha;
			device.RenderState.ShadeMode=ShadeMode.Gouraud;
			device.SamplerState[0].MinFilter=device.SamplerState[0].MagFilter=TextureFilter.Linear;
			device.RenderState.AlphaBlendEnable=true;
		}
		public void RenderOptions(bool wireframe,bool backface,bool blend)
		{
			// RenderOptions
			if(wireframe)
				device.RenderState.FillMode=FillMode.WireFrame;
			else
				device.RenderState.FillMode=FillMode.Solid;
			if(backface)
				device.RenderState.CullMode=Cull.None;
			else
				device.RenderState.CullMode=Cull.CounterClockwise;
			device.RenderState.AlphaBlendEnable=blend;
		}
		public void Matte(bool ztest,bool zwrite)
		{
			// Matte
			device.RenderState.ZBufferEnable=ztest;
			device.RenderState.ZBufferWriteEnable=zwrite;
		}
		public void Texture(string name)
		{
			// Set texture from list
			if(name==null)
				device.SetTexture(0,null);
			else
				device.SetTexture(0,(Texture)texturelist[name]);
		}
		public void TextureOptions(Matrix matrix,bool filter)
		{
			// TextureOptions
			device.Transform.Texture0=matrix;
			if(filter)
				device.SamplerState[0].MinFilter=device.SamplerState[0].MagFilter=TextureFilter.Linear;
			else
				device.SamplerState[0].MinFilter=device.SamplerState[0].MagFilter=TextureFilter.None;
		}
		public void TextureOptions(Matrix matrix,bool filter,TextureAddress textureaddress)
		{
			// TextureOptions
			device.Transform.Texture0=matrix;
			if(filter)
				device.SamplerState[0].MinFilter=device.SamplerState[0].MagFilter=TextureFilter.Linear;
			else
				device.SamplerState[0].MinFilter=device.SamplerState[0].MagFilter=TextureFilter.None;
			device.SamplerState[0].AddressU=textureaddress;
			device.SamplerState[0].AddressV=textureaddress;
		}
		public void Material(string name)
		{
			// Set texture from list
			if(name==null)
				device.Material=new Material();
			else
				device.Material=((Material)materiallist[name]);
		}
		public void LightOptions(bool onoff,Color ambient)
		{
			// LightOptions
			device.RenderState.Lighting=onoff;
			device.RenderState.SpecularEnable=onoff;
			device.RenderState.Ambient=ambient;
		}
		public void Projection(Matrix matrix)
		{
			// Set projection matrix
			device.Transform.Projection=matrix;
		}
		public void Projection(float fov,float aspect,float near,float far)
		{
			// Set projection matrix
			device.Transform.Projection=Matrix.PerspectiveFovLH(fov,aspect,near,far);
		}
		public void View(Matrix matrix)
		{
			// Set view matrix
			device.Transform.View=matrix;
		}
		public void View(float px,float py,float pz,float tx,float ty,float tz,float ux,float uy,float uz)
		{
			// Set view matrix
			device.Transform.View=Matrix.LookAtLH(new Vector3(px,py,pz),new Vector3(tx,ty,tz),new Vector3(ux,uy,uz));
		}
		public void World(Matrix matrix)
		{
			// Set world matrix
			device.Transform.World=devicematrix=matrix;
		}
		public void World(float px,float py,float pz,float rx,float ry,float rz,float sx,float sy,float sz)
		{
			// Set world matrix
			device.Transform.World=devicematrix=Matrix.Scaling(sx,sy,sz)*Matrix.RotationZ(rz)*Matrix.RotationY(ry)*Matrix.RotationX(rx)*Matrix.Translation(px,py,pz);
		}
		public void PrimitiveBegin(string name)
		{
			// Set primitive
			if(name==null)
				devicemesh=new G3DMesh();
			else
				deviceprimitive=((G3DPrimitive)primitivelist[name]);
		}
		public void DrawPrimitive()
		{
			// Draw primitive
			device.VertexFormat=CustomVertex.PositionNormalTextured.Format;
			device.SetStreamSource(0,deviceprimitive.VertexBuffer,0);
			device.Indices=deviceprimitive.IndexBuffer;
			device.DrawIndexedPrimitives(PrimitiveType.TriangleList,0,0,deviceprimitive.Vertices,0,deviceprimitive.Indices);
		}
		public void PrimitiveEnd()
		{
			devicemesh=new G3DMesh();
		}
		public void MeshBegin(string name)
		{
			// Set mesh
			if(name==null)
				devicemesh=new G3DMesh();
			else
				devicemesh=((G3DMesh)meshlist[name]);
		}
		public void Texture(int id)
		{
			// Set texture from mesh
			device.SetTexture(0,devicemesh.Textures[id]);
		}
		public void Material(int id)
		{
			// Set texture from mesh
			device.Material=devicemesh.Materials[id];
		}
		public void DrawMesh(int id)
		{
			// Draw mesh
			devicemesh.Mesh.DrawSubset(id);
		}
		public void DrawMesh()
		{
			// Draw mesh
			for(int i=0;i<devicemesh.Materials.Length;i++)
			{
				Texture(i);
				Material(i);
				DrawMesh(i);
			}
		}
		public bool IntersectMesh(float ox,float oy,float oz,float dx,float dy,float dz,ref IntersectInformation closesthit)
		{
			return devicemesh.Mesh.Intersect(new Vector3(ox,oy,oz),new Vector3(dx,dy,dz),ref closesthit);
		}
		public bool IntersectMesh(int id,float ox,float oy,float oz,float dx,float dy,float dz,ref IntersectInformation closesthit)
		{
			return devicemesh.Mesh.IntersectSubset(id,new Vector3(ox,oy,oz),new Vector3(dx,dy,dz),ref closesthit);
		}
		public Mesh GetMesh()
		{
			return devicemesh.Mesh;
		}
		public void MeshEnd()
		{
			devicemesh=new G3DMesh();
		}
		public void HierarchyMeshBegin(string name)
		{
			// Set hierarchy mesh
			if(name==null)
				devicehierarchymesh=new G3DHierarchyMesh();
			else
				devicehierarchymesh=((G3DHierarchyMesh)hierarchymeshlist[name]);
		}
		public void AnimateHierarchyMesh(bool onoff,int track,int animationset,float time)
		{
			// Animate hierarchy mesh
			AnimationController animationcontroller=devicehierarchymesh.RootFrame.AnimationController;
			
			animationcontroller.Time=0f; 
			animationcontroller.SetTrackEnable(track,onoff);
			animationcontroller.SetTrackAnimationSet(track,animationcontroller.GetAnimationSet(animationset));
			animationcontroller.SetTrackAnimationTime(track,time);
		}
		public void DrawHierarchyMesh(Frame frame)
		{
			// Draw hierarchy mesh
			Frame oldframe=frame;

			MatrixStack matrixstack=new MatrixStack();
			matrixstack.Push();
				matrixstack.LoadMatrix(devicematrix);
				matrixstack.MultiplyMatrixLocal(frame.TransformationMatrix);
				if(frame.MeshContainer!=null)
				{
					device.Transform.World=matrixstack.Top;
					G3DMesh d3dmesh=(G3DMesh)frame.MeshContainer.UserData;
					for(int i=0;i<d3dmesh.Materials.Length;i++)
					{
						if(d3dmesh.Textures!=null) 
							device.SetTexture(0,d3dmesh.Textures[i]);
						device.Material=d3dmesh.Materials[i];
						d3dmesh.Mesh.DrawSubset(i);
					}
				}

				if(frame.FrameFirstChild!=null)
					DrawHierarchyMesh(frame.FrameFirstChild);
			matrixstack.Pop();

			frame=oldframe;
			if(frame.FrameSibling!=null)
				DrawHierarchyMesh(frame.FrameSibling);
		}
		public void DrawHierarchyMesh(string name)
		{
			// Draw hierarchy mesh
			DrawHierarchyMesh(Frame.Find(devicehierarchymesh.RootFrame.FrameHierarchy,name));
		}
		public void DrawHierarchyMesh()
		{
			// Draw hierarchy mesh
			DrawHierarchyMesh(devicehierarchymesh.RootFrame.FrameHierarchy);
		}
		public bool IntersectFrame(Frame frame,float ox,float oy,float oz,float dx,float dy,float dz)
		{
			Vector3 center;
			float radius=GetBoundingSphere(frame,out center);
			return Geometry.SphereBoundProbe(center,radius,new Vector3(ox,oy,oz),new Vector3(dx,dy,dz));
		}
		public bool IntersectFrame(float ox,float oy,float oz,float dx,float dy,float dz)
		{
			return IntersectFrame(devicehierarchymesh.RootFrame.FrameHierarchy,ox,oy,oz,dx,dy,dz);
		}
		public AnimationController GetAnimation()
		{
			return devicehierarchymesh.RootFrame.AnimationController;
		}
		public Frame GetFrame(string name)
		{
			return Frame.Find(devicehierarchymesh.RootFrame.FrameHierarchy,name);
		}
		public Frame GetFrame()
		{
			return devicehierarchymesh.RootFrame.FrameHierarchy;
		}
		public float GetBoundingSphere(Frame frame,out Vector3 center)
		{
			return Frame.CalculateBoundingSphere(frame,out center);
		}
		public float GetBoundingSphere(out Vector3 center)
		{
			return GetBoundingSphere(devicehierarchymesh.RootFrame.FrameHierarchy,out center);
		}
		public void HierarchyMeshEnd()
		{
			devicehierarchymesh=new G3DHierarchyMesh();
		}
		public void PointSpritesBegin(string name)
		{
			// Set pointsprites
			if(name==null)
				devicepointsprites=new G3DPointSprites();
			else
				devicepointsprites=((G3DPointSprites)pointspriteslist[name]);
		}
		public void DrawPointSprites(float size,float sizemin,float sizemax,bool billboard)
		{
			// Draw pointsprites
			device.RenderState.PointSpriteEnable=true;
			device.RenderState.PointSize=size;
			device.RenderState.PointSizeMin=sizemin;
			device.RenderState.PointSizeMax=sizemax;
			if(!billboard)
			{
				device.RenderState.SourceBlend=Blend.One;
				device.RenderState.DestinationBlend=Blend.One;
			}
			device.VertexFormat=CustomVertex.PositionColored.Format;
			device.SetStreamSource(0,devicepointsprites.VertexBuffer,0);
			device.DrawPrimitives(PrimitiveType.PointList,0,devicepointsprites.Vertices);
			device.RenderState.SourceBlend=Blend.SourceAlpha;
			device.RenderState.DestinationBlend=Blend.InvSourceAlpha;
			device.RenderState.PointSpriteEnable=false;
		}
		public void DrawPointSprites(float size,float sizemin,float sizemax,float a,float b,float c,bool billboard)
		{
			// Draw pointsprites
			device.RenderState.PointSpriteEnable=true;
			device.RenderState.PointSize=size;
			device.RenderState.PointSizeMin=sizemin;
			device.RenderState.PointSizeMax=sizemax;
			device.RenderState.PointScaleEnable=true;
			device.RenderState.PointScaleA=a;
			device.RenderState.PointScaleB=b;
			device.RenderState.PointScaleC=c;
			if(!billboard)
			{
				device.RenderState.SourceBlend=Blend.One;
				device.RenderState.DestinationBlend=Blend.One;
			}
			device.VertexFormat=CustomVertex.PositionColored.Format;
			device.SetStreamSource(0,devicepointsprites.VertexBuffer,0);
			device.DrawPrimitives(PrimitiveType.PointList,0,devicepointsprites.Vertices);
			device.RenderState.SourceBlend=Blend.SourceAlpha;
			device.RenderState.DestinationBlend=Blend.InvSourceAlpha;
			device.RenderState.PointSpriteEnable=false;
			device.RenderState.PointScaleEnable=false;
		}
		public void PointSpritesEnd()
		{
			devicepointsprites=new G3DPointSprites();
		}
		public void FontBegin(System.Drawing.Font font)
		{
			// Set font
			devicefont=new Microsoft.DirectX.Direct3D.Font(device,font);
			devicefont.Begin();
		}
		public void DrawText(string text,int x,int y,Color color)
		{
			// Draw text
			devicefont.DrawText(text,new Rectangle(x,y,0,0),DrawTextFormat.None,color);
		}
		public void FontEnd()
		{
			devicefont.End();
		}
		public void SpriteBegin(string name)
		{
			// Set sprite and texture
			devicesprite=new Sprite(device);
			devicesprite.Begin();
			devicetexture=(Texture)texturelist[name];
		}
		public void DrawSprite(Rectangle src,float sx,float sy,float rcx,float rcy,float r,float px,float py,Color color)
		{
			// Draw sprite
			devicesprite.Draw(devicetexture,src,new Vector2(sx,sy),new Vector2(rcx,rcy),r,new Vector2(px,py),color);
		}
		public void SpriteEnd()
		{
			devicesprite.End();
		}
		public void SceneEnd()
		{
			device.EndScene();
			device.Present();
		}
		public void ClearTextures()
		{
			texturelist=new SortedList();
		}
		public void ClearMaterials()
		{
			materiallist=new SortedList();
		}
		public void ClearPrimitives()
		{
			primitivelist=new SortedList();
		}
		public void ClearMeshs()
		{
			meshlist=new SortedList();
		}
		public void ClearHierarchyMeshs()
		{
			hierarchymeshlist=new SortedList();
		}
		public void ClearPointSprites()
		{
			pointspriteslist=new SortedList();
		}
		public void ClearLights()
		{
			device.Lights.Reset();
		}

		public Device Device
		{
			get
			{
				return device;
			}
			set
			{
				device=value;
			}
		}
	}
}
