CREATE TABLE [dbo].[Tarea]
(
	id_tarea INT IDENTITY NOT NULL PRIMARY KEY,
	descripcion NVARCHAR(MAX) NOT NULL,
	id_colaborador INT,
	codigo_estado NVARCHAR(15) NOT NULL,
	codigo_prioridad NVARCHAR(5) NOT NULL,
	fecha_inicio DATETIME NOT NULL,
	fecha_fin DATETIME NOT NULL,
	nota NVARCHAR(MAX)

	FOREIGN KEY (id_colaborador) REFERENCES Colaborador(id_colaborador),
	FOREIGN KEY (codigo_estado) REFERENCES Estado(codigo_estado),
	FOREIGN KEY (codigo_prioridad) REFERENCES Prioridad(codigo_prioridad)
)
