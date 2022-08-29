<?php
$hostname = 'mysql.2122.lakeside-cs.org';
$username = 'student2122';
$password = 'm545CS42122';
$database = '2122project';


try 
{
	$dbh = new PDO('mysql:host='. $hostname .';dbname='. $database, $username, $password);
} 
catch(PDOException $e) 
{
	echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
}

$sth = $dbh->prepare('INSERT INTO Music_Game VALUES (:Username, :Wav, :Rating, :ID, :gameid)');

try 
{
		$sth->bindParam(':Username', $_GET['Username'], PDO::PARAM_STR);
		$sth->bindParam(':Wav', $_GET['Wav'], PDO::PARAM_STR);
		$sth->bindParam(':Rating', $_GET['Rating'], PDO::PARAM_INT);
		$sth->bindParam(':ID', $_GET['ID'], PDO::PARAM_INT);
		$sth->bindParam(':gameid', $_GET['gameid'], PDO::PARAM_INT);
		$sth->execute();
}

catch(Exception $e) 
{
	echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
}

?>