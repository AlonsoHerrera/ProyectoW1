IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE TABLE [Canton] (
        [IDCanton] int NOT NULL IDENTITY,
        [CodCanton] int NULL,
        [IDProvicia] int NULL,
        [Nombre] varchar(20) NULL,
        CONSTRAINT [PK_Canton] PRIMARY KEY ([IDCanton])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE TABLE [Distrito] (
        [IDdistrito] int NOT NULL IDENTITY,
        [CodDistrito] int NULL,
        [IDCanton] int NULL,
        [IDProvicia] int NULL,
        [Nombre] varchar(30) NULL,
        CONSTRAINT [PK_Distrito] PRIMARY KEY ([IDdistrito])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE TABLE [Entidad] (
        [IDEntidad] int NOT NULL IDENTITY,
        [Descripcion] varchar(30) NULL,
        [Estado] int NULL,
        CONSTRAINT [PK_Entidad] PRIMARY KEY ([IDEntidad])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE TABLE [NivelAcademico] (
        [IDNivel] int NOT NULL IDENTITY,
        [Descripcion] varchar(20) NULL,
        CONSTRAINT [PK_NivelAcademico] PRIMARY KEY ([IDNivel])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE TABLE [Provincia] (
        [IDProvincia] int NOT NULL IDENTITY,
        [Nombre] varchar(10) NULL,
        CONSTRAINT [PK_Provincia] PRIMARY KEY ([IDProvincia])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE TABLE [TipoEvento] (
        [IDEvento] int NOT NULL IDENTITY,
        [Descripcion] nvarchar(50) NULL,
        [Estado] int NULL,
        CONSTRAINT [PK_TipoEvento] PRIMARY KEY ([IDEvento])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE TABLE [TipoUsuario] (
        [IDTipo] int NOT NULL IDENTITY,
        [Descripcion] nvarchar(50) NULL,
        [Estado] int NULL,
        CONSTRAINT [PK_TipoUsuario] PRIMARY KEY ([IDTipo])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE TABLE [Tema] (
        [IDTema] int NOT NULL IDENTITY,
        [Descripcion] varchar(500) NULL,
        [IDTipo] int NULL,
        CONSTRAINT [PK_Tema] PRIMARY KEY ([IDTema]),
        CONSTRAINT [FK_Tema_TipoEvento] FOREIGN KEY ([IDTipo]) REFERENCES [TipoEvento] ([IDEvento]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE TABLE [Usuario] (
        [IDUsuario] int NOT NULL IDENTITY,
        [Apellido1] varchar(30) NULL,
        [Apellido2] varchar(30) NULL,
        [Clave] varchar(50) NULL,
        [Estado] int NULL,
        [FechaIngreso] date NULL,
        [IDEntidad] int NULL,
        [IDNivel] int NULL,
        [IDTipo] int NULL,
        [Nombre] varchar(30) NULL,
        [Usuario] varchar(50) NULL,
        CONSTRAINT [PK_Usuario] PRIMARY KEY ([IDUsuario]),
        CONSTRAINT [FK_Usuario_Entidad] FOREIGN KEY ([IDEntidad]) REFERENCES [Entidad] ([IDEntidad]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Usuario_NivelAC] FOREIGN KEY ([IDNivel]) REFERENCES [NivelAcademico] ([IDNivel]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Usuario_TipoUsuario] FOREIGN KEY ([IDTipo]) REFERENCES [TipoUsuario] ([IDTipo]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE TABLE [Contacto] (
        [IDContacto] int NOT NULL IDENTITY,
        [Identificador] varchar(30) NULL,
        [IDUsuario] int NULL,
        [TipoContacto] int NULL,
        CONSTRAINT [PK_Contacto] PRIMARY KEY ([IDContacto]),
        CONSTRAINT [FK_Contacto_Usuario] FOREIGN KEY ([IDUsuario]) REFERENCES [Usuario] ([IDUsuario]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE TABLE [Ubicacion] (
        [IDUbicacion] int NOT NULL IDENTITY,
        [IDCanton] int NULL,
        [IDDistrito] int NULL,
        [IDEvento] int NULL,
        [IDProvincia] int NULL,
        [Lugar] varchar(200) NULL,
        CONSTRAINT [PK_Ubicacion] PRIMARY KEY ([IDUbicacion]),
        CONSTRAINT [FK_Ubica_Canton] FOREIGN KEY ([IDCanton]) REFERENCES [Canton] ([IDCanton]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Ubica_Distrito] FOREIGN KEY ([IDDistrito]) REFERENCES [Distrito] ([IDdistrito]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Ubica_provincia] FOREIGN KEY ([IDProvincia]) REFERENCES [Provincia] ([IDProvincia]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE TABLE [Evento] (
        [IDEvento] int NOT NULL IDENTITY,
        [Calificacion] int NULL,
        [Estado] int NULL,
        [FechaFinal] datetime NULL,
        [FechaInicio] datetime NULL,
        [IDExpositor] int NULL,
        [IDTema] int NULL,
        [IDTipoEvento] int NULL,
        [IDUbicacion] int NULL,
        [Limite] int NULL,
        CONSTRAINT [PK_Evento] PRIMARY KEY ([IDEvento]),
        CONSTRAINT [FK_Evento_Usuario] FOREIGN KEY ([IDExpositor]) REFERENCES [Usuario] ([IDUsuario]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Evento_Tema] FOREIGN KEY ([IDTema]) REFERENCES [Tema] ([IDTema]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Evento_Ubica] FOREIGN KEY ([IDUbicacion]) REFERENCES [Ubicacion] ([IDUbicacion]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE TABLE [Calificacion] (
        [IDCalifiacion] int NOT NULL IDENTITY,
        [Calificacion] int NULL,
        [Comentario] varchar(1500) NULL,
        [IDEvento] int NULL,
        [IDUsuario] int NULL,
        CONSTRAINT [PK_Calificacion] PRIMARY KEY ([IDCalifiacion]),
        CONSTRAINT [FK_Calificacion_Evento] FOREIGN KEY ([IDEvento]) REFERENCES [Evento] ([IDEvento]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Calificacion_Usuario] FOREIGN KEY ([IDUsuario]) REFERENCES [Usuario] ([IDUsuario]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE TABLE [Reserva] (
        [IDReserva] int NOT NULL IDENTITY,
        [Confirma] int NULL,
        [IDEvento] int NULL,
        [IDUsuario] int NULL,
        [Reserva] int NULL,
        CONSTRAINT [PK_Reserva] PRIMARY KEY ([IDReserva]),
        CONSTRAINT [FK_Reserva_Evento] FOREIGN KEY ([IDEvento]) REFERENCES [Evento] ([IDEvento]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Reserva_Usuario] FOREIGN KEY ([IDUsuario]) REFERENCES [Usuario] ([IDUsuario]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE INDEX [IX_Calificacion_IDEvento] ON [Calificacion] ([IDEvento]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE INDEX [IX_Calificacion_IDUsuario] ON [Calificacion] ([IDUsuario]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE INDEX [IX_Contacto_IDUsuario] ON [Contacto] ([IDUsuario]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE INDEX [IX_Evento_IDExpositor] ON [Evento] ([IDExpositor]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE INDEX [IX_Evento_IDTema] ON [Evento] ([IDTema]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE INDEX [IX_Evento_IDUbicacion] ON [Evento] ([IDUbicacion]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE INDEX [IX_Reserva_IDEvento] ON [Reserva] ([IDEvento]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE INDEX [IX_Reserva_IDUsuario] ON [Reserva] ([IDUsuario]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE INDEX [IX_Tema_IDTipo] ON [Tema] ([IDTipo]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE INDEX [IX_Ubicacion_IDCanton] ON [Ubicacion] ([IDCanton]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE INDEX [IX_Ubicacion_IDDistrito] ON [Ubicacion] ([IDDistrito]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE INDEX [IX_Ubicacion_IDEvento] ON [Ubicacion] ([IDEvento]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE INDEX [IX_Ubicacion_IDProvincia] ON [Ubicacion] ([IDProvincia]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE INDEX [IX_Usuario_IDEntidad] ON [Usuario] ([IDEntidad]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE INDEX [IX_Usuario_IDNivel] ON [Usuario] ([IDNivel]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    CREATE INDEX [IX_Usuario_IDTipo] ON [Usuario] ([IDTipo]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    ALTER TABLE [Ubicacion] ADD CONSTRAINT [FK_Ubica_Evento] FOREIGN KEY ([IDEvento]) REFERENCES [Evento] ([IDEvento]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180708231834_FirstMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180708231834_FirstMigration', N'2.0.3-rtm-10026');
END;

GO

