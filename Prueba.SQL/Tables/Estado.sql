CREATE TABLE [dbo].[Estado]
(
	codigo_estado NVARCHAR(15) NOT NULL PRIMARY KEY,
	descripcion NVARCHAR(1000) NOT NULL, 
	activo BIT DEFAULT 1
)
