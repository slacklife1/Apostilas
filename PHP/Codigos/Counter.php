//**************************************
    //     
    // Name: A cool Counter
    // Description:This is a simple counter 
    //     that doesn't need any editing. If you wa
    //     nt the better version, which is free, go
    //     to http://ddkresource.cjb.com
    // By: Driss Kaitouni
    //
    //This code is copyrighted and has    // limited warranties.Please see http://
    //     www.Planet-Source-Code.com/xq/ASP/txtCod
    //     eId.352/lngWId.8/qx/vb/scripts/ShowCode.
    //     htm    //for details.    //**************************************
    //     
    
    <?php
    $img = "";
    $animated_img = "";
    $padding = 4;
    $width = 16;
    $height = 22;
    $fpt = "acount.txt";
    $lock_ip =0;
    $ip_lock_timeout =30;
    $fpt_ip = "ip.txt";
    function checkIP($rem_addr) {
    global $fpt_ip,$ip_lock_timeout;
    $ip_array = file($fpt_ip);
    $reload_dat = fopen($fpt_ip,"w");
    $this_time = time();
    for ($i=0; $i<sizeof($ip_array); $i++) {
    list($ip_addr,$time_stamp) = split("\|",$ip_array[$i]);
    if ($this_time < ($time_stamp+60*$ip_lock_timeout)) {
    if ($ip_addr == $rem_addr) {
    $found=1;
    } else {
    fwrite($reload_dat,"$ip_addr|$time_stamp");
    }
    }
    }
    fwrite($reload_dat,"$rem_addr|$this_time\n");
    fclose($reload_dat);
    return ($found==1) ? 1 : 0;
    }
    if (!file_exists($fpt)) {
    $count_dat = fopen($fpt,"w+");
    $digits = 0;
    fwrite($count_dat,$digits);
    fclose($count_dat);
    }
    else {
    $line = file($fpt);
    $digits = $line[0];
    if ($lock_ip==0 || ($lock_ip==1 && checkIP($REMOTE_ADDR)==0)) {
    $count_dat = fopen($fpt,"r+");
    $digits++;
    fwrite($count_dat,$digits);
    fclose($count_dat);
    }
    }
    $digits = sprintf ("%0".$padding."d",$digits);
    $ani_digits = sprintf ("%0".$padding."d",$digits+1);
    echo "<table cellpadding=0 cellspacing=0 border=0><tr align=center>\n";
    $length_digits = strlen($digits);
    for ($i=0; $i < $length_digits; $i++) {
    if (substr("$digits",$i,1) == substr("$ani_digits",$i,1)) {
    $digit_pos = substr("$digits",$i,1);
    echo ("<td><img src=$img$digit_pos.gif width=$width height=$height></td>\n");
    } else {
    $digit_pos = substr("$ani_digits",$i,1);
    echo ("<td><img src=$animated_img$digit_pos.gif width=$width height=$height></td>\n");
    }
    }
    echo "</tr></table>\n";
    ?>

