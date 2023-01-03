CREATE PROCEDURE [dbo].[sp_obtener_datos_cliente_por_id]
	@input_id_cliente INT
AS
BEGIN TRY

	SELECT  
	[transaccion_id],            
    [fk_id_cliente],             
    [retiros],                     
    [consignaciones],
    [transferencias_otros_bancos], 
    [consulta_movimientos]
	FROM [transaccion]
	WHERE transaccion_id = @input_id_cliente

END TRY

BEGIN CATCH 
	 SELECT 0;
END CATCH