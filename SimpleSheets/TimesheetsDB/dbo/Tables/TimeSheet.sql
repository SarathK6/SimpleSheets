CREATE TABLE [dbo].[TimeSheet] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [mapId]          INT            NULL,
    [hours]          INT            NULL,
    [TimeTypeID]     INT            NULL,
    [approvalStatus] BIT            NULL,
    [description]    NVARCHAR (255) NULL,
    [created_at]     ROWVERSION     NOT NULL,
    [last_updated]   DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([mapId]) REFERENCES [dbo].[EmployeeProjectMap] ([id]),
    FOREIGN KEY ([TimeTypeID]) REFERENCES [dbo].[TimeType] ([id])
);

