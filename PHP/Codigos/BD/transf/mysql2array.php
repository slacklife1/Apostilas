<?php

function mysql2array($result)
{
    $retorno = array();
    while ($dados = mysql_fetch_assoc($result)) {
        array_push($retorno, $dados);
    }
    
    return $retorno;
}


/** Exemplo de utiliza��o
$con = mysql_connect("localhost", "root", "root") or die("falha na conex�o: ".mysql_error());
mysql_select_db("mysql") or die("falha na sele��o do banco: ".mysql_error());

//Forma de utiliza��o 
$sql = "select * from user"; 

$result = mysql_query($sql) or die("falha na consulta: ".mysql_error());

$mysql_array  = mysql2array($result);

echo "<pre>";
print_r($mysql_array);
*/
?>