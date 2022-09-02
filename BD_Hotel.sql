CREATE DATABASE Hotel;
GO
USE Hotel;
GO

CREATE TABLE Nacionalida
(
 IdNacionalida INT Identity Primary Key,
 pais VARCHAR(30)NOT NULL,
 nacionalidad VARCHAR(50)NOT NULL
);
GO

CREATE TABLE Habitacion
(
 IdHabitacion int identity primary key,
 Costo DECIMAL NOT NULL,
 Descripcion TEXT NOT NULL
);
GO

CREATE TABLE Cliente
(
 IdCliente INT Identity Primary Key,
 Nombre VARCHAR(170)NOT NULL,
 Direccion VARCHAR(170)NOT NULL,
 DNI INT,
 Telefono VARCHAR(20)NOT NULL,
 IdNacionalida INT Foreign Key(IdNacionalida) References Nacionalida(IdNacionalida),
 IdHabitacion INT Foreign Key(IdHabitacion) References Habitacion(IdHabitacion) 
);
GO

SELECT * FROM Nacionalida;

INSERT INTO Nacionalida  VALUES('PERU','PERUANO')
INSERT INTO Nacionalida  VALUES('PERU','COLOMBIANO')
INSERT INTO Nacionalida  VALUES('PERU','ARGENTINO')
INSERT INTO Nacionalida  VALUES('VENEZUELA','BOLIVIANO')


SELECT * FROM Habitacion;

INSERT INTO Habitacion  VALUES('250','CAMA MATRIMONIO')
INSERT INTO Habitacion  VALUES('200','ASIGNADA A 2 PERSONAS')
INSERT INTO Habitacion  VALUES('100','ASIGNADA A 1 PERSONA')
INSERT INTO Habitacion  VALUES('120','CON CAMA ADICIONAL')








