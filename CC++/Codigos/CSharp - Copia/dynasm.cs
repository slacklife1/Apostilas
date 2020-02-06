/*
 *   DynAsm 2
 *   --------
 * 
 *   project start: 27th July 2k2
 * 
 *   Create an assembly dynamically via Reflection Emit techniques...
 * 
 *   by yoda
 * 
 */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace DynAsm
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox tbDaString;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bBuildNow;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
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
			this.tbDaString = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bBuildNow = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbDaString
			// 
			this.tbDaString.Location = new System.Drawing.Point(80, 8);
			this.tbDaString.Name = "tbDaString";
			this.tbDaString.Size = new System.Drawing.Size(136, 20);
			this.tbDaString.TabIndex = 0;
			this.tbDaString.Text = "Lutz";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "My name is:";
			// 
			// bBuildNow
			// 
			this.bBuildNow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bBuildNow.Location = new System.Drawing.Point(8, 40);
			this.bBuildNow.Name = "bBuildNow";
			this.bBuildNow.Size = new System.Drawing.Size(208, 23);
			this.bBuildNow.TabIndex = 2;
			this.bBuildNow.Text = "Build assembly";
			this.bBuildNow.Click += new System.EventHandler(this.bBuildNow_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(224, 73);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.bBuildNow,
																		  this.label1,
																		  this.tbDaString});
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "[ DynAsm ] by yoda";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void bBuildNow_Click(object sender, System.EventArgs e)
		{
			// sth entered ?
			if (tbDaString.Text == "")
			{
				MessageBox.Show("Enter your name !");
				return;
			}
			// gen !
			AsmBuilder ab = new AsmBuilder(tbDaString.Text);
			string error;
			if ( !ab.GenerateNow(out error) )
			{
				MessageBox.Show(error);
				return;
			}
			MessageBox.Show("Output created !\nTest with UrTester.exe...");
		}
	}

	/// <summary>
	/// Class which does the job
	/// </summary>
	public class AsmBuilder
	{
		/// <summary>
		/// Holds the user's name
		/// </summary>
		protected string Name;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="name">User's name</param>
		public AsmBuilder(string name)
		{
			this.Name = name;
		}

		/// <summary>
		/// Main method of this class
		/// </summary>
		/// <param name="errString">Includes an error string in case of a bad result</param>
		/// <returns></returns>
		public bool GenerateNow(out string errString)
		{
			errString = ""; // assign output var

			//
			// use Reflection Emit techniques to build a dynamic assembly
			//

			// create virtual module skeleton
			AssemblyName AsmName = new AssemblyName();
			AsmName.Name = "I_was_generated";
			AssemblyBuilder AsmBuilda = Thread.GetDomain().DefineDynamicAssembly(
				AsmName,
				AssemblyBuilderAccess.Save);
			ModuleBuilder mod = AsmBuilda.DefineDynamicModule("I_was_generated", "I_was_generated.mod");

			//
			// build the class hierarchy :)
			//

			// create DynClass class
			TypeBuilder newClass = mod.DefineType("DynClass", TypeAttributes.Public);
			// create DropName method
			Type[] argTypes = new Type[0];
			Type retType = typeof(void);
			MethodBuilder newMeth = newClass.DefineMethod(
				"DropName",
				MethodAttributes.Public | MethodAttributes.Static,
				retType, argTypes);

			//
			// assemble the IL codes for the DropName method
			//

			// ILDasm says...
			/*
			.method public hidebysig static void  Main() cil managed
			{
			.entrypoint
			// Code size       20 (0x14)
			.maxstack  4
			IL_0000:  ldstr      "Salut Lutz !"
			IL_0005:  ldstr      "I_was_generated.MainClass.Main()"
			IL_000a:  ldc.i4.0
			IL_000b:  ldc.i4.s   64
			IL_000d:  call       valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string,
																																								string,
																																								valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons,
																																								valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
			IL_0012:  pop
			IL_0013:  ret
			} // end of method MainClass::Main
			 */
			ILGenerator ilGen = newMeth.GetILGenerator();
			ilGen.Emit( OpCodes.Ldstr, "Salut " + Name + " !" );
			ilGen.Emit( OpCodes.Ldstr, "I_was_generated.MainClass.Main()" );
			ilGen.Emit( OpCodes.Ldc_I4_0 );
			ilGen.Emit( OpCodes.Ldc_I4_S, 64 );

			// emit the class method call
			Type msgBoxType = typeof(MessageBox);
			Type[] msgBoxArgs = new Type[4];
			msgBoxArgs[0] = typeof(string);
			msgBoxArgs[1] = typeof(string);
			msgBoxArgs[2] = typeof(MessageBoxButtons);
			msgBoxArgs[3] = typeof(MessageBoxIcon);
			MethodInfo msgBoxInfo = msgBoxType.GetMethod("Show", msgBoxArgs);
			ilGen.EmitCall( OpCodes.Call, msgBoxInfo, null);

			ilGen.Emit( OpCodes.Pop );
			ilGen.Emit( OpCodes.Ret );

//			AsmBuilda.SetEntryPoint( newMeth.GetBaseDefinition() );

			//
			// create type
			//
			newClass.CreateType();

			//
			// save 2 disk
			//
			AsmBuilda.Save("I_was_generated.dll");

			return true; // OK
		}
	}
}
