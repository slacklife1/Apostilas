/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 2.11
*
*/     

public class OrdenacaoArray
{
    
   private static final int CONT=5;
   
   public static void main (String bolhas[])
   {
       int valores [] ={7, 2, 9, 3, 8};         
       System.out.println ("Valores do array não ordenados:");

       for (int i=0; i < 5; i++)
           System.out.print (valores[i] + " ");

       new OrdenacaoArray().metodoBolha (valores);
       System.out.println ("\nValores do array ordenados:");

       for (int i=0; i < 5; i++)
           System.out.print (valores[i] + " ");

   }
   public void metodoBolha (int num[])
   {
       int temp;
        for (int i=1; i < num.length; i++)
        {
            for (int j=0; j < num.length-1; j++)
            {
                if (num [j] > num [j + 1])
                {
                    temp = num[j];
                    num[j] = num [j+1];
                    num [j+1] = temp;
                }
            }
        }
   }
    
}
