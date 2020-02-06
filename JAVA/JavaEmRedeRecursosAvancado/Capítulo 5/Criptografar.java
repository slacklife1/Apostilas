/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 5.3
*
*/


import javax.crypto.*;
import javax.crypto.spec.*;

public class Criptografar
{

    static public void main (String entrada [])
    {
        try
        {
            String mensagem = "Usuario: root, senha: AsD587";
            System.out.println ("Mensagem original: " + mensagem);

 	    KeyGenerator kgen = KeyGenerator.getInstance ("Blowfish");
            SecretKey chave = kgen.generateKey();

            Cipher cipher = Cipher.getInstance ("Blowfish");
            cipher.init (Cipher.ENCRYPT_MODE, chave);

 	    byte criptografada[] = cipher.doFinal (mensagem.getBytes());
            System.out.println ("Mensagem criptografada: " + criptografada);

	    cipher.init (Cipher.DECRYPT_MODE, chave);

            byte decriptografada[] = cipher.doFinal (criptografada);
            System.out.println ("Mensagem decriptografada: " + new String (decriptografada));

	}
        catch (Exception exc)
        {
            System.err.println (exc.toString());
        }
    }
}