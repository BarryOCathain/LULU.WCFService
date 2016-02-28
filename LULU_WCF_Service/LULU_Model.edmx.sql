
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/28/2016 00:06:36
-- Generated from EDMX file: C:\Users\DynamicDuo\Source\Repos\LULU_WCF_Service\LULU_WCF_Service\LULU_Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LULU_DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StudentCourse_Student]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentCourse] DROP CONSTRAINT [FK_StudentCourse_Student];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentCourse_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentCourse] DROP CONSTRAINT [FK_StudentCourse_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Classes] DROP CONSTRAINT [FK_CourseClass];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassAtttendedClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AtttendedClasses] DROP CONSTRAINT [FK_ClassAtttendedClass];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentAtttendedClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AtttendedClasses] DROP CONSTRAINT [FK_StudentAtttendedClass];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassRoomClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Classes] DROP CONSTRAINT [FK_ClassRoomClass];
GO
IF OBJECT_ID(N'[dbo].[FK_CampusClassRoom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClassRooms1] DROP CONSTRAINT [FK_CampusClassRoom];
GO
IF OBJECT_ID(N'[dbo].[FK_AtttendedClassGPS_Login]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Logins_GPS_Login] DROP CONSTRAINT [FK_AtttendedClassGPS_Login];
GO
IF OBJECT_ID(N'[dbo].[FK_AtttendedClassStaff_Login]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Logins_Staff_Login] DROP CONSTRAINT [FK_AtttendedClassStaff_Login];
GO
IF OBJECT_ID(N'[dbo].[FK_Staff_LoginStaff_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Staff_User] DROP CONSTRAINT [FK_Staff_LoginStaff_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Student_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Student] DROP CONSTRAINT [FK_Student_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_GPS_Login_inherits_Login]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Logins_GPS_Login] DROP CONSTRAINT [FK_GPS_Login_inherits_Login];
GO
IF OBJECT_ID(N'[dbo].[FK_Staff_Login_inherits_Login]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Logins_Staff_Login] DROP CONSTRAINT [FK_Staff_Login_inherits_Login];
GO
IF OBJECT_ID(N'[dbo].[FK_Staff_User_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Staff_User] DROP CONSTRAINT [FK_Staff_User_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Lecturer_inherits_Staff_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Lecturer] DROP CONSTRAINT [FK_Lecturer_inherits_Staff_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Classes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Classes];
GO
IF OBJECT_ID(N'[dbo].[AtttendedClasses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AtttendedClasses];
GO
IF OBJECT_ID(N'[dbo].[Logins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Logins];
GO
IF OBJECT_ID(N'[dbo].[Courses1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courses1];
GO
IF OBJECT_ID(N'[dbo].[ClassRooms1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClassRooms1];
GO
IF OBJECT_ID(N'[dbo].[Campus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Campus];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Users_Student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Student];
GO
IF OBJECT_ID(N'[dbo].[Logins_GPS_Login]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Logins_GPS_Login];
GO
IF OBJECT_ID(N'[dbo].[Logins_Staff_Login]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Logins_Staff_Login];
GO
IF OBJECT_ID(N'[dbo].[Users_Staff_User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Staff_User];
GO
IF OBJECT_ID(N'[dbo].[Users_Lecturer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Lecturer];
GO
IF OBJECT_ID(N'[dbo].[StudentCourse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentCourse];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Classes'
CREATE TABLE [dbo].[Classes] (
    [ClassID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ClassDate] datetime  NOT NULL,
    [Compulsory] bit  NOT NULL,
    [StartTime] time  NOT NULL,
    [EndTime] time  NOT NULL,
    [Course_CourseID] int  NOT NULL,
    [ClassRoom_ClassRoomID] int  NOT NULL
);
GO

-- Creating table 'AtttendedClasses'
CREATE TABLE [dbo].[AtttendedClasses] (
    [AttendedClassID] int IDENTITY(1,1) NOT NULL,
    [Class_ClassID] int  NOT NULL,
    [Student_UserID] int  NOT NULL
);
GO

-- Creating table 'Logins'
CREATE TABLE [dbo].[Logins] (
    [LoginID] int IDENTITY(1,1) NOT NULL,
    [LoginDate] datetime  NOT NULL,
    [LoginTime] time  NOT NULL
);
GO

-- Creating table 'Courses1'
CREATE TABLE [dbo].[Courses1] (
    [CourseID] int IDENTITY(1,1) NOT NULL,
    [CourseCode] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ClassRooms1'
CREATE TABLE [dbo].[ClassRooms1] (
    [ClassRoomID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Longitude] decimal(18,0)  NOT NULL,
    [Latitude] decimal(18,0)  NOT NULL,
    [Campu_CampusID] int  NOT NULL
);
GO

-- Creating table 'Campus'
CREATE TABLE [dbo].[Campus] (
    [CampusID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users_Student'
CREATE TABLE [dbo].[Users_Student] (
    [StudentNumber] nvarchar(max)  NOT NULL,
    [UserID] int  NOT NULL
);
GO

-- Creating table 'Logins_GPS_Login'
CREATE TABLE [dbo].[Logins_GPS_Login] (
    [GPS_LoginID] int IDENTITY(1,1) NOT NULL,
    [Longitude] decimal(18,0)  NOT NULL,
    [Latitude] decimal(18,0)  NOT NULL,
    [LoginID] int  NOT NULL,
    [AtttendedClass_AttendedClassID] int  NOT NULL
);
GO

-- Creating table 'Logins_Staff_Login'
CREATE TABLE [dbo].[Logins_Staff_Login] (
    [LoginID] int  NOT NULL,
    [AtttendedClass_AttendedClassID] int  NOT NULL
);
GO

-- Creating table 'Users_Staff_User'
CREATE TABLE [dbo].[Users_Staff_User] (
    [StaffNumber] nvarchar(max)  NOT NULL,
    [IsSysAdmin] bit  NOT NULL,
    [UserID] int  NOT NULL,
    [Staff_Login_LoginID] int  NOT NULL
);
GO

-- Creating table 'Users_Lecturer'
CREATE TABLE [dbo].[Users_Lecturer] (
    [Title] nvarchar(max)  NOT NULL,
    [UserID] int  NOT NULL
);
GO

-- Creating table 'StudentCourse'
CREATE TABLE [dbo].[StudentCourse] (
    [Students_UserID] int  NOT NULL,
    [Courses_CourseID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ClassID] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [PK_Classes]
    PRIMARY KEY CLUSTERED ([ClassID] ASC);
GO

-- Creating primary key on [AttendedClassID] in table 'AtttendedClasses'
ALTER TABLE [dbo].[AtttendedClasses]
ADD CONSTRAINT [PK_AtttendedClasses]
    PRIMARY KEY CLUSTERED ([AttendedClassID] ASC);
GO

-- Creating primary key on [LoginID] in table 'Logins'
ALTER TABLE [dbo].[Logins]
ADD CONSTRAINT [PK_Logins]
    PRIMARY KEY CLUSTERED ([LoginID] ASC);
GO

-- Creating primary key on [CourseID] in table 'Courses1'
ALTER TABLE [dbo].[Courses1]
ADD CONSTRAINT [PK_Courses1]
    PRIMARY KEY CLUSTERED ([CourseID] ASC);
GO

-- Creating primary key on [ClassRoomID] in table 'ClassRooms1'
ALTER TABLE [dbo].[ClassRooms1]
ADD CONSTRAINT [PK_ClassRooms1]
    PRIMARY KEY CLUSTERED ([ClassRoomID] ASC);
GO

-- Creating primary key on [CampusID] in table 'Campus'
ALTER TABLE [dbo].[Campus]
ADD CONSTRAINT [PK_Campus]
    PRIMARY KEY CLUSTERED ([CampusID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users_Student'
ALTER TABLE [dbo].[Users_Student]
ADD CONSTRAINT [PK_Users_Student]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [LoginID] in table 'Logins_GPS_Login'
ALTER TABLE [dbo].[Logins_GPS_Login]
ADD CONSTRAINT [PK_Logins_GPS_Login]
    PRIMARY KEY CLUSTERED ([LoginID] ASC);
GO

-- Creating primary key on [LoginID] in table 'Logins_Staff_Login'
ALTER TABLE [dbo].[Logins_Staff_Login]
ADD CONSTRAINT [PK_Logins_Staff_Login]
    PRIMARY KEY CLUSTERED ([LoginID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users_Staff_User'
ALTER TABLE [dbo].[Users_Staff_User]
ADD CONSTRAINT [PK_Users_Staff_User]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users_Lecturer'
ALTER TABLE [dbo].[Users_Lecturer]
ADD CONSTRAINT [PK_Users_Lecturer]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [Students_UserID], [Courses_CourseID] in table 'StudentCourse'
ALTER TABLE [dbo].[StudentCourse]
ADD CONSTRAINT [PK_StudentCourse]
    PRIMARY KEY CLUSTERED ([Students_UserID], [Courses_CourseID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Students_UserID] in table 'StudentCourse'
ALTER TABLE [dbo].[StudentCourse]
ADD CONSTRAINT [FK_StudentCourse_Student]
    FOREIGN KEY ([Students_UserID])
    REFERENCES [dbo].[Users_Student]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Courses_CourseID] in table 'StudentCourse'
ALTER TABLE [dbo].[StudentCourse]
ADD CONSTRAINT [FK_StudentCourse_Course]
    FOREIGN KEY ([Courses_CourseID])
    REFERENCES [dbo].[Courses1]
        ([CourseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentCourse_Course'
CREATE INDEX [IX_FK_StudentCourse_Course]
ON [dbo].[StudentCourse]
    ([Courses_CourseID]);
GO

-- Creating foreign key on [Course_CourseID] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [FK_CourseClass]
    FOREIGN KEY ([Course_CourseID])
    REFERENCES [dbo].[Courses1]
        ([CourseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseClass'
CREATE INDEX [IX_FK_CourseClass]
ON [dbo].[Classes]
    ([Course_CourseID]);
GO

-- Creating foreign key on [Class_ClassID] in table 'AtttendedClasses'
ALTER TABLE [dbo].[AtttendedClasses]
ADD CONSTRAINT [FK_ClassAtttendedClass]
    FOREIGN KEY ([Class_ClassID])
    REFERENCES [dbo].[Classes]
        ([ClassID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassAtttendedClass'
CREATE INDEX [IX_FK_ClassAtttendedClass]
ON [dbo].[AtttendedClasses]
    ([Class_ClassID]);
GO

-- Creating foreign key on [Student_UserID] in table 'AtttendedClasses'
ALTER TABLE [dbo].[AtttendedClasses]
ADD CONSTRAINT [FK_StudentAtttendedClass]
    FOREIGN KEY ([Student_UserID])
    REFERENCES [dbo].[Users_Student]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentAtttendedClass'
CREATE INDEX [IX_FK_StudentAtttendedClass]
ON [dbo].[AtttendedClasses]
    ([Student_UserID]);
GO

-- Creating foreign key on [ClassRoom_ClassRoomID] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [FK_ClassRoomClass]
    FOREIGN KEY ([ClassRoom_ClassRoomID])
    REFERENCES [dbo].[ClassRooms1]
        ([ClassRoomID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassRoomClass'
CREATE INDEX [IX_FK_ClassRoomClass]
ON [dbo].[Classes]
    ([ClassRoom_ClassRoomID]);
GO

-- Creating foreign key on [Campu_CampusID] in table 'ClassRooms1'
ALTER TABLE [dbo].[ClassRooms1]
ADD CONSTRAINT [FK_CampusClassRoom]
    FOREIGN KEY ([Campu_CampusID])
    REFERENCES [dbo].[Campus]
        ([CampusID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CampusClassRoom'
CREATE INDEX [IX_FK_CampusClassRoom]
ON [dbo].[ClassRooms1]
    ([Campu_CampusID]);
GO

-- Creating foreign key on [AtttendedClass_AttendedClassID] in table 'Logins_GPS_Login'
ALTER TABLE [dbo].[Logins_GPS_Login]
ADD CONSTRAINT [FK_AtttendedClassGPS_Login]
    FOREIGN KEY ([AtttendedClass_AttendedClassID])
    REFERENCES [dbo].[AtttendedClasses]
        ([AttendedClassID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AtttendedClassGPS_Login'
CREATE INDEX [IX_FK_AtttendedClassGPS_Login]
ON [dbo].[Logins_GPS_Login]
    ([AtttendedClass_AttendedClassID]);
GO

-- Creating foreign key on [AtttendedClass_AttendedClassID] in table 'Logins_Staff_Login'
ALTER TABLE [dbo].[Logins_Staff_Login]
ADD CONSTRAINT [FK_AtttendedClassStaff_Login]
    FOREIGN KEY ([AtttendedClass_AttendedClassID])
    REFERENCES [dbo].[AtttendedClasses]
        ([AttendedClassID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AtttendedClassStaff_Login'
CREATE INDEX [IX_FK_AtttendedClassStaff_Login]
ON [dbo].[Logins_Staff_Login]
    ([AtttendedClass_AttendedClassID]);
GO

-- Creating foreign key on [Staff_Login_LoginID] in table 'Users_Staff_User'
ALTER TABLE [dbo].[Users_Staff_User]
ADD CONSTRAINT [FK_Staff_LoginStaff_User]
    FOREIGN KEY ([Staff_Login_LoginID])
    REFERENCES [dbo].[Logins_Staff_Login]
        ([LoginID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Staff_LoginStaff_User'
CREATE INDEX [IX_FK_Staff_LoginStaff_User]
ON [dbo].[Users_Staff_User]
    ([Staff_Login_LoginID]);
GO

-- Creating foreign key on [UserID] in table 'Users_Student'
ALTER TABLE [dbo].[Users_Student]
ADD CONSTRAINT [FK_Student_inherits_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [LoginID] in table 'Logins_GPS_Login'
ALTER TABLE [dbo].[Logins_GPS_Login]
ADD CONSTRAINT [FK_GPS_Login_inherits_Login]
    FOREIGN KEY ([LoginID])
    REFERENCES [dbo].[Logins]
        ([LoginID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [LoginID] in table 'Logins_Staff_Login'
ALTER TABLE [dbo].[Logins_Staff_Login]
ADD CONSTRAINT [FK_Staff_Login_inherits_Login]
    FOREIGN KEY ([LoginID])
    REFERENCES [dbo].[Logins]
        ([LoginID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserID] in table 'Users_Staff_User'
ALTER TABLE [dbo].[Users_Staff_User]
ADD CONSTRAINT [FK_Staff_User_inherits_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserID] in table 'Users_Lecturer'
ALTER TABLE [dbo].[Users_Lecturer]
ADD CONSTRAINT [FK_Lecturer_inherits_Staff_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users_Staff_User]
        ([UserID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------