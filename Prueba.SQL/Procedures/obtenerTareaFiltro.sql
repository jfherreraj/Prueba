CREATE PROCEDURE obtenerTareaFiltro(
	@fecha_inicio DATETIME,
	@fecha_fin DATETIME,
	@id_colaborador INT,
	@codigo_estado NVARCHAR(10),
	@codigo_prioridad NVARCHAR(10)
)

AS
BEGIN
IF(0=1) SET FMTONLY OFF
	SELECT
		t.id_tarea,
		t.descripcion,
		c.nombre + c.apellido as nombre,
		t.codigo_estado,
		t.codigo_prioridad,
		t.fecha_inicio,
		t.fecha_fin,
		t.nota
	FROM Tarea AS t
	LEFT JOIN Colaborador AS c
	ON t.id_colaborador = c.id_colaborador 
	WHERE (fecha_inicio BETWEEN @fecha_inicio AND @fecha_fin)
			AND (fecha_fin BETWEEN @fecha_inicio AND @fecha_fin)
			AND (@id_colaborador IS NULL OR (t.id_colaborador = @id_colaborador))
			AND (@codigo_estado IS NULL OR (t.codigo_estado = @codigo_estado))
			AND (@codigo_prioridad IS NULL OR (codigo_prioridad = @codigo_prioridad))
END