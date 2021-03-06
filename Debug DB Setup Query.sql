-- THIS IS USED TO RESET THE DB FOR DEBUG PURPOSES
-- You can also grab samples of the INSERT statements below!


-- DON'T USE THIS UNLESS YOU REALLY FUCKED UP THE DB, INSTEAD
-- USE THE RESETEVENT.SQL! I will find you.
use data;

DROP TABLE dbo.Attendees
DROP TABLE dbo.CustomerInfo

-- Drop this and I'll go after you.
-----------------------------------
--DROP TABLE dbo.ErrorMessages

-- No Badge Table
DROP TABLE dbo.NoBadgeNums
CREATE TABLE [dbo].[NoBadgeNums]
(
	[ID] varchar(10) NOT NULL PRIMARY KEY
)

-- Ticket table handling
DROP TABLE dbo.Tickets
CREATE TABLE [dbo].[Tickets]
(
	[ID] varchar(30) NOT NULL PRIMARY KEY,
	[Reserved] bit NOT NULL DEFAULT 0
)


INSERT INTO dbo.Tickets (ID) Values (1), (2), (3), (4), (5), (6), (7), (8), (9), (10)

CREATE TABLE [dbo].[CustomerInfo]
(
	[ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [fName] varchar(30) NOT NULL, 
    [lName] varchar(30) NOT NULL,
	[email] varchar(50) DEFAULT NULL,
	[VIP] bit DEFAULT 0,
	[canGetPrize] bit DEFAULT 0,
	[preregistered] bit DEFAULT 0,
	[gender] varchar(1) NOT NULL
)

CREATE TABLE [dbo].Attendees
(
	[custID] INT NOT NULL,
    [tickID] varchar(30) UNIQUE NOT NULL,
	[RegistrationTime] DATETIME DEFAULT GETDATE(),
	[Raffle_VIP] int NULL,
	[Raffle_PreRegister] int NULL,
	[Raffle_CheckIn] int NULL,
	CONSTRAINT PK_Attendee PRIMARY KEY NONCLUSTERED ([custID], [tickID]),
	CONSTRAINT FK_CustomerInfo foreign key (custID) references dbo.CustomerInfo(ID),
	CONSTRAINT FK_Ticket foreign key (tickID) references dbo.Tickets(ID)
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

INSERT INTO dbo.CustomerInfo (fName, lName, email, gender, VIP) 
Values ('Gabriel', 'Franco', 'gabriel@email.com', 'M', 1)

INSERT INTO dbo.CustomerInfo (fName, lName, email, gender, VIP) 
Values ('Maikol', 'Brito', 'maikol@email.com', 'M', 1)

INSERT INTO dbo.CustomerInfo (fName, lName, email, gender, VIP) 
Values ('Derek', 'DePontbriand', 'derek@email.com', 'M', 1)

INSERT INTO dbo.CustomerInfo (fName, lName, email, gender) 
Values ('The Andy', 'Man', 'andy@email.com', 'M')

INSERT INTO dbo.CustomerInfo (fName, lName, email, gender) 
Values ('Ebli', 'Rosa', 'ebli@email.com', 'M')

INSERT INTO dbo.CustomerInfo (fName, lName, email, gender) 
Values ('Sample', 'Sam', 'andy@email.com', 'F')

INSERT INTO dbo.CustomerInfo (fName, lName, email, gender) 
Values ('Mary', 'Thomas', 'ebli@email.com', 'F')

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