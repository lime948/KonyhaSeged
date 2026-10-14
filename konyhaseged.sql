CREATE DATABASE IF NOT EXISTS `konyhaseged` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `konyhaseged`;

CREATE TABLE `alapanyagok` (
  `alapanyag_id` int(11) NOT NULL,
  `nev` int(11) NOT NULL,
  `mertekegyseg` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `hozzavalok` (
  `recept_id` int(11) NOT NULL,
  `alapanyag_id` int(11) NOT NULL,
  `mennyiseg` int(11) NOT NULL,
  `mertekegyseg` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `receptek` (
  `recept_id` int(11) NOT NULL,
  `nev` varchar(10) NOT NULL,
  `leiras` varchar(10) NOT NULL,
  `elkeszitesi_ido` int(10) NOT NULL,
  `kategoria` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
COMMIT;