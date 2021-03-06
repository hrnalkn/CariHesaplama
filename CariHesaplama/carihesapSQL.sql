USE [master]
GO
/****** Object:  Database [carihesap]    Script Date: 29.12.2019 17:29:36 ******/
CREATE DATABASE [carihesap]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'carihesap', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.HARUNALKAN\MSSQL\DATA\carihesap.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'carihesap_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.HARUNALKAN\MSSQL\DATA\carihesap_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [carihesap] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [carihesap].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [carihesap] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [carihesap] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [carihesap] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [carihesap] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [carihesap] SET ARITHABORT OFF 
GO
ALTER DATABASE [carihesap] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [carihesap] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [carihesap] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [carihesap] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [carihesap] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [carihesap] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [carihesap] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [carihesap] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [carihesap] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [carihesap] SET  DISABLE_BROKER 
GO
ALTER DATABASE [carihesap] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [carihesap] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [carihesap] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [carihesap] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [carihesap] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [carihesap] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [carihesap] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [carihesap] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [carihesap] SET  MULTI_USER 
GO
ALTER DATABASE [carihesap] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [carihesap] SET DB_CHAINING OFF 
GO
ALTER DATABASE [carihesap] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [carihesap] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [carihesap] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [carihesap] SET QUERY_STORE = OFF
GO
USE [carihesap]
GO
/****** Object:  Table [dbo].[Kategoriler]    Script Date: 29.12.2019 17:29:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategoriler](
	[KategoriId] [int] IDENTITY(1,1) NOT NULL,
	[Kategori] [nvarchar](20) NOT NULL,
	[Aciklama] [nvarchar](40) NOT NULL,
	[KayitTarih] [datetime] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_Kategoriler] PRIMARY KEY CLUSTERED 
(
	[KategoriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 29.12.2019 17:29:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[KullaniciId] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAd] [nvarchar](20) NOT NULL,
	[Sifre] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Kullanicilar] PRIMARY KEY CLUSTERED 
(
	[KullaniciId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteriler]    Script Date: 29.12.2019 17:29:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteriler](
	[müsteriId] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](20) NOT NULL,
	[Soyad] [nvarchar](20) NOT NULL,
	[Tel] [nvarchar](20) NOT NULL,
	[Adres] [nvarchar](50) NOT NULL,
	[KayitTarihi] [datetime] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_Musteriler] PRIMARY KEY CLUSTERED 
(
	[müsteriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Satislar]    Script Date: 29.12.2019 17:29:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Satislar](
	[SatisId] [int] IDENTITY(1,1) NOT NULL,
	[UrunId] [int] NOT NULL,
	[MusteriId] [int] NOT NULL,
	[Adet] [int] NOT NULL,
	[Tarih] [datetime] NOT NULL,
 CONSTRAINT [PK_Satislar] PRIMARY KEY CLUSTERED 
(
	[SatisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urunler]    Script Date: 29.12.2019 17:29:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urunler](
	[UrunId] [int] IDENTITY(1,1) NOT NULL,
	[UrunAdi] [nvarchar](20) NOT NULL,
	[KategoriId] [int] NOT NULL,
	[AlisFiyat] [int] NOT NULL,
	[SatisFiyat] [int] NOT NULL,
	[Stok] [int] NOT NULL,
	[Aciklama] [nvarchar](40) NOT NULL,
	[KayitTarihi] [datetime] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_Urunler] PRIMARY KEY CLUSTERED 
(
	[UrunId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Kategoriler] ON 

INSERT [dbo].[Kategoriler] ([KategoriId], [Kategori], [Aciklama], [KayitTarih], [AktifMi]) VALUES (3, N'Gıda', N'Gıda ürünleri', CAST(N'2019-12-15T15:14:53.420' AS DateTime), 1)
INSERT [dbo].[Kategoriler] ([KategoriId], [Kategori], [Aciklama], [KayitTarih], [AktifMi]) VALUES (4, N'Kimyasal M.', N'Kimyasal maddeler', CAST(N'2019-12-15T15:17:08.540' AS DateTime), 1)
INSERT [dbo].[Kategoriler] ([KategoriId], [Kategori], [Aciklama], [KayitTarih], [AktifMi]) VALUES (5, N'Ambalaj', N'Ambalaj maddeleri', CAST(N'2019-12-15T15:26:16.053' AS DateTime), 1)
INSERT [dbo].[Kategoriler] ([KategoriId], [Kategori], [Aciklama], [KayitTarih], [AktifMi]) VALUES (8, N'Hammadde', N'Hammaddeler', CAST(N'2019-12-15T15:26:16.053' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Kategoriler] OFF
SET IDENTITY_INSERT [dbo].[Kullanicilar] ON 

INSERT [dbo].[Kullanicilar] ([KullaniciId], [KullaniciAd], [Sifre]) VALUES (2, N'admin', N'12345')
SET IDENTITY_INSERT [dbo].[Kullanicilar] OFF
SET IDENTITY_INSERT [dbo].[Musteriler] ON 

INSERT [dbo].[Musteriler] ([müsteriId], [Ad], [Soyad], [Tel], [Adres], [KayitTarihi], [AktifMi]) VALUES (2, N'Harun', N'Alkan', N'(537) 695-8769', N'Gaziosmanpaşa', CAST(N'2019-12-15T00:00:27.550' AS DateTime), 1)
INSERT [dbo].[Musteriler] ([müsteriId], [Ad], [Soyad], [Tel], [Adres], [KayitTarihi], [AktifMi]) VALUES (3, N'Ahmet', N'Alkan', N'(444) 444-4444', N'Gaziosmanpaşa', CAST(N'2019-12-15T00:11:42.267' AS DateTime), 0)
INSERT [dbo].[Musteriler] ([müsteriId], [Ad], [Soyad], [Tel], [Adres], [KayitTarihi], [AktifMi]) VALUES (4, N'Yiğit', N'Özdemir', N'(516) 524-1254', N'Küçükköy', CAST(N'2019-12-15T00:39:33.690' AS DateTime), 1)
INSERT [dbo].[Musteriler] ([müsteriId], [Ad], [Soyad], [Tel], [Adres], [KayitTarihi], [AktifMi]) VALUES (5, N'Hakan', N'Yıldırım', N'(333) 333-3333', N'Beşiktaş', CAST(N'2019-12-15T00:49:41.980' AS DateTime), 1)
INSERT [dbo].[Musteriler] ([müsteriId], [Ad], [Soyad], [Tel], [Adres], [KayitTarihi], [AktifMi]) VALUES (6, N'Büşra', N'Çınar', N'(538) 875-44458', N'Beşiktaş', CAST(N'2019-12-15T00:49:56.430' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Musteriler] OFF
SET IDENTITY_INSERT [dbo].[Satislar] ON 

INSERT [dbo].[Satislar] ([SatisId], [UrunId], [MusteriId], [Adet], [Tarih]) VALUES (1, 4, 5, 10, CAST(N'2019-12-15T23:59:08.393' AS DateTime))
INSERT [dbo].[Satislar] ([SatisId], [UrunId], [MusteriId], [Adet], [Tarih]) VALUES (2, 5, 4, 10, CAST(N'2019-12-16T00:48:38.783' AS DateTime))
INSERT [dbo].[Satislar] ([SatisId], [UrunId], [MusteriId], [Adet], [Tarih]) VALUES (3, 4, 4, 10, CAST(N'2019-12-16T22:14:40.027' AS DateTime))
SET IDENTITY_INSERT [dbo].[Satislar] OFF
SET IDENTITY_INSERT [dbo].[Urunler] ON 

INSERT [dbo].[Urunler] ([UrunId], [UrunAdi], [KategoriId], [AlisFiyat], [SatisFiyat], [Stok], [Aciklama], [KayitTarihi], [AktifMi]) VALUES (1, N'Ekmek', 3, 124, 344, 114, N'Bu bir ekmektir', CAST(N'2019-12-15T19:09:38.343' AS DateTime), 1)
INSERT [dbo].[Urunler] ([UrunId], [UrunAdi], [KategoriId], [AlisFiyat], [SatisFiyat], [Stok], [Aciklama], [KayitTarihi], [AktifMi]) VALUES (2, N'Streç film', 5, 144, 15, 16, N'Streç kaplama film', CAST(N'2019-12-15T19:30:50.397' AS DateTime), 0)
INSERT [dbo].[Urunler] ([UrunId], [UrunAdi], [KategoriId], [AlisFiyat], [SatisFiyat], [Stok], [Aciklama], [KayitTarihi], [AktifMi]) VALUES (3, N'Su', 3, 23, 35, 64, N'İçmelik su', CAST(N'2019-12-15T22:00:24.967' AS DateTime), 0)
INSERT [dbo].[Urunler] ([UrunId], [UrunAdi], [KategoriId], [AlisFiyat], [SatisFiyat], [Stok], [Aciklama], [KayitTarihi], [AktifMi]) VALUES (4, N'Çay', 3, 24, 425, 12, N'En kaliteli çay', CAST(N'2019-12-15T22:05:27.770' AS DateTime), 1)
INSERT [dbo].[Urunler] ([UrunId], [UrunAdi], [KategoriId], [AlisFiyat], [SatisFiyat], [Stok], [Aciklama], [KayitTarihi], [AktifMi]) VALUES (5, N'Kutu', 5, 10, 15, 20, N'Karton kutu', CAST(N'2019-12-16T00:42:20.767' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Urunler] OFF
ALTER TABLE [dbo].[Satislar]  WITH CHECK ADD  CONSTRAINT [FK_Satislar_Musteriler] FOREIGN KEY([MusteriId])
REFERENCES [dbo].[Musteriler] ([müsteriId])
GO
ALTER TABLE [dbo].[Satislar] CHECK CONSTRAINT [FK_Satislar_Musteriler]
GO
ALTER TABLE [dbo].[Satislar]  WITH CHECK ADD  CONSTRAINT [FK_Satislar_Urunler] FOREIGN KEY([UrunId])
REFERENCES [dbo].[Urunler] ([UrunId])
GO
ALTER TABLE [dbo].[Satislar] CHECK CONSTRAINT [FK_Satislar_Urunler]
GO
ALTER TABLE [dbo].[Urunler]  WITH CHECK ADD  CONSTRAINT [FK_Urunler_Kategoriler] FOREIGN KEY([KategoriId])
REFERENCES [dbo].[Kategoriler] ([KategoriId])
GO
ALTER TABLE [dbo].[Urunler] CHECK CONSTRAINT [FK_Urunler_Kategoriler]
GO
USE [master]
GO
ALTER DATABASE [carihesap] SET  READ_WRITE 
GO
