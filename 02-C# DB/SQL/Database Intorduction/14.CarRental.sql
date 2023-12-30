-- Create Categories table
CREATE TABLE Categories (
    Id INT PRIMARY KEY,
    CategoryName VARCHAR(255) NOT NULL,
    DailyRate DECIMAL(8, 2) NOT NULL,
    WeeklyRate DECIMAL(8, 2) NOT NULL,
    MonthlyRate DECIMAL(8, 2) NOT NULL,
    WeekendRate DECIMAL(8, 2) NOT NULL
);

-- Create Cars table
CREATE TABLE Cars (
    Id INT PRIMARY KEY,
    PlateNumber VARCHAR(20) NOT NULL,
    Manufacturer VARCHAR(255) NOT NULL,
    Model VARCHAR(255) NOT NULL,
    CarYear INT NOT NULL,
    CategoryId INT,
    Doors INT NOT NULL,
    Picture VARCHAR(255),
    Condition VARCHAR(50) NOT NULL,
    Available BIT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

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
    Id INT PRIMARY KEY,
    DriverLicenceNumber VARCHAR(20) NOT NULL,
    FullName VARCHAR(255) NOT NULL,
    Address VARCHAR(255),
    City VARCHAR(50),
    ZIPCode VARCHAR(10),
    Notes TEXT
);

-- Create RentalOrders table
CREATE TABLE RentalOrders (
    Id INT PRIMARY KEY,
    EmployeeId INT,
    CustomerId INT,
    CarId INT,
    TankLevel DECIMAL(4, 2),
    KilometrageStart INT,
    KilometrageEnd INT,
    TotalKilometrage INT,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalDays INT NOT NULL,
    RateApplied DECIMAL(8, 2) NOT NULL,
    TaxRate DECIMAL(4, 2) NOT NULL,
    OrderStatus VARCHAR(20) NOT NULL,
    Notes TEXT,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
    FOREIGN KEY (CarId) REFERENCES Cars(Id)
);

-- Insert data into Categories table
INSERT INTO Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
    (1, 'Economy', 30.00, 175.00, 600.00, 40.00),
    (2, 'Compact', 35.00, 200.00, 700.00, 45.00),
    (3, 'SUV', 50.00, 300.00, 1000.00, 70.00);

-- Insert data into Cars table
INSERT INTO Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES
    (1, 'ABC123', 'Toyota', 'Corolla', 2021, 1, 4, 'corolla.jpg', 'Good', 1),
    (2, 'XYZ789', 'Ford', 'Focus', 2020, 2, 4, 'focus.jpg', 'Excellent', 1),
    (3, 'DEF456', 'Chevrolet', 'Equinox', 2019, 3, 4, 'equinox.jpg', 'Fair', 1);

-- Insert data into Employees table
INSERT INTO Employees (Id, FirstName, LastName, Title, Notes)
VALUES
    (1, 'John', 'Doe', 'Manager', 'Manager notes'),
    (2, 'Jane', 'Smith', 'Clerk', 'Clerk notes'),
    (3, 'Bob', 'Johnson', 'Driver', 'Driver notes');

-- Insert data into Customers table
INSERT INTO Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
VALUES
    (1, 'DL12345', 'Alice Johnson', '123 Main St', 'Cityville', '12345', 'Customer notes 1'),
    (2, 'DL67890', 'Bob Williams', '456 Elm St', 'Towndale', '67890', 'Customer notes 2'),
    (3, 'DL45678', 'Charlie Davis', '789 Oak St', 'Villageton', '45678', 'Customer notes 3');

-- Insert data into RentalOrders table
INSERT INTO RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
    (1, 1, 1, 1, 0.75, 5000, 5200, 200, '2023-09-01', '2023-09-05', 5, 175.00, 0.08, 'Completed', 'Order notes 1'),
    (2, 2, 2, 2, 0.90, 6000, 6200, 200, '2023-09-02', '2023-09-06', 4, 200.00, 0.08, 'Completed', 'Order notes 2'),
    (3, 3, 3, 3, 0.80, 7000, 7200, 200, '2023-09-03', '2023-09-07', 4, 300.00, 0.08, 'Completed', 'Order notes 3');
