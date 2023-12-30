-- Exercise 1: Create the Minions database
CREATE DATABASE Minions;

-- Exercise 2: Create the Minions and Towns tables
CREATE TABLE Minions (
    Id INT PRIMARY KEY,
    Name VARCHAR(255),
    Age INT,
    TownId INT
);

CREATE TABLE Towns (
    Id INT PRIMARY KEY,
    Name VARCHAR(255)
);

-- Exercise 3: Alter the Minions table to add the TownId column as a foreign key
ALTER TABLE Minions
ADD CONSTRAINT FK_TownId FOREIGN KEY (TownId) REFERENCES Towns(Id);

-- Exercise 4: Insert records into both tables
INSERT INTO Towns (Id, Name)
VALUES
    (1, 'Sofia'),
    (2, 'Plovdiv'),
    (3, 'Varna');

INSERT INTO Minions (Id, Name, Age, TownId)
VALUES
    (1, 'Kevin', 22, 1),
    (2, 'Bob', 15, 3),
    (3, 'Steward', NULL, 2);

--Exercise 5: Delete all data from the Minions table
TRUNCATE TABLE Minions;

--Exercise 6: Drop all tables from the Minions database
DROP TABLE Minions, Towns;