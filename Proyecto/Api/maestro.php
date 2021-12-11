<?php
include 'bd/BD.php';

header('Access-Control-Allow-Origin: *');

if($_SERVER['REQUEST_METHOD']=='GET')
{
    if(isset($_GET['id']))
    {
        $query="select * from maestro where id=".$_GET['id'];
        $resultado=metodoGet($query);
        echo json_encode($resultado->fetch(PDO::FETCH_ASSOC));
    }
    else
    {
        $query="select * from maestro";
        $resultado=metodoGet($query);
        echo json_encode($resultado->fetchAll()); 
    }
    header("HTTP/1.1 200 OK");
    exit();
}

if($_POST['METHOD']=='POST')
{
    unset ($_POST['METHOD']);
    $nombre=$_POST['nombre'];
    $apellidoMaterno=$_POST['apellidoMaterno'];
    $apellidoPaterno=$_POST['apellidoPaterno'];
    $telefono=$_POST['telefono'];
    
    $query="INSERT INTO maestro(nombre,apellidoMaterno,apellidoPaterno,telefono) 
    VALUES ('$nombre','$apellidoMaterno','$apellidoPaterno','$telefono')";

    $queryAutoIncrement="select MAX(id) as id from maestro";
    $resultado=metodoPost($query, $queryAutoIncrement);
    echo json_encode($resultado);
    header("HTTP/1.1 200 OK");
    exit();
}

if($_POST['METHOD']=='PUT')
{
    unset($_POST['METHOD']);
    $id=$_POST['id'];
    $nombre=$_POST['nombre'];
    $apellidoMaterno=$_POST['apellidoMaterno'];
    $apellidoPaterno=$_POST['apellidoPaterno'];
    $telefono=$_POST['telefono'];
    $estatus=$_POST['estatus'];
    $query="UPDATE maestro SET nombre='$nombre',apellidoMaterno='$apellidoMaterno',
    apellidoPaterno='$apellidoPaterno',telefono='$telefono',
    estatus=$estatus WHERE id='$id'";
    $resultado=metodoPut($query);
    echo json_encode($resultado);
    header("HTTP/1.1 200 OK");
    exit();
}

if($_POST['METHOD']=='DELETE')
{
    unset($_POST['METHOD']);
    $id=$_GET['id'];
    $query="DELETE FROM maestro WHERE id='$id'";
    $resultado=metodoDelete($query);
    echo json_encode($resultado);
    header("HTTP/1.1 200 OK");
    exit();
}

header("HTTP/1.1 400 Bad Request");

?>