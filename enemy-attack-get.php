<?php
$servername = "mysql307.phy.lolipop.lan";  // サーバー名
$dbname = "LAA1611974-mytho";  // データベース名
$username = "LAA1611974";  // ユーザー名
$password = "mythosencounter";  // パスワード

try {
    // データベースに接続
    $conn = new PDO("mysql:host={$servername};dbname={$dbname}", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    // SQLクエリを実行
    $sql = "SELECT * FROM enemy_attack_table";
    $stmt = $conn->query($sql);
    $stmt->execute();

    if ($stmt->rowCount() > 0) {
        // 結果をループして表示
        while ($row = $stmt->fetchObject()) {
            echo $row->id. ":". $row->name . ":" . $row->direct_damage . ":" . $row->bleeding_damage . ":" . $row->stan_time . ":" . $row->range . ":" . $row->attack_probability .":" . $row->accuracy .":" . $row->speed . "<br>"; //改行は"<br>"あるいは"\n"
        }
    } else {
        echo "結果がありません";
    }

    // 接続を閉じる
    $conn = null;
}
?>
