USE [NewsDatabase]
GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 05/17/2015 15:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 05/17/2015 15:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 05/17/2015 15:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (2, CAST(0x0000A49500F3B6C6 AS DateTime), NULL, 1, NULL, 0, N'AF4e/NYUkQpgbMP+8bQ82JC0oCkU2YjmKUUdVLl3Q+CsJ3/u2xq2I7ONUrvpA5kemQ==', CAST(0x0000A49500F3B6C6 AS DateTime), N'', NULL, NULL)
/****** Object:  Table [dbo].[UserProfile]    Script Date: 05/17/2015 15:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](56) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserProfile] ON
INSERT [dbo].[UserProfile] ([UserId], [Email]) VALUES (2, N'manager@skyfire.vn')
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
/****** Object:  Table [dbo].[THELOAI]    Script Date: 05/17/2015 15:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THELOAI](
	[MATHELOAI] [int] NOT NULL,
	[TENTHELOAI] [nvarchar](30) NOT NULL,
	[MOTA] [text] NULL,
	[SAPXEP] [int] NOT NULL,
	[SLUG] [nvarchar](60) NOT NULL,
	[NGAYTAO] [datetime] NOT NULL,
	[XOA] [bit] NULL,
 CONSTRAINT [PK_THELOAI] PRIMARY KEY CLUSTERED 
(
	[MATHELOAI] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[THELOAI] ([MATHELOAI], [TENTHELOAI], [MOTA], [SAPXEP], [SLUG], [NGAYTAO], [XOA]) VALUES (1, N'CHÍNH TRỊ XÃ HỘI', N'CHÍNH TR? XÃ H?I', 1, N'chinh-tri-xa-hoi', CAST(0x0000A49400000000 AS DateTime), 1)
INSERT [dbo].[THELOAI] ([MATHELOAI], [TENTHELOAI], [MOTA], [SAPXEP], [SLUG], [NGAYTAO], [XOA]) VALUES (2, N'PHÁP LUẬT', N'PHÁP LU?T', 2, N'phap-luat', CAST(0x0000A49400000000 AS DateTime), 1)
INSERT [dbo].[THELOAI] ([MATHELOAI], [TENTHELOAI], [MOTA], [SAPXEP], [SLUG], [NGAYTAO], [XOA]) VALUES (3, N'KINH TẾ', N'KINH T?', 3, N'kinh-te', CAST(0x0000A49400000000 AS DateTime), 1)
INSERT [dbo].[THELOAI] ([MATHELOAI], [TENTHELOAI], [MOTA], [SAPXEP], [SLUG], [NGAYTAO], [XOA]) VALUES (4, N'GIÁO DỤC', N'GIÁO D?C', 4, N'giao-duc', CAST(0x0000A49400000000 AS DateTime), 1)
INSERT [dbo].[THELOAI] ([MATHELOAI], [TENTHELOAI], [MOTA], [SAPXEP], [SLUG], [NGAYTAO], [XOA]) VALUES (5, N'VĂN HÓA', N'VAN HÓA', 5, N'van-hoa', CAST(0x0000A49400000000 AS DateTime), 1)
INSERT [dbo].[THELOAI] ([MATHELOAI], [TENTHELOAI], [MOTA], [SAPXEP], [SLUG], [NGAYTAO], [XOA]) VALUES (7, N'DU LỊCH', N'DU L?CH', 7, N'du-lich', CAST(0x0000A49400000000 AS DateTime), 1)
INSERT [dbo].[THELOAI] ([MATHELOAI], [TENTHELOAI], [MOTA], [SAPXEP], [SLUG], [NGAYTAO], [XOA]) VALUES (8, N'DU LỊCH', N'DU L?CH', 7, N'du-lich', CAST(0x0000A49400000000 AS DateTime), 1)
INSERT [dbo].[THELOAI] ([MATHELOAI], [TENTHELOAI], [MOTA], [SAPXEP], [SLUG], [NGAYTAO], [XOA]) VALUES (9, N'DU LỊCH', N'DU L?CH', 7, N'du-lich', CAST(0x0000A49400000000 AS DateTime), 1)
INSERT [dbo].[THELOAI] ([MATHELOAI], [TENTHELOAI], [MOTA], [SAPXEP], [SLUG], [NGAYTAO], [XOA]) VALUES (11, N'DU LỊCH', N'DU L?CH', 7, N'du-lich', CAST(0x0000A49400000000 AS DateTime), 1)
INSERT [dbo].[THELOAI] ([MATHELOAI], [TENTHELOAI], [MOTA], [SAPXEP], [SLUG], [NGAYTAO], [XOA]) VALUES (12, N'DU LỊCH', N'DU L?CH', 7, N'du-lich', CAST(0x0000A49400000000 AS DateTime), 1)
INSERT [dbo].[THELOAI] ([MATHELOAI], [TENTHELOAI], [MOTA], [SAPXEP], [SLUG], [NGAYTAO], [XOA]) VALUES (13, N'wcwecwecw', N'werewr', 1, N'2015513', CAST(0x0000A497017E1BEC AS DateTime), 1)
INSERT [dbo].[THELOAI] ([MATHELOAI], [TENTHELOAI], [MOTA], [SAPXEP], [SLUG], [NGAYTAO], [XOA]) VALUES (14, N'trhtrhrt', N'htrhtrh', 1, N'2015517trhtrhrt', CAST(0x0000A49B00065BBC AS DateTime), 1)
/****** Object:  Table [dbo].[BINHLUAN]    Script Date: 05/17/2015 15:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BINHLUAN](
	[MABINHLUAN] [int] NOT NULL,
	[MABANTIN] [int] NOT NULL,
	[HOTEN] [nvarchar](255) NOT NULL,
	[EMAIL] [nvarchar](255) NOT NULL,
	[DIENTHOAI] [nvarchar](255) NOT NULL,
	[TIEUDE] [nvarchar](255) NOT NULL,
	[NOIDUNG] [text] NOT NULL,
	[NGAYTAO] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_BINHLUAN] PRIMARY KEY CLUSTERED 
(
	[MABINHLUAN] ASC,
	[MABANTIN] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BANTIN]    Script Date: 05/17/2015 15:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BANTIN](
	[MABANTIN] [int] NOT NULL,
	[MATHELOAI] [int] NOT NULL,
	[TIEUDE] [nvarchar](255) NOT NULL,
	[NOIDUNGTOMTAT] [nvarchar](255) NOT NULL,
	[NOIDUNG] [nvarchar](max) NOT NULL,
	[NGAYDANG] [datetime] NOT NULL,
	[HINHANH] [nvarchar](255) NOT NULL,
	[TENTACGIA] [nvarchar](255) NOT NULL,
	[SLUG] [nvarchar](255) NOT NULL,
	[LIKES] [int] NOT NULL,
	[XOA] [bit] NULL,
 CONSTRAINT [PK_BanTin] PRIMARY KEY CLUSTERED 
(
	[MABANTIN] ASC,
	[MATHELOAI] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BANTIN] ([MABANTIN], [MATHELOAI], [TIEUDE], [NOIDUNGTOMTAT], [NOIDUNG], [NGAYDANG], [HINHANH], [TENTACGIA], [SLUG], [LIKES], [XOA]) VALUES (1, 1, N'Pháo hoa thắp sáng mừng 60 năm giải phóng Hải Phòng', N'TTO - Ngày 9-5, Thành phố Hải Phòng tổ chức trọng thể lễ kỷ niệm 60 năm ngày giải phóng (13-5-1955 - 13-5-2015).', N'Th? tu?ng chính ph? Nguy?n T?n Dung cùng nhi?u lãnh d?o, nguyên lãnh d?o Ð?ng và Nhà nu?c t?i d? l? k? ni?m. Hàng tram c?u chi?n binh, cán b?, h?c sinh, sinh viên và ngu?i dân H?i Phòng cung có m?t ôn l?i nh?ng m?c son chói l?i trong quá trình hình thành, b?o v? và phát tri?n c?a thành ph? C?ng.', CAST(0x0000A49400000000 AS DateTime), N'Kzhk9we2.jpg', N'TUỔI TRẺ', N'ky-niem-60-nam-giai-phong-hai-phong', 0, 1)
INSERT [dbo].[BANTIN] ([MABANTIN], [MATHELOAI], [TIEUDE], [NOIDUNGTOMTAT], [NOIDUNG], [NGAYDANG], [HINHANH], [TENTACGIA], [SLUG], [LIKES], [XOA]) VALUES (2, 4, N'Kẹt xi', N'grgerregre reer', N'<p>Theo CSGT dang ph&acirc;n lu?ng giao th&ocirc;ng t?i tr?m thu ph&iacute; c?u R?ch Chi?c, kho?ng 2g s&aacute;ng c&ugrave;ng ng&agrave;y tuy?n du?ng v&agrave;o c?ng C&aacute;t L&aacute;i b?t d?u b? &ugrave;n ?.</p>
', CAST(0x0000A49400000000 AS DateTime), N'T2Z0PFkq.jpg', N'TUỔI TRẺ', N'2015517ket-xi', 0, 0)
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 05/17/2015 15:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_BANTIN_LIKES]    Script Date: 05/17/2015 15:28:23 ******/
ALTER TABLE [dbo].[BANTIN] ADD  CONSTRAINT [DF_BANTIN_LIKES]  DEFAULT ((0)) FOR [LIKES]
GO
/****** Object:  Default [DF__webpages___IsCon__29572725]    Script Date: 05/17/2015 15:28:23 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
/****** Object:  Default [DF__webpages___Passw__2A4B4B5E]    Script Date: 05/17/2015 15:28:23 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
/****** Object:  ForeignKey [fk_RoleId]    Script Date: 05/17/2015 15:28:23 ******/
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
/****** Object:  ForeignKey [fk_UserId]    Script Date: 05/17/2015 15:28:23 ******/
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO
