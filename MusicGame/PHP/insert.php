<?php
$playerID = $_POST["playerid"];
$conn = mysqli_connect('mysql.2122.lakeside-cs.org','student2122','m545CS42122','2122project');
$target_dir = "Upload/";
$base = basename($_FILES["fileToUpload"]["name"]);
$newBase = uniqid('', true).".".$base;
$target_file = $target_dir . $newBase;
$uploadOk = 1;
$imageFileType = strtolower(pathinfo($target_file,PATHINFO_EXTENSION));

// Check if $uploadOk is set to 0 by an error
if ($uploadOk == 0) {
  echo "Sorry, your file was not uploaded.";
// if everything is ok, try to upload file
} else {
  if (move_uploaded_file($_FILES["fileToUpload"]["tmp_name"], $target_file)) {
    //$query = "INSERT INTO music_game_players(music) VALUES ('asdf') WHERE name ==('calvin')";
    $query = "UPDATE music_game_players SET music = '$newBase' WHERE id = '$playerID'";
    mysqli_query($conn,$query);
    echo "The file ". htmlspecialchars( basename( $_FILES["fileToUpload"]["name"])). " has been uploaded.";
  } else {
    echo "Sorry, there was an error uploading your file.";
  }
}
?>
