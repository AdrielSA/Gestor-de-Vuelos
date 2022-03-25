CREATE DATABASE [GestorVuelos];
GO

USE [GestorVuelos];
GO

CREATE TABLE [Roles]
(
	Codigo VARCHAR(5) NOT NULL,
	Nombre NVARCHAR(20) NOT NULL,

	CONSTRAINT PK_ROL PRIMARY KEY(Codigo)
);
GO

CREATE TABLE [Usuarios]
(
	Id INT IDENTITY(1,1) NOT NULL,
	Nombre NVARCHAR(20) NOT NULL,
	Correo NVARCHAR(30) NOT NULL,
	Contraseņa NVARCHAR(MAX) NOT NULL,
	CodigoRol VARCHAR(5) NOT NULL,

	CONSTRAINT PK_USUARIO PRIMARY KEY(Id),
	CONSTRAINT FK_USUARIO_ROL FOREIGN KEY (CodigoRol) REFERENCES Roles(Codigo) ON DELETE NO ACTION ON UPDATE NO ACTION

);
GO

CREATE TABLE [Vuelos]
(
	Id INT IDENTITY(1,1),
	Origen NVARCHAR(30) NOT NULL,
	Destino NVARCHAR(30) NOT NULL,
	Partida DATE NOT NULL,
	Regreso DATE NOT NULL,
	Pasajeros INT NOT NULL,
	UsuarioID INT NOT NULL

	CONSTRAINT PK_VUELO PRIMARY KEY(Id)
	CONSTRAINT FK_VUELO_USUARIO FOREIGN KEY (UsuarioID) REFERENCES Usuarios(Id) ON DELETE CASCADE ON UPDATE CASCADE
);
GO