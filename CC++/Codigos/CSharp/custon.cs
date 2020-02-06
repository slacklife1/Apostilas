using System;
 
namespace CustomCode
{
  [CodeInfo("Gaurav Mantro","John Doe","10/10/01")]
  class CustomAttrDemo
  {
    static void Main(string[] args)
    {
      CustomAttrDemo cattDemo = new CustomAttrDemo();
      DisplayCustomAttribute(cattDemo);
    }
 
    static void DisplayCustomAttribute(CustomAttrDemo cattDemo)
    {
      Type type = cattDemo.GetType();
      Object obj = type.GetCustomAttributes(false)[0];
      if(obj is CodeInfoAttribute)
      {
       System.Console.Write("Developer - ");
       System.Console.WriteLine(((CodeInfoAttribute)obj).Devloper);
       System.Console.Write("Reviewer - ");
       System.Console.WriteLine(((CodeInfoAttribute)obj).Reviewer);
       System.Console.Write("Review Date - ");
     System.Console.WriteLine(((CodeInfoAttribute)obj).ReviewDate);
      }
      else
       System.Console.WriteLine("Attribute not found");
    }
}
 
[AttributeUsage(AttributeTarget.All,Inherited=true,AllowMultiple=true)]
public class CodeInfoAttribute : Attribute
{
  // Private Data
  private string reviewerName;
  private string reviewDate;
  private string developerName;
 
  // Constructor
  public CodeInfoAttribute(string developerName,
                           string reviewerName,
                           string reviewDate)
  {
    this.developer_name = developerName;
    this.reviewer_name  = reviewerName;
    this.review_date    = reviewDate;
  }
 
  public string Devloper
  {
    get
    {
      return developerName;
    }
  }
 
  public string Reviewer
  {
    get
    {
      return reviewerName;
    }
  }
 
  public string ReviewDate
  {
    get
    {
      return reviewDate;
    }
  }
}