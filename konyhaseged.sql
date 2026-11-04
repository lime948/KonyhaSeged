-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Okt 15. 14:33
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `konyhaseged`
--
CREATE DATABASE IF NOT EXISTS `konyhaseged` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `konyhaseged`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `alapanyagok`
--

CREATE TABLE IF NOT EXISTS `alapanyagok` (
  `alapanyag_id` int(11) NOT NULL AUTO_INCREMENT,
  `nev` varchar(20) NOT NULL,
  PRIMARY KEY (`alapanyag_id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `alapanyagok`
--

INSERT INTO `alapanyagok` (`alapanyag_id`, `nev`) VALUES
(1, 'Liszt'),
(2, 'Tojás'),
(3, 'Tej'),
(4, 'Só'),
(5, 'Cukor'),
(6, 'Étolaj'),
(7, 'Marhahús'),
(8, 'Sertészsír'),
(9, 'Vöröshagyma'),
(10, 'Fokhagyma'),
(11, 'Őrölt Paprika'),
(12, 'Paprika'),
(13, 'Paradicsom'),
(14, 'Sárgarépa'),
(15, 'Petrezselyemgyökér'),
(16, 'Krumpli'),
(17, 'Bors'),
(18, 'Víz');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `hozzavalok`
--

CREATE TABLE IF NOT EXISTS `hozzavalok` (
  `recept_id` int(11) NOT NULL,
  `alapanyag_id` int(11) NOT NULL,
  `mennyiseg` varchar(11) NOT NULL,
  KEY `recept_id` (`recept_id`,`alapanyag_id`),
  KEY `alapanyag_id` (`alapanyag_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `hozzavalok`
--

INSERT INTO `hozzavalok` (`recept_id`, `alapanyag_id`, `mennyiseg`) VALUES
-- 1. Palacsinta
(1, 1, '20 dkg'),
(1, 2, '2 db'),
(1, 3, '3 dl'),
(1, 4, '1 csipet'),
(1, 5, '1 csipet'),
(1, 6, '2 ek'),
(1, 18, '2 dl'),

-- 2. Gulyásleves
(2, 7, '55 dkg'),
(2, 8, '3 ek'),
(2, 9, '2 fej'),
(2, 10, '2 gerezd'),
(2, 11, '1 ek'),
(2, 12, '1 db'),
(2, 13, '1 db'),
(2, 14, '4 db'),
(2, 15, '1 db'),
(2, 16, '4 db'),
(2, 4, '1 tk'),
(2, 17, '1 tk'),
(2, 18, '2 l'),

-- 3. Rántotta
(3, 2, '3 db'),
(3, 4, '1 csipet'),
(3, 6, '1 ek'),
(3, 17, '1 csipet'),

-- 4. Lángos
(4, 1, '50 dkg'),
(4, 3, '2 dl'),
(4, 5, '1 tk'),
(4, 4, '1 tk'),
(4, 6, '5 dl'),
(4, 10, '3 gerezd'),
(4, 18, '1 dl'),

-- 5. Krumplileves
(5, 16, '60 dkg'),
(5, 9, '1 fej'),
(5, 8, '2 ek'),
(5, 1, '2 ek'),
(5, 11, '1 ek'),
(5, 4, '1 tk'),
(5, 17, '1 csipet'),
(5, 18, '1.5 l'),

-- 6. Paprikás krumpli
(6, 16, '1 kg'),
(6, 9, '2 fej'),
(6, 8, '3 ek'),
(6, 11, '1.5 ek'),
(6, 12, '1 db'),
(6, 13, '1 db'),
(6, 4, '1.5 tk'),
(6, 17, '1 csipet'),
(6, 18, '8 dl'),

-- 7. Marhapörkölt
(7, 7, '80 dkg'),
(7, 9, '3 fej'),
(7, 8, '4 ek'),
(7, 10, '3 gerezd'),
(7, 11, '2 ek'),
(7, 12, '1 db'),
(7, 13, '1 db'),
(7, 4, '1.5 tk'),
(7, 17, '1 tk'),
(7, 18, '5 dl'),

-- 8. Főtt tojás
(8, 2, '2 db'),
(8, 4, '1 csipet'),
(8, 18, '5 dl'),

-- 9. Hagymás rántotta
(9, 2, '3 db'),
(9, 9, '1 fej'),
(9, 8, '1 ek'),
(9, 4, '1 csipet'),
(9, 17, '1 csipet'),

-- 10. Sült krumpli
(10, 16, '80 dkg'),
(10, 6, '5 dl'),
(10, 4, '1 tk'),

-- 11. Fokhagymakrémleves
(11, 10, '8 gerezd'),
(11, 8, '2 ek'),
(11, 1, '2 ek'),
(11, 3, '2 dl'),
(11, 4, '1 tk'),
(11, 17, '1 csipet'),
(11, 18, '1 l'),

-- 12. Zöldségleves
(12, 14, '3 db'),
(12, 15, '2 db'),
(12, 9, '1 fej'),
(12, 6, '2 ek'),
(12, 4, '1 tk'),
(12, 17, '1 csipet'),
(12, 18, '1.5 l'),

-- 13. Császármorzsa
(13, 1, '25 dkg'),
(13, 3, '3 dl'),
(13, 2, '3 db'),
(13, 5, '3 ek'),
(13, 4, '1 csipet'),
(13, 8, '2 ek'),

-- 14. Galuska
(14, 1, '40 dkg'),
(14, 2, '2 db'),
(14, 4, '1 tk'),
(14, 18, '2.5 dl'),

-- 15. Hagymaleves
(15, 9, '4 fej'),
(15, 8, '3 ek'),
(15, 1, '1 ek'),
(15, 4, '1 tk'),
(15, 17, '1 csipet'),
(15, 18, '1 l'),

-- 16. Dödölle
(16, 16, '1 kg'),
(16, 1, '30 dkg'),
(16, 9, '2 fej'),
(16, 8, '4 ek'),
(16, 4, '1.5 tk'),
(16, 18, '5 dl'),

-- 17. Tejbegíz
(17, 3, '5 dl'),
(17, 1, '4 ek'),
(17, 5, '2 ek'),
(17, 4, '1 csipet'),

-- 18. Pörkölt szaft alap
(18, 9, '2 fej'),
(18, 8, '2 ek'),
(18, 11, '1 ek'),
(18, 12, '1 db'),
(18, 13, '1 db'),
(18, 4, '0.5 tk'),
(18, 18, '2 dl'),

-- 19. Tükörtojás
(19, 2, '2 db'),
(19, 6, '1 ek'),
(19, 4, '1 csipet'),
(19, 17, '1 csipet'),

-- 20. Pirított hagymás krumpli
(20, 16, '60 dkg'),
(20, 9, '2 fej'),
(20, 8, '2 ek'),
(20, 4, '1 tk'),
(20, 17, '1 csipet');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `receptek`
--

CREATE TABLE IF NOT EXISTS `receptek` (
  `recept_id` int(11) NOT NULL AUTO_INCREMENT,
  `nev` varchar(30) NOT NULL,
  `leiras` varchar(255) NOT NULL,
  `elkeszitesi_ido` int(10) NOT NULL,
  `kategoria` varchar(20) NOT NULL,
  `allergenek` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`recept_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `receptek`
--

USE `konyhaseged`;

-- A meglévő receptek törlése (a FOREIGN KEY CASCADE miatt a hozzávalók is törlődnek)
DELETE FROM `receptek`;
ALTER TABLE `receptek` AUTO_INCREMENT = 1;

-- --------------------------------------------------------
-- RECEPTEK BESZÚRÁSA 
-- --------------------------------------------------------

INSERT INTO `receptek` (`recept_id`, `nev`, `leiras`, `elkeszitesi_ido`, `kategoria`, `allergenek`) VALUES
(1, 'Palacsinta', 'Klasszikus édes palacsinta tészta', 30, 'Desszert', 'Glutén, Tojás, Tej'),
(2, 'Gulyásleves', 'Hagyományos húsos leves zöldségekkel', 120, 'Leves', NULL),
(3, 'Rántotta', 'Egyszerű sült tojás', 10, 'Reggeli', 'Tojás'),
(4, 'Lángos', 'Fokhagymás kelt tészta olajban sütve', 45, 'Főétel', 'Glutén'),
(5, 'Krumplileves', 'Kiadós krumplileves rántással', 40, 'Leves', 'Glutén'),
(6, 'Paprikás krumpli', 'Hagyományos paprikás krumpli', 45, 'Főétel', NULL),
(7, 'Marhapörkölt', 'Sűrű szaftos marhapörkölt', 150, 'Főétel', NULL),
(8, 'Főtt tojás', 'Egyszerű főtt tojás reggelire', 10, 'Reggeli', 'Tojás'),
(9, 'Hagymás rántotta', 'Vöröshagymával pirított rántotta', 15, 'Reggeli', 'Tojás'),
(10, 'Sült krumpli', 'Ropogós sült krumpli', 30, 'Köret', NULL),
(11, 'Fokhagymakrémleves', 'Krémes fokhagymaleves', 35, 'Leves', 'Glutén, Tej'),
(12, 'Zöldségleves', 'Könnyű sárgarépás zöldségleves', 40, 'Leves', NULL),
(13, 'Császármorzsa', 'Osztrák édes tésztamorzsa', 40, 'Desszert', 'Glutén, Tojás, Tej'),
(14, 'Galuska', 'Hagyományos galuska pörköltekhez', 20, 'Köret', 'Glutén, Tojás'),
(15, 'Hagymaleves', 'Pirított hagymás meleg leves', 35, 'Leves', 'Glutén'),
(16, 'Dödölle', 'Hagyományos pirított krumplis étel', 50, 'Főétel', 'Glutén'),
(17, 'Tejbegíz', 'Édes tejes gríz cukorral', 15, 'Desszert', 'Glutén, Tej'),
(18, 'Pörkölt szaft alap', 'Általános pörkölt alap ételízesítéshez', 25, 'Alap', NULL),
(19, 'Tükörtojás', 'Serpenyőben sült tükörtojás', 8, 'Reggeli', 'Tojás'),
(20, 'Pirított hagymás krumpli', 'Főtt krumpli pirított hagymával', 35, 'Köret', NULL);

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `hozzavalok`
--
ALTER TABLE `hozzavalok`
  ADD CONSTRAINT `hozzavalok_ibfk_1` FOREIGN KEY (`recept_id`) REFERENCES `receptek` (`recept_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `hozzavalok_ibfk_2` FOREIGN KEY (`alapanyag_id`) REFERENCES `alapanyagok` (`alapanyag_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
