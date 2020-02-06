/*
    DirectoryDialog class
      written in C#                              Version: 1.0
      by The KPD-Team                            Date: 2002/01/25
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
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

[ StructLayout( LayoutKind.Sequential, CharSet=CharSet.Ansi )]
public struct BROWSEINFO {
	public IntPtr hWndOwner;
	public int pIDLRoot;
	public string pszDisplayName;
	public string lpszTitle;
	public int ulFlags;
	public int lpfnCallback;
	public int lParam;
	public int iImage;
}

/// <summary>
/// Implements the SHBrowseForFolder function to show a common folder dialog.
/// </summary>
public class DirectoryDialog {
	private const int MAX_PATH = 260;
	/// <summary>Specifies the type of items to browse for.</summary>
	public enum BrowseForTypes {
		/// <summary>Browse for computers..</summary>
		Computers = 0x1000,
		/// <summary>Browse for directories.</summary>
		Directories = 0x1,
		/// <summary>Browse for files and directories.</summary>
		/// <remarks>Only works on shell version 4.71 and higher!<remarks>
		FilesAndDirectories = 0x4000, // Version 4.71
		/// <summary>Browse for file system ancestors (an ancestor is a subfolder that is beneath the root folder in the namespace hierarchy.).</summary>
		FileSystemAncestors = 0x8
	}
	[ DllImport( "ole32.dll", CharSet=CharSet.Ansi )]
	private static extern int CoTaskMemFree(IntPtr hMem);
	[ DllImport( "kernel32.dll", CharSet=CharSet.Ansi )]
	private static extern IntPtr lstrcat(string lpString1, string lpString2);
	[ DllImport( "shell32.dll", CharSet=CharSet.Ansi )]
	private static extern IntPtr SHBrowseForFolder(ref BROWSEINFO lpbi);
	[ DllImport( "shell32.dll", CharSet=CharSet.Ansi )]
	private static extern int SHGetPathFromIDList(IntPtr pidList, StringBuilder lpBuffer);
	/// <summary>Shows the common folder dialog.</summary>
	/// <param name="hWndOwner">The owner of the folder dialog.</param>
	protected bool RunDialog(IntPtr hWndOwner) {
		BROWSEINFO udtBI = new BROWSEINFO();
		IntPtr lpIDList;
		GCHandle hTitle = GCHandle.Alloc(Title, GCHandleType.Pinned);
		// set the owner of the window
		udtBI.hWndOwner = hWndOwner;
		// set the owner of the window
		udtBI.lpszTitle =  Title;
		// set the owner of the window
		udtBI.ulFlags  = (int)BrowseFor;
		// create string buffer for display name
		StringBuilder buffer = new StringBuilder(MAX_PATH);
		buffer.Length = MAX_PATH;
		udtBI.pszDisplayName = buffer.ToString();
		// show the 'Browse for folder' dialog
		lpIDList = SHBrowseForFolder(ref udtBI);
		hTitle.Free();
		if (lpIDList.ToInt64() != 0) {
			if (BrowseFor == BrowseForTypes.Computers) {
				m_Selected = udtBI.pszDisplayName.Trim();
			} else {
				StringBuilder path = new StringBuilder(MAX_PATH);
				// get the path from the IDList
				SHGetPathFromIDList(lpIDList, path);
				m_Selected = path.ToString();
			}
			// free the block of memory
			CoTaskMemFree(lpIDList);
		} else {
			return false;
		}
		return true;
	}
	/// <summary>Shows the common folder dialog.</summary>
	public DialogResult ShowDialog() {
		return ShowDialog(null);
	}
	/// <summary>Shows the common folder dialog.</summary>
	/// <param name="owner">The owner of the folder dialog.</param>
	public DialogResult ShowDialog(IWin32Window owner) {
		IntPtr handle;
		if (owner != null)
			handle = owner.Handle;
		else
			handle = IntPtr.Zero;
		if (RunDialog(handle)) {
			return DialogResult.OK;
		} else {
			return DialogResult.Cancel;
		}
	}
	/// <summary>Specifies the title of the dialog.</summary>
	/// <value>The title of the dialog.</value>
	/// <exceptions cref="ArgumentNullException">Thrown when the specified value is null (VB.NET: Nothing)</exceptions>
	public string Title {
		get {
			return m_Title;
		}
		set {
			if (value == null)
				throw new ArgumentNullException();
			m_Title = value;
		}
	}
	/// <summary>Returns the selected item.</summary>
	/// <value>The selected item.</value>
	public string Selected {
		get {
			return m_Selected;
		}
	}
	/// <summary>Specifies what to browse for.</summary>
	/// <value>What to browse for.</value>
	public BrowseForTypes BrowseFor {
		get {
			return m_BrowseFor;
		}
		set {
			m_BrowseFor = value;
		}
	}
	// private declares
	private BrowseForTypes m_BrowseFor = BrowseForTypes.Directories;
	private string m_Title = "";
	private string m_Selected = "";
}
