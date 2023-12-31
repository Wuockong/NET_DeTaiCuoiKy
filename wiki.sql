CREATE DATABASE quanlyxemay_db;
GO
USE [quanlyxemay_db]
GO
/****** Object:  Table [dbo].[chitiethoadon]    Script Date: 12/5/2023 8:42:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitiethoadon](
	[ma_chi_tiet_hd] [int] IDENTITY(1,1) NOT NULL,
	[ma_san_pham] [int] NULL,
	[ma_hoa_don] [int] NULL,
	[ten_san_pham] [nvarchar](255) NULL,
	[so_luong] [int] NULL,
	[don_gia] [int] NULL,
	[thanh_tien] [int] NULL,
	[hinh_anh] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_chi_tiet_hd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hoadon]    Script Date: 12/5/2023 8:42:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hoadon](
	[ma_hoa_don] [int] IDENTITY(1,1) NOT NULL,
	[ngay_lap] [datetime] NULL,
	[ma_khach_hang] [int] NULL,
	[ma_nhan_vien] [int] NULL,
	[tong_tien] [int] NULL,
	[hinh_thuc_thanh_toan] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_hoa_don] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loaisanpham]    Script Date: 12/5/2023 8:42:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaisanpham](
	[ma_loai_sp] [int] IDENTITY(1,1) NOT NULL,
	[ten_loai_sp] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_loai_sp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nguoidung]    Script Date: 12/5/2023 8:42:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nguoidung](
	[ma_nguoi_dung] [int] IDENTITY(1,1) NOT NULL,
	[ten_nguoi_dung] [nvarchar](255) NULL,
	[ten_dang_nhap] [varchar](255) NULL,
	[mat_khau] [varchar](255) NULL,
	[vai_tro] [varchar](255) NULL,
	[trang_thai] [nvarchar](10) NULL,
	[so_dien_thoai] [nvarchar](20) NULL,
	[email] [varchar](255) NULL,
	[dia_chi] [nvarchar](255) NULL,
	[gioi_tinh] [nvarchar](10) NULL,
	[ngay_sinh] [datetime] NULL,
	[hinh_anh] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_nguoi_dung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sanpham]    Script Date: 12/5/2023 8:42:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sanpham](
	[ma_san_pham] [int] IDENTITY(1,1) NOT NULL,
	[ten_san_pham] [nvarchar](255) NULL,
	[don_gia] [int] NULL,
	[so_luong_ton] [int] NULL,
	[trang_thai] [varchar](10) NULL,
	[ma_loai_sp] [int] NULL,
	[hinh_anh] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_san_pham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[chitiethoadon] ON 

INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (3, 10, 3, N'Sirus RSX 2021', 2, 28000000, 56000000, N'sirus')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (4, 7, 3, N'Wave RSX 2021', 1, 28000000, 28000000, N'anh-xe-wave_1')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (5, 9, 4, N'Wave RSX 2019', 1, 19000000, 19000000, N'anh-xe-wave_1')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (6, 12, 4, N'Sirus RSX 2019', 2, 19000000, 38000000, N'product1')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (7, 6, 4, N'Exciter X 2021', 3, 38000000, 114000000, N'xeeciter')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (8, 14, 5, N'Xe Vision 2022', 1, 32000000, 32000000, N'aoag15ugcdx')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (9, 13, 5, N'Xe Vision 2023', 1, 36000000, 36000000, N'k4h30zg0que')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (10, 16, 5, N'Exciter X 2018', 1, 39000000, 39000000, N'pum2ui5fder')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (11, 13, 6, N'Xe Vision 2023', 1, 36000000, 36000000, N'k4h30zg0que')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (12, 12, 6, N'Sirus RSX 2019', 1, 19000000, 19000000, N'product1')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (13, 7, 7, N'Wave RSX 2021', 2, 28000000, 56000000, N'anh-xe-wave_1')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (14, 12, 7, N'Sirus RSX 2019', 1, 19000000, 19000000, N'product1')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (15, 11, 8, N'Sirus RSX 2022', 2, 18000000, 36000000, N'sirus')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (16, 12, 9, N'Sirus RSX 2019', 1, 19000000, 19000000, N'product1')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (17, 11, 9, N'Sirus RSX 2022', 1, 18000000, 18000000, N'sirus')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (18, 13, 10, N'Xe Vision 2023', 1, 36000000, 36000000, N'k4h30zg0que')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (19, 11, 10, N'Sirus RSX 2022', 1, 18000000, 18000000, N'sirus')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (20, 11, 11, N'Sirus RSX 2022', 1, 18000000, 18000000, N'sirus')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (21, 14, 11, N'Xe Vision 2022', 1, 32000000, 32000000, N'aoag15ugcdx')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (22, 13, 11, N'Xe Vision 2023', 1, 36000000, 36000000, N'k4h30zg0que')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (23, 9, 12, N'Wave RSX 2019', 1, 19000000, 19000000, N'anh-xe-wave_1')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (24, 12, 12, N'Sirus RSX 2019', 1, 19000000, 19000000, N'product1')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (25, 12, 13, N'Sirus RSX 2019', 1, 19000000, 19000000, N'product1')
INSERT [dbo].[chitiethoadon] ([ma_chi_tiet_hd], [ma_san_pham], [ma_hoa_don], [ten_san_pham], [so_luong], [don_gia], [thanh_tien], [hinh_anh]) VALUES (26, 11, 14, N'Sirus RSX 2022', 1, 18000000, 18000000, N'sirus')
SET IDENTITY_INSERT [dbo].[chitiethoadon] OFF
GO
SET IDENTITY_INSERT [dbo].[hoadon] ON 

INSERT [dbo].[hoadon] ([ma_hoa_don], [ngay_lap], [ma_khach_hang], [ma_nhan_vien], [tong_tien], [hinh_thuc_thanh_toan]) VALUES (3, CAST(N'2023-12-05T07:22:02.560' AS DateTime), 13, 2, 84000000, N'Tiền mặt')
INSERT [dbo].[hoadon] ([ma_hoa_don], [ngay_lap], [ma_khach_hang], [ma_nhan_vien], [tong_tien], [hinh_thuc_thanh_toan]) VALUES (4, CAST(N'2023-12-05T07:23:17.350' AS DateTime), 10, 2, 171000000, N'Tiền mặt')
INSERT [dbo].[hoadon] ([ma_hoa_don], [ngay_lap], [ma_khach_hang], [ma_nhan_vien], [tong_tien], [hinh_thuc_thanh_toan]) VALUES (5, CAST(N'2023-12-05T07:59:46.473' AS DateTime), 7, 2, 107000000, N'Tiền mặt')
INSERT [dbo].[hoadon] ([ma_hoa_don], [ngay_lap], [ma_khach_hang], [ma_nhan_vien], [tong_tien], [hinh_thuc_thanh_toan]) VALUES (6, CAST(N'2023-12-05T08:16:00.887' AS DateTime), 9, 2, 55000000, N'Tiền mặt')
INSERT [dbo].[hoadon] ([ma_hoa_don], [ngay_lap], [ma_khach_hang], [ma_nhan_vien], [tong_tien], [hinh_thuc_thanh_toan]) VALUES (7, CAST(N'2023-12-05T08:17:19.857' AS DateTime), 11, 2, 75000000, N'Tiền mặt')
INSERT [dbo].[hoadon] ([ma_hoa_don], [ngay_lap], [ma_khach_hang], [ma_nhan_vien], [tong_tien], [hinh_thuc_thanh_toan]) VALUES (8, CAST(N'2023-12-05T08:22:33.693' AS DateTime), 9, 2, 36000000, N'Tiền mặt')
INSERT [dbo].[hoadon] ([ma_hoa_don], [ngay_lap], [ma_khach_hang], [ma_nhan_vien], [tong_tien], [hinh_thuc_thanh_toan]) VALUES (9, CAST(N'2023-12-05T08:23:06.963' AS DateTime), 8, 2, 37000000, N'Tiền mặt')
INSERT [dbo].[hoadon] ([ma_hoa_don], [ngay_lap], [ma_khach_hang], [ma_nhan_vien], [tong_tien], [hinh_thuc_thanh_toan]) VALUES (10, CAST(N'2023-12-05T08:23:26.217' AS DateTime), 13, 2, 54000000, N'Tiền mặt')
INSERT [dbo].[hoadon] ([ma_hoa_don], [ngay_lap], [ma_khach_hang], [ma_nhan_vien], [tong_tien], [hinh_thuc_thanh_toan]) VALUES (11, CAST(N'2023-12-05T08:23:45.810' AS DateTime), 13, 2, 86000000, N'Tiền mặt')
INSERT [dbo].[hoadon] ([ma_hoa_don], [ngay_lap], [ma_khach_hang], [ma_nhan_vien], [tong_tien], [hinh_thuc_thanh_toan]) VALUES (12, CAST(N'2023-12-05T08:24:13.333' AS DateTime), 10, 2, 38000000, N'Tiền mặt')
INSERT [dbo].[hoadon] ([ma_hoa_don], [ngay_lap], [ma_khach_hang], [ma_nhan_vien], [tong_tien], [hinh_thuc_thanh_toan]) VALUES (13, CAST(N'2023-12-05T08:27:45.227' AS DateTime), 13, 2, 19000000, N'Tiền mặt')
INSERT [dbo].[hoadon] ([ma_hoa_don], [ngay_lap], [ma_khach_hang], [ma_nhan_vien], [tong_tien], [hinh_thuc_thanh_toan]) VALUES (14, CAST(N'2023-12-05T08:30:57.347' AS DateTime), 13, 2, 18000000, N'Tiền mặt')
SET IDENTITY_INSERT [dbo].[hoadon] OFF
GO
SET IDENTITY_INSERT [dbo].[loaisanpham] ON 

INSERT [dbo].[loaisanpham] ([ma_loai_sp], [ten_loai_sp]) VALUES (1, N'HONDA')
INSERT [dbo].[loaisanpham] ([ma_loai_sp], [ten_loai_sp]) VALUES (2, N'YAMAHA')
INSERT [dbo].[loaisanpham] ([ma_loai_sp], [ten_loai_sp]) VALUES (3, N'SUZUKI')
INSERT [dbo].[loaisanpham] ([ma_loai_sp], [ten_loai_sp]) VALUES (4, N'SYM')
SET IDENTITY_INSERT [dbo].[loaisanpham] OFF
GO
SET IDENTITY_INSERT [dbo].[nguoidung] ON 

INSERT [dbo].[nguoidung] ([ma_nguoi_dung], [ten_nguoi_dung], [ten_dang_nhap], [mat_khau], [vai_tro], [trang_thai], [so_dien_thoai], [email], [dia_chi], [gioi_tinh], [ngay_sinh], [hinh_anh]) VALUES (1, N'Pham Hoang Khanh', N'khanhpham123', N'123456', N'nguoidung', N'ACTIVE', N'0928755354', N'khanh223@gmail.com', N'49 Nguyen Van Cu, Quan 3, Ho Chi Minh', N'Nam', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'avt-default')
INSERT [dbo].[nguoidung] ([ma_nguoi_dung], [ten_nguoi_dung], [ten_dang_nhap], [mat_khau], [vai_tro], [trang_thai], [so_dien_thoai], [email], [dia_chi], [gioi_tinh], [ngay_sinh], [hinh_anh]) VALUES (2, N'Nguyen Huynh Gia Han', N'giahan123', N'123456', N'nhanvien', N'ACTIVE', N'0928755355', N'giahan2001@gmail.com', N'188 Ha Dong, Phuong 10, Ha Noi', N'Nữ', CAST(N'1997-12-28T00:00:00.000' AS DateTime), N'avt-default')
INSERT [dbo].[nguoidung] ([ma_nguoi_dung], [ten_nguoi_dung], [ten_dang_nhap], [mat_khau], [vai_tro], [trang_thai], [so_dien_thoai], [email], [dia_chi], [gioi_tinh], [ngay_sinh], [hinh_anh]) VALUES (3, N'Sơn Trần', N'onebabyq', N'123456', N'nguoidung', N'ACTIVE', N'0968900475', N'hoangson3239@gmail.com', N'Hồ Chí Minh', N'Nam', CAST(N'2000-12-03T14:52:37.000' AS DateTime), N'avt-default')
INSERT [dbo].[nguoidung] ([ma_nguoi_dung], [ten_nguoi_dung], [ten_dang_nhap], [mat_khau], [vai_tro], [trang_thai], [so_dien_thoai], [email], [dia_chi], [gioi_tinh], [ngay_sinh], [hinh_anh]) VALUES (4, N'Phạm Hùng', N'hungpham223', N'123456', N'nguoidung', N'ACTIVE', N'0987433534', N'hungpham213@gmail.com', N'Hà Nội', N'Nữ', CAST(N'2003-12-03T15:02:32.853' AS DateTime), N'i220guni2xm')
INSERT [dbo].[nguoidung] ([ma_nguoi_dung], [ten_nguoi_dung], [ten_dang_nhap], [mat_khau], [vai_tro], [trang_thai], [so_dien_thoai], [email], [dia_chi], [gioi_tinh], [ngay_sinh], [hinh_anh]) VALUES (5, N'Phạm Hữu Duyên', N'huuduyen123', N'123456', N'nguoidung', N'ACTIVE', N'0987433522', N'huuduyen213@gmail.com', N'Hà Nội', N'Nam', CAST(N'1999-12-03T15:02:32.000' AS DateTime), N'zobxhvpj42y')
INSERT [dbo].[nguoidung] ([ma_nguoi_dung], [ten_nguoi_dung], [ten_dang_nhap], [mat_khau], [vai_tro], [trang_thai], [so_dien_thoai], [email], [dia_chi], [gioi_tinh], [ngay_sinh], [hinh_anh]) VALUES (6, N'Nguyễn Thị Hoa', N'hoa2223', N'123456', N'nguoidung', N'ACTIVE', N'0928755125', N'hoa123@gmail.com', N'49 Nguyen Van Cu, Quan 3, Hà Đông', N'Nam', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'054lvirlfpo')
INSERT [dbo].[nguoidung] ([ma_nguoi_dung], [ten_nguoi_dung], [ten_dang_nhap], [mat_khau], [vai_tro], [trang_thai], [so_dien_thoai], [email], [dia_chi], [gioi_tinh], [ngay_sinh], [hinh_anh]) VALUES (7, N'Nguyễn Khánh Nhựt', N'nhut1234', N'123456', N'nguoidung', N'ACTIVE', N'0932745353', N'khanhut12@gmail.com', N'Hồ Chí Minh', N'Nam', CAST(N'1998-12-03T14:52:37.000' AS DateTime), N'gj2gomg3de1')
INSERT [dbo].[nguoidung] ([ma_nguoi_dung], [ten_nguoi_dung], [ten_dang_nhap], [mat_khau], [vai_tro], [trang_thai], [so_dien_thoai], [email], [dia_chi], [gioi_tinh], [ngay_sinh], [hinh_anh]) VALUES (8, N'Nguyễn Ngọc Hoài', N'ngochoai234', N'123456', N'nguoidung', N'ACTIVE', N'0984273535', N'ngochoai2242@gmail.com', N'Hồ Chí Minh', N'Nữ', CAST(N'1995-12-03T14:52:37.000' AS DateTime), N'u3awt2hqcx1')
INSERT [dbo].[nguoidung] ([ma_nguoi_dung], [ten_nguoi_dung], [ten_dang_nhap], [mat_khau], [vai_tro], [trang_thai], [so_dien_thoai], [email], [dia_chi], [gioi_tinh], [ngay_sinh], [hinh_anh]) VALUES (9, N'Nguyễn Gia Bảo', N'giabao882', N'123456', N'nguoidung', N'ACTIVE', N'0958427435', N'giabao42@gmail.com', N'Hồ Chí Minh', N'Nam', CAST(N'1995-12-03T14:52:37.000' AS DateTime), N'ctocvnkw2e1')
INSERT [dbo].[nguoidung] ([ma_nguoi_dung], [ten_nguoi_dung], [ten_dang_nhap], [mat_khau], [vai_tro], [trang_thai], [so_dien_thoai], [email], [dia_chi], [gioi_tinh], [ngay_sinh], [hinh_anh]) VALUES (10, N'Trần Hữu Thọ', N'huutho8274', N'123456', N'nguoidung', N'ACTIVE', N'0958248375', N'huutho88@gmail.com', N'Hồ Chí Minh', N'Nam', CAST(N'1994-12-03T14:52:37.000' AS DateTime), N'4ctr4ngjc3d')
INSERT [dbo].[nguoidung] ([ma_nguoi_dung], [ten_nguoi_dung], [ten_dang_nhap], [mat_khau], [vai_tro], [trang_thai], [so_dien_thoai], [email], [dia_chi], [gioi_tinh], [ngay_sinh], [hinh_anh]) VALUES (11, N'Lê Đức Mạnh', N'ducmanh77', N'123456', N'nguoidung', N'ACTIVE', N'0958248333', N'leducmanh222@gmail.com', N'Hồ Chí Minh', N'Nam', CAST(N'1988-12-03T14:52:37.000' AS DateTime), N'hevuuxeougd')
INSERT [dbo].[nguoidung] ([ma_nguoi_dung], [ten_nguoi_dung], [ten_dang_nhap], [mat_khau], [vai_tro], [trang_thai], [so_dien_thoai], [email], [dia_chi], [gioi_tinh], [ngay_sinh], [hinh_anh]) VALUES (12, N'Hồ Ngọc Hiền', N'ngochien2424', N'123456', N'nguoidung', N'ACTIVE', N'0945872313', N'ngchien23@gmail.com', N'49 Nguyen Van Cu, Quan 3, Ho Chi Minh', N'Nữ', CAST(N'2001-09-09T00:00:00.000' AS DateTime), N'afiy1wo5ieo')
INSERT [dbo].[nguoidung] ([ma_nguoi_dung], [ten_nguoi_dung], [ten_dang_nhap], [mat_khau], [vai_tro], [trang_thai], [so_dien_thoai], [email], [dia_chi], [gioi_tinh], [ngay_sinh], [hinh_anh]) VALUES (13, N'Nguyễn Thị Hoang', N'hoang2223', N'123456', N'nguoidung', N'ACTIVE', N'0928755121', N'hoang123@gmail.com', N'49 Nguyen Van Cu, Quan 3, Hà Đông', N'Nữ', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'slsuhwlqx0o')
INSERT [dbo].[nguoidung] ([ma_nguoi_dung], [ten_nguoi_dung], [ten_dang_nhap], [mat_khau], [vai_tro], [trang_thai], [so_dien_thoai], [email], [dia_chi], [gioi_tinh], [ngay_sinh], [hinh_anh]) VALUES (14, N'Nguyễn Thị Thùy Trang', N'thuynguyen22', N'1234567', N'nguoidung', N'INACTIVE', N'093875353', N'thuynguyen123@gmail.com', N'49 Nguyen Van Cu, Quan 3, Hà Đông', N'Nữ', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'0otpy2xumzu')
INSERT [dbo].[nguoidung] ([ma_nguoi_dung], [ten_nguoi_dung], [ten_dang_nhap], [mat_khau], [vai_tro], [trang_thai], [so_dien_thoai], [email], [dia_chi], [gioi_tinh], [ngay_sinh], [hinh_anh]) VALUES (15, N'Trần Hữu Thoại', N'huuthoai8274', N'123456', N'nguoidung', N'ACTIVE', N'0958248372', N'huuthoai88@gmail.com', N'82 Nguyễn Hữu Cảnh, phường 10, Bình Thạnh', N'Nam', CAST(N'1988-12-03T14:52:37.000' AS DateTime), N'f45dae2rjsh')
INSERT [dbo].[nguoidung] ([ma_nguoi_dung], [ten_nguoi_dung], [ten_dang_nhap], [mat_khau], [vai_tro], [trang_thai], [so_dien_thoai], [email], [dia_chi], [gioi_tinh], [ngay_sinh], [hinh_anh]) VALUES (16, N'Luu Chi Vy', N'luuchivy123', N'123456', N'nhanvien', N'ACTIVE', N'09287135124', N'luuchivy01@gmail.com', N'188 Ha Dong, Phuong 10, HCM', N'Nam', CAST(N'1997-12-28T00:00:00.000' AS DateTime), N'orf5npgy11t')
SET IDENTITY_INSERT [dbo].[nguoidung] OFF
GO
SET IDENTITY_INSERT [dbo].[sanpham] ON 

INSERT [dbo].[sanpham] ([ma_san_pham], [ten_san_pham], [don_gia], [so_luong_ton], [trang_thai], [ma_loai_sp], [hinh_anh]) VALUES (1, N'Winner X 2023', 45000000, 28, N'ACTIVE', 1, N'product1')
INSERT [dbo].[sanpham] ([ma_san_pham], [ten_san_pham], [don_gia], [so_luong_ton], [trang_thai], [ma_loai_sp], [hinh_anh]) VALUES (2, N'Winner X 2022', 36000000, 50, N'ACTIVE', 1, N'product1')
INSERT [dbo].[sanpham] ([ma_san_pham], [ten_san_pham], [don_gia], [so_luong_ton], [trang_thai], [ma_loai_sp], [hinh_anh]) VALUES (3, N'Winner X 2021', 32000000, 16, N'ACTIVE', 1, N'product1')
INSERT [dbo].[sanpham] ([ma_san_pham], [ten_san_pham], [don_gia], [so_luong_ton], [trang_thai], [ma_loai_sp], [hinh_anh]) VALUES (4, N'Exciter X 2023', 46000000, 88, N'ACTIVE', 2, N'xeeciter')
INSERT [dbo].[sanpham] ([ma_san_pham], [ten_san_pham], [don_gia], [so_luong_ton], [trang_thai], [ma_loai_sp], [hinh_anh]) VALUES (5, N'Exciter X 2022', 41000000, 56, N'ACTIVE', 2, N'xeeciter')
INSERT [dbo].[sanpham] ([ma_san_pham], [ten_san_pham], [don_gia], [so_luong_ton], [trang_thai], [ma_loai_sp], [hinh_anh]) VALUES (6, N'Exciter X 2021', 38000000, 33, N'ACTIVE', 2, N'xeeciter')
INSERT [dbo].[sanpham] ([ma_san_pham], [ten_san_pham], [don_gia], [so_luong_ton], [trang_thai], [ma_loai_sp], [hinh_anh]) VALUES (7, N'Wave RSX 2021', 28000000, 22, N'ACTIVE', 3, N'anh-xe-wave_1')
INSERT [dbo].[sanpham] ([ma_san_pham], [ten_san_pham], [don_gia], [so_luong_ton], [trang_thai], [ma_loai_sp], [hinh_anh]) VALUES (8, N'Wave S 2022', 18000000, 44, N'INACTIVE', 1, N'ozsntyld0ps')
INSERT [dbo].[sanpham] ([ma_san_pham], [ten_san_pham], [don_gia], [so_luong_ton], [trang_thai], [ma_loai_sp], [hinh_anh]) VALUES (9, N'Wave RSX 2019', 19000000, 54, N'ACTIVE', 3, N'anh-xe-wave_1')
INSERT [dbo].[sanpham] ([ma_san_pham], [ten_san_pham], [don_gia], [so_luong_ton], [trang_thai], [ma_loai_sp], [hinh_anh]) VALUES (10, N'Sirus RSX 2021', 28000000, 22, N'ACTIVE', 4, N'sirus')
INSERT [dbo].[sanpham] ([ma_san_pham], [ten_san_pham], [don_gia], [so_luong_ton], [trang_thai], [ma_loai_sp], [hinh_anh]) VALUES (11, N'Sirus RSX 2022', 18000000, 24, N'ACTIVE', 4, N'sirus')
INSERT [dbo].[sanpham] ([ma_san_pham], [ten_san_pham], [don_gia], [so_luong_ton], [trang_thai], [ma_loai_sp], [hinh_anh]) VALUES (12, N'Sirus RSX 2019', 19000000, 66, N'ACTIVE', 4, N'product1')
INSERT [dbo].[sanpham] ([ma_san_pham], [ten_san_pham], [don_gia], [so_luong_ton], [trang_thai], [ma_loai_sp], [hinh_anh]) VALUES (13, N'Xe Vision 2023', 36000000, 5, N'ACTIVE', 1, N'k4h30zg0que')
INSERT [dbo].[sanpham] ([ma_san_pham], [ten_san_pham], [don_gia], [so_luong_ton], [trang_thai], [ma_loai_sp], [hinh_anh]) VALUES (14, N'Xe Vision 2022', 32000000, 19, N'ACTIVE', 1, N'aoag15ugcdx')
INSERT [dbo].[sanpham] ([ma_san_pham], [ten_san_pham], [don_gia], [so_luong_ton], [trang_thai], [ma_loai_sp], [hinh_anh]) VALUES (15, N'Wave Thai 2019', 28000000, 25, N'ACTIVE', 3, N'quuaeuhlgy2')
INSERT [dbo].[sanpham] ([ma_san_pham], [ten_san_pham], [don_gia], [so_luong_ton], [trang_thai], [ma_loai_sp], [hinh_anh]) VALUES (16, N'Exciter X 2018', 39000000, 18, N'ACTIVE', 2, N'pum2ui5fder')
SET IDENTITY_INSERT [dbo].[sanpham] OFF
GO
ALTER TABLE [dbo].[hoadon] ADD  DEFAULT (getdate()) FOR [ngay_lap]
GO
ALTER TABLE [dbo].[hoadon] ADD  CONSTRAINT [DF__hoadon__hinh_thu__4222D4EF]  DEFAULT (N'Tiền mặt') FOR [hinh_thuc_thanh_toan]
GO
ALTER TABLE [dbo].[nguoidung] ADD  DEFAULT ('nguoidung') FOR [vai_tro]
GO
ALTER TABLE [dbo].[nguoidung] ADD  CONSTRAINT [DF_nguoidung_trang_thai]  DEFAULT (N'ACTIVE') FOR [trang_thai]
GO
ALTER TABLE [dbo].[sanpham] ADD  DEFAULT ('ACTIVE') FOR [trang_thai]
GO
ALTER TABLE [dbo].[chitiethoadon]  WITH CHECK ADD  CONSTRAINT [FK_cthd_hoadon] FOREIGN KEY([ma_hoa_don])
REFERENCES [dbo].[hoadon] ([ma_hoa_don])
GO
ALTER TABLE [dbo].[chitiethoadon] CHECK CONSTRAINT [FK_cthd_hoadon]
GO
ALTER TABLE [dbo].[chitiethoadon]  WITH CHECK ADD  CONSTRAINT [FK_cthd_san_pham] FOREIGN KEY([ma_san_pham])
REFERENCES [dbo].[sanpham] ([ma_san_pham])
GO
ALTER TABLE [dbo].[chitiethoadon] CHECK CONSTRAINT [FK_cthd_san_pham]
GO
ALTER TABLE [dbo].[hoadon]  WITH CHECK ADD  CONSTRAINT [FK_hoadon_khachhang] FOREIGN KEY([ma_khach_hang])
REFERENCES [dbo].[nguoidung] ([ma_nguoi_dung])
GO
ALTER TABLE [dbo].[hoadon] CHECK CONSTRAINT [FK_hoadon_khachhang]
GO
ALTER TABLE [dbo].[hoadon]  WITH CHECK ADD  CONSTRAINT [FK_hoadon_nhan_vien] FOREIGN KEY([ma_nhan_vien])
REFERENCES [dbo].[nguoidung] ([ma_nguoi_dung])
GO
ALTER TABLE [dbo].[hoadon] CHECK CONSTRAINT [FK_hoadon_nhan_vien]
GO
ALTER TABLE [dbo].[sanpham]  WITH CHECK ADD  CONSTRAINT [fk_sanpham_loaisanpham] FOREIGN KEY([ma_loai_sp])
REFERENCES [dbo].[loaisanpham] ([ma_loai_sp])
GO
ALTER TABLE [dbo].[sanpham] CHECK CONSTRAINT [fk_sanpham_loaisanpham]
GO
