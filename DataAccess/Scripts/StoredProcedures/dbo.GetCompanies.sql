﻿USE SupportSystemTIS
GO

IF OBJECT_ID('dbo.GetCompanies', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetCompanies
GO

CREATE PROCEDURE dbo.GetCompanies
@status INT
AS
	SELECT  c.Id, c.ShortName, c.LongName, c.Society, c.Address, c.Telephone, c.CmpanyEmail, c.CmpanyStatus
	FROM  Companies c
	WHERE c.CmpanyStatus=@status
GO
