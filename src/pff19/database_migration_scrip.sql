CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `News` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Date` datetime(6) NOT NULL,
    `Title` longtext NULL,
    `Content` longtext NULL,
    `Image` longtext NULL,
    CONSTRAINT `PK_News` PRIMARY KEY (`Id`)
);

CREATE TABLE `Sponsors` (
    `Id` int  NOT NULL AUTO_INCREMENT,
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
    `Id` int NOT NULL AUTO_INCREMENT,
    `Mail` longtext NULL,
    `Phone` longtext NULL,
    `Description` longtext NULL,
    `ReferenceToScout` longtext NULL,
    CONSTRAINT `PK_Bands` PRIMARY KEY (`Id`)
);

CREATE TABLE `Users` (
    `Id` int NOT NULL AUTO_INCREMENT,
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

ALTER TABLE `News` CHANGE `Title` `TitleFr` longtext NULL
ALTER TABLE `News` CHANGE `Content` `TitleDe` longtext NULL
ALTER TABLE `Bands` CHANGE `Description` `DescriptionFr` longtext NULL
ALTER TABLE `News` ADD `ContentDe` longtext NULL;

ALTER TABLE `News` ADD `ContentFr` longtext NULL;

ALTER TABLE `Bands` ADD `DescriptionDe` longtext NULL;

CREATE TABLE `Assistants` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext NULL,
    `Vorname` longtext NULL,
    `Pfadiname` longtext NULL,
    `Wishes` longtext NULL,
    CONSTRAINT `PK_Assistants` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180729124949_FranceAndAddAssistants', '2.1.1-rtm-30846');

INSERT INTO `Users` (`FirstName`, `IsAdmin`, `Mail`, `Name`, `PasswordHash`, `Ressort`, `Salt`, `ScoutName`)
VALUES ('Administrator', TRUE, 'info@pff.ch', 'Administrator', 0xF1D5151A60A0D532EE522EA06C5CCF2651012D7C53786FD0E4B72E856EFC050D6F8EE22CA0CD50A7AD8BBF81551A88350C83E009DB317507CE21FCDC9DE565C5, 'Kommunikation', 0x53C382691E05B1286B06540012CD6222EEAE092B48EBF3852F882891ECC5149BA41B9DD9688DAD76673B37087E2C8C6EDB520FD8E5D3BDC05841F6E832B58FF8, 'admin');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180729135517_DefaultData', '2.1.1-rtm-30846');

ALTER TABLE `News` ADD `PreviewDe` longtext NULL;

ALTER TABLE `News` ADD `PreviewFr` longtext NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180729144757_NewsPreview', '2.1.1-rtm-30846');

CREATE TABLE `Faqs` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `QuestionDe` longtext NULL,
    `QuestionFr` longtext NULL,
    `AnswerDe` longtext NULL,
    `AnswerFr` longtext NULL,
    `Category` int NOT NULL,
    `Order` int NOT NULL,
    CONSTRAINT `PK_Faqs` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180730210224_AddFaqs', '2.1.1-rtm-30846');

ALTER TABLE `Assistants` ADD `Email` longtext NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180809195107_AssitantEmailColumn', '2.1.1-rtm-30846');

ALTER TABLE `Assistants` MODIFY COLUMN `Vorname` longtext NOT NULL;

ALTER TABLE `Assistants` MODIFY COLUMN `Name` longtext NOT NULL;

ALTER TABLE `Assistants` MODIFY COLUMN `Email` longtext NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180809200400_AssistantRequiredFields', '2.1.1-rtm-30846');

ALTER TABLE `Bands` DROP COLUMN `Mail`;

ALTER TABLE `Bands` DROP COLUMN `Phone`;

ALTER TABLE `Bands` DROP COLUMN `ReferenceToScout`;

ALTER TABLE `Bands` MODIFY COLUMN `DescriptionFr` longtext NOT NULL;

ALTER TABLE `Bands` MODIFY COLUMN `DescriptionDe` longtext NOT NULL;

ALTER TABLE `Bands` ADD `Name` longtext NOT NULL DEFAULT '';

CREATE TABLE `BandRequests` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext NOT NULL,
    `Email` longtext NOT NULL,
    `Phone` longtext NOT NULL,
    `ReferenceToScout` longtext NULL,
    CONSTRAINT `PK_BandRequests` PRIMARY KEY (`Id`)
);

CREATE TABLE `ContactRequests` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `FirstName` longtext NOT NULL,
    `LastName` longtext NOT NULL,
    `Text` longtext NOT NULL,
    `Mail` longtext NOT NULL,
    CONSTRAINT `PK_ContactRequests` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180809204833_ContactRequestAndBandRequest', '2.1.1-rtm-30846');


