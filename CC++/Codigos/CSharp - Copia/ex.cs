Example: C# Interface and Class Definitions

     interface IDotNetInterface
     {
         void Initialize();

         string Caption
         {
             set;
         }

         int ShowDialog(string sText);
     }

     class DotNetClass : IDotNetInterface
     {
