/*
	C# PortIO,
	I had a 5 1/4" floppy disk drive and I'd like to use its stepper motor.
	I searched the net but I didn't find any code to do this in C#. Ultimately I solved my problem, this is my solution:
	Download this: http://www.doc.ic.ac.uk/~ih/doc/par/port95nt/port95nt.exe, this is a good DLL, install it.
	We use its functions to send to and recive from ports.
	In C# you can use this DLL, I saw a simple code in Programming C# book(O'Reilly). You can see it in my code.
	This program is a tester, gets a number and send it to LPT port (0x378).
	
	HTH,
	Hesham Ebrahimi,
	heshamebrahimi@msn.com
	
*/
namespace PortIO_CSharp
{
  using System;
  using System.IO;
  using System.Runtime.InteropServices;
  class PortIO
  {
	// declare the method you wish to P/Invoke
	[DllImport("DLPORTIO.dll", EntryPoint="DlPortWritePortUshort",
		ExactSpelling=false, CharSet=CharSet.Unicode,
		SetLastError=true)]
	static extern void DlPortWritePortUshort(uint Port,ushort Value);
	
	public static void Main( )
	{
		string str;
		
		for(;;)
		{
			str=Console.ReadLine();
			
			if ( str == "q" )
			{
				return;
			}

			ushort value=(ushort)Double.Parse(str);
			
			DlPortWritePortUshort(0x378, value);

			Console.WriteLine("Value: {0}",value);
		}
	}
  }
}