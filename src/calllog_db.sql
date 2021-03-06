IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [CallStatus] (
    [Id] int NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_CallStatus] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [CallLogs] (
    [Id] int NOT NULL IDENTITY,
    [Caller] nvarchar(max) NULL,
    [Title] nvarchar(max) NULL,
    [Problem] nvarchar(max) NULL,
    [Solution] nvarchar(max) NULL,
    [CallStatusId] int NULL,
    [WhenCreated] datetime2 NOT NULL,
    CONSTRAINT [PK_CallLogs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CallLogs_CallStatus_CallStatusId] FOREIGN KEY ([CallStatusId]) REFERENCES [CallStatus] ([Id]) ON DELETE NO ACTION
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[CallStatus]'))
    SET IDENTITY_INSERT [CallStatus] ON;
INSERT INTO [CallStatus] ([Id], [Name])
VALUES (0, N'New'),
(1, N'Working'),
(2, N'Closed'),
(3, N'Rejected');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[CallStatus]'))
    SET IDENTITY_INSERT [CallStatus] OFF;
GO

CREATE INDEX [IX_CallLogs_CallStatusId] ON [CallLogs] ([CallStatusId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210820172102_InitialCreate', N'5.0.9');
GO

COMMIT;
GO


