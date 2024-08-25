CREATE TABLE Users (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Role ENUM('Admin', 'Support' ,'User') NOT NULL
);

CREATE TABLE Tickets (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Title VARCHAR(150) NOT NULL,
    Description VARCHAR(255) NOT NULL,
    AssigneeId INT,
    ReporterId INT NOT NULL,
    FOREIGN KEY (AssigneeId) REFERENCES Users(Id),
    FOREIGN KEY (ReporterId) REFERENCES Users(Id)
);