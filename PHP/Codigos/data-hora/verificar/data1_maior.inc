<?php

/*
  Fun��o data1_maior
  Autor : Luiz F�bio M. Jr. - http://www.microlabinfo.com.br
  Data  : 10/09/2003
  Vers�o: 1.00

Se data1 maior que data2 a fun��o retorna "true", sen�o retorna "false".
Obs: independe se a data est� no formato AAAA-MM-DD ou DD/MM/AAAA.
*/

  function data1_maior($data1,$data2){
    // se data no formato DD/MM/AAAA ent�o converte para AAAA-MM-DD
    if (strstr($data1, "/")){
      $aux = explode ("/", $data1);
      $data1 = $aux[2] . "-". $aux[1] . "-" . $aux[0];
    }
    // se data no formato DD/MM/AAAA ent�o converte para AAAA-MM-DD
    if (strstr($data2, "/")){
      $aux = explode ("/", $data2);
      $data2 = $aux[2] . "-". $aux[1] . "-" . $aux[0];
    }
    // verifica se data1 � maior que data2
    if ($data1 > $data2) return true;
    else return false;
  }
?>
