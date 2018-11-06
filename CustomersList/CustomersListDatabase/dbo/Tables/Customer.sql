CREATE TABLE [dbo].[Customer] (
    [Id]               UNIQUEIDENTIFIER CONSTRAINT [DF_Customer_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Name]             VARCHAR (200)    NOT NULL,
    [Website]          VARCHAR (100)    NULL,
    [Email]            VARCHAR (100)    NULL,
    [Telephone]        VARCHAR (15)     NOT NULL,
    [PostalAddress]    UNIQUEIDENTIFIER NOT NULL,
    [InvoicingAddress] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Customer_PostalAddress] FOREIGN KEY ([PostalAddress]) REFERENCES [dbo].[Address] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

