-- Create Directors table
CREATE TABLE Directors (
    Id INT PRIMARY KEY,
    DirectorName VARCHAR(255) NOT NULL,
    Notes TEXT
);

-- Create Genres table
CREATE TABLE Genres (
    Id INT PRIMARY KEY,
    GenreName VARCHAR(255) NOT NULL,
    Notes TEXT
);

-- Create Categories table
CREATE TABLE Categories (
    Id INT PRIMARY KEY,
    CategoryName VARCHAR(255) NOT NULL,
    Notes TEXT
);

-- Create Movies table
CREATE TABLE Movies (
    Id INT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    DirectorId INT,
    CopyrightYear INT,
    Length INT,
    GenreId INT,
    CategoryId INT,
    Rating DECIMAL(3, 1),
    Notes TEXT,
    FOREIGN KEY (DirectorId) REFERENCES Directors(Id),
    FOREIGN KEY (GenreId) REFERENCES Genres(Id),
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

-- Insert data into Directors table
INSERT INTO Directors (Id, DirectorName, Notes)
VALUES
    (1, 'Director 1', 'Notes for Director 1'),
    (2, 'Director 2', 'Notes for Director 2'),
    (3, 'Director 3', 'Notes for Director 3'),
    (4, 'Director 4', 'Notes for Director 4'),
    (5, 'Director 5', 'Notes for Director 5');

-- Insert data into Genres table
INSERT INTO Genres (Id, GenreName, Notes)
VALUES
    (1, 'Action', 'Notes for Action'),
    (2, 'Drama', 'Notes for Drama'),
    (3, 'Comedy', 'Notes for Comedy'),
    (4, 'Science Fiction', 'Notes for Sci-Fi'),
    (5, 'Adventure', 'Notes for Adventure');

-- Insert data into Categories table
INSERT INTO Categories (Id, CategoryName, Notes)
VALUES
    (1, 'Thriller', 'Notes for Thriller'),
    (2, 'Romance', 'Notes for Romance'),
    (3, 'Horror', 'Notes for Horror'),
    (4, 'Fantasy', 'Notes for Fantasy'),
    (5, 'Mystery', 'Notes for Mystery');

-- Insert data into Movies table
INSERT INTO Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
VALUES
    (1, 'Movie 1', 1, 2020, 120, 1, 1, 8.5, 'Notes for Movie 1'),
    (2, 'Movie 2', 2, 2018, 110, 2, 2, 7.8, 'Notes for Movie 2'),
    (3, 'Movie 3', 3, 2019, 130, 3, 3, 6.9, 'Notes for Movie 3'),
    (4, 'Movie 4', 4, 2021, 115, 4, 4, 9.0, 'Notes for Movie 4'),
    (5, 'Movie 5', 5, 2022, 125, 5, 5, 7.2, 'Notes for Movie 5');