﻿CREATE TABLE [People]
(
	[Id] COUNTER NOT NULL PRIMARY KEY,
	[Surname] NVARCHAR(50),
	[Title] NVARCHAR(10),
	[Forenames] NVARCHAR(50),
	[Address] NVARCHAR(100),
	[Postcode] NVARCHAR(10),
	[Phone1] NVARCHAR(20),
	[Phone2] NVARCHAR(20),
	[Modified] DATETIME NOT NULL DEFAULT NOW()
)