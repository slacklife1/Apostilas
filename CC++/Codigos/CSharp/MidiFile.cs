/*
    MidiFile class
      written in C#                              Version: 1.0
      by The KPD-Team                            Date: 2002/02/02
      Copyright © 2002                           Comments to: KPDTeam@allapi.net
                                                 URL: http://www.allapi.net/


   You are free to use this class file in your own applications,
   but you are expressly forbidden from selling or otherwise
   distributing this code as source without prior written consent.
   This includes both posting samples on a web site or otherwise
   reproducing it in text or html format.

   Although much care has gone into the programming of this class
   file, The KPD-Team does not accept any responsibility for damage
   caused by possible errors in this class and/or by misuse of this
   class.
*/

using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

[ StructLayout( LayoutKind.Sequential, CharSet=CharSet.Ansi )]
public struct MCI_OPEN_PARMS {
	public int dwCallback;
	public int wDeviceID;
	public string lpstrDeviceType;
	public string lpstrElementName;
	public string lpstrAlias;
}
[ StructLayout( LayoutKind.Sequential, CharSet=CharSet.Auto )]
public struct MCI_PLAY_PARMS {
	public int dwCallback;
	public int dwFrom;
	public int dwTo;
}
[ StructLayout( LayoutKind.Sequential, CharSet=CharSet.Auto )]
public struct MCI_STATUS_PARMS {
	public int dwCallback;
	public int dwReturn;
	public int dwItem;
	public int dwTrack;
}
[ StructLayout( LayoutKind.Sequential, CharSet=CharSet.Auto )]
public struct MCI_SEQ_SET_PARMS {
	public int dwCallback;
	public int dwTimeFormat;
	public int dwAudio;
	public int dwTempo;
	public int dwPort;
	public int dwSlave;
	public int dwMaster;
	public int dwOffset;
}
[ StructLayout( LayoutKind.Sequential, CharSet=CharSet.Auto )]
public struct MCI_SEEK_PARMS {
	public int dwCallback;
	public int dwTo;
}
[ StructLayout( LayoutKind.Sequential, CharSet=CharSet.Auto )]
public struct MCI_GENERIC_PARMS {
	public int dwCallback;
}

/// <summary>This is an abstract representation of a MIDI file.</summary>
public class MidiFile {
	private const int MCI_OPEN = 0x803;
	private const int MCI_OPEN_TYPE = 0x2000;
	private const int MCI_OPEN_ELEMENT = 0x200;
	private const int MCI_CLOSE = 0x804;
	private const int MCI_PLAY = 0x806;
	private const int MCI_PAUSE = 0x809;
	private const int MCI_RESUME = 0x855;
	private const int MCI_STOP = 0x808;
	private const int MCI_STATUS = 0x814;
	private const int MCI_WAIT = 0x2;
	private const int MCI_SEEK = 0x807;
	private const int MCI_TO = 0x8;
	private const int MCI_STATUS_ITEM = 0x100;
	private const int MCI_STATUS_LENGTH = 0x1;
	private const int MCI_STATUS_POSITION = 0x2;
	private const int MCI_STATUS_MODE = 0x4;
	private const int MCI_STRING_OFFSET = 512;
	private const int MCI_MODE_PAUSE = (MCI_STRING_OFFSET + 17);
	private const int MCI_MODE_PLAY = (MCI_STRING_OFFSET + 14);
	[ DllImport( "winmm.dll", EntryPoint="mciSendCommandA", CharSet=CharSet.Ansi )]
	private static extern int mciSendCommand(int wDeviceID, int uMessage, int dwParam1, IntPtr dwParam2);
	[ DllImport( "winmm.dll", EntryPoint="mciSendCommandA", CharSet=CharSet.Ansi )]
	private static extern int mciSendCommandOpen(int wDeviceID, int uMessage, int dwParam1, ref MCI_OPEN_PARMS dwParam2);
	[ DllImport( "winmm.dll", EntryPoint="mciSendCommandA", CharSet=CharSet.Ansi )]
	private static extern int mciSendCommandStatus(int wDeviceID, int uMessage, int dwParam1, ref MCI_STATUS_PARMS dwParam2);
	[ DllImport( "winmm.dll", EntryPoint="mciSendCommandA", CharSet=CharSet.Ansi )]
	private static extern int mciSendCommandSeek(int wDeviceID, int uMessage, int dwParam1, ref MCI_SEEK_PARMS dwParam2);
	[ DllImport( "winmm.dll", EntryPoint="mciSendCommandA", CharSet=CharSet.Ansi )]
	private static extern int mciSendCommandGeneric(int wDeviceID, int uMessage, int dwParam1, ref MCI_GENERIC_PARMS dwParam2);
	
	/// <summary>Constructs a new MifiFile object.</summary>
	/// <param name="Filename">The MIDI file to load.</param>
	/// <exceptions cref="ArgumentNullException">Thrown when the specified Filename parameter is null (VB.NET: Nothing).</exceptions>
	public MidiFile(string Filename) {
		if (Filename == null)
			throw new ArgumentNullException();
		m_Filename = Filename;
		OpenFile();
	}
	/// <summary>Starts playing the MIDI file.</summary>
	/// <exceptions cref="MediaException">Thrown when an error occured while playing the file.</exceptions>
	public void Play() {
		if (mciSendCommand(DeviceID, MCI_PLAY, 0, IntPtr.Zero) != 0)
			throw new MediaException("Unable to play the MIDI file.");
	}
	/// <summary>Stops the playback of the MIDI file and rewinds.</summary>
	/// <exceptions cref="MediaException">Thrown when an error occured while trying to stop the playback of the file.</exceptions>
	public void StopPlay() {
		if (Playing) {
			if (mciSendCommand(DeviceID, MCI_STOP, 0, IntPtr.Zero) != 0)
				throw new MediaException("Unable to stop the MIDI file.");
		}
		Position = 0;
	}
	/// <summary>Specifies whether the MIDI file is currently paused or not.</summary>
	/// <value>True when the file is paused, False otherwise.</value>
	public bool Paused {
		get {
			MCI_STATUS_PARMS mciStatusParms = new MCI_STATUS_PARMS();
			mciStatusParms.dwItem = MCI_STATUS_MODE;
			if (mciSendCommandStatus(DeviceID, MCI_STATUS, MCI_WAIT | MCI_STATUS_ITEM, ref mciStatusParms) != 0)
				throw new MediaException("Couldn't query the position in the MIDI file.");
			return (mciStatusParms.dwReturn == MCI_MODE_PAUSE);
		}
		set {
			MCI_GENERIC_PARMS mciGenericParms = new MCI_GENERIC_PARMS();
			if (value) {
				if (mciSendCommandGeneric(DeviceID, MCI_PAUSE, MCI_WAIT, ref mciGenericParms) != 0)
					throw new MediaException("Couldn't pause the MIDI file.");
			} else {
				Play();
			}
		}
	}
	/// <summary>Gets the name of the MIDI file.</summary>
	/// <value>The name of the MIDI file.</value>
	public string Filename {
		get {
			return m_Filename;
		}
	}
	/// <summary>Gets the length of the MIDI file.</summary>
	/// <value>The length of the MIDI file.</value>
	public int Length {
		get {
			
			return m_Length;
		}
	}
	/// <summary>Specifies whether the MIDI file is currently playing.</summary>
	/// <value>True if the MIDI file is currently playing, False otherwise.</value>
	public bool Playing {
		get {
			MCI_STATUS_PARMS mciStatusParms = new MCI_STATUS_PARMS();
			mciStatusParms.dwItem = MCI_STATUS_MODE;
			if (mciSendCommandStatus(DeviceID, MCI_STATUS, MCI_WAIT | MCI_STATUS_ITEM, ref mciStatusParms) != 0)
				throw new MediaException("Couldn't query the position in the MIDI file.");
			return (mciStatusParms.dwReturn == MCI_MODE_PLAY);
		}
	}
	/// <summary>Specifies the position in the MIDI file.</summary>
	/// <value>The position in the MIDI file.</value>
	public int Position {
		get {
			MCI_STATUS_PARMS mciStatusParms = new MCI_STATUS_PARMS();
			mciStatusParms.dwItem = MCI_STATUS_POSITION;
			if (mciSendCommandStatus(DeviceID, MCI_STATUS, MCI_WAIT | MCI_STATUS_ITEM, ref mciStatusParms) != 0)
				throw new MediaException("Couldn't query the position in the MIDI file.");
			return mciStatusParms.dwReturn;
		}
		set {
			bool WasPlaying = Playing;
			MCI_SEEK_PARMS mciSeekParms = new MCI_SEEK_PARMS();
			mciSeekParms.dwTo = value;
			if (mciSendCommandSeek(DeviceID, MCI_SEEK, MCI_WAIT | MCI_TO, ref mciSeekParms) != 0)
				throw new MediaException("Couldn't seek to the new location in the MIDI file.");
			if (WasPlaying)		// MCI stops playback when seeking to a new position
				Play();		// so we must manually restart it
		}
	}
	/// <summary>Specifies the ID of the opened MIDI device.</summary>
	/// <remarks>Used interally only.</remarks>
	/// <value>The ID of the opened MIDI device.</value>
	protected int DeviceID {
		get {
			return m_DeviceID;
		}
		set {
			m_DeviceID = value;
		}
	}
	/// <summary>Called when the class gets GCed.</summary>
	~MidiFile() {
		CloseFile();
	}
	/// <summary>Opens a MIDI file.</summary>
	/// <remarks>Used interally only.</remarks>
	/// <exceptions cref="MediaException">Thrown when there was an error opening the file.</exceptions>
	/// <exceptions cref="FileNotFoundException">Thrown when the specified file could not be found.</exceptions>
	protected void OpenFile() {
		if (!File.Exists(Filename))
			throw new FileNotFoundException();
		MCI_OPEN_PARMS mciOpenParms = new MCI_OPEN_PARMS();
		mciOpenParms.lpstrDeviceType = "sequencer";
		mciOpenParms.lpstrElementName = Filename;
		if (mciSendCommandOpen(0, MCI_OPEN, MCI_OPEN_TYPE | MCI_OPEN_ELEMENT, ref mciOpenParms) != 0)
			throw new MediaException("Failed to open the MIDI device.");
		// The device opened successfully; get the device ID.
		DeviceID = mciOpenParms.wDeviceID;
		// Get the length of the MIDI file
		MCI_STATUS_PARMS mciStatusParms = new MCI_STATUS_PARMS();
		mciStatusParms.dwItem = MCI_STATUS_LENGTH;
		if (mciSendCommandStatus(DeviceID, MCI_STATUS, MCI_WAIT | MCI_STATUS_ITEM, ref mciStatusParms) != 0)
			throw new MediaException("Couldn't get the length of the specified MIDI file.");
		m_Length = mciStatusParms.dwReturn;
	}
	/// <summary>Used internally to close a wave file and free the used memory.</summary>
	public void CloseFile() {
		mciSendCommand(DeviceID, MCI_CLOSE, 0, IntPtr.Zero);
	}
	//Private variables
	private string m_Filename;
	private MCI_PLAY_PARMS mciPlayParms = new MCI_PLAY_PARMS();
	private MCI_SEQ_SET_PARMS mciSeqSetParms = new MCI_SEQ_SET_PARMS();
	private int m_DeviceID;
	private int m_Length;
}