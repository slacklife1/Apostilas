<html>

<body onload="position_at_top();expand()">
<div style="position:absolute;color:black" id="test"></div>

<script>

//This script created by Steve Bomer (steveb03@yahoo.com)
//Modified by Dynamic Drive for NS6, additional features
//Visit Dynamicdrive.com to get it!

//Change the message below
var themessage="Welcome to Dynamic Drive!"
var fontsize=10
//Below determines how long the message will appear before disappearing. 3000=3 seconds
var appearfor=3000

function position_at_top(){
if (document.layers)
document.test.top=pageYOffset
else if (document.all){
test.innerHTML='<div align=center><font face="Arial">'+themessage+'</font></div>'
setTimeout("test.style.top=document.body.scrollTop+10;test.style.left=document.body.scrollLeft+10",100)
}
else if (document.getElementById){
document.getElementById("test").innerHTML='<div align=center><font face="Arial">'+themessage+'</font></div>'
document.getElementById("test").style.top=pageYOffset
}
}

function expand(){
if (document.layers){
document.test.document.write('<div align=center style="font-size:'+fontsize+'px"><font face="Arial">'+themessage+'</font></div>')
document.test.document.close()
}
else if (document.all)
test.style.fontSize=fontsize+'px'
else if (document.getElementById)
document.getElementById("test").style.fontSize=fontsize+'px'
fontsize+=5
if (fontsize>90){
if (document.layers)
setTimeout("document.test.visibility='hide'",appearfor)
else if (document.all)
setTimeout("test.style.visibility='hidden'",appearfor)
else if (document.getElementById)
setTimeout("document.getElementById('test').style.visibility='hidden'",appearfor)
return
}
else
setTimeout("expand()",50)
}

</script>
</body>
</html>