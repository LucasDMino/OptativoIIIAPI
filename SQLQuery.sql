-------------------------------------------------------------------------------------------------------------
--																		Tarea: Desarrollo de API en .NET Core

DROP TABLE IF EXISTS dbo.Persona_2
--Tabla Persona_2
CREATE TABLE dbo.Persona_2 (
    idPersona INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    idCiudad INT FOREIGN KEY REFERENCES Ciudad(idCiudad) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
	Direccion VARCHAR(75) NOT NULL,
	Email VARCHAR(25) NULL,
	Celular VARCHAR(15) NOT NULL,
	Edad VARCHAR(20) NOT NULL
);

DROP TABLE IF EXISTS dbo.Ciudad_2
--Tabla Ciudad_2
CREATE TABLE dbo.Ciudad_2 (
    idCiudad INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    CiudadNombre VARCHAR(50) NOT NULL,
    Departamento VARCHAR(50) NOT NULL,
    PostalCode INT NOT NULL
);

---------------------------------------------------------------------------------
--																	PROCEDURES
--INSERTS
CREATE PROC usp_AddCiudad(@CiudadNombre VARCHAR(50), @Departamento VARCHAR(50), @PostalCode INT)
AS
BEGIN 
	INSERT INTO Ciudad_2(CiudadNombre,Departamento,PostalCode)
	VALUES(@CiudadNombre,@Departamento,@PostalCode);
END;

CREATE PROC usp_AddPersona(@idCiudad INT, @Nombre VARCHAR(50), @Apellido VARCHAR(50), @Direccion VARCHAR(75), @Email VARCHAR(25),
							@Celular VARCHAR(15),@Edad VARCHAR(20))
AS
BEGIN 
	INSERT INTO Persona_2(idCiudad,Nombre,Apellido, Direccion, Email, Celular, Edad)
	VALUES(@idCiudad,@Nombre,@Apellido, @Direccion, @Email, @Celular, @Edad);
END;


--READ
CREATE PROC usp_GetAllCiudad
AS
BEGIN 
	SELECT * FROM Ciudad_2;
END;

CREATE PROC usp_GetAllPersona
AS
BEGIN 
	SELECT * FROM Persona_2;
END;

--READ_2
CREATE PROC usp_GetAllCiudadById(@idCiudad INT)
AS
BEGIN 
	SELECT * FROM Ciudad_2 WHERE idCiudad = @idCiudad;
END;

CREATE PROC usp_GetAllPersonaById(@idPersona INT)
AS
BEGIN 
	SELECT * FROM Persona_2 WHERE idPersona = @idPersona;
END;

--UPDATE
CREATE PROC usp_UpdateCiudad(@idCiudad INT, @CiudadNombre VARCHAR(50), @Departamento VARCHAR(50), @PostalCode INT)
AS
BEGIN 
	UPDATE Ciudad_2
	SET CiudadNombre = @CiudadNombre, Departamento = @Departamento, PostalCode = @PostalCode WHERE idCiudad = @idCiudad
END;

CREATE PROC usp_UpdatePersona(@idPersona INT, @idCiudad INT, @Nombre VARCHAR(50), @Apellido VARCHAR(50), @Direccion VARCHAR(75), @Email VARCHAR(25),
							@Celular VARCHAR(15),@Edad VARCHAR(20))
AS
BEGIN 
	UPDATE Persona_2
	SET idCiudad = @idCiudad, Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Email = @Email, Celular = @Celular, Edad = @Edad WHERE idPersona = @idPersona
END;

--DELETE
CREATE PROC usp_DeleteCiudad (@idCiudad INT)
AS
BEGIN 
	DELETE FROM Ciudad_2 WHERE idCiudad = @idCiudad;
END;

CREATE PROC usp_DeletePersona (@idPersona INT)
AS
BEGIN 
	DELETE FROM Persona_2 WHERE idPersona = @idPersona;
END;
