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

ALTER TABLE `News` CHANGE `Title` `TitleFr` longtext NULL;
ALTER TABLE `News` CHANGE `Content` `TitleDe` longtext NULL;
ALTER TABLE `Bands` CHANGE `Description` `DescriptionFr` longtext NULL;
ALTER TABLE `News` ADD `ContentDe` longtext NULL;

ALTER TABLE `News` ADD `ContentFr` longtext NULL;

ALTER TABLE `Bands` ADD `DescriptionDe` longtext NULL;

CREATE TABLE `Assistants` (
    `Id` int NOT NULL,
    `Name` longtext NULL,
    `Vorname` longtext NULL,
    `Pfadiname` longtext NULL,
    `Wishes` longtext NULL,
    CONSTRAINT `PK_Assistants` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180729124949_FranceAndAddAssistants', '2.1.1-rtm-30846');

INSERT INTO `Users` (`Id`, `FirstName`, `IsAdmin`, `Mail`, `Name`, `PasswordHash`, `Ressort`, `Salt`, `ScoutName`)
VALUES (1, 'Administrator', TRUE, 'info@pff.ch', 'Administrator', 0xFC898EC5842EE001635F890C9DA284E9F47B1988C9DC09578F81BF9C432ADB8259D666D88669AE9577A3613A6AB429AD27D839178A1441A6FCC9656234517654, 'Kommunikation', 0xD055F9DDCD78ABD82BB677E5A1BCD0CA0C72B2BDE6CDBC87537F3D81BF5B1EEB79E30B2437899186321A85EA91F7D8FB5A571572EB77E57A5D4EB6A062D56E8D, 'admin');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180729135517_DefaultData', '2.1.1-rtm-30846');

ALTER TABLE `News` ADD `PreviewDe` longtext NULL;

ALTER TABLE `News` ADD `PreviewFr` longtext NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180729144757_NewsPreview', '2.1.1-rtm-30846');



