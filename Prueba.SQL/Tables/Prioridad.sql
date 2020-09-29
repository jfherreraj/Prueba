CREATE TABLE [dbo].[Prioridad]
(
	codigo_prioridad NVARCHAR(5) NOT NULL PRIMARY KEY,
	descripcion NVARCHAR(1000) NOT NULL,
	Activo BIT DEFAULT 1
)
