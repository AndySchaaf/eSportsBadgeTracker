use data;

UPDATE Tickets
SET Reserved = 0
WHERE Reserved = 1;

TRUNCATE TABLE Attendees;

SELECT * FROM Attendees

SELECT * FROM CustomerInfo

SELECT * FROM Tickets