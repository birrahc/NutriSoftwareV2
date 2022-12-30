CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    CREATE TABLE `Alimentos` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Nome` longtext CHARACTER SET utf8mb4 NULL,
        `Calorias` DECIMAL(10,2) NULL,
        CONSTRAINT `PK_Alimentos` PRIMARY KEY (`Id`)
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    CREATE TABLE `Nutricionistas` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Nome` longtext CHARACTER SET utf8mb4 NULL,
        `Sexo` int NOT NULL,
        `Nascimento` datetime(6) NOT NULL,
        `CPF` longtext CHARACTER SET utf8mb4 NULL,
        `Email` longtext CHARACTER SET utf8mb4 NULL,
        `Telefone` longtext CHARACTER SET utf8mb4 NULL,
        `TipoDeContatoTelefone` int NULL,
        `CRN` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_Nutricionistas` PRIMARY KEY (`Id`)
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    CREATE TABLE `PACIENTES` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Nome` VARCHAR(60) NOT NULL,
        `Sexo` INT NOT NULL,
        `Nascimento` DATE NOT NULL,
        `CPF` VARCHAR(11) NULL,
        `Email` VARCHAR(40) NULL,
        `Telefone` VARCHAR(11) NULL,
        `TipoDeContatoTelefone` int NULL,
        `AnmineseId` int NOT NULL,
        CONSTRAINT `PK_PACIENTES` PRIMARY KEY (`Id`)
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    CREATE TABLE `Pagamentos` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `ConsultaId` int NOT NULL,
        `TipoDePagamento` int NOT NULL,
        `Data` datetime(6) NOT NULL,
        `DataVencimento` datetime(6) NULL,
        CONSTRAINT `PK_Pagamentos` PRIMARY KEY (`Id`)
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    CREATE TABLE `TipoMedidas` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `NomeTipoMedida` VARCHAR(40) NULL,
        CONSTRAINT `PK_TipoMedidas` PRIMARY KEY (`Id`)
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    CREATE TABLE `Formacoes` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Nome` longtext CHARACTER SET utf8mb4 NULL,
        `NutricionistaId` int NULL,
        CONSTRAINT `PK_Formacoes` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_Formacoes_Nutricionistas_NutricionistaId` FOREIGN KEY (`NutricionistaId`) REFERENCES `Nutricionistas` (`Id`) ON DELETE RESTRICT
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    CREATE TABLE `AGENDA_PACIENTE` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `PacienteId` int NOT NULL,
        `Data` DATE NOT NULL,
        `Horario` varchar(5) NOT NULL,
        `Status` INT NOT NULL,
        CONSTRAINT `PK_AGENDA_PACIENTE` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AGENDA_PACIENTE_PACIENTES_PacienteId` FOREIGN KEY (`PacienteId`) REFERENCES `PACIENTES` (`Id`) ON DELETE CASCADE
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    CREATE TABLE `ANMINESE` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `PacienteId` int NOT NULL,
        `PacienteId1` int NULL,
        CONSTRAINT `PK_ANMINESE` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_ANMINESE_PACIENTES_PacienteId1` FOREIGN KEY (`PacienteId1`) REFERENCES `PACIENTES` (`Id`) ON DELETE RESTRICT
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    CREATE TABLE `AvaliacaoFisica` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `PacienteId` int NOT NULL,
        `NumAvaliacao` int NOT NULL,
        `DataAvaliacao` datetime(6) NOT NULL,
        `Peso` decimal(65,30) NULL,
        `CircCintura` decimal(65,30) NULL,
        `CircAbdominal` decimal(65,30) NULL,
        `CircQuadril` decimal(65,30) NULL,
        `CircPeito` decimal(65,30) NULL,
        `CircBracoDireito` decimal(65,30) NULL,
        `CircBracoEsquerdo` decimal(65,30) NULL,
        `CircCoxadireita` decimal(65,30) NULL,
        `CircCoxaEsquerda` decimal(65,30) NULL,
        `CircPanturrilhaDireita` decimal(65,30) NULL,
        `CircPanturrilhaEsquerda` decimal(65,30) NULL,
        `DCTriceps` decimal(65,30) NULL,
        `DCEscapular` decimal(65,30) NULL,
        `DCSupraIliaca` decimal(65,30) NULL,
        `DCAbdominal` decimal(65,30) NULL,
        `DCAxilar` decimal(65,30) NULL,
        `DCPeitoral` decimal(65,30) NULL,
        `DCCoxa` decimal(65,30) NULL,
        CONSTRAINT `PK_AvaliacaoFisica` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AvaliacaoFisica_PACIENTES_PacienteId` FOREIGN KEY (`PacienteId`) REFERENCES `PACIENTES` (`Id`) ON DELETE CASCADE
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    CREATE TABLE `Consulta` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `PacienteId` int NOT NULL,
        `AvaliacaoId` int NOT NULL,
        CONSTRAINT `PK_Consulta` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_Consulta_AvaliacaoFisica_AvaliacaoId` FOREIGN KEY (`AvaliacaoId`) REFERENCES `AvaliacaoFisica` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_Consulta_PACIENTES_PacienteId` FOREIGN KEY (`PacienteId`) REFERENCES `PACIENTES` (`Id`) ON DELETE CASCADE
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    CREATE INDEX `IX_AGENDA_PACIENTE_PacienteId` ON `AGENDA_PACIENTE` (`PacienteId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    CREATE INDEX `IX_ANMINESE_PacienteId1` ON `ANMINESE` (`PacienteId1`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    CREATE INDEX `IX_AvaliacaoFisica_PacienteId` ON `AvaliacaoFisica` (`PacienteId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    CREATE INDEX `IX_Consulta_AvaliacaoId` ON `Consulta` (`AvaliacaoId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    CREATE INDEX `IX_Consulta_PacienteId` ON `Consulta` (`PacienteId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    CREATE INDEX `IX_Formacoes_NutricionistaId` ON `Formacoes` (`NutricionistaId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221218204609_PrimeiraMigracao') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20221218204609_PrimeiraMigracao', '3.1.5');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221228202036_SegundaMigracao') THEN

    ALTER TABLE `Formacoes` DROP FOREIGN KEY `FK_Formacoes_Nutricionistas_NutricionistaId`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221228202036_SegundaMigracao') THEN

    ALTER TABLE `Pagamentos` ADD `PacienteId` int NOT NULL DEFAULT 0;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221228202036_SegundaMigracao') THEN

    ALTER TABLE `Nutricionistas` MODIFY COLUMN `Sexo` int NULL;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221228202036_SegundaMigracao') THEN

    ALTER TABLE `Formacoes` MODIFY COLUMN `NutricionistaId` int NOT NULL;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221228202036_SegundaMigracao') THEN

    CREATE INDEX `IX_Pagamentos_PacienteId` ON `Pagamentos` (`PacienteId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221228202036_SegundaMigracao') THEN

    ALTER TABLE `Formacoes` ADD CONSTRAINT `FK_Formacoes_Nutricionistas_NutricionistaId` FOREIGN KEY (`NutricionistaId`) REFERENCES `Nutricionistas` (`Id`) ON DELETE CASCADE;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221228202036_SegundaMigracao') THEN

    ALTER TABLE `Pagamentos` ADD CONSTRAINT `FK_Pagamentos_PACIENTES_PacienteId` FOREIGN KEY (`PacienteId`) REFERENCES `PACIENTES` (`Id`) ON DELETE CASCADE;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221228202036_SegundaMigracao') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20221228202036_SegundaMigracao', '3.1.5');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

