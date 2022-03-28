﻿CREATE TABLE [dbo].[Roles] (
    [Codigo] VARCHAR (5)   NOT NULL,
    [Nombre] NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_ROL] PRIMARY KEY CLUSTERED ([Codigo] ASC),
    UNIQUE NONCLUSTERED ([Codigo] ASC)
);

