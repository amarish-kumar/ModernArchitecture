CREATE TABLE [dbo].[User] (
    [ID]       UNIQUEIDENTIFIER NOT NULL,
    [IsActive] BIT              NOT NULL,
    [Username] NVARCHAR (128)   NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([ID] ASC)
);

