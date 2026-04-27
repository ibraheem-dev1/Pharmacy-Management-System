-- ========================================
-- FIX SALEDETAIL TABLE PRIMARY KEY ISSUE
-- ========================================
-- This script checks and fixes the SaleDetail table schema
-- to support FIFO batch selling where multiple rows can have the same SaleID

USE PharmacyDB;
GO

-- Check current schema
PRINT '=== CURRENT SALEDETAIL TABLE SCHEMA ===';
SELECT 
    c.COLUMN_NAME,
    c.DATA_TYPE,
    c.IS_NULLABLE,
    c.COLUMN_DEFAULT,
    CASE WHEN EXISTS (
        SELECT 1 FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE k
        WHERE k.TABLE_NAME = 'SaleDetail' 
        AND k.COLUMN_NAME = c.COLUMN_NAME
        AND k.CONSTRAINT_NAME LIKE 'PK%'
    ) THEN 'PRIMARY KEY' ELSE '' END AS KeyType
FROM INFORMATION_SCHEMA.COLUMNS c
WHERE TABLE_NAME = 'SaleDetail'
ORDER BY ORDINAL_POSITION;
GO

-- Check existing primary key constraint
PRINT '=== EXISTING PRIMARY KEY CONSTRAINTS ===';
SELECT 
    CONSTRAINT_NAME,
    COLUMN_NAME
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
WHERE TABLE_NAME = 'SaleDetail' 
AND CONSTRAINT_NAME LIKE 'PK%';
GO

-- Check if SaleDetailID exists and is auto-increment
PRINT '=== CHECKING FOR AUTO-INCREMENT IDENTITY ===';
SELECT 
    COLUMN_NAME,
    COLUMNPROPERTY(OBJECT_ID('SaleDetail'), COLUMN_NAME, 'IsIdentity') AS IsIdentity
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'SaleDetail' 
AND COLUMN_NAME = 'SaleDetailID';
GO

-- View sample data to understand current structure
PRINT '=== SAMPLE DATA (First 10 rows) ===';
IF EXISTS (SELECT 1 FROM SaleDetail)
BEGIN
    SELECT TOP 10 * FROM SaleDetail ORDER BY SaleID;
END
ELSE
BEGIN
    PRINT 'No data in SaleDetail table';
END
GO

-- ========================================
-- SOLUTION 1: If SaleDetailID doesn't exist or isn't auto-increment
-- ========================================
-- Uncomment the section below if you need to add/fix SaleDetailID as auto-increment primary key

/*
-- Drop existing primary key if it exists
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
           WHERE TABLE_NAME = 'SaleDetail' AND CONSTRAINT_TYPE = 'PRIMARY KEY')
BEGIN
    DECLARE @PKConstraintName NVARCHAR(200);
    SELECT @PKConstraintName = CONSTRAINT_NAME 
    FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
    WHERE TABLE_NAME = 'SaleDetail' AND CONSTRAINT_TYPE = 'PRIMARY KEY';
    
    EXEC('ALTER TABLE SaleDetail DROP CONSTRAINT ' + @PKConstraintName);
    PRINT 'Dropped existing primary key: ' + @PKConstraintName;
END
GO

-- Add SaleDetailID as auto-increment primary key if it doesn't exist
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'SaleDetail' AND COLUMN_NAME = 'SaleDetailID')
BEGIN
    ALTER TABLE SaleDetail ADD SaleDetailID INT IDENTITY(1,1) NOT NULL;
    PRINT 'Added SaleDetailID column with IDENTITY';
END
ELSE IF COLUMNPROPERTY(OBJECT_ID('SaleDetail'), 'SaleDetailID', 'IsIdentity') = 0
BEGIN
    PRINT 'ERROR: SaleDetailID exists but is not an IDENTITY column.';
    PRINT 'You need to recreate the table or manually fix the column.';
END
GO

-- Create primary key on SaleDetailID
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
               WHERE TABLE_NAME = 'SaleDetail' AND CONSTRAINT_TYPE = 'PRIMARY KEY')
BEGIN
    ALTER TABLE SaleDetail ADD CONSTRAINT PK_SaleDetail PRIMARY KEY (SaleDetailID);
    PRINT 'Created primary key on SaleDetailID';
END
GO
*/

-- ========================================
-- SOLUTION 2: If you want composite primary key (SaleID, BatchID)
-- ========================================
-- Uncomment this section if you prefer composite key instead of auto-increment

/*
-- Drop existing primary key
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
           WHERE TABLE_NAME = 'SaleDetail' AND CONSTRAINT_TYPE = 'PRIMARY KEY')
BEGIN
    DECLARE @PKConstraintName NVARCHAR(200);
    SELECT @PKConstraintName = CONSTRAINT_NAME 
    FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
    WHERE TABLE_NAME = 'SaleDetail' AND CONSTRAINT_TYPE = 'PRIMARY KEY';
    
    EXEC('ALTER TABLE SaleDetail DROP CONSTRAINT ' + @PKConstraintName);
    PRINT 'Dropped existing primary key: ' + @PKConstraintName;
END
GO

-- Create composite primary key on (SaleID, BatchID)
ALTER TABLE SaleDetail ADD CONSTRAINT PK_SaleDetail PRIMARY KEY (SaleID, BatchID);
PRINT 'Created composite primary key on (SaleID, BatchID)';
GO
*/

PRINT '=== SCRIPT COMPLETED ===';
PRINT 'Review the output above to determine which solution to apply.';
PRINT 'Then uncomment the appropriate section and re-run this script.';
GO
