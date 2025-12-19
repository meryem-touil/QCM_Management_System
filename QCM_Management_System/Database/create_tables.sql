USE QCM_DB;
GO

-- ==============================
-- TABLE 1: Users
-- ==============================
CREATE TABLE Users (
    IdUser INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Role NVARCHAR(10) NOT NULL CHECK (Role IN ('Admin', 'User')),
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- ==============================
-- TABLE 2: QCM
-- ==============================
CREATE TABLE QCM (
    IdQCM INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NULL,
    Duration INT NOT NULL, -- minutes
    CreatedBy INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1,
    CONSTRAINT FK_QCM_Users FOREIGN KEY (CreatedBy) REFERENCES Users(IdUser)
);
GO

-- ==============================
-- TABLE 3: Questions
-- ==============================
CREATE TABLE Questions (
    IdQuestion INT IDENTITY(1,1) PRIMARY KEY,
    QuestionText NVARCHAR(500) NOT NULL,
    IdQCM INT NOT NULL,
    OrderNumber INT NULL,
    CONSTRAINT FK_Questions_QCM FOREIGN KEY (IdQCM) 
        REFERENCES QCM(IdQCM) ON DELETE CASCADE
);
GO

-- ==============================
-- TABLE 4: Answers
-- ==============================
CREATE TABLE Answers (
    IdAnswer INT IDENTITY(1,1) PRIMARY KEY,
    AnswerText NVARCHAR(300) NOT NULL,
    IsCorrect BIT NOT NULL DEFAULT 0,
    IdQuestion INT NOT NULL,
    CONSTRAINT FK_Answers_Questions FOREIGN KEY (IdQuestion) 
        REFERENCES Questions(IdQuestion) ON DELETE CASCADE
);
GO

-- ==============================
-- TABLE 5: Results (improved)
-- This table stores EACH attempt
-- ==============================
CREATE TABLE Results (
    IdResult INT IDENTITY(1,1) PRIMARY KEY,
    IdUser INT NOT NULL,
    IdQCM INT NOT NULL,
    Score DECIMAL(5,2) NOT NULL, -- percentage (0-100)
    TotalQuestions INT NOT NULL,
    CorrectAnswers INT NOT NULL,
    StartTime DATETIME DEFAULT GETDATE(),
    EndTime DATETIME NULL,
    CONSTRAINT FK_Results_Users FOREIGN KEY (IdUser) REFERENCES Users(IdUser),
    CONSTRAINT FK_Results_QCM FOREIGN KEY (IdQCM) REFERENCES QCM(IdQCM)
);
GO

-- ==============================
-- TABLE 6: UserResponses
-- Store each answer for detailed review
-- ==============================
CREATE TABLE UserResponses (
    IdResponse INT IDENTITY(1,1) PRIMARY KEY,
    IdResult INT NOT NULL, -- which attempt
    IdQuestion INT NOT NULL,
    IdAnswer INT NULL, -- NULL if skipped
    IsCorrect BIT NOT NULL,
    CONSTRAINT FK_Responses_Results FOREIGN KEY (IdResult) 
        REFERENCES Results(IdResult) ON DELETE CASCADE,
    CONSTRAINT FK_Responses_Questions FOREIGN KEY (IdQuestion) 
        REFERENCES Questions(IdQuestion),
    CONSTRAINT FK_Responses_Answers FOREIGN KEY (IdAnswer) 
        REFERENCES Answers(IdAnswer)
);
GO

-- Default admin
INSERT INTO Users (Username, PasswordHash, FullName, Role)
VALUES ('admin', 'admin123', 'Administrator', 'Admin');
GO