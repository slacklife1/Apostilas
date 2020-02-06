 1: //  FileSize.cs -  
 2: //-----------------------------------------------
 3: using System;
 4: using System.IO;
 5: 
 6: class FileSize
 7: {
 8:   public static void Main()
 9:   {
10:      string[] CLA = 
             Environment.GetCommandLineArgs();
11:       
12:      FileInfo fiExe = 
              new FileInfo(CLA[0]);
13: 
14:      if ( CLA.Length < 2 )
15:      {
16:          Console.WriteLine(
              "Format: {0} filename", fiExe.Name);
17:      }
18:      else
19:      {
20:        try
21:        {
22:          FileInfo fiFile = 
               new FileInfo(CLA[1]);
23: 
24:          if(fiFile.Exists)
25:          {
26:            Console.WriteLine("===================================");
27:            Console.WriteLine("{0} - {1}", 
                                      fiFile.Name, fiFile.Length );
28:            Console.WriteLine("===================================");
29:            Console.WriteLine("Last Access: {0}",
                                      fiFile.LastAccessTime);
30:            Console.WriteLine("Last Write:  {0}",
                                      fiFile.LastWriteTime);
31:            Console.WriteLine("Creation:    {0}", 
                                      fiFile.CreationTime);
32:            Console.WriteLine("===================================");
33:          }
34:          else
35:          {
36:            Console.WriteLine("{0} doesn't exist!", fiFile.Name);
37:          }
38:       }
39:  
40:       catch (System.IO.FileNotFoundException)
41:       {
42:         Console.WriteLine("\n{0} does not exist!", CLA[1]);
43:         return;
44:       }
45:       catch (Exception e)
46:       {
47:         Console.WriteLine("\nException thrown trying to copy file.");
48:         Console.WriteLine(e);
49:         return;
50:       }
51:     }
52:   }
53: }

