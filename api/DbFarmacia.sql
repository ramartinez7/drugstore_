USE [master]
GO
/****** Object:  Database [farmacia]    Script Date: 29/04/2024 2:15:33 p. m. ******/
CREATE DATABASE [farmacia]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'farmacia', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\farmacia.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'farmacia_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\farmacia_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [farmacia] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [farmacia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [farmacia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [farmacia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [farmacia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [farmacia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [farmacia] SET ARITHABORT OFF 
GO
ALTER DATABASE [farmacia] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [farmacia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [farmacia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [farmacia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [farmacia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [farmacia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [farmacia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [farmacia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [farmacia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [farmacia] SET  ENABLE_BROKER 
GO
ALTER DATABASE [farmacia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [farmacia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [farmacia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [farmacia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [farmacia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [farmacia] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [farmacia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [farmacia] SET RECOVERY FULL 
GO
ALTER DATABASE [farmacia] SET  MULTI_USER 
GO
ALTER DATABASE [farmacia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [farmacia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [farmacia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [farmacia] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [farmacia] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [farmacia] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [farmacia] SET QUERY_STORE = ON
GO
ALTER DATABASE [farmacia] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [farmacia]
GO
/****** Object:  Table [dbo].[administracion]    Script Date: 29/04/2024 2:15:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[administracion](
	[administracion_id] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[administracion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 29/04/2024 2:15:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[categoria_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[categoria_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[concentracion]    Script Date: 29/04/2024 2:15:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[concentracion](
	[concentracion_id] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[concentracion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[medicamento]    Script Date: 29/04/2024 2:15:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[medicamento](
	[medicamento_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](25) NOT NULL,
	[activo] [bit] NOT NULL,
	[descripcion] [varchar](200) NULL,
	[presentacion_id] [int] NOT NULL,
	[concentracion_id] [int] NOT NULL,
	[administracion_id] [int] NOT NULL,
	[categoria_id] [int] NOT NULL,
 CONSTRAINT [PK__medicame__BBBBB8CA9C30AF12] PRIMARY KEY CLUSTERED 
(
	[medicamento_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[medicamento_ubicacion]    Script Date: 29/04/2024 2:15:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[medicamento_ubicacion](
	[medicamento_ubicacion_id] [int] IDENTITY(1,1) NOT NULL,
	[medicamento_id] [int] NOT NULL,
	[ubicacion_id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[presentacion]    Script Date: 29/04/2024 2:15:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[presentacion](
	[presentacion_id] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[presentacion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ubicacion]    Script Date: 29/04/2024 2:15:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ubicacion](
	[ubicacion_id] [int] IDENTITY(1,1) NOT NULL,
	[estante] [int] NOT NULL,
	[casilla] [int] NOT NULL,
	[caja] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ubicacion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[administracion] ON 

INSERT [dbo].[administracion] ([administracion_id], [tipo]) VALUES (1, N'Oral')
INSERT [dbo].[administracion] ([administracion_id], [tipo]) VALUES (2, N'Intravenosa')
INSERT [dbo].[administracion] ([administracion_id], [tipo]) VALUES (3, N'Tópico')
SET IDENTITY_INSERT [dbo].[administracion] OFF
GO
SET IDENTITY_INSERT [dbo].[categoria] ON 

INSERT [dbo].[categoria] ([categoria_id], [nombre]) VALUES (1, N'Analgésicos')
INSERT [dbo].[categoria] ([categoria_id], [nombre]) VALUES (2, N'Antibióticos')
INSERT [dbo].[categoria] ([categoria_id], [nombre]) VALUES (3, N'Antiinflamatorio')
SET IDENTITY_INSERT [dbo].[categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[concentracion] ON 

INSERT [dbo].[concentracion] ([concentracion_id], [tipo]) VALUES (1, N'50mg')
INSERT [dbo].[concentracion] ([concentracion_id], [tipo]) VALUES (2, N'100mg')
INSERT [dbo].[concentracion] ([concentracion_id], [tipo]) VALUES (3, N'150mg')
SET IDENTITY_INSERT [dbo].[concentracion] OFF
GO
SET IDENTITY_INSERT [dbo].[medicamento] ON 

INSERT [dbo].[medicamento] ([medicamento_id], [nombre], [activo], [descripcion], [presentacion_id], [concentracion_id], [administracion_id], [categoria_id]) VALUES (1, N'Paracetamol', 1, N'Se usa para tratar diversas dolencias como fiebre, dolor de cabeza, dolores musculares, artritis, dolor de espalda o resfriados.', 1, 1, 1, 1)
INSERT [dbo].[medicamento] ([medicamento_id], [nombre], [activo], [descripcion], [presentacion_id], [concentracion_id], [administracion_id], [categoria_id]) VALUES (2, N'Omeprazol', 1, N'Para la acidez de estómago o tratamiento de los síntomas por reflujo gastroesofáfico, este efecto también previene las úlceras.', 2, 2, 2, 2)
INSERT [dbo].[medicamento] ([medicamento_id], [nombre], [activo], [descripcion], [presentacion_id], [concentracion_id], [administracion_id], [categoria_id]) VALUES (3, N'Naproxeno', 1, N'Se utiliza para el tratamiento del dolor, de la inflamación, para bajar la fiebre y la migraña incluídos los dolores de menstruación. ', 3, 3, 3, 3)
SET IDENTITY_INSERT [dbo].[medicamento] OFF
GO
SET IDENTITY_INSERT [dbo].[medicamento_ubicacion] ON 

INSERT [dbo].[medicamento_ubicacion] ([medicamento_ubicacion_id], [medicamento_id], [ubicacion_id]) VALUES (1, 1, 1)
INSERT [dbo].[medicamento_ubicacion] ([medicamento_ubicacion_id], [medicamento_id], [ubicacion_id]) VALUES (2, 2, 2)
INSERT [dbo].[medicamento_ubicacion] ([medicamento_ubicacion_id], [medicamento_id], [ubicacion_id]) VALUES (3, 3, 3)
SET IDENTITY_INSERT [dbo].[medicamento_ubicacion] OFF
GO
SET IDENTITY_INSERT [dbo].[presentacion] ON 

INSERT [dbo].[presentacion] ([presentacion_id], [tipo]) VALUES (1, N'Tableta')
INSERT [dbo].[presentacion] ([presentacion_id], [tipo]) VALUES (2, N'Líquida')
INSERT [dbo].[presentacion] ([presentacion_id], [tipo]) VALUES (3, N'Polvo')
SET IDENTITY_INSERT [dbo].[presentacion] OFF
GO
SET IDENTITY_INSERT [dbo].[ubicacion] ON 

INSERT [dbo].[ubicacion] ([ubicacion_id], [estante], [casilla], [caja]) VALUES (1, 1, 1, 1)
INSERT [dbo].[ubicacion] ([ubicacion_id], [estante], [casilla], [caja]) VALUES (2, 1, 2, 2)
INSERT [dbo].[ubicacion] ([ubicacion_id], [estante], [casilla], [caja]) VALUES (3, 1, 3, 3)
SET IDENTITY_INSERT [dbo].[ubicacion] OFF
GO
/****** Object:  Index [UQ__administ__1B41E81988011BC7]    Script Date: 29/04/2024 2:15:34 p. m. ******/
ALTER TABLE [dbo].[administracion] ADD UNIQUE NONCLUSTERED 
(
	[administracion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__categori__DB875A4EE7B8AC3E]    Script Date: 29/04/2024 2:15:34 p. m. ******/
ALTER TABLE [dbo].[categoria] ADD UNIQUE NONCLUSTERED 
(
	[categoria_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__concentr__758525F122F97EAC]    Script Date: 29/04/2024 2:15:34 p. m. ******/
ALTER TABLE [dbo].[concentracion] ADD UNIQUE NONCLUSTERED 
(
	[concentracion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__medicame__BBBBB8CBB3B33CB6]    Script Date: 29/04/2024 2:15:34 p. m. ******/
ALTER TABLE [dbo].[medicamento] ADD  CONSTRAINT [UQ__medicame__BBBBB8CBB3B33CB6] UNIQUE NONCLUSTERED 
(
	[medicamento_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__presenta__040BBA9963003408]    Script Date: 29/04/2024 2:15:34 p. m. ******/
ALTER TABLE [dbo].[presentacion] ADD UNIQUE NONCLUSTERED 
(
	[presentacion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__ubicacio__129843858B966AEE]    Script Date: 29/04/2024 2:15:34 p. m. ******/
ALTER TABLE [dbo].[ubicacion] ADD UNIQUE NONCLUSTERED 
(
	[estante] ASC,
	[casilla] ASC,
	[caja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[medicamento]  WITH CHECK ADD  CONSTRAINT [FK__medicamen__admin__440B1D61] FOREIGN KEY([administracion_id])
REFERENCES [dbo].[administracion] ([administracion_id])
GO
ALTER TABLE [dbo].[medicamento] CHECK CONSTRAINT [FK__medicamen__admin__440B1D61]
GO
ALTER TABLE [dbo].[medicamento]  WITH CHECK ADD  CONSTRAINT [FK__medicamen__categ__47DBAE45] FOREIGN KEY([categoria_id])
REFERENCES [dbo].[categoria] ([categoria_id])
GO
ALTER TABLE [dbo].[medicamento] CHECK CONSTRAINT [FK__medicamen__categ__47DBAE45]
GO
ALTER TABLE [dbo].[medicamento]  WITH CHECK ADD  CONSTRAINT [FK__medicamen__conce__4316F928] FOREIGN KEY([concentracion_id])
REFERENCES [dbo].[concentracion] ([concentracion_id])
GO
ALTER TABLE [dbo].[medicamento] CHECK CONSTRAINT [FK__medicamen__conce__4316F928]
GO
ALTER TABLE [dbo].[medicamento]  WITH CHECK ADD  CONSTRAINT [FK__medicamen__prese__4222D4EF] FOREIGN KEY([presentacion_id])
REFERENCES [dbo].[presentacion] ([presentacion_id])
GO
ALTER TABLE [dbo].[medicamento] CHECK CONSTRAINT [FK__medicamen__prese__4222D4EF]
GO
ALTER TABLE [dbo].[medicamento_ubicacion]  WITH CHECK ADD  CONSTRAINT [FK__medicamen__medic__4CA06362] FOREIGN KEY([medicamento_id])
REFERENCES [dbo].[medicamento] ([medicamento_id])
GO
ALTER TABLE [dbo].[medicamento_ubicacion] CHECK CONSTRAINT [FK__medicamen__medic__4CA06362]
GO
ALTER TABLE [dbo].[medicamento_ubicacion]  WITH CHECK ADD  CONSTRAINT [FK__medicamen__ubica__4CA06362] FOREIGN KEY([ubicacion_id])
REFERENCES [dbo].[ubicacion] ([ubicacion_id])
GO
ALTER TABLE [dbo].[medicamento_ubicacion] CHECK CONSTRAINT [FK__medicamen__ubica__4CA06362]
GO
USE [master]
GO
ALTER DATABASE [farmacia] SET  READ_WRITE 
GO
