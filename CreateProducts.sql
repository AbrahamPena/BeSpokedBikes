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
CREATE TABLE dbo.products
	(
	id int NOT NULL IDENTITY (1, 1),
	name varchar(50) NOT NULL,
	manufacturer int NOT NULL,
	style int NOT NULL,
	purchase_price decimal(9, 4) NULL,
	sale_price decimal(9, 4) NULL,
	qty_available int NOT NULL,
	commision_percent decimal(6, 4) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.products ADD CONSTRAINT
	PK_Table3 PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.products SET (LOCK_ESCALATION = TABLE)
GO
COMMIT