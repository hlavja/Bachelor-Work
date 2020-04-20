-- phpMyAdmin SQL Dump
-- version 4.6.6deb4
-- https://www.phpmyadmin.net/
--
-- Počítač: localhost
-- Vytvořeno: Pon 24. úno 2020, 20:47
-- Verze serveru: 10.3.22-MariaDB-0+deb10u1
-- Verze PHP: 7.0.33-1~dotdeb+8.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databáze: `lvasa`
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
(64, 43, 1),
(65, 43, 3),
(66, 43, 4),
(67, 44, 1),
(68, 44, 3),
(69, 44, 4),
(70, 47, 3),
(71, 49, 3),
(72, 48, 1),
(73, 50, 1),
(74, 51, 3),
(75, 52, 1),
(76, 53, 3),
(78, 54, 1),
(79, 55, 3),
(80, 62, 1);

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
(8, 'MECH 1', 'Mechanika 1', 1, 4),
(9, 'PPA2', 'Počítače a programování 2', 1, 3);

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
  `ATTENDANCE` int(50) DEFAULT NULL,
  `IS_CANCELLED` tinyint(1) DEFAULT NULL,
  `CANCELATION_COMMENT` varchar(480) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `IS_EXTRA_LESSON` tinyint(1) DEFAULT NULL,
  `ID_APPLICANT` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `event`
--

INSERT INTO `event` (`ID`, `TIME_FROM`, `TIME_TO`, `ID_SUBJECT`, `ID_TUTOR`, `IS_ACCEPTED`, `ATTENDANCE`, `IS_CANCELLED`, `CANCELATION_COMMENT`, `IS_EXTRA_LESSON`, `ID_APPLICANT`) VALUES
(81, '2019-11-26 10:00:00', '2019-11-26 12:00:00', 1, 43, 1, 5, 0, NULL, 0, NULL),
(82, '2019-12-03 10:00:00', '2019-12-03 12:00:00', 1, 43, 1, 158, 0, NULL, 0, NULL),
(83, '2019-12-10 10:00:00', '2019-12-10 12:00:00', 1, 43, 1, 0, 0, NULL, 0, NULL),
(84, '2019-12-17 10:00:00', '2019-12-17 12:00:00', 1, 43, 1, 4, 0, NULL, 0, NULL),
(85, '2019-12-31 11:00:00', '2019-12-31 12:00:00', 3, 1, 1, NULL, 1, 'Tutor fired!', 1, 43),
(86, '2019-11-20 11:00:00', '2019-11-20 13:00:00', 1, 1, 1, 1, 0, NULL, 0, NULL),
(87, '2019-12-02 09:00:00', '2019-12-02 11:00:00', 3, 53, 0, NULL, 0, NULL, 0, NULL),
(88, '2019-12-09 09:00:00', '2019-12-09 11:00:00', 3, 53, 0, NULL, 0, NULL, 0, NULL),
(89, '2019-12-16 09:00:00', '2019-12-16 11:00:00', 3, 53, 0, NULL, 0, NULL, 0, NULL),
(90, '2019-12-05 10:00:00', '2019-12-05 12:00:00', 1, 50, 1, 0, 0, NULL, 0, NULL),
(91, '2019-12-12 10:00:00', '2019-12-12 12:00:00', 1, 50, 1, 1, 0, NULL, 0, NULL),
(92, '2019-12-19 10:00:00', '2019-12-19 12:00:00', 1, 50, 1, 1, 0, NULL, 0, NULL),
(93, '2019-12-05 10:00:00', '2019-12-05 11:00:00', 1, 50, 1, 2, 0, 'test', 1, 50),
(94, '2019-12-12 15:00:00', '2019-12-12 17:00:00', 1, 54, 0, NULL, 0, NULL, 0, NULL),
(95, '2019-12-05 15:00:00', '2019-12-05 17:00:00', 1, 54, 0, NULL, 0, NULL, 0, NULL),
(96, '2019-12-19 15:00:00', '2019-12-19 17:00:00', 1, 54, 0, NULL, 0, NULL, 0, NULL),
(99, '2020-01-22 10:10:00', '2020-01-22 12:10:00', 1, 1, 0, NULL, 1, 'Tutor fired!', 0, NULL),
(100, '2020-01-29 10:10:00', '2020-01-29 12:10:00', 1, 1, 0, NULL, 1, 'Tutor fired!', 0, NULL),
(101, '2020-02-05 10:10:00', '2020-02-05 12:10:00', 1, 1, 0, NULL, 1, 'Tutor fired!', 0, NULL),
(102, '2020-02-13 10:00:00', '2020-02-13 12:00:00', 1, 50, 1, NULL, 0, NULL, 0, NULL);

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
  `ID_USER` int(11) DEFAULT NULL
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
  `EDITED` datetime DEFAULT NULL,
  `TEXT_CONTENT` varchar(3200) COLLATE utf8_bin NOT NULL,
  `HEADER` varchar(180) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktura tabulky `sscis_param`
--

CREATE TABLE `sscis_param` (
  `ID` int(11) NOT NULL,
  `PARAM_KEY` varchar(120) COLLATE utf8_bin NOT NULL,
  `PARAM_VALUE` varchar(10000) COLLATE utf8_bin NOT NULL,
  `DESCRIPTION` varchar(480) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Vypisuji data pro tabulku `sscis_param`
--

INSERT INTO `sscis_param` (`ID`, `PARAM_KEY`, `PARAM_VALUE`, `DESCRIPTION`) VALUES
(1, 'WEB_AUTH_ON', 'true', 'Autorizace pres webauth 2'),
(2, 'WEB_AUTH_URL', 'https://fkmagion.zcu.cz/testauth/', 'Adresa webauth'),
(5, 'MAP_TOKEN', 'AIzaSyAQs4WkNXBvsGLUrWoV70_9gcpTjwBwTdY', 'Token pro google mapy'),
(6, 'SESSION_LENGTH', '900', 'Délka session'),
(7, 'MAX_SUBJECTS_COUNT', '10', 'Maximalni pocet predmetu na prihlasce'),
(8, 'VERSION', '0.9.1', 'Oznaceni verze'),
(9, 'STANDART_EVENT_LENGTH', '2', 'Délka standardní hodiny '),
(10, 'EXTRA_EVENT_LENGTH', '1', 'Délka extra lekce'),
(11, 'INDEX_HTML_TEXT', '&lt;p&gt;\r\n            &lt;strong&gt;Student Support Centre (SSC)&lt;/strong&gt; je společn&#225; aktivita kateder &lt;a href=&quot;http://www.fav.zcu.cz/&quot; target=&quot;_blank&quot;&gt;Fakulty aplikovan&#253;ch věd Z&#225;padočesk&#233; univerzity v Plzni&lt;/a&gt;.\r\n            &lt;br /&gt; &lt;br /&gt;\r\n            Projekt startuje ve zkouškov&#233;m obdob&#237; zimn&#237;ho semestru 2017/2018. C&#237;lem je podpora studentů prvn&#237;ho ročn&#237;ku, kteř&#237; mohou m&#237;t probl&#233;my s &#250;vodn&#237;mi matematick&#253;mi a\r\n            informatick&#253;mi předměty. Podpory se studentům dostane od kolegů ve vyšš&#237;ch ročn&#237;c&#237;ch pod dohledem pedagogick&#253;ch pracovn&#237;ků z&#250;častněn&#253;ch kateder.\r\n            Každ&#253; den v t&#253;dnu mohou studenti přij&#237;t do &lt;a href=&quot;https://drive.google.com/open?id=1tuebFsEvUDw3HhLc6PJtB0nnRfJTe5Bt&amp;usp=sharing&quot; target=&quot;_blank&quot;&gt;studovny FAV&lt;/a&gt;, kde z&#237;skaj&#237; bezplatnou pomoc se z&#225;kladn&#237;mi předměty:\r\n            &lt;ul&gt;\r\n                &lt;li&gt;&lt;strong&gt;matematika&lt;/strong&gt; - KMA/M1, KMA/M2, KMA/MA1, KMA/MA1, KMA/M1S, KMA/M2S, KMA/MA1E, KMA/M2E, KMA/ZM1, KMA/ZM2 (po dohodě tak&#233; KMA/LAA)&lt;/li&gt;\r\n\r\n                &lt;li&gt;&lt;strong&gt;programov&#225;n&#237;&lt;/strong&gt; - KIV/PPA1, KIV/PPA2 a KIV/UPG&lt;/li&gt;\r\n\r\n                &lt;li&gt;&lt;strong&gt;mechanika&lt;/strong&gt;&lt;/li&gt;\r\n            &lt;/ul&gt;\r\n        &lt;/p&gt;', 'Upravitelný text na indexové stránce ve spodní části webu.'),
(12, 'CHCI_POMAHAT_HTML_TEXT', '&lt;p&gt;Hled&#225;me tutory, tj. studenty/studentky 3.- 5. ročn&#237;ku FAV, kteř&#237; by si chtěli přivydělat poskytov&#225;n&#237;m konzultac&#237; mladš&#237;m spoluž&#225;kům. &lt;strong&gt;Nab&#237;z&#237;me 190,- Kč na hodinu, požadujeme dobr&#233; znalosti alespoň někter&#233;ho z doučovan&#253;ch předmětů&lt;/strong&gt; tj. na &#250;rovni zn&#225;mky v&#253;borně nebo alespoň velmi dobře.&lt;/p&gt;', 'Upravitelný text na stránce chci pomáhat v horní části webu.'),
(13, 'POTREBUJI_POMOC_HTML_TEXT', '&lt;p&gt;             K dispozici budou pokažd&#233; dva tutoři (studenti vyšš&#237;ho ročn&#237;ku FAV) a jeden pedagog z katedry zaštiťuj&#237;c&#237; př&#237;slušnou oblast (podrobn&#253; rozpis). Diskutovat je možn&#233; jak&#225;koli t&#233;mata z n&#225;sleduj&#237;c&#237;ch předmětů:              &lt;ul&gt;                 &lt;li&gt;&lt;strong&gt;matematika&lt;/strong&gt; - KKMA/M1, KMA/M2, KMA/MA1, KMA/MA1, KMA/M1S, KMA/M2S, KMA/MA1E, KMA/M2E, KMA/ZM1, KMA/ZM2 (po dohodě tak&#233; KMA/LAA)&lt;/li&gt;                  &lt;li&gt;&lt;strong&gt;programov&#225;n&#237;&lt;/strong&gt; - KIV/PPA1, KIV/PPA2 a KIV/UPG&lt;/li&gt;                  &lt;li&gt;&lt;strong&gt;mechanika&lt;/strong&gt;&lt;/li&gt;             &lt;/ul&gt;              Pomoc/konzultace je poskytov&#225;na bezplatně, &#250;čast je interně evidov&#225;na pro potřeby support centra, evidence však nen&#237; poskytov&#225;na vyučuj&#237;c&#237;m předmětů a nem&#225; ž&#225;dn&#253; vliv na hodnocen&#237; v dan&#253;ch předmětech.         &lt;/p&gt;', 'Upravitelný text na stránce potřebuji pomoc ve střední části webu.'),
(14, 'KONTAKT_HTML_TEXT', '&lt;p&gt;\r\n&lt;strong&gt;M&#225;te dotazy? Kontaktujte n&#225;s:&lt;/strong&gt;\r\n&lt;br /&gt;\r\n&lt;br /&gt;\r\nKMA: Světlana Tomiczkov&#225;, &lt;a href=&quot;mailto:svetlana@kma.zcu.cz&quot;&gt;svetlana@kma.zcu.cz&lt;/a&gt;\r\n&lt;br /&gt;\r\n&lt;br /&gt;\r\nKIV: Libor V&#225;ša, &lt;a href=&quot;mailto:lvasa@kiv.zcu.cz&quot;&gt;lvasa@kiv.zcu.cz&lt;/a&gt;\r\n&lt;/p&gt;', 'Upravitelný text na stránce kontakt.'),
(15, 'SMTP', 'smtp.zcu.cz', 'SMTP server pro odesílání pošty'),
(19, 'ADMIN_PASSWORD', 'Q4uqFcMQWF4f4VVD6yT1knUqIjkF7ct/R5yYr1QnzTPpBngU', 'Admin password!'),
(20, 'TIMETABLE_MONTH_RANGE', '1', 'Doba na kterou se má vykreslovat rozvrh (v měsících).');

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
(522, 1, '2020-02-13 22:58:30', '2020-02-13 23:13:30', 'B8-53-46-F9-E9-E0-24-45-7C-85-59-52-EB-39-15-0F-F0-D9-AF-BA-35-E6-4F-0D-F6-EE-4B-7A-DC-5E-08-38');

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
(1, 'admin', 'admin', 'admin', 1, 1, '0001-01-01 00:00:00', '0001-01-01 00:00:00', 'admin', 'lvasa@kiv.zcu.cz', NULL),
(42, 'hachaf', 'Filip', 'Hácha', 3, 1, '2019-11-15 22:16:44', '2019-11-15 22:16:44', NULL, 'hachaf@students.zcu.cz', NULL),
(43, 'lvasa', 'Libor', 'Váša', 1, 1, '0001-01-01 00:00:00', NULL, NULL, 'lvasa@ntis.zcu.cz', NULL),
(44, 'svetlana', 'Světlana', 'Tomiczková', 1, 1, '0001-01-01 00:00:00', NULL, NULL, 'svetlana@kma.zcu.cz', NULL),
(46, 'fenclm37', 'Martin', 'Fencl', 3, 1, '2019-11-26 16:51:43', '2019-11-26 16:51:43', NULL, 'fenclm37@ntis.zcu.cz', NULL),
(47, 'lovcim', 'Marek', 'Lovčí', 2, 1, '2019-11-26 17:05:30', '2019-11-26 17:05:30', NULL, 'lovcim@rek.zcu.cz', 44),
(48, 'hantovak', 'Kamila', 'Hantová', 2, 1, '2019-11-26 17:06:17', '2019-11-26 17:06:17', NULL, 'hantovak@rek.zcu.cz', 44),
(49, 'vyskocj', 'Jiří', 'Vyskočil', 2, 1, '2019-11-26 17:25:50', '2019-11-26 17:25:50', NULL, 'vyskocj@rek.zcu.cz', 44),
(50, 'kucerape', 'Petr', 'Kučera', 2, 1, '2019-11-26 17:42:27', '2019-11-26 17:42:27', NULL, 'kucerape@rti.zcu.cz', 44),
(51, 'zabran', 'Marek', 'Zábran', 2, 1, '2019-11-26 20:07:43', '2019-11-26 20:07:43', NULL, 'zabran@kiv.zcu.cz', 44),
(52, 'kadlecj9', 'Jiří', 'Kadlec', 2, 1, '2019-11-26 20:16:59', '2019-11-26 20:16:59', NULL, 'kadlecj9@rek.zcu.cz', 44),
(53, 'jitka', 'Jitka', 'Fürbacherová', 2, 1, '2019-11-26 20:25:25', '2019-11-26 20:25:25', NULL, 'jitka@rek.zcu.cz', 44),
(54, 'sivek', 'Miroslav', 'Sívek', 2, 1, '2019-11-26 20:51:14', '2019-11-26 20:51:14', NULL, 'sivek@rek.zcu.cz', 44),
(55, 'anezkaj', 'Anežka', 'Jáchymová', 2, 1, '2019-11-26 20:54:57', '2019-11-26 20:54:57', NULL, 'anezkaj@rek.zcu.cz', 44),
(56, 'vmasek', 'Václav', 'Mašek', 3, 1, '2019-11-27 19:27:00', '2019-11-27 19:27:00', NULL, 'vmasek@rek.zcu.cz', NULL),
(57, 'trnkpe', 'Petr', 'Trnka', 3, 1, '2019-11-29 08:59:29', '2019-11-29 08:59:29', NULL, 'trnkpe@rek.zcu.cz', NULL),
(62, 'hlavja', 'Jakub', 'Hlaváč', 2, 1, '2020-01-19 20:50:01', '2020-01-19 20:50:01', NULL, 'hlavja@students.zcu.cz', 1),
(63, 'kleinerv', 'Viktorie', 'Kleinertová', 3, 1, '2020-01-19 21:24:11', '2020-01-19 21:24:11', NULL, 'kleinerv@students.zcu.cz', NULL);

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
(3, 43, '2019-11-18 10:55:39', 1, '2019-11-18 10:58:55', 1),
(5, 47, '2019-11-26 17:06:33', 1, '2019-11-26 20:47:01', 44),
(6, 48, '2019-11-26 17:06:50', 1, '2019-11-26 20:47:14', 44),
(7, 49, '2019-11-26 17:26:20', 1, '2019-11-26 20:47:07', 44),
(8, 50, '2019-11-26 17:44:37', 1, '2019-11-26 20:47:20', 44),
(9, 51, '2019-11-26 20:08:08', 1, '2019-11-26 20:47:24', 44),
(10, 52, '2019-11-26 20:18:14', 1, '2019-11-26 20:47:30', 44),
(11, 53, '2019-11-26 20:26:51', 1, '2019-11-26 20:47:35', 44),
(12, 54, '2019-11-26 20:52:08', 1, '2019-11-27 09:45:57', 44),
(13, 55, '2019-11-26 20:55:17', 1, '2019-11-27 09:46:00', 44),
(14, 56, '2019-11-29 08:31:03', NULL, NULL, NULL),
(15, 57, '2019-11-29 16:12:05', NULL, NULL, NULL),
(16, 62, '2020-02-10 20:38:02', 1, '2020-02-10 20:38:19', 1);

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
(5, 2, 3, 1),
(7, 7, 5, 1),
(8, 9, 5, 1),
(9, 2, 6, 2),
(10, 2, 6, NULL),
(11, 7, 7, 1),
(12, 9, 7, 1),
(13, 2, 8, 2),
(14, 2, 8, NULL),
(15, 7, 9, 1),
(16, 9, 9, 1),
(17, 2, 10, 2),
(18, 2, 10, NULL),
(19, 7, 11, 1),
(20, 2, 12, NULL),
(21, 7, 13, 1),
(22, 2, 14, 1),
(23, 8, 14, 2),
(24, 2, 15, 1),
(25, 2, 16, 1);

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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=81;
--
-- AUTO_INCREMENT pro tabulku `enum_role`
--
ALTER TABLE `enum_role`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT pro tabulku `enum_subject`
--
ALTER TABLE `enum_subject`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT pro tabulku `event`
--
ALTER TABLE `event`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=103;
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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pro tabulku `sscis_param`
--
ALTER TABLE `sscis_param`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
--
-- AUTO_INCREMENT pro tabulku `sscis_session`
--
ALTER TABLE `sscis_session`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=523;
--
-- AUTO_INCREMENT pro tabulku `sscis_user`
--
ALTER TABLE `sscis_user`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=64;
--
-- AUTO_INCREMENT pro tabulku `tutor_application`
--
ALTER TABLE `tutor_application`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
--
-- AUTO_INCREMENT pro tabulku `tutor_application_subject`
--
ALTER TABLE `tutor_application_subject`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;
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

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
