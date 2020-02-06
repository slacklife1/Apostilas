Demonstration of the try-catch-finally

// Demonstration of the try-catch-finally

// exception handling mechanism.

public class UsingExceptions {

   public static void main( String args[] )

   {

      try {

         throwException();

      }

      catch ( Exception e )

      {

         System.err.println( "Exception handled in main" );

      }



      doesNotThrowException();

   }



   public static void throwException() throws Exception

   {

      // Throw an exception and immediately catch it.

      try {

         System.out.println( "Method throwException" );

         throw new Exception();  // generate exception

      }

      catch( Exception e )

      {

         System.err.println(

            "Exception handled in method throwException" );

         throw e;  // rethrow e for further processing



         // any code here would not be reached

      }

      finally {

         System.err.println(

            "Finally executed in throwException" );

      }



      // any code here would not be reached

   }



   public static void doesNotThrowException()

   {

      try {

         System.out.println( "Method doesNotThrowException" );

      }

      catch( Exception e )

      {

         System.err.println( e.toString() );

      }

      finally {

         System.err.println(

            "Finally executed in doesNotThrowException" );

      }



      System.out.println(

         "End of method doesNotThrowException" );

   }

}



/**************************************************************************

 * (C) Copyright 1999 by Deitel & Associates, Inc. and Prentice Hall.     *

 * All Rights Reserved.                                                   *

 *                                                                        *

 * DISCLAIMER: The authors and publisher of this book have used their     *

 * best efforts in preparing the book. These efforts include the          *

 * development, research, and testing of the theories and programs        *

 * to determine their effectiveness. The authors and publisher make       *

 * no warranty of any kind, expressed or implied, with regard to these    *

 * programs or to the documentation contained in these books. The authors *

 * and publisher shall not be liable in any event for incidental or       *

 * consequential damages in connection with, or arising out of, the       *

 * furnishing, performance, or use of these programs.                     *

 *************************************************************************/