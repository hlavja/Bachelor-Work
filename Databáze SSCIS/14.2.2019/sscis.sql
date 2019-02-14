-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Počítač: 127.0.0.1
-- Vytvořeno: Čtv 14. úno 2019, 19:35
-- Verze serveru: 5.7.24
-- Verze PHP: 7.3.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databáze: `sscis`
--

-- --------------------------------------------------------

--
-- Struktura tabulky `approval`
--

CREATE TABLE `approval` (
  `ID` int(11) NOT NULL,
  `ID_TUTOR` int(11) NOT NULL,
  `ID_SUBJECT` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktura tabulky `enum_role`
--

CREATE TABLE `enum_role` (
  `ID` int(11) NOT NULL,
  `ROLE` varchar(24) COLLATE utf8_bin NOT NULL,
  `DESCRIPTION` varchar(160) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Vypisuji data pro tabulku `enum_role`
--

INSERT INTO `enum_role` (`ID`, `ROLE`, `DESCRIPTION`) VALUES
(1, 'ADMIN', 'Administrátor'),
(2, 'TUTOR', 'Tutor'),
(3, 'USER', 'Uživatel');

-- --------------------------------------------------------

--
-- Struktura tabulky `enum_subject`
--

CREATE TABLE `enum_subject` (
  `ID` int(11) NOT NULL,
  `CODE` varchar(10) COLLATE utf8_bin NOT NULL,
  `NAME` varchar(30) COLLATE utf8_bin NOT NULL,
  `LESSON` tinyint(1) NOT NULL,
  `ID_PARENT` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Vypisuji data pro tabulku `enum_subject`
--

INSERT INTO `enum_subject` (`ID`, `CODE`, `NAME`, `LESSON`, `ID_PARENT`) VALUES
(1, '1', 'MAT', 0, NULL),
(2, 'M2', 'Matematika 2', 0, 1);

-- --------------------------------------------------------

--
-- Struktura tabulky `event`
--

CREATE TABLE `event` (
  `ID` int(11) NOT NULL,
  `TIME_FROM` datetime NOT NULL,
  `TIME_TO` datetime NOT NULL,
  `ID_SUBJECT` int(11) NOT NULL,
  `ID_TUTOR` int(11) NOT NULL,
  `IS_ACCEPTED` tinyint(1) DEFAULT NULL,
  `IS_CANCELLED` tinyint(1) DEFAULT NULL,
  `CANCELATION_COMMENT` varchar(480) COLLATE utf8_bin NOT NULL,
  `IS_EXTRA_LESSON` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktura tabulky `feedback`
--

CREATE TABLE `feedback` (
  `ID` int(11) NOT NULL,
  `ID_PARTICIPATION` int(11) NOT NULL,
  `TEXT` varchar(1000) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktura tabulky `participation`
--

CREATE TABLE `participation` (
  `ID` int(11) NOT NULL,
  `ID_EVENT` int(11) NOT NULL,
  `ID_USER` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktura tabulky `sscis_content`
--

CREATE TABLE `sscis_content` (
  `ID` int(11) NOT NULL,
  `ID_AUTHOR` int(11) NOT NULL,
  `ID_EDITED_BY` int(11) DEFAULT NULL,
  `CREATED` datetime NOT NULL,
  `EDITED` datetime NOT NULL,
  `TEXT_CONTENT` varchar(3200) COLLATE utf8_bin NOT NULL,
  `HEADER` varchar(180) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Vypisuji data pro tabulku `sscis_content`
--

INSERT INTO `sscis_content` (`ID`, `ID_AUTHOR`, `ID_EDITED_BY`, `CREATED`, `EDITED`, `TEXT_CONTENT`, `HEADER`) VALUES
(3, 1, 1, '2019-02-14 00:00:00', '2019-02-14 02:00:00', 'Ahoj jak se máš?', 'Základ'),
(10, 3, 3, '2019-02-14 00:00:02', '2019-02-21 00:00:02', 'asdf', 'adsf'),
(12, 1, 1, '2019-02-14 00:00:00', '2019-02-21 00:00:02', '22', '222'),
(16, 1, 1, '2019-02-14 17:49:20', '0001-01-01 00:00:00', 'Jak se máš?', 'Ahoj'),
(18, 1, 1, '2019-02-14 18:06:32', '0001-01-01 00:00:00', 'asdf', 'adf'),
(19, 1, 1, '2019-02-14 18:06:51', '0001-01-01 00:00:00', 'ešcžešcrešc', 'ešcrešcr'),
(20, 1, 1, '2019-02-14 18:07:00', '0001-01-01 00:00:00', 'cržácžrá', 'ertuzertu');

-- --------------------------------------------------------

--
-- Struktura tabulky `sscis_param`
--

CREATE TABLE `sscis_param` (
  `ID` int(11) NOT NULL,
  `PARAM_KEY` varchar(120) COLLATE utf8_bin NOT NULL,
  `PARAM_VALUE` varchar(240) COLLATE utf8_bin NOT NULL,
  `DESCRIPTION` varchar(480) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Vypisuji data pro tabulku `sscis_param`
--

INSERT INTO `sscis_param` (`ID`, `PARAM_KEY`, `PARAM_VALUE`, `DESCRIPTION`) VALUES
(1, 'WEB_AUTH_ON', '0', 'Autorizace přes webauth'),
(2, 'WEB_AUTH_URL', 'none', 'none'),
(5, 'MAP_TOKEN', 'AIzaSyAbXzS1is8YRQaQKdAgpoO7OnvQ1klGsi4', 'Token pro google mapy'),
(6, 'SESSION_LENGTH', '900', 'Délka session'),
(7, 'MAX_SUBJECTS_COUNT', '10', 'Maximalni pocet predmetu na prihlasce'),
(8, 'VERSION', '0.0.7', 'Oznaceni verze');

-- --------------------------------------------------------

--
-- Struktura tabulky `sscis_session`
--

CREATE TABLE `sscis_session` (
  `ID` int(11) NOT NULL,
  `ID_USER` int(11) NOT NULL,
  `SESSION_START` datetime NOT NULL,
  `EXPIRATION` datetime NOT NULL,
  `HASH` varchar(480) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Vypisuji data pro tabulku `sscis_session`
--

INSERT INTO `sscis_session` (`ID`, `ID_USER`, `SESSION_START`, `EXPIRATION`, `HASH`) VALUES
(53, 1, '2019-02-14 18:25:28', '2019-02-14 18:40:28', 'FC-6D-AD-6F-7E-56-F2-C6-BF-06-28-70-0A-0C-48-8E-DF-29-7F-FF-12-EF-CB-21-9C-32-70-22-1B-27-84-2A');

-- --------------------------------------------------------

--
-- Struktura tabulky `sscis_user`
--

CREATE TABLE `sscis_user` (
  `ID` int(11) NOT NULL,
  `LOGIN` varchar(160) COLLATE utf8_bin NOT NULL,
  `FIRSTNAME` varchar(255) COLLATE utf8_bin NOT NULL,
  `LASTNAME` varchar(255) COLLATE utf8_bin NOT NULL,
  `ID_ROLE` int(11) NOT NULL,
  `IS_ACTIVE` tinyint(1) NOT NULL,
  `CREATED` datetime NOT NULL,
  `ACTIVATED` datetime DEFAULT NULL,
  `STUDENT_NUMBER` varchar(10) COLLATE utf8_bin NOT NULL,
  `IS_ACTIVATED_BY` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Vypisuji data pro tabulku `sscis_user`
--

INSERT INTO `sscis_user` (`ID`, `LOGIN`, `FIRSTNAME`, `LASTNAME`, `ID_ROLE`, `IS_ACTIVE`, `CREATED`, `ACTIVATED`, `STUDENT_NUMBER`, `IS_ACTIVATED_BY`) VALUES
(1, 'admin', 'Jakub', 'Hlaváč', 1, 1, '2019-01-13 15:00:00', '2019-01-13 15:06:00', '', NULL),
(2, 'user', 'Kamila', 'Lenivá', 3, 1, '2019-02-14 00:00:00', '2019-02-14 06:00:00', 'A16B0457P', NULL),
(3, 'tutor', 'Tutor', 'Nicnedělá', 2, 1, '2019-02-14 00:00:00', '2019-02-14 02:00:00', 'A16B0457P', 1);

-- --------------------------------------------------------

--
-- Struktura tabulky `tutor_application`
--

CREATE TABLE `tutor_application` (
  `ID` int(11) NOT NULL,
  `ID_USER` int(11) NOT NULL,
  `APPLICATION_DATE` datetime NOT NULL,
  `IS_ACCEPTED` tinyint(1) NOT NULL,
  `ACCEPTED_DATE` datetime NOT NULL,
  `ACCEPTED_BY_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktura tabulky `tutor_application_subject`
--

CREATE TABLE `tutor_application_subject` (
  `ID` int(11) NOT NULL,
  `ID_SUBJECT` int(11) NOT NULL,
  `ID_APPLICATION` int(11) NOT NULL,
  `DEGREE` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Klíče pro exportované tabulky
--

--
-- Klíče pro tabulku `approval`
--
ALTER TABLE `approval`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `ID_TUTOR` (`ID_TUTOR`),
  ADD UNIQUE KEY `ID_SUBJECT` (`ID_SUBJECT`);

--
-- Klíče pro tabulku `enum_role`
--
ALTER TABLE `enum_role`
  ADD PRIMARY KEY (`ID`);

--
-- Klíče pro tabulku `enum_subject`
--
ALTER TABLE `enum_subject`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `ID_PARENT` (`ID_PARENT`);

--
-- Klíče pro tabulku `event`
--
ALTER TABLE `event`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `ID_SUBJECT` (`ID_SUBJECT`),
  ADD UNIQUE KEY `ID_TUTOR` (`ID_TUTOR`);

--
-- Klíče pro tabulku `feedback`
--
ALTER TABLE `feedback`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `ID_PARTICIPATION` (`ID_PARTICIPATION`);

--
-- Klíče pro tabulku `participation`
--
ALTER TABLE `participation`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `ID_EVENT` (`ID_EVENT`),
  ADD UNIQUE KEY `ID_USER` (`ID_USER`);

--
-- Klíče pro tabulku `sscis_content`
--
ALTER TABLE `sscis_content`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_AUTHOR` (`ID_AUTHOR`) USING BTREE,
  ADD KEY `ID_EDITED_BY` (`ID_EDITED_BY`) USING BTREE;

--
-- Klíče pro tabulku `sscis_param`
--
ALTER TABLE `sscis_param`
  ADD PRIMARY KEY (`ID`);

--
-- Klíče pro tabulku `sscis_session`
--
ALTER TABLE `sscis_session`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `ID_USER` (`ID_USER`);

--
-- Klíče pro tabulku `sscis_user`
--
ALTER TABLE `sscis_user`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `ID_ROLE` (`ID_ROLE`),
  ADD UNIQUE KEY `IS_ACTIVATED_BY` (`IS_ACTIVATED_BY`);

--
-- Klíče pro tabulku `tutor_application`
--
ALTER TABLE `tutor_application`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `ID_USER` (`ID_USER`),
  ADD UNIQUE KEY `ACCEPTED_BY_ID` (`ACCEPTED_BY_ID`);

--
-- Klíče pro tabulku `tutor_application_subject`
--
ALTER TABLE `tutor_application_subject`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `ID_SUBJECT` (`ID_SUBJECT`),
  ADD UNIQUE KEY `ID_APPLICATION` (`ID_APPLICATION`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `approval`
--
ALTER TABLE `approval`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pro tabulku `enum_role`
--
ALTER TABLE `enum_role`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pro tabulku `enum_subject`
--
ALTER TABLE `enum_subject`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pro tabulku `event`
--
ALTER TABLE `event`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pro tabulku `feedback`
--
ALTER TABLE `feedback`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pro tabulku `participation`
--
ALTER TABLE `participation`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pro tabulku `sscis_content`
--
ALTER TABLE `sscis_content`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT pro tabulku `sscis_param`
--
ALTER TABLE `sscis_param`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT pro tabulku `sscis_session`
--
ALTER TABLE `sscis_session`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=54;

--
-- AUTO_INCREMENT pro tabulku `sscis_user`
--
ALTER TABLE `sscis_user`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pro tabulku `tutor_application`
--
ALTER TABLE `tutor_application`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pro tabulku `tutor_application_subject`
--
ALTER TABLE `tutor_application_subject`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Omezení pro exportované tabulky
--

--
-- Omezení pro tabulku `approval`
--
ALTER TABLE `approval`
  ADD CONSTRAINT `approval_ibfk_1` FOREIGN KEY (`ID_TUTOR`) REFERENCES `sscis_user` (`ID`),
  ADD CONSTRAINT `approval_ibfk_2` FOREIGN KEY (`ID_SUBJECT`) REFERENCES `enum_subject` (`ID`);

--
-- Omezení pro tabulku `enum_subject`
--
ALTER TABLE `enum_subject`
  ADD CONSTRAINT `enum_subject_ibfk_1` FOREIGN KEY (`ID_PARENT`) REFERENCES `enum_subject` (`ID`);

--
-- Omezení pro tabulku `event`
--
ALTER TABLE `event`
  ADD CONSTRAINT `event_ibfk_1` FOREIGN KEY (`ID_SUBJECT`) REFERENCES `enum_subject` (`ID`),
  ADD CONSTRAINT `event_ibfk_2` FOREIGN KEY (`ID_TUTOR`) REFERENCES `sscis_user` (`ID`);

--
-- Omezení pro tabulku `feedback`
--
ALTER TABLE `feedback`
  ADD CONSTRAINT `feedback_ibfk_1` FOREIGN KEY (`ID_PARTICIPATION`) REFERENCES `participation` (`ID`);

--
-- Omezení pro tabulku `participation`
--
ALTER TABLE `participation`
  ADD CONSTRAINT `participation_ibfk_1` FOREIGN KEY (`ID_EVENT`) REFERENCES `event` (`ID`),
  ADD CONSTRAINT `participation_ibfk_2` FOREIGN KEY (`ID_USER`) REFERENCES `sscis_user` (`ID`);

--
-- Omezení pro tabulku `sscis_content`
--
ALTER TABLE `sscis_content`
  ADD CONSTRAINT `sscis_content_ibfk_1` FOREIGN KEY (`ID_AUTHOR`) REFERENCES `sscis_user` (`ID`),
  ADD CONSTRAINT `sscis_content_ibfk_2` FOREIGN KEY (`ID_EDITED_BY`) REFERENCES `sscis_user` (`ID`);

--
-- Omezení pro tabulku `sscis_session`
--
ALTER TABLE `sscis_session`
  ADD CONSTRAINT `sscis_session_ibfk_1` FOREIGN KEY (`ID_USER`) REFERENCES `sscis_user` (`ID`);

--
-- Omezení pro tabulku `sscis_user`
--
ALTER TABLE `sscis_user`
  ADD CONSTRAINT `sscis_user_ibfk_1` FOREIGN KEY (`IS_ACTIVATED_BY`) REFERENCES `sscis_user` (`ID`),
  ADD CONSTRAINT `sscis_user_ibfk_2` FOREIGN KEY (`ID_ROLE`) REFERENCES `enum_role` (`ID`);

--
-- Omezení pro tabulku `tutor_application`
--
ALTER TABLE `tutor_application`
  ADD CONSTRAINT `tutor_application_ibfk_1` FOREIGN KEY (`ID_USER`) REFERENCES `sscis_user` (`ID`),
  ADD CONSTRAINT `tutor_application_ibfk_2` FOREIGN KEY (`ACCEPTED_BY_ID`) REFERENCES `sscis_user` (`ID`);

--
-- Omezení pro tabulku `tutor_application_subject`
--
ALTER TABLE `tutor_application_subject`
  ADD CONSTRAINT `tutor_application_subject_ibfk_1` FOREIGN KEY (`ID_APPLICATION`) REFERENCES `tutor_application` (`ID`),
  ADD CONSTRAINT `tutor_application_subject_ibfk_2` FOREIGN KEY (`ID_SUBJECT`) REFERENCES `enum_subject` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
