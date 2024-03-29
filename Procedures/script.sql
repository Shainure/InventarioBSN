USE [DBI]
GO
/****** Object:  StoredProcedure [dbo].[rpt_cierre_no_digitados]    Script Date: 25/11/2021 9:33:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rpt_cierre_no_digitados]
AS

SELECT distinct codigo_prod as "Nart", descripcion as "Descripción" 
FROM tbnart 
WHERE codigo_prod not in 
(SELECT codigo_prod FROM tbconteosinventario);
GO
/****** Object:  StoredProcedure [dbo].[rpt_consolidado_conteo]    Script Date: 25/11/2021 9:33:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rpt_consolidado_conteo]
AS

SELECT ci.codigo_prod as "Nart", tbn.descripcion as "Descripción", 
ci.bodega as "Bodega", SUM(ci.cant_conteofinal) as "Cant Total Conteo"
FROM dbo.tbconteosinventario ci 
INNER JOIN dbo.tbnart tbn ON ci.codigo_prod = tbn.codigo_prod
WHERE ci.cant_conteofinal !=-1 
GROUP BY CI.codigo_prod, tbn.descripcion, ci.bodega
ORDER BY ci.codigo_prod
GO
/****** Object:  StoredProcedure [dbo].[rpt_diferencia_conteo_cierre]    Script Date: 25/11/2021 9:33:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rpt_diferencia_conteo_cierre]
AS

SELECT 
	sb.codigo_prod as "Nart", 
	tbn.descripcion as "Descripción", 
	SUM(CASE WHEN ci.cant_conteofinal >0 THEN ci.cant_conteofinal ELSE 0 END) 
		as "Conteo final",
	sb.cantidad as "Saldo bodega", 
	ABS((SUM(CASE WHEN ci.cant_conteofinal >0 THEN ci.cant_conteofinal ELSE 0 END))-sb.cantidad) 
		as "Diferencia"
FROM tbsaldobodega sb 
INNER JOIN tbnart tbn 
	ON sb.codigo_prod = tbn.codigo_prod
INNER JOIN tbconteosinventario ci 
	ON ci.codigo_prod = sb.codigo_prod 
GROUP BY sb.codigo_prod, tbn.descripcion, sb.cantidad
ORDER BY sb.codigo_prod;
GO
/****** Object:  StoredProcedure [dbo].[rpt_digitados_no_cierre]    Script Date: 25/11/2021 9:33:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rpt_digitados_no_cierre]
AS

SELECT distinct codigo_prod "Nart", lote as "Lote" 
FROM tbconteosinventario 
WHERE codigo_prod not in (SELECT codigo_prod FROM tbnart);
GO
/****** Object:  StoredProcedure [dbo].[rpt_tarjetas_conteo]    Script Date: 25/11/2021 9:33:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rpt_tarjetas_conteo]
AS

SELECT 
	ci.numero_tarjeta as "Nro. Tarjeta", 
	ci.codigo_prod as "Nart", 
	tbn.descripcion as "Descripción", 
	ci.lote as "Lote", 
	ci.bodega as "Bodega", 
	ci.ubicacion as "Ubicación", 
	ci.cant_conteo1 as "Conteo1", 
	ci.cant_conteo2 as "Conteo2", 
	ci.cant_conteo3 as "Conteo3"
FROM tbconteosinventario ci 
	INNER JOIN tbnart tbn 
	ON ci.codigo_prod = tbn.codigo_prod 
ORDER by ci.numero_tarjeta
GO
/****** Object:  StoredProcedure [dbo].[rpt_tarjetas_sin_contar]    Script Date: 25/11/2021 9:33:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rpt_tarjetas_sin_contar]
AS

SELECT ci.numero_tarjeta as "Nro. Tarjeta", ci.codigo_prod as "Nart", tbn.descripcion as "Descripción", 
ci.lote as "Lote", ci.cant_conteo1 as "Conteo 1", ci.cant_conteo2 as "Conteo 2", ci.cant_conteo3 as "Conteo 3"
FROM tbconteosinventario ci 
INNER JOIN tbnart tbn ON ci.codigo_prod = tbn.codigo_prod
WHERE ci.cant_conteo1 = -1 OR ci.cant_conteo2 = -1 
ORDER BY ci.numero_tarjeta;
GO
/****** Object:  StoredProcedure [dbo].[rpt_total_conteo_cierre]    Script Date: 25/11/2021 9:33:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rpt_total_conteo_cierre]
AS

SELECT sb.codigo_prod as "Nart", tbn.descripcion as "Descripción", sb.cantidad as "Conteo final",
		SUM(CASE WHEN ci.cant_conteofinal >0 THEN ci.cant_conteofinal ELSE 0 END) as "Saldo bodega"
FROM tbsaldobodega sb 
INNER JOIN tbnart tbn ON sb.codigo_prod = tbn.codigo_prod
INNER JOIN tbconteosinventario ci ON ci.codigo_prod = sb.codigo_prod 
GROUP BY sb.codigo_prod, tbn.descripcion, sb.cantidad
ORDER BY sb.codigo_prod;
GO
/****** Object:  StoredProcedure [dbo].[Sp_Consolidar_Conteo]    Script Date: 25/11/2021 9:33:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_Consolidar_Conteo]
AS 
BEGIN
DECLARE @tarjetaIDs TABLE (num_tarjeta int);
	DECLARE @return_value INT = 0;

	INSERT INTO @tarjetaIDs
		SELECT numero_tarjeta
		FROM tbconteosinventario
		WHERE estado = 1 AND cant_conteo1 != -1 AND cant_conteo2 != -1 and cant_conteofinal = -1
		ORDER BY numero_tarjeta

	DECLARE @tarjetaId int
	WHILE EXISTS (SELECT * FROM @tarjetaIDs)
	BEGIN 
		SELECT @tarjetaId = (SELECT top 1 num_tarjeta 
								FROM @tarjetaIDs
								ORDER BY num_tarjeta ASC)
		DELETE @tarjetaIDs
		WHERE num_tarjeta = @tarjetaId
		

		IF ((SELECT cant_conteo1 FROM tbconteosinventario WHERE numero_tarjeta = @tarjetaId) = 
			(SELECT cant_conteo2 FROM tbconteosinventario WHERE numero_tarjeta = @tarjetaId))
		BEGIN
			UPDATE tbconteosinventario
			SET 
				cant_conteofinal = cant_conteo1
			WHERE numero_tarjeta = @tarjetaId

			SET @return_value = @return_value +1
		END

		ELSE IF (SELECT cant_conteo3 FROM tbconteosinventario WHERE numero_tarjeta = @tarjetaId) != -1

		BEGIN
			UPDATE tbconteosinventario
			SET 
				cant_conteofinal = cant_conteo3
			WHERE numero_tarjeta = @tarjetaId

			SET @return_value = @return_value +1
		END


		/*
		UPDATE tbconteosinventario
		SET 
			cant_conteofinal = CASE WHEN cant_conteo1 = cant_conteo2 THEN cant_conteo1
									WHEN cant_conteo3 != -1	THEN cant_conteo3 END
		WHERE numero_tarjeta = @tarjetaId
		SET @return_value = @return_value +1*/
	END
	--return @return_value
	select @return_value
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_Consolidar_Conteo_run]    Script Date: 25/11/2021 9:33:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_Consolidar_Conteo_run]
AS 
BEGIN
DECLARE @tarjetaIDs TABLE (num_tarjeta int);
	DECLARE @return_value INT = 0;

	INSERT INTO @tarjetaIDs
		SELECT numero_tarjeta
		FROM tbconteosinventario
		WHERE estado = 1 AND cant_conteo1 != -1 AND cant_conteo2 != -1
		ORDER BY numero_tarjeta

	DECLARE @tarjetaId int
	WHILE EXISTS (SELECT * FROM @tarjetaIDs)
	BEGIN 
		SELECT @tarjetaId = (SELECT top 1 num_tarjeta 
								FROM @tarjetaIDs
								ORDER BY num_tarjeta ASC)
		DELETE @tarjetaIDs
		WHERE num_tarjeta = @tarjetaId
		
		UPDATE tbconteosinventario
		SET 
			cant_conteofinal = CASE WHEN cant_conteo1 = cant_conteo2 THEN cant_conteo1
									WHEN cant_conteo1 = cant_conteo3 THEN cant_conteo3
									WHEN cant_conteo2 = cant_conteo3 THEN cant_conteo3 ELSE 
									cant_conteofinal END
		WHERE numero_tarjeta = @tarjetaId
		SET @return_value = @return_value +1
	END
	--return @return_value
	select @return_value
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetConteos]    Script Date: 25/11/2021 9:33:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_GetConteos]

(
    @num_tarjeta int 
)
AS
BEGIN
SELECT 
cant_conteo1, cant_conteo2, cant_conteo3 
FROM tbconteosinventario 
WHERE numero_tarjeta= @num_tarjeta
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_inf_tarjeta]    Script Date: 25/11/2021 9:33:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_inf_tarjeta]

(
    @num_tarjeta int 
)
AS
BEGIN
--SET NOCOUNT ON;    
SELECT ci.codigo_prod, tbn.descripcion, ci.lote, ci.bodega, ci.ubicacion FROM tbconteosinventario ci
INNER JOIN tbnart tbn 
ON ci.codigo_prod = tbn.codigo_prod 
WHERE numero_tarjeta= @num_tarjeta
END

GO
/****** Object:  StoredProcedure [dbo].[Sp_Update_Conteo]    Script Date: 25/11/2021 9:33:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_Update_Conteo]
(
	@num_tarjeta INT,
    @conteo INT,
	@total INT
)
AS 
BEGIN
	UPDATE tbconteosinventario
	SET 
		cant_conteo1 = CASE WHEN @conteo = 1 THEN @total ELSE cant_conteo1 END,
		cant_conteo2 = CASE WHEN @conteo = 2 THEN @total ELSE cant_conteo2 END,
		cant_conteo3 = CASE WHEN @conteo = 3 THEN @total ELSE cant_conteo3 END,
		estado = 1
	WHERE numero_tarjeta = @num_tarjeta
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_valor_conteo]    Script Date: 25/11/2021 9:33:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_valor_conteo]

(
	@num_tarjeta INT,
    @conteo INT 
)
AS
BEGIN
SELECT 
CASE
	WHEN @conteo = 1 THEN cant_conteo1
	WHEN @conteo = 2 THEN cant_conteo2
	WHEN @conteo = 3 THEN cant_conteo3
END
AS conteo
FROM tbconteosinventario 
WHERE numero_tarjeta = @num_tarjeta
END
GO
