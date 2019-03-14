-- phpMyAdmin SQL Dump
-- version 2.11.7
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 15-07-2016 a las 20:46:51
-- Versión del servidor: 5.0.51
-- Versión de PHP: 5.2.6

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `rj_shop`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `comics`
--

CREATE TABLE IF NOT EXISTS `comics` (
  `COM_ID` int(11) NOT NULL auto_increment,
  `COM_TITULO` varchar(75) collate utf8_spanish_ci default NULL,
  `COM_EDITORIAL` varchar(15) collate utf8_spanish_ci default NULL,
  `COM_NOMBREHEROE` varchar(30) collate utf8_spanish_ci default NULL,
  `COM_NUMEROTITULO` int(11) default NULL,
  `COM_DISPONIBLE` int(11) default NULL,
  `COM_STOCK` int(11) default NULL,
  `COM_IMAGEN` varchar(20) collate utf8_spanish_ci default NULL,
  `COM_DESCRIPCION` varchar(250) collate utf8_spanish_ci default NULL,
  `COM_PRECIO` int(11) default NULL,
  PRIMARY KEY  (`COM_ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci AUTO_INCREMENT=4 ;

--
-- Volcar la base de datos para la tabla `comics`
--

INSERT INTO `comics` (`COM_ID`, `COM_TITULO`, `COM_EDITORIAL`, `COM_NOMBREHEROE`, `COM_NUMEROTITULO`, `COM_DISPONIBLE`, `COM_STOCK`, `COM_IMAGEN`, `COM_DESCRIPCION`, `COM_PRECIO`) VALUES
(1, 'Amazing Spiderman #01', 'Marvel Comics', 'Spider-man', 1, 1, 10, NULL, 'El comic Titulado Amazing Spider-Man #1 (Subtitulada: Spider-Man Vs el CamaleÃ³n) es el primer comic de esta serie regular que hasta el dia de hoy continua, este comic se creo en 1963 por Stan Lee para la marvel comics.', 3500),
(2, 'Daredevil - Man without fear #01', 'Marvel Comics', 'Daredevil', 1, NULL, 2, NULL, 'Tomo numero 1 de Man without fear de Daredevil', 1),
(3, 'Civil War 03 - Los 4 Fantasticos #536', 'Marvel Comics', 'Fantastic Four', 536, NULL, 4, NULL, 'Tomo numero 3 del evento Marvel ', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuentas`
--

CREATE TABLE IF NOT EXISTS `cuentas` (
  `CUE_ID` int(11) NOT NULL auto_increment,
  `USU_ID` varchar(16) collate utf8_spanish_ci NOT NULL,
  `TIC_ID` int(11) NOT NULL,
  `CUE_PASSWORD` varchar(16) collate utf8_spanish_ci NOT NULL,
  `CUE_ESTADO` int(11) default NULL,
  PRIMARY KEY  (`CUE_ID`),
  KEY `FK_CONTIENEN` (`TIC_ID`),
  KEY `FK_CREAN` (`USU_ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci AUTO_INCREMENT=3 ;

--
-- Volcar la base de datos para la tabla `cuentas`
--

INSERT INTO `cuentas` (`CUE_ID`, `USU_ID`, `TIC_ID`, `CUE_PASSWORD`, `CUE_ESTADO`) VALUES
(1, 'Nicjergsen', 1, '189001134', NULL),
(2, 'Froen', 2, 'qwerty', NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalles`
--

CREATE TABLE IF NOT EXISTS `detalles` (
  `DET_ID` int(11) NOT NULL,
  `COM_ID` int(11) NOT NULL,
  `PED_ID` int(11) NOT NULL,
  `DET_CANTIDAD` int(11) NOT NULL,
  `DET_PAGADO` int(11) default NULL,
  PRIMARY KEY  (`DET_ID`),
  KEY `FK_GENERAN` (`COM_ID`),
  KEY `FK_POSEE` (`PED_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcar la base de datos para la tabla `detalles`
--


-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pedidos`
--

CREATE TABLE IF NOT EXISTS `pedidos` (
  `PED_ID` int(11) NOT NULL,
  `USU_ID` varchar(16) collate utf8_spanish_ci NOT NULL,
  `PED_FECHA` datetime NOT NULL,
  `PED_ESTADO` int(11) default NULL,
  PRIMARY KEY  (`PED_ID`),
  KEY `FK_REALIZA` (`USU_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcar la base de datos para la tabla `pedidos`
--


-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipos_cuenta`
--

CREATE TABLE IF NOT EXISTS `tipos_cuenta` (
  `TIC_ID` int(11) NOT NULL,
  `TIC_NOMBRE` varchar(13) collate utf8_spanish_ci default NULL,
  PRIMARY KEY  (`TIC_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcar la base de datos para la tabla `tipos_cuenta`
--

INSERT INTO `tipos_cuenta` (`TIC_ID`, `TIC_NOMBRE`) VALUES
(1, 'Administrador'),
(2, 'Usuario');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE IF NOT EXISTS `usuarios` (
  `USU_ID` varchar(16) collate utf8_spanish_ci NOT NULL,
  `USU_NOMBRE` varchar(20) collate utf8_spanish_ci NOT NULL,
  `USU_APELLIDO` varchar(20) collate utf8_spanish_ci NOT NULL,
  `USU_DIRECCION` varchar(50) collate utf8_spanish_ci NOT NULL,
  `USU_EMAIL` varchar(35) collate utf8_spanish_ci NOT NULL,
  `USU_CIUDAD` varchar(15) collate utf8_spanish_ci NOT NULL,
  PRIMARY KEY  (`USU_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcar la base de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`USU_ID`, `USU_NOMBRE`, `USU_APELLIDO`, `USU_DIRECCION`, `USU_EMAIL`, `USU_CIUDAD`) VALUES
('Froen', 'Juan', 'Lopez', 'La africana #3232', 'froenmusica@gmail.com', 'Arica'),
('Hume', 'Felipe', 'Hume', 'Nose #1234', 'hume@gmail.com', 'Arica'),
('Nicjergsen', 'Rigoberto', 'Fernandez', 'Jose Diaz Gana #825', 'rnfernandezc@hotmail.com', 'Arica');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `valoraciones`
--

CREATE TABLE IF NOT EXISTS `valoraciones` (
  `VAL_ID` int(11) NOT NULL,
  `COM_ID` int(11) default NULL,
  `USU_ID` varchar(16) collate utf8_spanish_ci default NULL,
  `VAL_PUNTAJE` int(11) NOT NULL,
  PRIMARY KEY  (`VAL_ID`),
  KEY `FK_REALIZAN` (`USU_ID`),
  KEY `FK_TIENEN` (`COM_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcar la base de datos para la tabla `valoraciones`
--


--
-- Filtros para las tablas descargadas (dump)
--

--
-- Filtros para la tabla `cuentas`
--
ALTER TABLE `cuentas`
  ADD CONSTRAINT `FK_CONTIENEN` FOREIGN KEY (`TIC_ID`) REFERENCES `tipos_cuenta` (`TIC_ID`),
  ADD CONSTRAINT `FK_CREAN` FOREIGN KEY (`USU_ID`) REFERENCES `usuarios` (`USU_ID`);

--
-- Filtros para la tabla `detalles`
--
ALTER TABLE `detalles`
  ADD CONSTRAINT `FK_GENERAN` FOREIGN KEY (`COM_ID`) REFERENCES `comics` (`COM_ID`),
  ADD CONSTRAINT `FK_POSEE` FOREIGN KEY (`PED_ID`) REFERENCES `pedidos` (`PED_ID`);

--
-- Filtros para la tabla `pedidos`
--
ALTER TABLE `pedidos`
  ADD CONSTRAINT `FK_REALIZA` FOREIGN KEY (`USU_ID`) REFERENCES `usuarios` (`USU_ID`);

--
-- Filtros para la tabla `valoraciones`
--
ALTER TABLE `valoraciones`
  ADD CONSTRAINT `FK_REALIZAN` FOREIGN KEY (`USU_ID`) REFERENCES `usuarios` (`USU_ID`),
  ADD CONSTRAINT `FK_TIENEN` FOREIGN KEY (`COM_ID`) REFERENCES `comics` (`COM_ID`);
