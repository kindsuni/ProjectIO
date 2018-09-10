<?php

$connect = new mysqli('localhost', 'root', 'autoset', 'unityaccess');


if($connect -> connect_error)
{
	echo "1 : Connection failed";
	exit();
}


$username = $_POST["name"];
$password = $_POST["password"];

$namecheckquery = "SELECT * FROM players WHERE username = '".$username."'";
//$namecheckquery = "SELECT 'username' FROM players WHERE username = '".$username."'";
//echo $namecheckquery;

$result = $connect->query($namecheckquery);

if ($result ->num_rows > 0) 
{
	while ($fila = $result->fetch_row()) 
	{
		$idx = 0;
		//printf("RowCout:%d -",count($fila));
		//printf ("%s (%s)\n", $fila[1], $username);
		if($fila[1] == $username)
		{
			echo "2 : UserName already exists";
			exit();
		}
		//print_r($fila);
//echo "<br>";
	}
	/* free result set */
    //$result->close();
}

$salt = "\$5\$rounds=5000\$" . "steamedhams" . $username. "\$";
$hash = crypt($password , $salt);
$insertuserquery = "INSERT INTO `players`(`username`, `hash`, `salt`) VALUES ('" . $username."','" . $hash."','". $salt."')";

//mysqli_query($con, $insertuserquery) or die("4 : Insert player query failed");
if($querycheck = $connect -> query($insertuserquery) == FALSE)
{
	echo "Player Insert Failed";
	exit();
}

$itemquery = mysqli_query($connect, $namecheckquery);
$iteminfo = mysqli_fetch_assoc($itemquery);
$itemsid = $iteminfo["id"];
$insertuserquery = "INSERT INTO `items`(`id`) VALUES ('". $itemsid."')";
if($querycheck = $connect -> query($insertuserquery) == FALSE)
{
	echo "Player items Insert failed";	 
	exit();
}

echo "0";
?>