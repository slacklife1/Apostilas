<?PHP 
# ---------- Autor ----------------------------------> 
# 
# Script Desenvolvido por Anderson Brito em 07/01/2002 
# Nicks: Unixer, Anderson-RJ ou WebServ 
# ICQ: 43003071 
# Email: anderson-rj@linuxbr.com.br ou anderson@linuxclub.com.br 
# Site: http://www.linuxclub.com.br 
# ---------- Copy Right -----------------------------> 
# 
# Este Script pode ser usado e modificado onde voc� quiser!     
# S� quero que quando coloque este script em seu site ou em outros #sites! 
# coloquem o meu nome corretamente e respeite a minha autoria deste! 
# Eu quero ajudar e acabam roubando o meu script e colocando o pr�prio 
# nome e nick! 
# Um Grande Abra�o a Todos! Anderson! 
# 
# ----------- Sobre o Script -----------------------> 
# 
# Script de Lembrar Senha 
# Este script procura um email cadastrado em um banco de dados e o 
# retorna para a conta de email 
# encontrada a sua senha de conexao ao site ! 
# 
# Obs: 
#   Preste aten��o nas configura��es que voc� tem que mudar ! 
# 
#   Qualquer duvida envie um e-mail! 
# 
# ----------------------------------------------------> 

# Abaixo use as suas configura��es   

#Banco de Dados 

$bd_host = "bd.servidor.com.br"; // nome do host do hospediro do Banco de dados // 
$bd_usr = "nomedeusuario"; // nome do usuario do Banco de dados // 
$bd_pass = "senhadobd"; // Senha do Banco de dados // 
$bd_banco_de_dados = "nomedobancodedados"; // Nome do Banco de dados // 
$tabela = "listadeusuarios"; // nome da tabela onde deve ser procurado a senha 

#Webmaster 

$nome_webmaster = "Seu_Nome"; 
$email_do_webmaster = "Seu_Nome"; 

#Site 

$nomedosite = "Nome_do_site"; 
$linkdosite = "http://www.nomesite.com.br"; 

?> 
<? 

if ($submit){ #Verificar se o Formulario foi enviado !! 

  if (!$email){  #Verificar se o email possue @ Sen�o anvia msg de email invalido!! 
      $erro = "O E-mail esta em Branco !!"; 
    } else if (strpos ($email, "@")) { 
      $email = $email;         
    } else { 
      $erro = "Desculpe!, mais o seu email esta invalido!!"; 
    } 
     
    if (!$erro){ #Sen�o exite erros ! Procura o email no banco de dados 
     
        $conectar = mysql_connect($bd_host, $bd_user, $bd_pass) or die (mysql_error()); 

        mysql_select_db($bd_banco_de_dados, $conectar); 

        $sql = mysql_query("SELECT * FROM $tabela WHERE email = '$email'"); 


        $total = mysql_num_rows($sql);  # Conta quantos emails foram encontrados na busca -- query! 


        if ($total == 1){ # Se o total de emial for igual a 1 ele envia a senha por email se for diferente de 1   
                          # Envia uma msg de erro !         
         
        while($l = mysql_fetch_array($sql)) { 

        # Aqui voc� deve colocar os dados que voc� quer retirar da tabela do Banco de dados 
        # Aqui eu retirei os campos usuario, nome, e senha, Basta voc� mudar os dados $l[x]; onde x = qualquer campo # do seu banco de dados ! 
          
        $enivar = "Lembrar Senha!!! ".$nomedosite."\n"; 
        $enivar .= $l[nick]; 
        $enviar .= "\n"; 
        $enviar .= $l[nome]; 
        $enviar .= "\n"; 
        $enviar .= $l[senha]; 

        # exemplo: se quiser mais campos fa�a assim : 
        #  $enviar .= $l[endereco]; 
        #  $enviar .= "\n"; 
        #  $enviar .= $l[telefone]; 


        } 
        $enviar .= "\n"; 
        $enviar .= "Obrigado!!\n\n Abra�os do WebMaster: ".$nome_webmaster."\n\n"; 
        $enviar .= "                      ".$linkdosite."\n"; 
        $enviar .= " \n"; 
        $enviar .= "        Webmaster: ".$email_do_webmaster."\n"; 
        
        mail("$email", "[$nomedosite][Lembrar Senha]", $enviar,"From: $email_do_webmaster <$nomedosite>\n"); 

        $erro = "Sua senha foi enviada para sua conta de email com sucesso! Obrigado !"; 
         
        }else{ 

        $erro = "Desculpe! Seu e-mail n�o esta cadastrado em nosso site ou Talves voc� tenha se cadastrado com outro          email! "; 
        } 
    } 
     
} 
?> 
<form method="post" action="<?  echo $PHP_SELF; ?>"> 
  <div align="left"> 
    <? if ($erro){ echo $erro; } # Msg de erro de acordo com o erro ! ?> 
    <p><font color="#000000"><b>Lembrar Senha</b></font></p> 
    <p><b><font color="#000000">e-mial:</font></b> 
      <input type="text" name="email"> 
    </p> 
    <p> 
      <input type="submit" name="submit" value="Enviar" width="150"> 
    </p> 
  </div> 
</form> 