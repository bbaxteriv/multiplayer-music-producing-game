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

$sth = $dbh->prepare('INSERT INTO music_game_games (name) VALUES (:name)');
try
{
		// Create new game
		$sth->bindParam(':name', $_GET['gamename'], PDO::PARAM_STR);
		$sth->execute();
}
catch(Exception $e)
{
		echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
}

?>
