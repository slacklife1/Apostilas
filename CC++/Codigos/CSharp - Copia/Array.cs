using System;
using System.Collections;

namespace Collections
{
class Class1
{
public static int[] arr1 = new int[] {1,2,3,4};
public static string s = "";
public static string opt = "y";

static void Main(string[] args)
{
while ((opt == "y")|| (opt == "Y"))
{
Console.Write("Enter Your name :");
s = Console.ReadLine();
IEnumerator IEn = s.GetEnumerator();
Array a =
Array.CreateInstance(typeof(char),s.Length);
Console.WriteLine("Type
:{0}",IEn.GetType());
Console.WriteLine("HashCode for the
Type:{0}",(IEn.GetHashCode()));
IEn.Reset();
IEn.MoveNext();
for(int i = 0;i<s.Length; i++)
{
a.SetValue(IEn.Current,i);
IEn.MoveNext();
}
Array.Sort(a);
Console.Write("Your Name in the sorted
form : ");
for(int i =
a.GetLowerBound(0);i<=a.GetUpperBound(0); i++)
{
Console.Write(a.GetValue(i));
}
Console.WriteLine("");
Console.Write("Do You want to try
again?(y/n): ");
opt = Console.ReadLine();
}
}
}
}