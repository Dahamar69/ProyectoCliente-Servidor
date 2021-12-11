<?php
include 'bd/BD.php';

header('Access-Control-Allow-Origin: *');

if($_SERVER['REQUEST_METHOD']=='GET')
{
    if(isset($_GET['id']))
    {
        $query="select * from alumno where id=".$_GET['id'];
        $resultado=metodoGet($query);
        echo json_encode($resultado->fetch(PDO::FETCH_ASSOC));
    }
    else
    {
        $query="select * from alumno";
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
    $direccion=$_POST['direccion'];
    $telefono=$_POST['telefono'];
    $semestre=$_POST['semestre'];
    
    $query="INSERT INTO alumno(nombre,apellidoMaterno,apellidoPaterno,direccion,telefono,semestre) 
    VALUES ('$nombre','$apellidoMaterno','$apellidoPaterno','$direccion','$telefono','$semestre')";

    $queryAutoIncrement="select MAX(id) as id from alumno";
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
    $direccion=$_POST['direccion'];
    $telefono=$_POST['telefono'];
    $semestre=$_POST['semestre'];
    $estatus=$_POST['estatus'];
    $query="UPDATE alumno SET nombre='$nombre',apellidoMaterno='$apellidoMaterno',
    apellidoPaterno='$apellidoPaterno',direccion='$direccion',telefono='$telefono',
    semestre='$semestre',estatus=$estatus WHERE id='$id'";
    $resultado=metodoPut($query);
    echo json_encode($resultado);
    header("HTTP/1.1 200 OK");
    exit();
}

if($_POST['METHOD']=='DELETE')
{
    unset($_POST['METHOD']);
    $id=$_GET['id'];
    $query="DELETE FROM alumno WHERE id='$id'";
    $resultado=metodoDelete($query);
    echo json_encode($resultado);
    header("HTTP/1.1 200 OK");
    exit();
}

header("HTTP/1.1 400 Bad Request");


?>