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

$sth = $dbh->prepare('INSERT INTO music_game_ratings (rating, player_id) VALUES (:rating, :p_id)');
try
{
		// Create new game
		$sth->bindParam(':rating', $_GET['rating'], PDO::PARAM_STR);
    $sth->bindParam(':p_id', $_GET['p_id'], PDO::PARAM_STR);
		$sth->execute();
}
catch(Exception $e)
{
		echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
}

?>
