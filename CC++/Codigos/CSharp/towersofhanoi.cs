/// This is my first C# program, if you have any suggestion please send to my email

using System;

namespace TowersOfHanoi
{
	/// <summary>
	/// This class is our main class.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
			if(args.Length==1)
			{
				Console.WriteLine("Number of disks: {0}",args[0]);

				Class1 obj= new Class1();
				/// Start peg is 1, destination peg is 3 and temp peg is 2
				obj.Move((int)Double.Parse(args[0]), 1, 3, 2);
			}
			else
				Console.WriteLine("Error! Please enter the number of disks: towersofhanoi <NumberOfDisks> ");
		
		}

		/// <summary>
		/// This is our recursive function to move disks.
		/// </summary>
		public void Move(int NumberOfDisks,int StartPeg,int DestinationPeg,int TempPeg)
		{
			if(NumberOfDisks>=2)
				Move(NumberOfDisks-1,StartPeg,TempPeg,DestinationPeg);

			Console.WriteLine("{0} -> {1}", StartPeg,DestinationPeg);

			if(NumberOfDisks>=2)
				Move(NumberOfDisks-1,TempPeg,DestinationPeg,StartPeg);
            			
		}
	}
}
