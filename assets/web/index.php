<?php
#if (!isset($_SERVER['PHP_AUTH_USER'])) {
#    header('WWW-Authenticate: Basic realm="My Realm"');
#    header('HTTP/1.0 401 Unauthorized');
#    echo 'Authentification necessaire';
#    exit;
#} else {
#	if ($_SERVER['PHP_AUTH_PW']!="mmir2012"){
#   	 header('WWW-Authenticate: Basic realm="My Realm"');
#   	 header('HTTP/1.0 401 Unauthorized');
#   	 echo 'Authentification necessaire';
#   	 }
#   	else{

   	 echo '
   	 
   	 <body bgcolor="#FFFFFF">
   	 
   	 <center><br>
   	  	
   	  	--- La qu&ecircte du capitaine Woo ---<br><br><br>
   	  	<a href="http://www.ozwe.com/z/woo_quest.apk">
   	  	<img src="Andoid_pirate.jpeg" /><br><br>
   	  	<a href="http://www.ozwe.com/z/woo_quest.apk">Boite &agrave outils Android</a><br><br><br>  
   	  	-------------------------------------------------<br><br><br>
   	  	
   	  	<a href="itms-services://?action=download-manifest&url=http://www.ozwe.com/z/WooQuest.plist">
   	  	<img src="ios_pirate.jpg" /><br>
   	  	<a href="itms-services://?action=download-manifest&url=http://www.ozwe.com/z/WooQuest.plist">Boite &agrave outils iOS</a><br><br>   
		
   	  </center>;

		
   	  	'
#		}
#}
?>