USE [master]
GO
/****** Object:  Database [library_prac2021]    Script Date: 06.07.2021 14:50:59 ******/
CREATE DATABASE [library_prac2021]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'library_prac2021', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\library_prac2021.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'library_prac2021_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\library_prac2021_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [library_prac2021] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [library_prac2021].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [library_prac2021] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [library_prac2021] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [library_prac2021] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [library_prac2021] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [library_prac2021] SET ARITHABORT OFF 
GO
ALTER DATABASE [library_prac2021] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [library_prac2021] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [library_prac2021] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [library_prac2021] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [library_prac2021] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [library_prac2021] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [library_prac2021] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [library_prac2021] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [library_prac2021] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [library_prac2021] SET  DISABLE_BROKER 
GO
ALTER DATABASE [library_prac2021] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [library_prac2021] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [library_prac2021] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [library_prac2021] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [library_prac2021] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [library_prac2021] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [library_prac2021] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [library_prac2021] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [library_prac2021] SET  MULTI_USER 
GO
ALTER DATABASE [library_prac2021] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [library_prac2021] SET DB_CHAINING OFF 
GO
ALTER DATABASE [library_prac2021] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [library_prac2021] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [library_prac2021] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [library_prac2021] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [library_prac2021] SET QUERY_STORE = OFF
GO
USE [library_prac2021]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Publication_date] [date] NULL,
	[Text] [nvarchar](max) NULL,
	[Book_itself] [varbinary](max) NULL,
	[File_name] [nvarchar](256) NULL,
	[Added_by_username] [varchar](20) NOT NULL,
	[AuthorID] [bigint] NOT NULL,
 CONSTRAINT [PK_Books_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[TestFindFunc]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[TestFindFunc] 
(
	@name nvarchar(50)
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT Books.Name 
	From library_prac2021.dbo.Books
	Where  Books.Name Like '%' + N'' +@name + '%' 
)
GO
/****** Object:  Table [dbo].[Admins_password]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins_password](
	[Password] [nvarchar](8) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Secondname] [nvarchar](40) NULL,
	[Firstname] [nvarchar](40) NOT NULL,
	[Birth_date] [date] NOT NULL,
 CONSTRAINT [PK_Authors_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book_Genres]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_Genres](
	[BookID] [bigint] NOT NULL,
	[GenreID] [bigint] NOT NULL,
 CONSTRAINT [PK_Book_Genres] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC,
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Genre_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Favorite_Book]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Favorite_Book](
	[Username] [nvarchar](20) NOT NULL,
	[BookID] [bigint] NOT NULL,
 CONSTRAINT [PK_User_Favorite_Book] PRIMARY KEY CLUSTERED 
(
	[Username] ASC,
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Username] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Custom_name] [nvarchar](20) NULL,
	[Sex] [bit] NOT NULL,
	[Register_date] [datetime] NOT NULL,
	[Is_Admin] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book_Genres]  WITH CHECK ADD  CONSTRAINT [FK_Book_Genres_Books] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Book_Genres] CHECK CONSTRAINT [FK_Book_Genres_Books]
GO
ALTER TABLE [dbo].[Book_Genres]  WITH CHECK ADD  CONSTRAINT [FK_Book_Genres_Genre] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genre] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Book_Genres] CHECK CONSTRAINT [FK_Book_Genres_Genre]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Authors] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Authors]
GO
ALTER TABLE [dbo].[User_Favorite_Book]  WITH CHECK ADD  CONSTRAINT [FK_User_Favorite_Book_Books] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User_Favorite_Book] CHECK CONSTRAINT [FK_User_Favorite_Book_Books]
GO
ALTER TABLE [dbo].[User_Favorite_Book]  WITH CHECK ADD  CONSTRAINT [FK_User_Favorite_Book_Users] FOREIGN KEY([Username])
REFERENCES [dbo].[Users] ([Username])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User_Favorite_Book] CHECK CONSTRAINT [FK_User_Favorite_Book_Users]
GO
/****** Object:  StoredProcedure [dbo].[Add_author]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_author]
	@Secondname nvarchar(40),
	@Firstname nvarchar(40),
	@birth_date date
AS
BEGIN

	Insert into Authors values (N'' +@Secondname, N'' + @Firstname, @birth_date)

END
GO
/****** Object:  StoredProcedure [dbo].[Add_book]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_book]
	@name nvarchar(50),
	@description nvarchar(max),
	@publication_date date,
	@added_by_username nvarchar(20),
	@authorID bigint,
	@text nvarchar(max) = null,
	@book varbinary(max) = null,
	@file_name nvarchar(256) = null

AS
BEGIN
	
	Insert into library_prac2021.dbo.Books values (@name, @description, @publication_date, @text, @book, @file_name, @added_by_username, @authorID)

END
GO
/****** Object:  StoredProcedure [dbo].[Add_book_to_favorite]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Add_book_to_favorite]
	@username nvarchar(20),
	@BookID bigint

AS
BEGIN
	
	Insert into library_prac2021.dbo.User_Favorite_Book values (@username, @BookID)

END
GO
/****** Object:  StoredProcedure [dbo].[Add_genre]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_genre]
	@name nvarchar(30),
	@description nvarchar(max) = null
AS
BEGIN
	
	Insert into library_prac2021.dbo.Genre values (@name, @description)

END
GO
/****** Object:  StoredProcedure [dbo].[Add_genre_to_book]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Add_genre_to_book]
	@BookID bigint,
	@GenreID bigint
AS
BEGIN

	Insert into Book_Genres values (@BookID, @GenreID)

END
GO
/****** Object:  StoredProcedure [dbo].[Add_user]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_user]
	@username nvarchar(20), 
	@password nvarchar(20),
	@Sex bit,
	@Is_admin bit = 0,
	@Custom_name nvarchar(20) = null
AS
BEGIN
	Insert into library_prac2021.dbo.Users values (@username, @password, N'' + @Custom_name, @Sex, GETDATE(), @Is_admin)
    
END
GO
/****** Object:  StoredProcedure [dbo].[Check_admin_pass]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Check_admin_pass]
	@password nvarchar(8)
AS
BEGIN

	Select Top 1 Admins_password.Password
	From library_prac2021.dbo.Admins_password
	Where Admins_password.Password = @password
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_all_fav_book_from_user]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Delete_all_fav_book_from_user]
	@username nvarchar(20)

AS
BEGIN

	Delete From library_prac2021.dbo.User_Favorite_Book 
	Where Username = @username

END
GO
/****** Object:  StoredProcedure [dbo].[Delete_all_genres_from_book]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Delete_all_genres_from_book]
	@BookID bigint
AS
BEGIN

	Delete From library_prac2021.dbo.Book_Genres 
	Where BookID = @BookID

END
GO
/****** Object:  StoredProcedure [dbo].[Delete_author]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Delete_author]
	@ID bigint
AS
BEGIN

	Delete From library_prac2021.dbo.Authors 
	Where ID = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[Delete_book_by_id]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Delete_book_by_id]
	@ID bigint
AS
BEGIN

	Delete From library_prac2021.dbo.Books
	Where ID = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[Delete_connection_fav_book_with_users]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Delete_connection_fav_book_with_users]
	@BookID bigint

AS
BEGIN

	Delete From library_prac2021.dbo.User_Favorite_Book 
	Where BookID = @BookID

END
GO
/****** Object:  StoredProcedure [dbo].[Delete_connection_of_genre_with_books]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Delete_connection_of_genre_with_books]
	@GenreID bigint
AS
BEGIN

	Delete From library_prac2021.dbo.Book_Genres 
	Where GenreID = @GenreID

END
GO
/****** Object:  StoredProcedure [dbo].[Delete_fav_book_from_user]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Delete_fav_book_from_user]
	@username nvarchar(20),
	@BookID bigint
AS
BEGIN

	Delete From library_prac2021.dbo.User_Favorite_Book 
	Where BookID = @BookID and Username = @username

END
GO
/****** Object:  StoredProcedure [dbo].[Delete_genre]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Delete_genre]
	@ID bigint

AS
BEGIN
	
	Delete from library_prac2021.dbo.Genre 
	where ID = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[Delete_genre_from_book]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Delete_genre_from_book]
	@BookID bigint,
	@GenreID bigint
AS
BEGIN

	Delete From library_prac2021.dbo.Book_Genres 
	Where BookID = @BookID and GenreID = @GenreID

END
GO
/****** Object:  StoredProcedure [dbo].[Delete_user]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Delete_user]
	@username nvarchar(20)
AS
BEGIN

	Delete From library_prac2021.dbo.Users
	Where Users.username = @username
    
END
GO
/****** Object:  StoredProcedure [dbo].[Find_authors]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Find_authors]
	@author nvarchar(100)
AS
BEGIN
	Declare @author_concat nvarchar(100)

	Select *
	From library_prac2021.dbo.Authors
	Where Authors.Secondname + ' ' + Authors.Firstname like '%' + @author + '%'
	Order by Authors.Secondname 

END
GO
/****** Object:  StoredProcedure [dbo].[Find_books_by_author]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Find_books_by_author]
	@author nvarchar(100)
AS
BEGIN
	Declare @author_concat nvarchar(100)

	Select Books.ID, Books.Name, Books.Description, Books.Publication_date, Books.Added_by_username, Books.AuthorID
	From library_prac2021.dbo.Books Join library_prac2021.dbo.Authors on Books.AuthorID = Authors.ID
	Where Authors.Secondname + ' ' + Authors.Firstname like '%' + @author + '%'
	Order by Books.Name 

END
GO
/****** Object:  StoredProcedure [dbo].[Find_books_by_genre]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Find_books_by_genre]
	@genre nvarchar(30)
AS
BEGIN

	Select Books.ID, Books.Name, Books.Description, Books.Publication_date, Books.Added_by_username, Books.AuthorID
	From library_prac2021.dbo.Books Join Book_Genres on Books.ID = Book_Genres.BookID
									Join library_prac2021.dbo.Genre on Book_Genres.GenreID = Genre.ID

	Where Genre.Name like '%' + @genre + '%'
	Order by Books.Name 

END
GO
/****** Object:  StoredProcedure [dbo].[Find_books_by_name]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Find_books_by_name]
	@name nvarchar(50)
AS
BEGIN

	Select ID, Name, Description, Publication_date, Added_by_username, AuthorID
	From library_prac2021.dbo.Books
	Where Books.Name Like '%' + @name + '%'
	Order by Books.Name 

END
GO
/****** Object:  StoredProcedure [dbo].[Find_books_by_year]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Find_books_by_year]
	@year1 bigint
AS
BEGIN

	Select Books.ID, Books.Name, Books.Description, Books.Publication_date, Books.Added_by_username, Books.AuthorID
	From library_prac2021.dbo.Books
	Where YEAR(Publication_date) = @year1
	Order by Books.Name 

END
GO
/****** Object:  StoredProcedure [dbo].[Find_books_by_year_multiple]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Find_books_by_year_multiple]
	@year1 bigint,
	@year2 bigint
AS
BEGIN

	Select Books.ID, Books.Name, Books.Description, Books.Publication_date, Books.Added_by_username, Books.AuthorID
	From library_prac2021.dbo.Books
	Where YEAR(Publication_date) between @year1 and @year2
	Order by Books.Name 

END
GO
/****** Object:  StoredProcedure [dbo].[Get_all_authors]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get_all_authors]

AS
BEGIN

	Select *
	From library_prac2021.dbo.Authors
	Order by Authors.Secondname    
END
GO
/****** Object:  StoredProcedure [dbo].[Get_all_books]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get_all_books]

AS
BEGIN

	Select ID, Name, Description, Publication_date, Added_by_username, AuthorID
	From library_prac2021.dbo.Books
	Order by Books.Name 

END
GO
/****** Object:  StoredProcedure [dbo].[Get_all_genres]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Get_all_genres]

AS
BEGIN

	Select *
	From library_prac2021.dbo.Genre
	Order by ID    
END
GO
/****** Object:  StoredProcedure [dbo].[Get_all_users]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get_all_users]

AS
BEGIN

	Select Users.Username, Users.Custom_name, Users.Sex, Users.Register_date, Users.Is_Admin
	From library_prac2021.dbo.Users
	Order by Register_date    
END
GO
/****** Object:  StoredProcedure [dbo].[Get_author_by_id]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Get_author_by_id]
	@id bigint

AS
BEGIN

	Select Top 1 *
	From library_prac2021.dbo.Authors
	Where Authors.ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Get_book_by_id]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get_book_by_id]
	@ID bigint
AS
BEGIN
	Select Top 1 ID, Name, Description, Publication_date, Added_by_username, AuthorID
	From library_prac2021.dbo.Books
	Where ID = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[Get_bookFile_of_book]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create  PROCEDURE [dbo].[Get_bookFile_of_book]
	@BookID bigint

AS
BEGIN
	
	Select Books.Book_itself, Books.File_name
	From library_prac2021.dbo.Books 
	Where ID = @BookID

END
GO
/****** Object:  StoredProcedure [dbo].[Get_books_by_author_id]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Get_books_by_author_id]
	@ID bigint
AS
BEGIN

	Select Books.ID, Books.Name, Books.Description, Books.Publication_date, Books.Added_by_username, Books.AuthorID
	From library_prac2021.dbo.Books
	Where Books.AuthorID = @ID
	Order by Books.Name 

END
GO
/****** Object:  StoredProcedure [dbo].[Get_books_by_genre_id]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get_books_by_genre_id]
	@ID bigint
AS
BEGIN

	Select Books.ID, Books.Name, Books.Description, Books.Publication_date, Books.Added_by_username, Books.AuthorID
	From library_prac2021.dbo.Books Join Book_Genres on Books.ID = Book_Genres.BookID
									Join library_prac2021.dbo.Genre on Book_Genres.GenreID = Genre.ID

	Where Genre.ID = @ID
	Order by Books.Name 

END
GO
/****** Object:  StoredProcedure [dbo].[Get_favorite_books_of_user]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[Get_favorite_books_of_user]
	@username nvarchar(20)

AS
BEGIN
	
	Select Books.ID, Books.Name, Books.Description, Books.Publication_date, Books.Added_by_username, Books.AuthorID 
	From library_prac2021.dbo.Books join library_prac2021.dbo.User_Favorite_Book on Books.ID = BookID
									join library_prac2021.dbo.Users on User_Favorite_Book.Username = Users.Username
									join library_prac2021.dbo.Authors on Books.AuthorID = Authors.ID
	Where Users.username = @username

END
GO
/****** Object:  StoredProcedure [dbo].[Get_genre_by_ID]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Get_genre_by_ID]
	@ID bigint

AS
BEGIN
	
	Select * 
	from library_prac2021.dbo.Genre 
	where ID = @ID

END
GO
/****** Object:  StoredProcedure [dbo].[Get_genres_of_book_by_id]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Get_genres_of_book_by_id]
	@ID bigint
AS
BEGIN

	Select Genre.ID, Genre.Name, Genre.Description
	From library_prac2021.dbo.Books Join Book_Genres on Books.ID = Book_Genres.BookID
									Join library_prac2021.dbo.Genre on Book_Genres.GenreID = Genre.ID

	Where Books.ID = @ID
	Order by Genre.Name 

END
GO
/****** Object:  StoredProcedure [dbo].[Get_text_of_book]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create  PROCEDURE [dbo].[Get_text_of_book]
	@BookID bigint

AS
BEGIN
	
	Select Books.Text
	From library_prac2021.dbo.Books 
	Where ID = @BookID

END
GO
/****** Object:  StoredProcedure [dbo].[Get_user_by_name]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get_user_by_name]
	@username nvarchar(20)
AS
BEGIN

	Select Top 1 *
	From library_prac2021.dbo.Users
	Where Users.username = @username
    
END
GO
/****** Object:  StoredProcedure [dbo].[Get_user_by_name_with_pass]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Get_user_by_name_with_pass]
	@username nvarchar(20),
	@password nvarchar(20)
AS
BEGIN

	Select Top 1 *
	From library_prac2021.dbo.Users
	Where Users.username = @username and Users.Password = @password
    
END
GO
/****** Object:  StoredProcedure [dbo].[Update_author]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Update_author]
	@id bigint, 
	@secondname nvarchar(40),
	@firstname nvarchar(40),
	@birth_date date

AS
BEGIN

	Update library_prac2021.dbo.Authors
	Set Secondname =  @secondname, Firstname = @firstname, Birth_date = @birth_date
	Where ID = @id

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Book]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Book]
	@id bigint, 
	@name nvarchar(50),
	@description nvarchar(50),
	@publication_date date,
	@AuthorID bigint

AS
BEGIN

	Update library_prac2021.dbo.Books
	Set Name =  @name, Description = @description, publication_date = @publication_date, AuthorID = @AuthorID
	Where ID = @id

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Book_file]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Update_Book_file]
	@id bigint, 
	@file_name nvarchar(256),
	@book varbinary(max)

AS
BEGIN

	Update library_prac2021.dbo.Books
	Set Books.Book_itself = @book, Books.file_name = @file_name
	Where ID = @id

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Book_text]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Update_Book_text]
	@id bigint, 
	@text nvarchar(max)

AS
BEGIN

	Update library_prac2021.dbo.Books
	Set Books.Text = @text
	Where ID = @id

END
GO
/****** Object:  StoredProcedure [dbo].[Update_genre]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Update_genre]
	@id bigint, 
	@name nvarchar(30),
	@description nvarchar(max) = null

AS
BEGIN

	Update library_prac2021.dbo.Genre
	Set Name =  @name, Description = @description
	Where ID = @id

END
GO
/****** Object:  StoredProcedure [dbo].[Update_user]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_user]
	@username nvarchar(20), 
	@Sex bit,
	@Custom_name nvarchar(20) = null

AS
BEGIN

	Update library_prac2021.dbo.Users
	Set Sex = @Sex, Custom_name = N''+ @Custom_name
	Where Username = @username

END
GO
/****** Object:  StoredProcedure [dbo].[Update_user_password]    Script Date: 06.07.2021 14:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Update_user_password]
	@username nvarchar(20), 
	@password nvarchar(20)

AS
BEGIN

	Update library_prac2021.dbo.Users
	Set Users.Password = @password
	Where Username = @username

END
GO
USE [master]
GO
ALTER DATABASE [library_prac2021] SET  READ_WRITE 
GO
