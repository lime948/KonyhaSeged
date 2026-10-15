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
(1, 1, '20 dkg'),
(1, 2, '2 db'),
(1, 3, '3 dl'),
(1, 4, '1 csipet'),
(1, 5, '1 csipet'),
(1, 6, '2 ek'),
(3, 2, '2 db'),
(3, 4, '1 csipet'),
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
(2, 18, '2 l');

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

INSERT INTO `receptek` (`recept_id`, `nev`, `leiras`, `elkeszitesi_ido`, `kategoria`, `allergenek`) VALUES
(1, 'Palacsinta', 'Édes tészta', 30, 'Desszert', NULL),
(2, 'Gulyás', 'Húsos leves', 120, 'Leves', NULL),
(3, 'Rántotta', 'Sült tojás', 10, 'Reggeli', NULL),
(4, 'Pizza', 'Kelt tészta', 45, 'Főétel', NULL),
(5, 'Muffin', 'Süti formában', 35, 'Desszert', NULL);

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
