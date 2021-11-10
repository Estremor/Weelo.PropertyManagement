CREATE TABLE [dbo].[PropertyTrace] (
    [IdPropertyTrace] UNIQUEIDENTIFIER NOT NULL,
    [DataSale]        VARCHAR (500)    NULL,
    [Name]            VARCHAR (200)    NULL,
    [Value]           DECIMAL (18, 2)  NULL,
    [Tax]             DECIMAL (18, 2)  NULL,
    [IdProperty]      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_PropertyTrace] PRIMARY KEY CLUSTERED ([IdPropertyTrace] ASC),
    CONSTRAINT [FK_PropertyTrace_Property] FOREIGN KEY ([IdProperty]) REFERENCES [dbo].[Property] ([IdProperty])
);


GO
CREATE NONCLUSTERED INDEX [IX_PropertyTrace_IdProperty]
    ON [dbo].[PropertyTrace]([IdProperty] ASC);

