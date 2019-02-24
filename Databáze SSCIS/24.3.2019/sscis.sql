-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Počítač: 127.0.0.1
-- Vytvořeno: Ned 24. úno 2019, 21:21
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

--
-- Vypisuji data pro tabulku `approval`
--

INSERT INTO `approval` (`ID`, `ID_TUTOR`, `ID_SUBJECT`) VALUES
(7, 4, 1),
(8, 4, 3),
(9, 4, 4),
(12, 3, 1),
(13, 3, 3);

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
  `LESSON` tinyint(1) DEFAULT NULL,
  `ID_PARENT` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Vypisuji data pro tabulku `enum_subject`
--

INSERT INTO `enum_subject` (`ID`, `CODE`, `NAME`, `LESSON`, `ID_PARENT`) VALUES
(1, 'MAT', 'Matematika', 0, NULL),
(2, 'M2', 'Matematika 2', 1, 1),
(3, 'INF', 'Informatika', 0, NULL),
(4, 'MECH', 'Mechanika', 0, NULL),
(7, 'PPA1', 'Počítače a programování 1', 1, 3),
(8, 'MECH 1', 'Mechanika 1', 1, 4);

-- --------------------------------------------------------

--
-- Struktura tabulky `event`
--

CREATE TABLE `event` (
  `ID` int(11) NOT NULL,
  `TIME_FROM` datetime NOT NULL,
  `TIME_TO` datetime NOT NULL,
  `ID_SUBJECT` int(11) NOT NULL,
  `ID_TUTOR` int(11) DEFAULT NULL,
  `IS_ACCEPTED` tinyint(1) DEFAULT NULL,
  `IS_CANCELLED` tinyint(1) DEFAULT NULL,
  `CANCELATION_COMMENT` varchar(480) COLLATE utf8_bin DEFAULT NULL,
  `IS_EXTRA_LESSON` tinyint(1) DEFAULT NULL,
  `ID_APPLICANT` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Vypisuji data pro tabulku `event`
--

INSERT INTO `event` (`ID`, `TIME_FROM`, `TIME_TO`, `ID_SUBJECT`, `ID_TUTOR`, `IS_ACCEPTED`, `IS_CANCELLED`, `CANCELATION_COMMENT`, `IS_EXTRA_LESSON`, `ID_APPLICANT`) VALUES
(7, '2019-02-25 15:00:00', '2019-02-25 16:00:00', 1, 3, 1, 0, NULL, 1, 2),
(10, '2019-02-26 17:00:00', '2019-02-26 18:00:00', 3, 3, 1, 1, 'asd', 0, NULL),
(11, '2019-02-23 20:00:00', '2019-02-23 21:00:00', 1, 4, 1, 0, NULL, 0, NULL),
(12, '2019-02-24 22:00:00', '2019-02-24 23:00:00', 3, 3, 1, 0, NULL, 0, NULL),
(13, '2019-03-03 15:00:00', '2019-03-03 17:00:00', 1, 3, 1, 0, NULL, 0, NULL),
(14, '2019-02-26 15:50:00', '2019-02-26 16:50:00', 3, 4, 1, 0, NULL, 1, 2),
(15, '2019-02-25 18:00:00', '2019-02-25 19:00:00', 3, NULL, 0, 0, NULL, 1, 2);

-- --------------------------------------------------------

--
-- Struktura tabulky `feedback`
--

CREATE TABLE `feedback` (
  `ID` int(11) NOT NULL,
  `ID_PARTICIPATION` int(11) NOT NULL,
  `TEXT` varchar(1000) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Vypisuji data pro tabulku `feedback`
--

INSERT INTO `feedback` (`ID`, `ID_PARTICIPATION`, `TEXT`) VALUES
(1, 3, 'Super lekce'),
(2, 4, 'cšrýžšrážrtýcáirtz');

-- --------------------------------------------------------

--
-- Struktura tabulky `participation`
--

CREATE TABLE `participation` (
  `ID` int(11) NOT NULL,
  `ID_EVENT` int(11) NOT NULL,
  `ID_USER` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Vypisuji data pro tabulku `participation`
--

INSERT INTO `participation` (`ID`, `ID_EVENT`, `ID_USER`) VALUES
(3, 7, 3),
(4, 14, 4);

-- --------------------------------------------------------

--
-- Struktura tabulky `sscis_content`
--

CREATE TABLE `sscis_content` (
  `ID` int(11) NOT NULL,
  `ID_AUTHOR` int(11) NOT NULL,
  `ID_EDITED_BY` int(11) DEFAULT NULL,
  `CREATED` datetime NOT NULL,
  `EDITED` datetime DEFAULT NULL,
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
(20, 1, 1, '2019-02-14 18:07:00', '0001-01-01 00:00:00', 'cržácžrá', 'ertuzertu'),
(21, 1, NULL, '2019-02-15 00:25:40', '0001-01-01 00:00:00', 'tzurtzuirtzuoiuzto', 'erwzrteue'),
(22, 1, NULL, '2019-02-15 12:23:46', '0001-01-01 00:00:00', 'resgdfgd', 'ešžrctz'),
(24, 1, 1, '2019-02-20 21:32:20', '2019-02-20 21:32:36', 'Jak se máš?', 'Ahoj 233'),
(25, 1, NULL, '2019-02-24 17:25:55', NULL, 'https://www.facebook.com/Hrnky-DEGEN-348459922672749/', 'Kupujte hrnky DEGEN');

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
(1, 'WEB_AUTH_ON', '0', 'Autorizace pres webauth 2'),
(2, 'WEB_AUTH_URL', 'none', 'none'),
(5, 'MAP_TOKEN', 'AIzaSyAQs4WkNXBvsGLUrWoV70_9gcpTjwBwTdY', 'Token pro google mapy'),
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
(144, 4, '2019-02-24 21:07:02', '2019-02-24 21:22:02', 'C5-AC-41-2C-36-3A-76-E4-28-33-29-D1-A3-21-14-6F-4F-47-E9-A3-7F-7F-43-CF-98-BB-F5-93-AD-53-A0-D3');

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
  `IS_ACTIVE` tinyint(1) DEFAULT NULL,
  `CREATED` datetime NOT NULL,
  `ACTIVATED` datetime DEFAULT NULL,
  `STUDENT_NUMBER` varchar(10) COLLATE utf8_bin DEFAULT NULL,
  `EMAIL` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `IS_ACTIVATED_BY` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Vypisuji data pro tabulku `sscis_user`
--

INSERT INTO `sscis_user` (`ID`, `LOGIN`, `FIRSTNAME`, `LASTNAME`, `ID_ROLE`, `IS_ACTIVE`, `CREATED`, `ACTIVATED`, `STUDENT_NUMBER`, `EMAIL`, `IS_ACTIVATED_BY`) VALUES
(1, 'admin', 'Jakub', 'Hlaváč', 1, NULL, '0001-01-01 00:00:00', NULL, 'A16B0472P', 'hlavja@students.zcu.cz', NULL),
(2, 'user', 'Kamila', 'Lenivá', 3, 1, '2019-02-14 00:00:00', NULL, 'A16B0457P', NULL, NULL),
(3, 'tutor', 'Tutor', 'Nicnedělá', 2, 1, '2019-02-14 00:00:00', NULL, 'A16B0457P', NULL, 1),
(4, 'tutoral', 'Tutor', 'Vyučujevše', 2, 1, '2019-02-20 00:00:00', NULL, 'A16B0457P', NULL, 1);

-- --------------------------------------------------------

--
-- Struktura tabulky `tutor_application`
--

CREATE TABLE `tutor_application` (
  `ID` int(11) NOT NULL,
  `ID_USER` int(11) NOT NULL,
  `APPLICATION_DATE` datetime NOT NULL,
  `IS_ACCEPTED` tinyint(1) DEFAULT NULL,
  `ACCEPTED_DATE` datetime DEFAULT NULL,
  `ACCEPTED_BY_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Vypisuji data pro tabulku `tutor_application`
--

INSERT INTO `tutor_application` (`ID`, `ID_USER`, `APPLICATION_DATE`, `IS_ACCEPTED`, `ACCEPTED_DATE`, `ACCEPTED_BY_ID`) VALUES
(38, 4, '2019-02-21 00:07:54', 1, '2019-02-21 00:08:04', 1),
(41, 3, '2019-02-21 00:28:12', 1, '2019-02-21 00:28:19', 1),
(42, 2, '2019-02-23 16:37:10', 0, '2019-02-23 19:09:48', 1),
(43, 2, '2019-02-24 17:28:45', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Struktura tabulky `tutor_application_subject`
--

CREATE TABLE `tutor_application_subject` (
  `ID` int(11) NOT NULL,
  `ID_SUBJECT` int(11) DEFAULT NULL,
  `ID_APPLICATION` int(11) DEFAULT NULL,
  `DEGREE` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Vypisuji data pro tabulku `tutor_application_subject`
--

INSERT INTO `tutor_application_subject` (`ID`, `ID_SUBJECT`, `ID_APPLICATION`, `DEGREE`) VALUES
(47, 2, 38, 1),
(48, 7, 38, 3),
(49, 8, 38, 2),
(53, 2, 41, 1),
(54, 7, 41, 2),
(55, 2, 42, 1),
(56, 2, 43, 1),
(57, 7, 43, 3),
(58, 7, 43, 1);

--
-- Klíče pro exportované tabulky
--

--
-- Klíče pro tabulku `approval`
--
ALTER TABLE `approval`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_TUTOR` (`ID_TUTOR`) USING BTREE,
  ADD KEY `ID_SUBJECT` (`ID_SUBJECT`) USING BTREE;

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
  ADD KEY `ID_PARENT` (`ID_PARENT`) USING BTREE;

--
-- Klíče pro tabulku `event`
--
ALTER TABLE `event`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_SUBJECT` (`ID_SUBJECT`) USING BTREE,
  ADD KEY `ID_TUTOR` (`ID_TUTOR`) USING BTREE,
  ADD KEY `ID_APPLICANT` (`ID_APPLICANT`);

--
-- Klíče pro tabulku `feedback`
--
ALTER TABLE `feedback`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_PARTICIPATION` (`ID_PARTICIPATION`) USING BTREE;

--
-- Klíče pro tabulku `participation`
--
ALTER TABLE `participation`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_EVENT` (`ID_EVENT`) USING BTREE,
  ADD KEY `ID_USER` (`ID_USER`) USING BTREE;

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
  ADD KEY `ID_USER` (`ID_USER`) USING BTREE;

--
-- Klíče pro tabulku `sscis_user`
--
ALTER TABLE `sscis_user`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_ROLE` (`ID_ROLE`) USING BTREE,
  ADD KEY `IS_ACTIVATED_BY` (`IS_ACTIVATED_BY`) USING BTREE;

--
-- Klíče pro tabulku `tutor_application`
--
ALTER TABLE `tutor_application`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_USER` (`ID_USER`) USING BTREE,
  ADD KEY `ACCEPTED_BY_ID` (`ACCEPTED_BY_ID`) USING BTREE;

--
-- Klíče pro tabulku `tutor_application_subject`
--
ALTER TABLE `tutor_application_subject`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_SUBJECT` (`ID_SUBJECT`) USING BTREE,
  ADD KEY `ID_APPLICATION` (`ID_APPLICATION`) USING BTREE;

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `approval`
--
ALTER TABLE `approval`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT pro tabulku `enum_role`
--
ALTER TABLE `enum_role`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pro tabulku `enum_subject`
--
ALTER TABLE `enum_subject`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT pro tabulku `event`
--
ALTER TABLE `event`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT pro tabulku `feedback`
--
ALTER TABLE `feedback`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pro tabulku `participation`
--
ALTER TABLE `participation`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pro tabulku `sscis_content`
--
ALTER TABLE `sscis_content`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT pro tabulku `sscis_param`
--
ALTER TABLE `sscis_param`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT pro tabulku `sscis_session`
--
ALTER TABLE `sscis_session`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=145;

--
-- AUTO_INCREMENT pro tabulku `sscis_user`
--
ALTER TABLE `sscis_user`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pro tabulku `tutor_application`
--
ALTER TABLE `tutor_application`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT pro tabulku `tutor_application_subject`
--
ALTER TABLE `tutor_application_subject`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=59;

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
  ADD CONSTRAINT `event_ibfk_2` FOREIGN KEY (`ID_TUTOR`) REFERENCES `sscis_user` (`ID`),
  ADD CONSTRAINT `event_ibfk_3` FOREIGN KEY (`ID_APPLICANT`) REFERENCES `sscis_user` (`ID`);

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
