CREATE TABLE [dbo].[Property] (
    [IdProperty]   UNIQUEIDENTIFIER NOT NULL,
    [Name]         VARCHAR (200)    NOT NULL,
    [Address]      VARCHAR (500)    NOT NULL,
    [Price]        DECIMAL (18, 2)  NULL,
    [CodeInternal] VARCHAR (500)    NOT NULL,
    [Year]         INT              NOT NULL,
    [IdOwner]      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED ([IdProperty] ASC),
    CONSTRAINT [FK_Property_Owner] FOREIGN KEY ([IdOwner]) REFERENCES [dbo].[Owner] ([IdOwner])
);


GO
CREATE NONCLUSTERED INDEX [IX_Property_IdOwner]
    ON [dbo].[Property]([IdOwner] ASC);

