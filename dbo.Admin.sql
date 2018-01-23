CREATE TABLE [dbo].[Admin] (
    [user_id]  INT          IDENTITY (1, 1) NOT NULL,
    [username] VARCHAR (20) NOT NULL,
    [password] VARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([user_id] ASC)
);

