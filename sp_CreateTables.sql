CREATE PROCEDURE sp_create_all_nedeed_tables
AS

CREATE TABLE Departaments
(
Id INT IDENTITY (1,1)  NOT NULL, CONSTRAINT PK_Departaments PRIMARY KEY CLUSTERED (Id),
NAME NVARCHAR(100) NOT NULL,
)

CREATE TABLE EmployeeTypes
(
Id INT IDENTITY (1,1)  NOT NULL, CONSTRAINT PK_EmployeeTypes PRIMARY KEY CLUSTERED (Id),
Description NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees
   (
      Id INT UNIQUE IDENTITY (100000,1)  NOT NULL, CONSTRAINT PK_Employees PRIMARY KEY CLUSTERED (Id),

	  UserId NVARCHAR(450) NOT NULL UNIQUE,
	  CONSTRAINT FK_Employees_To_AspNetUsers FOREIGN KEY (UserId)
      REFERENCES AspNetUsers (Id)
      ON DELETE CASCADE
      ON UPDATE CASCADE,
	  
	  FirstName NVARCHAR(25) NOT NULL,
	  MiddleName NVARCHAR(25),
	  LastName NVARCHAR(25) NOT NULL,

	  DepartamentId INT NOT NULL,
	  CONSTRAINT FK_Employees_To_Departaments FOREIGN KEY (DepartamentId)
      REFERENCES Departaments (Id)
      ON DELETE CASCADE
      ON UPDATE CASCADE,

	  EmployeeTypesId INT NOT NULL,
	  CONSTRAINT FK_Employees_To_EmployeeTypes FOREIGN KEY (EmployeeTypesId)
      REFERENCES EmployeeTypes (Id)
      ON DELETE CASCADE
      ON UPDATE CASCADE,
   )
;


CREATE TABLE LoggedTime
(
Id INT IDENTITY (1,1)  NOT NULL, CONSTRAINT PK_LoggedTime PRIMARY KEY CLUSTERED (Id),
DateLogged DATETIME NOT NULL,
Hours TIME NOT NULL,
LogType INT NOT NULL,

 EmployeesId INT NOT NULL,
	  CONSTRAINT FK_LoggedTime_To_Employees FOREIGN KEY (EmployeesId)
      REFERENCES Employees (Id)
      ON DELETE CASCADE
      ON UPDATE CASCADE
)

CREATE TABLE LoggedTimeTypes
(
Id INT IDENTITY (1,1)  NOT NULL, CONSTRAINT PK_LoggedTimeTypes PRIMARY KEY CLUSTERED (Id),
Description NVARCHAR(250) NOT NULL
)
CREATE TABLE LoggedTimePivotLoggedTimeTypes
(
Id INT IDENTITY (1,1)  NOT NULL, CONSTRAINT PK_LoggedTimePivotLoggedTimeTypes PRIMARY KEY CLUSTERED (Id),
LoggedTimeId INT NOT NULL,
	  CONSTRAINT FK_LoggedTimePivotLoggedTimeTypes_To_LoggedTime FOREIGN KEY (LoggedTimeId)
      REFERENCES LoggedTime (Id)
      ON DELETE CASCADE
      ON UPDATE CASCADE,
LoggedTimeTypesId INT NOT NULL,
	  CONSTRAINT FK_LoggedTimePivotLoggedTimeTypes_To_LoggedTimeTypes FOREIGN KEY (LoggedTimeTypesId)
      REFERENCES LoggedTimeTypes (Id)
      ON DELETE CASCADE
      ON UPDATE CASCADE
)