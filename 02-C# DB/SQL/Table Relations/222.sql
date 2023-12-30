-- Create the Manufacturers table
CREATE TABLE Manufacturers (
    ManufacturerID INT PRIMARY KEY,
    Name VARCHAR(50),
    EstablishedOn DATE
);

-- Create the Models table
CREATE TABLE Models (
    ModelID INT PRIMARY KEY,
    Name VARCHAR(50),
    ManufacturerID INT,
    FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
);

-- Insert data into Manufacturers and Models tables
INSERT INTO Manufacturers (ManufacturerID, Name, EstablishedOn)
VALUES
    (1, 'BMW', '1916-07-03'),
    (2, 'Tesla', '2003-01-01'),
    (3, 'Lada', '1966-01-05');

INSERT INTO Models (ModelID, Name, ManufacturerID)
VALUES
    (101, 'X1', 1),
    (102, 'i6', 1),
    (103, 'Model S', 2),
    (104, 'Model X', 2),
    (105, 'Model 3', 2),
    (106, 'Nova', 3);