-- MySqlBackup.NET 2.3.8.0
-- Dump Time: 2025-01-17 08:42:50
-- --------------------------------------
-- Server version 10.4.28-MariaDB mariadb.org binary distribution


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of augments
-- 

DROP TABLE IF EXISTS `augments`;
CREATE TABLE IF NOT EXISTS `augments` (
  `AugmentID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Effect` text DEFAULT NULL,
  `Rarity` varchar(15) NOT NULL,
  PRIMARY KEY (`AugmentID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- 
-- Dumping data for table augments
-- 

/*!40000 ALTER TABLE `augments` DISABLE KEYS */;
INSERT INTO `augments`(`AugmentID`,`Name`,`Effect`,`Rarity`) VALUES(1,'A Golden Find','Champions evolved by the Anomaly drop 2 gold every 2 kills. Gain 10 free rerolls.','Gold'),(2,'At What Cost','Immediately go to level 6 and gain 8 XP. You don''t get to choose your future augments.','Prismatic'),(3,'Band of Thieves I','Gain 1 Thief''s Gloves.','Silver');
/*!40000 ALTER TABLE `augments` ENABLE KEYS */;

-- 
-- Definition of class
-- 

DROP TABLE IF EXISTS `class`;
CREATE TABLE IF NOT EXISTS `class` (
  `ClassID` int(11) NOT NULL AUTO_INCREMENT,
  `ClassName` varchar(50) NOT NULL,
  PRIMARY KEY (`ClassID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- 
-- Dumping data for table class
-- 

/*!40000 ALTER TABLE `class` DISABLE KEYS */;
INSERT INTO `class`(`ClassID`,`ClassName`) VALUES(1,'Eldritch'),(2,'Arcana'),(3,'Sugarcraft');
/*!40000 ALTER TABLE `class` ENABLE KEYS */;

-- 
-- Definition of character
-- 

DROP TABLE IF EXISTS `character`;
CREATE TABLE IF NOT EXISTS `character` (
  `CharacterID` int(11) NOT NULL AUTO_INCREMENT,
  `CharacterName` varchar(50) NOT NULL,
  `ClassID` int(11) DEFAULT NULL,
  `Ability` text DEFAULT NULL,
  `Cost` int(11) DEFAULT NULL,
  `Health` int(11) DEFAULT NULL,
  `AttackSpeed` double DEFAULT NULL,
  `AttackDamage` int(11) DEFAULT NULL,
  `AbilityPower` int(11) DEFAULT NULL,
  `ManaStart` int(11) DEFAULT NULL,
  `ManaMax` int(11) DEFAULT NULL,
  `Armor` int(11) DEFAULT NULL,
  `MagicResist` int(11) DEFAULT NULL,
  `DamagePerSec` int(11) DEFAULT NULL,
  `Rangee` int(11) DEFAULT NULL,
  PRIMARY KEY (`CharacterID`),
  KEY `ClassID` (`ClassID`),
  CONSTRAINT `character_ibfk_1` FOREIGN KEY (`ClassID`) REFERENCES `class` (`ClassID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- 
-- Dumping data for table character
-- 

/*!40000 ALTER TABLE `character` DISABLE KEYS */;
INSERT INTO `character`(`CharacterID`,`CharacterName`,`ClassID`,`Ability`,`Cost`,`Health`,`AttackSpeed`,`AttackDamage`,`AbilityPower`,`ManaStart`,`ManaMax`,`Armor`,`MagicResist`,`DamagePerSec`,`Rangee`) VALUES(4,'Ashe',1,'For the next 5 seconds, Ashe fires an additional missile dealing physical damage at another target. This effect stacks.',1,450,0.7,50,NULL,30,80,15,15,35,4),(5,'Ahri',2,'Passive: Gain 30% bonus Ability Power from all sources. Active: Fire an orb towards the target dealing magic damage. After hitting an enemy it returns, dealing true damage.',2,550,0.75,40,NULL,0,40,20,20,30,4),(6,'Bard',3,'Launch a magic missile at the target that bounces 4 times between enemies dealing magic damage to enemies hit. They also take 10% more damage for 3 seconds.',3,700,0.75,40,NULL,10,75,25,25,40,4);
/*!40000 ALTER TABLE `character` ENABLE KEYS */;

-- 
-- Definition of characterclass
-- 

DROP TABLE IF EXISTS `characterclass`;
CREATE TABLE IF NOT EXISTS `characterclass` (
  `CharacterID` int(11) NOT NULL,
  `ClassID` int(11) NOT NULL,
  PRIMARY KEY (`CharacterID`,`ClassID`),
  KEY `ClassID` (`ClassID`),
  CONSTRAINT `characterclass_ibfk_1` FOREIGN KEY (`CharacterID`) REFERENCES `character` (`CharacterID`),
  CONSTRAINT `characterclass_ibfk_2` FOREIGN KEY (`ClassID`) REFERENCES `class` (`ClassID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- 
-- Dumping data for table characterclass
-- 

/*!40000 ALTER TABLE `characterclass` DISABLE KEYS */;

/*!40000 ALTER TABLE `characterclass` ENABLE KEYS */;

-- 
-- Definition of fullitems
-- 

DROP TABLE IF EXISTS `fullitems`;
CREATE TABLE IF NOT EXISTS `fullitems` (
  `full_item_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `effect` text DEFAULT NULL,
  PRIMARY KEY (`full_item_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- 
-- Dumping data for table fullitems
-- 

/*!40000 ALTER TABLE `fullitems` DISABLE KEYS */;

/*!40000 ALTER TABLE `fullitems` ENABLE KEYS */;

-- 
-- Definition of partialitems
-- 

DROP TABLE IF EXISTS `partialitems`;
CREATE TABLE IF NOT EXISTS `partialitems` (
  `partial_item_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `effect` text DEFAULT NULL,
  PRIMARY KEY (`partial_item_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- 
-- Dumping data for table partialitems
-- 

/*!40000 ALTER TABLE `partialitems` DISABLE KEYS */;
INSERT INTO `partialitems`(`partial_item_id`,`name`,`effect`) VALUES(1,'B.F. Sword','10 Attack damage.'),(2,'Needlessly Large Rod','10 Ability power.'),(3,'Giant''s Belt','Gain 150 Health.');
/*!40000 ALTER TABLE `partialitems` ENABLE KEYS */;

-- 
-- Definition of fullitemcomponents
-- 

DROP TABLE IF EXISTS `fullitemcomponents`;
CREATE TABLE IF NOT EXISTS `fullitemcomponents` (
  `full_item_id` int(11) NOT NULL,
  `partial_item_id` int(11) NOT NULL,
  PRIMARY KEY (`full_item_id`,`partial_item_id`),
  KEY `partial_item_id` (`partial_item_id`),
  CONSTRAINT `fullitemcomponents_ibfk_1` FOREIGN KEY (`full_item_id`) REFERENCES `fullitems` (`full_item_id`),
  CONSTRAINT `fullitemcomponents_ibfk_2` FOREIGN KEY (`partial_item_id`) REFERENCES `partialitems` (`partial_item_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- 
-- Dumping data for table fullitemcomponents
-- 

/*!40000 ALTER TABLE `fullitemcomponents` DISABLE KEYS */;

/*!40000 ALTER TABLE `fullitemcomponents` ENABLE KEYS */;

-- 
-- Definition of permission
-- 

DROP TABLE IF EXISTS `permission`;
CREATE TABLE IF NOT EXISTS `permission` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Level` int(1) NOT NULL,
  `Name` varchar(32) NOT NULL,
  `Description` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Szint` (`Level`),
  UNIQUE KEY `Nev` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- 
-- Dumping data for table permission
-- 

/*!40000 ALTER TABLE `permission` DISABLE KEYS */;
INSERT INTO `permission`(`Id`,`Level`,`Name`,`Description`) VALUES(1,0,'Luzer','Webes regisztráció felhasználó'),(2,9,'Administrator','Rendszergazda');
/*!40000 ALTER TABLE `permission` ENABLE KEYS */;

-- 
-- Definition of portals
-- 

DROP TABLE IF EXISTS `portals`;
CREATE TABLE IF NOT EXISTS `portals` (
  `portal_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `effect` text DEFAULT NULL,
  PRIMARY KEY (`portal_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- 
-- Dumping data for table portals
-- 

/*!40000 ALTER TABLE `portals` DISABLE KEYS */;
INSERT INTO `portals`(`portal_id`,`name`,`effect`) VALUES(1,'Tactician''s Crown','Start with a Tactician''s Crown (gain +1 team size).'),(2,'Support Anvil','Start with 1 Support item anvil.'),(3,'Champion Delivery','Twice per stage, gain a high cost champion. The cost increases with game time.');
/*!40000 ALTER TABLE `portals` ENABLE KEYS */;

-- 
-- Definition of user
-- 

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `LoginNev` varchar(16) NOT NULL,
  `HASH` varchar(64) NOT NULL,
  `SALT` varchar(64) NOT NULL,
  `Name` varchar(64) NOT NULL,
  `PermissionId` int(11) NOT NULL,
  `Active` tinyint(1) NOT NULL,
  `Email` varchar(64) NOT NULL,
  `ProfilePicturePath` varchar(64) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `LoginNev` (`LoginNev`),
  UNIQUE KEY `Email` (`Email`),
  KEY `Jog` (`PermissionId`),
  CONSTRAINT `user_ibfk_1` FOREIGN KEY (`PermissionId`) REFERENCES `permission` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- 
-- Dumping data for table user
-- 

/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user`(`Id`,`LoginNev`,`HASH`,`SALT`,`Name`,`PermissionId`,`Active`,`Email`,`ProfilePicturePath`) VALUES(1,'kerenyir','d5fe0e517520122f1ab363b6b7ee9ae616e7ad393693ef00d81a7f287a79931a','Gm63C4jiWnYvfZfiKUu2cu8AHPNDj8NoHhtQn88yiJhyOunBNSd7tRoWo5wwqg9X','Kerényi Róbert',2,1,'kerenyir@kkszki.hu','img\\kerenyir.jpg');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2025-01-17 08:42:51
-- Total time: 0:0:0:0:396 (d:h:m:s:ms)
