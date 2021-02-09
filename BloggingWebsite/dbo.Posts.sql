USE [BlogDB]
GO

/****** Object: Table [dbo].[Posts] Script Date: 2/10/2021 12:25:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Posts] (
    [PostId]      UNIQUEIDENTIFIER NOT NULL,
    [Created]     DATETIME2 (7)    NOT NULL,
    [Description] NVARCHAR (MAX)   NULL,
    [Title]       NVARCHAR (MAX)   NULL
);


