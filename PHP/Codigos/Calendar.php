//**************************************
    //     
    // Name: Calendar Class
    // Description:To create a navigable cal
    //     endar which can be easily hooked into a 
    //     database.
    // By: Louie Simpson
    //
    //This code is copyrighted and has    // limited warranties.Please see http://
    //     www.Planet-Source-Code.com/xq/ASP/txtCod
    //     eId.279/lngWId.8/qx/vb/scripts/ShowCode.
    //     htm    //for details.    //**************************************
    //     
    
    <? 
    class calendar { 
    //Sets up some class vars 
    var $month; 
    var $year; 
    var $firstdayofmonth; 
    var $lastdayofmonth; 
    var $numdays; 
    var $days; 
    var $monthname; 
    //The constructor class gets pertinent d
    //     ates and set them to the class vars 
    function calendar() { 
    global $month, $year; 
    //If the month isn't set set it top the 
    //     current month 
    if ($month == "") $month = DATE("m"); 
    $this->month = $month; 
    //If the year isn't set set it top the c
    //     urrent month 
    if ($year == "") $year = DATE("Y"); 
    $this->year = $year; 
    //This gets the number of days in the cu
    //     rrent month 
    $this->numdays = date("t", mktime(0,0,0,$this->month, DATE("d"), $this->year)); 
    //This gets the month name for current m
    //     onth 
    $this->monthname = date("F", mktime(0,0,0,$this->month, DATE("d"), $this->year)); 
    //This gets the first day of the month 
    $this->firstdayofmonth = DATE("D", mktime(0,0,0,$this->month, 1, $this->year)); 
    //This gets the last day of the month 
    $this->lastdayofmonth = DATE("D", mktime(0,0,0,$this->month, $this->numdays, $this->year)); 
    //This assigns the daynames to an array 
    //     for use later 
    $this->days = array("Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"); 
    } 
    //This sets some user defined cosmetic v
    //     ars 
    function set_attributes($colsize, $daycolor, $linkcolor, $bgcolor, $linksize, $daysize, 
    $headersize, $headercolor, $headerweight, $dayheight, $fontface) { 
    $this->daycolor = $daycolor; 
    $this->linkcolor = $linkcolor; 
    $this->bgcolor = $bgcolor; 
    $this->linksize = $linksize; 
    $this->daysize = $daysize; 
    $this->headersize = $headersize; 
    $this->headercolor = $headercolor; 
    $this->headerweight = $headerweight; 
    $this->colsize = $colsize / 7; 
    $this->fontface = $fontface; 
    $this->dayheight = $dayheight; 
    } 
    //Get the number of the firstday of the 
    //     month like 1 for Sunday, 2 for Monday, e
    //     tc.... 
    function getfirst() { 
    //Reset the $days array 
    reset($this->days); 
    //Loop through the $days array and look 
    //     for a match for the 
    //firstdayofmonth and then assign the ke
    //     y to var $colspan 
    while(list($key,$val) = each ($this->days)) { 
    if ($this->firstdayofmonth == $val) { 
    $colspan = $key; 
    } 
    } 
    return $colspan; 
    } 
    function getlast() { 
    //Reset the $days array 
    reset($this->days); 
    //Loop through the $days array and look 
    //     for a match 
    //for the lastdayofmonth and then assign
    //     the key to var $remainder 
    while(list($key,$val) = each ($this->days)) { 
    if ($this->lastdayofmonth == $val) { 
    $remainder = 6 - $key; 
    } 
    } 
    return $remainder; 
    } 
    //This function creates the link for the
    //     previous year 
    function prev_year() { 
    global $PHP_SELF; 
    return sprintf('<a href="%s?month=%s&year=%s" 
    style="font-family:%s;text-decoration:none; 
    color:%s; font-size:%spx">%s</a>', $PHP_SELF, 
    $this->month, $this->year - 1, $this->fontface, 
    $this->linkcolor, $this->linksize, 
    $this->year - 1); 
    } 
    //This function creates the link for the
    //     next year 
    function next_year() { 
    global $PHP_SELF; 
    return sprintf('<a href="%s?month=%s&year=%s" 
    style="font-family:%s;text-decoration:none; 
    color:%s; font-size:%spx">%s</a>', $PHP_SELF, $this->month, 
    $this->year + 1, $this->fontface, $this->linkcolor, 
    $this->linksize, $this->year + 1); 
    } 
    //This function creates the link for the
    //     previous month 
    function prev_month() { 
    global $PHP_SELF; 
    //Check to see if the month is not Janua
    //     ry 
    if ($this->month > 1) { 
    $prevm = sprintf('<a href="%s?month=%s&year=%s" 
    style="font-family:%s;text-decoration:none; 
    color:%s; font-size:%spx"><<</a> ', 
    $PHP_SELF, $this->month - 1, $this->year, $this->fontface, 
    $this->linkcolor, $this->linksize); 
    } 
    //If it is January our prev link will be
    //     December of the previous year 
    else { 
    $prevm = sprintf('<a href="%s?month=%s&year=%s" 
    style="font-family:%s;text-decoration:none; 
    color:%s; font-size:%spx"><<</a> ', 
    $PHP_SELF, 12, $this->year - 1, $this->fontface, 
    $this->linkcolor, $this->linksize); 
    } 
    return $prevm; 
    } 
    //This function creates the link for the
    //     next month 
    function next_month() { 
    global $PHP_SELF; 
    //Check to see if the month is not Decem
    //     ber 
    if ($this->month < 12) { 
    $nextm = sprintf(' <a href="%s?month=%s&year=%s" 
    style="font-family:%s;text-decoration:none; 
    color:%s; font-size:%spx">>></a>', 
    $PHP_SELF, $this->month + 1, $this->year, 
    $this->fontface, $this->linkcolor, $this->linksize); 
    } 
    //If it is December our next link will b
    //     e January of the next year 
    else { 
    $nextm = sprintf(' <a href="%s?month=%s&year=%s" 
    style="font-family:%s;text-decoration:none; 
    color:%s; font-size:%spx">>></a>', 
    $PHP_SELF, 1, $this->year + 1, $this->fontface, 
    $this->linkcolor, $this->linksize); 
    } 
    return $nextm; 
    } 
    //This is the main function and the one 
    //     that generates the html for the calendar
    //     
    function make_calendar() { 
    $result .= sprintf('<table bgcolor="%s" width=%s border=0 
    cellspacing="0"cellpadding="4">', $this->bgcolor, 
    $this->colsize * 7); 
    $result .= sprintf('<tr><td width="%s">%s</td><td colspan=5 
    align=center width="%s">%s<span style="font-family:%s; 
    font-size:%s;color:%s;font-weight:%s">%s 
    </span>%s</td><td width="%s">%s</td></tr>%s', 
    $this->colsize, $this->prev_year(), $this->colsize * 5, 
    $this->prev_month(), $this->fontface, $this->headersize, 
    $this->headercolor, $this->headerweight, $this->monthname, 
    $this->next_month(), $this->colsize, $this->next_year(), "\n"); 
    $result .= '<tr align="center">'; 
    //Reset the $days array 
    reset($this->days); 
    //Loop through the days array and create
    //     a cell for each day 
    for($i=0;$i<count($this->days);$i++) { 
    $result .= sprintf('<td width="%s"><span style=" 
    font-family:%s;font-size:%s;color:%s; 
    font-weight:%s">%s</span></td>', $this->colsize, 
    $this->fontface, $this->headersize, $this->headercolor, 
    $this->headerweight, $this->days[$i]); 
    } 
    $result .= '</tr><tr align="center">'."\n"; 
    //This sets the offset for the first day
    //     of the onth in the calendar 
    if ($this->getfirst() > 0) { 
    $result .= sprintf('<td colspan=%s height="%s"> 
    </td>', $this->getfirst(), 
    $this->dayheight); 
    } 
    //This is the day counter 
    $count = $this->getfirst() + 1; 
    //This loops runs through the number fo 
    //     days in the month 
    for($j=1;$j<=$this->numdays;$j++) { 
    //Create the cells for the indivdual day
    //     s 
    //Divide the current count by 7 if there
    //     is no remainder we no we need 
    //to end the row and start a new one 
    if (is_int($count/7)) { 
    $result .= sprintf('<td height="%s"><span style=" 
    font-family:%s;font-size:%s;color:%s">%s</span> 
    </td></tr><tr align="center">%s', $this->dayheight, 
    $this->fontface, $this->daysize, $this->daycolor, 
    $j, "\n"); 
    } 
    //Or elese we just print a row 
    else { 
    $result .= sprintf('<td height="%s"><span style=" 
    font-family:%s;font-size:%s;color:%s">%s</span> 
    </td>', $this->dayheight, $this->fontface, 
    $this->daysize, $this->daycolor, $j); 
    } 
    //INcrement the day counter 
    $count++; 
    } 
    //Check to see if there are left over sp
    //     aces to fill up the week if so make 
    //a cell with colspan set to that number
    //     of spaces 
    if ($this->getlast() > 0) { 
    $result .= sprintf('<td colspan=%s height="%s"> </td>%s 
    ', $this->getlast(), $this->dayheight, "\n"); 
    } 
    //End the cell 
    $result .= sprintf('</tr></table>'); 
    return $result; 
    } 
    } 
    //Sample 
    //Instaniate the calendar class 
    $cal = new calendar; 
    //This will set look and feel for the ca
    //     lendar 
    /* 
    1st argument is the width of the calendar and should be divisble by 7 
    2nd argument is the font color for the numbered days in the calendar 
    3rd argument is the link color 
    4th argument is the background color for the calendar 
    5th argument is the font size for the link in pixels 
    6th argument is the font size for the numbered days in pixels 
    7th argument is the font size for the day header and month name in pixels 
    8th argument is the font color for the day header and month name 
    9th argument is the font weight for the day header and month name 
    10th argument is the height of the cells that contain the days 
    11th argument is the font face for the calendar 
    */ 
    $cal->set_attributes(210, "#000000", "#ff0000", "#cccccc", 
    11, 11, 12, "navy", "bold", 
    20, "Arial, Helvetica, Sans-Serif"); 
    //Print the calendar 
    print $cal->make_calendar(); 
    ?>
