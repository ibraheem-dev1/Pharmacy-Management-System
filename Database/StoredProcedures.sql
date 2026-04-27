--=========================================================
-- PHARMACY MANAGEMENT SYSTEM - STORED PROCEDURES
-- Run this script on PharmacyDB to create all procedures
--=========================================================

USE PharmacyDB;
GO

--=========================================================
-- USER PROCEDURES
--=========================================================

-- sp_ValidateLogin: Validate user credentials and return user info
IF OBJECT_ID('sp_ValidateLogin', 'P') IS NOT NULL DROP PROCEDURE sp_ValidateLogin;
GO
CREATE PROCEDURE sp_ValidateLogin
    @Username VARCHAR(100),
    @Password VARCHAR(255)
AS
BEGIN
    SELECT u.UserID, u.UserName, u.RoleID, r.RoleName 
    FROM [User] u 
    INNER JOIN Role r ON u.RoleID = r.RoleID 
    WHERE u.UserName = @Username AND u.PasswordHash = @Password AND u.IsActive = 1;
END
GO

-- sp_GetAllUsers: Get all users with their roles
IF OBJECT_ID('sp_GetAllUsers', 'P') IS NOT NULL DROP PROCEDURE sp_GetAllUsers;
GO
CREATE PROCEDURE sp_GetAllUsers
AS
BEGIN
    SELECT u.UserID, u.UserName, u.RoleID, u.IsActive, r.RoleName 
    FROM [User] u 
    INNER JOIN Role r ON u.RoleID = r.RoleID 
    ORDER BY u.UserName;
END
GO

-- sp_AddUser: Add a new user
IF OBJECT_ID('sp_AddUser', 'P') IS NOT NULL DROP PROCEDURE sp_AddUser;
GO
CREATE PROCEDURE sp_AddUser
    @UserName VARCHAR(100),
    @PasswordHash VARCHAR(255),
    @RoleID INT,
    @IsActive BIT
AS
BEGIN
    INSERT INTO [User] (UserName, PasswordHash, RoleID, IsActive) 
    VALUES (@UserName, @PasswordHash, @RoleID, @IsActive);
    SELECT @@ROWCOUNT;
END
GO

-- sp_UpdateUser: Update an existing user
IF OBJECT_ID('sp_UpdateUser', 'P') IS NOT NULL DROP PROCEDURE sp_UpdateUser;
GO
CREATE PROCEDURE sp_UpdateUser
    @UserID INT,
    @UserName VARCHAR(100),
    @PasswordHash VARCHAR(255),
    @RoleID INT,
    @IsActive BIT
AS
BEGIN
    UPDATE [User] SET 
        UserName = @UserName, 
        PasswordHash = @PasswordHash, 
        RoleID = @RoleID, 
        IsActive = @IsActive 
    WHERE UserID = @UserID;
    SELECT @@ROWCOUNT;
END
GO

-- sp_DeactivateUser: Deactivate a user
IF OBJECT_ID('sp_DeactivateUser', 'P') IS NOT NULL DROP PROCEDURE sp_DeactivateUser;
GO
CREATE PROCEDURE sp_DeactivateUser
    @UserID INT
AS
BEGIN
    UPDATE [User] SET IsActive = 0 WHERE UserID = @UserID;
    SELECT @@ROWCOUNT;
END
GO

--=========================================================
-- ROLE PROCEDURES
--=========================================================

-- sp_GetAllRoles: Get all roles
IF OBJECT_ID('sp_GetAllRoles', 'P') IS NOT NULL DROP PROCEDURE sp_GetAllRoles;
GO
CREATE PROCEDURE sp_GetAllRoles
AS
BEGIN
    SELECT RoleID, RoleName FROM Role;
END
GO

-- sp_AddRole: Add a new role
IF OBJECT_ID('sp_AddRole', 'P') IS NOT NULL DROP PROCEDURE sp_AddRole;
GO
CREATE PROCEDURE sp_AddRole
    @RoleName VARCHAR(50)
AS
BEGIN
    INSERT INTO Role (RoleName) VALUES (@RoleName);
    SELECT @@ROWCOUNT;
END
GO

--=========================================================
-- CATEGORY PROCEDURES
--=========================================================

-- sp_GetAllCategories: Get all categories
IF OBJECT_ID('sp_GetAllCategories', 'P') IS NOT NULL DROP PROCEDURE sp_GetAllCategories;
GO
CREATE PROCEDURE sp_GetAllCategories
AS
BEGIN
    SELECT CategoryID, CategoryName FROM Category ORDER BY CategoryName;
END
GO

-- sp_AddCategory: Add a new category
IF OBJECT_ID('sp_AddCategory', 'P') IS NOT NULL DROP PROCEDURE sp_AddCategory;
GO
CREATE PROCEDURE sp_AddCategory
    @CategoryName VARCHAR(100)
AS
BEGIN
    INSERT INTO Category (CategoryName) VALUES (@CategoryName);
    SELECT @@ROWCOUNT;
END
GO

-- sp_UpdateCategory: Update a category
IF OBJECT_ID('sp_UpdateCategory', 'P') IS NOT NULL DROP PROCEDURE sp_UpdateCategory;
GO
CREATE PROCEDURE sp_UpdateCategory
    @CategoryID INT,
    @CategoryName VARCHAR(100)
AS
BEGIN
    UPDATE Category SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID;
    SELECT @@ROWCOUNT;
END
GO

--=========================================================
-- MANUFACTURER PROCEDURES
--=========================================================

-- sp_GetAllManufacturers: Get all manufacturers
IF OBJECT_ID('sp_GetAllManufacturers', 'P') IS NOT NULL DROP PROCEDURE sp_GetAllManufacturers;
GO
CREATE PROCEDURE sp_GetAllManufacturers
AS
BEGIN
    SELECT ManufacturerID, ManufacturerName FROM Manufacturer ORDER BY ManufacturerName;
END
GO

-- sp_AddManufacturer: Add a new manufacturer
IF OBJECT_ID('sp_AddManufacturer', 'P') IS NOT NULL DROP PROCEDURE sp_AddManufacturer;
GO
CREATE PROCEDURE sp_AddManufacturer
    @ManufacturerName VARCHAR(150)
AS
BEGIN
    INSERT INTO Manufacturer (ManufacturerName) VALUES (@ManufacturerName);
    SELECT @@ROWCOUNT;
END
GO

-- sp_UpdateManufacturer: Update a manufacturer
IF OBJECT_ID('sp_UpdateManufacturer', 'P') IS NOT NULL DROP PROCEDURE sp_UpdateManufacturer;
GO
CREATE PROCEDURE sp_UpdateManufacturer
    @ManufacturerID INT,
    @ManufacturerName VARCHAR(150)
AS
BEGIN
    UPDATE Manufacturer SET ManufacturerName = @ManufacturerName WHERE ManufacturerID = @ManufacturerID;
    SELECT @@ROWCOUNT;
END
GO

--=========================================================
-- FORMULA PROCEDURES
--=========================================================

-- sp_GetAllFormulas: Get all formulas
IF OBJECT_ID('sp_GetAllFormulas', 'P') IS NOT NULL DROP PROCEDURE sp_GetAllFormulas;
GO
CREATE PROCEDURE sp_GetAllFormulas
AS
BEGIN
    SELECT FormulaID, FormulaName FROM Formula ORDER BY FormulaName;
END
GO

-- sp_AddFormula: Add a new formula
IF OBJECT_ID('sp_AddFormula', 'P') IS NOT NULL DROP PROCEDURE sp_AddFormula;
GO
CREATE PROCEDURE sp_AddFormula
    @FormulaName VARCHAR(150)
AS
BEGIN
    INSERT INTO Formula (FormulaName) VALUES (@FormulaName);
    SELECT @@ROWCOUNT;
END
GO

-- sp_UpdateFormula: Update a formula
IF OBJECT_ID('sp_UpdateFormula', 'P') IS NOT NULL DROP PROCEDURE sp_UpdateFormula;
GO
CREATE PROCEDURE sp_UpdateFormula
    @FormulaID INT,
    @FormulaName VARCHAR(150)
AS
BEGIN
    UPDATE Formula SET FormulaName = @FormulaName WHERE FormulaID = @FormulaID;
    SELECT @@ROWCOUNT;
END
GO

--=========================================================
-- CUSTOMER PROCEDURES
--=========================================================

-- sp_GetAllCustomers: Get all customers
IF OBJECT_ID('sp_GetAllCustomers', 'P') IS NOT NULL DROP PROCEDURE sp_GetAllCustomers;
GO
CREATE PROCEDURE sp_GetAllCustomers
AS
BEGIN
    SELECT CustomerID, CustomerName, ContactNo, Address FROM Customer ORDER BY CustomerName;
END
GO

-- sp_AddCustomer: Add a new customer
IF OBJECT_ID('sp_AddCustomer', 'P') IS NOT NULL DROP PROCEDURE sp_AddCustomer;
GO
CREATE PROCEDURE sp_AddCustomer
    @CustomerName VARCHAR(150),
    @ContactNo VARCHAR(50),
    @Address VARCHAR(250)
AS
BEGIN
    INSERT INTO Customer (CustomerName, ContactNo, Address) VALUES (@CustomerName, @ContactNo, @Address);
    SELECT @@ROWCOUNT;
END
GO

-- sp_UpdateCustomer: Update a customer
IF OBJECT_ID('sp_UpdateCustomer', 'P') IS NOT NULL DROP PROCEDURE sp_UpdateCustomer;
GO
CREATE PROCEDURE sp_UpdateCustomer
    @CustomerID INT,
    @CustomerName VARCHAR(150),
    @ContactNo VARCHAR(50),
    @Address VARCHAR(250)
AS
BEGIN
    UPDATE Customer SET 
        CustomerName = @CustomerName, 
        ContactNo = @ContactNo, 
        Address = @Address 
    WHERE CustomerID = @CustomerID;
    SELECT @@ROWCOUNT;
END
GO

-- sp_SearchCustomers: Search customers by name
IF OBJECT_ID('sp_SearchCustomers', 'P') IS NOT NULL DROP PROCEDURE sp_SearchCustomers;
GO
CREATE PROCEDURE sp_SearchCustomers
    @SearchTerm VARCHAR(150)
AS
BEGIN
    SELECT CustomerID, CustomerName, ContactNo, Address 
    FROM Customer 
    WHERE CustomerName LIKE '%' + @SearchTerm + '%'
    OR Contact LIKE '%' + @SearchTerm + '%'
    ORDER BY CustomerName;
END
GO

--=========================================================
-- SUPPLIER PROCEDURES
--=========================================================

-- sp_GetAllSuppliers: Get all suppliers
IF OBJECT_ID('sp_GetAllSuppliers', 'P') IS NOT NULL DROP PROCEDURE sp_GetAllSuppliers;
GO
CREATE PROCEDURE sp_GetAllSuppliers
AS
BEGIN
    SELECT SupplierID, SupplierName, Contact, Address FROM Supplier ORDER BY SupplierName;
END
GO

-- sp_AddSupplier: Add a new supplier
IF OBJECT_ID('sp_AddSupplier', 'P') IS NOT NULL DROP PROCEDURE sp_AddSupplier;
GO
CREATE PROCEDURE sp_AddSupplier
    @SupplierName VARCHAR(150),
    @Contact VARCHAR(100),
    @Address VARCHAR(250)
AS
BEGIN
    INSERT INTO Supplier (SupplierName, Contact, Address) VALUES (@SupplierName, @Contact, @Address);
    SELECT @@ROWCOUNT;
END
GO

-- sp_UpdateSupplier: Update a supplier
IF OBJECT_ID('sp_UpdateSupplier', 'P') IS NOT NULL DROP PROCEDURE sp_UpdateSupplier;
GO
CREATE PROCEDURE sp_UpdateSupplier
    @SupplierID INT,
    @SupplierName VARCHAR(150),
    @Contact VARCHAR(100),
    @Address VARCHAR(250)
AS
BEGIN
    UPDATE Supplier SET 
        SupplierName = @SupplierName, 
        Contact = @Contact, 
        Address = @Address 
    WHERE SupplierID = @SupplierID;
    SELECT @@ROWCOUNT;
END
GO

-- sp_SearchSuppliers: Search suppliers by name, contact, or address
IF OBJECT_ID('sp_SearchSuppliers', 'P') IS NOT NULL DROP PROCEDURE sp_SearchSuppliers;
GO
CREATE PROCEDURE sp_SearchSuppliers
    @SearchTerm VARCHAR(150)
AS
BEGIN
    SELECT SupplierID, SupplierName, Contact, Address 
    FROM Supplier 
    WHERE SupplierName LIKE '%' + @SearchTerm + '%'
       OR Contact LIKE '%' + @SearchTerm + '%'
       OR Address LIKE '%' + @SearchTerm + '%'
    ORDER BY SupplierName;
END
GO

--=========================================================
-- SUPPLIER-MEDICINE PROCEDURES (already exists, keeping for reference)
--=========================================================

-- sp_AddSupplierMedicine: Link supplier to medicine
IF OBJECT_ID('sp_AddSupplierMedicine', 'P') IS NOT NULL DROP PROCEDURE sp_AddSupplierMedicine;
GO
CREATE PROCEDURE sp_AddSupplierMedicine
    @SupplierID INT,
    @MedicineID INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM SupplierMedicine WHERE SupplierID = @SupplierID AND MedicineID = @MedicineID)
    BEGIN
        INSERT INTO SupplierMedicine (SupplierID, MedicineID) VALUES (@SupplierID, @MedicineID);
    END
    SELECT @@ROWCOUNT;
END
GO

-- sp_RemoveSupplierMedicine: Remove supplier-medicine link
IF OBJECT_ID('sp_RemoveSupplierMedicine', 'P') IS NOT NULL DROP PROCEDURE sp_RemoveSupplierMedicine;
GO
CREATE PROCEDURE sp_RemoveSupplierMedicine
    @SupplierID INT,
    @MedicineID INT
AS
BEGIN
    DELETE FROM SupplierMedicine WHERE SupplierID = @SupplierID AND MedicineID = @MedicineID;
    SELECT @@ROWCOUNT;
END
GO

-- sp_GetMedicinesBySupplier: Get medicines for a supplier
IF OBJECT_ID('sp_GetMedicinesBySupplier', 'P') IS NOT NULL DROP PROCEDURE sp_GetMedicinesBySupplier;
GO
CREATE PROCEDURE sp_GetMedicinesBySupplier
    @SupplierID INT
AS
BEGIN
    SELECT m.MedicineID, m.Name, m.StrengthMG
    FROM Medicine m
    INNER JOIN SupplierMedicine sm ON m.MedicineID = sm.MedicineID
    WHERE sm.SupplierID = @SupplierID AND m.IsActive = 1;
END
GO

--=========================================================
-- MEDICINE PROCEDURES
--=========================================================

-- sp_GetAllMedicines: Get all active medicines with stock info
IF OBJECT_ID('sp_GetAllMedicines', 'P') IS NOT NULL DROP PROCEDURE sp_GetAllMedicines;
GO
CREATE PROCEDURE sp_GetAllMedicines
AS
BEGIN
    SELECT m.MedicineID, m.Name, m.StrengthMG, m.MinimumStockLevel, 
           m.IsPrescriptionRequired, m.IsActive, m.CategoryID, m.ManufacturerID, m.FormulaID,
           c.CategoryName, mf.ManufacturerName, f.FormulaName,
           ISNULL(SUM(mb.QuantityInStock), 0) as TotalStock
    FROM Medicine m
    INNER JOIN Category c ON m.CategoryID = c.CategoryID
    INNER JOIN Manufacturer mf ON m.ManufacturerID = mf.ManufacturerID
    INNER JOIN Formula f ON m.FormulaID = f.FormulaID
    LEFT JOIN MedicineBatch mb ON m.MedicineID = mb.MedicineID
    WHERE m.IsActive = 1
    GROUP BY m.MedicineID, m.Name, m.StrengthMG, m.MinimumStockLevel, 
             m.IsPrescriptionRequired, m.IsActive, m.CategoryID, m.ManufacturerID, m.FormulaID,
             c.CategoryName, mf.ManufacturerName, f.FormulaName
    ORDER BY m.Name;
END
GO

-- sp_AddMedicine: Add a new medicine
IF OBJECT_ID('sp_AddMedicine', 'P') IS NOT NULL DROP PROCEDURE sp_AddMedicine;
GO
CREATE PROCEDURE sp_AddMedicine
    @Name VARCHAR(150),
    @StrengthMG INT,
    @MinimumStockLevel INT,
    @IsPrescriptionRequired BIT,
    @IsActive BIT,
    @CategoryID INT,
    @ManufacturerID INT,
    @FormulaID INT
AS
BEGIN
    -- Check if medicine with same name, strength, category, manufacturer, and formula already exists
    IF EXISTS (SELECT 1 FROM Medicine 
               WHERE Name = @Name 
               AND StrengthMG = @StrengthMG 
               AND CategoryID = @CategoryID 
               AND ManufacturerID = @ManufacturerID 
               AND FormulaID = @FormulaID)
    BEGIN
        -- Return 0 to indicate duplicate found
        SELECT 0;
        RETURN;
    END

    INSERT INTO Medicine (Name, StrengthMG, MinimumStockLevel, IsPrescriptionRequired, 
                         IsActive, CategoryID, ManufacturerID, FormulaID) 
    VALUES (@Name, @StrengthMG, @MinimumStockLevel, @IsPrescriptionRequired, 
            @IsActive, @CategoryID, @ManufacturerID, @FormulaID);
    SELECT @@ROWCOUNT;
END
GO

-- sp_UpdateMedicine: Update a medicine
IF OBJECT_ID('sp_UpdateMedicine', 'P') IS NOT NULL DROP PROCEDURE sp_UpdateMedicine;
GO
CREATE PROCEDURE sp_UpdateMedicine
    @MedicineID INT,
    @Name VARCHAR(150),
    @StrengthMG INT,
    @MinimumStockLevel INT,
    @IsPrescriptionRequired BIT,
    @IsActive BIT,
    @CategoryID INT,
    @ManufacturerID INT,
    @FormulaID INT
AS
BEGIN
    UPDATE Medicine SET 
        Name = @Name, 
        StrengthMG = @StrengthMG, 
        MinimumStockLevel = @MinimumStockLevel, 
        IsPrescriptionRequired = @IsPrescriptionRequired, 
        IsActive = @IsActive, 
        CategoryID = @CategoryID, 
        ManufacturerID = @ManufacturerID, 
        FormulaID = @FormulaID 
    WHERE MedicineID = @MedicineID;
    SELECT @@ROWCOUNT;
END
GO

-- sp_DeactivateMedicine: Deactivate a medicine
IF OBJECT_ID('sp_DeactivateMedicine', 'P') IS NOT NULL DROP PROCEDURE sp_DeactivateMedicine;
GO
CREATE PROCEDURE sp_DeactivateMedicine
    @MedicineID INT
AS
BEGIN
    UPDATE Medicine SET IsActive = 0 WHERE MedicineID = @MedicineID;
    SELECT @@ROWCOUNT;
END
GO

-- sp_GetMedicinesWithLowStock: Get medicines with stock below minimum level
IF OBJECT_ID('sp_GetMedicinesWithLowStock', 'P') IS NOT NULL DROP PROCEDURE sp_GetMedicinesWithLowStock;
GO
CREATE PROCEDURE sp_GetMedicinesWithLowStock
AS
BEGIN
    SELECT m.MedicineID, m.Name, m.StrengthMG, m.MinimumStockLevel, 
           ISNULL(SUM(mb.QuantityInStock), 0) as TotalStock
    FROM Medicine m
    LEFT JOIN MedicineBatch mb ON m.MedicineID = mb.MedicineID
    WHERE m.IsActive = 1
    GROUP BY m.MedicineID, m.Name, m.StrengthMG, m.MinimumStockLevel
    HAVING ISNULL(SUM(mb.QuantityInStock), 0) < m.MinimumStockLevel;
END
GO

-- sp_GetDistinctMedicineNames: Get distinct medicine names
IF OBJECT_ID('sp_GetDistinctMedicineNames', 'P') IS NOT NULL DROP PROCEDURE sp_GetDistinctMedicineNames;
GO
CREATE PROCEDURE sp_GetDistinctMedicineNames
AS
BEGIN
    SELECT DISTINCT Name
    FROM Medicine
    WHERE IsActive = 1
    ORDER BY Name;
END
GO

-- sp_GetMedicineVariants: Get formulas and strengths for a specific medicine name
IF OBJECT_ID('sp_GetMedicineVariants', 'P') IS NOT NULL DROP PROCEDURE sp_GetMedicineVariants;
GO
CREATE PROCEDURE sp_GetMedicineVariants
    @MedicineName VARCHAR(150)
AS
BEGIN
    SELECT m.MedicineID, m.Name, m.StrengthMG, m.FormulaID, f.FormulaName
    FROM Medicine m
    INNER JOIN Formula f ON m.FormulaID = f.FormulaID
    WHERE m.Name = @MedicineName AND m.IsActive = 1
    ORDER BY f.FormulaName, m.StrengthMG;
END
GO

-- sp_GetMedicinesWithStock: Get all active medicines with stock details
IF OBJECT_ID('sp_GetMedicinesWithStock', 'P') IS NOT NULL DROP PROCEDURE sp_GetMedicinesWithStock;
GO
CREATE PROCEDURE sp_GetMedicinesWithStock
AS
BEGIN
    SELECT m.MedicineID, m.Name, m.StrengthMG, m.MinimumStockLevel, 
           m.IsPrescriptionRequired, m.IsActive, m.CategoryID, m.ManufacturerID, 
           m.FormulaID, c.CategoryName, mf.ManufacturerName, f.FormulaName,
           ISNULL(SUM(mb.QuantityInStock), 0) as TotalStock
    FROM Medicine m
    INNER JOIN Category c ON m.CategoryID = c.CategoryID
    INNER JOIN Manufacturer mf ON m.ManufacturerID = mf.ManufacturerID
    INNER JOIN Formula f ON m.FormulaID = f.FormulaID
    LEFT JOIN MedicineBatch mb ON m.MedicineID = mb.MedicineID
    WHERE m.IsActive = 1
    GROUP BY m.MedicineID, m.Name, m.StrengthMG, m.MinimumStockLevel, 
             m.IsPrescriptionRequired, m.IsActive, m.CategoryID, m.ManufacturerID, 
             m.FormulaID, c.CategoryName, mf.ManufacturerName, f.FormulaName
    ORDER BY m.Name;
END
GO

--=========================================================
-- MEDICINE BATCH PROCEDURES
--=========================================================

-- sp_AddMedicineBatch: Add a new medicine batch
IF OBJECT_ID('sp_AddMedicineBatch', 'P') IS NOT NULL DROP PROCEDURE sp_AddMedicineBatch;
GO
CREATE PROCEDURE sp_AddMedicineBatch
    @MedicineID INT,
    @SupplierID INT,
    @PurchaseID INT,
    @ExpiryDate DATE,
    @PurchasePrice DECIMAL(10,2),
    @QuantityInStock INT
AS
BEGIN
    -- Validate expiry date is greater than today
    IF @ExpiryDate <= CAST(GETDATE() AS DATE)
    BEGIN
        RAISERROR('Expiry date must be greater than today''s date.', 16, 1);
        RETURN;
    END

    -- Insert batch (BatchNumber will be set as BatchID after insertion)
    INSERT INTO MedicineBatch (MedicineID, SupplierID, PurchaseID, BatchNumber, 
                              ExpiryDate, PurchasePrice, QuantityInStock) 
    VALUES (@MedicineID, @SupplierID, @PurchaseID, NULL, 
            @ExpiryDate, @PurchasePrice, @QuantityInStock);
    
    -- Get the newly created BatchID
    DECLARE @NewBatchID INT = SCOPE_IDENTITY();
    
    -- Update BatchNumber to be the same as BatchID
    UPDATE MedicineBatch 
    SET BatchNumber = CAST(@NewBatchID AS VARCHAR(100))
    WHERE BatchID = @NewBatchID;
    
    -- Return the BatchID
    SELECT @NewBatchID AS BatchID;
END
GO

-- sp_GetAllBatches: Get all batches with stock > 0
IF OBJECT_ID('sp_GetAllBatches', 'P') IS NOT NULL DROP PROCEDURE sp_GetAllBatches;
GO
CREATE PROCEDURE sp_GetAllBatches
AS
BEGIN
    SELECT mb.BatchID, mb.MedicineID, mb.SupplierID, mb.PurchaseID, 
           mb.BatchNumber, mb.ExpiryDate, mb.PurchasePrice, mb.QuantityInStock,
           m.Name as MedicineName, m.StrengthMG, m.MinimumStockLevel, s.SupplierName
    FROM MedicineBatch mb
    INNER JOIN Medicine m ON mb.MedicineID = m.MedicineID
    INNER JOIN Supplier s ON mb.SupplierID = s.SupplierID
    ORDER BY mb.ExpiryDate ASC;
END
GO

-- sp_GetEarliestExpiryBatch: Get earliest expiry batch for FIFO sale
IF OBJECT_ID('sp_GetEarliestExpiryBatch', 'P') IS NOT NULL DROP PROCEDURE sp_GetEarliestExpiryBatch;
GO
CREATE PROCEDURE sp_GetEarliestExpiryBatch
    @MedicineID INT,
    @QuantityNeeded INT
AS
BEGIN
    SELECT TOP 1 mb.BatchID, mb.MedicineID, mb.SupplierID, mb.PurchaseID, 
           mb.BatchNumber, mb.ExpiryDate, mb.PurchasePrice, mb.QuantityInStock,
           m.Name as MedicineName, s.SupplierName
    FROM MedicineBatch mb
    INNER JOIN Medicine m ON mb.MedicineID = m.MedicineID
    INNER JOIN Supplier s ON mb.SupplierID = s.SupplierID
    WHERE mb.MedicineID = @MedicineID AND mb.QuantityInStock >= @QuantityNeeded
    ORDER BY mb.ExpiryDate ASC;
END
GO

-- sp_UpdateBatchQuantity: Update batch quantity
IF OBJECT_ID('sp_UpdateBatchQuantity', 'P') IS NOT NULL DROP PROCEDURE sp_UpdateBatchQuantity;
GO
CREATE PROCEDURE sp_UpdateBatchQuantity
    @BatchID INT,
    @QuantityInStock INT
AS
BEGIN
    UPDATE MedicineBatch SET QuantityInStock = @QuantityInStock WHERE BatchID = @BatchID;
    SELECT @@ROWCOUNT;
END
GO

-- sp_GetExpiringSoonBatches: Get batches expiring within N days
IF OBJECT_ID('sp_GetExpiringSoonBatches', 'P') IS NOT NULL DROP PROCEDURE sp_GetExpiringSoonBatches;
GO
CREATE PROCEDURE sp_GetExpiringSoonBatches
    @Days INT = 30
AS
BEGIN
    SELECT mb.BatchID, mb.MedicineID, mb.SupplierID, mb.PurchaseID, 
           mb.BatchNumber, mb.ExpiryDate, mb.PurchasePrice, mb.QuantityInStock,
           m.Name as MedicineName, s.SupplierName
    FROM MedicineBatch mb
    INNER JOIN Medicine m ON mb.MedicineID = m.MedicineID
    INNER JOIN Supplier s ON mb.SupplierID = s.SupplierID
    WHERE mb.QuantityInStock > 0 AND mb.ExpiryDate <= DATEADD(day, @Days, GETDATE())
    ORDER BY mb.ExpiryDate ASC;
END
GO

-- sp_GetBatchesByMedicine: Get all batches for a medicine
IF OBJECT_ID('sp_GetBatchesByMedicine', 'P') IS NOT NULL DROP PROCEDURE sp_GetBatchesByMedicine;
GO
CREATE PROCEDURE sp_GetBatchesByMedicine
    @MedicineID INT
AS
BEGIN
    SELECT mb.BatchID, mb.MedicineID, mb.SupplierID, mb.PurchaseID, 
           mb.BatchNumber, mb.ExpiryDate, mb.PurchasePrice, mb.QuantityInStock,
           m.Name as MedicineName, s.SupplierName
    FROM MedicineBatch mb
    INNER JOIN Medicine m ON mb.MedicineID = m.MedicineID
    INNER JOIN Supplier s ON mb.SupplierID = s.SupplierID
    WHERE mb.MedicineID = @MedicineID AND mb.QuantityInStock > 0
    ORDER BY mb.ExpiryDate ASC;
END
GO

-- sp_GetBatchesByExpiryDate: Get batches expiring by a specific date
IF OBJECT_ID('sp_GetBatchesByExpiryDate', 'P') IS NOT NULL DROP PROCEDURE sp_GetBatchesByExpiryDate;
GO
CREATE PROCEDURE sp_GetBatchesByExpiryDate
    @ExpiryDate DATE
AS
BEGIN
    SELECT mb.BatchID, mb.MedicineID, mb.SupplierID, mb.PurchaseID, 
           mb.BatchNumber, mb.ExpiryDate, mb.PurchasePrice, mb.QuantityInStock,
           m.Name as MedicineName, s.SupplierName
    FROM MedicineBatch mb
    INNER JOIN Medicine m ON mb.MedicineID = m.MedicineID
    INNER JOIN Supplier s ON mb.SupplierID = s.SupplierID
    WHERE mb.QuantityInStock > 0 AND mb.ExpiryDate <= @ExpiryDate
    ORDER BY mb.ExpiryDate ASC;
END
GO

--=========================================================
-- PURCHASE PROCEDURES
--=========================================================

-- sp_AddPurchase: Add a new purchase and return the ID
IF OBJECT_ID('sp_AddPurchase', 'P') IS NOT NULL DROP PROCEDURE sp_AddPurchase;
GO
CREATE PROCEDURE sp_AddPurchase
    @SupplierID INT,
    @UserID INT,
    @PurchaseDate DATE,
    @TotalAmount DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Purchase (SupplierID, UserID, PurchaseDate, TotalAmount) 
    VALUES (@SupplierID, @UserID, @PurchaseDate, @TotalAmount);
    SELECT SCOPE_IDENTITY();
END
GO

-- sp_GetAllPurchases: Get all purchases
IF OBJECT_ID('sp_GetAllPurchases', 'P') IS NOT NULL DROP PROCEDURE sp_GetAllPurchases;
GO
CREATE PROCEDURE sp_GetAllPurchases
AS
BEGIN
    SELECT p.PurchaseID, p.SupplierID, p.UserID, p.PurchaseDate, p.TotalAmount,
           s.SupplierName, u.UserName
    FROM Purchase p
    INNER JOIN Supplier s ON p.SupplierID = s.SupplierID
    INNER JOIN [User] u ON p.UserID = u.UserID
    ORDER BY p.PurchaseDate DESC;
END
GO

--=========================================================
-- SALE PROCEDURES
--=========================================================

-- sp_AddSale: Add a new sale and return the ID
IF OBJECT_ID('sp_AddSale', 'P') IS NOT NULL DROP PROCEDURE sp_AddSale;
GO
CREATE PROCEDURE sp_AddSale
    @UserID INT,
    @CustomerID INT = NULL,
    @PrescriptionID INT = NULL,
    @SaleDate DATE,
    @TotalAmount DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Sale (UserID, CustomerID, PrescriptionID, SaleDate, TotalAmount) 
    VALUES (@UserID, @CustomerID, @PrescriptionID, @SaleDate, @TotalAmount);
    SELECT SCOPE_IDENTITY();
END
GO

-- sp_GetAllSales: Get all sales
IF OBJECT_ID('sp_GetAllSales', 'P') IS NOT NULL DROP PROCEDURE sp_GetAllSales;
GO
CREATE PROCEDURE sp_GetAllSales
AS
BEGIN
    SELECT s.SaleID, s.UserID, s.CustomerID, s.PrescriptionID, s.SaleDate, s.TotalAmount,
           u.UserName, c.CustomerName
    FROM Sale s
    INNER JOIN [User] u ON s.UserID = u.UserID
    LEFT JOIN Customer c ON s.CustomerID = c.CustomerID
    ORDER BY s.SaleDate DESC;
END
GO

-- sp_GetSalesByDate: Get sales for a specific date
IF OBJECT_ID('sp_GetSalesByDate', 'P') IS NOT NULL DROP PROCEDURE sp_GetSalesByDate;
GO
CREATE PROCEDURE sp_GetSalesByDate
    @SaleDate DATE
AS
BEGIN
    SELECT s.SaleID, s.UserID, s.CustomerID, s.PrescriptionID, s.SaleDate, s.TotalAmount,
           u.UserName, c.CustomerName
    FROM Sale s
    INNER JOIN [User] u ON s.UserID = u.UserID
    LEFT JOIN Customer c ON s.CustomerID = c.CustomerID
    WHERE CAST(s.SaleDate AS DATE) = @SaleDate
    ORDER BY s.SaleDate DESC;
END
GO

--=========================================================
-- SALE DETAIL PROCEDURES
--=========================================================

-- sp_SellMedicine_FIFO: Sell medicine using FIFO (First In, First Out) method
IF OBJECT_ID('sp_SellMedicine_FIFO', 'P') IS NOT NULL DROP PROCEDURE sp_SellMedicine_FIFO;
GO
CREATE PROCEDURE sp_SellMedicine_FIFO
    @SaleID INT,
    @MedicineID INT,
    @Quantity INT,
    @SellingPrice DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN;

    DECLARE @Remaining INT = @Quantity;

    DECLARE batch_cursor CURSOR FOR
    SELECT BatchID, QuantityInStock
    FROM MedicineBatch
    WHERE MedicineID = @MedicineID
      AND QuantityInStock > 0
      AND ExpiryDate > GETDATE()
    ORDER BY ExpiryDate;

    OPEN batch_cursor;

    DECLARE @BatchID INT, @BatchQty INT;

    FETCH NEXT FROM batch_cursor INTO @BatchID, @BatchQty;

    WHILE @@FETCH_STATUS = 0 AND @Remaining > 0
    BEGIN
        DECLARE @ToSell INT =
            CASE WHEN @BatchQty >= @Remaining THEN @Remaining ELSE @BatchQty END;

        UPDATE MedicineBatch
        SET QuantityInStock = QuantityInStock - @ToSell
        WHERE BatchID = @BatchID;

        INSERT INTO SaleDetail (SaleID, BatchID, QuantitySold, SellingPrice)
        VALUES (@SaleID, @BatchID, @ToSell, @SellingPrice);

        SET @Remaining -= @ToSell;

        FETCH NEXT FROM batch_cursor INTO @BatchID, @BatchQty;
    END

    CLOSE batch_cursor;
    DEALLOCATE batch_cursor;

    IF @Remaining > 0
    BEGIN
        ROLLBACK;
        THROW 50001, 'INSUFFICIENT STOCK', 1;
    END

    COMMIT;
END
GO

-- sp_GetSaleDetails: Get details for a sale
IF OBJECT_ID('sp_GetSaleDetails', 'P') IS NOT NULL DROP PROCEDURE sp_GetSaleDetails;
GO
CREATE PROCEDURE sp_GetSaleDetails
    @SaleID INT
AS
BEGIN
    SELECT m.Name AS MedicineName,
           m.StrengthMG,
           sd.QuantitySold,
           sd.SellingPrice,
           sd.BatchID,
           mb.BatchNumber,
           mb.ExpiryDate
    FROM SaleDetail sd
    JOIN MedicineBatch mb ON sd.BatchID = mb.BatchID
    JOIN Medicine m ON mb.MedicineID = m.MedicineID
    WHERE sd.SaleID = @SaleID;
END
GO

--=========================================================
-- PRESCRIPTION PROCEDURES
--=========================================================

-- sp_AddPrescription: Add a new prescription and return ID
IF OBJECT_ID('sp_AddPrescription', 'P') IS NOT NULL DROP PROCEDURE sp_AddPrescription;
GO
CREATE PROCEDURE sp_AddPrescription
    @CustomerID INT,
    @DoctorName VARCHAR(150),
    @PrescriptionDate DATE,
    @Notes VARCHAR(500)
AS
BEGIN
    INSERT INTO Prescription (CustomerID, DoctorName, PrescriptionDate, Notes) 
    VALUES (@CustomerID, @DoctorName, @PrescriptionDate, @Notes);
    SELECT SCOPE_IDENTITY();
END
GO

-- sp_GetAllPrescriptions: Get all prescriptions
IF OBJECT_ID('sp_GetAllPrescriptions', 'P') IS NOT NULL DROP PROCEDURE sp_GetAllPrescriptions;
GO
CREATE PROCEDURE sp_GetAllPrescriptions
AS
BEGIN
    SELECT p.PrescriptionID, p.CustomerID, p.DoctorName, p.PrescriptionDate, p.Notes,
           c.CustomerName
    FROM Prescription p
    INNER JOIN Customer c ON p.CustomerID = c.CustomerID
    ORDER BY p.PrescriptionDate DESC;
END
GO

-- sp_UpdatePrescription: Update a prescription
IF OBJECT_ID('sp_UpdatePrescription', 'P') IS NOT NULL DROP PROCEDURE sp_UpdatePrescription;
GO
CREATE PROCEDURE sp_UpdatePrescription
    @PrescriptionID INT,
    @CustomerID INT,
    @DoctorName VARCHAR(150),
    @PrescriptionDate DATE,
    @Notes VARCHAR(500)
AS
BEGIN
    UPDATE Prescription SET 
        CustomerID = @CustomerID, 
        DoctorName = @DoctorName, 
        PrescriptionDate = @PrescriptionDate, 
        Notes = @Notes 
    WHERE PrescriptionID = @PrescriptionID;
    SELECT @@ROWCOUNT;
END
GO

--=========================================================
-- PRESCRIPTION DETAIL PROCEDURES
--=========================================================

-- sp_AddPrescriptionDetail: Add a prescription detail line
IF OBJECT_ID('sp_AddPrescriptionDetail', 'P') IS NOT NULL DROP PROCEDURE sp_AddPrescriptionDetail;
GO
CREATE PROCEDURE sp_AddPrescriptionDetail
    @PrescriptionID INT,
    @MedicineID INT,
    @Dosage VARCHAR(100),
    @Frequency VARCHAR(100),
    @DurationDays INT
AS
BEGIN
    INSERT INTO PrescriptionDetail (PrescriptionID, MedicineID, Dosage, Frequency, DurationDays) 
    VALUES (@PrescriptionID, @MedicineID, @Dosage, @Frequency, @DurationDays);
    SELECT @@ROWCOUNT;
END
GO

-- sp_GetPrescriptionDetails: Get details for a prescription
IF OBJECT_ID('sp_GetPrescriptionDetails', 'P') IS NOT NULL DROP PROCEDURE sp_GetPrescriptionDetails;
GO
CREATE PROCEDURE sp_GetPrescriptionDetails
    @PrescriptionID INT
AS
BEGIN
    SELECT pd.PrescriptionID, pd.MedicineID, pd.Dosage, pd.Frequency, pd.DurationDays,
           m.Name as MedicineName
    FROM PrescriptionDetail pd
    INNER JOIN Medicine m ON pd.MedicineID = m.MedicineID
    WHERE pd.PrescriptionID = @PrescriptionID;
END
GO

--=========================================================
-- REPORTS PROCEDURES
--=========================================================

-- sp_GetStockSummary: Get stock summary report
IF OBJECT_ID('sp_GetStockSummary', 'P') IS NOT NULL DROP PROCEDURE sp_GetStockSummary;
GO
CREATE PROCEDURE sp_GetStockSummary
AS
BEGIN
    SELECT m.Name as MedicineName, 
           SUM(mb.QuantityInStock) as TotalStock,
           m.MinimumStockLevel,
           CASE 
               WHEN SUM(mb.QuantityInStock) < m.MinimumStockLevel THEN 'Low Stock'
               ELSE 'OK'
           END as Status
    FROM Medicine m
    LEFT JOIN MedicineBatch mb ON m.MedicineID = mb.MedicineID
    WHERE m.IsActive = 1
    GROUP BY m.Name, m.MinimumStockLevel
    ORDER BY m.Name;
END
GO

-- sp_GetExpiringSoonReport: Get expiring soon report
IF OBJECT_ID('sp_GetExpiringSoonReport', 'P') IS NOT NULL DROP PROCEDURE sp_GetExpiringSoonReport;
GO
CREATE PROCEDURE sp_GetExpiringSoonReport
    @Days INT = 30
AS
BEGIN
    SELECT m.Name as MedicineName, 
           mb.BatchNumber,
           mb.ExpiryDate,
           DATEDIFF(day, GETDATE(), mb.ExpiryDate) as DaysToExpiry,
           mb.QuantityInStock
    FROM MedicineBatch mb
    INNER JOIN Medicine m ON mb.MedicineID = m.MedicineID
    WHERE mb.QuantityInStock > 0 
    AND mb.ExpiryDate <= DATEADD(day, @Days, GETDATE())
    ORDER BY mb.ExpiryDate ASC;
END
GO

-- sp_GetSalesHistory: Get sales history report
IF OBJECT_ID('sp_GetSalesHistory', 'P') IS NOT NULL DROP PROCEDURE sp_GetSalesHistory;
GO
CREATE PROCEDURE sp_GetSalesHistory
    @FromDate DATE,
    @ToDate DATE
AS
BEGIN
    SELECT s.SaleDate, 
           c.CustomerName,
           u.UserName as SoldBy,
           s.TotalAmount
    FROM Sale s
    INNER JOIN [User] u ON s.UserID = u.UserID
    LEFT JOIN Customer c ON s.CustomerID = c.CustomerID
    WHERE s.SaleDate BETWEEN @FromDate AND @ToDate
    ORDER BY s.SaleDate DESC;
END
GO

-- sp_GetPurchaseHistory: Get purchase history report
IF OBJECT_ID('sp_GetPurchaseHistory', 'P') IS NOT NULL DROP PROCEDURE sp_GetPurchaseHistory;
GO
CREATE PROCEDURE sp_GetPurchaseHistory
    @FromDate DATE,
    @ToDate DATE
AS
BEGIN
    SELECT p.PurchaseDate, 
           s.SupplierName,
           u.UserName as PurchasedBy,
           p.TotalAmount
    FROM Purchase p
    INNER JOIN Supplier s ON p.SupplierID = s.SupplierID
    INNER JOIN [User] u ON p.UserID = u.UserID
    WHERE p.PurchaseDate BETWEEN @FromDate AND @ToDate
    ORDER BY p.PurchaseDate DESC;
END
GO

-- sp_GetBatchesByMedicineReport: Get batches for medicine report
IF OBJECT_ID('sp_GetBatchesByMedicineReport', 'P') IS NOT NULL DROP PROCEDURE sp_GetBatchesByMedicineReport;
GO
CREATE PROCEDURE sp_GetBatchesByMedicineReport
    @MedicineID INT
AS
BEGIN
    SELECT mb.BatchNumber, 
           s.SupplierName,
           mb.ExpiryDate,
           mb.PurchasePrice,
           mb.QuantityInStock
    FROM MedicineBatch mb
    INNER JOIN Supplier s ON mb.SupplierID = s.SupplierID
    WHERE mb.MedicineID = @MedicineID
    ORDER BY mb.ExpiryDate ASC;
END
GO

-- sp_GetSalesReport: Get sales summary report by date
IF OBJECT_ID('sp_GetSalesReport', 'P') IS NOT NULL DROP PROCEDURE sp_GetSalesReport;
GO
CREATE PROCEDURE sp_GetSalesReport
    @FromDate DATE,
    @ToDate DATE
AS
BEGIN
    SELECT CAST(s.SaleDate as DATE) as SaleDate, 
           COUNT(s.SaleID) as NumberOfSales,
           SUM(s.TotalAmount) as TotalAmount
    FROM Sale s
    WHERE s.SaleDate BETWEEN @FromDate AND @ToDate
    GROUP BY CAST(s.SaleDate as DATE)
    ORDER BY SaleDate DESC;
END
GO

-- sp_GetLowStockMedicinesReport: Get low stock medicines report
IF OBJECT_ID('sp_GetLowStockMedicinesReport', 'P') IS NOT NULL DROP PROCEDURE sp_GetLowStockMedicinesReport;
GO
CREATE PROCEDURE sp_GetLowStockMedicinesReport
AS
BEGIN
    SELECT m.MedicineID, m.Name as MedicineName, 
           ISNULL(SUM(mb.QuantityInStock), 0) as CurrentStock,
           m.MinimumStockLevel,
           (m.MinimumStockLevel - ISNULL(SUM(mb.QuantityInStock), 0)) as StockNeeded
    FROM Medicine m
    LEFT JOIN MedicineBatch mb ON m.MedicineID = mb.MedicineID
    WHERE m.IsActive = 1
    GROUP BY m.MedicineID, m.Name, m.MinimumStockLevel
    HAVING ISNULL(SUM(mb.QuantityInStock), 0) < m.MinimumStockLevel
    ORDER BY StockNeeded DESC;
END
GO

-- sp_ValidatePrescriptionMedicine: Check if medicine is in patient's prescription
IF OBJECT_ID('sp_ValidatePrescriptionMedicine', 'P') IS NOT NULL DROP PROCEDURE sp_ValidatePrescriptionMedicine;
GO
CREATE PROCEDURE sp_ValidatePrescriptionMedicine
    @PrescriptionID INT,
    @MedicineID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1 
        FROM PrescriptionDetail 
        WHERE PrescriptionID = @PrescriptionID 
        AND MedicineID = @MedicineID
    )
        SELECT 1 AS IsValid;
    ELSE
        SELECT 0 AS IsValid;
END
GO

-- sp_GetMedicinesByPrescription: Get all medicines for a prescription
IF OBJECT_ID('sp_GetMedicinesByPrescription', 'P') IS NOT NULL DROP PROCEDURE sp_GetMedicinesByPrescription;
GO
CREATE PROCEDURE sp_GetMedicinesByPrescription
    @PrescriptionID INT
AS
BEGIN
    SELECT DISTINCT m.MedicineID, m.Name, m.IsPrescriptionRequired
    FROM PrescriptionDetail pd
    INNER JOIN Medicine m ON pd.MedicineID = m.MedicineID
    WHERE pd.PrescriptionID = @PrescriptionID;
END
GO

--=========================================================
-- FINANCIAL MODULE - SALARY TABLES
--=========================================================

-- Create Salary table
IF OBJECT_ID('Salary', 'U') IS NULL
BEGIN
    CREATE TABLE Salary (
        SalaryID INT PRIMARY KEY IDENTITY(1,1),
        UserID INT NOT NULL FOREIGN KEY REFERENCES [User](UserID),
        Month INT NOT NULL CHECK (Month BETWEEN 1 AND 12),
        Year INT NOT NULL CHECK (Year >= 2000),
        BasicSalary DECIMAL(18,2) NOT NULL CHECK (BasicSalary >= 0),
        Bonus DECIMAL(18,2) DEFAULT 0 CHECK (Bonus >= 0),
        Deductions DECIMAL(18,2) DEFAULT 0 CHECK (Deductions >= 0),
        NetSalary AS (BasicSalary + Bonus - Deductions) PERSISTED,
        RecordedDate DATETIME DEFAULT GETDATE(),
        RecordedBy INT NOT NULL FOREIGN KEY REFERENCES [User](UserID),
        CONSTRAINT UQ_Salary_UserMonthYear UNIQUE (UserID, Month, Year)
    );
    PRINT 'Salary table created successfully!';
END
ELSE
BEGIN
    PRINT 'Salary table already exists.';
END
GO

--=========================================================
-- FINANCIAL MODULE - EXPENSE TABLES
--=========================================================

-- Create Expense table
IF OBJECT_ID('Expense', 'U') IS NULL
BEGIN
    CREATE TABLE Expense (
        ExpenseID INT PRIMARY KEY IDENTITY(1,1),
        Description NVARCHAR(500) NOT NULL,
        Amount DECIMAL(18,2) NOT NULL CHECK (Amount > 0),
        Category NVARCHAR(100) NOT NULL,
        ExpenseDate DATE NOT NULL,
        RecordedDate DATETIME DEFAULT GETDATE(),
        RecordedBy INT NOT NULL FOREIGN KEY REFERENCES [User](UserID)
    );
    PRINT 'Expense table created successfully!';
END
ELSE
BEGIN
    PRINT 'Expense table already exists.';
END
GO

--=========================================================
-- SALARY STORED PROCEDURES
--=========================================================

-- sp_AddSalary: Add a new salary record
IF OBJECT_ID('sp_AddSalary', 'P') IS NOT NULL DROP PROCEDURE sp_AddSalary;
GO
CREATE PROCEDURE sp_AddSalary
    @UserID INT,
    @Month INT,
    @Year INT,
    @BasicSalary DECIMAL(18,2),
    @Bonus DECIMAL(18,2),
    @Deductions DECIMAL(18,2),
    @RecordedBy INT
AS
BEGIN
    BEGIN TRY
        -- Check if salary already exists for this user/month/year
        IF EXISTS (SELECT 1 FROM Salary WHERE UserID = @UserID AND Month = @Month AND Year = @Year)
        BEGIN
            RAISERROR('Salary record already exists for this user in the specified month/year.', 16, 1);
            RETURN;
        END

        INSERT INTO Salary (UserID, Month, Year, BasicSalary, Bonus, Deductions, RecordedBy)
        VALUES (@UserID, @Month, @Year, @BasicSalary, @Bonus, @Deductions, @RecordedBy);
        
        SELECT SCOPE_IDENTITY() AS SalaryID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- sp_GetAllSalaries: Get all salary records
IF OBJECT_ID('sp_GetAllSalaries', 'P') IS NOT NULL DROP PROCEDURE sp_GetAllSalaries;
GO
CREATE PROCEDURE sp_GetAllSalaries
AS
BEGIN
    SELECT 
        s.SalaryID,
        s.UserID,
        u.UserName,
        s.Month,
        s.Year,
        s.BasicSalary,
        s.Bonus,
        s.Deductions,
        s.NetSalary,
        s.RecordedDate,
        s.RecordedBy,
        recorded.UserName AS RecordedByName
    FROM Salary s
    INNER JOIN [User] u ON s.UserID = u.UserID
    INNER JOIN [User] recorded ON s.RecordedBy = recorded.UserID
    ORDER BY s.Year DESC, s.Month DESC, u.UserName;
END
GO

-- sp_GetSalariesByMonth: Get salary records for a specific month/year
IF OBJECT_ID('sp_GetSalariesByMonth', 'P') IS NOT NULL DROP PROCEDURE sp_GetSalariesByMonth;
GO
CREATE PROCEDURE sp_GetSalariesByMonth
    @Month INT,
    @Year INT
AS
BEGIN
    SELECT 
        s.SalaryID,
        s.UserID,
        u.UserName,
        s.Month,
        s.Year,
        s.BasicSalary,
        s.Bonus,
        s.Deductions,
        s.NetSalary,
        s.RecordedDate,
        s.RecordedBy,
        recorded.UserName AS RecordedByName
    FROM Salary s
    INNER JOIN [User] u ON s.UserID = u.UserID
    INNER JOIN [User] recorded ON s.RecordedBy = recorded.UserID
    WHERE s.Month = @Month AND s.Year = @Year
    ORDER BY u.UserName;
END
GO

-- sp_GetSalariesByUser: Get salary records for a specific user
IF OBJECT_ID('sp_GetSalariesByUser', 'P') IS NOT NULL DROP PROCEDURE sp_GetSalariesByUser;
GO
CREATE PROCEDURE sp_GetSalariesByUser
    @UserID INT
AS
BEGIN
    SELECT 
        s.SalaryID,
        s.UserID,
        u.UserName,
        s.Month,
        s.Year,
        s.BasicSalary,
        s.Bonus,
        s.Deductions,
        s.NetSalary,
        s.RecordedDate,
        s.RecordedBy,
        recorded.UserName AS RecordedByName
    FROM Salary s
    INNER JOIN [User] u ON s.UserID = u.UserID
    INNER JOIN [User] recorded ON s.RecordedBy = recorded.UserID
    WHERE s.UserID = @UserID
    ORDER BY s.Year DESC, s.Month DESC;
END
GO

-- sp_GetTotalSalaryByMonth: Get total salary for a specific month/year
IF OBJECT_ID('sp_GetTotalSalaryByMonth', 'P') IS NOT NULL DROP PROCEDURE sp_GetTotalSalaryByMonth;
GO
CREATE PROCEDURE sp_GetTotalSalaryByMonth
    @Month INT,
    @Year INT
AS
BEGIN
    SELECT ISNULL(SUM(NetSalary), 0) AS TotalSalary
    FROM Salary
    WHERE Month = @Month AND Year = @Year;
END
GO

-- sp_UpdateSalary: Update an existing salary record
IF OBJECT_ID('sp_UpdateSalary', 'P') IS NOT NULL DROP PROCEDURE sp_UpdateSalary;
GO
CREATE PROCEDURE sp_UpdateSalary
    @SalaryID INT,
    @BasicSalary DECIMAL(18,2),
    @Bonus DECIMAL(18,2),
    @Deductions DECIMAL(18,2)
AS
BEGIN
    BEGIN TRY
        UPDATE Salary
        SET BasicSalary = @BasicSalary,
            Bonus = @Bonus,
            Deductions = @Deductions
        WHERE SalaryID = @SalaryID;

        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('Salary record not found.', 16, 1);
        END
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- sp_DeleteSalary: Delete a salary record
IF OBJECT_ID('sp_DeleteSalary', 'P') IS NOT NULL DROP PROCEDURE sp_DeleteSalary;
GO
CREATE PROCEDURE sp_DeleteSalary
    @SalaryID INT
AS
BEGIN
    BEGIN TRY
        DELETE FROM Salary WHERE SalaryID = @SalaryID;

        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('Salary record not found.', 16, 1);
        END
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

--=========================================================
-- EXPENSE STORED PROCEDURES
--=========================================================

-- sp_AddExpense: Add a new expense record
IF OBJECT_ID('sp_AddExpense', 'P') IS NOT NULL DROP PROCEDURE sp_AddExpense;
GO
CREATE PROCEDURE sp_AddExpense
    @Description NVARCHAR(500),
    @Amount DECIMAL(18,2),
    @Category NVARCHAR(100),
    @ExpenseDate DATE,
    @RecordedBy INT
AS
BEGIN
    BEGIN TRY
        INSERT INTO Expense (Description, Amount, Category, ExpenseDate, RecordedBy)
        VALUES (@Description, @Amount, @Category, @ExpenseDate, @RecordedBy);
        
        SELECT SCOPE_IDENTITY() AS ExpenseID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- sp_GetAllExpenses: Get all expense records
IF OBJECT_ID('sp_GetAllExpenses', 'P') IS NOT NULL DROP PROCEDURE sp_GetAllExpenses;
GO
CREATE PROCEDURE sp_GetAllExpenses
AS
BEGIN
    SELECT 
        e.ExpenseID,
        e.Description,
        e.Amount,
        e.Category,
        e.ExpenseDate,
        e.RecordedDate,
        e.RecordedBy,
        u.UserName AS RecordedByName
    FROM Expense e
    INNER JOIN [User] u ON e.RecordedBy = u.UserID
    ORDER BY e.ExpenseDate DESC;
END
GO

-- sp_GetExpensesByDateRange: Get expenses within a date range
IF OBJECT_ID('sp_GetExpensesByDateRange', 'P') IS NOT NULL DROP PROCEDURE sp_GetExpensesByDateRange;
GO
CREATE PROCEDURE sp_GetExpensesByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        e.ExpenseID,
        e.Description,
        e.Amount,
        e.Category,
        e.ExpenseDate,
        e.RecordedDate,
        e.RecordedBy,
        u.UserName AS RecordedByName
    FROM Expense e
    INNER JOIN [User] u ON e.RecordedBy = u.UserID
    WHERE e.ExpenseDate BETWEEN @StartDate AND @EndDate
    ORDER BY e.ExpenseDate DESC;
END
GO

-- sp_GetExpensesByCategory: Get expenses by category
IF OBJECT_ID('sp_GetExpensesByCategory', 'P') IS NOT NULL DROP PROCEDURE sp_GetExpensesByCategory;
GO
CREATE PROCEDURE sp_GetExpensesByCategory
    @Category NVARCHAR(100)
AS
BEGIN
    SELECT 
        e.ExpenseID,
        e.Description,
        e.Amount,
        e.Category,
        e.ExpenseDate,
        e.RecordedDate,
        e.RecordedBy,
        u.UserName AS RecordedByName
    FROM Expense e
    INNER JOIN [User] u ON e.RecordedBy = u.UserID
    WHERE e.Category = @Category
    ORDER BY e.ExpenseDate DESC;
END
GO

-- sp_GetTotalExpensesByMonth: Get total expenses for a specific month/year
IF OBJECT_ID('sp_GetTotalExpensesByMonth', 'P') IS NOT NULL DROP PROCEDURE sp_GetTotalExpensesByMonth;
GO
CREATE PROCEDURE sp_GetTotalExpensesByMonth
    @Month INT,
    @Year INT
AS
BEGIN
    SELECT ISNULL(SUM(Amount), 0) AS TotalExpenses
    FROM Expense
    WHERE MONTH(ExpenseDate) = @Month AND YEAR(ExpenseDate) = @Year;
END
GO

-- sp_UpdateExpense: Update an existing expense record
IF OBJECT_ID('sp_UpdateExpense', 'P') IS NOT NULL DROP PROCEDURE sp_UpdateExpense;
GO
CREATE PROCEDURE sp_UpdateExpense
    @ExpenseID INT,
    @Description NVARCHAR(500),
    @Amount DECIMAL(18,2),
    @Category NVARCHAR(100),
    @ExpenseDate DATE
AS
BEGIN
    BEGIN TRY
        UPDATE Expense
        SET Description = @Description,
            Amount = @Amount,
            Category = @Category,
            ExpenseDate = @ExpenseDate
        WHERE ExpenseID = @ExpenseID;

        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('Expense record not found.', 16, 1);
        END
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- sp_DeleteExpense: Delete an expense record
IF OBJECT_ID('sp_DeleteExpense', 'P') IS NOT NULL DROP PROCEDURE sp_DeleteExpense;
GO
CREATE PROCEDURE sp_DeleteExpense
    @ExpenseID INT
AS
BEGIN
    BEGIN TRY
        DELETE FROM Expense WHERE ExpenseID = @ExpenseID;

        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('Expense record not found.', 16, 1);
        END
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

--=========================================================
-- FINANCIAL REPORTS PROCEDURES
--=========================================================

-- sp_GetSalesReportByDateRange: Get sales report with details
IF OBJECT_ID('sp_GetSalesReportByDateRange', 'P') IS NOT NULL DROP PROCEDURE sp_GetSalesReportByDateRange;
GO
CREATE PROCEDURE sp_GetSalesReportByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        s.SaleID,
        s.SaleDate,
        u.UserName,
        ISNULL(c.CustomerName, 'Walk-in') AS CustomerName,
        s.TotalAmount
    FROM Sale s
    INNER JOIN [User] u ON s.UserID = u.UserID
    LEFT JOIN Customer c ON s.CustomerID = c.CustomerID
    WHERE s.SaleDate BETWEEN @StartDate AND @EndDate
    ORDER BY s.SaleDate DESC;
END
GO

-- sp_GetPurchasesReportByDateRange: Get purchases report with details
IF OBJECT_ID('sp_GetPurchasesReportByDateRange', 'P') IS NOT NULL DROP PROCEDURE sp_GetPurchasesReportByDateRange;
GO
CREATE PROCEDURE sp_GetPurchasesReportByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        p.PurchaseID,
        p.PurchaseDate,
        s.SupplierName,
        u.UserName,
        p.TotalAmount
    FROM Purchase p
    INNER JOIN Supplier s ON p.SupplierID = s.SupplierID
    INNER JOIN [User] u ON p.UserID = u.UserID
    WHERE p.PurchaseDate BETWEEN @StartDate AND @EndDate
    ORDER BY p.PurchaseDate DESC;
END
GO

-- sp_GetSalariesReportByDateRange: Get salaries report for a date range
IF OBJECT_ID('sp_GetSalariesReportByDateRange', 'P') IS NOT NULL DROP PROCEDURE sp_GetSalariesReportByDateRange;
GO
CREATE PROCEDURE sp_GetSalariesReportByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        s.SalaryID,
        u.UserName,
        s.Month,
        s.Year,
        s.BasicSalary,
        s.Bonus,
        s.Deductions,
        s.NetSalary,
        s.RecordedDate
    FROM Salary s
    INNER JOIN [User] u ON s.UserID = u.UserID
    WHERE (
        (s.Year * 12 + s.Month) >= (YEAR(@StartDate) * 12 + MONTH(@StartDate))
        AND (s.Year * 12 + s.Month) <= (YEAR(@EndDate) * 12 + MONTH(@EndDate))
    )
    ORDER BY s.Year DESC, s.Month DESC, u.UserName;
END
GO

-- sp_GetFinancialSummary: Get financial summary for reports
IF OBJECT_ID('sp_GetFinancialSummary', 'P') IS NOT NULL DROP PROCEDURE sp_GetFinancialSummary;
GO
CREATE PROCEDURE sp_GetFinancialSummary
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    DECLARE @TotalSales DECIMAL(18,2);
    DECLARE @TotalPurchases DECIMAL(18,2);
    DECLARE @TotalSalaries DECIMAL(18,2);
    DECLARE @TotalExpenses DECIMAL(18,2);
    DECLARE @NetProfit DECIMAL(18,2);

    -- Calculate total sales
    SELECT @TotalSales = ISNULL(SUM(TotalAmount), 0)
    FROM Sale
    WHERE SaleDate BETWEEN @StartDate AND @EndDate;

    -- Calculate total purchases
    SELECT @TotalPurchases = ISNULL(SUM(TotalAmount), 0)
    FROM Purchase
    WHERE PurchaseDate BETWEEN @StartDate AND @EndDate;

    -- Calculate total salaries (for months within the date range)
    SELECT @TotalSalaries = ISNULL(SUM(NetSalary), 0)
    FROM Salary
    WHERE (
        (Year * 12 + Month) >= (YEAR(@StartDate) * 12 + MONTH(@StartDate))
        AND (Year * 12 + Month) <= (YEAR(@EndDate) * 12 + MONTH(@EndDate))
    );

    -- Calculate total expenses
    SELECT @TotalExpenses = ISNULL(SUM(Amount), 0)
    FROM Expense
    WHERE ExpenseDate BETWEEN @StartDate AND @EndDate;

    -- Calculate net profit
    SET @NetProfit = @TotalSales - @TotalPurchases - @TotalSalaries - @TotalExpenses;

    -- Return summary
    SELECT 
        @TotalSales AS TotalSales,
        @TotalPurchases AS TotalPurchases,
        @TotalSalaries AS TotalSalaries,
        @TotalExpenses AS TotalExpenses,
        @NetProfit AS NetProfit;
END
GO

-- sp_GetBatchDetails: Get detailed information about a specific batch
IF OBJECT_ID('sp_GetBatchDetails', 'P') IS NOT NULL DROP PROCEDURE sp_GetBatchDetails;
GO
CREATE PROCEDURE sp_GetBatchDetails
    @BatchID INT
AS
BEGIN
    SELECT 
        mb.BatchID,
        mb.BatchNumber,
        mb.ExpiryDate,
        mb.PurchasePrice,
        mb.QuantityInStock,
        m.Name AS MedicineName,
        m.StrengthMG,
        m.MinimumStockLevel,
        m.IsPrescriptionRequired,
        c.CategoryName,
        mf.ManufacturerName,
        f.FormulaName,
        s.SupplierName,
        s.Contact AS SupplierContact,
        s.Address AS SupplierAddress,
        p.PurchaseDate,
        u.UserName AS PurchasedBy
    FROM MedicineBatch mb
    INNER JOIN Medicine m ON mb.MedicineID = m.MedicineID
    INNER JOIN Category c ON m.CategoryID = c.CategoryID
    INNER JOIN Manufacturer mf ON m.ManufacturerID = mf.ManufacturerID
    INNER JOIN Formula f ON m.FormulaID = f.FormulaID
    INNER JOIN Supplier s ON mb.SupplierID = s.SupplierID
    LEFT JOIN Purchase p ON mb.PurchaseID = p.PurchaseID
    LEFT JOIN [User] u ON p.UserID = u.UserID
    WHERE mb.BatchID = @BatchID;
END
GO

-- sp_GetMedicineDetails: Get detailed information about a specific medicine
IF OBJECT_ID('sp_GetMedicineDetails', 'P') IS NOT NULL DROP PROCEDURE sp_GetMedicineDetails;
GO
CREATE PROCEDURE sp_GetMedicineDetails
    @MedicineID INT
AS
BEGIN
    SELECT 
        m.MedicineID,
        m.Name AS MedicineName,
        m.StrengthMG,
        m.MinimumStockLevel,
        m.IsPrescriptionRequired,
        m.IsActive,
        c.CategoryName,
        mf.ManufacturerName,
        f.FormulaName,
        ISNULL(SUM(mb.QuantityInStock), 0) AS TotalStock,
        COUNT(mb.BatchID) AS TotalBatches
    FROM Medicine m
    INNER JOIN Category c ON m.CategoryID = c.CategoryID
    INNER JOIN Manufacturer mf ON m.ManufacturerID = mf.ManufacturerID
    INNER JOIN Formula f ON m.FormulaID = f.FormulaID
    LEFT JOIN MedicineBatch mb ON m.MedicineID = mb.MedicineID
    WHERE m.MedicineID = @MedicineID
    GROUP BY m.MedicineID, m.Name, m.StrengthMG, m.MinimumStockLevel, 
             m.IsPrescriptionRequired, m.IsActive, c.CategoryName, 
             mf.ManufacturerName, f.FormulaName;
END
GO

--=========================================================
-- DATABASE TRIGGERS FOR DATE VALIDATION
--=========================================================

-- Trigger to prevent future expense dates
IF OBJECT_ID('trg_ValidateExpenseDate', 'TR') IS NOT NULL DROP TRIGGER trg_ValidateExpenseDate;
GO
CREATE TRIGGER trg_ValidateExpenseDate
ON Expense
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    IF EXISTS (SELECT 1 FROM inserted WHERE ExpenseDate > CAST(GETDATE() AS DATE))
    BEGIN
        RAISERROR('Expense date cannot be in the future.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END
GO

-- Trigger to validate salary month/year is not in future
IF OBJECT_ID('trg_ValidateSalaryDate', 'TR') IS NOT NULL DROP TRIGGER trg_ValidateSalaryDate;
GO
CREATE TRIGGER trg_ValidateSalaryDate
ON Salary
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @CurrentYear INT = YEAR(GETDATE());
    DECLARE @CurrentMonth INT = MONTH(GETDATE());
    
    IF EXISTS (
        SELECT 1 FROM inserted 
        WHERE (Year > @CurrentYear) 
           OR (Year = @CurrentYear AND Month > @CurrentMonth)
    )
    BEGIN
        RAISERROR('Salary cannot be recorded for future months.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END
GO

--=========================================================
-- STORED PROCEDURES AND TRIGGERS CREATED SUCCESSFULLY
--=========================================================
PRINT 'All stored procedures and triggers have been created successfully!';
GO
