USE [urapz_test]
GO
/****** Object:  StoredProcedure [dbo].[SP_Sys_Users_Update]    Script Date: 2021-08-22 01:35:10 AM ******/
DROP PROCEDURE [dbo].[SP_Sys_Users_Update]
GO
/****** Object:  StoredProcedure [dbo].[SP_Sys_Users_Login]    Script Date: 2021-08-22 01:35:10 AM ******/
DROP PROCEDURE [dbo].[SP_Sys_Users_Login]
GO
/****** Object:  StoredProcedure [dbo].[SP_Sys_Users_Create]    Script Date: 2021-08-22 01:35:10 AM ******/
DROP PROCEDURE [dbo].[SP_Sys_Users_Create]
GO
ALTER TABLE [dbo].[Sys_Users] DROP CONSTRAINT [DF_Sys_Users_Last_Login]
GO
ALTER TABLE [dbo].[Sys_Users] DROP CONSTRAINT [DF_Sys_Users_Status]
GO
ALTER TABLE [dbo].[Sys_Users] DROP CONSTRAINT [DF_Sys_Users_Password]
GO
ALTER TABLE [dbo].[Sys_Users] DROP CONSTRAINT [DF_Sys_Users_Username]
GO
ALTER TABLE [dbo].[Sys_Users] DROP CONSTRAINT [DF_Sys_Users_Name]
GO
/****** Object:  Table [dbo].[Sys_Users]    Script Date: 2021-08-22 01:35:10 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sys_Users]') AND type in (N'U'))
DROP TABLE [dbo].[Sys_Users]
GO
/****** Object:  Table [dbo].[Sys_Users]    Script Date: 2021-08-22 01:35:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Users](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](80) NULL,
	[Username] [varchar](35) NOT NULL,
	[Password] [varchar](35) NULL,
	[Status] [varchar](1) NULL,
	[Last_Login] [varchar](25) NULL,
 CONSTRAINT [PK_Sys_Users] PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Sys_Users] ON 

INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (1, N'Administrator', N'admin', N'admin', N'A', N'2021-08-21 21:50:30')
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (2, N'Cherry Nepomuceno', N'cherryl', N'cheeryl', N'', N'')
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (3, N'Daryl', N'daryl', N'daryl', N'', N'')
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (4, N'Renzo', N'renzo', N'renzo', N'', N'')
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (5, N'Cherry Ann', N'cherry', N'cherry', N'', N'')
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (6, N'Julieta', N'julie', N'julie', N'L', N'')
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (7, N'Ed', N'ed', N'ed', N'', N'')
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (8, N'Mike', N'mike', N'mike', N'', N'')
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (9, N'Lambert Cadalzo', N'ozla', N'ozla', N'', N'')
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (10, N'Mervin', N'mervin', N'mervin', N'', N'')
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (11, N'Crezka', N'crezka', N'crezka', N'', N'')
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (12, N'Meigo', N'meigo', N'meigo', N'', N'')
SET IDENTITY_INSERT [dbo].[Sys_Users] OFF
GO
ALTER TABLE [dbo].[Sys_Users] ADD  CONSTRAINT [DF_Sys_Users_Name]  DEFAULT (N'') FOR [Name]
GO
ALTER TABLE [dbo].[Sys_Users] ADD  CONSTRAINT [DF_Sys_Users_Username]  DEFAULT (N'') FOR [Username]
GO
ALTER TABLE [dbo].[Sys_Users] ADD  CONSTRAINT [DF_Sys_Users_Password]  DEFAULT (N'') FOR [Password]
GO
ALTER TABLE [dbo].[Sys_Users] ADD  CONSTRAINT [DF_Sys_Users_Status]  DEFAULT (N'') FOR [Status]
GO
ALTER TABLE [dbo].[Sys_Users] ADD  CONSTRAINT [DF_Sys_Users_Last_Login]  DEFAULT (N'') FOR [Last_Login]
GO
/****** Object:  StoredProcedure [dbo].[SP_Sys_Users_Create]    Script Date: 2021-08-22 01:35:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Sys_Users_Create]
@Name varchar(75),
@Username varchar(35),
@Password varchar(35),
@Err varchar(300) output
AS
BEGIN

	SET @Err = ''

	SET @Name = LTRIM(RTRIM(TRIM(@Name)))
	SET @Username = LTRIM(RTRIM(TRIM(@Username)))
	SET @Password = LTRIM(RTRIM(TRIM(@Password)))

	IF @Name = '' BEGIN
		SET @Err = 'Name is required to be filled up'
		RETURN
	END

	IF @Username = '' BEGIN
		SET @Err = 'Username is required to be filled up'
		RETURN
	END

	IF @Password = '' BEGIN
		SET @Err = 'Password is required to be filled up'
		RETURN
	END

	IF EXISTS(SELECT Name FROM Sys_Users WHERE Name = @Name) BEGIN
		SET @Err = 'Name is already used: ''' + @Name + ''''
		RETURN
	END

	IF EXISTS(SELECT Username FROM Sys_Users WHERE Username = @Username) BEGIN
		SET @Err = 'Username is already used: ''' + @Username + ''''
		RETURN
	END

	SET @Err = TRIM(@Err)

	INSERT INTO Sys_Users (Name, Username, Password, Status) VALUES (@Name, @Username, @Password, '')

END
GO
/****** Object:  StoredProcedure [dbo].[SP_Sys_Users_Login]    Script Date: 2021-08-22 01:35:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Sys_Users_Login]
@Username varchar(35),
@Password varchar(35),
@Err varchar(300) output
AS
BEGIN

	SET @Err = ''

	DECLARE @ID int, @Status varchar(1)

	IF NOT EXISTS(SELECT Name FROM Sys_Users WHERE Username = @Username AND Password = @Password) BEGIN
		SET @Err = 'User account does not exists in database. user : ''' + @Username + ''''
		RETURN
	END

	SELECT @Status = Status, @ID = PK_ID FROM Sys_Users WHERE Username = @Username AND Password = @Password

	SET @ID = ISNULL(@ID, 0)
	SET @Status = ISNULL(@Status, '')

	IF @Status = '' BEGIN
		SET @Err = 'User account is not activated'
		RETURN
	END

	IF @Status = 'L' BEGIN
		SET @Err = 'User account is locked. Please contact your system admin'
		RETURN
	END

	UPDATE Sys_Users SET Last_Login = FORMAT(GETDATE(), 'yyy-MM-dd HH:mm:ss') WHERE PK_ID = @ID

	SELECT TOP 1 * FROM Sys_Users WHERE PK_ID = @ID
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Sys_Users_Update]    Script Date: 2021-08-22 01:35:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Sys_Users_Update]
@ID int,
@Name varchar(75),
@Username varchar(35),
@Password varchar(35),
@Err varchar(300) output
AS
BEGIN

	SET @Err = ''

	SET @Name = LTRIM(RTRIM(TRIM(@Name)))
	SET @Username = LTRIM(RTRIM(TRIM(@Username)))
	SET @Password = LTRIM(RTRIM(TRIM(@Password)))

	IF @Name = '' BEGIN
		SET @Err = 'Name is required to be filled up'
		RETURN
	END

	IF @Username = '' BEGIN
		SET @Err = 'Username is required to be filled up'
		RETURN
	END

	IF @Password = '' BEGIN
		SET @Err = 'Password is required to be filled up'
		RETURN
	END

	IF EXISTS(SELECT Name FROM Sys_Users WHERE Name = @Name AND PK_ID != @ID) BEGIN
		SET @Err = 'Name is already used: ''' + @Name + ''''
		RETURN
	END

	IF EXISTS(SELECT Username FROM Sys_Users WHERE Username = @Username AND PK_ID != @ID) BEGIN
		SET @Err = 'Username is already used: ''' + @Username + ''''
		RETURN
	END

	SET @Err = TRIM(@Err)

	UPDATE Sys_Users SET Name = @Name, Username = @Username, Password = @Password WHERE PK_ID = @ID

END
GO
