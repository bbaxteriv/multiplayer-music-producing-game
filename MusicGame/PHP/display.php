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
 
$sth = $dbh->query('SELECT * FROM Music_Game ORDER BY Rating DESC LIMIT 5');
$sth->setFetchMode(PDO::FETCH_ASSOC);
 
$result = $sth->fetchAll();
 
if (count($result) > 0) 
{
	foreach($result as $r) 
	{
		echo $r['Username'], "_";
		echo $r['Wav'], "_";
		echo $r['Rating'], "_";
		echo $r['ID'], "_";
		echo $r['gameid'], "_";
	}
}
?>