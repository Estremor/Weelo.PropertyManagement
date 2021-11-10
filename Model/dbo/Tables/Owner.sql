CREATE TABLE [dbo].[Owner] (
    [IdOwner]  UNIQUEIDENTIFIER NOT NULL,
    [Name]     VARCHAR (200)    NOT NULL,
    [Address]  VARCHAR (500)    NOT NULL,
    [Document] NVARCHAR (MAX)   NULL,
    [Photo]    IMAGE            NULL,
    [Birthday] DATETIME         NOT NULL,
    CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED ([IdOwner] ASC)
);

