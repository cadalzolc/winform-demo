/****** Object:  Table [dbo].[Sys_Users]    Script Date: 2021-08-19 09:57:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Users](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](80) NULL,
	[Username] [varchar](35) NULL,
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
GO
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (1, N'Lambert', N'bet', N'bet', N'A', N'2021-08-19 21:33:19')
GO
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (2, N'Cherrly', N'cherryl', N'cheeryl', N'', N'')
GO
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (3, N'Daryl', N'daryl', N'daryl', N'', N'')
GO
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (4, N'Renzo', N'renzo', N'renzo', N'', N'')
GO
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (5, N'Cherry Ann', N'cherry', N'cherry', N'', N'')
GO
INSERT [dbo].[Sys_Users] ([PK_ID], [Name], [Username], [Password], [Status], [Last_Login]) VALUES (6, N'Julieta', N'julie', N'julie', N'L', N'')
GO
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
/****** Object:  StoredProcedure [dbo].[SP_Sys_User_Login]    Script Date: 2021-08-19 09:57:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Sys_User_Login]
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
