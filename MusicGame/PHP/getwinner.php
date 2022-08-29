<?php
$hostname = 'mysql.2122.lakeside-cs.org';
$username = 'student2122';
$password = 'm545CS42122';
$database = '2122project';

try
{
	$dbh = new PDO('mysql:host='. $hostname .';dbname='. $database,
         $username, $password);
}
catch(PDOException $e)
{
	echo '<h1>An error has occurred.</h1><pre>', $e->getMessage()
            ,'</pre>';
}

$sth1 = $dbh->query('SELECT id FROM music_game_players WHERE game_id = (:g_id)');
$sth1->bindParam(':g_id', $_GET['g_id'], PDO::PARAM_STR);
$sth1->setFetchMode(PDO::FETCH_ASSOC);

$result = $sth1->fetchAll();

$highRat = 0;
$bestID = NULL;

if (count($result) > 0)
{
  foreach($result as $r)
	{
    $sth2 = $dbh->query('SELECT rating FROM music_game_ratings WHERE player_id = (:id)');
    $sth2->bindParam(':id', $r['id'], PDO::PARAM_STR);
    $sth2->setFetchMode(PDO::FETCH_ASSOC);

    $ratings = $sth2->fetchAll();

    $sum = 0;
    $count = 0;

    foreach($ratings as $rat)
    {
      $sum += $rat['rating'];
      $count += 1;
    }

    $rating = $sum / $count;
    if ($rating > $highRat)
    {
      $highRat = $rating;
      $bestID = $r['id'];
    }
	}
}

$sth3 = $dbh->query('SELECT name FROM music_game_players WHERE id = (:id)');
$sth3->bindParam(':id', $bestID, PDO::PARAM_STR);
$sth3->setFetchMode(PDO::FETCH_ASSOC);

$names = $sth3->fetchAll();
if (count($names) > 0)
{
	echo $names[0]['name'];
}
?>
