<html>

<head>

<SCRIPT type="text/javascript">
<!--

/*****************************************
* Open links in new window Script- By spk100 (spk100@yahoo.com)
* Script featured on/available at Dynamic Drive- http://www.dynamicdrive.com/
* Modified by DD. This notice must stay intact for use
*****************************************/

//Enter "_blank" for new window (each time), "window2" for a set secondary window
var newwindow="_blank"

function hyperlinks(target){
if (target) where = newwindow;
else where = "_self";
for (var i=0; i<=(document.links.length-1); i++){
var linkobj=document.links[i].href
if ( linkobj.indexOf("javascript:") ==-1 && linkobj.indexOf("#") ==-1){
if (target && where!="_blank") //DynamicDrive.com added routine- open window in set secondary window
document.links[i].onclick=function(){
if (window.window2 && !window2.closed)
window2.location=this.href
else
window2=window.open(this.href)
window2.focus()
return false
}
else{
if (newwindow=="window2") document.links[i].onclick = ""; 
document.links[i].target = where;
}
}
}
}

function inithyperlinks(){ //DynamicDrive.com added routine
if (document.targetform.targetnew.checked)
hyperlinks(true)
}

window.onload=inithyperlinks

// -->
</SCRIPT>

</head>

<body>

<FORM name="targetform"><INPUT TYPE="checkbox" NAME="targetnew" ONCLICK="hyperlinks(this.checked)" checked> <b>Open links in secondary window</b></FORM>

</body>

</html>