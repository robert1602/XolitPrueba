CREATE PROCEDURE [dbo].[sp_crea_o_actualiza_cliente]
@input_cliente_id INT=0,         
@tipoDocumentoIdent VARCHAR(100)=NULL, 
@identificacion INT=0,
@nroCuenta INT = 0,
@saldoinicial INT = 0,
@nombre VARCHAR(100)

AS

--Inicio procedimiento almacenado
BEGIN TRY
    DECLARE @estado_activo BIT;
    DECLARE @estado_inactivo BIT;
    DECLARE @fecha_actual DATETIME;
    DECLARE @registro_insertado_actualizado INT;
    BEGIN TRANSACTION 
    --
    SET @estado_activo = 1;
    SET @estado_inactivo = 0;
    SET @fecha_actual = GETDATE(); 

    IF @input_cliente_id != 0 --UPDATE
    BEGIN
		IF EXISTS    
		(
			SELECT c.Id_cliente
			FROM [Cliente] e WITH (NOLOCK)
			WHERE [Id_cliente] = @input_cliente_id
		)
		BEGIN
			SELECT 0 registro_id;
		END
		ELSE
		BEGIN
			UPDATE Cliente
			SET Id_cliente = @input_cliente_id,
				[nombre] = @nombre       ,
				[tipo_ident] = @tipoDocumentoIdent   ,
				[identificacion] = @identificacion,
				[nro_cuenta] = @nroCuenta   ,
				[saldo_inicial] = @saldoinicial
			FROM [dbo].Cliente e WITH (NOLOCK)
			WHERE Id_cliente = @input_cliente_id;
						
			INSERT INTO [dbo].[Cliente]
			(
				[nombre]        ,
				[tipo_ident]    ,
				[identificacion],
				[nro_cuenta]    ,
				[saldo_inicial] 
			)
			VALUES
			(@nombre, @tipoDocumentoIdent, @identificacion,@nroCuenta, @saldoinicial);
		END
	END
	ELSE
	BEGIN
	IF EXISTS    
		(
			SELECT c.Id_cliente
			FROM [Cliente] e WITH (NOLOCK)
			WHERE [Id_cliente] = @input_cliente_id
		)
		BEGIN
			SELECT 0 registro_id;
		END
		ELSE
			INSERT INTO [dbo].[Cliente]
			(
				[nombre]        ,
				[tipo_ident]    ,
				[identificacion],
				[nro_cuenta]    ,
				[saldo_inicial] 
			)
			VALUES
			(@nombre, @tipoDocumentoIdent, @identificacion,@nroCuenta, @saldoinicial);
		
	END;

IF @@TRANCOUNT > 0
BEGIN
	COMMIT TRANSACTION
	SELECT SCOPE_IDENTITY() AS registro_id;
END
ELSE
	SELECT 0 registro_id;

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
    BEGIN
        ROLLBACK TRANSACTION;
    END
      SELECT 0;
END CATCH