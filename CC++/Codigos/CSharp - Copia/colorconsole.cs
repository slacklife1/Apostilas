/* Color Console Class v0.89
 *		www.cshrp.net 
 * Created: 2003-05-20 (Patrik.Lowendahl@csharpsweden.com)
 * Description: This class uses Interop to extend the console in .NET
 *				Read 'readme.txt' for the docs.
 */

using System;
using System.Runtime.InteropServices;

namespace Cshrp.Examples.Interop.Console
{	
	public class ColorConsole
	{
		#region Interop stuff
		private const byte EMPTY = 32;
		
		// To alloc and dealloc the console handle.
		// returns 0 if already allocated.
		// Don't forget to free console
		[DllImport("kernel32.dll",EntryPoint="AllocConsole")]
		private static extern int AllocConsole();
	
		[DllImport("kernel32.dll",EntryPoint="FreeConsole")]
		private static extern int FreeConsole();
		// -->
		
		// Gets the handle for standard input and output
		// streams of the console.
		private const int STD_INPUT_HANDLE = -10;
		private const int STD_OUTPUT_HANDLE = -11;
		[DllImport("kernel32", EntryPoint="GetStdHandle")]
		private static extern int GetStdHandle(int nStdHandle);

		//Writes to the console
		[DllImport("kernel32", EntryPoint="WriteConsoleW")]
		private static extern long WriteConsole(int hConsoleOutput , 
											IntPtr lpBuffer, 
											int nNumberOfCharsToWrite, 
											out int lpNumberOfCharsWritten, 
											IntPtr lpNull); 
									

		private const int ENABLE_PROCESSED_INPUT = 0x1;
		private const int ENABLE_LINE_INPUT = 0x2;
		private const int ENABLE_ECHO_INPUT = 0x4;
		private const int ENABLE_WINDOW_INPUT = 0x8;
		private const int ENABLE_MOUSE_INPUT = 0x10;
		
		[DllImport("kernel32", EntryPoint="SetConsoleMode")]
		private static extern int SetConsoleMode(int hConsoleHandle,int dwMode);

		// Enumeration to hold the console colors
		private const Int16 FOREGROUND_BLUE =      0x0001; // text color contains blue.
		private const Int16 FOREGROUND_GREEN =    0x0002; // text color contains green.
		private const Int16 FOREGROUND_RED =      0x0004; // text color contains red.
		private const Int16 FOREGROUND_INTENSITY = 0x0008; // text color is intensified.
		private const Int16 BACKGROUND_BLUE =      0x0010; // background color contains blue.
		private const Int16 BACKGROUND_GREEN =    0x0020; // background color contains green.
		private const Int16 BACKGROUND_RED =      0x0040; // background color contains red.
		private const Int16 BACKGROUND_INTENSITY = 0x0080; // background color is intensified.
		
		public enum  ConsoleColor 
		{
						Black = 0x0,
						Blue = 0x1,
						Green = 0x2,
						Aqua = Blue | Green,
						Red = 0x4,
						Purple = Blue | Red,
						Yellow = Green | Red,
						White = Green | Red | Blue,
						Gray = 0x8,
						LightBlue = Gray | Blue,
						LightGreen = Gray | Green,
						LightAqua = Gray | Aqua,
						LightRed = Gray | Red,
						LightPurple = Gray | Purple,
						LightYellow = Gray | Yellow,
						BrightWhite = Gray | White }

		// Used to set console colors.
		[DllImport("kernel32", EntryPoint="SetConsoleTextAttribute")]
		private static extern int SetConsoleTextAttribute(int hConsoleOutput, 
													Int16 wScreenColors);
		[StructLayoutAttribute(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
		private struct COORD 
		{
			public Int16 x;
			public Int16 y;
		}
		
		[StructLayoutAttribute(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
		private struct CONSOLE_CURSOR_INFO 
		{
			public int dwSize;  
			public bool bVisible;
		}
		
		
		[StructLayoutAttribute(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
		private struct SMALL_RECT 
		{
			public Int16 Left;
			public Int16 Top;
			public Int16 Right;
			public Int16 Bottom;
		}

		[StructLayoutAttribute(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
		private struct CONSOLE_SCREEN_BUFFER_INFO 
		{
			public COORD Size;
			public COORD CursorPosition;
			public Int16 ScreenColors;
			public SMALL_RECT Window;
			public COORD MaximumWindowSize;
		}		

		[DllImport("kernel32", EntryPoint="GetConsoleScreenBufferInfo")]
		private static extern int GetConsoleScreenBufferInfo(int hConsoleOutput,
														ref CONSOLE_SCREEN_BUFFER_INFO lpConsoleScreenBufferInfo);
		
		[DllImport("kernel32.dll", EntryPoint="FillConsoleOutputCharacter", SetLastError=true, CharSet=CharSet.Auto, CallingConvention=CallingConvention.StdCall)]
		private static extern int FillConsoleOutputCharacter(int hConsoleOutput, byte cCharacter, int nLength, COORD dwWriteCoord, ref int lpNumberOfCharsWritten);
		
		[DllImport("kernel32", EntryPoint="SetConsoleCursorInfo")]
		private static extern int SetConsoleCursorInfo(
								int hConsoleOutput,
								ref CONSOLE_CURSOR_INFO lpConsoleCursorInfo);

		[DllImport("kernel32", EntryPoint="SetConsoleCursorInfo")]
		private static extern int GetConsoleCursorInfo(
									int hConsoleOutput,
									out IntPtr lpConsoleCursorInfo
									 );
		
		[DllImport("kernel32.dll", EntryPoint="FillConsoleOutputAttribute", SetLastError=true, CharSet=CharSet.Auto, CallingConvention=CallingConvention.StdCall)]
		private static extern int FillConsoleOutputAttribute(
			int hConsoleOutput,
			Int16 wAttribute,
			int nLength,
			COORD dwWriteCoord,
			ref int lpNumberOfAttrsWritten
			);

		//set the console cursor position
		[DllImport("kernel32", EntryPoint="SetConsoleCursorPosition")]
		private static extern int SetConsoleCursorPosition(int hConsoleOutput,
													COORD dwCursorPosition);

		
		// get and set the console title
		[DllImport("kernel32", EntryPoint="SetConsoleTitleA")]
		private static extern int SetConsoleTitle([MarshalAs(UnmanagedType.LPStr)] string lpConsoleTitle);
		
		[DllImport("kernel32", EntryPoint="GetConsoleTitleA")]
		private static extern int GetConsoleTitle(out string lpConsoleTitle, int nSize);
  											
		#endregion
				
		private static Int16 OldConsoleColors;		// used to store the original console colors
		private static bool DidAllocate;			// True if AllocConsole returned non zero
		private static int hConsoleOut;				// handle to the output stream
		private static bool Disposed;				// Tells if we released the resources.
		
		static ColorConsole()
		{
			Allocate();
		}
	
		private static void Allocate()
		{
			//allocate a console. If the call suceeds, DidAllocate will be True.
			//This is used to decide if we need to free the console.
			DidAllocate = (AllocConsole()!=0?true:false);
   
			//get the StdIn and hConsoleOut handles
			hConsoleOut = GetStdHandle(STD_OUTPUT_HANDLE);
			
			// set the console mode
			SetConsoleMode(hConsoleOut, ENABLE_WINDOW_INPUT | ENABLE_PROCESSED_INPUT);
      
			//store the original console colors and set a flag to restore them on exit
			OldConsoleColors = GetConsoleOutColors();
   
			//make sure the ExitRequested flag is reset and the Disposed flag is reset
			//modConsole.ExitRequested = false;
			Disposed = false;   
			Backcolor = ColorConsole.ConsoleColor.Black;
			Forecolor = ColorConsole.ConsoleColor.White;
		}

		private static Int16 GetConsoleOutColors() 
		{			
			// Information about the struct.						
			CONSOLE_SCREEN_BUFFER_INFO csbi = new CONSOLE_SCREEN_BUFFER_INFO();
			GetConsoleScreenBufferInfo(hConsoleOut, ref csbi);
						
			return csbi.ScreenColors;
		}
	
		
		#region Properties
		
		private static bool _cv = true;
		public static bool CursorVisible
		{
			set 
			{
				CONSOLE_CURSOR_INFO cci = new CONSOLE_CURSOR_INFO();
				_cv = value;
				
				cci.bVisible = _cv;
				cci.dwSize = _cw;
			
				SetConsoleCursorInfo(hConsoleOut,ref cci);
			}
			get
			{
				return _cv;
			}
		}
		
		private static int _cw = 10;
		public static int CursorWeight
		{
			set 
			{
				if(value<0 || value >100)
					throw new ArgumentOutOfRangeException("CursorWeight", value, "Only values between 0 and 100 is allowed");
				
				CONSOLE_CURSOR_INFO cci = new CONSOLE_CURSOR_INFO();
				
				_cw = value;
				cci.bVisible = _cv;
				cci.dwSize = _cw;
			
				SetConsoleCursorInfo(hConsoleOut,ref cci);
			}
			get
			{
				return _cw;
			}
		}

		
		public static Int16 X
		{
			set 
			{
				CONSOLE_SCREEN_BUFFER_INFO csbi = new CONSOLE_SCREEN_BUFFER_INFO();
				csbi.CursorPosition.x = value;
				csbi.CursorPosition.y = Y;

				SetConsoleCursorPosition(hConsoleOut, csbi.CursorPosition);
			}
			get
			{
				
				CONSOLE_SCREEN_BUFFER_INFO current = new CONSOLE_SCREEN_BUFFER_INFO();
				GetConsoleScreenBufferInfo(hConsoleOut, ref current);
				
				return current.CursorPosition.x;
			}
		}

		public static Int16 Y
		{
			set 
			{
				CONSOLE_SCREEN_BUFFER_INFO csbi = new CONSOLE_SCREEN_BUFFER_INFO();
				
				
				csbi.CursorPosition.x = X;
				csbi.CursorPosition.y = value;

				SetConsoleCursorPosition(hConsoleOut, csbi.CursorPosition);
			}
		
			get
			{
				CONSOLE_SCREEN_BUFFER_INFO current = new CONSOLE_SCREEN_BUFFER_INFO();
				GetConsoleScreenBufferInfo(hConsoleOut, ref current);
				
				return current.CursorPosition.y;
			}
		}
		
		public static ColorConsole.ConsoleColor Forecolor
		{
			set 
			{
				SetConsoleTextAttribute(hConsoleOut, (Int16)( ((UInt16)(Backcolor) * 0x10) | (UInt16)value));
			}

			get
			{
				return (ColorConsole.ConsoleColor)((Int16)GetConsoleOutColors() & 0x0F);
			}
		}
		
		public static ColorConsole.ConsoleColor Backcolor
		{
			set 
			{
				SetConsoleTextAttribute(hConsoleOut, (Int16)(((UInt16)(value) * 0x10) | (UInt16)Forecolor));
			}

			get 
			{
				return (ColorConsole.ConsoleColor)((Int16)(GetConsoleOutColors() & 0xF0) / 0x10);
			}
		}
		
		public static string Title
		{
			set 
			{
				string title = value;
				IntPtr st = Marshal.StringToBSTR(title);
				
				SetConsoleTitle(title);
			}
			get
			{
				string strTitle = new string(' ', 255);
				int rtnLen;
				rtnLen = GetConsoleTitle(out strTitle, 256);
				if(rtnLen > 0)
					strTitle = strTitle.Substring(0, rtnLen);
				
				return strTitle;
			}
		}

		#endregion

		#region Methods
		public static void Clear()
		{
			// Variable to store status
			int hWrittenChars = 0;
			
			// Get hold of the screen buffer information.
			CONSOLE_SCREEN_BUFFER_INFO strConsoleInfo = new CONSOLE_SCREEN_BUFFER_INFO();			
			GetConsoleScreenBufferInfo(hConsoleOut, ref strConsoleInfo);
			
			// Set coordinate to 0,0
			COORD HomeCord;		
			HomeCord.x = HomeCord.y = 0;
			
			// Delete all characters in console.
			FillConsoleOutputCharacter(hConsoleOut, EMPTY, strConsoleInfo.Size.x * strConsoleInfo.Size.y, HomeCord, ref hWrittenChars);
			
			// Fill background with black.
			Fill(ConsoleColor.Black);

			// Go home
			Home();
		}

		public static void Write(string strOutPut, params object[] args)
		{
			int lngCb;
   
			if(Disposed)
				Allocate();

			for(int i = 0;i<args.Length;i++)
				strOutPut = strOutPut.Replace("{" + i + "}", args[i].ToString());
			
			
			IntPtr st = Marshal.StringToBSTR(strOutPut);
			WriteConsole(hConsoleOut, st, strOutPut.Length, out lngCb, IntPtr.Zero);
		}

		public static void WriteLine(string strOutPut, params object[] args)
		{
			int lngCb;
   
			if(Disposed)
				Allocate();
   
			strOutPut += "\n";
			
			for(int i = 0;i<args.Length;i++)
				strOutPut = strOutPut.Replace("{" + i + "}", args[i].ToString());
			
			IntPtr st = Marshal.StringToBSTR(strOutPut);
			
			WriteConsole(hConsoleOut, st, strOutPut.Length, out lngCb, IntPtr.Zero);
		}

		public static void Reset()
		{
			if(Disposed)
				return;
			// Restore console defaults.
			SetConsoleTextAttribute(hConsoleOut, OldConsoleColors);
										   
			// set a flag so as we can check if the console has been freed
			// in case it needs to be reallocated later
			Disposed = true;
   
			// Free the console if we allocated it
			if(DidAllocate)
				FreeConsole();
		}
		
		public static void Home()
		{
			// Set coordinate to 0,0
			COORD Home;		
			Home.x = Home.y = 0;
		
			// Set cursor position to home			
			SetConsoleCursorPosition(hConsoleOut, Home); 
		}
		public static void Fill(ColorConsole.ConsoleColor Color)
		{
			int hWrittenChars = 0;
			
			// Set coordinate to 0,0
			COORD Home;		
			Home.x = Home.y = 0;
						
			// Get hold of the screen buffer information.
			CONSOLE_SCREEN_BUFFER_INFO strConsoleInfo = new CONSOLE_SCREEN_BUFFER_INFO();			
			GetConsoleScreenBufferInfo(hConsoleOut, ref strConsoleInfo);
			
			Int16 wColor = (Int16)((Int16)Color * 0x10);
			
			// Set all colors on screen to 0 (Black)
			FillConsoleOutputAttribute( 
				hConsoleOut,									// screen buffer handle 
				wColor,											// fill with a bakcground
				strConsoleInfo.Size.x * strConsoleInfo.Size.y,	// number of cells to fill 
				Home,											// first cell to write to 
				ref hWrittenChars);								// actual number written 			
		}

		#endregion
	}
}
