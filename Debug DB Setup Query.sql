-- THIS IS USED TO RESET THE DB FOR DEBUG PURPOSES
-- You can also grab samples of the INSERT statements below!
use data;

DROP TABLE dbo.Attendees
DROP TABLE dbo.CustomerInfo
DROP TABLE dbo.Tickets

-- Drop this and I'll go after you.
-----------------------------------
--DROP TABLE dbo.ErrorMessages

CREATE TABLE [dbo].[Tickets]
(
	[ID] INT NOT NULL PRIMARY KEY,
	[Reserved] bit NOT NULL DEFAULT 0
)

CREATE TABLE [dbo].[CustomerInfo]
(
	[ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [fName] NCHAR(30) NOT NULL, 
    [lName] NCHAR(30) NOT NULL,
	[email] NCHAR(50) DEFAULT NULL,
	[VIP] bit DEFAULT 0,
	[Meal] bit DEFAULT 0,
	[canGetPrize] bit DEFAULT 0
)

CREATE TABLE [dbo].Attendees
(
	[AttendeeID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[custID] INT NOT NULL,
    [tickID] INT UNIQUE NULL,
	[RegistrationTime] DATETIME DEFAULT GETDATE(),
	constraint FK_CustomerInfo foreign key (custID) references dbo.CustomerInfo(ID),
	constraint FK_Ticket foreign key (tickID) references dbo.Tickets(ID)
)

/*
DON'T USE THIS UNLESS YOU ARE RESETTING THE LOGIN INFO OR ADDING IN NEW ACCOUNTS
--------------------------------------------------------------------------------

use data;

CREATE TABLE [dbo].AuthorizedUsers
(
	[Username] nvarchar(30) NOT NULL PRIMARY KEY,
	[Pass] nvarchar(30)
)

INSERT INTO dbo.AuthorizedUsers (Username, Pass)
VALUES ('laz', 'esports'), ('admin', 'goeagles1'), ('test', 'test')
*/

INSERT INTO dbo.Tickets (ID)
Values (1), (2), (3), (4), (5), (6), (7), (8), (9), (10)

INSERT INTO dbo.CustomerInfo (fName, lName, email, VIP) 
Values ('Gabriel', 'Franco', 'gabriel@email.com', 1)

INSERT INTO dbo.CustomerInfo (fName, lName, email, VIP) 
Values ('Maikol', 'Brito', 'maikol@email.com', 1)

INSERT INTO dbo.CustomerInfo (fName, lName, email, VIP) 
Values ('Derek', 'DePontbriand', 'derek@email.com', 1)

INSERT INTO dbo.CustomerInfo (fName, lName, email) 
Values ('The Andy', 'Man', 'andy@email.com')

INSERT INTO dbo.CustomerInfo (fName, lName, email) 
Values ('Ebli', 'Rosa', 'ebli@email.com')

INSERT INTO dbo.CustomerInfo (fName, lName, email) 
Values ('Sample', 'Sam', 'andy@email.com')

INSERT INTO dbo.CustomerInfo (fName, lName, email) 
Values ('Mary', 'Thomas', 'ebli@email.com')

/*
SAMPLE ADDING ERROR MESSAGES
------------------------------------------------------

CREATE TABLE [dbo].ErrorMessages
(
	[ID] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Message] nvarchar(100) NOT NULL
)

INSERT INTO dbo.ErrorMessages (Message)
Values ('ERROR: Ticket is already registered.')


SAMPLE EXECS FOR STORED PROCEDURES
------------------------------------------------------

EXEC RegisterCustomer 'laz', 'padron', 'laz@email.com'
GetUnregCustomersByFilter '%gab%', '%%', '%%'
*/