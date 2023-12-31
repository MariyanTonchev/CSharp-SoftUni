-- Create the Persons table
CREATE TABLE Persons (
    PersonID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    Salary DECIMAL(10, 2),
    PassportID INT
);

-- Create the Passports table
CREATE TABLE Passports (
    PassportID INT PRIMARY KEY,
    PassportNumber VARCHAR(20)
);

-- Insert data into Persons and Passports tables
INSERT INTO Persons (PersonID, FirstName, Salary, PassportID)
VALUES
    (1, 'Roberto', 43300.00, 102),
    (2, 'Tom', 56100.00, 103),
    (3, 'Yana', 60200.00, 101);

INSERT INTO Passports (PassportID, PassportNumber)
VALUES
    (101, 'N34FG21B'),
    (102, 'K65LO4R7'),
    (103, 'ZE657QP2');

-- Add a foreign key constraint
ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports FOREIGN KEY (PassportID) REFERENCES Passports(PassportID);