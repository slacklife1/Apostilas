Source code for serversocket1.cs
// created on 9/21/2001 at 10:59 AM
using System ;
using System.Net.Sockets ;
using System.IO ;  

public class ServerSocket1
{
                public static void Main()
                {
                                try
                                {
                                                bool status = true ;
                                                string servermessage = "" ;
                                                string clientmessage = "" ;
                                                TcpListener tcpListener = new TcpListener(8100) ;
                                                tcpListener.Start() ;
                                                Console.WriteLine("Server Started") ;
                                                Socket socketForClient = tcpListener.AcceptSocket() ;
                                                Console.WriteLine("Client Connected") ;
                                                NetworkStream networkStream = new NetworkStream(socketForClient) ;
                                                StreamWriter streamwriter = new StreamWriter(networkStream) ;
                                                StreamReader streamreader = new StreamReader(networkStream) ;
                                                while(status)
                                                {
                                                                if(socketForClient.Connected)
                                                                {
                                                                                servermessage = streamreader.ReadLine() ;
                                                                                Console.WriteLine("Client:"+servermessage) ;
                                                                                if((servermessage== "bye" ))
                                                                                {
                                                                                                status = false ;
                                                                                                streamreader.Close() ;
                                                                                                networkStream.Close() ;
                                                                                                streamwriter.Close() ;
                                                                                                return ;                                                                                               

                                                                                }
                                                                                                                Console.Write("Server:") ;
                                                                                                                clientmessage = Console.ReadLine() ;                       
                                                                                
                                                                                                                streamwriter.WriteLine(clientmessage) ;
                                                                                                                streamwriter.Flush() ; 

                                                                         }                                                               

                                                }
                                                streamreader.Close() ;
                                                networkStream.Close() ;
                                                streamwriter.Close() ;
                                                socketForClient.Close() ;
                                                Console.WriteLine("Exiting") ;
                                }
                                catch(Exception e)
                                {
                                                Console.WriteLine(e.ToString()) ;
                                }
                                }
}              

// Source Code Ends 
************************************************************** 
// Source Code for  ClientSocket1.cs
// created on 9/21/2001 at 11:54 AM 
using System ; 
using System.Net.Sockets ; 
using System.IO ; 
  
public class ClientSocket1 
{ 
            static void Main(string[] args) 
            { 
                        TcpClient socketForServer ; 
                        bool status = true ; 
                        try 
                        { 
                                    socketForServer = new TcpClient("localhost",8100) ; 
                                    Console.WriteLine("Connected to Server") ; 
                                    
                        } 
                        catch 
                        { 
                                    Console.WriteLine("Failed to Connect to server{0}:999","localhost") ; 
                                    return ; 
                        } 
                        
                        NetworkStream networkStream = socketForServer.GetStream() ; 
                        StreamReader streamreader = new StreamReader(networkStream) ; 
                        StreamWriter streamwriter = new StreamWriter(networkStream) ; 
                        
                        try 
                        { 
                                    string clientmessage="" ; 
                                    string servermessage="" ; 
                                    
                                    while(status) 
                                    { 
                                                
                                                Console.Write("Client:") ; 
                                                clientmessage = Console.ReadLine() ; 
                                                if((clientmessage=="bye") || (clientmessage=="BYE")) 
                                                            { 
                                                                        status = false ; 
                                                                        streamwriter.WriteLine("bye") ; 
                                                                        streamwriter.Flush() ; 
                                                                        
                                                            } 
                                                            if((clientmessage!="bye") && (clientmessage!="BYE")) 
                                                                        { 
                                                                                    streamwriter.WriteLine(clientmessage) ; 
                                                                                    streamwriter.Flush() ; 
                                                                                    servermessage = streamreader.ReadLine() ; 
                                                                                    Console.WriteLine("Server:"+servermessage) ; 
                                                                        } 
                                                
                                                
                                                            
                                    } 
                        } 
                        catch 
                        { 
                                    Console.WriteLine("Exception reading from the server") ; 
                        } 
                        streamreader.Close() ; 
                        networkStream.Close() ; 
                        streamwriter.Close() ; 
            } 
} 