-- Exercise 9:
-- Create the Users table
CREATE TABLE Users (
    Id BIGINT IDENTITY(1, 1) PRIMARY KEY,
    Username VARCHAR(30) NOT NULL UNIQUE,
    Password VARCHAR(26) NOT NULL CHECK (LEN(Password) >= 5),
    ProfilePicture VARBINARY(MAX),
    LastLoginTime DATETIME DEFAULT GETDATE(),
    IsDeleted BIT
);

-- Insert data into the Users table
INSERT INTO Users (Username, Password, ProfilePicture, IsDeleted)
VALUES
    ('User1', 'Pwd11', NULL, 0),
    ('User2', 'Pwd22', NULL, 0),
    ('User3', 'Pwd33', NULL, 1),
    ('User4', 'Pwd44', NULL, 0),
    ('User5', 'Pwd55', NULL, 1);

-- Exercise 9:
-- Remove the current primary key
ALTER TABLE Users DROP CONSTRAINT PK_Users;

-- Create a new primary key that combines fields Id and Username
ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username);

-- Exercise 10: Add a check constraint to ensure Password values are at least 5 characters long
ALTER TABLE Users
ADD CONSTRAINT CK_PasswordLength CHECK (LEN(Password) >= 5);

-- Exercise 11: Set the default value of LastLoginTime field to the current time
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime;

-- Exercise 12:
-- Remove Username field from the primary key
ALTER TABLE Users DROP CONSTRAINT PK_Users;

-- Add a unique constraint to ensure Username values are at least 3 characters long
ALTER TABLE Users
ADD CONSTRAINT UQ_Username UNIQUE (Username);

-- Add the Id field as the primary key
ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id);