use data;

UPDATE Tickets
SET Reserved = 0
WHERE Reserved = 1;

TRUNCATE TABLE Attendees;

TRUNCATE TABLE NoBadgeNums;

--TRUNCATE TABLE Tickets;

SELECT * FROM Attendees

SELECT * FROM CustomerInfo

SELECT * FROM Tickets

SELECT * FROM NoBadgeNums


/*
DELETE FROM CustomerInfo
WHERE gender is null
*/