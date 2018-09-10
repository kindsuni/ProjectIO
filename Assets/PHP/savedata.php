<?php

$connect = new mysqli('localhost', 'root', 'autoset', 'unityaccess');

if($connect -> connect_error)
{
	echo "1 : Connection failed";
	exit();
}

$username = $_POST["name"];
$newscore = $_POST["coin"];

$namecheckquery = "SELECT * FROM players WHERE username = '".$username."'";

$namecheck = mysqli_query($connect, $namecheckquery) or die("2 : namecheckquery failed");

if(mysqli_num_rows($namecheck)!= 1)
{
	echo "'".mysqli_num_rows($namecheck)."'";
	echo "5 : Either no user with name or more than one";
	exit();
}
$iteminfo = mysqli_fetch_assoc($namecheck);
$id = $iteminfo["id"];
//$itemcheckquery = "SELECT * FROM items WHERE id = '".$id."'";
$updatequery = "UPDATE items SET coin = ". $newscore. " WHERE id = '" . $id."'";

mysqli_query($connect,$updatequery) or die("7: Save query failed");

echo "0";


















?>