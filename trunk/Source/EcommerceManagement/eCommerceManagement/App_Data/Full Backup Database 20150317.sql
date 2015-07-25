USE eCommerceManagement
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[NhanVienGuid] [uniqueidentifier] NOT NULL,
	[MaNhanVien] [nvarchar](25) NULL,
	[Ho] [nvarchar](25) NULL,
	[Ten] [nvarchar](25) NULL,
	[TenLot] [nvarchar](75) NULL,
	[NgaySinh] [datetime] NULL,
	[SoCMND] [nvarchar](25) NULL,
	[Phai] [int] NULL,
	[DiaChiLienHe] [nvarchar](256) NULL,
	[DienThoai] [nvarchar](50) NULL,
	[Email] [nvarchar](256) NULL,
	[URLHinhAnh] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[NhanVienGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[NhanVien] ([NhanVienGuid], [MaNhanVien], [Ho], [Ten], [TenLot], [NgaySinh], [SoCMND], [Phai], [DiaChiLienHe], [DienThoai], [Email], [URLHinhAnh]) VALUES (N'40832c0d-e3f5-471c-bee6-0215d215409c', N'VN0002', N'Đỗ', N'Ngọc', N'Thị', CAST(0x00007F4A00000000 AS DateTime), NULL, 2, N'Bến Tre', N'0989595945', N'dothingocbt@gmail.com', NULL)
INSERT [dbo].[NhanVien] ([NhanVienGuid], [MaNhanVien], [Ho], [Ten], [TenLot], [NgaySinh], [SoCMND], [Phai], [DiaChiLienHe], [DienThoai], [Email], [URLHinhAnh]) VALUES (N'84c8e930-7a32-4bd4-8f79-960f136485f3', N'VN0001', N'Nguyễn', N'Vinh', N'Thành', CAST(0x000080B900000000 AS DateTime), N'024326971', 1, N'Gò Vấp', N'0902583976', N'enjoyvinh@gmail.com', NULL)
INSERT [dbo].[NhanVien] ([NhanVienGuid], [MaNhanVien], [Ho], [Ten], [TenLot], [NgaySinh], [SoCMND], [Phai], [DiaChiLienHe], [DienThoai], [Email], [URLHinhAnh]) VALUES (N'2511938b-5a63-4d1b-a517-fceea072582e', N'VN0003', N'Nguyễn', N'Hiệp', N'Thị', NULL, NULL, 2, N'KrongBong', NULL, NULL, NULL)
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[NhaCungCapGuid] [uniqueidentifier] NOT NULL,
	[NhaCungCapID] [nvarchar](25) NULL,
	[TenNhaCungCap] [nvarchar](256) NULL,
	[DiaChi] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[NhaCungCapGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhuVucBanHang]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuVucBanHang](
	[KhuVucBanHangGuid] [uniqueidentifier] NOT NULL,
	[KhuVucBanName] [nvarchar](256) NULL,
	[KhuVucBanID] [nvarchar](25) NULL,
	[KhuVucChaGuid] [uniqueidentifier] NULL,
	[KhuVucChaID] [nvarchar](25) NULL,
	[KhuVucChaName] [nvarchar](256) NULL,
	[LuuVetKhuVucGuid] [nvarchar](max) NULL,
	[LuuVetKhuVucID] [nvarchar](max) NULL,
	[LuuVetKhuVucName] [nvarchar](max) NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[KhuVucBanHangGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'0e43818a-73d5-46ec-9e93-1be74f20cad0', N'Tầng 2', N'TA00002', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0', N'NH00001', N'Nhà Hành Ẩm Thực 3 Miền', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,', N'NH00001,', N'Nhà Hành Ẩm Thực 3 Miền,', 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'eee41842-7ab2-48b8-99f9-3461e4c9c538', N'Bàn 2', N'BAN0002', N'fedc0cd9-f3c4-4812-9ad7-585e194415bd', N'TA00001', N'Tầng Trệt', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,fedc0cd9-f3c4-4812-9ad7-585e194415bd,', N'NH00001,TA00001,', N'Nhà Hành Ẩm Thực 3 Miền,Tầng Trệt', 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'eb812fb3-52b9-40d9-b220-52e653ca73ce', N'Bàn 1', N'BAN0001', N'0e43818a-73d5-46ec-9e93-1be74f20cad0', N'TA00002', N'Tầng 2', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,0e43818a-73d5-46ec-9e93-1be74f20cad0', N'NH00001,TA00002,', N'Nhà Hành Ẩm Thực 3 Miền,Tầng 2', 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'fedc0cd9-f3c4-4812-9ad7-585e194415bd', N'Tầng Trệt', N'TA00001', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0', N'NH00001', N'Nhà Hành Ẩm Thực 3 Miền', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,', N'NH00001,', N'Nhà Hành Ẩm Thực 3 Miền,', 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'1308bc5b-4e41-420c-b47f-6e247e250393', N'Bàn 2', N'BAN0001', N'0e43818a-73d5-46ec-9e93-1be74f20cad0', N'TA00002', N'Tầng 2', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,0e43818a-73d5-46ec-9e93-1be74f20cad0', N'NH00001,TA00002,', N'Nhà Hành Ẩm Thực 3 Miền,Tầng 2', 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'7723e19c-5f80-41a5-9d31-718cb43c957f', N'Bàn VIP 3', N'BAV0001', N'bc9e30ef-f169-499f-b4d4-bcbdfa028400', N'KVV0001', N'Khu Vực VIP', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,9fd75589-6cc3-4b60-8c74-e56d04292244,1fa199b3-5607-4e0b-93c5-89cd9451a661,bc9e30ef-f169-499f-b4d4-bcbdfa028400,', N'NH00001,TA00007,KH00001,KVV0001,', N'Nhà Hành Ẩm Thực 3 Miền,Tầng 7,Khu Đại Sảnh,Khu Vực VIP', 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'88705a1b-969c-4a0e-b472-7663cb209533', N'Tầng 4', N'TA00004', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0', N'NH00001', N'Nhà Hành Ẩm Thực 3 Miền', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,', N'NH00001,', N'Nhà Hành Ẩm Thực 3 Miền,', 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'2e9a3a33-66e5-4fae-a7b1-7f26890c9c41', N'Bàn VIP 1', N'BAV0001', N'bc9e30ef-f169-499f-b4d4-bcbdfa028400', N'KVV0001', N'Khu Vực VIP', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,9fd75589-6cc3-4b60-8c74-e56d04292244,1fa199b3-5607-4e0b-93c5-89cd9451a661,bc9e30ef-f169-499f-b4d4-bcbdfa028400,', N'NH00001,TA00007,KH00001,KVV0001,', N'Nhà Hành Ẩm Thực 3 Miền,Tầng 7,Khu Đại Sảnh,Khu Vực VIP', 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'cc8f3cb9-05d9-44c4-9d67-810514e4ec3c', N'Bàn 1', N'BAN0001', N'fedc0cd9-f3c4-4812-9ad7-585e194415bd', N'TA00001', N'Tầng Trệt', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,fedc0cd9-f3c4-4812-9ad7-585e194415bd,', N'NH00001,TA00001,', N'Nhà Hành Ẩm Thực 3 Miền,Tầng Trệt', 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'1fa199b3-5607-4e0b-93c5-89cd9451a661', N'Khu Đại Sảnh', N'KH00001', N'9fd75589-6cc3-4b60-8c74-e56d04292244', N'TA00002', N'Nhà Hành Ẩm Thực 3 Miền', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,9fd75589-6cc3-4b60-8c74-e56d04292244', N'NH00001,TA00007', N'Nhà Hành Ẩm Thực 3 Miền,Tầng 7', 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'720e4f29-4dcb-46e5-8829-aef4d5222ea0', N'Nhà Hành Ẩm Thực 3 Miền', N'NH00001', NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'be5a4652-a227-420c-91a0-b63ea35ad1f1', N'Tầng 3', N'TA00003', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0', N'NH00001', N'Nhà Hành Ẩm Thực 3 Miền', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,', N'NH00001,', N'Nhà Hành Ẩm Thực 3 Miền,', 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'bc9e30ef-f169-499f-b4d4-bcbdfa028400', N'Khu Vực VIP', N'KVV0001', N'1fa199b3-5607-4e0b-93c5-89cd9451a661', N'KH00001', N'Khu Đại Sảnh', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,9fd75589-6cc3-4b60-8c74-e56d04292244,1fa199b3-5607-4e0b-93c5-89cd9451a661,', N'NH00001,TA00007,KH00001,', N'Nhà Hành Ẩm Thực 3 Miền,Tầng 7,Khu Đại Sảnh', 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'9fd75589-6cc3-4b60-8c74-e56d04292244', N'Tầng 7', N'TA00007', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0', N'NH00001', N'Nhà Hành Ẩm Thực 3 Miền', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,', N'NH00001,', N'Nhà Hành Ẩm Thực 3 Miền,', 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'508a11aa-3b9e-4d70-a8e4-f3672948ab1e', N'Tầng 6', N'TA00006', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0', N'NH00001', N'Nhà Hành Ẩm Thực 3 Miền', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,', N'NH00001,', N'Nhà Hành Ẩm Thực 3 Miền,', 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'c7d48ae4-54fc-4af7-9018-fc11bfe11a5c', N'Bàn 3', N'BAN0003', N'fedc0cd9-f3c4-4812-9ad7-585e194415bd', N'TA00001', N'Tầng Trệt', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,fedc0cd9-f3c4-4812-9ad7-585e194415bd,', N'NH00001,TA00001,', N'Nhà Hành Ẩm Thực 3 Miền,Tầng Trệt', 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'4d03c2d3-3aa0-493b-ba3a-ffaebf34e509', N'Tầng 5', N'TA00005', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0', N'NH00001', N'Nhà Hành Ẩm Thực 3 Miền', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,', N'NH00001,', N'Nhà Hành Ẩm Thực 3 Miền,', 1)
INSERT [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid], [KhuVucBanName], [KhuVucBanID], [KhuVucChaGuid], [KhuVucChaID], [KhuVucChaName], [LuuVetKhuVucGuid], [LuuVetKhuVucID], [LuuVetKhuVucName], [TrangThai]) VALUES (N'26f15d41-78db-44ad-9411-fff7aba45fc9', N'Bàn VIP 2', N'BAV0001', N'bc9e30ef-f169-499f-b4d4-bcbdfa028400', N'KVV0001', N'Khu Vực VIP', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0,9fd75589-6cc3-4b60-8c74-e56d04292244,1fa199b3-5607-4e0b-93c5-89cd9451a661,bc9e30ef-f169-499f-b4d4-bcbdfa028400,', N'NH00001,TA00007,KH00001,KVV0001,', N'Nhà Hành Ẩm Thực 3 Miền,Tầng 7,Khu Đại Sảnh,Khu Vực VIP', 1)
/****** Object:  Table [dbo].[DonViTinh]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonViTinh](
	[DonViTinhGuid] [uniqueidentifier] NOT NULL,
	[DonViTinhName] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[DonViTinhGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DonViTinh] ([DonViTinhGuid], [DonViTinhName]) VALUES (N'69fa5e69-49b2-4d7d-931f-33ed08d6defc', N'Củ')
INSERT [dbo].[DonViTinh] ([DonViTinhGuid], [DonViTinhName]) VALUES (N'31d938a5-c6c3-4beb-ab49-4063fa934933', N'Món')
INSERT [dbo].[DonViTinh] ([DonViTinhGuid], [DonViTinhName]) VALUES (N'de077a4c-d2af-41eb-84d7-682412415c8d', N'Hột')
INSERT [dbo].[DonViTinh] ([DonViTinhGuid], [DonViTinhName]) VALUES (N'2af50598-7edc-4719-bcd3-998ba7ec7f50', N'Gram')
INSERT [dbo].[DonViTinh] ([DonViTinhGuid], [DonViTinhName]) VALUES (N'46edef3e-44cd-42df-a318-a8bcd0140b0b', N'Con')
INSERT [dbo].[DonViTinh] ([DonViTinhGuid], [DonViTinhName]) VALUES (N'42d03a85-e73b-42b6-a9f2-b1e719471f7e', N'Kg')
INSERT [dbo].[DonViTinh] ([DonViTinhGuid], [DonViTinhName]) VALUES (N'fd301981-e7c1-40ed-be15-cf9c433e4dcd', N'Chai')
INSERT [dbo].[DonViTinh] ([DonViTinhGuid], [DonViTinhName]) VALUES (N'08e345bd-713c-454d-96ee-df4f0e5dc8ee', N'Cái')
INSERT [dbo].[DonViTinh] ([DonViTinhGuid], [DonViTinhName]) VALUES (N'83a020cc-509c-496a-84ff-e859d69df334', N'Lít')
INSERT [dbo].[DonViTinh] ([DonViTinhGuid], [DonViTinhName]) VALUES (N'9b8c206f-10e4-4a84-a74e-f0da55c110df', N'Trái')
INSERT [dbo].[DonViTinh] ([DonViTinhGuid], [DonViTinhName]) VALUES (N'd4697583-3dad-409b-a16c-f9594b05f737', N'ml')
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[DanhMucGuid] [uniqueidentifier] NOT NULL,
	[DanhMucID] [int] IDENTITY(1,1) NOT NULL,
	[DanhMucName] [nvarchar](256) NULL,
	[TrangThai] [bit] NULL,
	[LuuVetDanhMucGuid] [nvarchar](max) NULL,
	[LuuVetDanhMucID] [nvarchar](max) NULL,
	[LuuVetDanhMucName] [nvarchar](max) NULL,
	[DanhMucChaGuid] [uniqueidentifier] NULL,
	[DanhMucChaName] [nvarchar](256) NULL,
	[URLHinhAnh] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[DanhMucGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DanhMuc] ON
INSERT [dbo].[DanhMuc] ([DanhMucGuid], [DanhMucID], [DanhMucName], [TrangThai], [LuuVetDanhMucGuid], [LuuVetDanhMucID], [LuuVetDanhMucName], [DanhMucChaGuid], [DanhMucChaName], [URLHinhAnh]) VALUES (N'5afa6dcc-082f-4a6e-848c-1102217a8e40', 8, N'Món Lẩu - Hầm', 1, N'ddbff0e5-c7ec-4419-811c-d3af8a74601a,', N'17,', N'Menu Món Ăn,', N'ddbff0e5-c7ec-4419-811c-d3af8a74601a', N'Menu Món Ăn', NULL)
INSERT [dbo].[DanhMuc] ([DanhMucGuid], [DanhMucID], [DanhMucName], [TrangThai], [LuuVetDanhMucGuid], [LuuVetDanhMucID], [LuuVetDanhMucName], [DanhMucChaGuid], [DanhMucChaName], [URLHinhAnh]) VALUES (N'6b88969c-413d-4768-935d-352e37bfd90c', 4, N'Món Tráng Miệng', 1, N'ddbff0e5-c7ec-4419-811c-d3af8a74601a,', N'17,', N'Menu Món Ăn,', N'ddbff0e5-c7ec-4419-811c-d3af8a74601a', N'Menu Món Ăn', NULL)
INSERT [dbo].[DanhMuc] ([DanhMucGuid], [DanhMucID], [DanhMucName], [TrangThai], [LuuVetDanhMucGuid], [LuuVetDanhMucID], [LuuVetDanhMucName], [DanhMucChaGuid], [DanhMucChaName], [URLHinhAnh]) VALUES (N'ce0f2b7b-3d2d-4fa6-8fd1-442b6edd5572', 3, N'Món Khai Vị', 1, N'ddbff0e5-c7ec-4419-811c-d3af8a74601a,', N'17,', N'Menu Món Ăn,', N'ddbff0e5-c7ec-4419-811c-d3af8a74601a', N'Menu Món Ăn', NULL)
INSERT [dbo].[DanhMuc] ([DanhMucGuid], [DanhMucID], [DanhMucName], [TrangThai], [LuuVetDanhMucGuid], [LuuVetDanhMucID], [LuuVetDanhMucName], [DanhMucChaGuid], [DanhMucChaName], [URLHinhAnh]) VALUES (N'fa016ebf-740c-4892-a0bd-54288a7f0be1', 13, N'Rượu - Bia', 1, N'ddbff0e5-c7ec-4419-811c-d3af8a74601a,', N'17,', N'Menu Món Ăn,', N'ddbff0e5-c7ec-4419-811c-d3af8a74601a', N'Menu Món Ăn', NULL)
INSERT [dbo].[DanhMuc] ([DanhMucGuid], [DanhMucID], [DanhMucName], [TrangThai], [LuuVetDanhMucGuid], [LuuVetDanhMucID], [LuuVetDanhMucName], [DanhMucChaGuid], [DanhMucChaName], [URLHinhAnh]) VALUES (N'1b17a91b-a080-46e2-8db4-5557c8d6557f', 2, N'Gia Vị', 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DanhMuc] ([DanhMucGuid], [DanhMucID], [DanhMucName], [TrangThai], [LuuVetDanhMucGuid], [LuuVetDanhMucID], [LuuVetDanhMucName], [DanhMucChaGuid], [DanhMucChaName], [URLHinhAnh]) VALUES (N'e8d3397d-0a09-4be8-a061-7174cf8d3ab2', 6, N'Món Xào', 1, N'ddbff0e5-c7ec-4419-811c-d3af8a74601a,', N'17,', N'Menu Món Ăn,', N'ddbff0e5-c7ec-4419-811c-d3af8a74601a', N'Menu Món Ăn', NULL)
INSERT [dbo].[DanhMuc] ([DanhMucGuid], [DanhMucID], [DanhMucName], [TrangThai], [LuuVetDanhMucGuid], [LuuVetDanhMucID], [LuuVetDanhMucName], [DanhMucChaGuid], [DanhMucChaName], [URLHinhAnh]) VALUES (N'd03981d1-006a-4b81-bd5b-73b89c276f86', 15, N'Thịt - Cá', 1, N'83520f24-fa44-48f8-a7bd-9023f5d11c39', N'1', N'Nguyên Liệu', N'83520f24-fa44-48f8-a7bd-9023f5d11c39', N'Nguyên Liệu', NULL)
INSERT [dbo].[DanhMuc] ([DanhMucGuid], [DanhMucID], [DanhMucName], [TrangThai], [LuuVetDanhMucGuid], [LuuVetDanhMucID], [LuuVetDanhMucName], [DanhMucChaGuid], [DanhMucChaName], [URLHinhAnh]) VALUES (N'268c6cbb-2b7f-4863-85c4-8b6138d0bbfd', 7, N'Món Nướng', 1, N'ddbff0e5-c7ec-4419-811c-d3af8a74601a,', N'17,', N'Menu Món Ăn,', N'ddbff0e5-c7ec-4419-811c-d3af8a74601a', N'Menu Món Ăn', NULL)
INSERT [dbo].[DanhMuc] ([DanhMucGuid], [DanhMucID], [DanhMucName], [TrangThai], [LuuVetDanhMucGuid], [LuuVetDanhMucID], [LuuVetDanhMucName], [DanhMucChaGuid], [DanhMucChaName], [URLHinhAnh]) VALUES (N'83520f24-fa44-48f8-a7bd-9023f5d11c39', 1, N'Nguyên Liệu', 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DanhMuc] ([DanhMucGuid], [DanhMucID], [DanhMucName], [TrangThai], [LuuVetDanhMucGuid], [LuuVetDanhMucID], [LuuVetDanhMucName], [DanhMucChaGuid], [DanhMucChaName], [URLHinhAnh]) VALUES (N'92d3d1cd-272a-4f6d-a1b2-acf5a7b0f7c7', 5, N'Món Chiên', 1, N'ddbff0e5-c7ec-4419-811c-d3af8a74601a,', N'17,', N'Menu Món Ăn,', N'ddbff0e5-c7ec-4419-811c-d3af8a74601a', N'Menu Món Ăn', NULL)
INSERT [dbo].[DanhMuc] ([DanhMucGuid], [DanhMucID], [DanhMucName], [TrangThai], [LuuVetDanhMucGuid], [LuuVetDanhMucID], [LuuVetDanhMucName], [DanhMucChaGuid], [DanhMucChaName], [URLHinhAnh]) VALUES (N'9d25f233-5628-4c51-acad-cb7ec0f4afcf', 16, N'Trứng Sữa', 1, N'83520f24-fa44-48f8-a7bd-9023f5d11c39', N'1', N'Nguyên Liệu', N'83520f24-fa44-48f8-a7bd-9023f5d11c39', N'Nguyên Liệu', NULL)
INSERT [dbo].[DanhMuc] ([DanhMucGuid], [DanhMucID], [DanhMucName], [TrangThai], [LuuVetDanhMucGuid], [LuuVetDanhMucID], [LuuVetDanhMucName], [DanhMucChaGuid], [DanhMucChaName], [URLHinhAnh]) VALUES (N'208835c6-57ec-441e-9871-cf165b844296', 11, N'Nước Ngọt', 1, N'ddbff0e5-c7ec-4419-811c-d3af8a74601a,', N'17,', N'Menu Món Ăn,', N'ddbff0e5-c7ec-4419-811c-d3af8a74601a', N'Menu Món Ăn', NULL)
INSERT [dbo].[DanhMuc] ([DanhMucGuid], [DanhMucID], [DanhMucName], [TrangThai], [LuuVetDanhMucGuid], [LuuVetDanhMucID], [LuuVetDanhMucName], [DanhMucChaGuid], [DanhMucChaName], [URLHinhAnh]) VALUES (N'ad2296d6-13e7-449c-8e2f-d1317d520658', 14, N'Rau - Củ - Quả ', 1, N'83520f24-fa44-48f8-a7bd-9023f5d11c39', N'1', N'Nguyên Liệu', N'83520f24-fa44-48f8-a7bd-9023f5d11c39', N'Nguyên Liệu', NULL)
INSERT [dbo].[DanhMuc] ([DanhMucGuid], [DanhMucID], [DanhMucName], [TrangThai], [LuuVetDanhMucGuid], [LuuVetDanhMucID], [LuuVetDanhMucName], [DanhMucChaGuid], [DanhMucChaName], [URLHinhAnh]) VALUES (N'ddbff0e5-c7ec-4419-811c-d3af8a74601a', 17, N'Menu Món Ăn', 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DanhMuc] ([DanhMucGuid], [DanhMucID], [DanhMucName], [TrangThai], [LuuVetDanhMucGuid], [LuuVetDanhMucID], [LuuVetDanhMucName], [DanhMucChaGuid], [DanhMucChaName], [URLHinhAnh]) VALUES (N'52b2fffc-175b-4a16-8e61-e68b769bb2fb', 10, N'Món Mì - Cháo - Sốt', 1, N'ddbff0e5-c7ec-4419-811c-d3af8a74601a,', N'17,', N'Menu Món Ăn,', N'ddbff0e5-c7ec-4419-811c-d3af8a74601a', N'Menu Món Ăn', NULL)
SET IDENTITY_INSERT [dbo].[DanhMuc] OFF
/****** Object:  Table [dbo].[CustomerGroup]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerGroup](
	[CustomerGroupGuid] [uniqueidentifier] NOT NULL,
	[ChinhSachCuaGroup] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerGroupGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CustomerGroup] ([CustomerGroupGuid], [ChinhSachCuaGroup]) VALUES (N'91255e02-05d7-4aad-929e-6b956db4bc31', N'Khách Hàng Thân Thiết')
INSERT [dbo].[CustomerGroup] ([CustomerGroupGuid], [ChinhSachCuaGroup]) VALUES (N'8b27ef8b-f181-4da4-95f9-df3f72d64bdd', N'Khách Vãng Lai')
/****** Object:  Table [dbo].[QuyDinhTraHang]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuyDinhTraHang](
	[QuyDinhTraHangGuid] [uniqueidentifier] NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[ThoiHan] [int] NULL,
	[TyLeKhauTru] [decimal](6, 3) NULL,
PRIMARY KEY CLUSTERED 
(
	[QuyDinhTraHangGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuocGia]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuocGia](
	[QuocGiaGuid] [uniqueidentifier] NOT NULL,
	[MaQuocGia] [char](6) NULL,
	[TenVietTat] [nvarchar](10) NULL,
	[TenQuocGia] [nvarchar](50) NULL,
	[DinhDangSo] [nvarchar](20) NULL,
	[DinhDangTienTe] [nvarchar](20) NULL,
	[DinhDangNgayThang] [nvarchar](30) NULL,
	[URLCoQuocGia] [nvarchar](256) NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[QuocGiaGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[QuocGia] ([QuocGiaGuid], [MaQuocGia], [TenVietTat], [TenQuocGia], [DinhDangSo], [DinhDangTienTe], [DinhDangNgayThang], [URLCoQuocGia], [TrangThai]) VALUES (N'6cae2ff3-f115-4e01-98ee-9cc3fd8a6c4e', N'000084', N'VN', N'Việt Nam', N'0.000,0', N'VNĐ', N'dd/MM/yyyy', N'http://upload.wikimedia.org/wikipedia/commons/2/21/Flag_of_Vietnam.svg', 1)
/****** Object:  Table [dbo].[TinhThanhPho]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TinhThanhPho](
	[TinhThanhPhoGuid] [uniqueidentifier] NOT NULL,
	[QuocGiaGuid] [uniqueidentifier] NOT NULL,
	[MaTinh] [char](6) NULL,
	[TenTinh] [nvarchar](50) NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TinhThanhPhoGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[TinhThanhPho] ([TinhThanhPhoGuid], [QuocGiaGuid], [MaTinh], [TenTinh], [TrangThai]) VALUES (N'91653fd5-3ec8-4406-8e65-86d1d5f96b31', N'6cae2ff3-f115-4e01-98ee-9cc3fd8a6c4e', N'79    ', N'Hồ Chí Minh', 1)
INSERT [dbo].[TinhThanhPho] ([TinhThanhPhoGuid], [QuocGiaGuid], [MaTinh], [TenTinh], [TrangThai]) VALUES (N'f0669019-96dc-423c-83e6-ad67f86c6f82', N'6cae2ff3-f115-4e01-98ee-9cc3fd8a6c4e', N'01    ', N'Hà Nội', 1)
/****** Object:  Table [dbo].[ItemStore]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemStore](
	[ItemStoreGuid] [uniqueidentifier] NOT NULL,
	[DanhMucGuid] [uniqueidentifier] NOT NULL,
	[DonViTinhGuid] [uniqueidentifier] NOT NULL,
	[ItemStoreID] [nvarchar](25) NULL,
	[TenGoi] [nvarchar](256) NULL,
	[URLHinhAnh] [nvarchar](256) NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemStoreGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ItemStore] ([ItemStoreGuid], [DanhMucGuid], [DonViTinhGuid], [ItemStoreID], [TenGoi], [URLHinhAnh], [TrangThai]) VALUES (N'f4f1a51c-760d-4180-b93e-0a2ae597bc10', N'ad2296d6-13e7-449c-8e2f-d1317d520658', N'2af50598-7edc-4719-bcd3-998ba7ec7f50', N'ITST0000000001', N'Cải Xà Lách', N'http://trongraulamvuon.com/wp-content/uploads/2012/07/xalach-1.jpg', 1)
INSERT [dbo].[ItemStore] ([ItemStoreGuid], [DanhMucGuid], [DonViTinhGuid], [ItemStoreID], [TenGoi], [URLHinhAnh], [TrangThai]) VALUES (N'807085b1-c154-4594-a096-1c31d07bcfb9', N'ad2296d6-13e7-449c-8e2f-d1317d520658', N'2af50598-7edc-4719-bcd3-998ba7ec7f50', N'ITST0000000002', N'Khoai Tây', N'http://skds3.vcmedia.vn/2014/ca-22a14.jpg', 1)
INSERT [dbo].[ItemStore] ([ItemStoreGuid], [DanhMucGuid], [DonViTinhGuid], [ItemStoreID], [TenGoi], [URLHinhAnh], [TrangThai]) VALUES (N'39ea2913-ac6d-489d-8ffa-283ca97c8a7b', N'1b17a91b-a080-46e2-8db4-5557c8d6557f', N'2af50598-7edc-4719-bcd3-998ba7ec7f50', N'ITST0000000006', N'Tiêu', N'http://www.giatieu.com/wp-content/uploads/2012/09/tieuden-1.jpg', 1)
INSERT [dbo].[ItemStore] ([ItemStoreGuid], [DanhMucGuid], [DonViTinhGuid], [ItemStoreID], [TenGoi], [URLHinhAnh], [TrangThai]) VALUES (N'9a1da188-a9b1-401f-9695-2c7cbd70c412', N'd03981d1-006a-4b81-bd5b-73b89c276f86', N'42d03a85-e73b-42b6-a9f2-b1e719471f7e', N'ITST0000000013', N'Thịt Heo', N'http://sohanews2.vcmedia.vn/k:2014/1-814de7baac9d5ac95efc34acd126b163-1401683937347/4-thuc-pham-nhat-thiet-khong-duoc-an-chung-voi-thit-lon.jpg', 1)
INSERT [dbo].[ItemStore] ([ItemStoreGuid], [DanhMucGuid], [DonViTinhGuid], [ItemStoreID], [TenGoi], [URLHinhAnh], [TrangThai]) VALUES (N'01f52f20-1592-4033-954b-57a7fb5ea4ca', N'1b17a91b-a080-46e2-8db4-5557c8d6557f', N'd4697583-3dad-409b-a16c-f9594b05f737', N'ITST0000000003', N'Dấm Ăn', N'http://www.suckhoetonghop.com/wp-content/uploads/2014/12/dam-trang.jpg', 1)
INSERT [dbo].[ItemStore] ([ItemStoreGuid], [DanhMucGuid], [DonViTinhGuid], [ItemStoreID], [TenGoi], [URLHinhAnh], [TrangThai]) VALUES (N'fedc0cd9-f3c4-4812-9ad7-585e194415bd', N'1b17a91b-a080-46e2-8db4-5557c8d6557f', N'd4697583-3dad-409b-a16c-f9594b05f737', N'ITST0000000004', N'Dầu Ăn', N'http://dichomuagi.com/uploads/files/D%E1%BA%A7u%20%C4%83n%2C%20M%E1%BA%AFm%2C%20T%C6%B0%C6%A1ng/dau-an-neptune-1lit.jpg', 1)
INSERT [dbo].[ItemStore] ([ItemStoreGuid], [DanhMucGuid], [DonViTinhGuid], [ItemStoreID], [TenGoi], [URLHinhAnh], [TrangThai]) VALUES (N'2b37b153-99cf-4836-960e-59577765abea', N'1b17a91b-a080-46e2-8db4-5557c8d6557f', N'd4697583-3dad-409b-a16c-f9594b05f737', N'ITST0000000009', N'Nước Tương', N'http://dichomuagi.com/uploads/files/D%E1%BA%A7u%20%C4%83n%2C%20M%E1%BA%AFm%2C%20T%C6%B0%C6%A1ng/dau-an-neptune-1lit.jpg', 1)
INSERT [dbo].[ItemStore] ([ItemStoreGuid], [DanhMucGuid], [DonViTinhGuid], [ItemStoreID], [TenGoi], [URLHinhAnh], [TrangThai]) VALUES (N'36837e3e-0cb1-48d1-8c44-8a68625e6165', N'd03981d1-006a-4b81-bd5b-73b89c276f86', N'42d03a85-e73b-42b6-a9f2-b1e719471f7e', N'ITST0000000014', N'Thịt Bò', N'http://sohanews2.vcmedia.vn/zoom/660_360/2014/thituoi1-405a1-5e1f0-crop1401684015327p.jpg', 1)
INSERT [dbo].[ItemStore] ([ItemStoreGuid], [DanhMucGuid], [DonViTinhGuid], [ItemStoreID], [TenGoi], [URLHinhAnh], [TrangThai]) VALUES (N'006f4d41-3a88-4c7f-b16f-9303707e2883', N'1b17a91b-a080-46e2-8db4-5557c8d6557f', N'd4697583-3dad-409b-a16c-f9594b05f737', N'ITST0000000010', N'Nước Mắm', N'http://dichomuagi.com/uploads/files/D%E1%BA%A7u%20%C4%83n%2C%20M%E1%BA%AFm%2C%20T%C6%B0%C6%A1ng/dau-an-neptune-1lit.jpg', 1)
INSERT [dbo].[ItemStore] ([ItemStoreGuid], [DanhMucGuid], [DonViTinhGuid], [ItemStoreID], [TenGoi], [URLHinhAnh], [TrangThai]) VALUES (N'a4de46f0-60f6-4cb4-afb6-b52f20401c2d', N'd03981d1-006a-4b81-bd5b-73b89c276f86', N'2af50598-7edc-4719-bcd3-998ba7ec7f50', N'ITST0000000011', N'Thịt Nguội', N'http://www.meohay.com/wp-content/image/cache/e53e9_hu0ngl0v3_902011102711610251_0.jpg', 1)
INSERT [dbo].[ItemStore] ([ItemStoreGuid], [DanhMucGuid], [DonViTinhGuid], [ItemStoreID], [TenGoi], [URLHinhAnh], [TrangThai]) VALUES (N'3d734bce-64bd-4d20-acda-c358e64158e6', N'1b17a91b-a080-46e2-8db4-5557c8d6557f', N'2af50598-7edc-4719-bcd3-998ba7ec7f50', N'ITST0000000005', N'Muối', N'http://khoahoc.tv/photos/image/082011/19/salt.jpg', 1)
INSERT [dbo].[ItemStore] ([ItemStoreGuid], [DanhMucGuid], [DonViTinhGuid], [ItemStoreID], [TenGoi], [URLHinhAnh], [TrangThai]) VALUES (N'1055dbec-6e54-4d6d-8a56-da9114349e4e', N'1b17a91b-a080-46e2-8db4-5557c8d6557f', N'2af50598-7edc-4719-bcd3-998ba7ec7f50', N'ITST0000000008', N'Bột Ngọt', N'http://images.alobacsi.vn/Images/Uploaded/Share/2013/3/19/Co-nen-nem-bot-ngot-khi-dang-nau-1.jpg', 1)
INSERT [dbo].[ItemStore] ([ItemStoreGuid], [DanhMucGuid], [DonViTinhGuid], [ItemStoreID], [TenGoi], [URLHinhAnh], [TrangThai]) VALUES (N'14e72e1a-557f-4f1d-b21c-e9cd26c6718c', N'd03981d1-006a-4b81-bd5b-73b89c276f86', N'42d03a85-e73b-42b6-a9f2-b1e719471f7e', N'ITST0000000012', N'Thịt Gà Ta', N'http://thucphamsachhanoi.net/images/stores/2015/01/03/0-1-con-ga-ta-que-thanh-pham.jpg', 1)
INSERT [dbo].[ItemStore] ([ItemStoreGuid], [DanhMucGuid], [DonViTinhGuid], [ItemStoreID], [TenGoi], [URLHinhAnh], [TrangThai]) VALUES (N'ae799cc4-7132-4532-ac5e-f86c5f1b4019', N'ad2296d6-13e7-449c-8e2f-d1317d520658', N'2af50598-7edc-4719-bcd3-998ba7ec7f50', N'ITST0000000002', N'Cà Chua', N'http://skds3.vcmedia.vn/2014/ca-22a14.jpg', 1)
INSERT [dbo].[ItemStore] ([ItemStoreGuid], [DanhMucGuid], [DonViTinhGuid], [ItemStoreID], [TenGoi], [URLHinhAnh], [TrangThai]) VALUES (N'a4c4444c-b7cb-49a1-b4cf-fabfc1a2bab6', N'1b17a91b-a080-46e2-8db4-5557c8d6557f', N'2af50598-7edc-4719-bcd3-998ba7ec7f50', N'ITST0000000007', N'Đường', N'http://www.vo.edu.vn/images/post/2014/08/03/22//duong-giup-me-lam-dep-da-hieu-qua-sau-sinh1.jpg', 1)
/****** Object:  Table [dbo].[Customer]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerGuid] [uniqueidentifier] NOT NULL,
	[CustomerGroupGuid] [uniqueidentifier] NOT NULL,
	[Ho] [nvarchar](25) NULL,
	[DiaChi] [nvarchar](256) NULL,
	[DienThoai] [nvarchar](50) NULL,
	[Email] [nvarchar](256) NULL,
	[Phai] [int] NULL,
	[DiaChiNhanHang] [nvarchar](256) NULL,
	[NgayTao] [datetime] NULL,
	[Ten] [nvarchar](25) NULL,
	[TenLot] [nvarchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([CustomerGuid], [CustomerGroupGuid], [Ho], [DiaChi], [DienThoai], [Email], [Phai], [DiaChiNhanHang], [NgayTao], [Ten], [TenLot]) VALUES (N'a2510426-4d2e-4e2c-8639-5723e971a967', N'91255e02-05d7-4aad-929e-6b956db4bc31', N'Nguyễn', N'HUTECH', N'123123325', N'ngocdev@gmail.com', 1, N'HUTECH', CAST(0x0000A42C00000000 AS DateTime), N'Ngọc', N'Văn')
INSERT [dbo].[Customer] ([CustomerGuid], [CustomerGroupGuid], [Ho], [DiaChi], [DienThoai], [Email], [Phai], [DiaChiNhanHang], [NgayTao], [Ten], [TenLot]) VALUES (N'11ed5c56-0d16-424d-98e1-f4a26d6a87de', N'8b27ef8b-f181-4da4-95f9-df3f72d64bdd', N'Khách', N'Khách Vãng Lai', N'Khách Vãng Lai', N'Khách Vãng Lai', 1, N'Khách Vãng Lai', CAST(0x0000A42C00000000 AS DateTime), N'Lai', N'Vãng')
/****** Object:  Table [dbo].[ItemSale]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemSale](
	[ItemSaleGuid] [uniqueidentifier] NOT NULL,
	[DanhMucGuid] [uniqueidentifier] NOT NULL,
	[DonViTinhGuid] [uniqueidentifier] NOT NULL,
	[ItemSaleID] [nvarchar](25) NULL,
	[TenGoi] [nvarchar](256) NULL,
	[GiaBan] [decimal](18, 4) NULL,
	[GiaKhuyenMai] [decimal](18, 4) NULL,
	[URLHinhAnh] [nvarchar](256) NULL,
	[TrangThai] [bit] NULL,
	[ThoiGianBaoHanh] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemSaleGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ItemSale] ([ItemSaleGuid], [DanhMucGuid], [DonViTinhGuid], [ItemSaleID], [TenGoi], [GiaBan], [GiaKhuyenMai], [URLHinhAnh], [TrangThai], [ThoiGianBaoHanh]) VALUES (N'175fbba2-64b0-4af8-9cf2-7bc7a522bb47', N'ce0f2b7b-3d2d-4fa6-8fd1-442b6edd5572', N'31d938a5-c6c3-4beb-ab49-4063fa934933', N'MON0000000000000000000001', N'Salad Dầu Dấm', CAST(99000.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), N'http://thuocgiamcanmy.com/images/2-mon-salad-cho-thuc-don-giam-can-1.jpg', 1, 0)
INSERT [dbo].[ItemSale] ([ItemSaleGuid], [DanhMucGuid], [DonViTinhGuid], [ItemSaleID], [TenGoi], [GiaBan], [GiaKhuyenMai], [URLHinhAnh], [TrangThai], [ThoiGianBaoHanh]) VALUES (N'b2f28635-99b1-43da-98b3-8212dd842200', N'268c6cbb-2b7f-4863-85c4-8b6138d0bbfd', N'31d938a5-c6c3-4beb-ab49-4063fa934933', N'MON0000000000000000000002', N'Gà Ta Nướng Lu', CAST(15000.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'http://amthucgiadinh.net/wp-content/uploads/ga-nuong-lo.jpg', 1, 0)
/****** Object:  Table [dbo].[HoaDonMuaHang]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonMuaHang](
	[HoaDongMuaHangGuid] [uniqueidentifier] NOT NULL,
	[NhaCungCapGuid] [uniqueidentifier] NOT NULL,
	[SoHoaDon] [nvarchar](25) NULL,
	[NgayLap] [datetime] NULL,
	[GiaTriHoaDon] [decimal](18, 4) NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[HoaDongMuaHangGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonBanHang]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonBanHang](
	[HoaDonBanHangGuid] [uniqueidentifier] NOT NULL,
	[KhuVucBanHangGuid] [uniqueidentifier] NULL,
	[CustomerGuid] [uniqueidentifier] NOT NULL,
	[NhanVienGuid] [uniqueidentifier] NOT NULL,
	[SoHoaDon] [nvarchar](25) NULL,
	[GiaTriDonHang] [decimal](18, 4) NULL,
	[ThoiGianLapPhieu] [datetime] NULL,
	[TienVAT] [decimal](18, 4) NULL,
	[TienChietKhau] [decimal](18, 4) NULL,
	[GhiChu] [nvarchar](max) NULL,
	[TrangThaiHoaDon] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[HoaDonBanHangGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid], [KhuVucBanHangGuid], [CustomerGuid], [NhanVienGuid], [SoHoaDon], [GiaTriDonHang], [ThoiGianLapPhieu], [TienVAT], [TienChietKhau], [GhiChu], [TrangThaiHoaDon]) VALUES (N'99c49074-4059-4e98-95d5-372e0b7369b6', N'0e43818a-73d5-46ec-9e93-1be74f20cad0', N'11ed5c56-0d16-424d-98e1-f4a26d6a87de', N'84c8e930-7a32-4bd4-8f79-960f136485f3', N'HDBH000000000000000000013', CAST(9801000.0000 AS Decimal(18, 4)), CAST(0x0000A45C014A3408 AS DateTime), CAST(891000.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), N'ban-vip', 1)
INSERT [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid], [KhuVucBanHangGuid], [CustomerGuid], [NhanVienGuid], [SoHoaDon], [GiaTriDonHang], [ThoiGianLapPhieu], [TienVAT], [TienChietKhau], [GhiChu], [TrangThaiHoaDon]) VALUES (N'de3c7492-b99c-43ae-b021-48cf2127090f', N'eb812fb3-52b9-40d9-b220-52e653ca73ce', N'11ed5c56-0d16-424d-98e1-f4a26d6a87de', N'2511938b-5a63-4d1b-a517-fceea072582e', N'HDBH000000000000000000010', CAST(867900.0000 AS Decimal(18, 4)), CAST(0x0000A443015872E8 AS DateTime), CAST(78900.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), N'sdsadsad-sad-sa-dsa-dsa-dsa-dsa-d', 1)
INSERT [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid], [KhuVucBanHangGuid], [CustomerGuid], [NhanVienGuid], [SoHoaDon], [GiaTriDonHang], [ThoiGianLapPhieu], [TienVAT], [TienChietKhau], [GhiChu], [TrangThaiHoaDon]) VALUES (N'2b495f77-ee97-447b-9cb1-82d1562e3c4a', N'1fa199b3-5607-4e0b-93c5-89cd9451a661', N'a2510426-4d2e-4e2c-8639-5723e971a967', N'2511938b-5a63-4d1b-a517-fceea072582e', N'HDBH000000000000000000019', CAST(442198.9000 AS Decimal(18, 4)), CAST(0x0000A45E00029748 AS DateTime), CAST(40199.9000 AS Decimal(18, 4)), CAST(9001.0000 AS Decimal(18, 4)), N'', 1)
INSERT [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid], [KhuVucBanHangGuid], [CustomerGuid], [NhanVienGuid], [SoHoaDon], [GiaTriDonHang], [ThoiGianLapPhieu], [TienVAT], [TienChietKhau], [GhiChu], [TrangThaiHoaDon]) VALUES (N'b8d1f445-01aa-4791-8941-87edcf159e6a', N'eee41842-7ab2-48b8-99f9-3461e4c9c538', N'a2510426-4d2e-4e2c-8639-5723e971a967', N'84c8e930-7a32-4bd4-8f79-960f136485f3', N'HDBH000000000000000000012', CAST(115500.0000 AS Decimal(18, 4)), CAST(0x0000A45C014A1B6C AS DateTime), CAST(10500.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), N'ban-vip', 1)
INSERT [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid], [KhuVucBanHangGuid], [CustomerGuid], [NhanVienGuid], [SoHoaDon], [GiaTriDonHang], [ThoiGianLapPhieu], [TienVAT], [TienChietKhau], [GhiChu], [TrangThaiHoaDon]) VALUES (N'ea0f8c8d-16ed-4321-a56c-88ed8130891d', N'bc9e30ef-f169-499f-b4d4-bcbdfa028400', N'a2510426-4d2e-4e2c-8639-5723e971a967', N'84c8e930-7a32-4bd4-8f79-960f136485f3', N'HDBH000000000000000000017', CAST(1253864700.0000 AS Decimal(18, 4)), CAST(0x0000A45D01894E54 AS DateTime), CAST(113987700.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), N'dsf-sdf-ds-fsdf-ds-fsdf-sd-f', 1)
INSERT [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid], [KhuVucBanHangGuid], [CustomerGuid], [NhanVienGuid], [SoHoaDon], [GiaTriDonHang], [ThoiGianLapPhieu], [TienVAT], [TienChietKhau], [GhiChu], [TrangThaiHoaDon]) VALUES (N'3eb90e47-188c-4f93-ac45-8aae93da6945', N'eb812fb3-52b9-40d9-b220-52e653ca73ce', N'11ed5c56-0d16-424d-98e1-f4a26d6a87de', N'84c8e930-7a32-4bd4-8f79-960f136485f3', N'HDBH000000000000000000008', CAST(16500.0000 AS Decimal(18, 4)), CAST(0x0000A45C00022CA4 AS DateTime), CAST(1500.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'ban-vip', 1)
INSERT [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid], [KhuVucBanHangGuid], [CustomerGuid], [NhanVienGuid], [SoHoaDon], [GiaTriDonHang], [ThoiGianLapPhieu], [TienVAT], [TienChietKhau], [GhiChu], [TrangThaiHoaDon]) VALUES (N'87a64c29-a50e-4818-8622-9eaa533138cf', N'eb812fb3-52b9-40d9-b220-52e653ca73ce', N'a2510426-4d2e-4e2c-8639-5723e971a967', N'84c8e930-7a32-4bd4-8f79-960f136485f3', N'HDBH000000000000000000009', CAST(594000.0000 AS Decimal(18, 4)), CAST(0x0000A45C001A71EC AS DateTime), CAST(54000.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), N'ban-vip', 1)
INSERT [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid], [KhuVucBanHangGuid], [CustomerGuid], [NhanVienGuid], [SoHoaDon], [GiaTriDonHang], [ThoiGianLapPhieu], [TienVAT], [TienChietKhau], [GhiChu], [TrangThaiHoaDon]) VALUES (N'94676753-49f0-4199-9921-bb2db1602db3', N'720e4f29-4dcb-46e5-8829-aef4d5222ea0', N'11ed5c56-0d16-424d-98e1-f4a26d6a87de', N'84c8e930-7a32-4bd4-8f79-960f136485f3', N'HDBH000000000000000000020', CAST(1088963700.0000 AS Decimal(18, 4)), CAST(0x0000A45E000BDC54 AS DateTime), CAST(98996700.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), N'', 0)
INSERT [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid], [KhuVucBanHangGuid], [CustomerGuid], [NhanVienGuid], [SoHoaDon], [GiaTriDonHang], [ThoiGianLapPhieu], [TienVAT], [TienChietKhau], [GhiChu], [TrangThaiHoaDon]) VALUES (N'f895c04e-fef8-4624-85ea-d2e6dcad2bec', N'0e43818a-73d5-46ec-9e93-1be74f20cad0', N'a2510426-4d2e-4e2c-8639-5723e971a967', N'84c8e930-7a32-4bd4-8f79-960f136485f3', N'HDBH000000000000000000014', CAST(1633500.0000 AS Decimal(18, 4)), CAST(0x0000A45C014A53AC AS DateTime), CAST(148500.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'ban-vip', 1)
INSERT [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid], [KhuVucBanHangGuid], [CustomerGuid], [NhanVienGuid], [SoHoaDon], [GiaTriDonHang], [ThoiGianLapPhieu], [TienVAT], [TienChietKhau], [GhiChu], [TrangThaiHoaDon]) VALUES (N'8c39546c-c3d2-4681-885b-dcfacae0b9ca', N'c7d48ae4-54fc-4af7-9018-fc11bfe11a5c', N'a2510426-4d2e-4e2c-8639-5723e971a967', N'2511938b-5a63-4d1b-a517-fceea072582e', N'HDBH000000000000000000006', CAST(99000.0000 AS Decimal(18, 4)), CAST(0x0000A45500E72958 AS DateTime), CAST(9000.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), N'ban-vip', 1)
INSERT [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid], [KhuVucBanHangGuid], [CustomerGuid], [NhanVienGuid], [SoHoaDon], [GiaTriDonHang], [ThoiGianLapPhieu], [TienVAT], [TienChietKhau], [GhiChu], [TrangThaiHoaDon]) VALUES (N'16f54fba-51e4-44c3-baf7-f5d0903aa934', N'fedc0cd9-f3c4-4812-9ad7-585e194415bd', N'11ed5c56-0d16-424d-98e1-f4a26d6a87de', N'2511938b-5a63-4d1b-a517-fceea072582e', N'HDBH000000000000000000007', CAST(16500.0000 AS Decimal(18, 4)), CAST(0x0000A45B018A8BE8 AS DateTime), CAST(1500.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'ban-vip', 1)
INSERT [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid], [KhuVucBanHangGuid], [CustomerGuid], [NhanVienGuid], [SoHoaDon], [GiaTriDonHang], [ThoiGianLapPhieu], [TienVAT], [TienChietKhau], [GhiChu], [TrangThaiHoaDon]) VALUES (N'361d6e5f-d7ff-4858-ad12-f6439646244c', N'1fa199b3-5607-4e0b-93c5-89cd9451a661', N'a2510426-4d2e-4e2c-8639-5723e971a967', N'40832c0d-e3f5-471c-bee6-0215d215409c', N'HDBH000000000000000000018', CAST(115500.0000 AS Decimal(18, 4)), CAST(0x0000A45D018B175C AS DateTime), CAST(10500.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), N'efew ew few f', 1)
INSERT [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid], [KhuVucBanHangGuid], [CustomerGuid], [NhanVienGuid], [SoHoaDon], [GiaTriDonHang], [ThoiGianLapPhieu], [TienVAT], [TienChietKhau], [GhiChu], [TrangThaiHoaDon]) VALUES (N'0809d1be-fd6f-440d-86b3-f6895add5dad', N'eee41842-7ab2-48b8-99f9-3461e4c9c538', N'11ed5c56-0d16-424d-98e1-f4a26d6a87de', N'84c8e930-7a32-4bd4-8f79-960f136485f3', N'HDBH000000000000000000015', CAST(115500.0000 AS Decimal(18, 4)), CAST(0x0000A45D00025B84 AS DateTime), CAST(10500.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), N'sdqw-dqwd-wqd-wq', 1)
/****** Object:  Table [dbo].[ItemSaleDetail]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemSaleDetail](
	[ItemStoreGuid] [uniqueidentifier] NOT NULL,
	[ItemSaleGuid] [uniqueidentifier] NOT NULL,
	[SoLuong] [decimal](18, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemStoreGuid] ASC,
	[ItemSaleGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ItemSaleDetail] ([ItemStoreGuid], [ItemSaleGuid], [SoLuong]) VALUES (N'f4f1a51c-760d-4180-b93e-0a2ae597bc10', N'175fbba2-64b0-4af8-9cf2-7bc7a522bb47', CAST(100.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemSaleDetail] ([ItemStoreGuid], [ItemSaleGuid], [SoLuong]) VALUES (N'39ea2913-ac6d-489d-8ffa-283ca97c8a7b', N'175fbba2-64b0-4af8-9cf2-7bc7a522bb47', CAST(1.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemSaleDetail] ([ItemStoreGuid], [ItemSaleGuid], [SoLuong]) VALUES (N'39ea2913-ac6d-489d-8ffa-283ca97c8a7b', N'b2f28635-99b1-43da-98b3-8212dd842200', CAST(0.5000 AS Decimal(18, 4)))
INSERT [dbo].[ItemSaleDetail] ([ItemStoreGuid], [ItemSaleGuid], [SoLuong]) VALUES (N'01f52f20-1592-4033-954b-57a7fb5ea4ca', N'175fbba2-64b0-4af8-9cf2-7bc7a522bb47', CAST(2.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemSaleDetail] ([ItemStoreGuid], [ItemSaleGuid], [SoLuong]) VALUES (N'fedc0cd9-f3c4-4812-9ad7-585e194415bd', N'175fbba2-64b0-4af8-9cf2-7bc7a522bb47', CAST(2.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemSaleDetail] ([ItemStoreGuid], [ItemSaleGuid], [SoLuong]) VALUES (N'fedc0cd9-f3c4-4812-9ad7-585e194415bd', N'b2f28635-99b1-43da-98b3-8212dd842200', CAST(0.5000 AS Decimal(18, 4)))
INSERT [dbo].[ItemSaleDetail] ([ItemStoreGuid], [ItemSaleGuid], [SoLuong]) VALUES (N'3d734bce-64bd-4d20-acda-c358e64158e6', N'b2f28635-99b1-43da-98b3-8212dd842200', CAST(0.3000 AS Decimal(18, 4)))
INSERT [dbo].[ItemSaleDetail] ([ItemStoreGuid], [ItemSaleGuid], [SoLuong]) VALUES (N'1055dbec-6e54-4d6d-8a56-da9114349e4e', N'b2f28635-99b1-43da-98b3-8212dd842200', CAST(0.1000 AS Decimal(18, 4)))
INSERT [dbo].[ItemSaleDetail] ([ItemStoreGuid], [ItemSaleGuid], [SoLuong]) VALUES (N'14e72e1a-557f-4f1d-b21c-e9cd26c6718c', N'b2f28635-99b1-43da-98b3-8212dd842200', CAST(0.5000 AS Decimal(18, 4)))
INSERT [dbo].[ItemSaleDetail] ([ItemStoreGuid], [ItemSaleGuid], [SoLuong]) VALUES (N'ae799cc4-7132-4532-ac5e-f86c5f1b4019', N'175fbba2-64b0-4af8-9cf2-7bc7a522bb47', CAST(100.0000 AS Decimal(18, 4)))
/****** Object:  Table [dbo].[ChiNhanhCongTy]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiNhanhCongTy](
	[ChiNhanhGuid] [uniqueidentifier] NOT NULL,
	[TinhThanhPhoGuid] [uniqueidentifier] NOT NULL,
	[ChiNhanhID] [nvarchar](25) NULL,
	[TenChiNhanh] [nvarchar](256) NULL,
	[DiaChi] [nvarchar](256) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ChiNhanhGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiNhanhCongTy] ([ChiNhanhGuid], [TinhThanhPhoGuid], [ChiNhanhID], [TenChiNhanh], [DiaChi], [SoDienThoai], [TrangThai]) VALUES (N'a47a3742-1254-45fd-8cb3-1ea14a988cb4', N'f0669019-96dc-423c-83e6-ad67f86c6f82', N'NH000000002', N'Nhà Hàng Ẩm Thực Phố Cổ', N'1C Khu Liên Hợp Thể Thao, Lê Đức Thọ, Xã Mỹ Đình, Từ Liêm, Hà Nội', N'0902583976', 1)
INSERT [dbo].[ChiNhanhCongTy] ([ChiNhanhGuid], [TinhThanhPhoGuid], [ChiNhanhID], [TenChiNhanh], [DiaChi], [SoDienThoai], [TrangThai]) VALUES (N'b463847f-6dd4-41fa-9689-836b5053ad93', N'91653fd5-3ec8-4406-8e65-86d1d5f96b31', N'NH000000001', N'Nhà Hành Ẩm Thực 3 Miền', N'265 Nguyễn Thái Sơn, Phường 7, Quận Gò Vấp, TP. Hồ Chí Minh', N'0902583976', 1)
/****** Object:  Table [dbo].[ChiTietHoaDonMuaHang]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDonMuaHang](
	[ItemStoreGuid] [uniqueidentifier] NOT NULL,
	[HoaDongMuaHangGuid] [uniqueidentifier] NOT NULL,
	[SoLuong] [decimal](18, 4) NULL,
	[DonGia] [decimal](18, 4) NULL,
	[ThoiGianBaoHanh] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemStoreGuid] ASC,
	[HoaDongMuaHangGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDonBanHang]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDonBanHang](
	[HoaDonBanHangGuid] [uniqueidentifier] NOT NULL,
	[ItemSaleGuid] [uniqueidentifier] NOT NULL,
	[SoLuong] [decimal](18, 4) NULL,
	[DonGia] [decimal](18, 4) NULL,
	[TienChietKhau] [decimal](18, 4) NULL,
	[ThoiGianBaoHanh] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[HoaDonBanHangGuid] ASC,
	[ItemSaleGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'99c49074-4059-4e98-95d5-372e0b7369b6', N'175fbba2-64b0-4af8-9cf2-7bc7a522bb47', CAST(99.0000 AS Decimal(18, 4)), CAST(99000.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'de3c7492-b99c-43ae-b021-48cf2127090f', N'175fbba2-64b0-4af8-9cf2-7bc7a522bb47', CAST(7.0000 AS Decimal(18, 4)), CAST(99000.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'de3c7492-b99c-43ae-b021-48cf2127090f', N'b2f28635-99b1-43da-98b3-8212dd842200', CAST(6.0000 AS Decimal(18, 4)), CAST(15000.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'2b495f77-ee97-447b-9cb1-82d1562e3c4a', N'175fbba2-64b0-4af8-9cf2-7bc7a522bb47', CAST(4.0000 AS Decimal(18, 4)), CAST(99000.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'2b495f77-ee97-447b-9cb1-82d1562e3c4a', N'b2f28635-99b1-43da-98b3-8212dd842200', CAST(1.0000 AS Decimal(18, 4)), CAST(15000.0000 AS Decimal(18, 4)), CAST(1.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'b8d1f445-01aa-4791-8941-87edcf159e6a', N'175fbba2-64b0-4af8-9cf2-7bc7a522bb47', CAST(1.0000 AS Decimal(18, 4)), CAST(99000.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'b8d1f445-01aa-4791-8941-87edcf159e6a', N'b2f28635-99b1-43da-98b3-8212dd842200', CAST(1.0000 AS Decimal(18, 4)), CAST(15000.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'ea0f8c8d-16ed-4321-a56c-88ed8130891d', N'175fbba2-64b0-4af8-9cf2-7bc7a522bb47', CAST(9999.0000 AS Decimal(18, 4)), CAST(99000.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'ea0f8c8d-16ed-4321-a56c-88ed8130891d', N'b2f28635-99b1-43da-98b3-8212dd842200', CAST(9999.0000 AS Decimal(18, 4)), CAST(15000.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'3eb90e47-188c-4f93-ac45-8aae93da6945', N'b2f28635-99b1-43da-98b3-8212dd842200', CAST(1.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'87a64c29-a50e-4818-8622-9eaa533138cf', N'175fbba2-64b0-4af8-9cf2-7bc7a522bb47', CAST(6.0000 AS Decimal(18, 4)), CAST(99000.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'94676753-49f0-4199-9921-bb2db1602db3', N'175fbba2-64b0-4af8-9cf2-7bc7a522bb47', CAST(9999.0000 AS Decimal(18, 4)), CAST(99000.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'94676753-49f0-4199-9921-bb2db1602db3', N'b2f28635-99b1-43da-98b3-8212dd842200', CAST(5.0000 AS Decimal(18, 4)), CAST(15000.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'f895c04e-fef8-4624-85ea-d2e6dcad2bec', N'b2f28635-99b1-43da-98b3-8212dd842200', CAST(99.0000 AS Decimal(18, 4)), CAST(15000.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'8c39546c-c3d2-4681-885b-dcfacae0b9ca', N'175fbba2-64b0-4af8-9cf2-7bc7a522bb47', CAST(1.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'16f54fba-51e4-44c3-baf7-f5d0903aa934', N'b2f28635-99b1-43da-98b3-8212dd842200', CAST(1.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'361d6e5f-d7ff-4858-ad12-f6439646244c', N'175fbba2-64b0-4af8-9cf2-7bc7a522bb47', CAST(1.0000 AS Decimal(18, 4)), CAST(99000.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'361d6e5f-d7ff-4858-ad12-f6439646244c', N'b2f28635-99b1-43da-98b3-8212dd842200', CAST(1.0000 AS Decimal(18, 4)), CAST(15000.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'0809d1be-fd6f-440d-86b3-f6895add5dad', N'175fbba2-64b0-4af8-9cf2-7bc7a522bb47', CAST(1.0000 AS Decimal(18, 4)), CAST(99000.0000 AS Decimal(18, 4)), CAST(9000.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[ChiTietHoaDonBanHang] ([HoaDonBanHangGuid], [ItemSaleGuid], [SoLuong], [DonGia], [TienChietKhau], [ThoiGianBaoHanh]) VALUES (N'0809d1be-fd6f-440d-86b3-f6895add5dad', N'b2f28635-99b1-43da-98b3-8212dd842200', CAST(1.0000 AS Decimal(18, 4)), CAST(15000.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 0)
/****** Object:  Table [dbo].[PhieuGiaoHang]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuGiaoHang](
	[PhieuGiaoHangGuid] [uniqueidentifier] NOT NULL,
	[HoaDonBanHangGuid] [uniqueidentifier] NOT NULL,
	[CustomerGuid] [uniqueidentifier] NOT NULL,
	[NhanVienGuid] [uniqueidentifier] NOT NULL,
	[SoPhieu] [nvarchar](25) NULL,
	[ThoiGianLapPhieu] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PhieuGiaoHangGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuTraHang]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuTraHang](
	[PhieuTraHangGuid] [uniqueidentifier] NOT NULL,
	[NhanVienGuid] [uniqueidentifier] NOT NULL,
	[HoaDonBanHangGuid] [uniqueidentifier] NOT NULL,
	[SoPhieu] [nvarchar](25) NULL,
	[ThoiGianLapPhieu] [datetime] NOT NULL,
	[TongTienHoanTra] [decimal](18, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[PhieuTraHangGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoHang]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoHang](
	[KhoHangGuid] [uniqueidentifier] NOT NULL,
	[ChiNhanhGuid] [uniqueidentifier] NOT NULL,
	[KhoHangID] [nvarchar](25) NULL,
	[TenKhoHang] [nvarchar](256) NULL,
	[DiaChi] [nvarchar](256) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[KhoHangGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[KhoHang] ([KhoHangGuid], [ChiNhanhGuid], [KhoHangID], [TenKhoHang], [DiaChi], [SoDienThoai]) VALUES (N'cd871b34-567c-4cf2-a251-b149f068870a', N'a47a3742-1254-45fd-8cb3-1ea14a988cb4', N'KH0002', N'Kho Hàng Miền Bắc', N'1C Khu Liên Hợp Thể Thao, Lê Đức Thọ, Xã Mỹ Đình, Từ Liêm, Hà Nội', N'0989959545')
INSERT [dbo].[KhoHang] ([KhoHangGuid], [ChiNhanhGuid], [KhoHangID], [TenKhoHang], [DiaChi], [SoDienThoai]) VALUES (N'79f908a3-98e4-46fc-9a04-cb3f69b75739', N'b463847f-6dd4-41fa-9689-836b5053ad93', N'KH0001', N'Kho Hàng Miền Nam', N'265 Nguyễn Thái Sơn, Phường 7, Quận Gò Vấp, TP. Hồ Chí Minh', N'0902583976')
/****** Object:  Table [dbo].[ItemStoreDetail]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemStoreDetail](
	[KhoHangGuid] [uniqueidentifier] NOT NULL,
	[ItemStoreGuid] [uniqueidentifier] NOT NULL,
	[SoLuong] [decimal](18, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[KhoHangGuid] ASC,
	[ItemStoreGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ItemStoreDetail] ([KhoHangGuid], [ItemStoreGuid], [SoLuong]) VALUES (N'79f908a3-98e4-46fc-9a04-cb3f69b75739', N'f4f1a51c-760d-4180-b93e-0a2ae597bc10', CAST(10100.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemStoreDetail] ([KhoHangGuid], [ItemStoreGuid], [SoLuong]) VALUES (N'79f908a3-98e4-46fc-9a04-cb3f69b75739', N'807085b1-c154-4594-a096-1c31d07bcfb9', CAST(10000.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemStoreDetail] ([KhoHangGuid], [ItemStoreGuid], [SoLuong]) VALUES (N'79f908a3-98e4-46fc-9a04-cb3f69b75739', N'39ea2913-ac6d-489d-8ffa-283ca97c8a7b', CAST(9998.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemStoreDetail] ([KhoHangGuid], [ItemStoreGuid], [SoLuong]) VALUES (N'79f908a3-98e4-46fc-9a04-cb3f69b75739', N'9a1da188-a9b1-401f-9695-2c7cbd70c412', CAST(10000.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemStoreDetail] ([KhoHangGuid], [ItemStoreGuid], [SoLuong]) VALUES (N'79f908a3-98e4-46fc-9a04-cb3f69b75739', N'01f52f20-1592-4033-954b-57a7fb5ea4ca', CAST(9996.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemStoreDetail] ([KhoHangGuid], [ItemStoreGuid], [SoLuong]) VALUES (N'79f908a3-98e4-46fc-9a04-cb3f69b75739', N'fedc0cd9-f3c4-4812-9ad7-585e194415bd', CAST(9996.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemStoreDetail] ([KhoHangGuid], [ItemStoreGuid], [SoLuong]) VALUES (N'79f908a3-98e4-46fc-9a04-cb3f69b75739', N'2b37b153-99cf-4836-960e-59577765abea', CAST(10000.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemStoreDetail] ([KhoHangGuid], [ItemStoreGuid], [SoLuong]) VALUES (N'79f908a3-98e4-46fc-9a04-cb3f69b75739', N'36837e3e-0cb1-48d1-8c44-8a68625e6165', CAST(10000.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemStoreDetail] ([KhoHangGuid], [ItemStoreGuid], [SoLuong]) VALUES (N'79f908a3-98e4-46fc-9a04-cb3f69b75739', N'006f4d41-3a88-4c7f-b16f-9303707e2883', CAST(10000.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemStoreDetail] ([KhoHangGuid], [ItemStoreGuid], [SoLuong]) VALUES (N'79f908a3-98e4-46fc-9a04-cb3f69b75739', N'a4de46f0-60f6-4cb4-afb6-b52f20401c2d', CAST(10000.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemStoreDetail] ([KhoHangGuid], [ItemStoreGuid], [SoLuong]) VALUES (N'79f908a3-98e4-46fc-9a04-cb3f69b75739', N'3d734bce-64bd-4d20-acda-c358e64158e6', CAST(10000.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemStoreDetail] ([KhoHangGuid], [ItemStoreGuid], [SoLuong]) VALUES (N'79f908a3-98e4-46fc-9a04-cb3f69b75739', N'1055dbec-6e54-4d6d-8a56-da9114349e4e', CAST(10000.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemStoreDetail] ([KhoHangGuid], [ItemStoreGuid], [SoLuong]) VALUES (N'79f908a3-98e4-46fc-9a04-cb3f69b75739', N'14e72e1a-557f-4f1d-b21c-e9cd26c6718c', CAST(10000.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemStoreDetail] ([KhoHangGuid], [ItemStoreGuid], [SoLuong]) VALUES (N'79f908a3-98e4-46fc-9a04-cb3f69b75739', N'ae799cc4-7132-4532-ac5e-f86c5f1b4019', CAST(9800.0000 AS Decimal(18, 4)))
INSERT [dbo].[ItemStoreDetail] ([KhoHangGuid], [ItemStoreGuid], [SoLuong]) VALUES (N'79f908a3-98e4-46fc-9a04-cb3f69b75739', N'a4c4444c-b7cb-49a1-b4cf-fabfc1a2bab6', CAST(10000.0000 AS Decimal(18, 4)))
/****** Object:  Table [dbo].[ChiTietPhieuGiaoHang]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuGiaoHang](
	[PhieuGiaoHangGuid] [uniqueidentifier] NOT NULL,
	[ItemSaleGuid] [uniqueidentifier] NOT NULL,
	[SoLuong] [decimal](18, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[PhieuGiaoHangGuid] ASC,
	[ItemSaleGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuXuatKho]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuXuatKho](
	[PhieuXuatKhoGuid] [uniqueidentifier] NOT NULL,
	[HoaDonBanHangGuid] [uniqueidentifier] NOT NULL,
	[NhanVienGuid] [uniqueidentifier] NOT NULL,
	[KhoHangGuid] [uniqueidentifier] NOT NULL,
	[SoPhieu] [nvarchar](25) NOT NULL,
	[ThoiGianLapPhieu] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PhieuXuatKhoGuid] ASC,
	[HoaDonBanHangGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuXuatDieuChuyen]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuXuatDieuChuyen](
	[PhieuXuatDieuChuyenGuid] [uniqueidentifier] NOT NULL,
	[KhoHangGuid] [uniqueidentifier] NOT NULL,
	[NhanVienGuid] [uniqueidentifier] NOT NULL,
	[SoPhieu] [nvarchar](25) NULL,
	[ThoiGianLapPhieu] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PhieuXuatDieuChuyenGuid] ASC,
	[NhanVienGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhapKho]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhapKho](
	[PhieuNhapKhoGuid] [uniqueidentifier] NOT NULL,
	[KhoHangGuid] [uniqueidentifier] NOT NULL,
	[NhanVienGuid] [uniqueidentifier] NOT NULL,
	[SoPhieu] [nvarchar](25) NULL,
	[ThoiGianLapPhieu] [datetime] NULL,
	[GiaTriDonHang] [decimal](18, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[PhieuNhapKhoGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuTraHang]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuTraHang](
	[ItemSaleGuid] [uniqueidentifier] NOT NULL,
	[PhieuTraHangGuid] [uniqueidentifier] NOT NULL,
	[SoLuong] [decimal](18, 4) NULL,
	[TienKhauTru] [decimal](18, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemSaleGuid] ASC,
	[PhieuTraHangGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhapKho]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhapKho](
	[PhieuNhapKhoGuid] [uniqueidentifier] NOT NULL,
	[ItemStoreGuid] [uniqueidentifier] NOT NULL,
	[SoLuong] [decimal](18, 4) NULL,
	[DonGia] [decimal](18, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[PhieuNhapKhoGuid] ASC,
	[ItemStoreGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuXuatKho]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuXuatKho](
	[PhieuXuatKhoGuid] [uniqueidentifier] NOT NULL,
	[ItemStoreGuid] [uniqueidentifier] NOT NULL,
	[HoaDonBanHangGuid] [uniqueidentifier] NOT NULL,
	[SoLuong] [decimal](18, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[PhieuXuatKhoGuid] ASC,
	[ItemStoreGuid] ASC,
	[HoaDonBanHangGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuXuatDieuChuyen]    Script Date: 03/17/2015 03:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuXuatDieuChuyen](
	[PhieuXuatDieuChuyenGuid] [uniqueidentifier] NOT NULL,
	[NhanVienGuid] [uniqueidentifier] NOT NULL,
	[ItemStoreGuid] [uniqueidentifier] NOT NULL,
	[SoLuong] [decimal](18, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[PhieuXuatDieuChuyenGuid] ASC,
	[NhanVienGuid] ASC,
	[ItemStoreGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK__ChiNhanhC__TinhT__41EDCAC5]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiNhanhCongTy]  WITH CHECK ADD FOREIGN KEY([TinhThanhPhoGuid])
REFERENCES [dbo].[TinhThanhPho] ([TinhThanhPhoGuid])
GO
/****** Object:  ForeignKey [FK__ChiNhanhC__TinhT__6FE99F9F]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiNhanhCongTy]  WITH CHECK ADD FOREIGN KEY([TinhThanhPhoGuid])
REFERENCES [dbo].[TinhThanhPho] ([TinhThanhPhoGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietHo__HoaDo__42E1EEFE]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietHoaDonBanHang]  WITH CHECK ADD FOREIGN KEY([HoaDonBanHangGuid])
REFERENCES [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietHo__HoaDo__70DDC3D8]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietHoaDonBanHang]  WITH CHECK ADD FOREIGN KEY([HoaDonBanHangGuid])
REFERENCES [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietHo__ItemS__43D61337]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietHoaDonBanHang]  WITH CHECK ADD FOREIGN KEY([ItemSaleGuid])
REFERENCES [dbo].[ItemSale] ([ItemSaleGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietHo__ItemS__71D1E811]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietHoaDonBanHang]  WITH CHECK ADD FOREIGN KEY([ItemSaleGuid])
REFERENCES [dbo].[ItemSale] ([ItemSaleGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietHo__HoaDo__44CA3770]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietHoaDonMuaHang]  WITH CHECK ADD FOREIGN KEY([HoaDongMuaHangGuid])
REFERENCES [dbo].[HoaDonMuaHang] ([HoaDongMuaHangGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietHo__HoaDo__72C60C4A]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietHoaDonMuaHang]  WITH CHECK ADD FOREIGN KEY([HoaDongMuaHangGuid])
REFERENCES [dbo].[HoaDonMuaHang] ([HoaDongMuaHangGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietHo__ItemS__45BE5BA9]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietHoaDonMuaHang]  WITH CHECK ADD FOREIGN KEY([ItemStoreGuid])
REFERENCES [dbo].[ItemStore] ([ItemStoreGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietHo__ItemS__73BA3083]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietHoaDonMuaHang]  WITH CHECK ADD FOREIGN KEY([ItemStoreGuid])
REFERENCES [dbo].[ItemStore] ([ItemStoreGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPh__ItemS__46B27FE2]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuGiaoHang]  WITH CHECK ADD FOREIGN KEY([ItemSaleGuid])
REFERENCES [dbo].[ItemSale] ([ItemSaleGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPh__ItemS__74AE54BC]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuGiaoHang]  WITH CHECK ADD FOREIGN KEY([ItemSaleGuid])
REFERENCES [dbo].[ItemSale] ([ItemSaleGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPh__Phieu__47A6A41B]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuGiaoHang]  WITH CHECK ADD FOREIGN KEY([PhieuGiaoHangGuid])
REFERENCES [dbo].[PhieuGiaoHang] ([PhieuGiaoHangGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPh__Phieu__75A278F5]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuGiaoHang]  WITH CHECK ADD FOREIGN KEY([PhieuGiaoHangGuid])
REFERENCES [dbo].[PhieuGiaoHang] ([PhieuGiaoHangGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPh__ItemS__489AC854]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuNhapKho]  WITH CHECK ADD FOREIGN KEY([ItemStoreGuid])
REFERENCES [dbo].[ItemStore] ([ItemStoreGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPh__ItemS__76969D2E]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuNhapKho]  WITH CHECK ADD FOREIGN KEY([ItemStoreGuid])
REFERENCES [dbo].[ItemStore] ([ItemStoreGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPh__Phieu__498EEC8D]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuNhapKho]  WITH CHECK ADD FOREIGN KEY([PhieuNhapKhoGuid])
REFERENCES [dbo].[PhieuNhapKho] ([PhieuNhapKhoGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPh__Phieu__778AC167]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuNhapKho]  WITH CHECK ADD FOREIGN KEY([PhieuNhapKhoGuid])
REFERENCES [dbo].[PhieuNhapKho] ([PhieuNhapKhoGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPh__ItemS__4A8310C6]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuTraHang]  WITH CHECK ADD FOREIGN KEY([ItemSaleGuid])
REFERENCES [dbo].[ItemSale] ([ItemSaleGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPh__ItemS__787EE5A0]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuTraHang]  WITH CHECK ADD FOREIGN KEY([ItemSaleGuid])
REFERENCES [dbo].[ItemSale] ([ItemSaleGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPh__Phieu__4B7734FF]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuTraHang]  WITH CHECK ADD FOREIGN KEY([PhieuTraHangGuid])
REFERENCES [dbo].[PhieuTraHang] ([PhieuTraHangGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPh__Phieu__797309D9]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuTraHang]  WITH CHECK ADD FOREIGN KEY([PhieuTraHangGuid])
REFERENCES [dbo].[PhieuTraHang] ([PhieuTraHangGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPh__ItemS__4C6B5938]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuXuatDieuChuyen]  WITH CHECK ADD FOREIGN KEY([ItemStoreGuid])
REFERENCES [dbo].[ItemStore] ([ItemStoreGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPh__ItemS__7A672E12]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuXuatDieuChuyen]  WITH CHECK ADD FOREIGN KEY([ItemStoreGuid])
REFERENCES [dbo].[ItemStore] ([ItemStoreGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPhieuXuat__4D5F7D71]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuXuatDieuChuyen]  WITH CHECK ADD FOREIGN KEY([PhieuXuatDieuChuyenGuid], [NhanVienGuid])
REFERENCES [dbo].[PhieuXuatDieuChuyen] ([PhieuXuatDieuChuyenGuid], [NhanVienGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPhieuXuat__7B5B524B]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuXuatDieuChuyen]  WITH CHECK ADD FOREIGN KEY([PhieuXuatDieuChuyenGuid], [NhanVienGuid])
REFERENCES [dbo].[PhieuXuatDieuChuyen] ([PhieuXuatDieuChuyenGuid], [NhanVienGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPh__ItemS__4E53A1AA]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuXuatKho]  WITH CHECK ADD FOREIGN KEY([ItemStoreGuid])
REFERENCES [dbo].[ItemStore] ([ItemStoreGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPh__ItemS__7C4F7684]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuXuatKho]  WITH CHECK ADD FOREIGN KEY([ItemStoreGuid])
REFERENCES [dbo].[ItemStore] ([ItemStoreGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPhieuXuat__4F47C5E3]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuXuatKho]  WITH CHECK ADD FOREIGN KEY([PhieuXuatKhoGuid], [HoaDonBanHangGuid])
REFERENCES [dbo].[PhieuXuatKho] ([PhieuXuatKhoGuid], [HoaDonBanHangGuid])
GO
/****** Object:  ForeignKey [FK__ChiTietPhieuXuat__7D439ABD]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ChiTietPhieuXuatKho]  WITH CHECK ADD FOREIGN KEY([PhieuXuatKhoGuid], [HoaDonBanHangGuid])
REFERENCES [dbo].[PhieuXuatKho] ([PhieuXuatKhoGuid], [HoaDonBanHangGuid])
GO
/****** Object:  ForeignKey [FK__Customer__Custom__503BEA1C]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD FOREIGN KEY([CustomerGroupGuid])
REFERENCES [dbo].[CustomerGroup] ([CustomerGroupGuid])
GO
/****** Object:  ForeignKey [FK__Customer__Custom__7E37BEF6]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD FOREIGN KEY([CustomerGroupGuid])
REFERENCES [dbo].[CustomerGroup] ([CustomerGroupGuid])
GO
/****** Object:  ForeignKey [FK__HoaDonBan__Custo__51300E55]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[HoaDonBanHang]  WITH CHECK ADD FOREIGN KEY([CustomerGuid])
REFERENCES [dbo].[Customer] ([CustomerGuid])
GO
/****** Object:  ForeignKey [FK__HoaDonBan__Custo__7F2BE32F]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[HoaDonBanHang]  WITH CHECK ADD FOREIGN KEY([CustomerGuid])
REFERENCES [dbo].[Customer] ([CustomerGuid])
GO
/****** Object:  ForeignKey [FK__HoaDonBan__KhuVu__00200768]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[HoaDonBanHang]  WITH CHECK ADD FOREIGN KEY([KhuVucBanHangGuid])
REFERENCES [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid])
GO
/****** Object:  ForeignKey [FK__HoaDonBan__KhuVu__5224328E]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[HoaDonBanHang]  WITH CHECK ADD FOREIGN KEY([KhuVucBanHangGuid])
REFERENCES [dbo].[KhuVucBanHang] ([KhuVucBanHangGuid])
GO
/****** Object:  ForeignKey [FK__HoaDonBan__NhanV__01142BA1]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[HoaDonBanHang]  WITH CHECK ADD FOREIGN KEY([NhanVienGuid])
REFERENCES [dbo].[NhanVien] ([NhanVienGuid])
GO
/****** Object:  ForeignKey [FK__HoaDonBan__NhanV__531856C7]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[HoaDonBanHang]  WITH CHECK ADD FOREIGN KEY([NhanVienGuid])
REFERENCES [dbo].[NhanVien] ([NhanVienGuid])
GO
/****** Object:  ForeignKey [FK__HoaDonMua__NhaCu__02084FDA]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[HoaDonMuaHang]  WITH CHECK ADD FOREIGN KEY([NhaCungCapGuid])
REFERENCES [dbo].[NhaCungCap] ([NhaCungCapGuid])
GO
/****** Object:  ForeignKey [FK__HoaDonMua__NhaCu__540C7B00]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[HoaDonMuaHang]  WITH CHECK ADD FOREIGN KEY([NhaCungCapGuid])
REFERENCES [dbo].[NhaCungCap] ([NhaCungCapGuid])
GO
/****** Object:  ForeignKey [FK__ItemSale__DanhMu__02FC7413]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ItemSale]  WITH CHECK ADD FOREIGN KEY([DanhMucGuid])
REFERENCES [dbo].[DanhMuc] ([DanhMucGuid])
GO
/****** Object:  ForeignKey [FK__ItemSale__DanhMu__55009F39]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ItemSale]  WITH CHECK ADD FOREIGN KEY([DanhMucGuid])
REFERENCES [dbo].[DanhMuc] ([DanhMucGuid])
GO
/****** Object:  ForeignKey [FK__ItemSale__DonViT__03F0984C]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ItemSale]  WITH CHECK ADD FOREIGN KEY([DonViTinhGuid])
REFERENCES [dbo].[DonViTinh] ([DonViTinhGuid])
GO
/****** Object:  ForeignKey [FK__ItemSale__DonViT__55F4C372]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ItemSale]  WITH CHECK ADD FOREIGN KEY([DonViTinhGuid])
REFERENCES [dbo].[DonViTinh] ([DonViTinhGuid])
GO
/****** Object:  ForeignKey [FK__ItemSaleD__ItemS__04E4BC85]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ItemSaleDetail]  WITH CHECK ADD FOREIGN KEY([ItemSaleGuid])
REFERENCES [dbo].[ItemSale] ([ItemSaleGuid])
GO
/****** Object:  ForeignKey [FK__ItemSaleD__ItemS__05D8E0BE]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ItemSaleDetail]  WITH CHECK ADD FOREIGN KEY([ItemStoreGuid])
REFERENCES [dbo].[ItemStore] ([ItemStoreGuid])
GO
/****** Object:  ForeignKey [FK__ItemSaleD__ItemS__56E8E7AB]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ItemSaleDetail]  WITH CHECK ADD FOREIGN KEY([ItemSaleGuid])
REFERENCES [dbo].[ItemSale] ([ItemSaleGuid])
GO
/****** Object:  ForeignKey [FK__ItemSaleD__ItemS__57DD0BE4]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ItemSaleDetail]  WITH CHECK ADD FOREIGN KEY([ItemStoreGuid])
REFERENCES [dbo].[ItemStore] ([ItemStoreGuid])
GO
/****** Object:  ForeignKey [FK__ItemStore__DanhM__06CD04F7]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ItemStore]  WITH CHECK ADD FOREIGN KEY([DanhMucGuid])
REFERENCES [dbo].[DanhMuc] ([DanhMucGuid])
GO
/****** Object:  ForeignKey [FK__ItemStore__DanhM__58D1301D]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ItemStore]  WITH CHECK ADD FOREIGN KEY([DanhMucGuid])
REFERENCES [dbo].[DanhMuc] ([DanhMucGuid])
GO
/****** Object:  ForeignKey [FK__ItemStore__DonVi__07C12930]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ItemStore]  WITH CHECK ADD FOREIGN KEY([DonViTinhGuid])
REFERENCES [dbo].[DonViTinh] ([DonViTinhGuid])
GO
/****** Object:  ForeignKey [FK__ItemStore__DonVi__59C55456]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ItemStore]  WITH CHECK ADD FOREIGN KEY([DonViTinhGuid])
REFERENCES [dbo].[DonViTinh] ([DonViTinhGuid])
GO
/****** Object:  ForeignKey [FK__ItemStore__ItemS__08B54D69]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ItemStoreDetail]  WITH CHECK ADD FOREIGN KEY([ItemStoreGuid])
REFERENCES [dbo].[ItemStore] ([ItemStoreGuid])
GO
/****** Object:  ForeignKey [FK__ItemStore__ItemS__5AB9788F]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ItemStoreDetail]  WITH CHECK ADD FOREIGN KEY([ItemStoreGuid])
REFERENCES [dbo].[ItemStore] ([ItemStoreGuid])
GO
/****** Object:  ForeignKey [FK__ItemStore__KhoHa__09A971A2]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ItemStoreDetail]  WITH CHECK ADD FOREIGN KEY([KhoHangGuid])
REFERENCES [dbo].[KhoHang] ([KhoHangGuid])
GO
/****** Object:  ForeignKey [FK__ItemStore__KhoHa__5BAD9CC8]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[ItemStoreDetail]  WITH CHECK ADD FOREIGN KEY([KhoHangGuid])
REFERENCES [dbo].[KhoHang] ([KhoHangGuid])
GO
/****** Object:  ForeignKey [FK__KhoHang__ChiNhan__0A9D95DB]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[KhoHang]  WITH CHECK ADD FOREIGN KEY([ChiNhanhGuid])
REFERENCES [dbo].[ChiNhanhCongTy] ([ChiNhanhGuid])
GO
/****** Object:  ForeignKey [FK__KhoHang__ChiNhan__5CA1C101]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[KhoHang]  WITH CHECK ADD FOREIGN KEY([ChiNhanhGuid])
REFERENCES [dbo].[ChiNhanhCongTy] ([ChiNhanhGuid])
GO
/****** Object:  ForeignKey [FK__PhieuGiao__Custo__0B91BA14]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuGiaoHang]  WITH CHECK ADD FOREIGN KEY([CustomerGuid])
REFERENCES [dbo].[Customer] ([CustomerGuid])
GO
/****** Object:  ForeignKey [FK__PhieuGiao__Custo__5D95E53A]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuGiaoHang]  WITH CHECK ADD FOREIGN KEY([CustomerGuid])
REFERENCES [dbo].[Customer] ([CustomerGuid])
GO
/****** Object:  ForeignKey [FK__PhieuGiao__HoaDo__0C85DE4D]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuGiaoHang]  WITH CHECK ADD FOREIGN KEY([HoaDonBanHangGuid])
REFERENCES [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid])
GO
/****** Object:  ForeignKey [FK__PhieuGiao__HoaDo__5E8A0973]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuGiaoHang]  WITH CHECK ADD FOREIGN KEY([HoaDonBanHangGuid])
REFERENCES [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid])
GO
/****** Object:  ForeignKey [FK__PhieuGiao__NhanV__0D7A0286]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuGiaoHang]  WITH CHECK ADD FOREIGN KEY([NhanVienGuid])
REFERENCES [dbo].[NhanVien] ([NhanVienGuid])
GO
/****** Object:  ForeignKey [FK__PhieuGiao__NhanV__5F7E2DAC]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuGiaoHang]  WITH CHECK ADD FOREIGN KEY([NhanVienGuid])
REFERENCES [dbo].[NhanVien] ([NhanVienGuid])
GO
/****** Object:  ForeignKey [FK__PhieuNhap__KhoHa__0E6E26BF]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuNhapKho]  WITH CHECK ADD FOREIGN KEY([KhoHangGuid])
REFERENCES [dbo].[KhoHang] ([KhoHangGuid])
GO
/****** Object:  ForeignKey [FK__PhieuNhap__KhoHa__607251E5]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuNhapKho]  WITH CHECK ADD FOREIGN KEY([KhoHangGuid])
REFERENCES [dbo].[KhoHang] ([KhoHangGuid])
GO
/****** Object:  ForeignKey [FK__PhieuNhap__NhanV__0F624AF8]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuNhapKho]  WITH CHECK ADD FOREIGN KEY([NhanVienGuid])
REFERENCES [dbo].[NhanVien] ([NhanVienGuid])
GO
/****** Object:  ForeignKey [FK__PhieuNhap__NhanV__6166761E]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuNhapKho]  WITH CHECK ADD FOREIGN KEY([NhanVienGuid])
REFERENCES [dbo].[NhanVien] ([NhanVienGuid])
GO
/****** Object:  ForeignKey [FK__PhieuTraH__HoaDo__10566F31]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuTraHang]  WITH CHECK ADD FOREIGN KEY([HoaDonBanHangGuid])
REFERENCES [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid])
GO
/****** Object:  ForeignKey [FK__PhieuTraH__HoaDo__625A9A57]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuTraHang]  WITH CHECK ADD FOREIGN KEY([HoaDonBanHangGuid])
REFERENCES [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid])
GO
/****** Object:  ForeignKey [FK__PhieuTraH__NhanV__114A936A]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuTraHang]  WITH CHECK ADD FOREIGN KEY([NhanVienGuid])
REFERENCES [dbo].[NhanVien] ([NhanVienGuid])
GO
/****** Object:  ForeignKey [FK__PhieuTraH__NhanV__634EBE90]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuTraHang]  WITH CHECK ADD FOREIGN KEY([NhanVienGuid])
REFERENCES [dbo].[NhanVien] ([NhanVienGuid])
GO
/****** Object:  ForeignKey [FK__PhieuXuat__KhoHa__123EB7A3]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuXuatDieuChuyen]  WITH CHECK ADD FOREIGN KEY([KhoHangGuid])
REFERENCES [dbo].[KhoHang] ([KhoHangGuid])
GO
/****** Object:  ForeignKey [FK__PhieuXuat__KhoHa__6442E2C9]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuXuatDieuChuyen]  WITH CHECK ADD FOREIGN KEY([KhoHangGuid])
REFERENCES [dbo].[KhoHang] ([KhoHangGuid])
GO
/****** Object:  ForeignKey [FK__PhieuXuat__NhanV__1332DBDC]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuXuatDieuChuyen]  WITH CHECK ADD FOREIGN KEY([NhanVienGuid])
REFERENCES [dbo].[NhanVien] ([NhanVienGuid])
GO
/****** Object:  ForeignKey [FK__PhieuXuat__NhanV__65370702]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuXuatDieuChuyen]  WITH CHECK ADD FOREIGN KEY([NhanVienGuid])
REFERENCES [dbo].[NhanVien] ([NhanVienGuid])
GO
/****** Object:  ForeignKey [FK__PhieuXuat__HoaDo__14270015]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuXuatKho]  WITH CHECK ADD FOREIGN KEY([HoaDonBanHangGuid])
REFERENCES [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid])
GO
/****** Object:  ForeignKey [FK__PhieuXuat__HoaDo__662B2B3B]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuXuatKho]  WITH CHECK ADD FOREIGN KEY([HoaDonBanHangGuid])
REFERENCES [dbo].[HoaDonBanHang] ([HoaDonBanHangGuid])
GO
/****** Object:  ForeignKey [FK__PhieuXuat__KhoHa__151B244E]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuXuatKho]  WITH CHECK ADD FOREIGN KEY([KhoHangGuid])
REFERENCES [dbo].[KhoHang] ([KhoHangGuid])
GO
/****** Object:  ForeignKey [FK__PhieuXuat__KhoHa__671F4F74]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuXuatKho]  WITH CHECK ADD FOREIGN KEY([KhoHangGuid])
REFERENCES [dbo].[KhoHang] ([KhoHangGuid])
GO
/****** Object:  ForeignKey [FK__PhieuXuat__NhanV__160F4887]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuXuatKho]  WITH CHECK ADD FOREIGN KEY([NhanVienGuid])
REFERENCES [dbo].[NhanVien] ([NhanVienGuid])
GO
/****** Object:  ForeignKey [FK__PhieuXuat__NhanV__681373AD]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[PhieuXuatKho]  WITH CHECK ADD FOREIGN KEY([NhanVienGuid])
REFERENCES [dbo].[NhanVien] ([NhanVienGuid])
GO
/****** Object:  ForeignKey [FK__TinhThanh__QuocG__17036CC0]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[TinhThanhPho]  WITH CHECK ADD FOREIGN KEY([QuocGiaGuid])
REFERENCES [dbo].[QuocGia] ([QuocGiaGuid])
GO
/****** Object:  ForeignKey [FK__TinhThanh__QuocG__690797E6]    Script Date: 03/17/2015 03:38:20 ******/
ALTER TABLE [dbo].[TinhThanhPho]  WITH CHECK ADD FOREIGN KEY([QuocGiaGuid])
REFERENCES [dbo].[QuocGia] ([QuocGiaGuid])
GO
