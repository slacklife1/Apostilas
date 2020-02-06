using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using OuthouseObjectModel;

namespace Outhouse
{
	/// <summary>
	/// Summary description for Utility.
	/// </summary>
	public class Utility
	{
		static public ArrayList LoadMessages( string inputLoc )
		{
			// Load the messages out of the messages file for this folder.
			ArrayList messages = new ArrayList( );
			XmlSerializer serializer = new XmlSerializer( typeof( Message[] ) );
			FileStream tempStream;
			try
			{
				tempStream = new FileStream( inputLoc, FileMode.Open );
			}
			catch( Exception )
			{
				// Unable to load the config file.
				return messages;
			}
			
			try
			{
				Message[] tempMessages = (Message[])serializer.Deserialize( tempStream );
				for( int count = 0; count < tempMessages.GetLength( 0 ); ++count )
				{
					messages.Add( tempMessages[ count ] as IMessage );
				}
			}
			catch( Exception e )
			{
				MessageBox.Show( string.Format( "Unable to open the file {0}. Error = {1}", inputLoc, e.Message ), "Deserialization Error" );
			}
			finally
			{
				tempStream.Close( );
			}

			return messages;
		}

		static public void SaveMessages( ArrayList messages, string outputLoc )
		{
			Message[] outArray = new Message[ messages.Count ];
			int count = 0;
			foreach( Message mess in messages )
			{
				outArray[ count ] = mess;
				++count;
			}
			
			XmlSerializer serializer = new XmlSerializer( typeof( Message[] ) );
			StreamWriter writer = new StreamWriter( outputLoc );
			try
			{
				serializer.Serialize( writer, outArray );
			}
			finally
			{
				writer.Close( );
			}
		}
	}
}
