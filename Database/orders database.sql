USE [master]
GO
/****** Object:  Database [Orders]    Script Date: 5.1.2015 г. 14:38:32 ******/
CREATE DATABASE [Orders]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Orders', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Orders.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Orders_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Orders_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Orders] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Orders].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Orders] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Orders] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Orders] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Orders] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Orders] SET ARITHABORT OFF 
GO
ALTER DATABASE [Orders] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Orders] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Orders] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Orders] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Orders] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Orders] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Orders] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Orders] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Orders] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Orders] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Orders] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Orders] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Orders] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Orders] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Orders] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Orders] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Orders] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Orders] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Orders] SET RECOVERY FULL 
GO
ALTER DATABASE [Orders] SET  MULTI_USER 
GO
ALTER DATABASE [Orders] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Orders] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Orders] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Orders] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Orders', N'ON'
GO
USE [Orders]
GO
/****** Object:  StoredProcedure [dbo].[deleteBook]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteBook] @BookId int
as
declare @SQLString nvarchar(500)
declare @ParamDefinition nvarchar(500)
set @SQLString = N'delete from Books where BookId = @BookId';

SET @ParamDefinition = N' @BookId int';

EXECUTE sp_executesql @SQLString,
					  @ParamDefinition, 
					  @BookId = @BookId;


GO
/****** Object:  StoredProcedure [dbo].[deleteOrder]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteOrder] @OrderId int
as
declare @SQLString nvarchar(500)
declare @ParamDefinition nvarchar(500)
set @SQLString = N'delete from Orders where OrderId = @OrderId';

SET @ParamDefinition = N' @OrderId int';

EXECUTE sp_executesql @SQLString,
					  @ParamDefinition, 
					  @OrderId = @OrderId;


GO
/****** Object:  StoredProcedure [dbo].[deleteTransport]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteTransport] @TransportId int
as
declare @SQLString nvarchar(500)
declare @ParamDefinition nvarchar(500)
set @SQLString = N'delete from Transports where TransportId = @TransportId';

SET @ParamDefinition = N' @TransportId int';

EXECUTE sp_executesql @SQLString,
					  @ParamDefinition, 
					  @TransportId = @TransportId;


GO
/****** Object:  StoredProcedure [dbo].[deleteUser]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteUser] @UserId int
as
declare @SQLString nvarchar(500)
declare @ParamDefinition nvarchar(500)
set @SQLString = N'delete from Users where UserId = @UserId';

SET @ParamDefinition = N' @UserId int';

EXECUTE sp_executesql @SQLString,
					  @ParamDefinition, 
					  @UserId = @UserId;


GO
/****** Object:  StoredProcedure [dbo].[findBooksByUsernameTransportDateOrderId]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[findBooksByUsernameTransportDateOrderId] @User nvarchar(50), @Date datetime, @OrderId int
as
declare @SQLString nvarchar(500)
declare @ParamDefinition nvarchar(500)
set @SQLString = N'select b.BookId, b.Title, b.ISBN, b.OrderedCount, b.ModificationDate, o.OrderId, u.Username, t.StartOffDate
	from Books b 
	inner join Users u
	on b.UserId = u.UserId
	inner join Orders o
	on b.OrderId = o.OrderId
	inner join Transports t
	on o.TransportId = t.TransportId
	where b.OrderId like @OrderId
	and u.Username like @Username 
	and t.StartOffDate =  @TransportDate';

SET @ParamDefinition = N' @Username nvarchar(50), @TransportDate datetime, @OrderId nvarchar(200)';

EXECUTE sp_executesql @SQLString,
					  @ParamDefinition, 
					  @Username = @User,@TransportDate = @Date, @OrderId = @OrderId;


GO
/****** Object:  StoredProcedure [dbo].[findBooksByUsernameTransportDateTitle]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[findBooksByUsernameTransportDateTitle] @User nvarchar(50), @Date datetime, @BookTitle nvarchar(100)
as
declare @SQLString nvarchar(500)
declare @ParamDefinition nvarchar(500)
set @SQLString = N'select b.BookId, b.Title, b.ISBN, b.OrderedCount, b.ModificationDate, o.OrderId, u.Username, t.StartOffDate
	from Books b 
	inner join Users u
	on b.UserId = u.UserId
	inner join Orders o
	on b.OrderId = o.OrderId
	inner join Transports t
	on o.TransportId = t.TransportId
	where b.Title like @Title
	and u.Username like @Username 
	and t.StartOffDate =  @TransportDate';

SET @ParamDefinition = N' @Username nvarchar(50), @TransportDate datetime, @Title nvarchar(200)';

EXECUTE sp_executesql @SQLString,
					  @ParamDefinition, 
					  @Username = @User,@TransportDate = @Date, @Title = @BookTitle;


GO
/****** Object:  StoredProcedure [dbo].[findOrdersByUsernameTransportDateAddress]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[findOrdersByUsernameTransportDateAddress] @User nvarchar(50), @Date datetime, @Address nvarchar(200)
as
declare @SQLString nvarchar(500)
declare @ParamDefinition nvarchar(500)
set @SQLString = N'select o.OrderId, o.Country, o.DeliveryAddress, o.ModificationDate, u.Username, t.StartOffDate from Orders o 
	inner join Users u
	on o.UserId = u.UserId
	inner join Transports t
	on o.TransportId = t.TransportId
	where o.DeliveryAddress like  @DeliveryAddress
	and u.Username like @Username 
	and t.StartOffDate =  @TransportDate';

SET @ParamDefinition = N' @Username nvarchar(50), @TransportDate datetime, @DeliveryAddress nvarchar(200)';

EXECUTE sp_executesql @SQLString,
					  @ParamDefinition, 
					  @Username = @User,@TransportDate = @Date, @DeliveryAddress = @Address;


GO
/****** Object:  StoredProcedure [dbo].[insertBook]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertBook] @Title nvarchar(100), @ISBN nvarchar(15), @OrderedCount int, @OrderId int, @UserId int
as
declare @SQLString nvarchar(500)
declare @ParamDefinition nvarchar(500)
set @SQLString = N'insert into Books (Title, ISBN, OrderedCount, OrderId, UserId) 
				values (@Title, @ISBN, @OrderedCount, @OrderId, @UserId)';

SET @ParamDefinition = N' @Title nvarchar(100), @ISBN nvarchar(15), @OrderedCount int, @OrderId int, @UserId int';

EXECUTE sp_executesql @SQLString,
					  @ParamDefinition, 
					  @Title = @Title,@ISBN = @ISBN, @OrderedCount = @OrderedCount, @OrderId = @OrderId, @UserId = @UserId;


GO
/****** Object:  StoredProcedure [dbo].[insertOrder]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertOrder] @DeliveryAddress nvarchar(200), @Country nvarchar(50), @UserId int, @TransportId int
as
declare @SQLString nvarchar(500)
declare @ParamDefinition nvarchar(500)
set @SQLString = N'insert into Orders (DeliveryAddress, Country, UserId, TransportId) 
				values (@DeliveryAddress, @Country, @UserId, @TransportId)';

SET @ParamDefinition = N' @DeliveryAddress nvarchar(200), @Country nvarchar(50), @UserId int, @TransportId int';

EXECUTE sp_executesql @SQLString,
					  @ParamDefinition, 
					  @DeliveryAddress = @DeliveryAddress,@Country = @Country, @UserId = @UserId, @TransportId = @TransportId;


GO
/****** Object:  StoredProcedure [dbo].[insertTransport]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertTransport] @StartOffDate date
as
declare @SQLString nvarchar(500)
declare @ParamDefinition nvarchar(500)
set @SQLString = N'insert into Transports (StartOffDate)
				values (@StartOffDate)';

SET @ParamDefinition = N' @StartOffDate date';

EXECUTE sp_executesql @SQLString,
					  @ParamDefinition, 
					  @StartOffDate = @StartOffDate;


GO
/****** Object:  StoredProcedure [dbo].[insertUser]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertUser] @Username nvarchar(50), @Password nvarchar(20), @FirstName nvarchar(20), @LastName nvarchar(20)
as
declare @SQLString nvarchar(500)
declare @ParamDefinition nvarchar(500)
set @SQLString = N'insert into Users (Username, Password, FirstName, LastName) 
				values (@Username, @Password, @FirstName, @LastName)';

SET @ParamDefinition = N' @Username nvarchar(50), @Password nvarchar(20), @FirstName nvarchar(20), @LastName nvarchar(20)';

EXECUTE sp_executesql @SQLString,
					  @ParamDefinition, 
					  @Username = @Username,@Password = @Password, @FirstName = @FirstName, @LastName = @LastName;


GO
/****** Object:  StoredProcedure [dbo].[Search]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Search]
	@strIDs VarChar(100)
AS
SELECT * 
FROM Transports
WHERE 	TransportId in (@strIDs)


GO
/****** Object:  StoredProcedure [dbo].[test]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[test]
as
begin

select * from users;

end
GO
/****** Object:  UserDefinedFunction [dbo].[validateUser]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[validateUser] (@username nvarchar(50), @password nvarchar(20))
RETURNS INT
AS BEGIN
	DECLARE @IsValid INT
	SET @IsValid = (SELECT count(*) FROM Users 
									WHERE Username like @username and 
									Password like  @password)
	RETURN @IsValid
END;

GO
/****** Object:  Table [dbo].[Books]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[ISBN] [nvarchar](15) NOT NULL,
	[OrderedCount] [int] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[OrderId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Journal]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Journal](
	[JournalId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Operation] [varchar](10) NOT NULL,
	[TableName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED 
(
	[JournalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[DeliveryAddress] [nvarchar](200) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[TransportId] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transports]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transports](
	[TransportId] [int] IDENTITY(1,1) NOT NULL,
	[StartOffDate] [date] NOT NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Transports] PRIMARY KEY CLUSTERED 
(
	[TransportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 5.1.2015 г. 14:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[ModificationDate] [datetime] NULL,
	[Username] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EmployeeUser] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_Username]    Script Date: 5.1.2015 г. 14:38:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Username] ON [dbo].[Users]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Orders]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Users]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Transports] FOREIGN KEY([TransportId])
REFERENCES [dbo].[Transports] ([TransportId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Transports]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
USE [master]
GO
ALTER DATABASE [Orders] SET  READ_WRITE 
GO
