CREATE VIEW V_EmployeeNameJobTitle AS
SELECT 
    CONCAT_WS(' ', FirstName, COALESCE(NULLIF(MiddleName, ''), ''), LastName) AS "Full Name",
    JobTitle
FROM 
    Employees;