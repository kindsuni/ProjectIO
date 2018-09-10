<?php
include 'include/connect.php';


$connect = mysqli_connect($localhost, $username, $password, $database);
echo "";
//$connect = new mysqli('localhost', 'root', 'autoset', 'unityaccess');
if($connect -> connect_error)
{
	echo "1 : Connection failed";
	exit();
}
$mode = $_POST["mode"];
$sql = $_POST["sql"];
$name = $_POST["name"];
$password = $_POST["password"];
$result = $connect->query($sql);
function check($_mode, $_result, $_name)
{	
	if ($_result ->num_rows > 0) 
	{
		$idx = 0;
		while ($fila = $_result->fetch_row()) 
		{
			$idx ++;			
			if($fila[1] == $_name)
			{
				if($_mode == 1)
				{
					echo "2 : UserName already exists";
					exit();
				}				
			}			
		}		
	}	
}
if($mode == 0)//Login
{
	check($mode,$result,$name);
	$namecheck = mysqli_query($connect, $sql) or die("2 : namecheckquery failed");
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
	$itemquery = mysqli_query($connect, $sql);
	$iteminfo = mysqli_fetch_assoc($itemquery);
	$itemsid = $iteminfo["id"];	
	//echo $itemsid;
	$idcheckquery = "SELECT * FROM items WHERE id = '".$itemsid."'";
	$idquery = mysqli_query($connect, $idcheckquery);
	//echo $idcheckquery;
	$idinfo = mysqli_fetch_assoc($idquery);
	$maxscore = $idinfo["maxscore"];

	echo "0\t". $maxscore;
}
if($mode == 1)//Register
{
	check($mode,$result,$name);
	$salt = "\$5\$rounds=5000\$" . "steamedhams" . $name. "\$";
	$hash = crypt($password , $salt);
	$insertuserquery = "INSERT INTO `players`(`username`, `hash`, `salt`) VALUES ('" . $name."','" . $hash."','". $salt."')";
	if($querycheck = $connect -> query($insertuserquery) == FALSE)
	{
		echo "Player Insert Failed";
		exit();
	}
	$itemquery = mysqli_query($connect, $sql);
	$iteminfo = mysqli_fetch_assoc($itemquery);
	$itemsid = $iteminfo["id"];
	$insertuserquery = "INSERT INTO `items`(`id`) VALUES ('". $itemsid."')";
	if($querycheck = $connect -> query($insertuserquery) == FALSE)
	{
		echo "Player items Insert failed";
		$mode = 2;	 		
	}
	else
	{
		echo "0";
	}
}
if($mode == 2)//Delete
{
	//check($mode);
	$itemquery = mysqli_query($connect, $sql);
	$iteminfo = mysqli_fetch_assoc($itemquery);
	$itemsid = $iteminfo["id"];	
	$deleteitems = "DELETE FROM items WHERE id = '".$itemsid."'";	
	$deleteplayer = "DELETE FROM players WHERE id = '".$itemsid."'";
	if($querycheck = $connect -> query($deleteitems) == FALSE || $querycheck2 = $connect -> query($deleteplayer) == FALSE)
	{
		echo "Player items Delete failed";	 
		exit();
	}	
	echo "0";
}
?>