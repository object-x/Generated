﻿-- ------------------------------------------------------------------------------ 
-- <auto-generated> 
-- This code was generated by LayerCake Generator v3.7.1.
-- http://www.layercake-generator.net
-- 
-- Changes to this file may cause incorrect behavior AND WILL BE LOST IF 
-- the code is regenerated. 
-- </auto-generated> 
-- ------------------------------------------------------------------------------

CREATE PROCEDURE Translation_Delete
(
	@Translation_Id BIGINT,

	@CtxUser BIGINT = NULL,
	@CtxCulture VARCHAR(2) = N'EN',
	@CtxWithContextSecurity BIT = N'True'
)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	BEGIN TRY
		BEGIN TRANSACTION;

			DECLARE @V_ROWCOUNT INT = 0;
			DECLARE @V_IS_LOCKED BIT = N'False';

			IF (@V_IS_LOCKED = N'False')
			BEGIN

				IF (EXISTS(	SELECT	TOP 1 1
							FROM	[sys].[tables] WITH(NOLOCK)
							WHERE	[name] = N'Translation_LOGS'))
				BEGIN

					DECLARE @V_LOG_QUERY NVARCHAR(MAX) = 
						  N' INSERT INTO [Translation_LOGS]'
						+ N' ('
						+ N'  [Translation_LOGS].[Translation_Id]'
						+ N' ,[Translation_LOGS].[Translation_Key]'
						+ N' ,[Translation_LOGS].[Translation_Value_EN]'
						+ N' )'
						+ N' SELECT'
						+ N'  [Translation].[Translation_Id]'
						+ N' ,[Translation].[Translation_Key]'
						+ N' ,[Translation].[Translation_Value_EN]'
						+ N' FROM'
						+ N' [Translation] WITH(NOLOCK)'
						+ N' WHERE'
						+ N' [Translation].[Translation_Id] = @Translation_Id;';

					EXECUTE sp_executesql @V_LOG_QUERY, N'@Translation_Id BIGINT', @Translation_Id;

				END

				DELETE FROM [Translation] WHERE [Translation].[Translation_Id] = @Translation_Id;

				SET @V_ROWCOUNT = @@ROWCOUNT;
			END

		COMMIT TRANSACTION;

		SELECT @V_ROWCOUNT;

	END TRY
	BEGIN CATCH

		IF XACT_STATE() != 0
		BEGIN
			ROLLBACK TRANSACTION;
		END

		DECLARE @V_NOW DATETIME2(3) = GETDATE();
		DECLARE @V_ERROR_MESSAGE VARCHAR(MAX) = ERROR_MESSAGE();
		DECLARE @V_ERROR_SEVERITY INT = ERROR_SEVERITY();
		DECLARE @V_ERROR_STATE INT = ERROR_STATE();

		-- RAISE() must be called before EXEC [ProcessErrorLog_Save] in order to get the error
		-- on the first result in the SqlDataReader (Save stored procedures return 1 row).

		RAISERROR(@V_ERROR_MESSAGE, @V_ERROR_SEVERITY, @V_ERROR_STATE);

		EXEC [ProcessErrorLog_Save]
			 @ProcessErrorLog_Date = @V_NOW,
			 @ProcessErrorLog_ProcedureName = N'Translation_Delete',
			 @ProcessErrorLog_ErrorMessage = @V_ERROR_MESSAGE,
			 @ProcessErrorLog_ErrorSeverity = @V_ERROR_SEVERITY,
			 @ProcessErrorLog_ErrorState = @V_ERROR_STATE,
			 @ProcessErrorLog_Data = NULL,
			 @CtxUser = @CtxUser,
			 @CtxCulture = @CtxCulture,
			 @CtxWithContextSecurity = @CtxWithContextSecurity;

		RETURN (@@ROWCOUNT);

	END CATCH
END