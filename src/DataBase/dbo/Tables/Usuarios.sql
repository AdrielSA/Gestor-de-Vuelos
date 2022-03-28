CREATE TABLE [dbo].[Usuarios] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]     NVARCHAR (20)  NOT NULL,
    [Correo]     NVARCHAR (30)  NOT NULL,
    [Contraseña] NVARCHAR (MAX) NOT NULL,
    [CodigoRol]  VARCHAR (5)    NOT NULL,
    CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_USUARIO_ROL] FOREIGN KEY ([CodigoRol]) REFERENCES [dbo].[Roles] ([Codigo]),
    UNIQUE NONCLUSTERED ([Correo] ASC)
);

