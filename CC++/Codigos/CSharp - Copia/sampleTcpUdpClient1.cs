/* Project:  Simple TCP/UDP Client v1
 * Author :  Patrick Lam
 * Date   :  09/19/2001
 * Brief  :  The simple TCP/UDP Client v2 allows users to send a simple text message to
 *           the server and get a confirm message from the server.  Users can either use
 *           TCP or UDP to send this message.  The program uses the traditional socket
 *           programming technique (socket/bind/connect/send).  In v2 of this program, I
 *           will make use of .Net library's TcpClient and UdpClient, that will make things
 *           much easier.
 * Usage  :  sampleTcpUdpClient2 <TCP or UDP> <destination hostname or IP> "Any message." 
 * Example:  sampleTcpUdpClient2 TCP localhost "hello. how are you?"
 * Bugs   :  When you send a message with UDP, you can't specify localhost as the
 *           destination.  Doing so will produce an exception.  Can't figure out why yet.  
 *           A workaround is to use the machine's hostname instead of just "localhost".  This
 *           problem does not happen to TCP connections.
 */
namespace SimpleTcpUdpClient1
{
	using System;
	using System.Net;
	using System.Net.Sockets;
	using System.Threading;
	
	public class sampleTcpUdpClient1
	{
		public enum clientType {TCP, UDP};
		private const int ANYPORT = 0;
		private const int SAMPLETCPPORT = 4567;
		private const int SAMPLEUDPPORT = 4568;
		private bool readData = false;
		public clientType cliType;
		
		public sampleTcpUdpClient1(clientType CliType)
		{
			this.cliType = CliType;
		}

		public void sampleTcpClient(String serverName, String whatEver)
		{
			try
			{
				//Create a TCP socket.
				Socket so = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			
				try
				{
					IPHostEntry localHostEntry = Dns.GetHostByName(Dns.GetHostName());

					//Bind the client to any local port chosen by the kernel.
					IPEndPoint localIpEndPoint = new IPEndPoint(localHostEntry.AddressList[0], ANYPORT);
				
					so.Bind(localIpEndPoint);
				}
				catch(Exception e)
				{
					Console.WriteLine("Local Host not found" + e.ToString()); // fail
				}
				
				try
				{
					IPHostEntry remoteHostEntry = Dns.GetHostByName(serverName);
				
					//Identify and connect to the remote endpoint.
					IPEndPoint remoteIpEndPoint = new IPEndPoint(remoteHostEntry.AddressList[0], SAMPLETCPPORT);
					
					so.Connect(remoteIpEndPoint);
			
					Byte[] inputToBeSent = System.Text.Encoding.ASCII.GetBytes(whatEver.ToCharArray());
					
					//Send the message to the remote endpoint.
					int nBytesSent = so.Send(inputToBeSent);
				}
				catch(Exception e)
				{
					Console.WriteLine("Local Host not found" + e.ToString()); // fail
				}
				
				Byte[] received = new Byte[512];

				while (!readData)
				{
					//Receive the message returned by the server and display it at the console.
					int nBytesReceived = so.Receive(received);
			
					String dataReceived = System.Text.Encoding.ASCII.GetString(received);

					Console.WriteLine(dataReceived);
					
					readData = true;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("An Exception Occurred!" + e.ToString());
			}
		}
	

		public void sampleUdpClient(String serverName, String whatEver)
		{
			try
			{
				//Create the UDP socket.
				Socket so = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			
				try
				{
					IPHostEntry localHostEntry = Dns.GetHostByName(Dns.GetHostName());
				
					//Bind the UDP client to any local port chosen by the kernel.
					IPEndPoint localIpEndPoint = new IPEndPoint(localHostEntry.AddressList[0], ANYPORT);
				
					so.Bind(localIpEndPoint);
				}
				catch(Exception e)
				{
					Console.WriteLine("Local Host not found" + e.ToString()); // fail
				}
				
				try
				{
					IPHostEntry remoteHostEntry = Dns.GetHostByName(serverName);
				
					IPEndPoint remoteIpEndPoint = new IPEndPoint(remoteHostEntry.AddressList[0], SAMPLEUDPPORT);

					EndPoint remoteEndPoint = (remoteIpEndPoint);
			
					//Identify the remote endpoint and send the text message to it.
					Byte[] inputToBeSent = System.Text.Encoding.ASCII.GetBytes(whatEver.ToCharArray());
					
					int nBytesSent = so.SendTo(inputToBeSent, remoteIpEndPoint);
				
					Byte[] received = new Byte[512];

					while (!readData)
					{
						//Receive the text message returned by the server and display it.
						int nBytesReceived = so.ReceiveFrom(received, ref remoteEndPoint);
				
						String dataReceived = System.Text.Encoding.ASCII.GetString(received);

						Console.WriteLine(dataReceived);
						
						readData = true;
					}
				}
				catch(Exception e)
				{
					Console.WriteLine("Local Host not found" + e.ToString()); // fail
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("An Exception Occurred!" + e.ToString());
			}
		}

		public static void Main(String[] argv)
		{
			if (argv.Length <= 0)
			{
				Console.WriteLine("Usage: sampleTcpUdpClient TCP/UDP ServerIPAddress Message");
			}
			else if ((argv[0] == "TCP") || (argv[0] == "tcp"))
			{
				sampleTcpUdpClient1 stc = new sampleTcpUdpClient1(clientType.TCP);
				stc.sampleTcpClient(argv[1], argv[2]);
				Console.WriteLine("The TCP server is disconnected.");
			}
			else if ((argv[0] == "UDP") || (argv[0] == "udp"))
			{
				sampleTcpUdpClient1 suc = new sampleTcpUdpClient1(clientType.UDP);
				suc.sampleUdpClient(argv[1], argv[2]);
				Console.WriteLine("The UDP server is disconnected.");
			}
		}
	}
}

// created on 8/26/2001 at 1:21 PM
