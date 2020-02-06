/*
    MediaException class
      written in C#                              Version: 1.0
      by The KPD-Team                            Date: 2002/01/17
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

/// <summary>
/// The exception that is thrown when an error occurs while opening and/or playing a WAVE file.
/// </summary>
public class MediaException : Exception {
	/// <summary>Constructs a new MediaException object.</summary>
	/// <param name="Message">Specifies the error message.</param>
	public MediaException(string Message) : base(Message) {}
	/// <summary>Returns a string representation of this object.</summary>	
	/// <returns>A string representation of this MediaException.</returns>
	public override string ToString() {
		return "MediaException: " + Message + " " + StackTrace;
	}
}