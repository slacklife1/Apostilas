using System;
using System.Data.OleDb;

namespace ConsoleApplication1
{
        /// 
        /// Summary description for Class1.
        /// 
        class Class1
        {
                static string strConnString = "Provider=SIBPROvider;" + 
                                              "Data Source=c:\\databases\\employee.gdb;" +
                                              "User Id=sysdba;" +
                                              "Password=masterkey;" +
                                              "Sib:Character set=iso8859_1";
                /// 
                /// The main entry point for the application.
                /// 
                [STAThread]
                static void Main(string[] args)
                {
                        OleDbConnection sibConnection = new OleDbConnection( strConnString );
                        sibConnection.Open();
                        Console.WriteLine("Conectou!");
                }
        }
}