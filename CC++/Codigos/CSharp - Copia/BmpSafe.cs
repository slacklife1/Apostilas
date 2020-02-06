/*
 *  BmpSafe
 *  -------
 * 
 *  Little steganografie implementation through 24bit bitmap files
 * 
 *  project start: 31th July 2k2
 * 
 *  by yoda
 * 
 */

using System;
using System.IO;
using System.Drawing;

/// <summary>
/// Class modifing the pixel's RGB colors to hide information in it
/// </summary>
public class Bitmap24Writer
{
	protected Bitmap bmp;
	protected int curX, curY, iRGB;
	protected uint bitsLeft, bitsTotal;
	protected byte r, g, b; // RGB color elements

	/// <summary>
	/// My constructor
	/// </summary>
	/// <param name="bmp"></param>
	public Bitmap24Writer(Bitmap bmp)
	{
		// 24bit bmp ?
		if (bmp.PixelFormat != System.Drawing.Imaging.PixelFormat.Format24bppRgb)
			throw new ArgumentException(); // EXCP
		// assign vars
		curX       = curY = iRGB = 0;
		this.bmp   = bmp;
		bitsLeft   = bitsTotal = (uint)bmp.Height * (uint)bmp.Width * 3;
	}

	public uint GetUnusedBitCount()
	{
		return bitsLeft; // OK
	}

	public uint GetMaxBitStorageCount()
	{
		return bitsTotal; // OK
	}

	public Bitmap GetBitmap()
	{
		return bmp; // OK
	}

	// stores a byte in the bitmap and saves the state for future write operations
	public bool WriteByte(byte by)
	{
		// enough unprocessed space in bitmap ?
		if (bitsLeft < 8)
			return false; // ERR

		uint bits2Do = 8; // 1 byte = 8 bit

		for (; curX < bmp.Width; curX++)
		{
			if (curY >= bmp.Height) // manually reset y coordinate to 0 if the current row is finished
				curY = 0;

			for (; curY < bmp.Height; curY++)
			{
				if (bits2Do == 0)
					return true; // OK

				Color col = bmp.GetPixel(curX, curY);
				r = col.R;
				g = col.G;
				b = col.B;

				for ( ; ; )
				{
					byte curBit = (byte)(by & 1);

					// store the bit in the current pixel
					switch( iRGB )
					{
						case 0:
							r = (byte)(r & 0xFE);
							r |= curBit;
							break;

						case 1:
							g = (byte)(g & 0xFE);
							g |= curBit;
							break;

						case 2:
							b = (byte)(b & 0xFE);
							b |= curBit;
							break;
					}
					--bits2Do; // update vars...
					--bitsLeft;
					by >>= 1; // 2nd rightmost bit -> rightmost bit
					// paste color back now
					bmp.SetPixel(curX, curY, Color.FromArgb(r, g, b)); // update pixel info in the bmp
					if (iRGB == 2) // all 3 pixel elements done ? -> next pixel
					{
						iRGB = 0;
						break; // leave 'for (;;)' loop
					}
					iRGB++;
					// byte written ?
					if (bits2Do == 0)
						return true; // OK
				}
			}
		}
		return true; // OK
	}
}

/// <summary>
/// Class reading the pixel's RGB colors to read information being hidden in it
/// </summary>
public class Bitmap24Reader
{
	protected Bitmap bmp;
	protected int curX, curY, iRGB;
	protected uint bitsLeft, bitsTotal;

	/// <summary>
	/// My constructor
	/// </summary>
	/// <param name="bmp"></param>
	public Bitmap24Reader(Bitmap bmp)
	{
		// 24bit bmp ?
		if (bmp.PixelFormat != System.Drawing.Imaging.PixelFormat.Format24bppRgb)
			throw new ArgumentException(); // EXCP
		// assign vars
		curX       = curY = iRGB = 0;
		this.bmp   = bmp;
		bitsLeft   = bitsTotal = (uint)bmp.Height * (uint)bmp.Width * 3;
	}

	public uint GetUnusedBitCount()
	{
		return bitsLeft; // OK
	}

	public uint GetMaxBitStorageCount()
	{
		return bitsTotal; // OK
	}

	public Bitmap GetBitmap()
	{
		return bmp; // OK
	}

	// reads a byte from the bitmap and saves the state for future read operations
	public bool ReadByte(out byte by)
	{
		by = 0;

		// enough unprocessed space in bitmap ?
		if (bitsLeft < 8)
			return false; // ERR

		byte bit = 0;
		uint bits2Do = 8;  // 1 byte = 8 bit

		for (; curX < bmp.Width; curX++)
		{
			if (curY >= bmp.Height)  // manually reset y coordinate to 0 if the current row is finished
				curY = 0;

			for (; curY < bmp.Height; curY++)
			{
				if (bits2Do == 0)
					return true; //OK

				// get bit from current pixel
				Color col = bmp.GetPixel(curX, curY);
				for ( ; ; )
				{
					switch( iRGB )
					{
						case 0:
							bit = (byte)(col.R & 1);
							break;

						case 1:
							bit = (byte)(col.G & 1);
							break;

						case 2:
							bit = (byte)(col.B & 1);
							break;
					}
					--bits2Do; // update vars...
					--bitsLeft;
					by |= (byte)(bit << 7); // assign current bit to output byte's leftmost bit
					if (bits2Do != 0)
						by >>= 1; // right shift output byte by 1
					if (iRGB == 2) // all 3 pixel elements used? -> switch to next pixel
					{
						iRGB = 0;
						break; // leave 'for (; iRGB < 3; iRGB++)' loop
					}
					iRGB++;
					// byte written ?
					if (bits2Do == 0)
						return true; // OK
				}
			}
		}
		return true; // OK
	}
}

public class BitmapWorks
{
	/// <summary>
	/// Write information into a bitmap
	/// </summary>
	/// <param name="dataStream"></param>
	/// <param name="bmpStream"></param>
	/// <param name="outFName"></param>
	/// <param name="error"></param>
	/// <returns></returns>
	public static bool Data2Bmp(FileStream dataStream, FileStream bmpStream, string outFName, out string error)
	{
		error = "";

		//
		// validate input
		//

		// is it a 24bit bitmap ?
		Bitmap bmp;
		try
		{
			bmp = new Bitmap(bmpStream);
		}
		catch
		{
			error = "Are you sure the specified bitmap is a valid bitmap ?";
			return false; // ERR
		}
		if (bmp.PixelFormat != System.Drawing.Imaging.PixelFormat.Format24bppRgb)
		{
			error = "Please drop only 24bit bitmaps,thanks !";
			return false; // ERR
		}

		error += "-> Bitmap info: height=" + bmp.Height + " width=" + bmp.Width + "...\n";

		// test input data for 0
		if (dataStream.Length == 0)
		{
			error = "Input data has a not supported size of 0 !";
			return false; // ERR
		}
		// enough space in bitmap ?
		uint maxByteStorage = ((uint)bmp.Height * (uint)bmp.Width * 3) / 8;
		error += "-> Up to " + (maxByteStorage-4) + " bytes could be stored in this bitmap...\n";
		if (maxByteStorage < dataStream.Length + 4) // enough space 4 data + data size (4 byte=DWORD) ?
		{
			error = "Not enough pixel in target bitmap to hide the input data block !";
			return false; // ERR
		}

		//
		// hide the input data bytes in the bitmap
		//	

		// loop through the pixel rows
		Bitmap24Writer bmpWriter = new Bitmap24Writer(bmp);
		// write data block size 2 bitmap
		uint dataSize = (uint)dataStream.Length;
		try
		{
			for (uint u = 0; u < 4; u++)
			{
				bmpWriter.WriteByte( (byte)dataSize );
				dataSize >>= 8;
			}
			// write data block 2 bitmap
			for (uint u = 0; u < dataStream.Length; u++)
				bmpWriter.WriteByte( (byte)dataStream.ReadByte() );
		}
		catch
		{
			error = "Error while modifing the bitmap's pixels !";
			return false; // ERR
		}

		// calc used space in bitmap and print it
		double maxBitStorage = bmpWriter.GetMaxBitStorageCount();
		double spaceUsed = (100 * (maxBitStorage - bmpWriter.GetUnusedBitCount())) / maxBitStorage;
        error += "-> Space used: " + Convert.ToUInt32(spaceUsed) + "%...\n";

		//
		// write the result 2 disk
		//

		try
		{
			if ( File.Exists( outFName ) ) // del if output file is already existing
				File.Delete( outFName );
			bmpWriter.GetBitmap().Save(outFName); // save op
		}
		catch
		{
			error = "Couldn't save output to " + outFName + " !";
			return false; // ERR
		}

		error += "-> Output saved to: " + outFName + "...\n"; // print result

		return true; // OK
	}

	/// <summary>
	/// Rip hidden data from a bitmap
	/// </summary>
	/// <param name="bmpStream"></param>
	/// <param name="outFName"></param>
	/// <param name="error"></param>
	/// <returns></returns>
	public static bool Bmp2Data(FileStream bmpStream, string outFName, out string error)
	{
		error = "";

		//
		// validate input
		//

		// is it a 24bit bitmap ?
		Bitmap bmp;
		try
		{
			bmp = new Bitmap(bmpStream);
		}
		catch
		{
			error = "Are you sure the specified bitmap is a valid bitmap ?";
			return false; // ERR
		}

		// fire up our Bitmap24Reader
		Bitmap24Reader bmpReader;
		try
		{
			bmpReader = new Bitmap24Reader(bmp);
		}
		catch (ArgumentException)
		{
			error = "This isn't a 24bit bitmap !";
			return false; // ERR
		}

		//
		// rebuild the hidden data - write result to output file
		//
		FileStream outStream;
		try
		{
			outStream = File.Create( outFName );
		}
		catch
		{
			error = "Couldn't create output file: " + outFName + " !";
			return false; // ERR
		}
		// get data size from bitmap image
		uint dataSize = 0;
		byte outByte;
		try
		{
			// read first 4 bytes == size of the hidden data block
			for (uint u = 0; u < 4; u++)
			{
				if ( !bmpReader.ReadByte( out outByte ) )
					throw new Exception(); // EXCP
				dataSize |= (uint)( outByte << 8*3 );
				if (u != 3)
					dataSize >>= 8;
			}
			error += "-> Size of hidden data: " + dataSize + " bytes...\n";
			// decode data block
			for (uint u = 0; u < dataSize; u++)
			{
				if ( !bmpReader.ReadByte( out outByte ) )
					throw new Exception(); // EXCP
				outStream.WriteByte( outByte );
			}
		}
		catch
		{
			error = "Exception caught while reading the hidden data !";
			return false; // ERR
		}
		finally
		{
			// tidy up
			outStream.Close();
		}

		error += "-> Output saved to: " + outFName + "...\n";

		return true; // OK
	}

}

/// <summary>
/// Entrypoint class
/// </summary>
class BmpSafe
{
	public static string cmdLine =
		"Command line:\n" +
		"    BmpSafe.exe /file2bmp (input BMP) (input file to hide) [output file]\n" +
		"    BmpSafe.exe /bmp2file (data BMP) [output file]";

	private static string serviceOne = "/file2bmp";
	private static string serviceTwo = "/bmp2file";

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main(string[] args)
	{
		//
		// print program title
		//
		Console.WriteLine(
			"BmpSafe - hide files in 24bit bitmaps\n" +
			"          a little steganografie implementation\n" +
			"          by yoda\n" +
			"-------------------------------------------------------------------------------\n");

		//
		// handle cmd line
		//
		string inFile = "", inBmp, outFile;
		bool bFile2Bmp;
		if (args.Length < 2)
		{
			Console.WriteLine("!! Invalid number of arguments :(");
			Console.WriteLine(cmdLine);
			return; // ERR
		}
		if ( String.Compare(args[0], serviceOne, true) == 0 )
			bFile2Bmp = true;
		else if ( String.Compare(args[0], serviceTwo, true) == 0)
			bFile2Bmp = false;
		else
		{
			Console.WriteLine("!! First parameters must be either \"/file2bmp\" or \"/bmp2file\" !");
			return; // ERR
		}

		inBmp = args[1];
		if (bFile2Bmp)
		{
			if (args.Length < 3)
			{
				Console.WriteLine("!! Invalid number of arguments :(");
				Console.WriteLine(cmdLine);
				return; // ERR
			}
			inFile = args[2];
			if (args.Length > 3)
				outFile = args[3];
			else
				outFile = "Secret.BMP";
		}
		else
		{
			if (args.Length > 2)
				outFile = args[2];
			else
				outFile = "Secret.bin";
		}
		
		//
		// do the job
		//
		Console.WriteLine("-> Processing input...");
		try
		{
			string err;
			bool ret;

			if (bFile2Bmp)
				ret = BitmapWorks.Data2Bmp(
					File.OpenRead(inFile),
					File.OpenRead(inBmp),
					outFile,
					out err );
			else
				ret = BitmapWorks.Bmp2Data(
					File.OpenRead(inBmp),
					outFile,
					out err);
			// result -> GUI
			if (!ret) // an error ?
			{
				Console.WriteLine("!! " + err);
				return; // ERR
			}
			else
				Console.Write( err );
		}
		catch(FileNotFoundException)
		{
			Console.WriteLine("!! At least one file could not be found :(");
			return; // ERR
		}
		catch
		{
			Console.WriteLine("!! An exception occurred :(");
			return; // ERR
		}

		Console.WriteLine("-> Job done..."); // success msg

		return; // OK
	}
}
