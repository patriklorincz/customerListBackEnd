CREATE TABLE [dbo].[Address] (
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_Address_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Street]   VARCHAR (100)    NULL,
    [Number]   VARCHAR (10)     NULL,
    [Postcode] VARCHAR (100)    NOT NULL,
    [City]     VARCHAR (100)    NULL,
    [Country]  VARCHAR (100)    NOT NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id] ASC)
);

