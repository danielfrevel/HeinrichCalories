CREATE TABLE Heinrich_Session(

    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Guid NVARCHAR(MAX) NOT NULL,
)

CREATE TABLE Meal (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    Calories INT NOT NULL,
    Protein INT,
    Carbs INT,
    Fat INT,
    HWeight INT NOT NULL,
    sessionID int not null,
    FOREIGN KEY (sessionId) REFERENCES Heinrich_Session(Id) 
)