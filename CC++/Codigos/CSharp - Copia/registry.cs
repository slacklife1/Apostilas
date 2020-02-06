namespace CSharpcenter{
using System;
using Microsoft.Win32;

 
public class ConsoleApp
{
public static int Main(string[] args)
{
//
// TODO: Add code to start application here
//

//get down to the Typed URL in 
//HKCU\\SOFTWARE\\MICROSOFT\\INTERNET EXPLORER\\TYPEDURLS
RegistryKey theCurrentMachine = Registry .CurrentUser ;
RegistryKey theSoftware = theCurrentMachine.OpenSubKey ("SOFTWARE");
RegistryKey theMicrosoft = theSoftware.OpenSubKey ("Microsoft");
RegistryKey theIE = theMicrosoft.OpenSubKey ("Internet Explorer");
RegistryKey theTypedURLS = theIE.OpenSubKey ("TypedURLs");
//Now get all the values in the key...
long lCount = theTypedURLS.ValueCount;
if(lCount <= 0) return 1;
string [] arTypedURL = theTypedURLS.GetValueNames();
Console.WriteLine ("You have typed in following web sites in IE :");
int i = 1;
	foreach ( string theURL in arTypedURL)
	{
		//get the name of the url ...
		Console.WriteLine ("[{0}] {1}",i,theTypedURLS.GetValue (theURL));
		i++;
	}
	return 0;
}
}
}