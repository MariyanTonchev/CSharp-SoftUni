-- Create Employees table
CREATE TABLE Employees (
    Id INT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Title VARCHAR(255),
    Notes TEXT
);

-- Create Customers table
CREATE TABLE Customers (
    AccountNumber INT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(15),
    EmergencyName VARCHAR(50),
    EmergencyNumber VARCHAR(15),
    Notes TEXT
);

-- Create RoomStatus table
CREATE TABLE RoomStatus (
    RoomStatus VARCHAR(50) PRIMARY KEY,
    Notes TEXT
);

-- Create RoomTypes table
CREATE TABLE RoomTypes (
    RoomType VARCHAR(50) PRIMARY KEY,
    Notes TEXT
);

-- Create BedTypes table
CREATE TABLE BedTypes (
    BedType VARCHAR(50) PRIMARY KEY,
    Notes TEXT
);

-- Create Rooms table
CREATE TABLE Rooms (
    RoomNumber INT PRIMARY KEY,
    RoomType VARCHAR(50),
    BedType VARCHAR(50),
    Rate DECIMAL(8, 2),
    RoomStatus VARCHAR(50),
    Notes TEXT,
    FOREIGN KEY (RoomType) REFERENCES RoomTypes(RoomType),
    FOREIGN KEY (BedType) REFERENCES BedTypes(BedType),
    FOREIGN KEY (RoomStatus) REFERENCES RoomStatus(RoomStatus)
);

-- Create Payments table
CREATE TABLE Payments (
    Id INT PRIMARY KEY,
    EmployeeId INT,
    PaymentDate DATE,
    AccountNumber INT,
    FirstDateOccupied DATE,
    LastDateOccupied DATE,
    TotalDays INT,
    AmountCharged DECIMAL(8, 2),
    TaxRate DECIMAL(4, 2),
    TaxAmount DECIMAL(8, 2),
    PaymentTotal DECIMAL(8, 2),
    Notes TEXT,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);

-- Create Occupancies table
CREATE TABLE Occupancies (
    Id INT PRIMARY KEY,
    EmployeeId INT,
    DateOccupied DATE,
    AccountNumber INT,
    RoomNumber INT,
    RateApplied DECIMAL(8, 2),
    PhoneCharge DECIMAL(8, 2),
    Notes TEXT,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (RoomNumber) REFERENCES Rooms(RoomNumber)
);

-- Insert data into Employees table
INSERT INTO Employees (Id, FirstName, LastName, Title, Notes)
VALUES
    (1, 'John', 'Doe', 'Manager', 'Manager notes'),
    (2, 'Jane', 'Smith', 'Receptionist', 'Receptionist notes'),
    (3, 'Bob', 'Johnson', 'Clerk', 'Clerk notes');

-- Insert data into Customers table
INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES
    (101, 'Alice', 'Johnson', '123-456-7890', 'Bob Johnson', '987-654-3210', 'Customer notes 1'),
    (102, 'Bob', 'Williams', '555-555-5555', 'Charlie Davis', '111-111-1111', 'Customer notes 2'),
    (103, 'Charlie', 'Davis', '999-999-9999', 'Alice Johnson', '444-444-4444', 'Customer notes 3');

-- Insert data into RoomStatus table
INSERT INTO RoomStatus (RoomStatus, Notes)
VALUES
    ('Occupied', 'Occupied room'),
    ('Available', 'Available room'),
    ('Maintenance', 'Room under maintenance');

-- Insert data into RoomTypes table
INSERT INTO RoomTypes (RoomType, Notes)
VALUES
    ('Single', 'Single bed'),
    ('Double', 'Double bed'),
    ('Suite', 'Suite with amenities');

-- Insert data into BedTypes table
INSERT INTO BedTypes (BedType, Notes)
VALUES
    ('Queen', 'Queen-sized bed'),
    ('King', 'King-sized bed'),
    ('Twin', 'Two twin beds');

-- Insert data into Rooms table
INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
VALUES
    (101, 'Single', 'Queen', 100.00, 'Available', 'Room notes 1'),
    (102, 'Double', 'King', 150.00, 'Available', 'Room notes 2'),
    (103, 'Suite', 'Twin', 200.00, 'Available', 'Room notes 3');

-- Insert data into Payments table
INSERT INTO Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES
    (1, 1, '2023-09-01', 101, '2023-08-15', '2023-08-20', 5, 500.00, 0.08, 40.00, 540.00, 'Payment notes 1'),
    (2, 2, '2023-09-02', 102, '2023-08-16', '2023-08-21', 5, 750.00, 0.08, 60.00, 810.00, 'Payment notes 2'),
    (3, 3, '2023-09-03', 103, '2023-08-17', '2023-08-22', 5, 1000.00, 0.08, 80.00, 1080.00, 'Payment notes 3');

-- Insert data into Occupancies table
INSERT INTO Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES
    (1, 1, '2023-08-15', 101, 101, 100.00, 20.00, 'Occupancy notes 1'),
    (2, 2, '2023-08-16', 102, 102, 150.00, 15.00, 'Occupancy notes 2'),
    (3, 3, '2023-08-17', 103, 103, 200.00, 10.00, 'Occupancy notes 3');
