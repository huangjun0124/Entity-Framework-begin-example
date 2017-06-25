CREATE TABLE Employee
(
    EmpId        int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    HREmpId        nvarchar(10),
    FirstName    nvarchar(30),
    LastName    nvarchar(30),
    Address        nvarchar(30),
    City        nvarchar(30)
)
