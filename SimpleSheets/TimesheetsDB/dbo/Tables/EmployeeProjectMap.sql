CREATE TABLE [dbo].[EmployeeProjectMap] (
    [id]        INT IDENTITY (1, 1) NOT NULL,
    [empId]     INT NULL,
    [projectId] INT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([empId]) REFERENCES [dbo].[Employee] ([id]),
    FOREIGN KEY ([projectId]) REFERENCES [dbo].[Projects] ([id]),
    FOREIGN KEY ([projectId]) REFERENCES [dbo].[Projects] ([id])
);

