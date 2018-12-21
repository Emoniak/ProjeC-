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
CREATE TABLE IF NOT EXISTS `db_garage`.`tcategorie` (
  `ID_CATEGORIE` INT(11) NOT NULL AUTO_INCREMENT,
  `NOM_CATEGORIE` VARCHAR(42) NOT NULL,
  PRIMARY KEY (`ID_CATEGORIE`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `db_garage`.`tclient`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_garage`.`tclient` (
  `ID_CLIENT` INT(11) NOT NULL AUTO_INCREMENT,
  `NOM_CLIENT` VARCHAR(42) NOT NULL,
  `ISPHYSIQUE` TINYINT(1) NOT NULL,
  `TEL` VARCHAR(42) NULL DEFAULT NULL,
  `MAIL` VARCHAR(42) NULL DEFAULT NULL,
  PRIMARY KEY (`ID_CLIENT`))
ENGINE = InnoDB
AUTO_INCREMENT = 46
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `db_garage`.`tdevis`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_garage`.`tdevis` (
  `ID_DEVIS` INT(11) NOT NULL AUTO_INCREMENT,
  `ID_CLIENT` INT(11) NOT NULL,
  `PRIX_DEVIS` FLOAT(8,2) NOT NULL,
  `Date_Devis` DATETIME NOT NULL,
  PRIMARY KEY (`ID_DEVIS`),
  CONSTRAINT `FK_DEVIS_CLIENT`
    FOREIGN KEY (`ID_CLIENT`)
    REFERENCES `db_garage`.`tclient` (`ID_CLIENT`))
ENGINE = InnoDB
AUTO_INCREMENT = 15
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `db_garage`.`tfacture`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_garage`.`tfacture` (
  `ID_FACTURE` INT(11) NOT NULL AUTO_INCREMENT,
  `ID_DEVIS` INT(11) NOT NULL,
  `DATE_FACTURE` DATETIME NOT NULL,
  PRIMARY KEY (`ID_FACTURE`),
  CONSTRAINT `FK_DEVIS_FACTURE`
    FOREIGN KEY (`ID_DEVIS`)
    REFERENCES `db_garage`.`tdevis` (`ID_DEVIS`))
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `db_garage`.`tmarque`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_garage`.`tmarque` (
  `ID_MARQUE` INT(11) NOT NULL AUTO_INCREMENT,
  `NOM_MARQUE` VARCHAR(42) NOT NULL,
  PRIMARY KEY (`ID_MARQUE`))
ENGINE = InnoDB
AUTO_INCREMENT = 217
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `db_garage`.`tmodel`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_garage`.`tmodel` (
  `ID_MODEL` INT(11) NOT NULL AUTO_INCREMENT,
  `ID_MARQUE` INT(11) NOT NULL,
  `NOM_MODEL` VARCHAR(42) NOT NULL,
  `ID_Categorie` INT(11) NOT NULL,
  PRIMARY KEY (`ID_MODEL`),
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
AUTO_INCREMENT = 1468
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `db_garage`.`toption`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_garage`.`toption` (
  `ID_OPTION` INT(11) NOT NULL AUTO_INCREMENT,
  `NOM_OPTION` VARCHAR(42) NOT NULL,
  `caracteristique` VARCHAR(255) NOT NULL,
  `prix` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`ID_OPTION`))
ENGINE = InnoDB
AUTO_INCREMENT = 1401
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `db_garage`.`toption_has_tmodel`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_garage`.`toption_has_tmodel` (
  `ID_OPTION` INT(11) NOT NULL,
  `ID_MODEL` INT(11) NOT NULL,
  `version` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`ID_MODEL`, `ID_OPTION`),
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
CREATE TABLE IF NOT EXISTS `db_garage`.`tvehicule` (
  `ID_VEHICULE` INT(11) NOT NULL AUTO_INCREMENT,
  `ID_DEVIS` INT(11) NULL DEFAULT NULL,
  `ID_CLIENT` INT(11) NOT NULL,
  `ID_MODEL` INT(11) NOT NULL,
  `PLAQUE` CHAR(9) NULL DEFAULT NULL,
  PRIMARY KEY (`ID_VEHICULE`),
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
AUTO_INCREMENT = 10
DEFAULT CHARACTER SET = latin1;

USE `db_garage` ;

-- -----------------------------------------------------
-- procedure CreationFacture
-- -----------------------------------------------------

DELIMITER $$
USE `db_garage`$$
CREATE DEFINER=`AdminGarage`@`%` PROCEDURE `CreationFacture`(
	IN `fkDevis` INT,
	IN `ParamDate` DATETIME

)
BEGIN
	insert into tfacture(id_devis,date_facture)
	values(fkDevis,ParamDate);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure CreationVehicule
-- -----------------------------------------------------

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

DELIMITER $$
USE `db_garage`$$
CREATE DEFINER=`AdminGarage`@`%` PROCEDURE `choisirOption`(in fkoption int, in fkmodel int, in version int)
BEGIN
	insert into toption_has_tmodel
		values(fkoption,fkmodel,version);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure createClient
-- -----------------------------------------------------

DELIMITER $$
USE `db_garage`$$
CREATE DEFINER=`AdminGarage`@`%` PROCEDURE `createClient`(
	IN `paramNom` VARCHAR(42)
,
	IN `ParamTel` VARCHAR(42),
	IN `ParamMail` VARCHAR(42)

)
BEGIN	insert into tclient (Nom_client,tel,mail,ISPHYSIQUE)

		values(paramNom,ParamTel,ParamMail,1);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure creationDevis
-- -----------------------------------------------------

DELIMITER $$
USE `db_garage`$$
CREATE DEFINER=`AdminGarage`@`%` PROCEDURE `creationDevis`(
	IN `idcli` INT,
	IN `fkprix` FLOAT,
	IN `paramDate` DATETIME
)
BEGIN
	insert into tdevis(ID_Client,Prix_devis,date_devis)
	values(idcli,fkprix,paramDate);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure insertModel
-- -----------------------------------------------------

DELIMITER $$
USE `db_garage`$$
CREATE DEFINER=`AdminGarage`@`%` PROCEDURE `insertModel`(in marque int,in nom varchar(42),in categorie int)
BEGIN
	insert into tmodel(ID_marque,Nom_Model,ID_Categorie)
		values(marque,nom,categorie);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sortiUsine
-- -----------------------------------------------------

DELIMITER $$
USE `db_garage`$$
CREATE DEFINER=`AdminGarage`@`%` PROCEDURE `sortiUsine`(
	IN `fkclient` INT,
	IN `paramvehicule` INT,
	IN `paramplaque` CHAR(9)
)
BEGIN
	update tvehicule set plaque=paramplaque, id_client=fkclient 
	where id_vehicule=paramvehicule;
END$$

DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
