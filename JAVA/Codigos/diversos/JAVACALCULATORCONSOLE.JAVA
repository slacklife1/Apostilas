 Console Based Java Calculator

package calculator;



/**

 * Title:        Calculator

 * Description:  Calculator

 * Copyright:    Copyright (c) 2003

 * Company:      Nagina Computers

 * @author Muhamnmad Saqib

 * @version 1.0

 */

import java.io.*;

import java.math.*;

public class Calculator {

 static double numAdd1=0,numAdd2=0

 static double numSub1=0,numSub2=0,numMul1=0

 static double  numMul2=0,numDiv1=0,numDiv2=0

 static double  numSqr1=0,numCube1=0,numPow1=0

 static double numPow2=0,numSqrt1=0;

 static int choice;

 static String myString;



  //makes the full user interface at start up

  public static int UI()throws Exception {



     BufferedReader input = new BufferedReader(new InputStreamReader(System.in));

     System.out.println("\n\n****************************\nWel Come to Java Language");

     System.out.println("   CALCULATOR    \n*****************************");

     System.out.println("0:\tEXIT()");

     System.out.println("1:\tAdd two Numbers");

     System.out.println("2:\tSubtract two Numbers");

     System.out.println("3:\tMultiply two Numbers");

     System.out.println("4:\tDivide two Numbers");

     System.out.println("5:\tSquare of a number");

        System.out.println("6:\tCube of a number");

     System.out.println("7:\tFind the SQUARE-ROOT of a Number");

        System.out.println("8:\tFind the X power Y");

     choice = Integer.parseInt(input.readLine());

     return choice;

  }

//Calculate the Addition of two numbers

  public static double add(double numAdd1, double numAdd2){

    return numAdd1 + numAdd2;

  }

//Calculate the subtraction of two numbers

  public static double sub(double numSub1, double numSub2){

    return numSub1 - numSub2;

  }

//Calculate the multiplication of two numbers

  public static double multiply(double numMul1, double numMul2){

    return numMul1 + numMul2;

  }

//Calculate the Division of two numbers

  public static double divide(double numDiv1, double numDiv2){

    return numDiv1 / numDiv2;

  }

//Calculate the Square of a numbers

  public static double square(double numSqr1){

    return numSqr1*numSqr1;

  }

//Calculate the Cube of a numbers

  public static double cube(double numCube1){

    return numCube1 * numCube1 * numCube1;

  }

//Calculate the SQUARE-ROOT of a numbers

  public static double squareRoot(double numSqrt1){

    return Math.sqrt(numSqrt1);

  }

//Calculate the power of numbers

  public static double power(double numpow1, double numPow2){

    return Math.pow(numPow1,numPow2);

  }





  //press any key to Goto Main Menu

  public static void mainMenu(){

     System.out.print("Press Enter key.....");

     try {

          System.in.read();

     }

        catch(IOException e){

        return;

     }

  }

  //Function to check the input validation

  public static boolean checkInput(String str){

    int stringLength = str.length();

    if (stringLength>=300){ return false;}

    for (int i=0;i<stringLength-1;i++)

     if (str.charAt(i) <=0 || str.charAt(i) >=9)

       return false;



  return true;

  }



  //main function

  public static  void main(String[] args)throws Exception {

      boolean isValidInput;

     BufferedReader input = new BufferedReader(new InputStreamReader(System.in));

     choice= UI();

        while (choice!=0){

          switch(choice){

            case 0:

              return;

            case 1:

            //Add two numbers code Code

                System.out.println("\nEnter First Number");

          String str = input.readLine();

          isValidInput = checkInput(str);

          if(isValidInput==true){

              numAdd1= Double.parseDouble(str);

          }

          else {System.out.println("\n****************\nInput ERROR\n**************  ");}

                System.out.println("\nEnter second Number");

          str = input.readLine();

          isValidInput = checkInput(str);

          if(isValidInput==true){

              numAdd2 = Double.parseDouble(str);

              double numAddSum= add(numAdd1,numAdd2);

              System.out.println("\n**********\nThe Sum is= " + numAddSum + "\n********** ");

          }

          else{System.out.println("\n****************\nInput ERROR\n**************  ");}

                mainMenu();

                UI();

            break;

            case 2:

            //Code

            //subtract two numbers code Code

                System.out.println("\nEnter First Number");

             numSub1= Double.parseDouble(input.readLine());

                System.out.println("\nEnter second Number");

          numSub2 = Double.parseDouble(input.readLine());

                double numSub = sub(numSub1,numSub2);

                System.out.println("\n**********\nThe Difference is= " + numSub + "\n********** ");



                mainMenu();

                UI();

            break;

            case 3:

            //Code

            //subtract two numbers code Code

                System.out.println("\nEnter First Number");

             numMul1= Double.parseDouble(input.readLine());

                System.out.println("\nEnter second Number");

          numMul2 = Double.parseDouble(input.readLine());



                    double numMul = multiply(numMul1,numMul2);

                System.out.println("\n**********\nThe Multiplication is= " + numMul + "\n********** ");



             mainMenu();

                UI();

            break;

            case 4:

            //Code

            //Divide two numbers code Code

                System.out.println("\nEnter First Number");

             numDiv1= Double.parseDouble(input.readLine());

                System.out.println("\nEnter second Number");

          numDiv2 = Double.parseDouble(input.readLine());

              double numDiv = divide(numDiv1,numDiv2);

                    System.out.println("\n**********\nThe Division is= " + numDiv + "\n********** ");



          mainMenu();

                UI();

            break;

            case 5:

            //Code

            //square of a number code

                System.out.println("\nEnter a Number");

             numSqr1= Double.parseDouble(input.readLine());

                double numSqr = square(numSqr1);

                System.out.println("\n**********\nThe SQUARE is= " + numSqr + "\n********** ");

                mainMenu();

                UI();

            break;

            case 6:

            //Code

                //cube of a number code

                System.out.println("\nEnter a Number");

             numCube1= Double.parseDouble(input.readLine());

                double numCube = cube(numCube1);

                System.out.println("\n**********\nThe CUBE is= " + numCube + "\n********** ");

                mainMenu();

                UI();

            break;

            case 7:

            //Code

                //square-root of a numbver

                System.out.println("\nEnter a Number");

             numSqrt1= Double.parseDouble(input.readLine());

                double numSqrt = squareRoot(numSqrt1);

                System.out.println("\n**********\nThe SQUARE-ROOT is= " + numSqrt + "\n********** ");

                mainMenu();

                UI();

            break;

            case 8:

            //Code

                //Divide two numbers code Code

                System.out.println("\nEnter a Number");

             numPow1= Double.parseDouble(input.readLine());

                System.out.println("\nEnter a 2nd Number");

             numPow2= Double.parseDouble(input.readLine());

                double numPow = power(numPow1,numPow2);

                System.out.println("\n**********\nThe " + numPow1 + "  power   " + numPow2 + " is= " + numPow + "\n********** ");

                mainMenu();

                UI();

            break;

            default:

            UI();

            break;

          }

      }

  }

}