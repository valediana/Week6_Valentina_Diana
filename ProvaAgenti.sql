USE [master]
GO
/****** Object:  Database [ProvaAgenti]    Script Date: 12/11/2021 14:39:09 ******/
CREATE DATABASE [ProvaAgenti]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProvaAgenti', FILENAME = N'C:\Users\valem\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\ProvaAgenti.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProvaAgenti_log', FILENAME = N'C:\Users\valem\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\ProvaAgenti.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ProvaAgenti] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProvaAgenti].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProvaAgenti] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [ProvaAgenti] SET ANSI_NULLS ON 
GO
ALTER DATABASE [ProvaAgenti] SET ANSI_PADDING ON 
GO
ALTER DATABASE [ProvaAgenti] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [ProvaAgenti] SET ARITHABORT ON 
GO
ALTER DATABASE [ProvaAgenti] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProvaAgenti] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProvaAgenti] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProvaAgenti] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProvaAgenti] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [ProvaAgenti] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [ProvaAgenti] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProvaAgenti] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [ProvaAgenti] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProvaAgenti] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProvaAgenti] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProvaAgenti] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProvaAgenti] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProvaAgenti] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProvaAgenti] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProvaAgenti] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProvaAgenti] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProvaAgenti] SET RECOVERY FULL 
GO
ALTER DATABASE [ProvaAgenti] SET  MULTI_USER 
GO
ALTER DATABASE [ProvaAgenti] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProvaAgenti] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProvaAgenti] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProvaAgenti] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProvaAgenti] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProvaAgenti] SET QUERY_STORE = OFF
GO
USE [ProvaAgenti]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [ProvaAgenti]
GO
/****** Object:  Table [dbo].[Agente]    Script Date: 12/11/2021 14:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agente](
	[Nome] [nvarchar](50) NOT NULL,
	[Cognome] [nvarchar](50) NOT NULL,
	[CodiceFiscale] [nchar](10) NOT NULL,
	[AreaGeografica] [nvarchar](50) NOT NULL,
	[AnnoInizio] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodiceFiscale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Agente] ([Nome], [Cognome], [CodiceFiscale], [AreaGeografica], [AnnoInizio]) VALUES (N'Caterina', N'Bianchi', N'CTRBNC85SS', N'Cagliari Sud', 1997)
INSERT [dbo].[Agente] ([Nome], [Cognome], [CodiceFiscale], [AreaGeografica], [AnnoInizio]) VALUES (N'Luca', N'Aru', N'LCAUA921CA', N'Cagliari Est', 2002)
INSERT [dbo].[Agente] ([Nome], [Cognome], [CodiceFiscale], [AreaGeografica], [AnnoInizio]) VALUES (N'Luisa', N'Piras', N'LSIPRS90CT', N'Cagliari Nord', 2000)
INSERT [dbo].[Agente] ([Nome], [Cognome], [CodiceFiscale], [AreaGeografica], [AnnoInizio]) VALUES (N'Marco', N'Rossi', N'MRCRSS87OP', N'Cagliari Sud', 1998)
INSERT [dbo].[Agente] ([Nome], [Cognome], [CodiceFiscale], [AreaGeografica], [AnnoInizio]) VALUES (N'Valeria', N'Monti', N'OPPUIN87IO', N'Cagliari Ovest', 1999)
INSERT [dbo].[Agente] ([Nome], [Cognome], [CodiceFiscale], [AreaGeografica], [AnnoInizio]) VALUES (N'Giovanni', N'Ponti', N'YUHJ80RTFG', N'Cagliari Est', 1999)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Agente__86E1BBF70A487855]    Script Date: 12/11/2021 14:39:09 ******/
ALTER TABLE [dbo].[Agente] ADD UNIQUE NONCLUSTERED 
(
	[CodiceFiscale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ProvaAgenti] SET  READ_WRITE 
GO
