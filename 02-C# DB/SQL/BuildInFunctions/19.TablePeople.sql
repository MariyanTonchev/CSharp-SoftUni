CREATE TABLE People (
    Id INT PRIMARY KEY,
    Name VARCHAR(255),
    Birthdate DATE
);

INSERT INTO People (Id, Name, Birthdate)
	VALUES 
	(1, 'Victor', '2000-12-07 00:00:00.000'),
	(2, 'Steven', '1992-09-10 00:00:00.000'),
	(3, 'Stephen', '1910-09-19 00:00:00.000'),
	(4, 'John', '2010-01-06 00:00:00.000');

SELECT
    [Name],
    DATEDIFF(YEAR, Birthdate, GETDATE()) AS AgeInYears,
    DATEDIFF(MONTH, Birthdate, GETDATE()) AS AgeInMonths,
    DATEDIFF(DAY, Birthdate, GETDATE()) AS AgeInDays,
    DATEDIFF(MINUTE, Birthdate, GETDATE()) AS AgeInMinutes
FROM
    People;