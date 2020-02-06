namespace CSharpCenter
{
public class CMyArray
{
	private int [] 	m_arIntegers;
	private int[,]	m_ar2DIntegers;
	public CMyArray()
	{
		//instantiate the arrays...
		m_arIntegers	= new int[2];
		m_ar2DIntegers	= new int[2,2];
	}
	public void Initialize()
	{
		//initialize the arrays...
		for ( int i = 0; i < 2; ++i)
			m_arIntegers[i] = i;
		for (  i = 0; i < 2; ++i)
			for(int j = 0; j < 2 ; j++)
				m_ar2DIntegers[i,j] = i + j;
	}
	public void PrintData()
	{	
		for ( int i = 0; i < m_arIntegers.Length; ++i)
			Console.WriteLine("m_arIntegers[{0}] = {1}",i,m_arIntegers[i]);
		for (  i = 0; i < 2; ++i)
			for(int j = 0; j < 2 ; j++)
				Console.WriteLine("m_ar2DIntegers[{0},{1}] = {2}",i,j,m_ar2DIntegers[i,j]);
	}
}
public class CConsoleApp
{
	void static Main()
	{
		CMyArray theArray = new CMyArray();
		theArray.Initialize();
		theArray.PrintData();

	}
}
}