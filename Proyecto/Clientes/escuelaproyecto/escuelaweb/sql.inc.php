<?php
include 'adodb5/adodb.inc.php';
$db = ADONewConnection('mssqlnative');
$db->connect('DESKTOP-F164C7L\SQLEXPRESS','','','escuela') or die("Error");
return $db;
?>