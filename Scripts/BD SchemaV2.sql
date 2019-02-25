IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'PolizaCobertura'))
BEGIN
CREATE TABLE [dbo].[PolizaCobertura](
	[IdPoliza] uniqueidentifier NOT NULL,
	[IdCobertura] uniqueidentifier NOT NULL,
	CONSTRAINT PK_PolizaCobertura PRIMARY KEY NONCLUSTERED ([IdPoliza], [IdCobertura])
) ON [PRIMARY]
END
GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'FamiliaPatente'))
BEGIN
CREATE TABLE [dbo].[FamiliaPatente](
	[IdFamilia] uniqueidentifier NOT NULL,
	[IdPatente] uniqueidentifier NOT NULL,
	[DVH] [int] NOT NULL
	CONSTRAINT PK_FamiliaPatente PRIMARY KEY NONCLUSTERED ([IdFamilia], [IdPatente])
) ON [PRIMARY]
END
GO
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'FamiliaUsuario'))
BEGIN
CREATE TABLE [dbo].[FamiliaUsuario](
	[IdFamilia] uniqueidentifier references dbo.Familia NOT NULL,
	[IdUsuario] uniqueidentifier references dbo.usuario NOT NULL,
	[DVH] [int] NULL,
 CONSTRAINT PK_UserGroup PRIMARY KEY NONCLUSTERED ([IdFamilia], [IdUsuario])
 )
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'DigitoVerificadorVertical'))
BEGIN
CREATE TABLE [dbo].[DigitoVerificadorVertical](
	[IdDVH][Uniqueidentifier] not null,
	[Entidad] [nvarchar](12) NOT NULL,
	[ValorDigitoVerificador] [int] NOT NULL,
	CONSTRAINT [PK_DVV] PRIMARY KEY CLUSTERED(
	[IdDVH] ASC)
) ON [PRIMARY]
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'FormularioPatente'))
BEGIN
CREATE TABLE [dbo].[FormularioPatente](
	[IdFormularioPatente] uniqueidentifier NOT NULL,
	[IdPatente] uniqueidentifier NOT NULL,
	CONSTRAINT PK_FormPatente PRIMARY KEY NONCLUSTERED ([IdFormularioPatente], [IdPatente])
) ON [PRIMARY]
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Patente'))
BEGIN
CREATE TABLE [dbo].[Patente](
	[IdPatente] uniqueidentifier NOT NULL,
	[Descripcion] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[IdPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
--Agregamos algunas patentes
insert into Patente(IdPatente, Descripcion) values(NEWID(), 'Realizar cobro')
go
insert into Patente(IdPatente, Descripcion) values(NEWID(), 'Imprimir factura')
go
insert into Patente(IdPatente, Descripcion) values(NEWID(), 'Baja de usuario')
go
insert into Patente(IdPatente, Descripcion) values(NEWID(), 'Modificacion de usuario')
go
insert into Patente(IdPatente, Descripcion) values(NEWID(), 'Emitir poliza')
go
insert into Patente(IdPatente, Descripcion) values(NEWID(), 'Alta de usuario')
--Agregamos algunas familias
go
insert into FAMILIA(IdFamilia, Descripcion) values(NEWID(), 'Administrador')
go
insert into FAMILIA(IdFamilia, Descripcion) values(NEWID(), 'Super Administrador')
go
insert into FAMILIA(IdFamilia, Descripcion) values(NEWID(), 'Cajero')
go
insert into FAMILIA(IdFamilia, Descripcion) values(NEWID(), 'Gerente')
go
insert into FAMILIA(IdFamilia, Descripcion) values(NEWID(), 'Cliente')
go
insert into FAMILIA(IdFamilia, Descripcion) values(NEWID(), 'Socio')

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'UsuarioPatente'))
BEGIN
CREATE TABLE [dbo].[UsuarioPatente](
	[IdPatente] uniqueidentifier references dbo.Patente NOT NULL,
	[IdUsuario] uniqueidentifier references dbo.Usuario NOT NULL,
	[Negada] [bit] NOT NULL,
	[DVH] [int]  NULL,--HACERLO NOT NULL
 CONSTRAINT [PK_UsuarioPatente] PRIMARY KEY NONCLUSTERED 

	([IdUsuario], [IdPatente])
) ON [PRIMARY]
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'FORMULARIO'))
BEGIN
	CREATE TABLE FORMULARIO
	(
	IdFormulario uniqueidentifier not null,
	NombreFormulario varchar(100) not null,--CAMBIAR EL TIPO DE DATO EN EL DOC
	primary key(IdFormulario)
	)
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'TRADUCCION'))
BEGIN
	CREATE TABLE TRADUCCION
	(
	IdTraduccion uniqueidentifier not null,
	IdIdioma uniqueidentifier References dbo.Idioma not null,
	IdFormulario uniqueidentifier references dbo.Formulario not null,
	ControlName varchar(50) null,
	MensajeCodigo varchar(50) null,
	Traduccion varchar(300) not null
	primary key(IdTraduccion)
	)
END

GO




CREATE TABLE [dbo].[Bitacora](
	[IdBitacora] [uniqueidentifier] PRIMARY KEY DEFAULT (NEWID()),
	[Fecha] [datetime] NOT NULL,
	[Criticidad] [varchar](50) NOT NULL,
	[Actividad] [varchar](255) NOT NULL,
	[InformacionAsociada] [varchar](4000) NOT NULL,
	[IdUsuario] [varchar](50) NULL,
	[DVH] [varchar](50) NULL,
 )
GO

GO
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'PROVINCIA'))
BEGIN
	CREATE TABLE PROVINCIA
	(
	IdProvincia uniqueidentifier not null,
	Descripcion varchar(100) not null,--CAMBIAR EL TIPO DE DATO EN EL DOC
	primary key(IdProvincia)
	)
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'LOCALIDAD'))
BEGIN
	CREATE TABLE LOCALIDAD
	(
	IdLocalidad uniqueidentifier not null,
	Descripcion varchar(100),--CAMBIAR EL TIPO DE DATO EN EL DOC
	IdProvincia uniqueidentifier not null references PROVINCIA,
	primary key(IdLocalidad)
	)
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'DOMICILIO'))
BEGIN
   CREATE TABLE DOMICILIO
(
IdDomicilio uniqueidentifier not null,
Direccion nvarchar(100) not null,
IdLocalidad uniqueidentifier not null references Localidad,
CodPostal nvarchar(32) not null,
primary key(IdDomicilio)
)

END


IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'COBERTURA'))
BEGIN
	CREATE TABLE COBERTURA
	(
	IdCobertura uniqueidentifier  NOT NULL,
	Descripcion VARCHAR(100) NOT NULL,
	PRIMARY KEY(IdCobertura)
	)

END

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'CLIENTE'))
BEGIN
	CREATE TABLE CLIENTE 
	(
	IdCliente uniqueidentifier not null,
	IdDomicilio uniqueidentifier not null references DOMICILIO,--CAMBIAR EL TIPO DE DATO EN EL DOC
	IdContacto uniqueidentifier not null references Contacto,--AGREGAR ESTO AL D
 	Nombre varchar(50) not null,
	Apellido varchar(50),
	FechaNacimiento smalldatetime not null,--CAMBIAR EL TIPO DE DATO EN EL DOC
	Dni int not null,
	Sexo bit not null,
	Email varchar(50) not null,
	Estado bit not null,
	primary key(IdCliente) 
	)
END


IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'DETALLE_POLIZA'))
BEGIN
	CREATE TABLE DETALLE_POLIZA
	(
	IdDetalle uniqueidentifier  NOT NULL,
	IdCobertura uniqueidentifier NOT NULL REFERENCES COBERTURA,
	IdVehiculo uniqueidentifier NOT NULL,
	PRIMA DECIMAL(9,2) NULL,
	SumaAsegurada DECIMAL(9,2) NOT NULL,
	DVH INT NOT NULL
	PRIMARY KEY (IDDETALLE)
	)
END

GO
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'POLIZA'))
BEGIN
	CREATE TABLE POLIZA
	(
	IdPoliza uniqueidentifier NOT NULL,
	IdDetalle uniqueidentifier NOT NULL REFERENCES DETALLE_POLIZA,
	IdCliente uniqueidentifier NOT NULL REFERENCES CLIENTE, 
	Estado BIT NOT NULL,
	NroPoliza INT NOT NULL,
	FechaEmision smalldatetime not null,
	PRIMARY KEY(IdPoliza)
	)
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'FACTURA'))
BEGIN
	CREATE TABLE FACTURA
	(
	IdFactura uniqueidentifier NOT NULL,
	IdDetalle uniqueidentifier not null,
	IdPoliza uniqueidentifier not null,
	NumeroFactura int not null,
    Vencimiento smalldatetime not null,
	Estado BIT NOT NULL,
	PRIMARY KEY(IdFactura)
	)
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'DETALLE_FACTURA'))
BEGIN
	CREATE TABLE DETALLE_FACTURA
	(
	IdDetalle uniqueidentifier NOT NULL,
	IdVehiculo uniqueidentifier not null REFERENCES Vehiculo,
	IdCliente uniqueidentifier NOT NULL REFERENCES CLIENTE,
	Importe DECIMAL(9,2) NOT NULL--CAMBIAR EL TIPO DE DATO EN EL DOC
	)
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'CONTACTO'))
BEGIN
	CREATE TABLE CONTACTO
	(
	IdContacto uniqueidentifier not null, 
	Telefono nvarchar(50) null,--CAMBIAR EL TIPO DE DATO EN EL DOC
	Celular nvarchar(50) null,--CAMBIAR EL TIPO DE DATO EN EL DOC
	primary key(IdContacto)
	)
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'IDIOMA'))
BEGIN
	CREATE TABLE IDIOMA
	(
	IdIdioma uniqueidentifier not null,
	Descripcion nvarchar(50) not null,
	primary key(IdIdioma)
	)
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'USUARIO'))
BEGIN
	CREATE TABLE USUARIO
	(
	IdUsuario uniqueidentifier  not null,--Cambiar el tipo de dato en la documentacion
	Nombre nvarchar(50) not null,
	Apellido nvarchar(50) not null,
	--UsuarioEncriptado nvarchar(50) not null,--eliminar columna del documento
	Password nvarchar(50) not null,
	Email nvarchar(100) not null,
	CantLoginsFallidos int not null,
	Estado bit not null,
	IdDomicilio uniqueidentifier not null references DOMICILIO,
	IdContacto uniqueidentifier not null references CONTACTO,
	IdIdioma uniqueidentifier not null references IDIOMA,
	PrimerLogin bit not null,
	Sexo bit not null,--Agregar en la documentacion
	--DVH int not null
	primary key(IdUsuario)
	)
END

GO



IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'FAMILIA'))
BEGIN
	CREATE TABLE FAMILIA
	(
	IdFamilia uniqueidentifier not null,
	Descripcion nvarchar(50) not null
	primary key(IdFamilia)
	)
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'TRADUCCION'))
BEGIN
	CREATE TABLE TRADUCCION
	(
	IdTraduccion UNIQUEIDENTIFIER not null,
	Descripcion nvarchar(255) not null,
	IdIdioma uniqueidentifier not null references IDIOMA,
	primary key(IdTraduccion)
	)
END

GO
---------------------------
GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'MARCA'))
BEGIN
	CREATE TABLE MARCA 
	(
	IdMarca [uniqueidentifier] NOT NULL,
	Descripcion VARCHAR(100) NOT NULL,
	PRIMARY KEY(IdMarca)
	)
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'CLASE_VEHICULO'))
BEGIN
	CREATE TABLE CLASE_VEHICULO
	(
	IdTipoVehiculo [uniqueidentifier] NOT NULL,
	Descripcion VARCHAR(100) NOT NULL,
	PRIMARY KEY (IdTipoVehiculo)
	)
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'MODELO'))
BEGIN
	CREATE TABLE MODELO
	(
	IdModelo [uniqueidentifier] NOT NULL,
	Descripcion VARCHAR(100) NOT NULL,
	PRIMARY KEY(IdModelo)
	)
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'TIPOUSO'))
BEGIN

	CREATE TABLE TIPOUSO
	(
	IdTipoUso [uniqueidentifier] NOT NULL,
	Descripcion VARCHAR(100) NOT NULL,
	PRIMARY KEY(IdTipoUso)
	)
END

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


------------------------------

USE [SistemaTIS]
GO

/****** Object:  Table [dbo].[Vehiculo]    Script Date: 9/16/2018 3:32:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Vehiculo](
	[IdVehiculo] [uniqueidentifier] NOT NULL,
	[IdTipoUso] [uniqueidentifier] NOT NULL,
	[IdTipoVehiculo] [uniqueidentifier] NOT NULL,
	[IdMarca] [uniqueidentifier] NOT NULL,
	--[IdClaseVehiculo] [uniqueidentifier] NULL,
	[IdModelo] [uniqueidentifier] NOT NULL,
	[CantPuertas] [smallint] NOT NULL,
	[Color] [varchar](50) NOT NULL,
	[Combustible] [varchar](100) NOT NULL,
	[NumChasis] [varchar](20) NOT NULL,
	[NumSerie] [varchar](20) NOT NULL,
	[Patente] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[IdVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

--Insert into table localidad

insert into dbo.LOCALIDAD (IdLocalidad, Descripcion, IdProvincia) values 
('0CCFEF30-4F59-4DC2-93B7-779B1BA3071E', 'Jose c Paz', '12582D77-BA41-4A95-95BB-CA67D11216D6')

GO

insert into dbo.LOCALIDAD (IdLocalidad, Descripcion, IdProvincia) values 
('F0D3448E-0DE4-43B2-AE03-56063E094760', 'San Miguel', '12582D77-BA41-4A95-95BB-CA67D11216D6')

GO

insert into dbo.LOCALIDAD (IdLocalidad, Descripcion, IdProvincia) values 
('7343825A-5765-4EFB-8BF0-C6D83F9A12EF', 'Malvinas Argentinas', '12582D77-BA41-4A95-95BB-CA67D11216D6')

GO
--insert into table provincias
insert into dbo.PROVINCIA(IdProvincia, Descripcion) values 
('12582D77-BA41-4A95-95BB-CA67D11216D6', 'Buenos Aires')

GO

insert into dbo.PROVINCIA(IdProvincia, Descripcion) values 
('7343825A-5765-4EFB-8BF0-C6D83F9A12EF', 'Cordoba')

GO

insert into dbo.PROVINCIA(IdProvincia, Descripcion) values 
('C057870D-0B2F-4E0B-B79F-A95C74B81B0E', 'Santa Fé')

GO
--Insert languages and ids

insert into dbo.IDIOMA(IdIdioma, Descripcion) values
(NEWID(), 'Español')

GO

insert into dbo.IDIOMA(IdIdioma, Descripcion) values
(NEWID(), 'Ingles')

GO 

--Insert formsIds and names

insert into dbo.FORMULARIO(IdFormulario, NombreFormulario) values
(NewID(), 'frmABMUsuarios')

GO

insert into dbo.FORMULARIO(IdFormulario, NombreFormulario) values
(NewID(), 'frmLogin')

GO

insert into dbo.FORMULARIO(IdFormulario, NombreFormulario) values
(NewID(), 'frmABMUsuarios')

GO

insert into dbo.FORMULARIO(IdFormulario, NombreFormulario) values
(NewID(), 'frmBitacora')

GO

insert into dbo.FORMULARIO(IdFormulario, NombreFormulario) values
(NewID(), 'frmNuevoUsuario')

GO

insert into dbo.FORMULARIO(IdFormulario, NombreFormulario) values
(NewID(), 'frmPrincipal')

GO

insert into dbo.FORMULARIO(IdFormulario, NombreFormulario) values
(NewID(), 'frmRealizarCopiaSeguridad')

GO

insert into dbo.FORMULARIO(IdFormulario, NombreFormulario) values
(NewID(), 'frmRestaurarCopiaDeSeguridad')

--insert tanslations in dbo.Traduccion
GO
----Formulario Login - Español---
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '632302C5-266A-440D-9F39-6DC6DDEBAACF', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', 'lblEmail', 
null, 'E-mail')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '632302C5-266A-440D-9F39-6DC6DDEBAACF', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', 'lblContraseña', 
null, 'Contraseña')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '632302C5-266A-440D-9F39-6DC6DDEBAACF', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', 'lblRecuperarPassword', 
null, 'Recuperar Contraseña')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '632302C5-266A-440D-9F39-6DC6DDEBAACF', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', 'lblSeleccionarIdioma', 
null, 'Seleccionar Idioma')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '632302C5-266A-440D-9F39-6DC6DDEBAACF', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', 'btnIngresar', 
null, 'Ingresar')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '632302C5-266A-440D-9F39-6DC6DDEBAACF', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', 'btnSalir', 
null, 'Salir')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '632302C5-266A-440D-9F39-6DC6DDEBAACF', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', 'lblTitulo', 
null, 'Por favor ingrese usuario y contraseña para ingresar')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '632302C5-266A-440D-9F39-6DC6DDEBAACF', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', null, 
'MSJ001', 'Estas seguro que desea salir del Sistema TIS?')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '632302C5-266A-440D-9F39-6DC6DDEBAACF', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', null, 
'MSJ002', 'Por favor verifique los datos ingresados.')
GO
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '632302C5-266A-440D-9F39-6DC6DDEBAACF', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', null, 
'MSJ003', 'Ocurrio un error al loguearse. Por favor verifique los datos ingresados.')
GO
----Formulario Login - Ingles---
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '14036BCA-1316-42A7-AED2-10BB3BF61E30', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', 'lblEmail', 
null, 'E-mail')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '14036BCA-1316-42A7-AED2-10BB3BF61E30', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE0', 'lblContraseña', 
null, 'Password')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '14036BCA-1316-42A7-AED2-10BB3BF61E30', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', 'lblRecuperarPassword', 
null, 'Forgot Password?')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '14036BCA-1316-42A7-AED2-10BB3BF61E30', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', 'lblSeleccionarIdioma', 
null, 'Select Language')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '14036BCA-1316-42A7-AED2-10BB3BF61E30', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', 'btnIngresar', 
null, 'Login')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '14036BCA-1316-42A7-AED2-10BB3BF61E30', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', 'btnSalir', 
null, 'Cancel')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '14036BCA-1316-42A7-AED2-10BB3BF61E30', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', 'lblTitulo', 
null, 'Please input a user and password to login')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '14036BCA-1316-42A7-AED2-10BB3BF61E30', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', null, 
'MSJ001', 'Are you sure you want to exit the Sistema TIS?')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '14036BCA-1316-42A7-AED2-10BB3BF61E30', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', null, 
'MSJ002', 'Please check the e-mail and password.')
GO
insert into dbo.TRADUCCION (IdTraduccion, IdIdioma, IdFormulario, ControlName, MensajeCodigo, Traduccion)
values (NEWID(), '14036BCA-1316-42A7-AED2-10BB3BF61E30', 'F19CEEC0-F6E4-4474-A506-EFB58E516EAE', null, 
'MSJ003', 'An error occurred when logging in. Please verify the entered data.')



---------------------------------------------------------------------------------------------------------
--------Coberturas---------------------------------------------------------------------------------------
--AGREGAR LA SUMA ASEGURADA A DOCX
insert into COBERTURA (IdCobertura, Descripcion, PrimaAsegurada) values (NEWID(), 'Responsabilidad Cívil', 6000000)
GO
insert into COBERTURA (IdCobertura, Descripcion, PrimaAsegurada) values (NEWID(), 'Robo Parcial', 120000)
GO
insert into COBERTURA (IdCobertura, Descripcion, PrimaAsegurada) values (NEWID(), 'Robo Total', 300000)
GO
insert into COBERTURA (IdCobertura, Descripcion, PrimaAsegurada) values (NEWID(), 'Incendio Parcial', 300000)
GO
insert into COBERTURA (IdCobertura, Descripcion, PrimaAsegurada) values (NEWID(), 'Incendio Total', 400000)
GO
insert into COBERTURA (IdCobertura, Descripcion, PrimaAsegurada) values (NEWID(), 'Accidente', 350000)
GO
insert into COBERTURA (IdCobertura, Descripcion, PrimaAsegurada) values (NEWID(), 'Rotura de Cristales laterales', 70000)
GO
insert into COBERTURA (IdCobertura, Descripcion, PrimaAsegurada) values (NEWID(), 'Rotura de Luneta y Parabrisa', 120000)
GO
insert into COBERTURA (IdCobertura, Descripcion, PrimaAsegurada) values (NEWID(), 'Granizo', 200000)
GO
insert into COBERTURA (IdCobertura, Descripcion, PrimaAsegurada) values (NEWID(), 'Robo de Llaves', 40000)
GO
insert into COBERTURA (IdCobertura, Descripcion, PrimaAsegurada) values (NEWID(), 'Responsabilidad Cívil y Mercosur Limitada', 3000000)
GO
insert into COBERTURA (IdCobertura, Descripcion, PrimaAsegurada) values (NEWID(), 'Reposición de Neumaticos', 50000)
GO
insert into COBERTURA (IdCobertura, Descripcion, PrimaAsegurada) values (NEWID(), 'Servicio de Grúa', 10000)
-----------------------------------------------------------------------------------------------------------------------
---- Cargamos las tablas asociadas a los vehiculos --------------------------------------------------------------------
GO
insert into TIPOUSO (IdTipoUso, Descripcion) values (NEWID(), 'Particular o Privado')
GO
insert into TIPOUSO (IdTipoUso, Descripcion) values (NEWID(), 'Profesional')
GO
insert into TIPOUSO (IdTipoUso, Descripcion) values (NEWID(), 'Ventas Ambulantes')
GO
insert into TIPOUSO (IdTipoUso, Descripcion) values (NEWID(), 'Viajantes y Representantes')
GO
insert into TIPOUSO (IdTipoUso, Descripcion) values (NEWID(), 'Uso Policial')
GO
insert into TIPOUSO (IdTipoUso, Descripcion) values (NEWID(), 'Uso Militar')
GO
insert into TIPOUSO (IdTipoUso, Descripcion) values (NEWID(), 'Transporte de Carga Urbano')
GO
insert into TIPOUSO (IdTipoUso, Descripcion) values (NEWID(), 'Transporte de Carga Interurbano')
GO

--MARCAS-
insert into MARCA(IdMarca, Descripcion) values ('A6C652C0-94C7-46D7-91A4-D2A1A331AA5F', 'Chevrolet')
GO
insert into MARCA(IdMarca, Descripcion) values ('F72F95A7-CDDC-4051-B596-BDC7CECC72F8', 'Ford')
GO
insert into MARCA(IdMarca, Descripcion) values ('35AC4F0A-A09F-4F91-B175-EF0D2F05A103', 'Volkswaguen')
GO
insert into MARCA(IdMarca, Descripcion) values ('E8265018-BBDA-4318-BEDF-D1EC519DCD63', 'Fiat')
GO
insert into MARCA(IdMarca, Descripcion) values ('5D989357-60E3-4822-85CE-C0D5BF244CEE', 'Renault')
GO
insert into MARCA(IdMarca, Descripcion) values ('DC902AE7-C275-49CA-8642-38D0E6FE4554', 'Toyota')
GO
insert into MARCA(IdMarca, Descripcion) values ('1D8CD3F8-6F11-4D23-8818-C14E15CCF30B', 'BMW')
GO
insert into MARCA(IdMarca, Descripcion) values ('6A355B43-13AD-4059-8120-C1GE88199E11', 'Peugeot')
GO
--MODELOS---
--Chevrolet--
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Tracker', 'A6C652C0-94C7-46D7-91A4-D2A1A331AA5F')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Spin', 'A6C652C0-94C7-46D7-91A4-D2A1A331AA5F')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Prisma', 'A6C652C0-94C7-46D7-91A4-D2A1A331AA5F')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Aveo', 'A6C652C0-94C7-46D7-91A4-D2A1A331AA5F')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Celta', 'A6C652C0-94C7-46D7-91A4-D2A1A331AA5F')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Onix', 'A6C652C0-94C7-46D7-91A4-D2A1A331AA5F')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Cobalt', 'A6C652C0-94C7-46D7-91A4-D2A1A331AA5F')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Cruze', 'A6C652C0-94C7-46D7-91A4-D2A1A331AA5F')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Camaro', 'A6C652C0-94C7-46D7-91A4-D2A1A331AA5F')
GO
--Ford--
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Ford KA', 'F72F95A7-CDDC-4051-B596-BDC7CECC72F8')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Fiesta', 'F72F95A7-CDDC-4051-B596-BDC7CECC72F8')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Fiesta Max', 'F72F95A7-CDDC-4051-B596-BDC7CECC72F8')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Focus', 'F72F95A7-CDDC-4051-B596-BDC7CECC72F8')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Eco Sport', 'F72F95A7-CDDC-4051-B596-BDC7CECC72F8')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Ranger', 'F72F95A7-CDDC-4051-B596-BDC7CECC72F8')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Mondeo', 'F72F95A7-CDDC-4051-B596-BDC7CECC72F8')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Transit', 'F72F95A7-CDDC-4051-B596-BDC7CECC72F8')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Focus Sedán', 'F72F95A7-CDDC-4051-B596-BDC7CECC72F8')
GO
--Volkswaguen--
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Suran', '35AC4F0A-A09F-4F91-B175-EF0D2F05A103')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Gol', '35AC4F0A-A09F-4F91-B175-EF0D2F05A103')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Polo', '35AC4F0A-A09F-4F91-B175-EF0D2F05A103')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Golf', '35AC4F0A-A09F-4F91-B175-EF0D2F05A103')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Fox', '35AC4F0A-A09F-4F91-B175-EF0D2F05A103')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Up', '35AC4F0A-A09F-4F91-B175-EF0D2F05A103')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Saveiro', '35AC4F0A-A09F-4F91-B175-EF0D2F05A103')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Amarok', '35AC4F0A-A09F-4F91-B175-EF0D2F05A103')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Virtus', '35AC4F0A-A09F-4F91-B175-EF0D2F05A103')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Voyage', '35AC4F0A-A09F-4F91-B175-EF0D2F05A103')
GO
--Fiat--
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Argo', 'E8265018-BBDA-4318-BEDF-D1EC519DCD63')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Toro', 'E8265018-BBDA-4318-BEDF-D1EC519DCD63')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Mobi', 'E8265018-BBDA-4318-BEDF-D1EC519DCD63')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Cronos', 'E8265018-BBDA-4318-BEDF-D1EC519DCD63')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Palio', 'E8265018-BBDA-4318-BEDF-D1EC519DCD63')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), '500', 'E8265018-BBDA-4318-BEDF-D1EC519DCD63')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Ducato', 'E8265018-BBDA-4318-BEDF-D1EC519DCD63')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Tipo', 'E8265018-BBDA-4318-BEDF-D1EC519DCD63')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Fiorino', 'E8265018-BBDA-4318-BEDF-D1EC519DCD63')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Adventure', 'E8265018-BBDA-4318-BEDF-D1EC519DCD63')
GO
--Renault--
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Duster', '5D989357-60E3-4822-85CE-C0D5BF244CEE')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'KWID', '5D989357-60E3-4822-85CE-C0D5BF244CEE')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Sandero Stepaway', '5D989357-60E3-4822-85CE-C0D5BF244CEE')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Captur', '5D989357-60E3-4822-85CE-C0D5BF244CEE')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Fluence', '5D989357-60E3-4822-85CE-C0D5BF244CEE')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Logan', '5D989357-60E3-4822-85CE-C0D5BF244CEE')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Renault 9', '5D989357-60E3-4822-85CE-C0D5BF244CEE')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Renault 12', '5D989357-60E3-4822-85CE-C0D5BF244CEE')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Renault 19', '5D989357-60E3-4822-85CE-C0D5BF244CEE')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Kangoo', '5D989357-60E3-4822-85CE-C0D5BF244CEE')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Clio', '5D989357-60E3-4822-85CE-C0D5BF244CEE')
GO
--Toyota--
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Corolla', 'DC902AE7-C275-49CA-8642-38D0E6FE4554')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Etios', 'DC902AE7-C275-49CA-8642-38D0E6FE4554')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'SW4', 'DC902AE7-C275-49CA-8642-38D0E6FE4554')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'RAV4', 'DC902AE7-C275-49CA-8642-38D0E6FE4554')
GO
insert into MODELO(IdModelo, Descripcion, IdMarca) values (NEWID(), 'Hilux', 'DC902AE7-C275-49CA-8642-38D0E6FE4554')
GO



