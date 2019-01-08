USE [master]
GO
/****** Object:  Database [SistemaTIS]    Script Date: 12/12/2018 7:55:10 PM ******/
CREATE DATABASE [SistemaTIS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SistemaTIS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SistemaTIS.mdf' , SIZE = 9216KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SistemaTIS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SistemaTIS_log.ldf' , SIZE = 13632KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SistemaTIS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SistemaTIS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SistemaTIS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SistemaTIS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SistemaTIS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SistemaTIS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SistemaTIS] SET ARITHABORT OFF 
GO
ALTER DATABASE [SistemaTIS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SistemaTIS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SistemaTIS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SistemaTIS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SistemaTIS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SistemaTIS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SistemaTIS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SistemaTIS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SistemaTIS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SistemaTIS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SistemaTIS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SistemaTIS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SistemaTIS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SistemaTIS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SistemaTIS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SistemaTIS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SistemaTIS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SistemaTIS] SET RECOVERY FULL 
GO
ALTER DATABASE [SistemaTIS] SET  MULTI_USER 
GO
ALTER DATABASE [SistemaTIS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SistemaTIS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SistemaTIS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SistemaTIS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SistemaTIS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SistemaTIS', N'ON'
GO
USE [SistemaTIS]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bitacora](
	[IdBitacora] [uniqueidentifier] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Criticidad] [varchar](50) NOT NULL,
	[Actividad] [varchar](255) NOT NULL,
	[InformacionAsociada] [varchar](4000) NOT NULL,
	[IdUsuario] [uniqueidentifier] NULL,
	[DVH] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[IdCliente] [uniqueidentifier] NOT NULL,
	[IdDomicilio] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[FechaNacimiento] [smalldatetime] NOT NULL,
	[dni] [varchar](30) NOT NULL,
	[Sexo] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Email] [varchar](60) NULL,
	[IdContacto] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK__CLIENTE__D59466420D752829] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COBERTURA]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COBERTURA](
	[IdCobertura] [uniqueidentifier] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[PrimaAsegurada] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCobertura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CONTACTO]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTACTO](
	[IdContacto] [uniqueidentifier] NOT NULL,
	[Telefono] [nvarchar](50) NULL,
	[Celular] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdContacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DETALLE_FACTURA]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_FACTURA](
	[IdDetalle] [uniqueidentifier] NOT NULL,
	[IdVehiculo] [uniqueidentifier] NOT NULL,
	[IdCliente] [uniqueidentifier] NOT NULL,
	[Importe] [decimal](9, 2) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DETALLE_POLIZA]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_POLIZA](
	[IdDetalle] [uniqueidentifier] NOT NULL,
	[IdCobertura] [uniqueidentifier] NOT NULL,
	[IdVehiculo] [uniqueidentifier] NOT NULL,
	[PRIMA] [decimal](9, 2) NOT NULL,
	[SumaAsegurada] [decimal](9, 2) NOT NULL,
	[DVH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DigitoVerificadorVertical]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DigitoVerificadorVertical](
	[IdDVH] [uniqueidentifier] NOT NULL,
	[Entidad] [nvarchar](12) NOT NULL,
	[ValorDigitoVerificador] [int] NOT NULL,
 CONSTRAINT [PK_DVV] PRIMARY KEY CLUSTERED 
(
	[IdDVH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DOMICILIO]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOMICILIO](
	[IdDomicilio] [uniqueidentifier] NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[IdLocalidad] [uniqueidentifier] NOT NULL,
	[CodPostal] [nvarchar](32) NOT NULL,
	[IdProvincia] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDomicilio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FACTURA]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FACTURA](
	[IdFactura] [uniqueidentifier] NOT NULL,
	[IdDetalle] [uniqueidentifier] NOT NULL,
	[IdPoliza] [uniqueidentifier] NOT NULL,
	[NumeroFactura] [int] NOT NULL,
	[Vencimiento] [smalldatetime] NOT NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FAMILIA]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAMILIA](
	[IdFamilia] [uniqueidentifier] NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FamiliaPatente]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamiliaPatente](
	[IdFamilia] [uniqueidentifier] NOT NULL,
	[IdPatente] [uniqueidentifier] NOT NULL,
	[DVH] [int] NOT NULL,
 CONSTRAINT [PK_FamiliaPatente] PRIMARY KEY NONCLUSTERED 
(
	[IdFamilia] ASC,
	[IdPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FamiliaUsuario]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamiliaUsuario](
	[IdFamilia] [uniqueidentifier] NOT NULL,
	[IdUsuario] [uniqueidentifier] NOT NULL,
	[DVH] [int] NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY NONCLUSTERED 
(
	[IdFamilia] ASC,
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FORMULARIO]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FORMULARIO](
	[IdFormulario] [uniqueidentifier] NOT NULL,
	[NombreFormulario] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFormulario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FormularioPatente]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormularioPatente](
	[IdFormularioPatente] [uniqueidentifier] NOT NULL,
	[IdPatente] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_FormPatente] PRIMARY KEY NONCLUSTERED 
(
	[IdFormularioPatente] ASC,
	[IdPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IDIOMA]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IDIOMA](
	[IdIdioma] [uniqueidentifier] NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOCALIDAD]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOCALIDAD](
	[IdLocalidad] [uniqueidentifier] NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[IdProvincia] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MARCA]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MARCA](
	[IdMarca] [uniqueidentifier] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MODELO]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MODELO](
	[IdModelo] [uniqueidentifier] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[IdMarca] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK__MODELO__CC30D30C77B4F999] PRIMARY KEY CLUSTERED 
(
	[IdModelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Patente]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patente](
	[IdPatente] [uniqueidentifier] NOT NULL,
	[Descripcion] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[IdPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[POLIZA]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POLIZA](
	[IdPoliza] [uniqueidentifier] NOT NULL,
	[IdDetalle] [uniqueidentifier] NOT NULL,
	[IdCliente] [uniqueidentifier] NOT NULL,
	[Estado] [bit] NOT NULL,
	[NroPoliza] [int] NOT NULL,
	[FechaEmision] [smalldatetime] NOT NULL,
 CONSTRAINT [PK__POLIZA__8E3943B315D83402] PRIMARY KEY CLUSTERED 
(
	[IdPoliza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PROVINCIA]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PROVINCIA](
	[IdProvincia] [uniqueidentifier] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TIPOUSO]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TIPOUSO](
	[IdTipoUso] [uniqueidentifier] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoUso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoVehiculo]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoVehiculo](
	[IdTipoVehiculo] [uniqueidentifier] NOT NULL,
	[Descripcion] [varchar](100) NULL,
 CONSTRAINT [PK_TipoVehiculo] PRIMARY KEY CLUSTERED 
(
	[IdTipoVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRADUCCION]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRADUCCION](
	[IdTraduccion] [uniqueidentifier] NOT NULL,
	[IdIdioma] [uniqueidentifier] NOT NULL,
	[IdFormulario] [uniqueidentifier] NOT NULL,
	[ControlName] [varchar](50) NULL,
	[MensajeCodigo] [varchar](50) NULL,
	[Traduccion] [varchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTraduccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USUARIO](
	[IdUsuario] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[CantLoginsFallidos] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[IdDomicilio] [uniqueidentifier] NOT NULL,
	[IdContacto] [uniqueidentifier] NOT NULL,
	[IdIdioma] [uniqueidentifier] NOT NULL,
	[PrimerLogin] [bit] NOT NULL,
	[Sexo] [varchar](50) NULL,
	[Dvh] [int] NULL,
	[Bloqueado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioPatente]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPatente](
	[IdPatente] [uniqueidentifier] NOT NULL,
	[IdUsuario] [uniqueidentifier] NOT NULL,
	[Negada] [bit] NOT NULL,
	[DVH] [int] NULL,
 CONSTRAINT [PK_UsuarioPatente] PRIMARY KEY NONCLUSTERED 
(
	[IdUsuario] ASC,
	[IdPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 12/12/2018 7:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[IdVehiculo] [uniqueidentifier] NOT NULL,
	[IdTipoUso] [uniqueidentifier] NOT NULL,
	[IdMarca] [uniqueidentifier] NOT NULL,
	[IdModelo] [uniqueidentifier] NOT NULL,
	[CantPuertas] [smallint] NOT NULL,
	[Color] [varchar](50) NOT NULL,
	[Combustible] [varchar](100) NOT NULL,
	[NumChasis] [varchar](20) NOT NULL,
	[NumSerie] [varchar](20) NOT NULL,
	[Patente] [varchar](10) NOT NULL,
	[Año] [nchar](16) NOT NULL,
	[Foto1] [varbinary](max) NULL,
	[Foto2] [varbinary](max) NULL,
	[Foto3] [varbinary](max) NULL,
	[Foto4] [varbinary](max) NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[IdVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CLIENTE]  WITH CHECK ADD  CONSTRAINT [FK__CLIENTE__IdDomic__0A688BB1] FOREIGN KEY([IdDomicilio])
REFERENCES [dbo].[DOMICILIO] ([IdDomicilio])
GO
ALTER TABLE [dbo].[CLIENTE] CHECK CONSTRAINT [FK__CLIENTE__IdDomic__0A688BB1]
GO
ALTER TABLE [dbo].[CLIENTE]  WITH CHECK ADD  CONSTRAINT [FK_CLIENTE_CONTACTO] FOREIGN KEY([IdContacto])
REFERENCES [dbo].[CONTACTO] ([IdContacto])
GO
ALTER TABLE [dbo].[CLIENTE] CHECK CONSTRAINT [FK_CLIENTE_CONTACTO]
GO
ALTER TABLE [dbo].[DETALLE_FACTURA]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[CLIENTE] ([IdCliente])
GO
ALTER TABLE [dbo].[DETALLE_FACTURA]  WITH CHECK ADD FOREIGN KEY([IdVehiculo])
REFERENCES [dbo].[Vehiculo] ([IdVehiculo])
GO
ALTER TABLE [dbo].[DETALLE_POLIZA]  WITH CHECK ADD FOREIGN KEY([IdCobertura])
REFERENCES [dbo].[COBERTURA] ([IdCobertura])
GO
ALTER TABLE [dbo].[DOMICILIO]  WITH CHECK ADD FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[LOCALIDAD] ([IdLocalidad])
GO
ALTER TABLE [dbo].[DOMICILIO]  WITH CHECK ADD FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[PROVINCIA] ([IdProvincia])
GO
ALTER TABLE [dbo].[LOCALIDAD]  WITH CHECK ADD FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[PROVINCIA] ([IdProvincia])
GO
ALTER TABLE [dbo].[MODELO]  WITH CHECK ADD  CONSTRAINT [FK_MODELO_MODELO] FOREIGN KEY([IdModelo])
REFERENCES [dbo].[MODELO] ([IdModelo])
GO
ALTER TABLE [dbo].[MODELO] CHECK CONSTRAINT [FK_MODELO_MODELO]
GO
ALTER TABLE [dbo].[POLIZA]  WITH CHECK ADD  CONSTRAINT [FK__POLIZA__IdClient__12FDD1B2] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[CLIENTE] ([IdCliente])
GO
ALTER TABLE [dbo].[POLIZA] CHECK CONSTRAINT [FK__POLIZA__IdClient__12FDD1B2]
GO
ALTER TABLE [dbo].[POLIZA]  WITH CHECK ADD  CONSTRAINT [FK__POLIZA__IdDetall__1209AD79] FOREIGN KEY([IdDetalle])
REFERENCES [dbo].[DETALLE_POLIZA] ([IdDetalle])
GO
ALTER TABLE [dbo].[POLIZA] CHECK CONSTRAINT [FK__POLIZA__IdDetall__1209AD79]
GO
ALTER TABLE [dbo].[TRADUCCION]  WITH CHECK ADD FOREIGN KEY([IdFormulario])
REFERENCES [dbo].[FORMULARIO] ([IdFormulario])
GO
ALTER TABLE [dbo].[TRADUCCION]  WITH CHECK ADD FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[IDIOMA] ([IdIdioma])
GO
USE [master]
GO
ALTER DATABASE [SistemaTIS] SET  READ_WRITE 
GO
