<?

    ##########################################
    #      //EXIBE REGISTRO RANDOMICO  \\    #
    #      //      MySQL               \\    #
    ##########################################
    # C�digo Gerado por Tadeu Pires Pasetto  #
    ##########################################
    #         t.pasetto@bol.com.br           #
    ##########################################
    #C�digo Livre desde que os Cr�ditos sejam#
    #   mantidos. Tamb�m podem ser feitas    #
    #altera��es para  melhor funcionabildade #
    ##########################################
/*
Exibe um registro aleat�rio de uma tabela no banco de dados
MySQL, utilizando o LIMIT
*/

##################################################
/*VARI�VEIS PARA CONFIGURA��O*/
$user = ""; // usuario
$pass = "";//senha
$bd = ""; // Banco de Dados
$tabela = ""; // tabela de origem dos dados
$cond = ""; // o WHERE, caso queira exibir apenas um tipo de registro entre com a condi��o
//$cond = " WHERE data=".date("Y-m-d"); // iniciando com espa�o " "
##################################################
$con = mysql_connect("localhost", "$user", "$pass");
$query = "SELECT * FROM ".$tabela;
$query .= $cond;
$resultado = mysql_db_query("$bd",$query,$con);
$num = mysql_num_rows($resultado);
$num --;
$reg = rand(0,$num);

$query .= " LIMIT ".$reg.",1";
$resultado = mysql_db_query("$bd",$query,$con);
$arr = mysql_fetch_array($resultado);

// Agora com o array "$arr" voc� exibe o rsultado como quiser
echo($arr['msg']); // imprime apenas o campo msg

?>

