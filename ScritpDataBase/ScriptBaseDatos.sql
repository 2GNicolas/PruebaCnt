-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema pruebacnt
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema pruebacnt
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `pruebacnt` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `pruebacnt` ;

-- -----------------------------------------------------
-- Table `pruebacnt`.`paciente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `pruebacnt`.`paciente` (
  `numeroDocumento` VARCHAR(45) NOT NULL,
  `nombres` VARCHAR(45) NOT NULL,
  `apellidos` VARCHAR(45) NOT NULL,
  `edad` INT(11) NOT NULL,
  `direccion` VARCHAR(100) NULL DEFAULT NULL,
  `sexo` VARCHAR(2) NULL DEFAULT NULL,
  `peso` DECIMAL(4,2) NOT NULL,
  `estatura` DECIMAL(3,2) NOT NULL,
  `fumador` INT(11) NULL DEFAULT NULL,
  `yearsFumando` INT(11) NULL DEFAULT NULL,
  `dieta` INT(11) NULL DEFAULT NULL,
  `pesoEstatura` INT(11) NULL DEFAULT NULL,
  `prioridad` INT(11) NULL DEFAULT NULL,
  `riesgo` DECIMAL(3,2) NULL DEFAULT NULL,
  PRIMARY KEY (`numeroDocumento`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `pruebacnt`.`estado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `pruebacnt`.`estado` (
  `documento` VARCHAR(45) NULL DEFAULT NULL,
  `estadoPaciente` VARCHAR(100) NULL DEFAULT NULL,
  INDEX `documento` (`documento` ASC) VISIBLE,
  CONSTRAINT `estado_ibfk_1`
    FOREIGN KEY (`documento`)
    REFERENCES `pruebacnt`.`paciente` (`numeroDocumento`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

USE `pruebacnt`;

DELIMITER $$
USE `pruebacnt`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `pruebacnt`.`estado_paciente`
AFTER INSERT ON `pruebacnt`.`paciente`
FOR EACH ROW
begin
	 INSERT INTO estado (documento, estadoPaciente) VALUES (NEW.numeroDocumento , 'Pendiente');
end$$


DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
