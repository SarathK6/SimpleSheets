CREATE TABLE [dbo].[Role] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [title]        NVARCHAR (255) NULL,
    [created_at]   ROWVERSION     NOT NULL,
    [last_updated] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

