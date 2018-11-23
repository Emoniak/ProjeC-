-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema db_garage
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema db_garage
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `db_garage` DEFAULT CHARACTER SET latin1 ;
USE `db_garage` ;

-- -----------------------------------------------------
-- Table `db_garage`.`tcategorie`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_garage`.`tcategorie` ;

CREATE TABLE IF NOT EXISTS `db_garage`.`tcategorie` (
  `ID_CATEGORIE` INT(11) NOT NULL AUTO_INCREMENT,
  `NOM_CATEGORIE` VARCHAR(42) NOT NULL,
  PRIMARY KEY (`ID_CATEGORIE`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `db_garage`.`tclient`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_garage`.`tclient` ;

CREATE TABLE IF NOT EXISTS `db_garage`.`tclient` (
  `ID_CLIENT` INT(11) NOT NULL AUTO_INCREMENT,
  `NOM_CLIENT` VARCHAR(42) NOT NULL,
  `ISPHYSIQUE` TINYINT(1) NOT NULL,
  `TEL` VARCHAR(42) NULL DEFAULT NULL,
  `MAIL` VARCHAR(42) NULL DEFAULT NULL,
  PRIMARY KEY (`ID_CLIENT`))
ENGINE = InnoDB
AUTO_INCREMENT = 22
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `db_garage`.`tdevis`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_garage`.`tdevis` ;

CREATE TABLE IF NOT EXISTS `db_garage`.`tdevis` (
  `ID_DEVIS` INT(11) NOT NULL AUTO_INCREMENT,
  `ID_CLIENT` INT(11) NOT NULL,
  `PRIX_DEVIS` FLOAT(8,2) NOT NULL,
  `Date_Devis` DATETIME NOT NULL,
  PRIMARY KEY (`ID_DEVIS`),
  INDEX `DEVIS_CLIENT_FK` (`ID_CLIENT` ASC) VISIBLE,
  CONSTRAINT `FK_DEVIS_CLIENT`
    FOREIGN KEY (`ID_CLIENT`)
    REFERENCES `db_garage`.`tclient` (`ID_CLIENT`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `db_garage`.`tfacture`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_garage`.`tfacture` ;

CREATE TABLE IF NOT EXISTS `db_garage`.`tfacture` (
  `ID_FACTURE` INT(11) NOT NULL AUTO_INCREMENT,
  `ID_DEVIS` INT(11) NOT NULL,
  `DATE_FACTURE` DATETIME NOT NULL,
  PRIMARY KEY (`ID_FACTURE`),
  INDEX `DEVIS_FACTURE_FK` (`ID_DEVIS` ASC),
  CONSTRAINT `FK_DEVIS_FACTURE`
    FOREIGN KEY (`ID_DEVIS`)
    REFERENCES `db_garage`.`tdevis` (`ID_DEVIS`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `db_garage`.`tmarque`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_garage`.`tmarque` ;

CREATE TABLE IF NOT EXISTS `db_garage`.`tmarque` (
  `ID_MARQUE` INT(11) NOT NULL AUTO_INCREMENT,
  `NOM_MARQUE` VARCHAR(42) NOT NULL,
  PRIMARY KEY (`ID_MARQUE`))
ENGINE = InnoDB
AUTO_INCREMENT = 200
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `db_garage`.`tmodel`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_garage`.`tmodel` ;

CREATE TABLE IF NOT EXISTS `db_garage`.`tmodel` (
  `ID_MODEL` INT(11) NOT NULL AUTO_INCREMENT,
  `ID_MARQUE` INT(11) NOT NULL,
  `NOM_MODEL` VARCHAR(42) NOT NULL,
  `ID_Categorie` INT(11) NOT NULL,
  PRIMARY KEY (`ID_MODEL`),
  INDEX `fk_tmodel_tmarque1_idx` (`ID_MARQUE` ASC),
  INDEX `fk_tmodel_tcategorie1_idx` (`ID_Categorie` ASC),
  CONSTRAINT `fk_tmodel_tcategorie1`
    FOREIGN KEY (`ID_Categorie`)
    REFERENCES `db_garage`.`tcategorie` (`ID_CATEGORIE`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tmodel_tmarque1`
    FOREIGN KEY (`ID_MARQUE`)
    REFERENCES `db_garage`.`tmarque` (`ID_MARQUE`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 1138
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `db_garage`.`toption`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_garage`.`toption` ;

CREATE TABLE IF NOT EXISTS `db_garage`.`toption` (
  `ID_OPTION` INT(11) NOT NULL AUTO_INCREMENT,
  `NOM_OPTION` VARCHAR(42) NOT NULL,
  `caracteristique` VARCHAR(255) NOT NULL,
  `prix` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`ID_OPTION`))
ENGINE = InnoDB
AUTO_INCREMENT = 1050
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `db_garage`.`toption_has_tmodel`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_garage`.`toption_has_tmodel` ;

CREATE TABLE IF NOT EXISTS `db_garage`.`toption_has_tmodel` (
  `ID_OPTION` INT(11) NOT NULL,
  `ID_MODEL` INT(11) NOT NULL,
  `version` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`ID_MODEL`, `ID_OPTION`),
  INDEX `fk_toption_has_tmodel_tmodel1_idx` (`ID_MODEL` ASC),
  INDEX `fk_toption_has_tmodel_toption1_idx` (`ID_OPTION` ASC),
  CONSTRAINT `fk_toption_has_tmodel_tmodel1`
    FOREIGN KEY (`ID_MODEL`)
    REFERENCES `db_garage`.`tmodel` (`ID_MODEL`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_toption_has_tmodel_toption1`
    FOREIGN KEY (`ID_OPTION`)
    REFERENCES `db_garage`.`toption` (`ID_OPTION`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `db_garage`.`tvehicule`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_garage`.`tvehicule` ;

CREATE TABLE IF NOT EXISTS `db_garage`.`tvehicule` (
  `ID_VEHICULE` INT(11) NOT NULL AUTO_INCREMENT,
  `ID_DEVIS` INT(11) NULL DEFAULT NULL,
  `ID_CLIENT` INT(11) NOT NULL,
  `ID_MODEL` INT(11) NOT NULL,
  `PLAQUE` CHAR(9) NULL DEFAULT NULL,
  PRIMARY KEY (`ID_VEHICULE`),
  INDEX `VEHICULE_CLIENT_FK` (`ID_CLIENT` ASC),
  INDEX `VEHICULE_DEVIS_FK` (`ID_DEVIS` ASC),
  INDEX `fk_tvehicule_tmodel1_idx` (`ID_MODEL` ASC),
  CONSTRAINT `FK_VEHICULE_CLIENT`
    FOREIGN KEY (`ID_CLIENT`)
    REFERENCES `db_garage`.`tclient` (`ID_CLIENT`),
  CONSTRAINT `FK_VEHICULE_DEVIS`
    FOREIGN KEY (`ID_DEVIS`)
    REFERENCES `db_garage`.`tdevis` (`ID_DEVIS`),
  CONSTRAINT `fk_tvehicule_tmodel1`
    FOREIGN KEY (`ID_MODEL`)
    REFERENCES `db_garage`.`tmodel` (`ID_MODEL`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;

USE `db_garage` ;

-- -----------------------------------------------------
-- procedure CreationVehicule
-- -----------------------------------------------------

USE `db_garage`;
DROP procedure IF EXISTS `db_garage`.`CreationVehicule`;

DELIMITER $$
USE `db_garage`$$
CREATE DEFINER=`AdminGarage`@`%` PROCEDURE `CreationVehicule`(in devis int,in usine int,in model int)
BEGIN
	insert into tvehicule (id_devis,id_client,id_model)
    values(devis,usine,model);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure InsertCategorie
-- -----------------------------------------------------

USE `db_garage`;
DROP procedure IF EXISTS `db_garage`.`InsertCategorie`;

DELIMITER $$
USE `db_garage`$$
CREATE DEFINER=`AdminGarage`@`%` PROCEDURE `InsertCategorie`(in nom varchar(42))
BEGIN
	INSERT INTO tcategorie(Nom_categorie) 
		VALUES (nom);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure InsertEntreprise
-- -----------------------------------------------------

USE `db_garage`;
DROP procedure IF EXISTS `db_garage`.`InsertEntreprise`;

DELIMITER $$
USE `db_garage`$$
CREATE DEFINER=`AdminGarage`@`%` PROCEDURE `InsertEntreprise`(in nom varchar(36))
BEGIN
Set @usine = CONCAT('usine ',nom);
	insert into tclient (NOM_CLIENT,isphysique)
    values(@usine,0);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure InsertMarque
-- -----------------------------------------------------

USE `db_garage`;
DROP procedure IF EXISTS `db_garage`.`InsertMarque`;

DELIMITER $$
USE `db_garage`$$
CREATE DEFINER=`AdminGarage`@`%` PROCEDURE `InsertMarque`(in nom varchar(42))
BEGIN
	INSERT INTO tmarque(Nom_Marque) 
		VALUES (nom);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure InsertOption
-- -----------------------------------------------------

USE `db_garage`;
DROP procedure IF EXISTS `db_garage`.`InsertOption`;

DELIMITER $$
USE `db_garage`$$
CREATE DEFINER=`AdminGarage`@`%` PROCEDURE `InsertOption`(in nomOption varchar(42),in carc varchar(255),in prixpara int)
BEGIN
	insert into toption(Nom_Option,caracteristique,prix)
		values(nomOption,carc,prixpara);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure choisirOption
-- -----------------------------------------------------

USE `db_garage`;
DROP procedure IF EXISTS `db_garage`.`choisirOption`;

DELIMITER $$
USE `db_garage`$$
CREATE DEFINER=`AdminGarage`@`%` PROCEDURE `choisirOption`(in fkoption int, in fkmodel int, in version int)
BEGIN
	insert into toption_has_tmodel
		values(fkoption,fkmodel,version);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure insertModel
-- -----------------------------------------------------

USE `db_garage`;
DROP procedure IF EXISTS `db_garage`.`insertModel`;

DELIMITER $$
USE `db_garage`$$
CREATE DEFINER=`AdminGarage`@`%` PROCEDURE `insertModel`(in marque int,in nom varchar(42),in categorie int)
BEGIN
	insert into tmodel(ID_marque,Nom_Model,ID_Categorie)
		values(marque,nom,categorie);
END$$

DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
