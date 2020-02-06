    //**************************************
    //     
    // Name: Bar Charts of arbitrary size
    // Description:Both PHP2 and PHP3 versio
    //     ns are now available. This code creates 
    //     bar charts of arbirary size, color and n
    //     umber. It works with gd1.2 and 1.3 Full 
    //     description at http://www.jeo.net/php/ b
    //     y Afan Ottenheimer
    // By: PHP Code Exchange
    //**************************************
    //     
    
    <?php
    /* Copyright (C) 1998 Afan Ottenheimer, afan@jeonet.com
    This is distributed with NO WARRANTY and under the terms of the GNU GPL.
    There is one exception - a license is required if this is incorporated 
    into, or sold or distributed with a Microsoft product.
    You can get a copy of the GNU GPL at http://www.gnu.org/copyleft/gpl.html
    */
    /* Some comments about the program: 
    This creates a chart with the thought that the X axis is 
    labeled array and the Y axis is real numbers. The Y axis uses a
    conversion between graph and data units called n_max_y.
    The X axis has no such conversion. Each x-axis-tick can get its
    own label xlab[N], where N= an integer.
    */
    /* READ DATA HERE */
    $maxy = $maxy_in;
    if ($maxy == 0) {
    echo "Error Max Y = 0 <p>";
    exit;
    }
    SetType($maxy,"double");
    /* The x-axis is divided up into $maxx sections going from 0 to $maxx-1 */
    $maxx = $maxx_in;
    if ($maxx <= 0) {
    echo "error maxx <= 0 <p>";
    exit;
    }
    SetType($maxx,"double");
    $XSIZE = $XSIZE_in; /* full width of the image in pixels */
    SetType($XSIZE,"double");
    $YSIZE = $YSIZE_in; /* Full height of the image in pixels */
    SetType($YSIZE,"double");
    $num_vert_ticks = $num_vert_ticks_in;
    if ($num_vert_ticks <= 0) {
    echo "error num_vert_ticks <= 0 <p>";
    exit;
    }
    SetType($num_vert_ticks,"double");
    $y_title = $y_title_in;
    $x_title = $x_title_in;
    /* *********END DATA ********** */
    /* We have the Header/Content-type after any error messages that might occur */
    Header("Content-Type: image/gif"); 
    $x_tot_margin = 100.0;
    SetType($x_tot_margin,"double");
    $x_left_margin = 77.0; /* distance between left and start of x axis in pixels */
    SetType($x_left_margin,"double");
    /* The x-axis is divided up into $maxx sections going from 0 to $maxx-1 */
    $xscale = ($XSIZE - $x_tot_margin)/$maxx ; 
    SetType($xscale,"double");
    $y_top_margin = 14.0; /* Must be integer */
    SetType($y_top_margin,"double");
    $y_tot_margin = 80.0; /* Must be integer */
    SetType($y_tot_margin,"double");
    $yscale = ($YSIZE - $y_tot_margin)/$maxy; /* Maximum Height in Screen Units */
    SetType($yscale,"double");
    $y_bot_margin = $y_tot_margin - $y_top_margin;
    SetType($y_bot_margin,"double");
    /* The y-axis is divided up into sections going from 0 to $maxy */
    $y_tick_delta = $maxy / $num_vert_ticks;
    SetType($y_tick_delta,"double");
    $si_units[0] = ""; /* Not yet used */
    $si_units[1] = "k";
    $si_units[2] = "M";
    $si_units[3] = "G";
    $si_units[4] = "T";
    $small_font = 2; /* fonts = 1,2,3,4 or 5 */
    $small_font_width = 6.0; /* width in pixels */
    $small_font_height = 10.0; /* height in pixels */
    $tiny_font = 1;
    $c_blank[0] = "245";
    $c_blank[1] = "245";
    $c_blank[2] = "245";
    $c_light[0] = "194";
    $c_light[1] = "194";
    $c_light[2] = "194";
    $c_dark[0] = "100";
    $c_dark[1] = "100";
    $c_dark[2] = "100";
    $c_major[0] = "255";
    $c_major[1] = "0";
    $c_major[2] = "0";
    $c_grid[0] = "0";
    $c_grid[1] = "0";
    $c_grid[2] = "0";
    $col_in[0] = "0";
    $col_in[1] = "235";
    $col_in[2] = "12";
    $col_inm[0] = "0";
    $col_inm[1] = "166";
    $col_inm[2] = "33";
    $col_out[0] = "0";
    $col_out[1] = "94";
    $col_out[2] = "255";
    $col_outm[0] = "255";
    $col_outm[1] = "0";
    $col_outm[2] = "255";
    /* ################################################# */
    /* Some general definitions for the graph generation */
    $XSIZE = (($maxx*$xscale)+100);
    /* position the graph */
    /* translate x/y coord into pixel coord */
    old_function ytr $y (
    SetType($y,"double");
    global $maxy,$yscale,$y_top_margin;
    return ($maxy*$yscale+$y_top_margin-(($y)*$yscale));
    );
    old_function xtr $x (
    SetType($x,"double");
    global $maxx,$xscale,$growright,$x_left_margin;
    if ($growright) {
    $tmpret = ($maxx*$xscale+$x_left_margin-(($x)*$xscale)) ;
    } else {
    $tmpret = ($x_left_margin+(($x)*$xscale));
    }
    return($tmpret);
    );
    /* ################################################# */
    /* the graph is made ten pixels higher to acomodate the x labels */
    $graph = ImageCreate($XSIZE, $YSIZE);
    /* Use brush_out and brush_outm for ImageSetBrush valid only for GD v3 */
    /* 
    $brush_out = ImageCreate(1,2);
    $brush_outm = ImageCreate(1,2);
    $i_outm = ImageColorAllocate($brush_outm,$col_outm[0], $col_outm[1], $col_outm[2]); 
    $i_out = ImageColorAllocate($brush_out,$col_out[0], $col_out[1], $col_out[2]);
    */
    /* the first color allocated will be the background color. */
    $i_blank = ImageColorAllocate($graph,$c_blank[0],$c_blank[1],$c_blank[2]);
    $i_light = ImageColorAllocate($graph,$c_light[0],$c_light[1],$c_light[2]);
    $i_dark = ImageColorAllocate($graph,$c_dark[0],$c_dark[1],$c_dark[2]);
    /* ImageColorTransparent($graph, $i_blank); */
    /* ImageInterlace($graph, 1); */
    $i_grid = ImageColorAllocate($graph,$c_grid[0],$c_grid[1],$c_grid[2] );
    $i_major = ImageColorAllocate($graph,$c_major[0],$c_major_g,$c_major_b);
    $i_in = ImageColorAllocate($graph,$col_in[0], $col_in[1], $col_in[2]);
    $i_inm = ImageColorAllocate($graph,$col_inm[0], $col_inm[1], $col_inm[2]);
    /* draw the image border */
    ImageLine($graph,0,0,$XSIZE-1,0,$i_light);
    ImageLine($graph,1,1,$XSIZE-2,1,$i_light);
    ImageLine($graph,0,0,0,$YSIZE-1,$i_light);
    ImageLine($graph,1,1,1,$YSIZE-2,$i_light);
    ImageLine($graph,$XSIZE-1,0,$XSIZE-1,$YSIZE-1,$i_dark);
    ImageLine($graph,0,$YSIZE-1,$XSIZE-1,$YSIZE-1,$i_dark);
    ImageLine($graph,$XSIZE-2,1,$XSIZE-2,$YSIZE-2,$i_dark);
    ImageLine($graph,1,$YSIZE-2,$XSIZE-2,$YSIZE-2,$i_dark);
    /* draw the graph border */
    ImageRectangle($graph, xtr(0),ytr(0),xtr($maxx),ytr($maxy),$i_grid);
    /*create a dotted style for the grid lines*/
    /* Style not supported in PHP/FI2 ???
    $styleDotted[0] = $i_grid;
    $styleDotted[1] = Transparent;
    $styleDotted[2] = Transparent;
    ImageSetStyle($graph, $styleDotted, 3);
    */
    /* draw the horizontal grid */
    /* It would be great to know how wide the font is in pixels. In 
    C you would use "small_font->w" for GD. Here we guess as $small_font_width
    */
    ImageStringUp($graph, $small_font,8, ($small_font_width*strlen($y_title)/2.0) + ytr($maxy/2.0), $y_title, $i_grid);
    ImageString($graph, $small_font, -($small_font_width*strlen($x_title)/2.0) + xtr($maxx/2.0) , ($YSIZE - 3.0*$small_font_height), $x_title, $i_grid);
    $i = 0;
    /* Draw Vertical Ticks */
    while ($i<=$num_vert_ticks){
    $y_tmp = (DoubleVal($i)*$maxy/$num_vert_ticks);
    SetType($y_tmp,"double");
    ImageLine($graph,(-10+xtr(0)),ytr($y_tmp),xtr(1),ytr($y_tmp),$i_grid);
    ImageLine($graph,(xtr($maxx)+10),ytr($y_tmp),xtr($maxx-1),ytr($y_tmp),$i_grid);
    /* gdStyled only supported with GD v3 */
    /*ImageLine($graph,xtr(0),ytr($y_tmp),xtr($maxx),ytr($y_tmp),gdStyled); */
    ImageLine($graph,xtr(0),ytr($y_tmp),xtr($maxx),ytr($y_tmp),$i_light);
    $ylab = sprintf("%6.1f %s",$y_tick_delta*$i,$si_units[0]);
    /* 
    It would be great to know the font height in pixels. In 
    C you would use "small_font->h" for GD. Here we guess as $small_font_height
    */
    ImageString($graph, $small_font,($x_left_margin-54),( -($small_font_height/2.0) + ytr($y_tmp)),$ylab, $i_grid);
    $i++;
    } 
    /* draw vertical grid and horizontal labels */
    $x = 0;
    while ($x<$maxx) {
    if ($x_label[$x]) {
    ImageString($graph, $small_font,( -(strlen($x_label[$x]) * $small_font_width / 2.0) + xtr(0.5+$x)), ($YSIZE - $y_bot_margin + 1.5*$small_font_height) ,$x_label[$x], $i_grid);
    }
    if ($y_data[$x] ) { /* Draw a bar */
    ImageFilledRectangle($graph, xtr(0.25+$x), ytr($y_data[$x]), xtr(0.75+$x), ytr(0), $i_major);
    }
    /* FUN DEBUGGING STUFF BELOW */
    /*
    $tempmid = "mid";
    $tempajo = $x;
    ImageString($graph, $small_font, xtr($x), ytr(-1), $tempajo, $i_major);
    ImageString($graph, $small_font, (-((strlen($tempmid))* $small_font_width /2.0) + xtr((.5+$x)) ), ytr(-1), $tempmid, $i_major); 
    */
    /* END FUN DEBUGGING STUFF */
    $x++;
    } 
    ImageGif($graph);
    ImageDestroy($graph);
    /* 
    ImageDestroy($brush_out);
    ImageDestroy($brush_outm);
    */
    ?>

