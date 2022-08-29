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


$sth = $dbh->prepare('SELECT id FROM music_game_games WHERE name = (:name) and id = (:id)');
try
{
		// Throw exception if game does not exist
		$sth->bindParam(':name', $_GET['gamename'], PDO::PARAM_STR);
		$sth->bindParam(':id', $_GET['id'], PDO::PARAM_STR);

		$sth->execute();
		$results = $sth->fetchAll();
		if (count($results) == 0)
		{
				throw new Exception('Game not found.'); // Will skip to catch exception
		}

		$sth = $dbh->prepare('SELECT name FROM music_game_players WHERE name = (:name) AND game_id = (:game_id)');
		try
		{
				// Throw exception if name in use
				$sth->bindParam(':name', $_GET['username'], PDO::PARAM_STR);
				$sth->bindParam(':game_id', $_GET['id'], PDO::PARAM_STR);
				$sth->execute();

				$results = $sth->fetchAll();
				if (count($results) != 0)
				{
						throw new Exception('Name in use.'); // Will skip to catch exception
				}



				$sth = $dbh->prepare('INSERT INTO music_game_players (name, game_id) VALUES(:name, :game_id)');
				try
				{
						// No problems so add new player to the database
						$sth->bindParam(':name', $_GET['username'], PDO::PARAM_STR);
						$sth->bindParam(':game_id', $_GET['id'], PDO::PARAM_STR);
						$sth->execute();
				}
				catch(Exception $e)
				{
					echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
				}
		}
		catch(Exception $e)
		{
			echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
		}
}
catch(Exception $e)
{
	echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
}
?>
