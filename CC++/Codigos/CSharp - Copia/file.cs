/// <summary>
/// Connect to the COM Port.
/// </summary>
private void GetDevice(string Port)
{
  // open the existing port...
  m_ihandle = CreateFile(Port,
    GENERIC_READ | GENERIC_WRITE,
    0,              // comm devices must be opened
                    // w/exclusive-access
    0,              // no security attributes
    OPEN_EXISTING,  // comm devices must use OPEN_EXISTING
    0,              // not overlapped I/O
    0);             // hTemplate must be NULL for comm devices
  //if the handle value is -1, that means you got an error....
  if(m_ihandle == -1)
    //write failure log
    Console.WriteLine("open COM port failed" + GetLastError());
  else
    //write success log
    Console.WriteLine(Port + " opened successfully!");
}

/// <summary>
/// Send Command to the COM Port.
/// As I am using a modem, I send command like "AT+CGMM"
/// </summary>
private unsafe void SendCommand(string szCmd)
{
  int i = 0, n = 0;
  //get string length
  int Len = szCmd.Length;
  //use ASCIIEncoding to work with byte and string
  ASCIIEncoding e = new ASCIIEncoding();
  //assign string to byte buffer and add "return"
  byte[]Buffer = e.GetBytes(szCmd + "\r\n");
  //use fixed to avoid more memory allocation
  fixed (byte* p = Buffer)
  {
    i=0;
    //write command to the port
    if(!WriteFile(m_ihandle, p + i, Len+1, &n, 0))
      //if false, write failure log
      Console.WriteLine("Send Command " + szCmd + " failed");
    else
      // write success log
      Console.WriteLine("Send Command Successed");
  }
}
/// <summary>
/// Read information from the COM Port.
/// </summary>
private unsafe void ReadModem()
{
  //set the maximum limit to read
  int count = 128;
  //create buffer to store the info
  byte[] buffer = new byte[count];
  //use ASCII encoding to work with string and byte
  ASCIIEncoding e = new ASCIIEncoding();
  //loop through read until done...
  int index = 0;
  int n = 1;
  while (n!=0)
  {
    n = 0;
    fixed (byte* p = buffer)
    {
      //read file
      if(!ReadFile(m_ihandle, p + index, count, &n, 0))
        //write the value received in log
        Console.WriteLine(e.GetString(buffer));
      else
        //write failure log
        Console.WriteLine("Read Modem Failed");
    }
  }
}