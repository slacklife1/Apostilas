<?
/* Valida��o de e-mail by Felipe Lopes v.2.0 - 2001
** php4@mailbr.com.br
** php.phpgo.com
** para usar o script, basta inclu�-lo na p�gina que se quer fazer
** a valida��o do e-mail com o seguinte c�digo:
** require("verifica_email.php");
** e ent�o chamar a fun��o da seguinte forma:
** verifica_email($variavel_q_contem_o_email)
** essa fun��o retornar� true se o e-mail estiver correto e, se n�o estiver, false.
*/

function verifica_email($email){
if (ereg("^([0-9,a-z,A-Z]+)([.,_]([0-9,a-z,A-Z]+))*[@]([0-9,a-z,A-Z]+)([.,_,-]([0-9,a-z,A-Z]+))*[.]([0-9,a-z,A-Z]){2}([0-9,a-z,A-Z])?$", $email)){
return true;
}else{
    return false;
}

}

?>