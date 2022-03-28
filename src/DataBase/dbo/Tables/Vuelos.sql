CREATE TABLE [dbo].[Vuelos] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Origen]    NVARCHAR (30) NOT NULL,
    [Destino]   NVARCHAR (30) NOT NULL,
    [Partida]   DATE          NOT NULL,
    [Regreso]   DATE          NOT NULL,
    [Pasajeros] INT           NOT NULL,
    [UsuarioID] INT           NOT NULL,
    CONSTRAINT [PK_VUELO] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_VUELO_USUARIO] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[Usuarios] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

