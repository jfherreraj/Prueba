﻿CREATE TABLE [dbo].[Colaborador]
(
	id_colaborador INT NOT NULL IDENTITY PRIMARY KEY,
	nombre NVARCHAR(100) NOT NULL,
	apellido NVARCHAR(100) NOT NULL,
	email NVARCHAR(100) UNIQUE NOT NULL,
	activo BIT DEFAULT 1
)