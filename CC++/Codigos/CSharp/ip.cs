using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;

// reads file data: ip_Addr\n etc...

namespace ConsoleApplication2
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		public void Thread1()
		{
			String buf;
			int i, j;

			StreamReader srf = new StreamReader(new FileStream("log.txt", FileMode.Open, FileAccess.Read)); 
			//FileStream fs = new FileStream("whois.html", FileMode.Open, FileAccess.Write);
			StreamWriter sw = new StreamWriter(new FileStream("whois.html", FileMode.Create, FileAccess.Write));
			buf = srf.ReadLine();

			sw.Write("<html>\r\n<head>\r\n<title>WHOIS List</title>\r\n</head>\r\n<body><pre style=\"font-family: verdana; font-size: 12pt;\">\r\n");

			while(buf.Length > 0)
			{
				TcpClient tcpc = new TcpClient();
				try
				{
					tcpc.Connect("whois.arin.net", 43);
				}
				catch(SocketException ex)
				{
					Console.Write(ex.ToString());

				}

				String strDomain = buf + "\r\n";
				Byte[] arrDomain = Encoding.ASCII.GetBytes(strDomain.ToCharArray());
	  
				Stream s = tcpc.GetStream();
				s.Write(arrDomain, 0, strDomain.Length);

				StreamReader sr = new StreamReader(tcpc.GetStream(), Encoding.ASCII);
				string strLine = null;
	
				while (null != (strLine = sr.ReadLine()))
				{
					Console.Write(strLine);
					sw.WriteLine(strLine, 0, strLine.Length);
				}
				sr.Close();
				tcpc.Close();

				sw.Write("\r\n<br><hr><br>\r\n");

				Console.Write("\n");
				Console.Write("***********************************");
				Console.Write("\n");

				// wait due to server connection limits
				Thread.Sleep(3000);
			
				buf = srf.ReadLine();
			}

			sw.Write("\n</pre>\n</body>\n</html>");

			srf.Close();
			sw.Close();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
			Class1 c1 = new Class1();
			
			Thread t1 = new Thread(new ThreadStart(c1.Thread1));
			t1.Start();
		}
	}
}