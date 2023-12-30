-- Create Cities table
CREATE TABLE Cities (
    CityID INT PRIMARY KEY,
    Name VARCHAR(50)
);

-- Create Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(50),
    Birthday DATE,
    CityID INT,
    FOREIGN KEY (CityID) REFERENCES Cities(CityID)
);

-- Create ItemTypes table
CREATE TABLE ItemTypes (
    ItemTypeID INT PRIMARY KEY,
    Name VARCHAR(50)
);

-- Create Items table
CREATE TABLE Items (
    ItemID INT PRIMARY KEY,
    Name VARCHAR(50),
    ItemTypeID INT,
    FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
);

-- Create Orders table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

-- Create OrderItems table
CREATE TABLE OrderItems (
    OrderID INT,
    ItemID INT,
    PRIMARY KEY (OrderID, ItemID),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
);