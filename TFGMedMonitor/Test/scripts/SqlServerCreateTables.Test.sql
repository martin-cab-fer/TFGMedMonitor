 /* 
 * SQL Server Script
 * 
 * In a local environment (for example, with the SQLServerExpress instance 
 * included in the VStudio installation) it will be necessary to create the 
 * database and the user required by the connection string. So, the following
 * steps are needed:
 *
 *     Configure the @Default_DB_Path variable with the path where 
 *     database and log files will be created  
 *
 * This script can be executed from MS Sql Server Management Studio Express,
 * but also it is possible to use a command Line syntax:
 *
 *    > sqlcmd.exe -U [user] -P [password] -I -i SqlServerCreateTables.sql
 *
 */


 /******************************************************************************/
 /*** PATH to store the db files. This path must exists in the local system. ***/
 /******************************************************************************/

 DECLARE @Default_DB_Path as VARCHAR(64)  
 SET @Default_DB_Path = N'C:\TFGMedMonitor\db'

 USE [master]

/* Drop database if already exists */
IF  EXISTS (SELECT name FROM sys.databases WHERE name = 'medmonitor_test')
	DROP DATABASE [medmonitor_test]

USE [master]


/* DataBase Creation */

	                              
DECLARE @sql nvarchar(500)

SET @sql = 
  N'CREATE DATABASE [medmonitor_test] 
    ON PRIMARY ( NAME = medmonitor_test, FILENAME = "' + @Default_DB_Path + N'medmonitor_test.mdf")
    LOG ON ( NAME = medmonitor_test_log, FILENAME = "' + @Default_DB_Path + N'medmonitor_test_log.ldf")'

EXEC(@sql)
PRINT N'Database [medmonitor_test] created.'
GO

 
USE [medmonitor_test]


/* ********** Drop Tables if already exist *********** */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[UserAction]') AND type in ('U'))
DROP TABLE [UserAction]

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Dose]') AND type in ('U'))
DROP TABLE [Dose]

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Prescription]') AND type in ('U'))
DROP TABLE [Prescription]

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Medicine]') AND type in ('U'))
DROP TABLE [Medicine]

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Analytic]') AND type in ('U'))
DROP TABLE [Analytic]

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[PatientEAssign]') AND type in ('U'))
DROP TABLE [PatientEAssign]

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[PatientDAssign]') AND type in ('U'))
DROP TABLE [PatientDAssign]

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Patient]') AND type in ('U'))
DROP TABLE [Patient]

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[ChatMessage]') AND type in ('U'))
DROP TABLE [ChatMessage]

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[UserProfile]') AND type in ('U'))
DROP TABLE [UserProfile]

GO

/*
 * Create tables.
 * UserProfile table is created. Indexes required for the 
 * most common operations are also defined.
 */

CREATE TABLE UserProfile (
	usrId bigint IDENTITY(1,1) NOT NULL,
	loginName varchar(30) NOT NULL,
	enPassword varchar(50) NOT NULL,
	firstName varchar(30) NOT NULL,
	lastName varchar(40) NOT NULL,
	email varchar(60) NOT NULL,
	language varchar(2) NOT NULL,
	country varchar(2) NOT NULL,
	userType smallint NOT NULL,

	CONSTRAINT [PK_UserProfile] PRIMARY KEY (usrId),
	CONSTRAINT [UniqueKey_Login] UNIQUE (loginName)
)

CREATE NONCLUSTERED INDEX [IX_UserProfileIndexByLoginName]
ON [UserProfile] ([loginName] ASC)

GO

CREATE TABLE ChatMessage (
	messageId bigint IDENTITY(1,1) NOT NULL,
	creationDate datetime NOT NULL,
	title varchar(60) NOT NULL,
	messageText varchar(255) NOT NULL,
	sender bigint NOT NULL,
	addressee bigint NOT NULL,

	CONSTRAINT [PK_ChatMessage] PRIMARY KEY (messageId),
	CONSTRAINT [ForeignKey_ChatMessageS] FOREIGN KEY (sender) REFERENCES UserProfile (usrId) ON DELETE CASCADE,
	CONSTRAINT [ForeignKey_ChatMessageA] FOREIGN KEY (addressee) REFERENCES UserProfile (usrId)
)

GO

CREATE TABLE Patient (
	patientId bigint IDENTITY(1,1) NOT NULL,
	patientName varchar(60) NOT NULL,
	birthDate datetime NOT NULL,
	info varchar(255) NOT NULL,

	CONSTRAINT [PK_Patient] PRIMARY KEY (patientId),
	CONSTRAINT [UniqueKey_Patient] UNIQUE (patientName)
)

GO

CREATE TABLE PatientDAssign (
	patient bigint NOT NULL,
	doctor bigint NOT NULL, 

	CONSTRAINT [PK_PattientDAssign] PRIMARY KEY (patient, doctor),
	CONSTRAINT [ForeignKey_PattientDAssignP] FOREIGN KEY (patient) REFERENCES Patient (patientId) ON DELETE CASCADE,
	CONSTRAINT [ForeignKey_PattientDAssignD] FOREIGN KEY (doctor) REFERENCES UserProfile (usrId) ON DELETE CASCADE
)

GO

CREATE TABLE PatientEAssign (
	patient bigint NOT NULL,
	employee bigint NOT NULL, 

	CONSTRAINT [PK_PattientEAssign] PRIMARY KEY (patient, employee),
	CONSTRAINT [ForeignKey_PattientEAssignP] FOREIGN KEY (patient) REFERENCES Patient (patientId) ON DELETE CASCADE,
	CONSTRAINT [ForeignKey_PattientEAssignE] FOREIGN KEY (employee) REFERENCES UserProfile (usrId) ON DELETE CASCADE
)

GO

CREATE TABLE Analytic(
	patientId bigint NOT NULL,
	measurementTime datetime NOT NULL,
	attendant bigint,
	patientWeight float NOT NULL DEFAULT 0,
	usedProcedure varchar(60) NOT NULL,
	observations varchar(255) NOT NULL,

	CONSTRAINT [PK_Analytic] PRIMARY KEY (patientId, measurementTime),
	CONSTRAINT [ForeignKey_AnalyticP] FOREIGN KEY (patientId) REFERENCES Patient (patientId) ON DELETE CASCADE,
	CONSTRAINT [ForeignKey_AnalyticA] FOREIGN KEY (attendant) REFERENCES UserProfile (usrId)
)

GO

CREATE TABLE Medicine (
	medicineId bigint IDENTITY(1,1) NOT NULL,
	registerNumber bigint NOT NULL,
	medName varchar(200) NOT NULL,
	labName varchar(200) NOT NULL,
	authDate datetime NOT NULL,
	medStatus varchar(50) NOT NULL,
	statusDate datetime NOT NULL,
	ATCCode varchar(7) NOT NULL,
	activePrinc varchar(255) NOT NULL,
	activePrincN smallint NOT NULL,
	commercialized varchar(2) NOT NULL,
	yellowTriangle varchar(2) NOT NULL,
	observations varchar(255) NOT NULL,
	substitutes varchar(255),
	affectsConduction varchar(2) NOT NULL,
	supplyIssues varchar(2) NOT NULL,

	CONSTRAINT [PK_Medicine] PRIMARY KEY (medicineId),
	CONSTRAINT [UniqueKey_Medicine] UNIQUE (registerNumber)
)

GO

CREATE TABLE Prescription (
	prescriptionId bigint IDENTITY(1,1) NOT NULL,
	patient bigint NOT NULL,
	creationDate datetime NOT NULL,
	medicine bigint NOT NULL,
	frequency smallint NOT NULL,
	administration varchar(60) NOT NULL,

	CONSTRAINT [PK_Prescription] PRIMARY KEY (prescriptionId),
	CONSTRAINT [ForeignKey_PrescriptionP] FOREIGN KEY (patient) REFERENCES Patient (patientId) ON DELETE CASCADE,
	CONSTRAINT [ForeignKey_PrescriptionM] FOREIGN KEY (medicine) REFERENCES Medicine (medicineId) ON DELETE CASCADE,
)

CREATE TABLE Dose (
	prescriptionId bigint NOT NULL,
	administrationTime datetime NOT NULL,
	administrator bigint NOT NULL,
	notes varchar(60),

	CONSTRAINT [PK_Dose] PRIMARY KEY (prescriptionId, administrationTime),
	CONSTRAINT [ForeignKey_DoseP] FOREIGN KEY (prescriptionId) REFERENCES Prescription (prescriptionId) ON DELETE CASCADE,
	CONSTRAINT [ForeignKey_DoseA] FOREIGN KEY (administrator) REFERENCES UserProfile (usrId),
)

GO

CREATE TABLE UserAction (
	actionId bigint IDENTITY(1,1) NOT NULL,
	actionTime datetime NOT NULL,
	actor bigint NOT NULL,
	performedAction int NOT NULL,
	stringVal varchar(60),
	intVal bigint,
	actionText varchar(255),

	CONSTRAINT [PK_UserAction] PRIMARY KEY (actionId),
	CONSTRAINT [ForeignKey_UserActionA] FOREIGN KEY (actor) REFERENCES UserProfile (usrId),
)

GO