<!DOCTYPE html>
<html>
<head>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
<link rel="stylesheet" href="tabla.css">
</head>
<body>
<div class=" p-3 mb-2 bg-secondary text-white">

<header class="p-3 bg-dark text-white">
<div class="container">
<div class="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
<a href="/" class="d-flex align-items-center mb-2 mb-lg-0 text-white text-decoration-none">
<svg class="bi me-2" width="40" height="32" role="img" aria-label="Bootstrap"><use xlink:href="#bootstrap"></use></svg>
</a>



<ul class="nav col-12 col-lg-auto me-lg-auto mb-2 justify-content-center mb-md-0">
<li><a href="tabla.php?tabla=alumno" class="nav-link px-2 text-white">Calificaciones</a></li>
<li><a href="tabla.php?tabla=maestro" class="nav-link px-2 text-white">Materias</a></li>
</ul>



</div>
</div>
</header>
</div>


<header>
   
<h1 class="display-1 " align="center">Instituto Tecnologico Superior De Monclova</h1>
<?php
$email=$_POST["email"];
    include("sql.inc.php");
    
    if ($email==null) 
    {
        echo '<h1 class="display-3" align="center"> SAL DE AQUI JAJA </h1>';
        return;
    }

$SELECT = "SELECT * FROM alumno";
?>

<div class="mi-auto" align="right" >
    <a algin="rhigt"  href="login.html" ><button type="button"  class="btn btn-danger">Regresar</button></a>
</div>
</header>
<?php

$array=$db->getAll($SELECT);
$db->close();

$db->connect('DESKTOP-F164C7L\SQLEXPRESS','','','escuela') or die("Error");

//$ADODB_FETCH_MODE = ADODB_FETCH_ASSOC;
$rs=$db->execute($SELECT);
//$array2=$rs->GetAll();
$db->close();
$db=null;

echo '<table class="table table-success table-striped >">
<thead class="table-secundary"';
echo '<tr>';
    for ($j=0; $j < $rs->FieldCount(); $j++) 
    {
      echo '<th>'.strtoupper($rs->FetchField($j)->name).'</th>';
    }
    
    echo '</tr>';

    for ($i=0; $i < count($array); $i++)
    {
        $a=count($array[$i]);
        
        echo '<tr>';
        for ($j=0; $j < $a; $j++) 
        {
            echo '<td>'.$array[$i][$j].'</td>';
        }
        
        echo '</tr>';
        
    }
    
    echo '<h1>'.$email.'</h1>';?>
</thead>
</table>
</div>
</body>
</html>
