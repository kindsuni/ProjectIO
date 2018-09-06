//<?php

//$connect = new mysqli('localhost', 'root', 'autoset', 'unityaccess');


//if($connect -> connect_error)
//{
//	echo "1 : Connection failed";
//	exit();
//}


//$username = $_POST["name"];
//$password = $_POST["password"];

//$namecheckquery = "SELECT * FROM players WHERE username = '".$username."'";
////$namecheckquery = "SELECT 'username' FROM players WHERE username = '".$username."'";
////echo $namecheckquery;

//if ($result = $connect->query($namecheckquery)) 
//{
//	while ($fila = $result->fetch_row()) 
//	{
//		$idx = 0;
//		//printf("RowCout:%d -",count($fila));
//		//printf ("%s (%s)\n", $fila[1], $username);
//		if($fila[1] == $username)
//		{
//			echo "2 : UserName already exists";
//			exit();
//		}
//		print_r($fila);
//echo "<br>";		
//	}

//	/* free result set */
//    $result->close();
//}

//$salt = "\$5\$rounds=5000\$" . "steamedhams" . $username. "\$";
//$hash = crypt($password , $salt);
//$insertuserquery = "INSERT INTO `players`(`username`, `hash`, `salt`) VALUES ('" . $username."','" . $hash."','". $salt."')";
////mysqli_query($con, $insertuserquery) or die("4 : Insert player query failed");
//if($querycheck = $connect -> query($insertuserquery) ==FALSE)
//{
//	exit();
//}
//echo "0";


//?>











//<?php

// $connect = new mysqli('localhost', 'root', 'autoset', 'unityaccess');

//if($connect -> connect_error)
//{
//	echo "1 : Connection failed";
//	exit();
//}

//$username =$_POST["name"]; //"todays21";
//$password =$_POST["password"]; //"password";

//$namecheckquery = "SELECT * FROM players WHERE username = '".$username."'";

//$namecheck = mysqli_query($connect, $namecheckquery) or die("2 : namecheckquery failed");


//if(mysqli_num_rows($namecheck)!= 1)
//{
//	echo "'".mysqli_num_rows($namecheck)."'";
//	echo "5 : Either no user with name or more than one";
//	exit();
//}
//$existinfo = mysqli_fetch_assoc($namecheck);
//$salt = $existinfo["salt"];
//$hash = $existinfo["hash"];

////echo "'". $salt."'";

//$loginhash = crypt($password, $salt);

//if($hash != $loginhash)
//{
//	echo "6 : Incorrect password";
//	exit();
//}

//echo "0\t" . $existinfo["score"];





//?>