 //secant method
using System;
class Secant
{
    public delegate double Function(double x); //declare a delegate that takes double and returns double

    public static void secant(int step_number, double point1,double point2,Function f)
    {
        double p2,p1,p0,prec=.0001f; //set precision to .0001
        int i;
        p0=f(point1);
        p1=f(point2);
        p2=p1-f(p1)*(p1-p0)/(f(p1)-f(p0)); //secant formula

        for(i=0;System.Math.Abs(p2)>prec &&i<step_number;i++)
            //iterate till precision goal is not met or the maximum
            //number of steps is reached
        {
                p0=p1;
                p1=p2;
                p2=p1-f(p1)*(p1-p0)/(f(p1)-f(p0));
        }
        if(i<step_number)
            Console.WriteLine(p2); //method converges
        else
            Console.WriteLine("{0}.The method did not converge",p2);//method does not converge
   }
}
class Demo
{//equation f1(x)==0;
    public static double f1( double x)
    {
        return x*x*x-2*x-5;
    }

    public static void Main()
    {
        Secant.secant(5,0,1,new Secant.Function(f1));
    }
}

Our second example is a Simpson integration algorithm. The Simpson algorithm is more precise the naive integration algorithm I have used there. The basic idea of the Simpson algorithm is to sample the integrand in a number of points to get a better estimate of its variations in a given interval.

//Simpson integration algorithm

using System;
//calculate the integral of f(x) between x=a and x=b by spliting the interval in step_number steps

class Integral
{
    public delegate double Function(double x); //declare a delegate that takes and returns double
    public static double integral(Function f,double a, double b,int step_number)
    {
        double sum=0;
        double step_size=(b-a)/step_number;
        for(int i=0;i<step_number;i=i+2)
            //Simpson algorithm samples the integrand in several point which
            // significantly improves precision.
            sum=sum+(f(a+i*step_size)+4*f(a+(i+1)*step_size)+f(a+(i+2)*step_size))*step_size/3;
            //divide the area under f(x)
            //into step_number rectangles and sum their areas
        return sum;
    }
}

class Test
{
    //simple functions to be integrated
    public static double f1( double x)
    {
        return x*x;
    }

    public static double f2(double x)
    {
        return x*x*x;
    }

    public static void Main()
    {//output the value of the integral.
        Console.WriteLine(Integral.integral(new Integral.Function(f1),1,10,20));
    }
}