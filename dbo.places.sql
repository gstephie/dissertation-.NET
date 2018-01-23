CREATE TABLE [dbo].[places] (
    [id]          INT          IDENTITY (1, 1) NOT NULL,
    [name]        VARCHAR (50) NOT NULL,
    [county]      VARCHAR (10) NOT NULL,
    [wet_notwet]  BIT          NOT NULL,
    [lang_origin] VARCHAR (50) NOT NULL,
    [etymology]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

