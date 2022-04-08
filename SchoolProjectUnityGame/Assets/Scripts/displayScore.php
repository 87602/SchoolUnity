<?php 
    $db = new SQLite3("DemoDB.db");
    $db->busyTimeout(5000);

    $query = "SELECT * FROM Highscores ORDER by Score DESC LIMIT 10";
    $result=$db->query($query);

    while($row=$result->fetchArray(SQLITE3_ASSOC)){
        echo " Name: ".$row['Naam']. " - Score: ".$row['Score']."\n";
    }
?>