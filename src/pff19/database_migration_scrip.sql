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
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext NULL,
    `Logo` longtext NULL,
    `Link` longtext NULL,
    CONSTRAINT `PK_Sponsors` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180702191438_InitialCreate', '2.2.3-servicing-35854');

ALTER TABLE `Sponsors` ADD `Status` int NOT NULL DEFAULT 0;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180702194855_SponsorStatusEnum', '2.2.3-servicing-35854');

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
VALUES ('20180709212713_BandsAndBasicUser', '2.2.3-servicing-35854');

ALTER TABLE `News` CHANGE `Title` `TitleFr` longtext NULL;
ALTER TABLE `News` CHANGE `Content` `TitleDe` longtext NULL;
ALTER TABLE `Bands` CHANGE `Description` `DescriptionFr` longtext NULL;
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
VALUES ('20180729124949_FranceAndAddAssistants', '2.2.3-servicing-35854');

INSERT INTO `Users` (`FirstName`, `IsAdmin`, `Mail`, `Name`, `PasswordHash`, `Ressort`, `Salt`, `ScoutName`)
VALUES ('Administrator', TRUE, 'info@pff.ch', 'Administrator', 0x77F3E1C030BAC182DFC9579C879358BCBF6822C2CE8B0A4E41151718F9CD09B6EC3E54166E3812F1C27550069F7A46E5737FDA65121244AFA2D60FE65331CDBC, 'Kommunikation', 0x5CEDD2E9D2C1F19C661B70EB1AF6C9E4C9AFE0EDF8DD595E4F6E436822147E6A9C432F617E5C7C4A98B01FB5AA28409FF2713625E9707D87EFBB8C881765F6AE, 'admin');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180729135517_DefaultData', '2.2.3-servicing-35854');

ALTER TABLE `News` ADD `PreviewDe` longtext NULL;

ALTER TABLE `News` ADD `PreviewFr` longtext NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180729144757_NewsPreview', '2.2.3-servicing-35854');

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
VALUES ('20180730210224_AddFaqs', '2.2.3-servicing-35854');

ALTER TABLE `Assistants` ADD `Email` longtext NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180809195107_AssitantEmailColumn', '2.2.3-servicing-35854');

ALTER TABLE `Assistants` MODIFY COLUMN `Vorname` longtext NOT NULL;

ALTER TABLE `Assistants` MODIFY COLUMN `Name` longtext NOT NULL;

ALTER TABLE `Assistants` MODIFY COLUMN `Email` longtext NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180809200400_AssistantRequiredFields', '2.2.3-servicing-35854');

ALTER TABLE `Bands` DROP COLUMN `Mail`;

ALTER TABLE `Bands` DROP COLUMN `Phone`;

ALTER TABLE `Bands` DROP COLUMN `ReferenceToScout`;

ALTER TABLE `Bands` MODIFY COLUMN `DescriptionFr` longtext NOT NULL;

ALTER TABLE `Bands` MODIFY COLUMN `DescriptionDe` longtext NOT NULL;

ALTER TABLE `Bands` ADD `Name` longtext NOT NULL;

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
VALUES ('20180809204833_ContactRequestAndBandRequest', '2.2.3-servicing-35854');

ALTER TABLE `News` CHANGE `Image` `Images` longtext NULL;
ALTER TABLE `News` ADD `LinkInstagram` longtext NULL;

ALTER TABLE `News` ADD `LinkFacebook` longtext NULL;

ALTER TABLE `Sponsors` ADD `CreatedAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000';

ALTER TABLE `News` ADD `DateCreated` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000';

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20181117164351_NewFields', '2.2.3-servicing-35854');

ALTER TABLE `ContactRequests` ADD `SubmitedAt` datetime(6) NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20181206214136_ContactRequest_SubmitedAt', '2.2.3-servicing-35854');

ALTER TABLE `Faqs` MODIFY COLUMN `Category` longtext NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20190105122738_FaqCategoryAsString', '2.2.3-servicing-35854');

ALTER TABLE `Bands` MODIFY COLUMN `Name` longtext NULL;

ALTER TABLE `Bands` MODIFY COLUMN `DescriptionFr` longtext NULL;

ALTER TABLE `Bands` MODIFY COLUMN `DescriptionDe` longtext NULL;

ALTER TABLE `Bands` ADD `Facebook` longtext NULL;

ALTER TABLE `Bands` ADD `ImageLarge` longtext NULL;

ALTER TABLE `Bands` ADD `ImageThumbnail` longtext NULL;

ALTER TABLE `Bands` ADD `Instagram` longtext NULL;

ALTER TABLE `Bands` ADD `Order` int NOT NULL DEFAULT 0;

ALTER TABLE `Bands` ADD `PlayTime` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000';

ALTER TABLE `Bands` ADD `SpotifyPlaylist` longtext NULL;

ALTER TABLE `Bands` ADD `WebSiteUrl` longtext NULL;

ALTER TABLE `Bands` ADD `YoutubeUrls` longtext NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20190105162610_NewFieldsForBands', '2.2.3-servicing-35854');

ALTER TABLE `Bands` MODIFY COLUMN `PlayTime` datetime(6) NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20190105165319_BandPlayTimeNotNull', '2.2.3-servicing-35854');

ALTER TABLE `Faqs` MODIFY COLUMN `QuestionFr` longtext NOT NULL;

ALTER TABLE `Faqs` MODIFY COLUMN `QuestionDe` longtext NOT NULL;

ALTER TABLE `Faqs` MODIFY COLUMN `Category` longtext NOT NULL;

ALTER TABLE `Faqs` MODIFY COLUMN `AnswerFr` longtext NOT NULL;

ALTER TABLE `Faqs` MODIFY COLUMN `AnswerDe` longtext NOT NULL;

ALTER TABLE `Bands` MODIFY COLUMN `PlayTime` longtext NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20190119124702_ChangeBandPlayTimeToStringColumn', '2.2.3-servicing-35854');

ALTER TABLE `Bands` ADD `ImageMobile` longtext NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20190321195706_AddBandMobileImage', '2.2.3-servicing-35854');
 

