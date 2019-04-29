
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/29/2019 17:16:08
-- Generated from EDMX file: C:\Users\ZestPC\source\repos\mlTest\01.DB\mlTest.db.con\mlTest.db.con\mlTest.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [mlTest];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MLSet'
CREATE TABLE [dbo].[MLSet] (
    [IDX] int IDENTITY(1,1) NOT NULL,
    [TITLE] nvarchar(max)  NULL,
    [CONTENT] nvarchar(max)  NULL,
    [REG_DT] datetime  NULL,
    [EDT_DT] datetime  NULL,
    [REG_NM] nvarchar(max)  NULL,
    [EDT_NM] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDX] in table 'MLSet'
ALTER TABLE [dbo].[MLSet]
ADD CONSTRAINT [PK_MLSet]
    PRIMARY KEY CLUSTERED ([IDX] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------