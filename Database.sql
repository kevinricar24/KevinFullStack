

USE [DBEmployee]

/****** Object:  Table [dbo].[Department] ******/

CREATE TABLE [dbo].[Department](
	[IdDepartment] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[CreationDate] [datetime] DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[IdDepartment] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Employee] ******/

CREATE TABLE [dbo].[Employee](
	[IdEmployee] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](50) NULL,
	[IdDepartment] [int] NOT NULL,
	[Salary] [int] NULL,
	[ContractDate] [datetime] NULL,
	[CreationDate] [datetime] DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[IdEmployee] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([IdDepartment])
REFERENCES [dbo].[Department] ([IdDepartment])
GO

/****** Data:  Table [dbo].[Department] ******/

INSERT INTO dbo.department(Name) VALUES ('Administration'), ('Marketing'), ('Sales'), ('Commerce')

/****** Data:  Table [dbo].[Employee] ******/

INSERT INTO dbo.employee(FullName, IdDepartment, Salary, ContractDate) VALUES ('Kevin Sejin', 1, 4600, GETDATE())