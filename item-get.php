<?php
$servername = "mysql307.phy.lolipop.lan";  // サーバー名
$dbname = "LAA1611974-mytho";  // データベース名
$username = "LAA1611974";  // ユーザー名

try {
    // データベースに接続
    $conn = new PDO("mysql:host={$servername};dbname={$dbname}", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    //$conn->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);


    // SQLクエリを実行
    $sql = "SELECT * FROM item_table";
    $stmt = $conn->query($sql);
    $stmt->execute();

    if ($stmt->rowCount() > 0) {
        // 結果をループして表示
        while ($row = $stmt->fetchObject()) {
            echo $row->id. ":". $row->name . ":" . $row->explanation . ":" . $row->category .  ":" . $row->price . "<br>"; //改行は"<br>"あるいは"\n"
        }
    } else {
        echo "結果がありません";
    }

    // 接続を閉じる
    $conn = null;
}
?>
