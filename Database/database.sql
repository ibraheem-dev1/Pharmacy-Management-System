-----------------------------------------
-- CREATE DATABASE
-----------------------------------------
IF DB_ID('PharmacyDB') IS NULL
    CREATE DATABASE PharmacyDB;
GO

USE PharmacyDB;
GO

-----------------------------------------
-- 1. ROLE
-----------------------------------------
CREATE TABLE Role (
    RoleID      INT IDENTITY(1,1) PRIMARY KEY,
    RoleName    VARCHAR(50) NOT NULL
);
GO

-----------------------------------------
-- 2. CATEGORY
-----------------------------------------
CREATE TABLE Category (
    CategoryID      INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName    VARCHAR(100) NOT NULL
);
GO

-----------------------------------------
-- 3. MANUFACTURER
-----------------------------------------
CREATE TABLE Manufacturer (
    ManufacturerID      INT IDENTITY(1,1) PRIMARY KEY,
    ManufacturerName    VARCHAR(150) NOT NULL
);
GO

-----------------------------------------
-- 4. FORMULA
-----------------------------------------
CREATE TABLE Formula (
    FormulaID       INT IDENTITY(1,1) PRIMARY KEY,
    FormulaName     VARCHAR(150) NOT NULL
);
GO

-----------------------------------------
-- 5. CUSTOMER
-----------------------------------------
CREATE TABLE Customer (
    CustomerID  INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(150) NOT NULL,
    ContactNo   VARCHAR(50),
    Address     VARCHAR(250)
);
GO

-----------------------------------------
-- 6. USER  (uses square brackets because USER is reserved)
-----------------------------------------
CREATE TABLE [User] (
    UserID          INT IDENTITY(1,1) PRIMARY KEY,
    UserName        VARCHAR(100) NOT NULL,
    PasswordHash    VARCHAR(255) NOT NULL,
    RoleID          INT NOT NULL,
    CONSTRAINT FK_User_Role
        FOREIGN KEY (RoleID) REFERENCES Role(RoleID)
);
GO

-----------------------------------------
-- 7. SUPPLIER
-----------------------------------------
CREATE TABLE Supplier (
    SupplierID      INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName    VARCHAR(150) NOT NULL,
    Contact         VARCHAR(100),
    Address         VARCHAR(250)
);
GO

-----------------------------------------
-- 8. MEDICINE
-----------------------------------------
CREATE TABLE Medicine (
    MedicineID              INT IDENTITY(1,1) PRIMARY KEY,
    Name                    VARCHAR(150) NOT NULL,
    StrengthMG              INT NOT NULL,
    MinimumStockLevel       INT NOT NULL,
    IsPrescriptionRequired  BIT NOT NULL DEFAULT 0,
    IsActive                BIT NOT NULL DEFAULT 1,
    CategoryID              INT NOT NULL,
    ManufacturerID          INT NOT NULL,
    FormulaID               INT NOT NULL,

    CONSTRAINT FK_Medicine_Category
        FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID),
    CONSTRAINT FK_Medicine_Manufacturer
        FOREIGN KEY (ManufacturerID) REFERENCES Manufacturer(ManufacturerID),
    CONSTRAINT FK_Medicine_Formula
        FOREIGN KEY (FormulaID) REFERENCES Formula(FormulaID)
);
GO

-----------------------------------------
-- 9. SUPPLIER–MEDICINE (junction)
-----------------------------------------
CREATE TABLE SupplierMedicine (
    SupplierID  INT NOT NULL,
    MedicineID  INT NOT NULL,
    CONSTRAINT PK_SupplierMedicine PRIMARY KEY (SupplierID, MedicineID),

    CONSTRAINT FK_SupplierMedicine_Supplier
        FOREIGN KEY (SupplierID) REFERENCES Supplier(SupplierID),
    CONSTRAINT FK_SupplierMedicine_Medicine
        FOREIGN KEY (MedicineID) REFERENCES Medicine(MedicineID)
);
GO

-----------------------------------------
-- 10. PURCHASE (header)
-----------------------------------------
CREATE TABLE Purchase (
    PurchaseID      INT IDENTITY(1,1) PRIMARY KEY,
    SupplierID      INT NOT NULL,
    UserID          INT NOT NULL,
    PurchaseDate    DATE NOT NULL,
    TotalAmount     DECIMAL(10,2) NULL,

    CONSTRAINT FK_Purchase_Supplier
        FOREIGN KEY (SupplierID) REFERENCES Supplier(SupplierID),
    CONSTRAINT FK_Purchase_User
        FOREIGN KEY (UserID) REFERENCES [User](UserID)
);
GO

-----------------------------------------
-- 11. MEDICINE BATCH (inventory per batch)
-----------------------------------------
CREATE TABLE MedicineBatch (
    BatchID         INT IDENTITY(1,1) PRIMARY KEY,
    MedicineID      INT NOT NULL,
    SupplierID      INT NOT NULL,
    PurchaseID      INT NOT NULL,
    BatchNumber     VARCHAR(100) NULL,
    ExpiryDate      DATE NOT NULL,
    PurchasePrice   DECIMAL(10,2) NOT NULL,
    QuantityInStock INT NOT NULL,

    CONSTRAINT FK_MedicineBatch_Medicine
        FOREIGN KEY (MedicineID) REFERENCES Medicine(MedicineID),
    CONSTRAINT FK_MedicineBatch_Supplier
        FOREIGN KEY (SupplierID) REFERENCES Supplier(SupplierID),
    CONSTRAINT FK_MedicineBatch_Purchase
        FOREIGN KEY (PurchaseID) REFERENCES Purchase(PurchaseID)
);
GO

-----------------------------------------
-- 12. PRESCRIPTION (header)
-----------------------------------------
CREATE TABLE Prescription (
    PrescriptionID      INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID          INT NOT NULL,
    DoctorName          VARCHAR(150) NOT NULL,
    PrescriptionDate    DATE NOT NULL,
    Notes               VARCHAR(500) NULL,

    CONSTRAINT FK_Prescription_Customer
        FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);
GO

-----------------------------------------
-- 13. PRESCRIPTION DETAIL
-----------------------------------------
CREATE TABLE PrescriptionDetail (
    PrescriptionID  INT NOT NULL,
    MedicineID      INT NOT NULL,
    Dosage          VARCHAR(100) NOT NULL,
    Frequency       VARCHAR(100) NOT NULL,
    DurationDays    INT NOT NULL,

    CONSTRAINT PK_PrescriptionDetail
        PRIMARY KEY (PrescriptionID, MedicineID),

    CONSTRAINT FK_PrescriptionDetail_Prescription
        FOREIGN KEY (PrescriptionID) REFERENCES Prescription(PrescriptionID),
    CONSTRAINT FK_PrescriptionDetail_Medicine
        FOREIGN KEY (MedicineID) REFERENCES Medicine(MedicineID)
);
GO

-----------------------------------------
-- 14. SALE (header)
-----------------------------------------
CREATE TABLE Sale (
    SaleID          INT IDENTITY(1,1) PRIMARY KEY,
    UserID          INT NOT NULL,
    CustomerID      INT NULL,
    PrescriptionID  INT NULL,
    SaleDate        DATE NOT NULL,
    TotalAmount     DECIMAL(10,2) NULL,

    CONSTRAINT FK_Sale_User
        FOREIGN KEY (UserID) REFERENCES [User](UserID),
    CONSTRAINT FK_Sale_Customer
        FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    CONSTRAINT FK_Sale_Prescription
        FOREIGN KEY (PrescriptionID) REFERENCES Prescription(PrescriptionID)
);
GO

-----------------------------------------
-- 15. SALE DETAIL (batch-based)
-----------------------------------------
CREATE TABLE SaleDetail (
    SaleID          INT NOT NULL,
    BatchID         INT NOT NULL,
    QuantitySold    INT NOT NULL,
    SellingPrice    DECIMAL(10,2) NOT NULL,

    CONSTRAINT PK_SaleDetail PRIMARY KEY (SaleID, BatchID),

    CONSTRAINT FK_SaleDetail_Sale
        FOREIGN KEY (SaleID) REFERENCES Sale(SaleID),
    CONSTRAINT FK_SaleDetail_Batch
        FOREIGN KEY (BatchID) REFERENCES MedicineBatch(BatchID)
);
GO

USE PharmacyDB;
GO

--------------------------------------------------
-- 1. ROLES
--------------------------------------------------
INSERT INTO Role (RoleName) VALUES
('Manager'),
('SalesMan'),
('Admin');


--------------------------------------------------
-- 2. USER
--------------------------------------------------
INSERT INTO [User] (UserName, PasswordHash, RoleID) VALUES
('Manager', 'manager123', 1),
('Salesman', 'salesman123', 2);

--------------------------------------------------
-- 3. CATEGORY
--------------------------------------------------
INSERT INTO Category (CategoryName) VALUES
('Tablet'),
('Capsule'),
('Syrup'),
('Injection');

--------------------------------------------------
-- 4. MANUFACTURER
--------------------------------------------------
INSERT INTO Manufacturer (ManufacturerName) VALUES
('GSK'),
('Pfizer'),
('Abbott'),
('Sanofi');

--------------------------------------------------
-- 5. FORMULA
--------------------------------------------------
INSERT INTO Formula (FormulaName) VALUES
('Paracetamol'),
('Ibuprofen'),
('Amoxicillin'),
('Omeprazole');

--------------------------------------------------
-- 6. CUSTOMERS
--------------------------------------------------
INSERT INTO Customer (CustomerName, ContactNo, Address) VALUES
('Ali Khan', '0300-1234567', 'Lahore'),
('Sara Ahmed', '0333-9876543', 'Karachi');

--------------------------------------------------
-- 7. SUPPLIERS
--------------------------------------------------
INSERT INTO Supplier (SupplierName, Contact, Address) VALUES
('HealthPlus Distributors', '0300-9990000', 'Lahore'),
('Medico Supplies', '0321-2223344', 'Karachi');

--------------------------------------------------
-- 8. MEDICINES
--------------------------------------------------
INSERT INTO Medicine
(Name, StrengthMG, MinimumStockLevel, IsPrescriptionRequired, IsActive, CategoryID, ManufacturerID, FormulaID)
VALUES
('Panadol', 500, 20, 0, 1, 1, 1, 1),    -- Tablet, GSK, Paracetamol
('Brufen', 400, 15, 0, 1, 1, 2, 2),     -- Tablet, Pfizer, Ibuprofen
('Augmentin', 625, 10, 1, 1, 1, 3, 3),  -- Prescription Required
('Losec', 40, 5, 0, 1, 1, 4, 4);        -- Omeprazole

--------------------------------------------------
-- 9. SUPPLIER-MEDICINE LINKS
--------------------------------------------------
INSERT INTO SupplierMedicine (SupplierID, MedicineID) VALUES
(1, 1),
(1, 3),
(2, 2),
(2, 4);

--------------------------------------------------
-- 10. PURCHASE RECORDS
--------------------------------------------------
INSERT INTO Purchase (SupplierID, UserID, PurchaseDate, TotalAmount)
VALUES
(1, 1, '2025-01-10', NULL),
(2, 1, '2025-01-15', NULL);

-- Capture Purchase IDs (assume they are 1 and 2)
--------------------------------------------------
-- 11. BATCHES (INVENTORY)
--------------------------------------------------
INSERT INTO MedicineBatch
(MedicineID, SupplierID, PurchaseID, BatchNumber, ExpiryDate, PurchasePrice, QuantityInStock)
VALUES
-- Purchase 1 from Supplier 1
(1, 1, 1, 'PAN-001', '2026-05-15', 5.00, 50),   -- Panadol batch 1
(1, 1, 1, 'PAN-002', '2027-01-10', 5.20, 100),  -- Panadol batch 2
(3, 1, 1, 'AUG-001', '2025-12-01', 12.00, 30),  -- Augmentin batch

-- Purchase 2 from Supplier 2
(2, 2, 2, 'BRU-001', '2027-03-10', 7.50, 40),   -- Brufen
(4, 2, 2, 'LOS-001', '2026-11-01', 6.00, 25);   -- Losec

--------------------------------------------------
-- 12. PRESCRIPTIONS
--------------------------------------------------
INSERT INTO Prescription (CustomerID, DoctorName, PrescriptionDate, Notes)
VALUES
(1, 'Dr. Haroon', '2025-02-01', 'Take as prescribed'),
(2, 'Dr. Samina', '2025-02-02', 'For infection');

--------------------------------------------------
-- 13. PRESCRIPTION DETAILS
--------------------------------------------------
INSERT INTO PrescriptionDetail (PrescriptionID, MedicineID, Dosage, Frequency, DurationDays)
VALUES
(1, 3, '1 tablet', '2 times a day', 5),    -- Augmentin
(2, 3, '1 tablet', '3 times a day', 7);

--------------------------------------------------
-- 14. SALES
--------------------------------------------------
INSERT INTO Sale (UserID, CustomerID, PrescriptionID, SaleDate, TotalAmount)
VALUES
(2, 1, 1, '2025-02-05', NULL),
(2, 2, 2, '2025-02-06', NULL);

-- Assume SaleIDs = 1 and 2

--------------------------------------------------
-- 15. SALE DETAILS (Sold from Batches)
--------------------------------------------------
INSERT INTO SaleDetail (SaleID, BatchID, QuantitySold, SellingPrice)
VALUES
(1, 1, 5, 7.00),  -- Sold 5 units from Panadol Batch1
(1, 3, 2, 15.00), -- Sold 2 units Augmentin batch
(2, 4, 3, 10.00); -- Sold 3 units Brufen

--------------------------------------------------
-- DONE: DATABASE SEEDED SUCCESSFULLY
--------------------------------------------------
ALTER TABLE [User]
ADD IsActive BIT NOT NULL DEFAULT 1;

select * from Medicine;



-- USER
CREATE INDEX IX_User_RoleID
ON [User](RoleID);

-- MEDICINE
CREATE INDEX IX_Medicine_CategoryID
ON Medicine(CategoryID);

CREATE INDEX IX_Medicine_ManufacturerID
ON Medicine(ManufacturerID);

CREATE INDEX IX_Medicine_FormulaID
ON Medicine(FormulaID);

-- SUPPLIER–MEDICINE (junction table already has PK index)
-- No extra index needed here

-- PURCHASE
CREATE INDEX IX_Purchase_SupplierID
ON Purchase(SupplierID);

CREATE INDEX IX_Purchase_UserID
ON Purchase(UserID);

-- MEDICINE BATCH
CREATE INDEX IX_MedicineBatch_MedicineID
ON MedicineBatch(MedicineID);

CREATE INDEX IX_MedicineBatch_PurchaseID
ON MedicineBatch(PurchaseID);

CREATE INDEX IX_MedicineBatch_SupplierID
ON MedicineBatch(SupplierID);

-- PRESCRIPTION
CREATE INDEX IX_Prescription_CustomerID
ON Prescription(CustomerID);

-- PRESCRIPTION DETAIL (PK already indexed)
-- No extra index required

-- SALE
CREATE INDEX IX_Sale_UserID
ON Sale(UserID);

CREATE INDEX IX_Sale_CustomerID
ON Sale(CustomerID);

CREATE INDEX IX_Sale_PrescriptionID
ON Sale(PrescriptionID);

-- SALE DETAIL
CREATE INDEX IX_SaleDetail_BatchID
ON SaleDetail(BatchID);
CREATE INDEX IX_Sale_SaleDate
ON Sale(SaleDate);

CREATE INDEX IX_Prescription_PrescriptionDate
ON Prescription(PrescriptionDate);

CREATE INDEX IX_Purchase_PurchaseDate
ON Purchase(PurchaseDate);

CREATE INDEX IX_MedicineBatch_ExpiryDate
ON MedicineBatch(ExpiryDate);
-- Low stock alerts
CREATE INDEX IX_Medicine_MinimumStockLevel
ON Medicine(MinimumStockLevel);

-- Active medicines filtering
CREATE INDEX IX_Medicine_IsActive
ON Medicine(IsActive);

-- Prescription-required filtering
CREATE INDEX IX_Medicine_IsPrescriptionRequired
ON Medicine(IsPrescriptionRequired);
CREATE INDEX IX_Medicine_Name
ON Medicine(Name);

CREATE INDEX IX_Customer_Name
ON Customer(CustomerName);

CREATE INDEX IX_Supplier_Name
ON Supplier(SupplierName);