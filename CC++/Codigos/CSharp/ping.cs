using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace SNSM
{
public class netPing
{
const int SOCKET_ERROR = -1;
const int ICMP_ECHO = 8;
public netPing()
{
}
public static int Ping(string host)
{
IPHostEntry ServerHostEntry;
IPHostEntry FromHostEntry;
int nBytes = 0;
int dwStart =0;

// Set the parameters for our new socket
// InterNetwork = Address for IP version 4
// Raw = This will be a raw socket
// Icmp = Our protcol will be ICMP (Internet Control Message Protocol)
Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Raw,ProtocolType.Icmp);
try
{
// Get a list of IP Addresses associated with our Host.
ServerHostEntry = Dns.GetHostByName(host);
}
catch(Exception)
{
// The host was not found. Return a negative number
// to represent that an error condition occured.
return -1;
}
IPEndPoint ipepServer = new IPEndPoint(ServerHostEntry.AddressList[0],0);
EndPoint epServer = (ipepServer);
// Set and end point for the receiving system.
FromHostEntry = Dns.GetHostByName(Dns.GetHostName());
// Use the 1st IP address in the list we received above using DNS.
IPEndPoint ipEndPointFrom = new IPEndPoint(FromHostEntry.AddressList[0],0);
EndPoint EndPointFrom = (ipEndPointFrom);
int PacketSize = 0;
// Create a new Packet. Define it's type and all relevent information
// (i.e., Checksums, Sequence numbers and the size of the data it will
// contain).
IcmpPacket packet = new IcmpPacket();
packet.Type = ICMP_ECHO;
packet.SubCode=0;
packet.CheckSum=UInt16.Parse("0");
packet.Identifier=UInt16.Parse("45");
packet.SequenceNumber=UInt16.Parse("0");
int PingData = 32; // Size of IcmpPacket - 8
packet.Data = new Byte[PingData];
// Fill the packet with some data.
// In this case we are using the Pound symbol
for (int i = 0; i < PingData; i++)
{
packet.Data[i] = (byte)'#';
}
PacketSize = PingData + 8;
Byte [] icmp_pkt_buffer = new Byte[ PacketSize ];
Int32 Index = 0;
Index = Serialize( 
packet, 
icmp_pkt_buffer, 
PacketSize, 
PingData );

// Check for an error condition in the packet size.
if( Index == -1 )
{
// Could not build the packet
return -2;
}

//Get the Half size of the Packet
Double double_length = Convert.ToDouble(Index);
Double dtemp = Math.Ceiling ( double_length / 2);
int cksum_buffer_length = Convert.ToInt32(dtemp);
//Create a Byte Array
UInt16 [] cksum_buffer = new UInt16[cksum_buffer_length];
//Code to initilize the Uint16 array 
int icmp_header_buffer_index = 0;
for( int i = 0; i < cksum_buffer_length; i++ ) 
{
cksum_buffer[i] = 
BitConverter.ToUInt16(icmp_pkt_buffer,icmp_header_buffer_index);
icmp_header_buffer_index += 2;
}
//Call a method which will return a checksum 
UInt16 u_cksum = checksum(cksum_buffer, cksum_buffer_length);
//Save the checksum to the Packet
packet.CheckSum = u_cksum; 

// Now that we have the checksum, serialize the packet again
Byte [] sendbuf = new Byte[ PacketSize ]; 
//again check the packet size
Index = Serialize( 
packet, 
sendbuf, 
PacketSize, 
PingData );
//if there is a error report it
if( Index == -1 )
{
// Could not build the packet
return -3;
}

dwStart = System.Environment.TickCount; // Start timing
//send the Pack over the socket
if ((nBytes = socket.SendTo(sendbuf, PacketSize, 0, epServer)) == SOCKET_ERROR) 
{ 
// Could not send the packet but lets ignore that and continue
}
// Initialize the buffers. The receive buffer is the size of the
// ICMP header plus the IP header (20 bytes)
Byte [] ReceiveBuffer = new Byte[256]; 
nBytes = 0;
//Receive the bytes
bool recd =false ;
int timeout=0 ;

//loop for checking the time of the server responding 
while(!recd)
{
// Make sure this is not a blocking socket or
// our call will not return if the remote system is 
// not responding.
socket.Blocking = false;
try
{
nBytes = socket.ReceiveFrom(ReceiveBuffer, 256, 0, ref EndPointFrom);
}
catch (SocketException e)
{
// Ignore the 'Socket Not Ready' error and
// return a failure for all other exceptions.
if (e.ErrorCode != 10035) // Socket not ready
return -4;
}
if(nBytes>0)
return 1;
timeout=System.Environment.TickCount - dwStart;
if(timeout>3000)
return 0; // Our request to the system has timed out

}

//close the socket
socket.Close(); 
return 0;
}
public static Int32 Serialize( IcmpPacket packet, Byte [] Buffer, Int32 PacketSize, Int32 PingData )
{
Int32 cbReturn = 0;
// serialize the struct into the array
int Index=0;
Byte [] b_type = new Byte[1];
b_type[0] = (packet.Type);
Byte [] b_code = new Byte[1];
b_code[0] = (packet.SubCode);
Byte [] b_cksum = BitConverter.GetBytes(packet.CheckSum);
Byte [] b_id = BitConverter.GetBytes(packet.Identifier);
Byte [] b_seq = BitConverter.GetBytes(packet.SequenceNumber);

Array.Copy( b_type, 0, Buffer, Index, b_type.Length );
Index += b_type.Length;

Array.Copy( b_code, 0, Buffer, Index, b_code.Length );
Index += b_code.Length;
Array.Copy( b_cksum, 0, Buffer, Index, b_cksum.Length );
Index += b_cksum.Length;
Array.Copy( b_id, 0, Buffer, Index, b_id.Length );
Index += b_id.Length;
Array.Copy( b_seq, 0, Buffer, Index, b_seq.Length );
Index += b_seq.Length;
// copy the data 
Array.Copy( packet.Data, 0, Buffer, Index, PingData );
Index += PingData;
if( Index != PacketSize/* sizeof(IcmpPacket) */) 
{
cbReturn = -1;
return cbReturn;
}
cbReturn = Index;
return cbReturn;
}
public static UInt16 checksum( UInt16[] buffer, int size )
{
Int32 cksum = 0;
int counter;
counter = 0;
while ( size > 0 ) 
{
UInt16 val = buffer[counter];
cksum += Convert.ToInt32( buffer[counter] );
counter += 1;
size -= 1;
}
cksum = (cksum >> 16) + (cksum & 0xffff);
cksum += (cksum >> 16);
return (UInt16)(~cksum);
}
}
// Define our ICMP packet structure.
public class IcmpPacket
{
public Byte Type;
public Byte SubCode;
public UInt16 CheckSum;
public UInt16 Identifier;
public UInt16 SequenceNumber;
public Byte [] Data;
}
}
