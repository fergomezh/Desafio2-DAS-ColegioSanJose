CREATE DATABASE ColegioSanJose;
GO

USE ColegioSanJose;
GO

-- Tabla de Alumnos
CREATE TABLE Alumno (
    AlumnoId INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Grado VARCHAR(50) NOT NULL
);


-- Tabla de Materias
CREATE TABLE Materia (
    MateriaId INT PRIMARY KEY IDENTITY(1,1),
    NombreMateria VARCHAR(50) NOT NULL UNIQUE,
    Docente VARCHAR(100) NOT NULL
);


-- Tabla de Expedientes
CREATE TABLE Expediente (
    ExpedienteId INT PRIMARY KEY IDENTITY(1,1),
    AlumnoId INT NOT NULL,
    MateriaId INT NOT NULL,
    NotaFinal DECIMAL(5,2) NOT NULL,
    FOREIGN KEY (AlumnoId) REFERENCES Alumno(AlumnoId),
    FOREIGN KEY (MateriaId) REFERENCES Materia(MateriaId)
);

