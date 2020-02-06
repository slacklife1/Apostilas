public class Sort

{

  public static void main(String[] args)

  {

    // Declare the String that is to be sorted.

    String text = "Death, be not proud, though some have called thee " +

                     "Mighty and dreadful, for thou art not so; " +

                     "for those whom thou think'st thou dost overthrow " +

                     "Die not, poor Death; nor yet canst thou kill me. " +

                     "From rest and sleep, which but thy pictures be, " +

                     "Much pleasure; then from thee much more must flow " +

                     "And sooner our best men with thee do go - " +

                     "Rest of their bones, and souls' delivery! " +

                     "Thou'rt slave to fate, chance, kings, and desperate men, " +

                     "And dost with poison, war, and sickness dwell; " + 

                     "And poppy or charms can make us sleep as well " +

                     "And better than thy stroke. Why swell'st thou then? " +

                     "One short sleep past, we wake eternally, " +

                     "And Death shall be no more: Death, thou shalt die!";



    int index = 0;

    char separator = ' '; // inter-word separating character

    int count = 1;       // Count number of words. There must be at least 1

                 // This is the reason for a do-while rather than

                 // a while loop in the example Word for Word.



    // Determine how many words there are

    while((index = text.indexOf(' ',index)) != -1)

    {

      index++;

      count++;

    }



    // Create the array of strings to contain all the words.

    String[] words = new String[count];



    index = 0;

    int endIndex = 0;



    for(int i = 0; i < count; i++)

    {

      endIndex = text.indexOf(separator,index); // find the next separator

      if(endIndex == -1)

     words[i] = text.substring(index);

      else

     words[i] = text.substring(index,endIndex);

      index = endIndex + 1;

    }



    // Sort the substring array using direct insertion

    {

      int i,j;

      String a;



      for(j = 1; j < count; j++) // Look at every word starting at 2nd

      {

     a = words[j];           // Put the current word in a buffer

     i = j - 1;           // Start compare with the previous word 

     while((i >= 0) && (words[i].compareTo(a) > 0))

     {                // Compare the ith and i+1th word - if ith word

       words[i+1] = words[i]; //  is greater than i+1th, swap them

        i--;                   // Decrease i so the previous pair are compared

        }                          //  next time round

     words[i+1] = a;     // if any changes to the array occur, the

      }               //  word at j is gone. Put the stored word in

    }               //  the vacant place.



    // Display the sorted array of words

    for(int i = 0; i < words.length; i++)

      System.out.println(words[i]);

  }

}

