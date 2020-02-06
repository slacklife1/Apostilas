Source Code : Ouputs the Zodiac signs

// Ouputs the Zodiac sign corresponding to a given date.

import java.util.*;

import java.text.DateformatSymbols;



class TryCalendar

{

     public static void main(String[]args)

     {

          String [] zodiac = {  "CAPRICORN", "AQUARIUS", "PISCES", 

                                "ARIES",     "TAURUS",   "GEMINI", 

                                "CANCER",    "LEO",      "VIRGO",  

                                            "LIBRA",     "SCORPIO",  "SAGITTARIUS" 

                                         };



    // Dates for the start of each sign period, starting with Aquarius

          GregorianCalendar[] signStartDates = { new GregorianCalendar(2000, Calendar.JANUARY, 21),

                                                 new GregorianCalendar(2000, Calendar.FEBRUARY, 20),

                                                 new GregorianCalendar(2000, Calendar.MARCH, 21),

                                                 new GregorianCalendar(2000, Calendar.APRIL, 21),

                                                 new GregorianCalendar(2000, Calendar.MAY, 22),

                                                 new GregorianCalendar(2000, Calendar.JUNE, 22),

                                                 new GregorianCalendar(2000, Calendar.JULY, 24),

                                                 new GregorianCalendar(2000, Calendar.AUGUST, 24),

                                                 new GregorianCalendar(2000, Calendar.SEPTEMBER, 24),

                                                 new GregorianCalendar(2000, Calendar.OCTOBER, 24),

                                                 new GregorianCalendar(2000, Calendar.NOVEMBER, 23),

                                                 new GregorianCalendar(2000, Calendar.DECEMBER, 22)

                                               };

               

          GregorianCalendar birthday = getDate();           // Get the calendar for a birthday



          String yourSign = zodiac[0];                      // Set CAPRICORN as default

    for(int i = 0; i<signStartDates.length ; i++)

            if(birthday.before(signStartDates[i]))          // Check if birthday is before a start date

            {

              yourSign = zodiac[i];                         // if it is, that determines the sign

              break;

            }

    // if none was set in the loop, it must be 22nd Dec or later so default applies

            

          System.out.println("Your zodiacal sign is: " + yourSign);

     }



     private static GregorianCalendar getDate()

     {

       int day = 0;

       int month = 0;

       for(int i = 0 ; i<5 ; i++)

       {

            System.out.println("Enter a birthday as dd mm: ");

            day=in.intRead();

            month=in.intRead();

            if(month>0 && month<13 && day>0 && day <= monthDays[month-1])

              return new GregorianCalendar(2000, month-1, day);

            System.out.println("Invalid date entered. Try again.");

       }

       System.out.println("Five invalid dates entered. Sorry - no more tries...");

    System.exit(1);

    return null;

     }



  private static int[] monthDays = {31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

     private static formattedInput in=new formattedInput();

}



//******************************************

//formattedInput.java

//******************************************

import java.io.*;



public class formattedInput implements Serializable

{

     public String stringRead()

     {

          try

          {

               for(int i=0;i<5;i++)

               {

                    int tokenType=tokenizer.nextToken();

                    if (tokenType==tokenizer.TT_WORD||tokenType=='\"')

                         return tokenizer.sval;

                    else if(tokenType=='!')

                         return"!";

                    else

                    {

                         System.out.println("Incorrect input. Re-enter a string between double quotes");

                         continue;

                    }

               }

               System.out.println("Five failures reading a string"+" - program terminated");

               System.exit(1);

               return null;

          }

          catch(IOException e)

          {

               System.out.println(e);

               System.exit(1);

               return null;

          }

     }



     public int intRead()

     {

          try

          {

               for(int i=0; i<5; i++)

               {

                    if(tokenizer.nextToken()==tokenizer.TT_NUMBER && tokenizer.nval==(double)((long)tokenizer.nval))

                         return(int)tokenizer.nval;

                    else

                    {

                         System.out.println("Incorrect input: "+tokenizer.sval+" Re-enter an integer");

                         continue;

                    }

               }

               System.out.println("Five failures reading an int value"+" - program terminated");



               System.exit(1);

               return 0;

          }

          catch(IOException e)

          {

               System.out.println(e);

               System.exit(1);

               return 0;

          }

     }

     private StreamTokenizer tokenizer=new StreamTokenizer(new InputStreamReader(System.in));

}