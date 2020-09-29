/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF (NOT EXISTS(SELECT * FROM Colaborador WHERE email = 'johnfrancishj@hotmail.com')) 
BEGIN 
    INSERT INTO Colaborador(nombre, apellido, email,activo) 
    VALUES('John', 'Herrera','johnfrancishj@hotmail.com', 1) 
END 
ELSE 
BEGIN 
    UPDATE Colaborador
    SET nombre = 'John',apellido = 'Herrera', activo = 1
    WHERE  email = 'johnfrancishj@hotmail.com'
END 


IF (NOT EXISTS(SELECT * FROM Colaborador WHERE email = 'kathymr-23@hotmail.com')) 
BEGIN 
    INSERT INTO Colaborador(nombre, apellido, email,activo) 
    VALUES('Katherine', 'Molina','kathymr-23@hotmail.com', 1) 
END 
ELSE 
BEGIN 
    UPDATE Colaborador
    SET nombre = 'Katherine',apellido = 'Molina', activo = 1
    WHERE  email = 'kathymr-23@hotmail.com'
END 


--INSERTO ESTADOS 

IF (NOT EXISTS(SELECT * FROM Estado WHERE codigo_estado = 'PENDIENTE')) 
BEGIN 
    INSERT INTO Estado(codigo_estado, descripcion, activo) 
    VALUES('PENDIENTE', 'La tarea se encuentra pendiente', 1) 
END 
ELSE 
BEGIN 
    UPDATE Estado
    SET descripcion =  'La tarea se encuentra pendiente', activo = 1
    WHERE  codigo_estado = 'PENDIENTE'
END 


IF (NOT EXISTS(SELECT * FROM Estado WHERE codigo_estado = 'PROCESO')) 
BEGIN 
    INSERT INTO Estado(codigo_estado, descripcion, activo) 
    VALUES('PROCESO', 'La tarea se encuentra en proceso', 1) 
END 
ELSE 
BEGIN 
    UPDATE Estado
    SET descripcion =  'La tarea se encuentra en proceso', activo = 1
    WHERE  codigo_estado = 'PROCESO'
END 

IF (NOT EXISTS(SELECT * FROM Estado WHERE codigo_estado = 'FINALIZADO')) 
BEGIN 
    INSERT INTO Estado(codigo_estado, descripcion, activo) 
    VALUES('FINALIZADO', 'La tarea se encuentra finalizada', 1) 
END 
ELSE 
BEGIN 
    UPDATE Estado
    SET descripcion =  'La tarea se encuentra finalizada', activo = 1
    WHERE  codigo_estado = 'FINALIZADO'
END 


--INSERTO PRIORIDAD
IF (NOT EXISTS(SELECT * FROM Prioridad WHERE codigo_prioridad = 'BAJA')) 
BEGIN 
    INSERT INTO Prioridad(codigo_prioridad, descripcion, activo) 
    VALUES('BAJA', 'La tarea una importancia baja', 1) 
END 
ELSE 
BEGIN 
    UPDATE Prioridad
    SET descripcion =  'La tarea una importancia baja', activo = 1
    WHERE  codigo_prioridad = 'BAJA'
END 



IF (NOT EXISTS(SELECT * FROM Prioridad WHERE codigo_prioridad = 'MEDIA')) 
BEGIN 
    INSERT INTO Prioridad(codigo_prioridad, descripcion, activo) 
    VALUES('MEDIA', 'La tarea una importancia media', 1) 
END 
ELSE 
BEGIN 
    UPDATE Prioridad
    SET descripcion =  'La tarea una importancia media', activo = 1
    WHERE  codigo_prioridad = 'MEDIA'
END 



IF (NOT EXISTS(SELECT * FROM Prioridad WHERE codigo_prioridad = 'ALTA')) 
BEGIN 
    INSERT INTO Prioridad(codigo_prioridad, descripcion, activo) 
    VALUES('ALTA', 'La tarea una importancia alta', 1) 
END 
ELSE 
BEGIN 
    UPDATE Prioridad
    SET descripcion =  'La tarea una importancia alta', activo = 1
    WHERE  codigo_prioridad = 'ALTA'
END 
