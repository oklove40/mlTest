﻿CREATE TABLE [dbo].[ML]
(
	[IDX] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TITLE] NVARCHAR(200) NULL, 
    [CONTENT] NVARCHAR(MAX) NULL, 
    [REG_DT] DATETIME NULL DEFAULT GETDATE(), 
    [EDT_DT] DATETIME NULL
)
