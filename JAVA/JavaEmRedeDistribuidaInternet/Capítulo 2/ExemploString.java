/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 2.13
*
*/   

public class ExemploString
{

    static public void main (String a[])
    {
        char arrayChar[] = {'L', 'i', 'v', 'r', 'o', ' ', 'd', 'e', ' ', 'J', 'a', 'v', 'a'};

        for (int i=0; i < arrayChar.length; i++)
        {
            System.out.print (arrayChar[i]);
        }
        System.out.println();

        String s1 = new String (arrayChar);
        String s2 = "Mais uma String\n";
        String s3 = new String ("Outra forma de criar um objeto String");
        System.out.println (s1 + "\n" + s2 + s3);
        System.out.println ("A String s3 tem " + s3.length() + " caracteres");
        System.out.println ("O quarto caractere da String s2 é " + s2.charAt (3));

        String s4 = "Java";

        if (s4.equals("Java"))
          System.out.println ("As Strings são iguais");

        if (s4.equalsIgnoreCase("JaVA"))
          System.out.println ("As Strings aqui também são iguais");

        System.out.println ("A String s3 maiúscula é " + s3.toUpperCase());

    }
}
