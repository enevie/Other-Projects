

<?php
     $to = "yosif.enev@gmail.com";
     $name = $_GET['name'];
     $mail = $_GET['mail'];
     $message = $_GET['feedback'];
     $headers ="From:$mail";
     $sent = mail($to, $mail, $message,$headers);
     if($sent){
     	echo '<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />';
     	echo '<a href="http://tsankova.eu.pn">'.'Your massage has been sent, please click here to return.'.'</a>';
     }

     ?>

