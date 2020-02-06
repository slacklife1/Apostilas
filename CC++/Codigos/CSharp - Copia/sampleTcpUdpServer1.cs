/* Project  : Simple Multi-threaded TCP/UDP Server v1
 * Author   : Patrick Lam
 * Date     : 09/19/2001
 * Brief    : The simple multi-threaded TCP/UDP Server v1 provides a TCP and 
 *            UDP servers running at separate threads.  The sockets can receive 
 *            a text messages send frm the client machine, and return a confirmation
 *            together with the received text back to the client. It uses the traditional
 *            socket programming methods (socket/bind/listen/accept).  In the 
 *            v2 of this program, I will make use if the .Net library's TcpListener
 *            that will make things much easier.
 * Usage  :   sampleTcpUdpServer1
 */
namespace SimpleTcpUdpServer1
{
	using System;
	using System.Net;
	using System.Net.Sockets;
	using System.Threading;
	
	public class SampleTcpUdpServer1
	{
		private const int sampleTcpPort = 4567;
		private const int sampleUdpPort = 4568;
		public Thread sampleTcpThread, sampleUdpThread;
		
		public SampleTcpUdpServer1()
		{
			try
			{		
				sampleTcpThread = new Thread(new ThreadStart(StartListen));
				sampleTcpThread.Start();
				Console.WriteLine("Started SampleTcpUdpServer's TCP Listener Thread!\n");
			}
			catch (Exception e)
			{
				Console.WriteLine("An TCP Exception has occurred!" + e.ToString());
				sampleTcpThread.Abort();
			}
			
			try
			{		
				sampleUdpThread = new Thread(new ThreadStart(StartReceiveFrom));
				sampleUdpThread.Start();
				Console.WriteLine("Started SampleTcpUdpServer's UDP Receiver Thread!\n");
			}
			catch (Exception e)
			{
				Console.WriteLine("An UDP Exception has occurred!" + e.ToString());
				sampleUdpThread.Abort();
			}
		}
		
		public static void Main(String[] argv)
		{
			SampleTcpUdpServer1 sts = new SampleTcpUdpServer1();
		}
		
		public void StartListen()
		{
			
			IPHostEntry localHostEntry;
		
			try
			{
				Socket soTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				
				try
				{
					localHostEntry = Dns.GetHostByName(Dns.GetHostName());
				}
				catch(Exception)
				{
					Console.WriteLine("Local Host not found"); // fail
					return ;
				}
				
			
				IPEndPoint localIpEndPoint = new IPEndPoint(localHostEntry.AddressList[0], sampleTcpPort);
				
				soTcp.Bind(localIpEndPoint);
				
				soTcp.Listen(5);
			
				while (true)
				{						
					Socket sampleTcpSocket = soTcp.Accept();
					
					if (sampleTcpSocket.Connected)
						{
							Console.WriteLine("SampleClient is connected through TCP.");
							Byte[] received = new Byte[256];
							int bytesReceived = sampleTcpSocket.Receive(received, received.Length, 0);
							String dataReceived = System.Text.Encoding.ASCII.GetString(received);
							Console.WriteLine(dataReceived);
							String returningString = "The Server got your message through TCP: " +
									dataReceived;
							
							Byte[] returningByte = System.Text.Encoding.ASCII.GetBytes(returningString.ToCharArray());
							
							sampleTcpSocket.Send(returningByte, returningByte.Length, 0);
							
						}
				}
					
			}
			catch (SocketException se)
			{
				Console.WriteLine("A Socket Exception has occurred!" + se.ToString());
			}
				
		}
		
		public void StartReceiveFrom()
		{
			
			IPHostEntry localHostEntry;
		
			try
			{
				Socket soUdp = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				
				try
				{
					localHostEntry = Dns.GetHostByName(Dns.GetHostName());
				}
				catch(Exception)
				{
					Console.WriteLine("Local Host not found"); // fail
					return ;
				}
				
			
				IPEndPoint localIpEndPoint = new IPEndPoint(localHostEntry.AddressList[0], sampleUdpPort);
				
				soUdp.Bind(localIpEndPoint);
			
				while (true)
					{
						Byte[] received = new Byte[256];
						IPEndPoint tmpIpEndPoint = new IPEndPoint(localHostEntry.AddressList[0], sampleUdpPort);
						EndPoint remoteEP = (tmpIpEndPoint);
						int bytesReceived = soUdp.ReceiveFrom(received, ref remoteEP);
						String dataReceived = System.Text.Encoding.ASCII.GetString(received);

						Console.WriteLine("SampleClient is connected through UDP.");

						Console.WriteLine(dataReceived);
				
						String returningString = "The Server got your message through UDP: " +
								dataReceived;
						
						Byte[] returningByte = System.Text.Encoding.ASCII.GetBytes(returningString.ToCharArray());
						
						soUdp.SendTo(returningByte, remoteEP);

					}
					
			}
			catch (SocketException se)
			{
				Console.WriteLine("A Socket Exception has occurred!" + se.ToString());
			}
				
		}
	}
}
