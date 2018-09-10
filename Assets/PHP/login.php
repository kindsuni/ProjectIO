<?php

 $connect = new mysqli('localhost', 'root', 'autoset', 'unityaccess');

if($connect -> connect_error)
{
	echo "1 : Connection failed";
	exit();
}

$username =$_POST["name"]; //"todays21";
$password =$_POST["password"]; //"password";

$namecheckquery = "SELECT * FROM players WHERE username = '".$username."'";

$namecheck = mysqli_query($connect, $namecheckquery) or die("2 : namecheckquery failed");


if(mysqli_num_rows($namecheck)!= 1)
{
	echo "'".mysqli_num_rows($namecheck)."'";
	echo "5 : Either no user with name or more than one";
	exit();
}
$existinfo = mysqli_fetch_assoc($namecheck);
$salt = $existinfo["salt"];
$hash = $existinfo["hash"];

//echo "'". $salt."'";

$loginhash = crypt($password, $salt);

if($hash != $loginhash)
{
	echo "6 : Incorrect password";
	exit();
}

echo "0";





?>