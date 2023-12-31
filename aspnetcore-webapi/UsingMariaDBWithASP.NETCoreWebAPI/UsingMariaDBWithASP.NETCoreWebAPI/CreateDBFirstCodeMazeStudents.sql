CREATE DATABASE DBFirstCodeMazeStudents;

USE DBFirstCodeMazeStudents;

CREATE TABLE `Courses` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` longtext NOT NULL,
    `CreditUnit` int NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Students` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `FirstName` longtext NOT NULL,
    `SecondName` longtext NOT NULL,
    `Address` longtext NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `StudentCourse` (
    `StudentId` int NOT NULL,
    `CourseId` int NOT NULL,
    PRIMARY KEY (`StudentId`, `CourseId`),
    FOREIGN KEY (`CourseId`) REFERENCES `Courses` (`Id`) ON DELETE CASCADE,
    FOREIGN KEY (`StudentId`) REFERENCES `Students` (`Id`) ON DELETE CASCADE
);

INSERT INTO `Courses` (`Id`, `CreditUnit`, `Title`)
VALUES (1, 4, 'Biology'),
(2, 3, 'Mathematics'),
(3, 3, 'Physics');

INSERT INTO `Students` (`Id`, `Address`, `FirstName`, `SecondName`)
VALUES (1, '123 Main St', 'John', 'Doe'),
(2, '456 Oak St', 'Jane', 'Doe');

INSERT INTO `StudentCourse` (`CourseId`, `StudentId`)
VALUES (1, 1),
(2, 1),
(3, 1),
(1, 2),
(2, 2),
(3, 2);