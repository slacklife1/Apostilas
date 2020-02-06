using System;

namespace Attributes
{

 class Class1
 {

  [AttributeUsage(AttributeTargets.All)]
  public class Details : Attribute
  {
   public readonly string MemberName;
   public double Version = 1.0;
   public Details(string name)
   {
    this.MemberName = name;
   }
   public double version
   {
    get
    {
     return Version;
    }
    set
    {
     Version = value;
    }
   }
  }
  [Details("Rajadurai")]
  public interface Iattribute
  {
   void display();
  }
  [Details("Sankar")]
  public class classAttribute1 : Iattribute
  {
   public void display()
   {
    Console.WriteLine("My Author is Sankar");
   }
  }

  static void Main(string[] args)
  {
   processAttributes p = new processAttributes(typeof(classAttribute1));
   processAttributes q = new processAttributes(typeof(Iattribute));
   //processAttributes r = new processAttributes(typeof(methodAttribute1));
   int i = Console.Read();
  }

  public class processAttributes
  {
   public processAttributes(Type t)
   {
    Attribute[] attrs = Attribute.GetCustomAttributes(t);
    foreach(Attribute attr in attrs)
    {
     if (attr is Details)
     {
      Console.WriteLine("Type Name :{0}",t);
      Details d = (Details)attr;
      Console.WriteLine("Author Name :{0}",d.MemberName);
      Console.WriteLine("Version :{0}",d.version);
      Console.WriteLine("");
     }
    }
   }
  }
 }
}