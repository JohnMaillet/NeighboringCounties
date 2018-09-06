PRINT N'Switching to Database master...';  
USE master;

if db_id('Counties') is not null
BEGIN
	ALTER DATABASE [Counties] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	PRINT N'Dropping Database Counties...';  
	DROP DATABASE [Counties];
END

PRINT N'Creating Database Counties...';  
CREATE DATABASE Counties;
GO

PRINT N'Switching to Database Counties...';  
USE [Counties];
GO

IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Creating tables
-- --------------------------------------------------
PRINT N'Creating CountyNumbers table...';  
-- Creating table 'CountyNumbers'
CREATE TABLE [dbo].[CountyNumbers] (
    [CountyID] int IDENTITY(1,1) NOT NULL,	
    [CountyName] varchar(255)  NOT NULL,
    [mapNumber] int  NOT NULL,
	[alphaOrder] int  NOT NULL,
    [Status] varchar(10)  NOT NULL	    
);
GO  
PRINT N'Creating AdjacentCounties table...';  
-- Creating table 'AdjacentCounties'
CREATE TABLE [dbo].[AdjacentCounties] (
    [AdjacencyID] int IDENTITY(1,1) NOT NULL,	
    [CountyName] varchar(255)  NULL,
	[AdjacentCountyName] varchar(255)  NULL
);
GO  

PRINT N'Adding Constraints...';
-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------
  
-- Creating primary key on [CountyID] in table 'CountyNumbers'
ALTER TABLE [dbo].[CountyNumbers]
ADD CONSTRAINT [PK_CountyNumbers]
    PRIMARY KEY CLUSTERED ([CountyID] ASC);
GO

-- Creating primary key on [AdjacencyID] in table 'AdjacentCounties'
ALTER TABLE [dbo].[AdjacentCounties]
ADD CONSTRAINT [PK_AdjacentCounties]
    PRIMARY KEY CLUSTERED ([AdjacencyID] ASC);
GO

GO

PRINT N'Creating stored procedure...';
GO

-- --------------------------------------------------
-- Creating stored procedure
-- --------------------------------------------------
CREATE PROCEDURE dbo.isAdjacent @County1 int, @County2 int
AS
select 
	cn.mapNumber, cn.CountyName 
from 
	dbo.CountyNumbers cn
where 
	cn.CountyName in ( 
						select 
							AdjacentCountyName as 'Adjacent County'
						from 
							dbo.AdjacentCounties 
						where 
							CountyName in (select 
												n.CountyName as County 
											from 
												dbo.CountyNumbers n, AdjacentCounties a
											where 
												n.mapNumber = @County1 
												and a.CountyName = n.CountyName))
	and cn.mapNumber = @County2;
GO

PRINT N'DONE: Database successfully created';
