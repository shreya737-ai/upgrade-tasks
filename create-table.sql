CREATE DATABASE EventDb;
USE EventDb;

CREATE TABLE UserInfo (
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL,
    Password VARCHAR(20) NOT NULL,

    CONSTRAINT CHK_UserName_Length 
        CHECK (LEN(UserName) BETWEEN 1 AND 50),

    CONSTRAINT CHK_Role 
        CHECK (Role IN ('Admin','Participant')),

    CONSTRAINT CHK_Password_Length 
        CHECK (LEN(Password) BETWEEN 6 AND 20)
);


CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY,
    EventName VARCHAR(50) NOT NULL,
    EventCategory VARCHAR(50) NOT NULL,
    EventDate DATETIME NOT NULL,
    Description VARCHAR(255) NULL,
    Status VARCHAR(20) NOT NULL,

    CONSTRAINT CHK_EventName_Length 
        CHECK (LEN(EventName) BETWEEN 1 AND 50),

    CONSTRAINT CHK_EventCategory_Length 
        CHECK (LEN(EventCategory) BETWEEN 1 AND 50),

    CONSTRAINT CHK_Event_Status 
        CHECK (Status IN ('Active','In-Active'))
);

CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY,
    SpeakerName VARCHAR(50) NOT NULL,

    CONSTRAINT CHK_SpeakerName_Length 
        CHECK (LEN(SpeakerName) BETWEEN 1 AND 50)
);

CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL,
    SpeakerId INT NOT NULL,
    Description VARCHAR(255) NULL,
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(255),

    CONSTRAINT FK_Session_Event 
        FOREIGN KEY (EventId) 
        REFERENCES EventDetails(EventId),

    CONSTRAINT FK_Session_Speaker 
        FOREIGN KEY (SpeakerId) 
        REFERENCES SpeakersDetails(SpeakerId),

    CONSTRAINT CHK_SessionTitle_Length 
        CHECK (LEN(SessionTitle) BETWEEN 1 AND 50),

    CONSTRAINT CHK_Session_Time 
        CHECK (SessionEnd > SessionStart)
);

CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,
    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT NOT NULL,

    CONSTRAINT FK_Participant_User 
        FOREIGN KEY (ParticipantEmailId) 
        REFERENCES UserInfo(EmailId),

    CONSTRAINT FK_Participant_Event 
        FOREIGN KEY (EventId) 
        REFERENCES EventDetails(EventId),

    CONSTRAINT FK_Participant_Session 
        FOREIGN KEY (SessionId) 
        REFERENCES SessionInfo(SessionId)
);

INSERT INTO UserInfo VALUES 
('admin1@gmail.com','AdminUser','Admin','admin123'),
('user1@gmail.com','Ravi','Participant','ravi123');

INSERT INTO EventDetails VALUES
(1,'Tech Conference','Technology','2026-04-15','Annual Tech Event','Active');

INSERT INTO SpeakersDetails VALUES
(101,'Shreya Banerjee');

INSERT INTO SessionInfo VALUES
(201,1,'AI and Future',101,'AI Discussion',
 '2026-04-15 10:00:00',
 '2026-04-15 12:00:00',
 'https://meetlink.com/ai');

 INSERT INTO ParticipantEventDetails VALUES
(1,'user1@gmail.com',1,201,1);

SELECT * FROM EventDetails;

