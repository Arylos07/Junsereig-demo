<?php
	$servername = "localhost";
	$username = "templari_Main";
	$password = "Junsereig7";
	$dbName = "templari_Main";
	
	$user_username = $_POST["usernamePost"];
	$user_password = $_POST["passwordPost"];

	//Make Connection
	$conn = new mysqli($servername, $username, $password, $dbName);
	//Check Connection
	if(!$conn)
	{
		die("Connection Failed. ". mysqli_connect_error());
	}
	echo "Connection made";
	$sql = "SELECT user_pass FROM wpej_users WHERE user_login = '".$user_username."' ";
	
	//Get result and confirm login
	if(mysqli_num_rows($result) > 0){
		//show data for each row
		while($row = mysqli_fetch_assoc($result)){
			if($row['user_pass'] == $user_password){
				echo "Login success";
			}else{
				echo "password incorrect";
			}
		}
	}
	else{
		echo "user not found";
	}
?>