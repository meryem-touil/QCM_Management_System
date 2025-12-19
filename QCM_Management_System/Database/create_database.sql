-- ==============================
-- Create Database
-- ==============================
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QCM_DB')
BEGIN
    CREATE DATABASE QCM_DB;
END
GO

USE QCM_DB;
GO