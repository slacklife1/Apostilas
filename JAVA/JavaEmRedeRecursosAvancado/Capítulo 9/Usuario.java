/*
* Java em Rede: Recursos Avan�ados de Programa��o
*
* Daniel G. Costa
*
* Exemplo 9.8
*
*/


public class Usuario implements java.io.Serializable
{
    private String nome;

    public Usuario (String n)
    {
	nome = n;
    }
    public String getNome ()
    {
	return nome;
    }
    public void setNome (String n)
    {
	nome = n;
    }
}