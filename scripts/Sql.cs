//CREATE DATABASE IF NOT EXISTS InventarioArmamento;
//USE InventarioArmamento;

//--1.Crear la tabla Armamento primero
//CREATE TABLE Armamento (
//    IdArma INT AUTO_INCREMENT PRIMARY KEY,
//    Tipo VARCHAR(50) NOT NULL,
//    Año INT NOT NULL,
//    Letra CHAR(1) NOT NULL,
//    NSerie VARCHAR(50) UNIQUE NOT NULL,
//    Activo BIT NOT NULL DEFAULT 1
//);

//--2.Crear la tabla Municion antes de usarla como referencia
//CREATE TABLE Municion (
//    IdMunicion INT AUTO_INCREMENT PRIMARY KEY,
//    Tipo VARCHAR(50) NOT NULL,
//    Calibre VARCHAR(20) NOT NULL,
//    CantidadDisponible INT NOT NULL,
//    Activo BIT NOT NULL DEFAULT 1
//);

//--3.Crear las tablas secundarias después de Armamento
//CREATE TABLE DetallesArmamento (
//    IdDetalle INT AUTO_INCREMENT PRIMARY KEY,
//    IdArma INT NULL,
//    NPiston VARCHAR(50) NOT NULL,
//    NCierre VARCHAR(50) NOT NULL,
//    Cargador VARCHAR(50) NOT NULL,
//    Activo BIT NOT NULL DEFAULT 1,
//    FOREIGN KEY (IdArma) REFERENCES Armamento(IdArma) ON DELETE SET NULL
//);

//CREATE TABLE AccesoriosArmamento (
//    IdAccesorio INT AUTO_INCREMENT PRIMARY KEY,
//    IdArma INT NULL,
//    Cajuela VARCHAR(50) NOT NULL,
//    Pechera VARCHAR(50) NOT NULL,
//    Correa VARCHAR(50) NOT NULL,
//    Activo BIT NOT NULL DEFAULT 1,
//    FOREIGN KEY (IdArma) REFERENCES Armamento(IdArma) ON DELETE SET NULL
//);

//--4.Finalmente, crear la tabla intermedia que depende de Armamento y Municion
//CREATE TABLE ArmamentoMunicion (
//    IdArmMun INT AUTO_INCREMENT PRIMARY KEY,
//    IdArma INT NULL,
//    IdMunicion INT NULL,
//    CantidadAsignada INT NOT NULL,
//    Activo BIT NOT NULL DEFAULT 1,
//    FOREIGN KEY (IdArma) REFERENCES Armamento(IdArma) ON DELETE SET NULL,
//    FOREIGN KEY (IdMunicion) REFERENCES Municion(IdMunicion) ON DELETE SET NULL
//);



//CREATE VIEW vArmamento AS
//SELECT 
//    IdArma, Tipo, Año, Letra, NSerie, Activo
//FROM Armamento
//WHERE Activo = 1;

//CREATE VIEW vMunicion AS
//SELECT 
//    IdMunicion, Tipo, Calibre, CantidadDisponible, Activo
//FROM Municion
//WHERE Activo = 1;

//CREATE VIEW vDetallesArmamento AS
//SELECT 
//    da.IdDetalle, a.IdArma, a.Tipo AS TipoArmamento, a.NSerie,
//    da.NPiston, da.NCierre, da.Cargador, da.Activo
//FROM DetallesArmamento da
//LEFT JOIN Armamento a ON da.IdArma = a.IdArma
//WHERE da.Activo = 1;

//CREATE VIEW vAccesoriosArmamento AS
//SELECT 
//    aa.IdAccesorio, a.IdArma, a.Tipo AS TipoArmamento, a.NSerie,
//    aa.Cajuela, aa.Pechera, aa.Correa, aa.Activo
//FROM AccesoriosArmamento aa
//LEFT JOIN Armamento a ON aa.IdArma = a.IdArma
//WHERE aa.Activo = 1;

//CREATE VIEW vArmamentoMunicion AS
//SELECT 
//    am.IdArmMun,
//    a.IdArma, a.Tipo AS TipoArmamento, a.NSerie,
//    m.IdMunicion, m.Tipo AS TipoMunicion, m.Calibre,
//    am.CantidadAsignada, am.Activo
//FROM ArmamentoMunicion am
//LEFT JOIN Armamento a ON am.IdArma = a.IdArma
//LEFT JOIN Municion m ON am.IdMunicion = m.IdMunicion
//WHERE am.Activo = 1;