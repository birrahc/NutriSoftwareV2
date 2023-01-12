CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE TABLE `Dietas` (
        `CodigoDieta` VARCHAR(50) NOT NULL,
        `Anotacoes` TEXT NULL,
        CONSTRAINT `PK_Dietas` PRIMARY KEY (`CodigoDieta`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE TABLE `Nutricionistas` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Nome` longtext CHARACTER SET utf8mb4 NULL,
        `Sexo` int NULL,
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE TABLE `HoraAlimentos` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `CodigoDieta` VARCHAR(50) NOT NULL,
        `Hora` VARCHAR(5) NOT NULL,
        `Observacao` TEXT NOT NULL,
        CONSTRAINT `PK_HoraAlimentos` PRIMARY KEY (`Id`, `CodigoDieta`),
        CONSTRAINT `FK_HoraAlimentos_Dietas_CodigoDieta` FOREIGN KEY (`CodigoDieta`) REFERENCES `Dietas` (`CodigoDieta`) ON DELETE CASCADE
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE TABLE `Formacoes` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Nome` longtext CHARACTER SET utf8mb4 NULL,
        `NutricionistaId` int NOT NULL,
        CONSTRAINT `PK_Formacoes` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_Formacoes_Nutricionistas_NutricionistaId` FOREIGN KEY (`NutricionistaId`) REFERENCES `Nutricionistas` (`Id`) ON DELETE CASCADE
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE TABLE `AnotacosPaciente` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `PacienteId` int NOT NULL,
        `Data` datetime(6) NULL,
        `Titulo` longtext CHARACTER SET utf8mb4 NULL,
        `Anotacoes` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_AnotacosPaciente` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AnotacosPaciente_PACIENTES_PacienteId` FOREIGN KEY (`PacienteId`) REFERENCES `PACIENTES` (`Id`) ON DELETE CASCADE
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE TABLE `AvaliacaoFisica` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `PacienteId` int NOT NULL,
        `NumAvaliacao` int NOT NULL,
        `DataAvaliacao` datetime(6) NOT NULL,
        `Peso` double NULL,
        `CircCintura` double NULL,
        `CircAbdominal` double NULL,
        `CircQuadril` double NULL,
        `CircPeito` double NULL,
        `CircBracoDireito` double NULL,
        `CircBracoEsquerdo` double NULL,
        `CircCoxadireita` double NULL,
        `CircCoxaEsquerda` double NULL,
        `CircPanturrilhaDireita` double NULL,
        `CircPanturrilhaEsquerda` double NULL,
        `DCTriceps` double NULL,
        `DCEscapular` double NULL,
        `DCSupraIliaca` double NULL,
        `DCAbdominal` double NULL,
        `DCAxilar` double NULL,
        `DCPeitoral` double NULL,
        `DCCoxa` double NULL,
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE TABLE `Pagamentos` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `ConsultaId` int NOT NULL,
        `TipoDePagamento` int NOT NULL,
        `Data` datetime(6) NOT NULL,
        `DataVencimento` datetime(6) NULL,
        `PacienteId` int NOT NULL,
        CONSTRAINT `PK_Pagamentos` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_Pagamentos_PACIENTES_PacienteId` FOREIGN KEY (`PacienteId`) REFERENCES `PACIENTES` (`Id`) ON DELETE CASCADE
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE TABLE `QuantidadeAlimento` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `CodigoDieta` VARCHAR(50) NOT NULL,
        `AlimentoId` int NOT NULL,
        `TipoMedidaId` int NOT NULL,
        `quantidade` decimal(65,30) NOT NULL,
        `HoraAlimentosCodigoDieta` VARCHAR(50) NULL,
        `HoraAlimentosId` int NULL,
        CONSTRAINT `PK_QuantidadeAlimento` PRIMARY KEY (`Id`, `CodigoDieta`),
        CONSTRAINT `FK_QuantidadeAlimento_Alimentos_AlimentoId` FOREIGN KEY (`AlimentoId`) REFERENCES `Alimentos` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_QuantidadeAlimento_Dietas_CodigoDieta` FOREIGN KEY (`CodigoDieta`) REFERENCES `Dietas` (`CodigoDieta`) ON DELETE CASCADE,
        CONSTRAINT `FK_QuantidadeAlimento_TipoMedidas_TipoMedidaId` FOREIGN KEY (`TipoMedidaId`) REFERENCES `TipoMedidas` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_QuantidadeAlimento_HoraAlimentos_HoraAlimentosId_HoraAliment~` FOREIGN KEY (`HoraAlimentosId`, `HoraAlimentosCodigoDieta`) REFERENCES `HoraAlimentos` (`Id`, `CodigoDieta`) ON DELETE RESTRICT
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE TABLE `Consulta` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `NutricionistaId` int NOT NULL,
        `PacienteId` int NOT NULL,
        `AvaliacaoId` int NULL,
        `DietaId` VARCHAR(50) NULL,
        `PagamentoId` int NULL,
        `DataConsulta` datetime(6) NOT NULL,
        `Observacoes` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_Consulta` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_Consulta_AvaliacaoFisica_AvaliacaoId` FOREIGN KEY (`AvaliacaoId`) REFERENCES `AvaliacaoFisica` (`Id`) ON DELETE RESTRICT,
        CONSTRAINT `FK_Consulta_Dietas_DietaId` FOREIGN KEY (`DietaId`) REFERENCES `Dietas` (`CodigoDieta`) ON DELETE RESTRICT,
        CONSTRAINT `FK_Consulta_Nutricionistas_NutricionistaId` FOREIGN KEY (`NutricionistaId`) REFERENCES `Nutricionistas` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_Consulta_PACIENTES_PacienteId` FOREIGN KEY (`PacienteId`) REFERENCES `PACIENTES` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_Consulta_Pagamentos_PagamentoId` FOREIGN KEY (`PagamentoId`) REFERENCES `Pagamentos` (`Id`) ON DELETE RESTRICT
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE INDEX `IX_AnotacosPaciente_PacienteId` ON `AnotacosPaciente` (`PacienteId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE UNIQUE INDEX `IX_Consulta_DietaId` ON `Consulta` (`DietaId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE INDEX `IX_Consulta_NutricionistaId` ON `Consulta` (`NutricionistaId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE INDEX `IX_Consulta_PagamentoId` ON `Consulta` (`PagamentoId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE INDEX `IX_HoraAlimentos_CodigoDieta` ON `HoraAlimentos` (`CodigoDieta`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE INDEX `IX_QuantidadeAlimento_AlimentoId` ON `QuantidadeAlimento` (`AlimentoId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE INDEX `IX_QuantidadeAlimento_CodigoDieta` ON `QuantidadeAlimento` (`CodigoDieta`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE INDEX `IX_QuantidadeAlimento_TipoMedidaId` ON `QuantidadeAlimento` (`TipoMedidaId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    CREATE INDEX `IX_QuantidadeAlimento_HoraAlimentosId_HoraAlimentosCodigoDieta` ON `QuantidadeAlimento` (`HoraAlimentosId`, `HoraAlimentosCodigoDieta`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230112014128_primeiraMigracao') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230112014128_primeiraMigracao', '3.1.5');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

