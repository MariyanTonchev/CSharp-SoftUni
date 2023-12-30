-- Create the Students table
CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    Name VARCHAR(50)
);

-- Create the Exams table
CREATE TABLE Exams (
    ExamID INT PRIMARY KEY,
    Name VARCHAR(50)
);

-- Create the StudentsExams table with a composite primary key
CREATE TABLE StudentsExams (
    StudentID INT,
    ExamID INT,
    PRIMARY KEY (StudentID, ExamID),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);

-- Insert data into Students and Exams tables
INSERT INTO Students (StudentID, Name)
VALUES
    (1, 'Mila'),
    (2, 'Toni'),
    (3, 'Ron');

INSERT INTO Exams (ExamID, Name)
VALUES
    (101, 'SpringMVC'),
    (102, 'Neo4j'),
    (103, 'Oracle 11g');

-- Insert data into StudentsExams table (relationship between students and exams)
INSERT INTO StudentsExams (StudentID, ExamID)
VALUES
    (1, 101),  -- Mila took SpringMVC
    (1, 102),  -- Mila took Neo4j
    (2, 101),  -- Toni took SpringMVC
    (2, 102),  -- Toni took Neo4j
    (2, 103),  -- Toni took Oracle 11g
    (3, 103);  -- Ron took Oracle 11g
