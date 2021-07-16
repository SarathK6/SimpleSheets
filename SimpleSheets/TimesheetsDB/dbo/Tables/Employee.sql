CREATE TABLE [dbo].[Employee] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [fullName]     NVARCHAR (255) NULL,
    [username]     NVARCHAR (255) NULL,
    [empId]        NVARCHAR (255) NULL,
    [created_at]   ROWVERSION     NOT NULL,
    [last_updated] DATETIME       NULL,
    [roleId]       INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([roleId]) REFERENCES [dbo].[Role] ([id])
);

