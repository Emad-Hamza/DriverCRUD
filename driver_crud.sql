-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Feb 24, 2023 at 06:22 PM
-- Server version: 8.0.31
-- PHP Version: 8.1.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `driver_crud`
--

-- --------------------------------------------------------

--
-- Table structure for table `drivers`
--

DROP TABLE IF EXISTS `drivers`;
CREATE TABLE IF NOT EXISTS `drivers` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `first_name` varchar(191) COLLATE utf8mb4_general_ci NOT NULL,
  `last_name` varchar(191) COLLATE utf8mb4_general_ci NOT NULL,
  `email` varchar(191) COLLATE utf8mb4_general_ci NOT NULL,
  `phone_number` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=207 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `drivers`
--

INSERT INTO `drivers` (`id`, `first_name`, `last_name`, `email`, `phone_number`) VALUES
(206, 'Juwan', 'Maggio', 'Leonora_Harvey@gmail.com', '(331) 831-0912'),
(205, 'Claire', 'Heller', 'Lane_Denesik4@gmail.com', '666-269-8210'),
(203, 'Adrien', 'Wyman', 'Isaias44@hotmail.com', '(472) 298-5457 x1182'),
(204, 'Kaley', 'Gibson', 'Viva57@hotmail.com', '(327) 381-2218'),
(202, 'Moriah', 'Schulist', 'Anna_OConnell18@hotmail.com', '(755) 665-9842 x16761'),
(201, 'Ransom', 'Dooley', 'Emie.Graham@gmail.com', '(848) 245-6739'),
(199, 'Rylee', 'Rodriguez', 'Marcel18@yahoo.com', '1-731-500-3055 x44133'),
(200, 'Delfina', 'Terry', 'Pedro.Russel58@hotmail.com', '560.436.4929'),
(198, 'Rosamond', 'Rohan', 'Opal38@yahoo.com', '985.619.8865'),
(196, 'Jaiden', 'West', 'Sylvester88@hotmail.com', '577.332.7229'),
(197, 'Clarabelle', 'Klein', 'Paul_Emard73@gmail.com', '1-711-497-3712'),
(195, 'Paolo', 'Cartwright', 'Rashawn.Towne@gmail.com', '1-643-409-3871 x7064'),
(194, 'Elisabeth', 'Kshlerin', 'Noel_Altenwerth@gmail.com', '1-668-234-7070 x02282'),
(193, 'Geovany', 'Gusikowski', 'Austin_Rosenbaum@gmail.com', '737.308.8949'),
(191, 'Guido', 'Altenwerth', 'Bobbie14@hotmail.com', '822.413.5121'),
(192, 'Wyatt', 'Gusikowski', 'Chyna_Schneider25@yahoo.com', '1-259-265-3441 x2252'),
(190, 'Idella', 'Stokes', 'Verlie_Kulas29@gmail.com', '501.920.6927'),
(188, 'Reva', 'Considine', 'Kurtis.Brekke38@gmail.com', '418.619.3075'),
(189, 'Pinkie', 'Hirthe', 'Kayli72@yahoo.com', '968.759.4687 x35918'),
(187, 'Armando', 'Shanahan', 'Aiden_Beatty@yahoo.com', '1-819-991-1230 x65880'),
(186, 'Sarah', 'Bahringer', 'Zora90@hotmail.com', '(708) 528-7028 x319'),
(184, 'Kole', 'Moen', 'Dorcas_Schowalter18@gmail.com', '850.892.3412'),
(185, 'Clair', 'Harris', 'Erna.Abernathy@gmail.com', '717.778.5758 x0498'),
(183, 'Carolanne', 'Shanahan', 'Margret81@yahoo.com', '422-755-4317 x2126'),
(182, 'Edythe', 'Rosenbaum', 'Justice_Anderson@yahoo.com', '(333) 881-3069 x25716'),
(181, 'Jacquelyn', 'Fadel', 'Hailee.Kemmer@yahoo.com', '(259) 225-7095'),
(180, 'Keenan', 'Spinka', 'Shyanne.Stoltenberg2@yahoo.com', '1-877-989-9701 x2889'),
(178, 'Jaron', 'Luettgen', 'Amara.Kuvalis@gmail.com', '1-870-520-5400 x59581'),
(179, 'Addison', 'Shanahan', 'Carmel.Hartmann54@yahoo.com', '1-274-568-9629 x524'),
(177, 'Dee', 'Crooks', 'Raquel_Wolf@hotmail.com', '(448) 459-3099 x7014'),
(175, 'Ilene', 'Bogan', 'Jesus51@gmail.com', '1-838-239-3000 x014'),
(176, 'Liliane', 'Greenfelder', 'Jayson86@yahoo.com', '1-927-865-8549'),
(174, 'Ericka', 'Larkin', 'Caitlyn.Schowalter@hotmail.com', '(766) 421-8523'),
(172, 'Mina', 'Rau', 'Jeanie.West@yahoo.com', '376.214.2733'),
(173, 'Beatrice', 'Barton', 'Bo_Bernier@yahoo.com', '905-326-2944 x93191'),
(171, 'Rosalyn', 'Nikolaus', 'Erwin_Stoltenberg18@gmail.com', '(666) 410-7666 x203'),
(169, 'Ernie', 'Schiller', 'Mozelle_Fahey5@gmail.com', '1-981-958-9606 x9442'),
(170, 'Kennith', 'Wyman', 'Jack.Boehm35@yahoo.com', '589.962.3194 x75429'),
(168, 'Leta', 'Emmerich', 'Mozell77@yahoo.com', '292-428-9978'),
(166, 'Jarrell', 'Shields', 'Tremayne.Toy@gmail.com', '809.788.7674 x694'),
(167, 'Leonor', 'Wolff', 'John.Carter@gmail.com', '402-672-8310 x548'),
(165, 'Noble', 'Schowalter', 'Clovis84@hotmail.com', '873.561.6803 x2826'),
(163, 'Lue', 'Heidenreich', 'Marilyne.Borer86@yahoo.com', '(471) 578-4647'),
(164, 'Omari', 'Denesik', 'Keon82@gmail.com', '1-781-926-5416 x913'),
(162, 'Elmore', 'Bayer', 'Jeffery.Kulas73@gmail.com', '1-351-764-1543'),
(160, 'Adrian', 'Quitzon', 'Herbert76@hotmail.com', '(206) 298-7932'),
(161, 'Ferne', 'Volkman', 'Ivah32@yahoo.com', '228.674.9519 x6329'),
(159, 'Constance', 'Huels', 'Richmond.Kreiger@hotmail.com', '(780) 947-0355 x70345'),
(157, 'Vernice', 'Cartwright', 'Brisa_Orn90@hotmail.com', '668.831.3963 x5447'),
(158, 'Isabella', 'Littel', 'Cielo69@yahoo.com', '469-796-8051 x17359'),
(156, 'Addison', 'Nikolaus', 'Davon_Cremin63@gmail.com', '1-527-755-0236'),
(154, 'Marcelle', 'Conroy', 'Harmon.Dibbert27@hotmail.com', '531-796-2336'),
(155, 'Colleen', 'Koch', 'Dax95@hotmail.com', '(961) 763-8841'),
(153, 'Lavinia', 'Veum', 'Lindsey.Bogan@hotmail.com', '962.262.3668 x45304'),
(151, 'Otto', 'Harber', 'Dino12@yahoo.com', '1-932-943-7548'),
(152, 'Michel', 'Runolfsson', 'Keanu91@hotmail.com', '(888) 664-6905 x70925'),
(150, 'Tristian', 'Ryan', 'Abdullah47@hotmail.com', '(246) 732-0421 x603'),
(148, 'Sharon', 'Daugherty', 'Aileen.Daugherty@hotmail.com', '242-626-3304 x4785'),
(149, 'Astrid', 'Conn', 'Elvis_Becker@yahoo.com', '(667) 981-6986 x05760'),
(147, 'Rodolfo', 'Cormier', 'Theron.Gusikowski69@yahoo.com', '1-351-457-7436'),
(145, 'Tressa', 'Huels', 'Breanne_Berge@yahoo.com', '1-789-202-9648'),
(146, 'Green', 'Becker', 'Queenie_Spinka84@hotmail.com', '1-274-332-6915'),
(144, 'Brandyn', 'Schaefer', 'Ivy.Runolfsdottir@gmail.com', '862.445.8329 x57938'),
(143, 'Kristina', 'Hackett', 'Kitty.Nikolaus@hotmail.com', '867-681-7071 x706'),
(141, 'Kellen', 'Stehr', 'Natalie.Sipes79@hotmail.com', '341.731.6667'),
(142, 'Corbin', 'Auer', 'Merlin_Adams79@gmail.com', '415-978-2486 x7982'),
(140, 'Brown', 'Johnston', 'Sylvia82@gmail.com', '1-828-790-5578'),
(138, 'Maritza', 'Hammes', 'Stephany_Okuneva23@yahoo.com', '(896) 469-6137 x5962'),
(139, 'Devonte', 'Brown', 'Josh95@gmail.com', '(286) 328-8986 x78870'),
(137, 'Vernie', 'Nikolaus', 'Leslie.Yundt23@yahoo.com', '1-862-506-5830 x746'),
(136, 'Assunta', 'Funk', 'Wilmer.Hoeger16@gmail.com', '1-215-415-4914 x278'),
(134, 'Buck', 'Christiansen', 'Julianne95@yahoo.com', '1-300-230-7668 x0178'),
(135, 'Tyrel', 'Friesen', 'Herminia_Cole@hotmail.com', '779.982.6921'),
(133, 'Fabian', 'Bernhard', 'Jean_Treutel63@yahoo.com', '546-301-0039 x0609'),
(132, 'Leda', 'Borer', 'Myles_Ryan94@hotmail.com', '683-447-0802'),
(130, 'Willa', 'Emard', 'Novella98@gmail.com', '346-795-5825'),
(131, 'Marcel', 'Glover', 'Gilberto50@yahoo.com', '(804) 579-3455'),
(129, 'Akeem', 'Kassulke', 'Dayne_Bergstrom@gmail.com', '329.232.8296'),
(127, 'Albert', 'Towne', 'Chase67@gmail.com', '350.714.1816'),
(128, 'Vito', 'Jast', 'Letha.Harber@gmail.com', '1-423-506-2281 x2713'),
(126, 'Kiley', 'Okuneva', 'Dayton_Wisoky@gmail.com', '218-419-5555 x076'),
(124, 'Niko', 'Pouros', 'Eveline.Goldner22@gmail.com', '1-456-845-2408'),
(125, 'Rosina', 'Hudson', 'Flavio.Langosh@yahoo.com', '869.863.0752 x644'),
(123, 'Laron', 'Crona', 'Trever.Schinner95@hotmail.com', '1-973-801-0102 x808'),
(121, 'Leon', 'Wuckert', 'Thalia_Miller45@yahoo.com', '(723) 931-9173 x0585'),
(122, 'Abel', 'Murphy', 'Janiya.Streich85@yahoo.com', '(974) 323-1038 x645'),
(120, 'Alysha', 'Romaguera', 'Geovanny.Gutmann37@gmail.com', '597.884.8403'),
(118, 'Anjali', 'Hoeger', 'Mylene.Lubowitz18@gmail.com', '1-763-376-4595 x7841'),
(119, 'Albert', 'Rau', 'Hugh.Beahan65@gmail.com', '474.847.1556 x58011'),
(117, 'Jayme', 'Kub', 'Jerod_Murazik@gmail.com', '1-973-641-9722'),
(115, 'Ricardo', 'Pollich', 'Santina40@yahoo.com', '511.741.5363'),
(116, 'Chester', 'Yundt', 'Ellis.Gulgowski@hotmail.com', '1-653-982-5415 x9226'),
(114, 'Shawna', 'Boehm', 'Green6@yahoo.com', '(904) 951-0045'),
(112, 'Michael', 'Terry', 'Alejandra.Schaefer@hotmail.com', '1-543-666-6734'),
(113, 'Nils', 'Wuckert', 'Mathew91@yahoo.com', '703.470.8478 x0255'),
(111, 'Judson', 'Rogahn', 'Flavie.Adams97@yahoo.com', '1-408-822-2172 x9200'),
(110, 'Tiara', 'Gusikowski', 'Noemie_Leannon@hotmail.com', '(525) 670-9437'),
(109, 'Albina', 'Rowe', 'Ferne0@hotmail.com', '(588) 729-6788 x15184'),
(107, 'Glennie', 'Kemmer', 'Alek.Baumbach27@hotmail.com', '657.833.2228'),
(108, 'Rose', 'Considine', 'Marty26@gmail.com', '1-909-220-7715 x298');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
