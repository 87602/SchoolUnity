<?php

$name = SQLite3::escapeString($_POST["name"]);
$score = SQLite3::escapeString($_POST["score"]);

$db = new SQLite3("DemoDB.db");
$db->busyTimeout(5000);

$query = "INSERT INTO Highscores (ID, Naam, Score) VALUES (NULL, '$name', '$score')";

$db->exec($query);

echo "Naam: ". $name . "<br>"; 
echo "Score: ". $score . "<br>"; 
?>