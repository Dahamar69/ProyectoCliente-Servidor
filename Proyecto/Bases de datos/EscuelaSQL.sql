-------------------------------------BASE DE DATOS-------------------------------------

USE master;
GO 
IF DB_ID(N'Escuela') IS NOT NULL
DROP DATABASE Escuela;
GO
CREATE DATABASE Escuela
ON
(NAME = Escuela_dat,
FILENAME =  'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Escuela.mdf',
SIZE = 10,
MAXSIZE = 50,
FILEGROWTH = 5)
LOG ON
(NAME = Escuela_log,
FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Escuela.ldf',
SIZE = 5,
MAXSIZE = 25,
FILEGROWTH = 5);
GO
USE Escuela;
GO

-------------------------------------TABLAS-------------------------------------
CREATE TABLE Usuario
(id INT IDENTITY (1,1),
usuario VARCHAR (15) NOT NULL,
contraseña VARBINARY(8000) NOT NULL
CONSTRAINT PK_Usuario PRIMARY KEY(id)
);

CREATE TABLE Carrera
(id INT IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
clave VARCHAR (50) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
CONSTRAINT PK_Carrera PRIMARY KEY (id)
);


CREATE TABLE Materia
(id INT IDENTITY (1,1),
nombre VARCHAR(50) NOT NULL,
credito VARCHAR(50) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
CONSTRAINT PK_Materia PRIMARY KEY (id)
);


CREATE TABLE CarreraMateria
(idCarreraMateria INT IDENTITY (1,1),
idCarrera INT NOT NULL,
idMateria INT NOT NULL
CONSTRAINT PK_CarreraMateria PRIMARY KEY(idCarreraMateria)
);


CREATE TABLE Maestro
(id INT IDENTITY (1,1),
nombre VARCHAR(50) NOT NULL,
apellidoPaterno VARCHAR(50) NOT NULL,
apellidoMaterno VARCHAR(50) NOT NULL,
telefono VARCHAR(10) NOT NULL,
idusuario INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
CONSTRAINT PK_Maestro PRIMARY KEY (id)
);

CREATE TABLE MateriaMaestro
(idMateriaMaestro INT IDENTITY (1,1),
idMateria INT NOT NULL,
idMaestro INT NOT NULL
CONSTRAINT PK_MateriaMaestro PRIMARY KEY (idMateriaMaestro)
);

CREATE TABLE Alumno
(id INT IDENTITY (1,1),
nombre VARCHAR(50) NOT NULL,
apellidoPaterno VARCHAR(50) NOT NULL,
apellidoMaterno VARCHAR(50) NOT NULL,
direccion VARCHAR(50) NOT NULL,
telefono VARCHAR(10) NOT NULL,
matricula VARCHAR (15) NOT NULL,
idcarrera INT NOT NULL,
idusuario INT NOT NULL,
idlista INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
CONSTRAINT PK_Alumno PRIMARY KEY (id)
);

CREATE TABLE MaestroAlumno
(idMaestroAlumno INT IDENTITY (1,1),
idMaestro INT NOT NULL,
idAlumno INT NOT NULL
CONSTRAINT PK_MaestroAlumno PRIMARY KEY (idMaestroAlumno)
);


CREATE TABLE Lista
(id INT IDENTITY (1,1),
nombre varchar (50) NOT NULL,
apellidopaterno varchar (50) NOT NULL,
apellidomaterno varchar (50) NOT NULL,
materia VARCHAR(50) NOT NULL,
creditos INT NOT NULL,
calificacion DECIMAL (10,2) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
CONSTRAINT PK_Lista PRIMARY KEY (id)
);

-------------------------------------INDEX-------------------------------------
CREATE INDEX IX_Carrera ON Carrera (id)
CREATE INDEX IX_Materia ON Materia (id)
CREATE INDEX IX_Maestro ON Maestro (id)
CREATE INDEX IX_Alumno ON Alumno (id)
CREATE INDEX IX_Lista ON Lista (id)
CREATE INDEX IX_CarreraMateria ON CarreraMateria (idCarreraMateria)
CREATE INDEX IX_MateriaMaestro ON MateriaMaestro (idMateriaMaestro)
CREATE INDEX IX_MaestroAlumno ON MaestroAlumno (idMaestroAlumno)


-------------------------------------RELACIONES-------------------------------------
ALTER TABLE CarreraMateria
ADD CONSTRAINT FK_CarreraMateriaCarrera
FOREIGN KEY (idCarrera) REFERENCES Carrera (id);

ALTER TABLE CarreraMateria
ADD CONSTRAINT FK_CarreraMateriaMateria
FOREIGN KEY (idMateria) REFERENCES Materia (id);

ALTER TABLE MateriaMaestro
ADD CONSTRAINT FK_MateriaMaestroMateria
FOREIGN KEY (idMateria) REFERENCES Materia (id);

ALTER TABLE MateriaMaestro
ADD CONSTRAINT FK_MateriaMaestroMaestro
FOREIGN KEY (idMaestro) REFERENCES Maestro (id);

ALTER TABLE Maestro
ADD CONSTRAINT FK_Maestro
FOREIGN KEY (idusuario) REFERENCES Usuario (id);


ALTER TABLE Alumno
ADD CONSTRAINT FK_AlumnoCarrera
FOREIGN KEY (idcarrera) REFERENCES Carrera (id);

ALTER TABLE Alumno
ADD CONSTRAINT FK_AlumnoLista
FOREIGN KEY (idlista) REFERENCES Lista (id);

ALTER TABLE Alumno
ADD CONSTRAINT FK_AlumnoUsuario
FOREIGN KEY (idusuario) REFERENCES Usuario (id);

ALTER TABLE MaestroAlumno
ADD CONSTRAINT FK_MaestroAlumnoMaestro
FOREIGN KEY (idMaestro) REFERENCES Maestro (id);

ALTER TABLE MaestroAlumno
ADD CONSTRAINT FK_MaestroAlumnoAlumno
FOREIGN KEY (idAlumno) REFERENCES Alumno (id);

-------------------------------------INSERT-------------------------------------

INSERT INTO Usuario (usuario,contraseña) 
VALUES ('admin',ENCRYPTBYPASSPHRASE('password','admin')),
('Camila',ENCRYPTBYPASSPHRASE('password','Camila')),
('Norberto',ENCRYPTBYPASSPHRASE('password','Norberto')),
('Ruben',ENCRYPTBYPASSPHRASE('password','Ruben')),
('Norma',ENCRYPTBYPASSPHRASE('password','Norma'))

SELECT*FROM Usuario
SELECT usuario,CONVERT(VARCHAR(MAX),DECRYPTBYPASSPHRASE('password',contraseña))Contraseña from Usuario


INSERT INTO Carrera (nombre,clave)
VALUES ('Informatica','I')

SELECT * FROM Carrera

INSERT INTO Materia (nombre,credito)
VALUES ('Programacion en ambiente cliente-servidor','5'),
('Administracion de servidores','5'),
('Taller de investigacion','5'),
('Taller base de datos','5')

SELECT * FROM Materia

INSERT INTO CarreraMateria (idCarrera,idMateria)
VALUES (1,1),
(1,2),
(1,3),
(1,4)

SELECT * FROM CarreraMateria

INSERT INTO Maestro (nombre,apellidoPaterno,apellidoMaterno,telefono,idusuario)
VALUES ('Ruben','Riojas','Rodriguez','8661234567',4),
('Norma','Aguilar','Covarrubias','8661234568',5)

SELECT * FROM Maestro

INSERT INTO MateriaMaestro (idMateria,idMaestro)
VALUES (1,1),
(2,1),
(3,2),
(4,2)

SELECT * FROM MateriaMaestro


INSERT INTO Lista (nombre,apellidopaterno,apellidomaterno,materia,calificacion,creditos)
VALUES ('Norberto', 'Hernandez', 'Perez','Programacion en ambiente cliente-servidor',10,20),
('Camila', 'Camila Ortiz', 'Jimenez','Programacion en ambiente cliente-servidor',10,20)

INSERT INTO Alumno(matricula,nombre,apellidoPaterno,apellidoMaterno,direccion,telefono,idcarrera,idlista,idusuario)
VALUES ('I18050480','Norberto','Hernandez','Perez','Durazno #123','8661234569',1,1,3),
('I16050658','Dahamar Camila','Ortiz','Jimenez','Manzana #12','8661234560',1,2,2)

SELECT * FROM Alumno


INSERT INTO MaestroAlumno (idMaestro,idAlumno)
VALUES (1,1),
(1,2),
(2,1),
(2,2)

select * from MaestroAlumno