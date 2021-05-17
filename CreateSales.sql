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
ALTER TABLE dbo.customer SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.salesperson SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.products SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.sales
	(
	id int NOT NULL IDENTITY (1, 1),
	product int NOT NULL,
	salesperson int NOT NULL,
	customer int NOT NULL,
	sales_date datetime NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.sales ADD CONSTRAINT
	PK_Table_1_2 PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.sales ADD CONSTRAINT
	FK_Table_1_products1 FOREIGN KEY
	(
	product
	) REFERENCES dbo.products
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.sales ADD CONSTRAINT
	FK_Table_1_salesperson FOREIGN KEY
	(
	salesperson
	) REFERENCES dbo.salesperson
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.sales ADD CONSTRAINT
	FK_Table_1_customer FOREIGN KEY
	(
	customer
	) REFERENCES dbo.customer
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.sales SET (LOCK_ESCALATION = TABLE)
GO
COMMIT