-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 17, 2024 at 06:03 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tftdatabase`
--

-- --------------------------------------------------------

--
-- Table structure for table `augments`
--

CREATE TABLE `augments` (
  `AugmentID` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Effect` text DEFAULT NULL,
  `Rarity` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `augments`
--

INSERT INTO `augments` (`AugmentID`, `Name`, `Effect`, `Rarity`) VALUES
(1, 'A Golden Find', 'Champions evolved by the Anomaly drop 2 gold every 2 kills. Gain 10 free rerolls.', 'Gold'),
(2, 'At What Cost', 'Immediately go to level 6 and gain 8 XP. You don\'t get to choose your future augments.', 'Prismatic'),
(3, 'Band of Thieves I', 'Gain 1 Thief\'s Gloves.', 'Silver');

-- --------------------------------------------------------

--
-- Table structure for table `character`
--

CREATE TABLE `character` (
  `CharacterID` int(11) NOT NULL,
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
  `Rangee` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `character`
--

INSERT INTO `character` (`CharacterID`, `CharacterName`, `ClassID`, `Ability`, `Cost`, `Health`, `AttackSpeed`, `AttackDamage`, `AbilityPower`, `ManaStart`, `ManaMax`, `Armor`, `MagicResist`, `DamagePerSec`, `Rangee`) VALUES
(4, 'Ashe', 1, 'For the next 5 seconds, Ashe fires an additional missile dealing physical damage at another target. This effect stacks.', 1, 450, 0.7, 50, NULL, 30, 80, 15, 15, 35, 4),
(5, 'Ahri', 2, 'Passive: Gain 30% bonus Ability Power from all sources. Active: Fire an orb towards the target dealing magic damage. After hitting an enemy it returns, dealing true damage.', 2, 550, 0.75, 40, NULL, 0, 40, 20, 20, 30, 4),
(6, 'Bard', 3, 'Launch a magic missile at the target that bounces 4 times between enemies dealing magic damage to enemies hit. They also take 10% more damage for 3 seconds.', 3, 700, 0.75, 40, NULL, 10, 75, 25, 25, 40, 4);

-- --------------------------------------------------------

--
-- Table structure for table `characterclass`
--

CREATE TABLE `characterclass` (
  `CharacterID` int(11) NOT NULL,
  `ClassID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `class`
--

CREATE TABLE `class` (
  `ClassID` int(11) NOT NULL,
  `ClassName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `class`
--

INSERT INTO `class` (`ClassID`, `ClassName`) VALUES
(1, 'Eldritch'),
(2, 'Arcana'),
(3, 'Sugarcraft');

-- --------------------------------------------------------

--
-- Table structure for table `fullitemcomponents`
--

CREATE TABLE `fullitemcomponents` (
  `full_item_id` int(11) NOT NULL,
  `partial_item_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `fullitems`
--

CREATE TABLE `fullitems` (
  `full_item_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `effect` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `partialitems`
--

CREATE TABLE `partialitems` (
  `partial_item_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `effect` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `partialitems`
--

INSERT INTO `partialitems` (`partial_item_id`, `name`, `effect`) VALUES
(1, 'B.F. Sword', '10 Attack damage.'),
(2, 'Needlessly Large Rod', '10 Ability power.'),
(3, 'Giant\'s Belt', 'Gain 150 Health.');

-- --------------------------------------------------------

--
-- Table structure for table `portals`
--

CREATE TABLE `portals` (
  `portal_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `effect` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `portals`
--

INSERT INTO `portals` (`portal_id`, `name`, `effect`) VALUES
(1, 'Tactician\'s Crown', 'Start with a Tactician\'s Crown (gain +1 team size).'),
(2, 'Support Anvil', 'Start with 1 Support item anvil.'),
(3, 'Champion Delivery', 'Twice per stage, gain a high cost champion. The cost increases with game time.');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `augments`
--
ALTER TABLE `augments`
  ADD PRIMARY KEY (`AugmentID`);

--
-- Indexes for table `character`
--
ALTER TABLE `character`
  ADD PRIMARY KEY (`CharacterID`),
  ADD KEY `ClassID` (`ClassID`);

--
-- Indexes for table `characterclass`
--
ALTER TABLE `characterclass`
  ADD PRIMARY KEY (`CharacterID`,`ClassID`),
  ADD KEY `ClassID` (`ClassID`);

--
-- Indexes for table `class`
--
ALTER TABLE `class`
  ADD PRIMARY KEY (`ClassID`);

--
-- Indexes for table `fullitemcomponents`
--
ALTER TABLE `fullitemcomponents`
  ADD PRIMARY KEY (`full_item_id`,`partial_item_id`),
  ADD KEY `partial_item_id` (`partial_item_id`);

--
-- Indexes for table `fullitems`
--
ALTER TABLE `fullitems`
  ADD PRIMARY KEY (`full_item_id`);

--
-- Indexes for table `partialitems`
--
ALTER TABLE `partialitems`
  ADD PRIMARY KEY (`partial_item_id`);

--
-- Indexes for table `portals`
--
ALTER TABLE `portals`
  ADD PRIMARY KEY (`portal_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `augments`
--
ALTER TABLE `augments`
  MODIFY `AugmentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `character`
--
ALTER TABLE `character`
  MODIFY `CharacterID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `class`
--
ALTER TABLE `class`
  MODIFY `ClassID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `fullitems`
--
ALTER TABLE `fullitems`
  MODIFY `full_item_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `partialitems`
--
ALTER TABLE `partialitems`
  MODIFY `partial_item_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `portals`
--
ALTER TABLE `portals`
  MODIFY `portal_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `character`
--
ALTER TABLE `character`
  ADD CONSTRAINT `character_ibfk_1` FOREIGN KEY (`ClassID`) REFERENCES `class` (`ClassID`);

--
-- Constraints for table `characterclass`
--
ALTER TABLE `characterclass`
  ADD CONSTRAINT `characterclass_ibfk_1` FOREIGN KEY (`CharacterID`) REFERENCES `character` (`CharacterID`),
  ADD CONSTRAINT `characterclass_ibfk_2` FOREIGN KEY (`ClassID`) REFERENCES `class` (`ClassID`);

--
-- Constraints for table `fullitemcomponents`
--
ALTER TABLE `fullitemcomponents`
  ADD CONSTRAINT `fullitemcomponents_ibfk_1` FOREIGN KEY (`full_item_id`) REFERENCES `fullitems` (`full_item_id`),
  ADD CONSTRAINT `fullitemcomponents_ibfk_2` FOREIGN KEY (`partial_item_id`) REFERENCES `partialitems` (`partial_item_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
