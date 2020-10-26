USE [eStoreAPI_DB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/26/2020 9:53:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnetroleclaims]    Script Date: 10/26/2020 9:53:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnetroleclaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_aspnetroleclaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnetroles]    Script Date: 10/26/2020 9:53:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnetroles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_aspnetroles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnetuserclaims]    Script Date: 10/26/2020 9:53:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnetuserclaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_aspnetuserclaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnetuserlogins]    Script Date: 10/26/2020 9:53:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnetuserlogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_aspnetuserlogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnetuserroles]    Script Date: 10/26/2020 9:53:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnetuserroles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_aspnetuserroles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnetusers]    Script Date: 10/26/2020 9:53:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnetusers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[MaxBuyLimit] [int] NOT NULL,
	[MaxBuyGiftLimit] [int] NOT NULL,
 CONSTRAINT [PK_aspnetusers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnetusertokens]    Script Date: 10/26/2020 9:53:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnetusertokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_aspnetusertokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[evoucher]    Script Date: 10/26/2020 9:53:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[evoucher](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
	[ExpireDate] [datetime2](7) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Amount] [float] NOT NULL,
	[PaymentMethodId] [uniqueidentifier] NOT NULL,
	[DiscountOnPaymentMethod] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[BuyType] [smallint] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_evoucher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[paymentmethod]    Script Date: 10/26/2020 9:53:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paymentmethod](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_paymentmethod] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201025095653_Init Schema', N'3.1.9')
GO
INSERT [dbo].[aspnetusers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [MaxBuyLimit], [MaxBuyGiftLimit]) VALUES (N'186cd611-ee6e-4e18-92eb-01211e603d6b', N'testuser@mail.com', N'TESTUSER@MAIL.COM', N'testuser@mail.com', N'TESTUSER@MAIL.COM', 1, N'AQAAAAEAACcQAAAAEAFT8e02B/1HFHKsAOOMmCq6kQ4zamZpBj53aeUN1GKynCNm/hvAmT0UCuHEt+S9LA==', N'JND7T5PEXQ6OGXRPMCGXG23YY47GLKBQ', N'ea4b3348-06e6-41f9-95b4-348e65c8250d', N'938388374774', 1, 0, NULL, 1, 0, N'Test User', 1000, 10)
GO
INSERT [dbo].[evoucher] ([Id], [Title], [Description], [ExpireDate], [Image], [Amount], [PaymentMethodId], [DiscountOnPaymentMethod], [Quantity], [BuyType], [IsActive]) VALUES (N'3f96647b-d83c-4b45-ddf4-08d8793fe64c', N'test eVoucher', N'Testing description will come here.', CAST(N'2021-12-25T00:00:00.0000000' AS DateTime2), NULL, 10, N'c728093b-2807-4b0e-9696-9f0c3a1d52fe', 5, 10000, 0, 1)
GO
INSERT [dbo].[evoucher] ([Id], [Title], [Description], [ExpireDate], [Image], [Amount], [PaymentMethodId], [DiscountOnPaymentMethod], [Quantity], [BuyType], [IsActive]) VALUES (N'76070321-5b7a-4dc5-ddf5-08d8793fe64c', N'Test eVoucher 1', N'Testing description 01 will come here.', CAST(N'2021-12-25T00:00:00.0000000' AS DateTime2), NULL, 20, N'c728093b-2807-4b0e-9696-9f0c3a1d52fe', 10, 15000, 1, 1)
GO
INSERT [dbo].[evoucher] ([Id], [Title], [Description], [ExpireDate], [Image], [Amount], [PaymentMethodId], [DiscountOnPaymentMethod], [Quantity], [BuyType], [IsActive]) VALUES (N'09e3a1f0-7cce-48ba-ddf6-08d8793fe64c', N'Test eVoucher 2', N'Testing description 02 will come here.', CAST(N'2022-12-25T00:00:00.0000000' AS DateTime2), NULL, 15, N'f33f5e25-21b6-4ce0-bc53-de8f3c55000d', 10, 25000, 0, 1)
GO
INSERT [dbo].[evoucher] ([Id], [Title], [Description], [ExpireDate], [Image], [Amount], [PaymentMethodId], [DiscountOnPaymentMethod], [Quantity], [BuyType], [IsActive]) VALUES (N'698864d8-0a8c-4d1e-fbce-08d879464fbe', N'Test eVoucher 2', N'Testing description 02 will come here.', CAST(N'2022-12-25T00:00:00.0000000' AS DateTime2), NULL, 15, N'f33f5e25-21b6-4ce0-bc53-de8f3c55000d', 10, 25000, 0, 1)
GO
INSERT [dbo].[evoucher] ([Id], [Title], [Description], [ExpireDate], [Image], [Amount], [PaymentMethodId], [DiscountOnPaymentMethod], [Quantity], [BuyType], [IsActive]) VALUES (N'bb776001-2275-4bab-9801-0e8d280b4d9f', N'Test eVoucher 15', N'Testing description 15 will come here.', CAST(N'2020-12-28T00:00:00.0000000' AS DateTime2), NULL, 150, N'f33f5e25-21b6-4ce0-bc53-de8f3c55000d', 16, 25000, 1, 1)
GO
INSERT [dbo].[evoucher] ([Id], [Title], [Description], [ExpireDate], [Image], [Amount], [PaymentMethodId], [DiscountOnPaymentMethod], [Quantity], [BuyType], [IsActive]) VALUES (N'336a1784-35e5-4349-bb5d-ba44bc127d58', N'Test eVoucher 15', N'Testing description 15 will come here.', CAST(N'2020-12-28T00:00:00.0000000' AS DateTime2), NULL, 150, N'f33f5e25-21b6-4ce0-bc53-de8f3c55000d', 16, 25000, 1, 1)
GO
INSERT [dbo].[evoucher] ([Id], [Title], [Description], [ExpireDate], [Image], [Amount], [PaymentMethodId], [DiscountOnPaymentMethod], [Quantity], [BuyType], [IsActive]) VALUES (N'c4f5b4a5-2460-4039-98f5-e43968447c72', N'Test eVoucher 15', N'Testing description 15 will come here.', CAST(N'2020-12-28T00:00:00.0000000' AS DateTime2), NULL, 150, N'f33f5e25-21b6-4ce0-bc53-de8f3c55000d', 16, 25000, 1, 1)
GO
INSERT [dbo].[paymentmethod] ([Id], [Description]) VALUES (N'eede761d-9ed5-47c9-aa3f-53107354643d', N'KBZ Pay')
GO
INSERT [dbo].[paymentmethod] ([Id], [Description]) VALUES (N'c728093b-2807-4b0e-9696-9f0c3a1d52fe', N'VISA')
GO
INSERT [dbo].[paymentmethod] ([Id], [Description]) VALUES (N'ea01952d-a79d-495f-9f58-ac314335e789', N'WavePay')
GO
INSERT [dbo].[paymentmethod] ([Id], [Description]) VALUES (N'f33f5e25-21b6-4ce0-bc53-de8f3c55000d', N'Mastercard')
GO
INSERT [dbo].[paymentmethod] ([Id], [Description]) VALUES (N'cd440abb-6321-4565-935b-e7185f524430', N'One Pay')
GO
INSERT [dbo].[paymentmethod] ([Id], [Description]) VALUES (N'47cf6500-026d-4731-938d-ead92afdc429', N'CB Pay')
GO
ALTER TABLE [dbo].[aspnetroleclaims]  WITH CHECK ADD  CONSTRAINT [FK_aspnetroleclaims_aspnetroles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[aspnetroles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[aspnetroleclaims] CHECK CONSTRAINT [FK_aspnetroleclaims_aspnetroles_RoleId]
GO
ALTER TABLE [dbo].[aspnetuserclaims]  WITH CHECK ADD  CONSTRAINT [FK_aspnetuserclaims_aspnetusers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnetusers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[aspnetuserclaims] CHECK CONSTRAINT [FK_aspnetuserclaims_aspnetusers_UserId]
GO
ALTER TABLE [dbo].[aspnetuserlogins]  WITH CHECK ADD  CONSTRAINT [FK_aspnetuserlogins_aspnetusers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnetusers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[aspnetuserlogins] CHECK CONSTRAINT [FK_aspnetuserlogins_aspnetusers_UserId]
GO
ALTER TABLE [dbo].[aspnetuserroles]  WITH CHECK ADD  CONSTRAINT [FK_aspnetuserroles_aspnetroles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[aspnetroles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[aspnetuserroles] CHECK CONSTRAINT [FK_aspnetuserroles_aspnetroles_RoleId]
GO
ALTER TABLE [dbo].[aspnetuserroles]  WITH CHECK ADD  CONSTRAINT [FK_aspnetuserroles_aspnetusers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnetusers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[aspnetuserroles] CHECK CONSTRAINT [FK_aspnetuserroles_aspnetusers_UserId]
GO
ALTER TABLE [dbo].[aspnetusertokens]  WITH CHECK ADD  CONSTRAINT [FK_aspnetusertokens_aspnetusers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnetusers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[aspnetusertokens] CHECK CONSTRAINT [FK_aspnetusertokens_aspnetusers_UserId]
GO
