-- --------------------------------------------------------
-- Хост:                         127.0.0.1
-- Версия сервера:               5.6.41 - MySQL Community Server (GPL)
-- Операционная система:         Win32
-- HeidiSQL Версия:              9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Дамп структуры базы данных workflow
CREATE DATABASE IF NOT EXISTS `workflow` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `workflow`;

-- Дамп структуры для таблица workflow.conversations
CREATE TABLE IF NOT EXISTS `conversations` (
  `name` char(50) DEFAULT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `messages` longtext,
  `users` mediumtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=56 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы workflow.conversations: ~52 rows (приблизительно)
/*!40000 ALTER TABLE `conversations` DISABLE KEYS */;
/*!40000 ALTER TABLE `conversations` ENABLE KEYS */;

-- Дамп структуры для таблица workflow.documents
CREATE TABLE IF NOT EXISTS `documents` (
  `author` char(50) DEFAULT NULL,
  `label` char(50) DEFAULT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `type` char(50) DEFAULT NULL,
  `recipients` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы workflow.documents: ~14 rows (приблизительно)
/*!40000 ALTER TABLE `documents` DISABLE KEYS */;
/*!40000 ALTER TABLE `documents` ENABLE KEYS */;

-- Дамп структуры для таблица workflow.news
CREATE TABLE IF NOT EXISTS `news` (
  `author` char(50) DEFAULT NULL,
  `label` char(50) DEFAULT NULL,
  `content` text,
  `time` datetime DEFAULT CURRENT_TIMESTAMP,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы workflow.news: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `news` DISABLE KEYS */;
/*!40000 ALTER TABLE `news` ENABLE KEYS */;

-- Дамп структуры для таблица workflow.templates
CREATE TABLE IF NOT EXISTS `templates` (
  `author` char(50) DEFAULT NULL,
  `name` char(50) DEFAULT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `type` char(50) DEFAULT NULL,
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы workflow.templates: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `templates` DISABLE KEYS */;
/*!40000 ALTER TABLE `templates` ENABLE KEYS */;

-- Дамп структуры для таблица workflow.users
CREATE TABLE IF NOT EXISTS `users` (
  `name` text,
  `password` text,
  `privileges` text,
  `shedule` text,
  `conversations` text,
  `update` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Дамп данных таблицы workflow.users: ~8 rows (приблизительно)
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

-- Дамп структуры для таблица workflow.variables
CREATE TABLE IF NOT EXISTS `variables` (
  `name` char(50) DEFAULT NULL,
  `value` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Дамп данных таблицы workflow.variables: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `variables` DISABLE KEYS */;
INSERT INTO `variables` (`name`, `value`) VALUES
	('main_news', 'main_text');
/*!40000 ALTER TABLE `variables` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
