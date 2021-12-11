<?php
//hearder('Access-Control-Allow-Origin: *');

include_once "bd/db.php";

//conectar();

if($_SERVER['REQUEST_METHOD'] == "POST" && $_POST['crud-req']=="signup")
signup($conn);

if($_SERVER['REQUEST_METHOD'] == "GET")
logout($conn);

if($_SERVER['REQUEST_METHOD'] == "PATCH")
update($conn);

if($_SERVER['REQUEST_METHOD'] == "DELETE")
unSubscribe($conn);

//if($_POST['crud-req']=="login")
//login($conn);




function signup($conn){
    $usuario = $_POST['usuario'];
    $contraseña = $_POST['contraseña'];

    if(empty($usuario) || empty($contraseña) )
    {
        http_response_code(400);
        echo "All fields are mandatory!!";
        exit();
    }
    if(! filter_var($usuario, FILTER_VALIDATE_EMAIL)){
        http_response_code(400);
        echo "Invalid usuario";
        exit();
    }
    //if($contraseña != $contraseña, CONTRASEÑA_DEFAULT){
      //  http_response_code(400);
        //echo "Invalid contraseña";
        //exit();
   // }
    $pwd = password_hash($contraseña, PASSWORD_DEFAULT);
    $contraseña = $contraseña;

    $sql = "Insert into Usuario(usuario, contraseña) values (?,?)";
    $stmt = $conn->stmt_init();

    if(!$stmt->prepare($sql)){
        http_response_code(400);
        echo "Somethin went wrong. Try again later!!";
        exit();
    }
    $stmt->bind_param('sssss',$usuario,$contraseña);
    $stmt->execute();
    if($stmt->affected_rows >0){
        http_response_code(200);
        echo "Congratulation! \n You have been";
        exit();
    }
    else{
        http_response_code(400);
        echo "Somethin went wrong.";
        
    }
}

conectar();
//function login($conn){}
function logout($conn){}
function update($conn){}
function unSubscribe($conn){}
?>