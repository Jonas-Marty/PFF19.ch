CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `News` (
    `Id` int NOT NULL,
    `Date` datetime(6) NOT NULL,
    `Title` longtext NULL,
    `Content` longtext NULL,
    `Image` longtext NULL,
    CONSTRAINT `PK_News` PRIMARY KEY (`Id`)
);

CREATE TABLE `Sponsors` (
    `Id` int NOT NULL,
    `Name` longtext NULL,
    `Logo` longtext NULL,
    `Link` longtext NULL,
    CONSTRAINT `PK_Sponsors` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180702191438_InitialCreate', '2.1.1-rtm-30846');

ALTER TABLE `Sponsors` ADD `Status` int NOT NULL DEFAULT 0;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180702194855_SponsorStatusEnum', '2.1.1-rtm-30846');

CREATE TABLE `Bands` (
    `Id` int NOT NULL,
    `Mail` longtext NULL,
    `Phone` longtext NULL,
    `Description` longtext NULL,
    `ReferenceToScout` longtext NULL,
    CONSTRAINT `PK_Bands` PRIMARY KEY (`Id`)
);

CREATE TABLE `Users` (
    `Id` int NOT NULL,
    `Name` longtext NULL,
    `FirstName` longtext NULL,
    `ScoutName` longtext NULL,
    `Mail` longtext NULL,
    `Ressort` longtext NULL,
    `PasswordHash` longblob NULL,
    `Salt` longblob NULL,
    `IsAdmin` bit NOT NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180709212713_BandsAndBasicUser', '2.1.1-rtm-30846');

