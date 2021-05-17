/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.products SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.discount
	(
	product int NOT NULL,
	begin_date datetime NOT NULL,
	end_date datetime NOT NULL,
	discount_percentage decimal(4, 4) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.discount ADD CONSTRAINT
	FK_Table_1_products FOREIGN KEY
	(
	product
	) REFERENCES dbo.products
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.discount SET (LOCK_ESCALATION = TABLE)
GO
COMMIT