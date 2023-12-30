-- Create the People table
CREATE TABLE People (
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Picture VARBINARY(MAX),
    Height DECIMAL(5, 2),
    Weight DECIMAL(5, 2),
    Gender CHAR(1) NOT NULL,
    Birthdate DATE NOT NULL,
    Biography NVARCHAR(MAX)
);

-- Insert data into the People table
INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES
    ('John Doe', NULL, 1.80, 75.50, 'm', '1985-05-15', 'John Doe is a fictional character...'),
    ('Jane Smith', NULL, 1.65, 58.20, 'f', '1990-08-22', 'Jane Smith is an artist and writer...'),
    ('Bob Johnson', NULL, 1.75, 80.00, 'm', '1980-03-10', 'Bob Johnson works as a software engineer...'),
    ('Alice Williams', NULL, 1.70, 65.75, 'f', '1988-11-30', 'Alice Williams is a biologist and researcher...'),
    ('Charlie Davis', NULL, NULL, NULL, 'm', '1995-02-05', NULL);