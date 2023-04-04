-- Use the master database before dropping the LRCH database
USE master;
GO
-- Drop the database if it exists.
DROP DATABASE IF EXISTS [LRCH];

-- If the database does not exist, then create it and use it.
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'LRCH')
	BEGIN
		CREATE DATABASE [LRCH];
	END
		GO
			USE [LRCH];
		GO

--------------------------------------------------------------------------------------------------------------
-- TABLES
--------------------------------------------------------------------------------------------------------------

-- Create a table of patients.
DROP TABLE IF EXISTS PATIENT;
CREATE TABLE PATIENT (
	PT_NO						INT			 IDENTITY(10000, 1) NOT NULL  PRIMARY KEY,
	PT_FNAME					VARCHAR(255) NOT NULL,
	PT_MNAME					VARCHAR(255),
	PT_LNAME					VARCHAR(255) NOT NULL,
	PT_PROVINCE					VARCHAR(255) NOT NULL,
	PT_CITY					    VARCHAR(255) NOT NULL,
	PT_STREET				    VARCHAR(255) NOT NULL,
	PT_POSTAL_CODE				VARCHAR(7)	 NOT NULL,
	PT_TEL						CHAR (12)	 NOT NULL,
	PT_SEX						CHAR(1)		 NOT NULL CHECK (PT_SEX IN ('M', 'F')),
	PT_HCN						VARCHAR (11) NOT NULL,
	PT_EXT						VARCHAR (3)
);

-- Create a table of physician specialties.
DROP TABLE IF EXISTS PHYSICIAN_SPECIALTY;
CREATE TABLE PHYSICIAN_SPECIALTY (
	SPECIALTY_ID				INT			 NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	SPECIALTY_DESC				VARCHAR(255) NOT NULL
);

-- Create a table of physicians.
DROP TABLE IF EXISTS PHYSICIAN;
CREATE TABLE PHYSICIAN (
	PHY_NO						INT			 NOT NULL IDENTITY(1000, 1) PRIMARY KEY,
	PHY_FNAME					VARCHAR(255) NOT NULL,
	PHY_LNAME					VARCHAR(255) NOT NULL,
	PHY_TEL						CHAR(12)	 NOT NULL,
	SPECIALTY_ID				INT			 NOT NULL,
	CONSTRAINT FK_PHYSICIAN_SPECIALTY_ID FOREIGN KEY (SPECIALTY_ID)
	REFERENCES PHYSICIAN_SPECIALTY (SPECIALTY_ID)
);

-- Create a table of patient physician records.
DROP TABLE IF EXISTS PHYSICIAN_PATIENT;
CREATE TABLE PHYSICIAN_PATIENT (
	PHY_PT_ID					INT			 NOT NULL IDENTITY(11, 1) PRIMARY KEY,
	PT_NO					    INT			 NOT NULL,
	PHY_NO					    INT			 NOT NULL,
	CONSTRAINT FK_PHYSICIAN_PATIENT_PT_NO FOREIGN KEY (PT_NO)
	REFERENCES PATIENT (PT_NO),
	CONSTRAINT FK_PHYSICIAN_PATIENT_PHY_NO FOREIGN KEY (PHY_NO)
	REFERENCES PHYSICIAN (PHY_NO)
);

-- Create a table of appointments.
DROP TABLE IF EXISTS APPOINTMENT;
CREATE TABLE APPOINTMENT (
	APT_ID		INT	 NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	APT_DATE	DATE NOT NULL,
	PT_NO		INT  NOT NULL, 
	PHY_NO		INT	 NOT NULL,
	CONSTRAINT FK_APPOINTMENT_PT_NO FOREIGN KEY (PT_NO)
	REFERENCES PATIENT (PT_NO),
	CONSTRAINT FK_APPOINTMENT_PHY_NO FOREIGN KEY (PHY_NO)
	REFERENCES PHYSICIAN (PHY_NO)
);

-- Create a table of treatments.
DROP TABLE IF EXISTS TREATMENT;
CREATE TABLE TREATMENT (
	TRMT_ID						INT			 NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	TRMT_NOTE					VARCHAR(255),
	APT_ID						INT		     NOT NULL,
	CONSTRAINT FK_TREATMENT_APT_ID FOREIGN KEY (APT_ID)
	REFERENCES APPOINTMENT (APT_ID)
);

-- Create a table of room types.
DROP TABLE IF EXISTS ROOM_TYPE;
CREATE TABLE ROOM_TYPE (
	RM_TYPE_ID					CHAR(2)		 PRIMARY KEY,
	RM_TYPE_DESC				VARCHAR(255) NOT NULL
);

-- Create a table of rooms
DROP TABLE IF EXISTS ROOM;
CREATE TABLE ROOM (
	RM_NO						INT	 		 NOT NULL PRIMARY KEY,
	RM_TYPE_ID					CHAR(2)	     NOT NULL,		
	RM_IS_OCCUPIED				BIT		     DEFAULT 0,
	CONSTRAINT FK_ROOM_RM_TYPE_ID FOREIGN KEY (RM_TYPE_ID)
	REFERENCES ROOM_TYPE (RM_TYPE_ID)
);

-- Create a table of beds.
DROP TABLE IF EXISTS BED;
CREATE TABLE BED (
	BED_LETTER					CHAR(1)	     NOT NULL CHECK (BED_LETTER IN ('A', 'B', 'C', 'D')),
	RM_NO						INT			 NOT NULL,
	BED_IS_OCCUPIED				BIT			 DEFAULT 0,
	PRIMARY KEY (RM_NO, BED_LETTER),
	CONSTRAINT FK_BED_RM_NO FOREIGN KEY (RM_NO)
	REFERENCES ROOM (RM_NO)
);

-- Create a table of patient stays.
DROP TABLE IF EXISTS PATIENT_STAY;
CREATE TABLE PATIENT_STAY (
	PT_STAY_ID					INT			 NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	PT_ADMITTED_DATE		    DATE,		 
	PT_DISCHARGE_DATE		    DATE,
	PT_NO						INT,
	RM_NO					    INT			 NOT NULL,
	BED_LETTER					CHAR(1)	     NOT NULL,
	CONSTRAINT FK_PATIENT_STAY_PT_NO FOREIGN KEY (PT_NO)
	REFERENCES PATIENT (PT_NO),
	CONSTRAINT FK_PATIENT_STAY_RM_NO_BED_LETTER 
	FOREIGN KEY(RM_NO, BED_LETTER) REFERENCES BED(RM_NO, BED_LETTER)
);

-- Create a table of financial statuses.
DROP TABLE IF EXISTS FIN_STATUS;
CREATE TABLE FIN_STATUS (
	FIN_STATUS_ID				INT			 NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	FIN_STATUS_DESC				VARCHAR(255) NOT NULL
);

-- Create a table of patient financial statuses.
DROP TABLE IF EXISTS PATIENT_FIN_STATUS;
CREATE TABLE PATIENT_FIN_STATUS (
	PT_FIN_STATUS_ID			INT			 NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	PT_NO						INT,		 
	FIN_STATUS_ID				INT			 NOT NULL,
	CONSTRAINT FK_PATIENT_FIN_STATUS_PT_NO FOREIGN KEY (PT_NO)
	REFERENCES PATIENT (PT_NO),
	CONSTRAINT FK_PATIENT_FIN_STATUS_FIN_STATUS_ID FOREIGN KEY (FIN_STATUS_ID)
	REFERENCES FIN_STATUS (FIN_STATUS_ID)
);

-- Create a table of financial source.
DROP TABLE IF EXISTS FIN_SOURCE;
CREATE TABLE FIN_SOURCE (
	FIN_SRC_ID					INT			 NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	FIN_SRC_DESC				VARCHAR(255) NOT NULL
);

-- Create a table of patient financial sources.
DROP TABLE IF EXISTS PATIENT_FIN_SOURCE;
CREATE TABLE PATIENT_FIN_SOURCE (
	PT_FIN_SRC_ID				INT			 NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	PT_NO						INT			 NOT NULL,		 
	FIN_SRC_ID					INT			 NOT NULL,
	CONSTRAINT FK_PATIENT_FIN_SOURCE_PT_NO FOREIGN KEY (PT_NO)
	REFERENCES PATIENT (PT_NO),
	CONSTRAINT FK_PATIENT_FIN_SOURCE_FIN_SRC_ID FOREIGN KEY (FIN_SRC_ID)
	REFERENCES FIN_SOURCE (FIN_SRC_ID)
);

-- Create a table of cost centers.
DROP TABLE IF EXISTS COST_CENTER;
CREATE TABLE COST_CENTER (
	COST_CENTER_ID				INT			 NOT NULL IDENTITY(100, 1) PRIMARY KEY,
	COST_CENTER_NAME 			VARCHAR(255) NOT NULL
);

-- Create a table of item prices.
DROP TABLE IF EXISTS ITEM_PRICE;
CREATE TABLE ITEM_PRICE (
	ITEM_PRICE_ID				INT			 NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	ITEM_PRICE 					MONEY		 NOT NULL
);

-- Create a table of items.
DROP TABLE IF EXISTS ITEM;
CREATE TABLE ITEM (
	ITEM_ID						INT			 NOT NULL IDENTITY(1000, 1) PRIMARY KEY,
	ITEM_DESC					VARCHAR(255) NOT NULL,
	ITEM_PRICE_ID			    INT			 NOT NULL,
	COST_CENTER_ID				INT			 NOT NULL,
	CONSTRAINT FK_ITEM_ITEM_PRICE_ID FOREIGN KEY (ITEM_PRICE_ID)
	REFERENCES ITEM_PRICE (ITEM_PRICE_ID),
	CONSTRAINT FK_ITEM_COST_CENTER_ID FOREIGN KEY (COST_CENTER_ID)
	REFERENCES COST_CENTER (COST_CENTER_ID)
);

-- Create a table of financial transactions.
DROP TABLE IF EXISTS FIN_TRANSACTION;
CREATE TABLE FIN_TRANSACTION (
	TRANS_ID					INT			 NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	TRANS_DATE					DATE		 NOT NULL,
	PT_FIN_SRC_ID			    INT			 NOT NULL,
	ITEM_ID						INT			 NOT NULL,
	CONSTRAINT FK_FIN_TRANSACTION_PT_FIN_SRC_ID FOREIGN KEY (PT_FIN_SRC_ID)
	REFERENCES PATIENT_FIN_SOURCE (PT_FIN_SRC_ID),
	CONSTRAINT FK_FIN_TRANSACTION_ITEM_ID FOREIGN KEY (ITEM_ID)
	REFERENCES ITEM (ITEM_ID)
);

-- Create a table of invoices.
DROP TABLE IF EXISTS INVOICE;
CREATE TABLE INVOICE (
	INV_ID						INT			 NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	INV_DATE 					DATE		 NOT NULL,
	TRANS_ID					INT			 NOT NULL,
	CONSTRAINT FK_INVOICE_TRANCE_ID FOREIGN KEY (TRANS_ID)
	REFERENCES FIN_TRANSACTION (TRANS_ID)
);

GO

--------------------------------------------------------------------------------------------------------------
-- TRIGGERS
--------------------------------------------------------------------------------------------------------------

-- Create a trigger for inserting room number in the patient stay table.
CREATE TRIGGER trgPatientStayInsertRoom
ON PATIENT_STAY
AFTER INSERT
AS
BEGIN
    -- Update the "IS_OCCUPIED" column in the "Room" table
    UPDATE ROOM
    SET RM_IS_OCCUPIED = 1
    FROM ROOM
    INNER JOIN inserted ON ROOM.RM_NO = inserted.RM_NO
END

GO

-- Create a trigger for inserting bed in the patient stay table.
CREATE TRIGGER trgPatientStayInsertBed
ON PATIENT_STAY
AFTER INSERT
AS
BEGIN
    -- Update the "IS_OCCUPIED" column in the "Room" table
    UPDATE BED
    SET BED_IS_OCCUPIED = 1
    FROM BED
    INNER JOIN inserted ON BED.RM_NO = inserted.RM_NO
	AND BED.BED_LETTER = inserted.BED_LETTER
END

GO

--------------------------------------------------------------------------------------------------------------
-- STORED PROCEDURES
--------------------------------------------------------------------------------------------------------------

-- Create a stored procedure for generating room utilization
CREATE PROCEDURE spGetRoomUtilization
AS
BEGIN
SELECT DISTINCT CONCAT(r.RM_NO, b.BED_LETTER) AS 'LOCATION', 
	   rt.RM_TYPE_DESC AS 'TYPE',
      ps.PT_NO AS 'PATIENT-NO', 
      CONCAT(p.PT_LNAME, ', ' , p.PT_FNAME, p.PT_MNAME) AS 'PATIENT-NAME', 
      ps.PT_ADMITTED_DATE AS 'ADMITTED-DATE' 
	   FROM ROOM r, BED b, PATIENT_STAY ps, PATIENT p, ROOM_TYPE rt 
      WHERE r.RM_NO = ps.RM_NO AND ps.PT_NO = p.PT_NO AND ps.BED_LETTER = b.BED_LETTER
	   AND r.RM_TYPE_ID = rt.RM_TYPE_ID
END

GO

-- Create a stored procedure to count the total number of beds per room type
CREATE PROCEDURE spCountTotalBedsPerRoomType (
	@RoomType CHAR(2)
) AS
BEGIN
SELECT COUNT(BED.BED_LETTER) AS 'Total beds'
FROM ROOM_TYPE
JOIN ROOM ON ROOM.RM_TYPE_ID = ROOM_TYPE.RM_TYPE_ID
JOIN BED ON BED.RM_NO = ROOM.RM_NO WHERE ROOM_TYPE.RM_TYPE_ID = @RoomType
GROUP BY ROOM_TYPE.RM_TYPE_ID
END

GO

-- Create a stored procedure to count the total number of empty beds per room type
CREATE PROCEDURE spCountEmptyBedsPerRoomType (
	@RoomType CHAR(2)
) AS
BEGIN
SELECT COUNT(BED.BED_LETTER) AS 'Total beds'
FROM ROOM_TYPE
JOIN ROOM ON ROOM.RM_TYPE_ID = ROOM_TYPE.RM_TYPE_ID
JOIN BED ON BED.RM_NO = ROOM.RM_NO 
WHERE ROOM_TYPE.RM_TYPE_ID = @RoomType
AND ROOM.RM_IS_OCCUPIED = 0
GROUP BY ROOM_TYPE.RM_TYPE_ID
END