/*
	This query resets tickets and removes all active attendees.
*/

use data;

UPDATE Tickets
SET Reserved = 0
WHERE Reserved = 1;

TRUNCATE TABLE Attendees;