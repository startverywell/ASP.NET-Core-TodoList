CREATE TABLE [dbo].[todo] (
    [Id]     INT        IDENTITY (1, 1) NOT NULL,
    [name]   NCHAR (50) NOT NULL,
    [type]   SMALLINT   DEFAULT ((0)) NOT NULL,
    [active] SMALLINT   DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

