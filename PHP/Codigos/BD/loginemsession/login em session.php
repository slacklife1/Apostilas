<?PHP 

# ---------- Autor ----------------------------------> 
# 
# Script Desenvolvido por Anderson Brito em 18/12/2001 
# Nicks: Unixer, Anderson-RJ ou WebServ 
# ICQ: 43003071 
# Email: anderson-rj@linuxbr.com.br ou anderson@linuxclub.com.br 
# Site: http://www.linuxclub.com.br 
# ---------- Copy Right -----------------------------> 
# 
# Este Script pode ser usado e modificado onde voc� quiser!     
# S� quero que quando coloque este script em seu site ou em outros sites! 
# coloquem o meu nome corretamente e respeite a minha autoria deste! 
# Eu quero ajudar e acabam roubando o meu script e colocando o pr�prio 
# nome e nick! O que eu vi acontecer com o meu script de Sauda��es ao usu�rio 
# que trata de Bom-dia Boa Tarde Boa noite de acordo com o hor�rio! 
# Um Grande Abra�o a Todos! Anderson! 
# 
# ----------- Sobre o Script -----------------------> 
# 
# Script de Login de Session! 
# A session � registrada somente enquanto o usu�rio esta conectado ao site ou esta com o 
# navegador aberto apos isso ter� que se Logar novamente usando o seu nome de 
# logim e sua senha! 
# antes cadastrados no formul�rio de cadastramento! E armazenado no banco de 
# dados ou arquivo no servido! 
# Este script tr�s um exemplo de como fazer um session de login usando banco de dados mysql 
# Qualquer duvida envie um e-mail! 
# 
# ----------------------------------------------------> 

if ($submit){ /* Se o formul�rio for enviado ele entra nesta parte do script sen�o ele ira mostrar o          
                        formul�rio novamente at� ser enviado corretamente!! */ 


if ((!$usuario) || (!$senha)){ 

        $erro = "Desculpe! Mas voc� deixou algum campo em branco no formul�rio."; 
        
    }else{ 
         
        $bd_host = "host_do_banco_de_dados";      // Endere�o do servidor mySQL pode ser o localhost 
        $bd_user = "usuario_do_bd";                  // Seu Login no mySQL 
        $bd_pass = "senhado_do_bd";               // Sua Senha no mySQL 
        $bd_bd = "nome_do_banco_de_dados";        // Nome do Banco de Dados 

        /* Conecta ao Banco de Dados */ 
        $conectar = mysql_connect($bd_host, $bd_user, $bd_pass) or die (mysql_error()); 

        /* Seleciona o Banco de dados na conex�o do BD */ 
        mysql_select_db($bd_bd, $conectar); 

        /* Verifica se existe usu�rios com aquela senha digitada!! */ 
        $sql = mysql_query("SELECT * FROM usuarios WHERE usuario='$usuario' and senha='$senha'"); 

        /* Conta o numero de usu�rios com aquela senha */ 
        $total = mysql_num_rows($sql); 

        if ($total == 1){   /* Caso o numero de usu�rio com aquela senha for igual a 1 entra neste if */ 

            session_start("usuarios"); /* A session_start deve estar antes de qualquer codigo senao dar� erro !!                               e ele pode ter qualquer nome  */ 
             
            session_register("usuario","senha"); /* Registra o nome de usu�rio e a senha caso esteja correto */ 

            header("Location: ./site_protegido.php"); /* Redireciona o usu�rio para o php protegido */ 

            exit;  /* Finaliza este script aqui */ 

         
        /* 
            No Topo do PHP protegido que o usu�rio ser� redirecionado deve-se colocar isto para evitar engra�adinhos querendo pular a prote��o! 
             
            if(!(session_is_registered("usr") AND session_is_registered("pass"))){   
                
               echo "Area somente para usu�rios cadastrados!"; 
             
            }else{ 

               # Mostra o conteudo do site para o usu�rio !!!     

            } 
            
        */ 


        }else{ 
             
            $erro = "Desculpe! Mas voc� n�o � cadastrado ou esqueceu sua senha !! Cadastre-se J�!!."; 

        } 
    } 
} 
if($erro){ /* Se existir algum erro ele entra neste if e mostra o erro antes de mostrar o formul�rio novamente */ 
    echo $erro; 
} 
?> 
  <form name="form" action="login_em_session.php" method="POST" > 
  <p>Usuario: 
    <input type="text" name="usuario"> 
    Senha: 
    <input type="text" name="senha"> 
   <input type="submit" name="submit" value="ok"> 
  </p> 
  </form> 