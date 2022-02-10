CREATE TABLE ConTable 
(
ConID int IDENTITY PRIMARY KEY,
ConName varchar(30)
);

CREATE TABLE ItemTable
(
ItemID int IDENTITY PRIMARY KEY,
ItemName varchar(50),
ConID int FOREIGN KEY REFERENCES ConTable (ConID)
);