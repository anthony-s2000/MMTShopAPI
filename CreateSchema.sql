CREATE DATABASE MMTShop;
GO

USE MMTShop;
GO

/*****************/
/* Create tables */
/*****************/
CREATE TABLE Products (
	[SKU]			NVARCHAR(6) NOT NULL,
	[Name]			NVARCHAR(50) NOT NULL,
	[Description]		NVARCHAR(200) NOT NULL,	
	[Price]			DECIMAL(18,2) NOT NULL,
	[CategoryID]		INT,
	CONSTRAINT PK_SKU PRIMARY KEY (SKU)
)
GO

CREATE TABLE Category (
	[ID]			INT NOT NULL,
	[Name]			NVARCHAR(20) NOT NULL
	CONSTRAINT PK_ID PRIMARY KEY (ID)
)
GO



/****************************/
/* Create Stored Procedures */
/****************************/

CREATE PROCEDURE [dbo].[sp_getAllCategories]
AS
BEGIN
	SELECT 
	ID,
	Name 
	FROM Category
END
GO

CREATE PROCEDURE [dbo].[sp_getAllProducts]
AS
BEGIN
	SELECT 
	SKU,
	Name,	
	Description,
	Price,
	CategoryID
	FROM Products
END
GO

CREATE PROCEDURE [dbo].[sp_getFeaturedProducts] 
AS
BEGIN
	SELECT 
	SKU,
	Name,
	Description,
	Price,
	CategoryID
	FROM Products where left(SKU,1) in ('1','2','3')
END
GO


/********************/
/* Create demo data */
/********************/
INSERT INTO Products (SKU,Name,Description,Price,CategoryID) VALUES ('100001','Blue Dbl Duvet Set','Blue double duvet set with 2x pillow cases.',15.99,1);
INSERT INTO Products (SKU,Name,Description,Price,CategoryID) VALUES ('100002','White King Duvet Set','White king size duvet set with 2x pillow cases.',18.99,1);
INSERT INTO Products (SKU,Name,Description,Price,CategoryID) VALUES ('200001','Bird Feeder - Seed','Bird feeder with 4 outlets for mixed seed use.',10.99,2);
INSERT INTO Products (SKU,Name,Description,Price,CategoryID) VALUES ('300001','Zoomie Digital Camera','100MP digital camera with 100x optical zoom.',10.99,3);
INSERT INTO Products (SKU,Name,Description,Price,CategoryID) VALUES ('400001','Run Boy! Treadmill','Motorised treadmill - 20kph, 18 levels of incline.',675.98,4);
INSERT INTO Products (SKU,Name,Description,Price,CategoryID) VALUES ('500001','Super Plush!','Super hero plush toy, with multiple costumes.',22.97,5);
GO

INSERT INTO Category (ID, Name) VALUES (1, 'Home');
INSERT INTO Category (ID, Name) VALUES (2, 'Garden');
INSERT INTO Category (ID, Name) VALUES (3, 'Electronics');
INSERT INTO Category (ID, Name) VALUES (4, 'Fitness');
INSERT INTO Category (ID, Name) VALUES (5, 'Toys');
GO

