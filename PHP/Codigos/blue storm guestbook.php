//**************************************
    //     
    // Name: blue storm guestbook
    // Description:by chujian
    // By: PHP Code Exchange
    //**************************************
    //     
    
    <html> 
    <head> 
    <title>��ɫ�籩���Ա�</title> 
    <style> 
    <!-- 
    A:link {text-decoration: none ; color:0000ff} 
    A:visited {text-decoration: none; color:004080} 
    A:active {text-decoration: none} 
    A:hover {text-decoration: underline; color:ff0000} 
    --> 
    </style> 
    <body bgcolor=#FFFFCC> 
    <center><IMG SRC="images/1(1).gif"></center> 
    <div align="center"> 
    <center> 
    <table border="1" width="39%" height="19" cellspacing="0" cellpadding="0" bordercolorlight="#000000"> 
    <tr> 
    <td width="100%" colspan="2" height="16"> 
    <p align="center"><b><font color="#00FF00" size="4">��д�������</font></b></td> 
    </tr> 
    <tr> 
    <td width="41%" height="19" valign="bottom"> 
    <p align="center"><font size="2" color="#00FF00">����</font></td> 
    </center> 
    <td width="81%" height="19" rowspan="4"> 
    <form method="POST" action="2.php"> 
    <p align="left"><font color="#00FF00"><input type="text" name="name" size="20"><br> 
    <input type="text" name="email" size="20"><br> 
    <select size="1" name="bq"> 
    <option value="">��ѡ��������Ա���</option> 
    <option value="images/m12.gif">��������</option> 
    <option value="images/m1.gif">��Ц</option> 
    <option value="images/m10.gif">���Խ�</option> 
    <option value="images/m11.gif">�Һ���ѽ</option> 
    <option value="images/m13.gif">�ÿ���Ŷ</option> 
    <option value="images/m14.gif">��������</option> 
    <option value="images/m15.gif">�ÿ�ЦŶ</option> 
    <option value="images/m16.gif">��ŭ</option> 
    <option value="images/m3.gif">�ÿ���ѽ</option> 
    <option value="images/m4.gif">����</option> 
    <option value="images/m5.gif">���</option> 
    <option value="images/m6.gif">O K</option> 
    <option value="images/m7.gif">����Ϣ</option> 
    <option value="images/m8.gif">�Һû�</option> 
    <option value="images/m9.gif">�ܿ�</option> 
    <option value="images/m2.gif">���ҵ�</option> 
    </select><br> 
    <textarea rows="4" name="message" cols="28"></textarea><br> 
    <input type="submit" value="����" name="B1">                 
    <input type="reset" value="��д" name="B2"></font></p> 
    </form> 
    </td> 
    </tr> 
    <center> 
    <tr> 
    <td width="41%" height="13" valign="bottom"> 
    <p align="center"><font size="2" color="#00FF00">���ö�</font></td> 
    </tr> 
    <tr> 
    <td width="41%" height="7" valign="bottom"> 
    <p align="center"><font size="2" color="#00FF00">����</font></td> 
    </tr> 
    <tr> 
    <td width="41%" height="96" valign="top"> 
    <p align="center"><b><font color="#00FF00"><br> 
    ��<br> 
    ��<br> 
    ��<br> 
    ��</font></b></td> 
    </tr> 
    </table> 
    </center> 
    </div> 
    <hr> 
    <? 
    $fp = fopen( "guest.txt", "r"); 
    $print = fread($fp,filesize( "guest.txt")); 
    fclose($fp); 
    print "$print"; 
    ?> 
    <center><b><font color=red>Copyright� 2000</font> by <a href="mailto:chujian@990.net">bigmouse</a></center></b> 
    </body> 
    </html>
