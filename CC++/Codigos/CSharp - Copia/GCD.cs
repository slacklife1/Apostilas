using System;

namespace Cshrp.TAOCP
{
	/// <summary>
	/// Euclids Algorithm in C#. 
	/// Given two possitive integers, Euclids algorithm finds the greatest common divisor.
	/// 
	/// Source:
	/// The Art Of Computer Programming. Volume 1, Fundamental Algorithms. By Donald E. Knuth.
	///	Algorithm 1.1E 
	///</summary>
	class GCD
	{
		[STAThread]
		static void Main(string[] args)
		{
			bool iterate = true;
			int r = -1; //initial state for r.
			int m = int.Parse(args[0]);
			int n = int.Parse(args[1]);

			//ensure that m > n, otherwise m <-> n.
			if(n > m)
			{
				m = m - n;	
				n = n + m;	
				m = n - m;
			}
		
			while(iterate)
			{
				r = m%n;
				
				if(r==0)
				{
					iterate = false;
				}
				else
				{
					m = n; n = r;
			
				}
			}
			Console.WriteLine("GCD: {0}", n);
		}
	}
}
