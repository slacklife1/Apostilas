public class Volumes

{

  public static void main(String[] args)

  {

    // Initialize a double variable to be the sun's diameter

    double sunRad = 865000.0/2.0;

    double earthRad = 7600.0/2.0;

    double fourOverThree = 4.0/3.0;

    double sunVol = 0, earthVol = 0; // You can declare a number of variables

    double ratioVol = 0;             // of the same type on a single line if you wish.



    // Find the volumes of earth and sun

    earthVol = fourOverThree*Math.PI*Math.pow(earthRad,3);

    sunVol = fourOverThree*Math.PI*Math.pow(sunRad,3);

    // Find the ratio of their volumes

    ratioVol = sunVol/earthVol;



    // Output the results

    System.out.println("Volume of the earth is " + earthVol + " cubic miles.");

    System.out.println("Volume of the sun is " + sunVol + " cubic miles.");

    System.out.println("The sun's volume is " + ratioVol +

                         " times greater than the earth's.");

  }

}

