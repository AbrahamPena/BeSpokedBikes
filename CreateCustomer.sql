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
CREATE TABLE dbo.customer
	(
	id int NOT NULL IDENTITY (1, 1),
	first_name varchar(50) NOT NULL,
	last_name varchar(50) NOT NULL,
	address varchar(128) NULL,
	phone varchar(20) NULL,
	start_date datetime NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.customer ADD CONSTRAINT
	PK_Table2 PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.customer SET (LOCK_ESCALATION = TABLE)
GO
COMMIT