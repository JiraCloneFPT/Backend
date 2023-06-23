USE [master]
GO
/****** Object:  Database [dbJiraClone]    Script Date: 23/6/2023 3:50:31 PM ******/
CREATE DATABASE [dbJiraClone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbJiraClone', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbJiraClone.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbJiraClone_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbJiraClone_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [dbJiraClone] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbJiraClone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbJiraClone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbJiraClone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbJiraClone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbJiraClone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbJiraClone] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbJiraClone] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbJiraClone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbJiraClone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbJiraClone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbJiraClone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbJiraClone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbJiraClone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbJiraClone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbJiraClone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbJiraClone] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbJiraClone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbJiraClone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbJiraClone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbJiraClone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbJiraClone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbJiraClone] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbJiraClone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbJiraClone] SET RECOVERY FULL 
GO
ALTER DATABASE [dbJiraClone] SET  MULTI_USER 
GO
ALTER DATABASE [dbJiraClone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbJiraClone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbJiraClone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbJiraClone] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbJiraClone] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbJiraClone] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbJiraClone', N'ON'
GO
ALTER DATABASE [dbJiraClone] SET QUERY_STORE = ON
GO
ALTER DATABASE [dbJiraClone] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [dbJiraClone]
GO
/****** Object:  Table [dbo].[CauseCategory]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauseCategory](
	[CauseCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CauseCategoryName] [varchar](55) NULL,
 CONSTRAINT [PK_CauseCategory] PRIMARY KEY CLUSTERED 
(
	[CauseCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[IssueId] [int] NULL,
	[CommentContent] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Component]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Component](
	[ComponentId] [int] IDENTITY(1,1) NOT NULL,
	[ComponentName] [nvarchar](255) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Component] PRIMARY KEY CLUSTERED 
(
	[ComponentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DefectOrigin]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefectOrigin](
	[DefectOriginId] [int] IDENTITY(1,1) NOT NULL,
	[DefectOriginName] [varchar](55) NULL,
 CONSTRAINT [PK_DefectOrigin] PRIMARY KEY CLUSTERED 
(
	[DefectOriginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DefectType]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefectType](
	[DefectTypeId] [int] IDENTITY(1,1) NOT NULL,
	[DefectTypeName] [varchar](55) NULL,
 CONSTRAINT [PK_DefectType] PRIMARY KEY CLUSTERED 
(
	[DefectTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FileAttachment]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileAttachment](
	[FileAttachmentId] [int] IDENTITY(1,1) NOT NULL,
	[IssueId] [int] NOT NULL,
	[FileName] [varchar](255) NULL,
	[FilePath] [varchar](max) NULL,
	[Created] [date] NULL,
	[FileSize] [int] NULL,
 CONSTRAINT [PK_FileAttachment] PRIMARY KEY CLUSTERED 
(
	[FileAttachmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[History]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[HistoryId] [int] IDENTITY(1,1) NOT NULL,
	[EditorId] [int] NOT NULL,
	[IssueId] [int] NULL,
	[ProjectId] [int] NULL,
	[IssueTypeId] [int] NULL,
	[ComponentId] [int] NULL,
	[ProductId] [int] NULL,
	[ReporterId] [int] NULL,
	[AssigneeId] [int] NULL,
	[Summary] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[DescriptionTranslate] [nvarchar](max) NULL,
	[FixVersion] [varchar](100) NULL,
	[DefectOriginId] [int] NULL,
	[PriorityId] [int] NULL,
	[Severity] [varchar](55) NULL,
	[QCActivityId] [int] NULL,
	[AffectsVersion] [varchar](100) NULL,
	[CauseAnalysis] [nvarchar](max) NULL,
	[CauseAnalysisTranslate] [nvarchar](max) NULL,
	[CorrectAction] [nvarchar](max) NULL,
	[CorrectActionTranslate] [nvarchar](max) NULL,
	[TechnicalCauseId] [int] NULL,
	[Environment] [nvarchar](max) NULL,
	[RoleIssueId] [int] NULL,
	[PlannedStart] [datetime] NULL,
	[OriginalEstimate] [varchar](55) NULL,
	[RemainingEstimate] [varchar](55) NULL,
	[EstimateEffort] [varchar](55) NULL,
	[Complexity] [int] NULL,
	[AdjustVP] [varchar](55) NULL,
	[ValuePoint] [varchar](55) NULL,
	[DueDate] [date] NULL,
	[Labels] [varchar](55) NULL,
	[Sprint] [varchar](55) NULL,
	[FunctionId] [varchar](55) NULL,
	[TestcaseId] [varchar](55) NULL,
	[FunctionCategory] [varchar](55) NULL,
	[Issue] [varchar](55) NULL,
	[EpicLink] [varchar](55) NULL,
	[ClosedDate] [date] NULL,
	[SecurityLevel] [varchar](55) NULL,
	[DefectTypeId] [int] NULL,
	[CauseCategoryId] [int] NULL,
	[LeakCauseId] [int] NULL,
	[DueTime] [varchar](55) NULL,
	[Units] [varchar](100) NULL,
	[PercentDone] [varchar](55) NULL,
	[StatusIssueId] [int] NULL,
	[Resolution] [varchar](255) NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[HistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Issue]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Issue](
	[IssueId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NULL,
	[IssueTypeId] [int] NULL,
	[ComponentId] [int] NULL,
	[ProductId] [int] NULL,
	[ReporterId] [int] NULL,
	[AssigneeId] [int] NULL,
	[Summary] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[DescriptionTranslate] [nvarchar](max) NULL,
	[FixVersion] [varchar](100) NULL,
	[DefectOriginId] [int] NULL,
	[PriorityId] [int] NULL,
	[Severity] [varchar](55) NULL,
	[QCActivityId] [int] NULL,
	[AffectsVersion] [varchar](100) NULL,
	[CauseAnalysis] [nvarchar](max) NULL,
	[CauseAnalysisTranslate] [nvarchar](max) NULL,
	[CorrectAction] [nvarchar](max) NULL,
	[CorrectActionTranslate] [nvarchar](max) NULL,
	[TechnicalCauseId] [int] NULL,
	[Environment] [nvarchar](max) NULL,
	[RoleIssueId] [int] NULL,
	[PlannedStart] [datetime] NULL,
	[OriginalEstimate] [varchar](55) NULL,
	[RemaningEstimate] [varchar](55) NULL,
	[EstimateEffort] [varchar](55) NULL,
	[Complexity] [int] NULL,
	[AdjustedVP] [varchar](55) NULL,
	[ValuePoint] [varchar](55) NULL,
	[DueDate] [date] NULL,
	[Labels] [varchar](55) NULL,
	[Sprint] [varchar](55) NULL,
	[FunctionId] [varchar](55) NULL,
	[TestcaseId] [varchar](55) NULL,
	[FunctionCategory] [varchar](55) NULL,
	[Issue] [varchar](55) NULL,
	[EpicLink] [varchar](55) NULL,
	[ClosedDate] [date] NULL,
	[SecurityLevel] [varchar](55) NULL,
	[DefectTypeId] [int] NULL,
	[CauseCategoryId] [int] NULL,
	[LeakCauseId] [int] NULL,
	[DueTime] [varchar](55) NULL,
	[Units] [varchar](100) NULL,
	[PercentDone] [varchar](55) NULL,
	[StatusIssueId] [int] NULL,
	[Resolution] [varchar](255) NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Issue] PRIMARY KEY CLUSTERED 
(
	[IssueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IssueType]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IssueType](
	[IssueTypeId] [int] IDENTITY(1,1) NOT NULL,
	[IssueTypeName] [nvarchar](255) NULL,
	[Status] [bit] NULL,
	[IssueTypeImage] [varchar](max) NULL,
 CONSTRAINT [PK_IssueType] PRIMARY KEY CLUSTERED 
(
	[IssueTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeakCause]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeakCause](
	[LeakCauseId] [int] IDENTITY(1,1) NOT NULL,
	[LeakCauseName] [varchar](55) NULL,
 CONSTRAINT [PK_LeakCause] PRIMARY KEY CLUSTERED 
(
	[LeakCauseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Priority]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Priority](
	[PriorityId] [int] IDENTITY(1,1) NOT NULL,
	[PriorityName] [varchar](55) NULL,
	[PriorityImage] [varchar](max) NULL,
 CONSTRAINT [PK_Priority] PRIMARY KEY CLUSTERED 
(
	[PriorityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](255) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](255) NULL,
	[ShortName] [varchar](100) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QCActivity]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QCActivity](
	[QCActivityId] [int] IDENTITY(1,1) NOT NULL,
	[QCActivityName] [varchar](55) NULL,
 CONSTRAINT [PK_QCActivity] PRIMARY KEY CLUSTERED 
(
	[QCActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resolution]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resolution](
	[ResolutionId] [int] IDENTITY(1,1) NOT NULL,
	[ResolutionContent] [varchar](100) NOT NULL,
	[StatusIssueId] [int] NOT NULL,
 CONSTRAINT [PK_Resolution] PRIMARY KEY CLUSTERED 
(
	[ResolutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleIssue]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleIssue](
	[RoleIssueId] [int] IDENTITY(1,1) NOT NULL,
	[RoleIssueName] [varchar](55) NULL,
 CONSTRAINT [PK_RoleIssue] PRIMARY KEY CLUSTERED 
(
	[RoleIssueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleUser]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleUser](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](55) NULL,
 CONSTRAINT [PK_RoleUser] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusIssue]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusIssue](
	[StatusIssueId] [int] IDENTITY(1,1) NOT NULL,
	[StatusIssueName] [varchar](55) NULL,
 CONSTRAINT [PK_StatusIssue] PRIMARY KEY CLUSTERED 
(
	[StatusIssueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TechnicalCause]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TechnicalCause](
	[TechnicalCauseId] [int] IDENTITY(1,1) NOT NULL,
	[TechnicalCauseName] [varchar](55) NULL,
 CONSTRAINT [PK_TechnicalCause] PRIMARY KEY CLUSTERED 
(
	[TechnicalCauseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 23/6/2023 3:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](255) NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](50) NULL,
	[Birthday] [date] NULL,
	[AccountName] [varchar](100) NULL,
	[Status] [varchar](10) NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CauseCategory] ON 

INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (1, N'None')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (2, N'CAR_Carelessness')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (3, N'COM_Missing communication')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (4, N'COM_Missing confirmation')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (5, N'DES_Detail design_Missing or incomplete')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (6, N'DES_Detail design_Mistake')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (7, N'DES_High level design_Missing or incomplete')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (8, N'DES_High level design_Mistake')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (9, N'DES_Missing or incomplete')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (10, N'DES_Mistake')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (11, N'EXT_External System interface')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (12, N'EXT_Thirdparty module')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (13, N'IMP_Discipline/process non-compliance')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (14, N'IMP_Insufficient analysis before implementation')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (15, N'IMP_Lack of understanding about system functions')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (16, N'IMP_Lack of understanding about system structure')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (17, N'IMP_Lack of configuration')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (18, N'PRO_Missing or incomplete')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (19, N'REQ_Missing or incomplete')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (20, N'REQ_Misunderstanding')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (21, N'REQ_Wrong')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (22, N'SKI_Inadequate language proficiency')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (23, N'SKI_Lack of professional skill')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (24, N'SKI_Shortage of business domain expertise')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (25, N'SKI_Shortage of technology expertise')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (26, N'ANA_Missing or incomplete')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (27, N'ANA_Misunderstanding')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (28, N'ANA_Wrong')
INSERT [dbo].[CauseCategory] ([CauseCategoryId], [CauseCategoryName]) VALUES (29, N'Other')
SET IDENTITY_INSERT [dbo].[CauseCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Component] ON 

INSERT [dbo].[Component] ([ComponentId], [ComponentName], [Status]) VALUES (1, N'DN23.FRF.V.WAT.01', 1)
INSERT [dbo].[Component] ([ComponentId], [ComponentName], [Status]) VALUES (2, N'DN23.FRF.V.WAT.02', 1)
INSERT [dbo].[Component] ([ComponentId], [ComponentName], [Status]) VALUES (3, N'DN23.FRF.V.WAT.03', 1)
INSERT [dbo].[Component] ([ComponentId], [ComponentName], [Status]) VALUES (4, N'DN23.FRF.V.WAT.04', 1)
SET IDENTITY_INSERT [dbo].[Component] OFF
GO
SET IDENTITY_INSERT [dbo].[DefectOrigin] ON 

INSERT [dbo].[DefectOrigin] ([DefectOriginId], [DefectOriginName]) VALUES (1, N'Requirement')
INSERT [dbo].[DefectOrigin] ([DefectOriginId], [DefectOriginName]) VALUES (2, N'Design')
INSERT [dbo].[DefectOrigin] ([DefectOriginId], [DefectOriginName]) VALUES (3, N'Coding')
INSERT [dbo].[DefectOrigin] ([DefectOriginId], [DefectOriginName]) VALUES (4, N'Test')
INSERT [dbo].[DefectOrigin] ([DefectOriginId], [DefectOriginName]) VALUES (5, N'Deployment')
INSERT [dbo].[DefectOrigin] ([DefectOriginId], [DefectOriginName]) VALUES (6, N'Customer support')
INSERT [dbo].[DefectOrigin] ([DefectOriginId], [DefectOriginName]) VALUES (7, N'Others')
SET IDENTITY_INSERT [dbo].[DefectOrigin] OFF
GO
SET IDENTITY_INSERT [dbo].[DefectType] ON 

INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (1, N'3D_Adjusting Creation')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (2, N'3D_Component''s Details')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (3, N'3D_Elevation''s Height')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (4, N'3D_Existing Constructions')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (5, N'3D_Fence')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (6, N'3D_Lightning')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (7, N'3D_Material Display')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (8, N'3D_Material Properties')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (9, N'3D_Others')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (10, N'CAD_Data Shape')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (11, N'CAD_Diagnostic')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (12, N'CAD_Dimen/Clearance')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (13, N'CAD_Drawing Note')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (14, N'CAD_History')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (15, N'CAD_Layout')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (16, N'CAD_Line Type')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (17, N'CAD_Other')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (18, N'CAD_Part Missing')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (19, N'CAD_View')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (20, N'CAE_Condition Analysis')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (21, N'CAE_Meshing Standard')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (22, N'CAE_Other')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (23, N'CAE_Processor')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (24, N'CAE_Propterty Material')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (25, N'CAE_Propterty Thickness')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (26, N'CAE_Shape Representation')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (27, N'CAE_Solver')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (28, N'Cod_BlackDuck_Liense Risk')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (29, N'Cod_BlackDuck_Operational Risk')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (30, N'Cod_BlackDuck_Security Risk')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (31, N'Cod_BlackDuck_Snippet')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (32, N'Cod_Coding Standard')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (33, N'Cod_Command')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (34, N'Cod_Compile')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (35, N'Cod_Coverity_Quality issue')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (36, N'Cod_Coverity_Securiry issue')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (37, N'Cod_Coverity_Test Advisor issue')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (38, N'Cod_Hard Code')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (39, N'Cod_Logic of Code')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (40, N'Cod_Name/Branch Place')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (41, N'Cod_Other')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (42, N'Cod_Redundancy Code')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (43, N'Cod_Register')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (44, N'Cod_Sonar_Bug')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (45, N'Cod_Sonar_Code Smell')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (46, N'Cod_Sonar_Vulnerability')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (47, N'CONS_Beam')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (48, N'CONS_Column')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (49, N'CONS_Docuwork')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (50, N'CONS_Foundation')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (51, N'CONS_Other')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (52, N'CONS_Roof')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (53, N'CONS_Setting Initiation')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (54, N'Des_Data Flow')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (55, N'Des_Domain Design')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (56, N'Des_Interface Between Modules')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (57, N'Des_Login Deployment From Function')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (58, N'Des_Table Design')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (59, N'Doc_Documentation')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (60, N'Doc_Format/Template')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (61, N'Doc_Grammar')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (62, N'Fun_Feature Missing')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (63, N'Fun_Incomplete Function')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (64, N'Fun_Wrong Business login')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (65, N'Other')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (66, N'UI_Label/Message')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (67, N'UI_Layout')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (68, N'UI_Postion/Size')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (69, N'Cod_Security Vulnerability')
INSERT [dbo].[DefectType] ([DefectTypeId], [DefectTypeName]) VALUES (70, N'Env_Cloud Infra Security Vulnerability')
SET IDENTITY_INSERT [dbo].[DefectType] OFF
GO
SET IDENTITY_INSERT [dbo].[History] ON 

INSERT [dbo].[History] ([HistoryId], [EditorId], [IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemainingEstimate], [EstimateEffort], [Complexity], [AdjustVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (1, 1, 1, 1, 1, 2, 2, 2, 2, N'Tempsoft', N'Other contact with nonvenomous lizards, initial encounter', NULL, NULL, 7, 6, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4, 19, 3, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:40:40.663' AS DateTime))
INSERT [dbo].[History] ([HistoryId], [EditorId], [IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemainingEstimate], [EstimateEffort], [Complexity], [AdjustVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (2, 2, 1, 2, 1, 1, 1, 2, 2, N'Tempsoft', N'Other contact with nonvenomous lizards, initial encounter', NULL, NULL, 7, 6, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4, 19, 3, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:40:40.667' AS DateTime))
INSERT [dbo].[History] ([HistoryId], [EditorId], [IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemainingEstimate], [EstimateEffort], [Complexity], [AdjustVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (3, 1, 1, 1, 2, 2, 2, 2, 2, N'Tempsoft', N'Other contact with nonvenomous lizards, initial encounter', NULL, NULL, 7, 6, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4, 19, 3, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:40:40.667' AS DateTime))
INSERT [dbo].[History] ([HistoryId], [EditorId], [IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemainingEstimate], [EstimateEffort], [Complexity], [AdjustVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (4, 1, 1, 2, 1, 3, 1, 2, 2, N'Tempsoft', N'Other contact with nonvenomous lizards, initial encounter', NULL, NULL, 7, 6, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4, 19, 3, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:40:40.667' AS DateTime))
SET IDENTITY_INSERT [dbo].[History] OFF
GO
SET IDENTITY_INSERT [dbo].[Issue] ON 

INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (1, 1, 1, 2, 2, 2, 2, N'Tempsoft', N'Other contact with nonvenomous lizards, initial encounter', NULL, NULL, 7, 6, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4, 19, 3, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.913' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (2, 3, 5, 1, 2, 1, 2, N'Holdlamis', N'Myocarditis, unspecified', NULL, NULL, 5, 7, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 13, 19, 1, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.913' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (3, 3, 4, 1, 2, 2, 2, N'Voltsillam', N'Monoarthritis, not elsewhere classified, left elbow', NULL, NULL, 5, 2, NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 42, 22, 9, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.913' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (4, 1, 3, 2, 1, 2, 2, N'Opela', N'Other specified disorders of arteries and arterioles', NULL, NULL, 3, 7, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 65, 10, 7, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.913' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (5, 1, 2, 3, 2, 1, 2, N'Solarbreeze', N'Superficial foreign body of left upper arm, init encntr', NULL, NULL, 7, 7, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 42, 27, 2, NULL, NULL, NULL, 3, NULL, CAST(N'2023-06-23T10:02:11.913' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (6, 3, 1, 2, 2, 1, 1, N'Bytecard', N'Slf-hrm by jumping or lying in front of moving object, init', NULL, NULL, 4, 1, NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, 24, 4, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.913' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (7, 3, 5, 3, 1, 2, 2, N'Redhold', N'Inj unsp musc/fasc/tend at thigh level, right thigh, sequela', NULL, NULL, 1, 1, NULL, 18, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 36, 11, 4, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.913' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (8, 3, 1, 1, 2, 2, 1, N'Gembucket', N'Expsr to industr wiring, appliances & electrical mach, subs', NULL, NULL, 1, 3, NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 17, 3, 2, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.913' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (9, 3, 3, 1, 1, 1, 2, N'Fintone', N'Oth fx upper end unsp tibia, subs for clos fx w delay heal', NULL, NULL, 6, 5, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 70, 19, 6, NULL, NULL, NULL, 6, NULL, CAST(N'2023-06-23T10:02:11.913' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (10, 3, 3, 3, 2, 2, 1, N'Flowdesk', N'Expsr to high air pressr from rapid descent in water, sqla', NULL, NULL, 1, 7, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 27, 16, 7, NULL, NULL, NULL, 6, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (11, 1, 4, 2, 2, 1, 1, N'Matsoft', N'Monocular exotropia, left eye', NULL, NULL, 4, 8, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 53, 6, 1, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (12, 2, 1, 3, 2, 1, 1, N'Trippledex', N'Maternal care for anti-D antibodies, third tri, fetus 5', NULL, NULL, 3, 1, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 55, 24, 4, NULL, NULL, NULL, 3, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (13, 2, 3, 3, 2, 2, 2, N'Pannier', N'Other dislocation of left radial head, initial encounter', NULL, NULL, 3, 4, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 63, 13, 6, NULL, NULL, NULL, 4, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (14, 1, 4, 2, 1, 1, 2, N'Konklab', N'Abrasion of scalp, initial encounter', NULL, NULL, 7, 5, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 18, 1, 3, NULL, NULL, NULL, 6, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (15, 1, 3, 2, 1, 2, 1, N'Sonsing', N'Occup of 3-whl mv injured in clsn w ped/anml in traf, subs', NULL, NULL, 4, 6, NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 48, 10, 2, NULL, NULL, NULL, 4, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (16, 2, 4, 3, 1, 2, 1, N'Transcof', N'Cardiomyopathy, unspecified', NULL, NULL, 5, 8, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 26, 4, 9, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (17, 1, 5, 2, 2, 2, 2, N'Voyatouch', N'Unspecified trochanteric fracture of right femur, sequela', NULL, NULL, 3, 5, NULL, 15, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 28, 13, 6, NULL, NULL, NULL, 3, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (18, 1, 1, 1, 1, 2, 1, N'Flowdesk', N'Worries', NULL, NULL, 2, 7, NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 43, 11, 7, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (19, 2, 5, 2, 1, 1, 1, N'Quo Lux', N'Other displaced fracture of fifth cervical vertebra', NULL, NULL, 1, 7, NULL, 17, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 26, 6, 8, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (20, 3, 1, 1, 2, 2, 1, N'Viva', N'Pedl cyc driver inj pk-up truck, pk-up/van nontraf, sequela', NULL, NULL, 6, 1, NULL, 15, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 27, 27, 6, NULL, NULL, NULL, 4, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (21, 3, 5, 1, 2, 2, 2, N'Konklab', N'Oth fracture of third lumbar vertebra, init for opn fx', NULL, NULL, 4, 4, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 20, 12, 3, NULL, NULL, NULL, 3, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (22, 1, 1, 3, 2, 2, 1, N'Stim', N'Pressure ulcer of unspecified site, unstageable', NULL, NULL, 4, 2, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 53, 18, 9, NULL, NULL, NULL, 3, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (23, 2, 1, 1, 2, 2, 1, N'Toughjoyfax', N'Nondisp fx of cuboid bone of left foot, init for clos fx', NULL, NULL, 6, 5, NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 55, 16, 3, NULL, NULL, NULL, 6, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (24, 3, 5, 2, 1, 1, 2, N'Fixflex', N'Chronic conjunctivitis', NULL, NULL, 5, 1, NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 67, 14, 4, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (25, 3, 1, 2, 2, 2, 2, N'Aerified', N'Sprain of joints and ligaments of oth parts of head, sequela', NULL, NULL, 6, 7, NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 66, 13, 2, NULL, NULL, NULL, 3, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (26, 3, 2, 3, 2, 2, 2, N'Cookley', N'Fracture of unspecified tarsal bone(s) of right foot', NULL, NULL, 3, 4, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 19, 21, 7, NULL, NULL, NULL, 3, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (27, 2, 1, 3, 2, 2, 2, N'Job', N'Unspecified fracture of sixth cervical vertebra', NULL, NULL, 3, 2, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 67, 11, 6, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (28, 2, 3, 1, 2, 1, 2, N'Stringtough', N'Displaced fracture of left tibial spine, sequela', NULL, NULL, 4, 4, NULL, 18, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 15, 21, 6, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.917' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (29, 3, 3, 2, 1, 2, 1, N'Prodder', N'Other superficial bite of breast', NULL, NULL, 3, 4, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 55, 3, 8, NULL, NULL, NULL, 3, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (30, 1, 2, 1, 1, 1, 1, N'Fix San', N'Encounter for exam of eyes and vision w abnormal findings', NULL, NULL, 5, 7, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 14, 11, 1, NULL, NULL, NULL, 3, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (31, 3, 3, 2, 2, 2, 2, N'Bamity', N'Nondisp spiral fx shaft of l fibula, 7thB', NULL, NULL, 6, 8, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 9, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (32, 1, 4, 1, 1, 1, 1, N'Bigtax', N'Lacerat abd wall w fb, unsp q w/o penet perit cav, subs', NULL, NULL, 5, 4, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 23, 23, 4, NULL, NULL, NULL, 4, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (33, 2, 2, 1, 1, 2, 1, N'Tin', N'Other specified diabetes mellitus without complications', NULL, NULL, 5, 2, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 39, 15, 5, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (34, 3, 4, 2, 2, 1, 2, N'Mat Lam Tam', N'Nondisp fx of 2nd metatarsal bone, l ft, 7thD', NULL, NULL, 1, 8, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 17, 4, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (35, 3, 5, 3, 1, 2, 1, N'Opela', N'Other specified arthritis, right hand', NULL, NULL, 1, 5, NULL, 18, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 45, 15, 9, NULL, NULL, NULL, 4, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (36, 1, 1, 3, 2, 2, 2, N'Fix San', N'War op w chem weapons and oth unconvtl warfare, civ, sequela', NULL, NULL, 2, 3, NULL, 13, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, 7, 2, NULL, NULL, NULL, 6, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (37, 2, 4, 2, 1, 2, 2, N'Lotstring', N'War op w thermal radn effect of nuclear weapon, milt, init', NULL, NULL, 2, 2, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 57, 10, 8, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (38, 3, 3, 3, 2, 1, 2, N'Quo Lux', N'Nondisp bicondylar fx unsp tibia, 7thD', NULL, NULL, 5, 3, NULL, 18, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 47, 9, 1, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (39, 1, 4, 3, 2, 1, 1, N'Quo Lux', N'Foreign body in vulva and vagina, initial encounter', NULL, NULL, 5, 1, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4, 2, 5, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (40, 1, 1, 2, 1, 1, 1, N'Tin', N'Poisn by analeptics and opioid receptor antag, slf-hrm, subs', NULL, NULL, 3, 8, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 26, 10, 2, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (41, 3, 4, 2, 1, 1, 2, N'Matsoft', N'Displaced transverse fracture of shaft of unsp radius, init', NULL, NULL, 4, 3, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, 12, 5, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (42, 3, 1, 2, 2, 2, 2, N'Bytecard', N'Recurrent dislocation, right foot', NULL, NULL, 5, 7, NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12, 19, 6, NULL, NULL, NULL, 4, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (43, 1, 4, 2, 1, 2, 2, N'Gembucket', N'Benign neoplasm of kidney', NULL, NULL, 3, 2, NULL, 18, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 47, 3, 3, NULL, NULL, NULL, 6, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (44, 1, 2, 1, 2, 2, 1, N'Asoka', N'Squamous cell carcinoma of skin of breast', NULL, NULL, 4, 5, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 27, 11, 3, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (45, 1, 4, 2, 2, 1, 2, N'Treeflex', N'Filariasis due to Brugia malayi', NULL, NULL, 4, 2, NULL, 15, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 31, 13, 1, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.920' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (46, 3, 2, 1, 2, 2, 2, N'Keylex', N'Partial traumatic amputation of penis', NULL, NULL, 1, 2, NULL, 13, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, 10, 1, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (47, 1, 5, 3, 1, 2, 2, N'Regrant', N'Obst due to fb acc left in body fol kidney dialysis, sequela', NULL, NULL, 1, 5, NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 69, 17, 3, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (48, 1, 1, 2, 1, 1, 1, N'Namfix', N'Disp fx of base of fifth metacarpal bone. left hand, sequela', NULL, NULL, 5, 6, NULL, 17, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 13, 18, 3, NULL, NULL, NULL, 4, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (49, 1, 5, 3, 1, 1, 2, N'Rank', N'Major depressive disorder, recurrent, mild', NULL, NULL, 4, 5, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 28, 2, 2, NULL, NULL, NULL, 3, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (50, 3, 4, 2, 1, 1, 2, N'Zontrax', N'Unstable burst fracture of first cervical vertebra, init', NULL, NULL, 2, 7, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 30, 1, 5, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (51, 2, 3, 3, 2, 1, 1, N'Bitwolf', N'Other anomalies of dental arch relationship', NULL, NULL, 5, 2, NULL, 18, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 70, 6, 8, NULL, NULL, NULL, 4, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (52, 1, 1, 2, 1, 1, 1, N'Bitchip', N'Toxic effects of zinc and its compounds', NULL, NULL, 1, 5, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 26, 19, 4, NULL, NULL, NULL, 6, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (53, 3, 4, 1, 1, 1, 1, N'Aerified', N'Malignant melanoma of unsp ear and external auricular canal', NULL, NULL, 6, 1, NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 27, 24, 7, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (54, 2, 3, 1, 2, 1, 1, N'Konklux', N'Injury of cutaneous sensory nerve at forearm level', NULL, NULL, 2, 5, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 61, 9, 5, NULL, NULL, NULL, 3, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (55, 3, 4, 1, 1, 1, 1, N'It', N'Other cyst of bone, left thigh', NULL, NULL, 6, 6, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 66, 6, 8, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (56, 1, 4, 2, 2, 2, 1, N'Bytecard', N'Blister (nonthermal) of penis, initial encounter', NULL, NULL, 4, 4, NULL, 18, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 35, 7, 6, NULL, NULL, NULL, 6, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (57, 2, 4, 3, 1, 2, 2, N'Duobam', N'Oth acc to commrcl fix-wing aircraft injuring occupant, subs', NULL, NULL, 1, 3, NULL, 11, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 15, 12, 3, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (58, 1, 4, 3, 1, 1, 1, N'Domainer', N'Arthropathy following intestinal bypass, right wrist', NULL, NULL, 6, 8, NULL, 16, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 47, 26, 6, NULL, NULL, NULL, 6, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (59, 3, 5, 2, 1, 1, 2, N'Fixflex', N'Rheumatoid polyneurop w rheumatoid arthritis of right wrist', NULL, NULL, 1, 6, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 19, 26, 6, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (60, 3, 1, 3, 2, 2, 1, N'Cookley', N'Toxic effect of venom of N & S American snake, accidental', NULL, NULL, 5, 4, NULL, 16, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 26, 8, 1, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (61, 3, 4, 3, 1, 1, 2, N'Vagram', N'Abscess of breast assoc w pregnancy, the puerp and lactation', NULL, NULL, 3, 4, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 25, 11, 6, NULL, NULL, NULL, 6, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (62, 3, 4, 2, 2, 1, 1, N'Trippledex', N'Chronic migraine without aura', NULL, NULL, 4, 5, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 57, 25, 4, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (63, 3, 3, 3, 2, 1, 2, N'Alpha', N'Opioid use, unspecified with other opioid-induced disorder', NULL, NULL, 2, 4, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 70, 16, 9, NULL, NULL, NULL, 4, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (64, 1, 2, 1, 1, 2, 1, N'Bitwolf', N'Nondisp fx of prox third of navic bone of r wrist, sequela', NULL, NULL, 7, 5, NULL, 11, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 22, 15, 5, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (65, 1, 3, 2, 1, 1, 2, N'Tres-Zap', N'Displaced avulsion fracture of left ischium, init for opn fx', NULL, NULL, 3, 5, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 40, 28, 9, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (66, 3, 4, 3, 1, 1, 2, N'Home Ing', N'Sltr-haris Type II physl fx upper end rad, right arm, init', NULL, NULL, 4, 1, NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 22, 26, 6, NULL, NULL, NULL, 3, NULL, CAST(N'2023-06-23T10:02:11.923' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (67, 3, 1, 2, 1, 1, 2, N'It', N'Psychodysleptics', NULL, NULL, 2, 1, NULL, 17, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 26, 26, 2, NULL, NULL, NULL, 4, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (68, 3, 5, 1, 2, 2, 2, N'Namfix', N'Disp fx of neck of fifth MC bone, right hand, sequela', NULL, NULL, 7, 4, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 27, 20, 8, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (69, 1, 3, 1, 1, 1, 1, N'Fix San', N'Juvenile osteochondrosis of patella', NULL, NULL, 7, 7, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, 25, 8, NULL, NULL, NULL, 4, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (70, 3, 3, 1, 2, 2, 2, N'Rank', N'Stress fracture, unspecified hand', NULL, NULL, 4, 5, NULL, 17, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 26, 22, 1, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (71, 1, 3, 2, 2, 1, 1, N'Treeflex', N'LeFort III fracture, initial encounter for open fracture', NULL, NULL, 1, 4, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 31, 18, 4, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (72, 1, 5, 2, 1, 2, 2, N'Temp', N'Prsn brd/alit pedl cyc injured in collision w statnry object', NULL, NULL, 2, 7, NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 39, 16, 3, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (73, 3, 4, 2, 2, 1, 2, N'Veribet', N'Immersion foot, unspecified foot, subsequent encounter', NULL, NULL, 2, 5, NULL, 13, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 43, 15, 7, NULL, NULL, NULL, 6, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (74, 3, 4, 3, 2, 1, 2, N'Lotstring', N'Cauliflower ear', NULL, NULL, 2, 6, NULL, 11, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 39, 8, 4, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (75, 1, 3, 1, 2, 2, 2, N'Ventosanzap', N'Meconium aspiration without respiratory symptoms', NULL, NULL, 3, 6, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 25, 17, 9, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (76, 3, 1, 3, 2, 1, 2, N'Temp', N'Unsp inj extn musc/fasc/tend l lit fngr at wrs/hnd lv, init', NULL, NULL, 2, 8, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 64, 19, 4, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (77, 1, 4, 1, 2, 1, 1, N'Sub-Ex', N'Drown due to falling or jumping from crushed unsp watercraft', NULL, NULL, 3, 2, NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 67, 18, 3, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (78, 3, 5, 2, 2, 1, 2, N'Stim', N'Inj unsp musc/fasc/tend at shldr/up arm, unsp arm, subs', NULL, NULL, 4, 5, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, 20, 3, NULL, NULL, NULL, 6, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (79, 3, 1, 1, 2, 2, 2, N'Cardguard', N'Contact w powered woodworking and forming machines, sequela', NULL, NULL, 6, 2, NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 66, 27, 3, NULL, NULL, NULL, 4, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (80, 2, 1, 3, 2, 1, 1, N'Zathin', N'Displ transverse fx shaft of l tibia, 7thB', NULL, NULL, 7, 4, NULL, 16, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 60, 16, 4, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (81, 3, 2, 2, 1, 1, 1, N'Sonsing', N'Maternal care for intrauterine death', NULL, NULL, 5, 1, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 8, 7, NULL, NULL, NULL, 3, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (82, 1, 2, 2, 2, 2, 2, N'It', N'Nontraumatic extradural hemorrhage', NULL, NULL, 1, 5, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 18, 11, 6, NULL, NULL, NULL, 4, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (83, 2, 1, 2, 1, 2, 2, N'Prodder', N'Chagas'' disease (chronic) with digestive system involvement', NULL, NULL, 2, 3, NULL, 18, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 49, 10, 6, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (84, 1, 2, 2, 1, 2, 1, N'Quo Lux', N'War operations involving unsp dest arcrft, milt', NULL, NULL, 1, 8, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 44, 27, 2, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (85, 2, 2, 2, 2, 2, 2, N'Fixflex', N'Rheu heart disease w rheumatoid arthritis of left ank/ft', NULL, NULL, 3, 1, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 52, 3, 9, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (86, 2, 5, 1, 2, 2, 2, N'Latlux', N'Unsp injury of branches of celiac and mesent art, init', NULL, NULL, 2, 8, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6, 24, 1, NULL, NULL, NULL, 3, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (87, 1, 3, 2, 1, 1, 1, N'Cardguard', N'Causalgia of upper limb', NULL, NULL, 1, 7, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 7, 9, NULL, NULL, NULL, 6, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (88, 1, 5, 3, 1, 1, 1, N'Viva', N'Strain of musc/tend anterior grp at low leg level, unsp leg', NULL, NULL, 2, 2, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 33, 4, 4, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (89, 1, 5, 3, 2, 2, 2, N'Job', N'Abrasion of left ring finger, sequela', NULL, NULL, 3, 1, NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 68, 15, 3, NULL, NULL, NULL, 4, NULL, CAST(N'2023-06-23T10:02:11.927' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (90, 3, 2, 1, 2, 2, 2, N'Gembucket', N'External constriction of left index finger, subs encntr', NULL, NULL, 6, 2, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 67, 29, 5, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.930' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (91, 1, 1, 1, 1, 1, 2, N'Wrapsafe', N'Other specified bursopathies', NULL, NULL, 2, 5, NULL, 15, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 9, 6, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.930' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (92, 3, 4, 2, 2, 2, 2, N'Bigtax', N'Synovial hypertrophy, NEC, multiple sites', NULL, NULL, 5, 1, NULL, 18, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 32, 17, 3, NULL, NULL, NULL, 1, NULL, CAST(N'2023-06-23T10:02:11.930' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (93, 2, 5, 1, 2, 2, 1, N'Tres-Zap', N'Congenital infectious or parasitic disease, unspecified', NULL, NULL, 5, 5, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 67, 4, 6, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.930' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (94, 1, 2, 1, 1, 2, 2, N'Voltsillam', N'Inj msl/tnd lng flexor muscle of toe at ank/ft level, r foot', NULL, NULL, 7, 8, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 38, 5, 2, NULL, NULL, NULL, 3, NULL, CAST(N'2023-06-23T10:02:11.930' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (95, 1, 2, 3, 2, 2, 1, N'Vagram', N'Encounter for attention to artificial openings', NULL, NULL, 6, 7, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 11, 14, 6, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.930' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (96, 1, 2, 1, 1, 1, 1, N'Zamit', N'Aphonia', NULL, NULL, 7, 1, NULL, 11, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 46, 27, 5, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.930' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (97, 1, 5, 3, 1, 1, 2, N'Span', N'Primary blast injury of thoracic trachea, initial encounter', NULL, NULL, 3, 7, NULL, 11, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 55, 24, 7, NULL, NULL, NULL, 6, NULL, CAST(N'2023-06-23T10:02:11.930' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (98, 1, 4, 1, 1, 2, 1, N'Kanlam', N'Bent bone of right ulna, subs for opn fx type I/2 w nonunion', NULL, NULL, 1, 2, NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 17, 29, 1, NULL, NULL, NULL, 6, NULL, CAST(N'2023-06-23T10:02:11.930' AS DateTime))
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (99, 2, 3, 3, 1, 1, 1, N'Namfix', N'Unsp fracture of right ischium, init for opn fx', NULL, NULL, 5, 8, NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 25, 5, 1, NULL, NULL, NULL, 2, NULL, CAST(N'2023-06-23T10:02:11.930' AS DateTime))
GO
INSERT [dbo].[Issue] ([IssueId], [ProjectId], [IssueTypeId], [ComponentId], [ProductId], [ReporterId], [AssigneeId], [Summary], [Description], [DescriptionTranslate], [FixVersion], [DefectOriginId], [PriorityId], [Severity], [QCActivityId], [AffectsVersion], [CauseAnalysis], [CauseAnalysisTranslate], [CorrectAction], [CorrectActionTranslate], [TechnicalCauseId], [Environment], [RoleIssueId], [PlannedStart], [OriginalEstimate], [RemaningEstimate], [EstimateEffort], [Complexity], [AdjustedVP], [ValuePoint], [DueDate], [Labels], [Sprint], [FunctionId], [TestcaseId], [FunctionCategory], [Issue], [EpicLink], [ClosedDate], [SecurityLevel], [DefectTypeId], [CauseCategoryId], [LeakCauseId], [DueTime], [Units], [PercentDone], [StatusIssueId], [Resolution], [CreateTime]) VALUES (1000, 1, 4, 2, 1, 2, 2, N'Lotstring', N'Disp fx of unsp tibial tuberosity, 7thQ', NULL, NULL, 7, 4, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 24, 2, 1, NULL, NULL, NULL, 5, NULL, CAST(N'2023-06-23T10:02:11.930' AS DateTime))
SET IDENTITY_INSERT [dbo].[Issue] OFF
GO
SET IDENTITY_INSERT [dbo].[IssueType] ON 

INSERT [dbo].[IssueType] ([IssueTypeId], [IssueTypeName], [Status], [IssueTypeImage]) VALUES (1, N'Bug', 1, N'https://res.cloudinary.com/dfb1bpw8c/image/upload/v1686642284/bug_l4fcuq.svg')
INSERT [dbo].[IssueType] ([IssueTypeId], [IssueTypeName], [Status], [IssueTypeImage]) VALUES (2, N'Task', 1, N'https://res.cloudinary.com/dfb1bpw8c/image/upload/v1686642284/task_xv8wmr.svg')
INSERT [dbo].[IssueType] ([IssueTypeId], [IssueTypeName], [Status], [IssueTypeImage]) VALUES (3, N'Improvement', 1, N'https://res.cloudinary.com/dfb1bpw8c/image/upload/v1686642284/improve_dwbhkk.svg')
INSERT [dbo].[IssueType] ([IssueTypeId], [IssueTypeName], [Status], [IssueTypeImage]) VALUES (4, N'Lesson/Practice', 1, N'https://res.cloudinary.com/dfb1bpw8c/image/upload/v1686642284/improve_dwbhkk.svg')
INSERT [dbo].[IssueType] ([IssueTypeId], [IssueTypeName], [Status], [IssueTypeImage]) VALUES (5, N'Q&A', 1, N'https://res.cloudinary.com/dfb1bpw8c/image/upload/v1686642285/q_a_goxwe5.png')
SET IDENTITY_INSERT [dbo].[IssueType] OFF
GO
SET IDENTITY_INSERT [dbo].[LeakCause] ON 

INSERT [dbo].[LeakCause] ([LeakCauseId], [LeakCauseName]) VALUES (1, N'Rev_Lack of review view point / check list')
INSERT [dbo].[LeakCause] ([LeakCauseId], [LeakCauseName]) VALUES (2, N'Rev_Lack of Review')
INSERT [dbo].[LeakCause] ([LeakCauseId], [LeakCauseName]) VALUES (3, N'Rev_Lack of business logic understanding')
INSERT [dbo].[LeakCause] ([LeakCauseId], [LeakCauseName]) VALUES (4, N'Rev_Lack of Skill')
INSERT [dbo].[LeakCause] ([LeakCauseId], [LeakCauseName]) VALUES (5, N'Test_Lack of test view point')
INSERT [dbo].[LeakCause] ([LeakCauseId], [LeakCauseName]) VALUES (6, N'Test Lack of Test case')
INSERT [dbo].[LeakCause] ([LeakCauseId], [LeakCauseName]) VALUES (7, N'Test Lack of Regression Test')
INSERT [dbo].[LeakCause] ([LeakCauseId], [LeakCauseName]) VALUES (8, N'Test Lack of business Login understanding')
INSERT [dbo].[LeakCause] ([LeakCauseId], [LeakCauseName]) VALUES (9, N'Test Lack of Test skill')
SET IDENTITY_INSERT [dbo].[LeakCause] OFF
GO
SET IDENTITY_INSERT [dbo].[Priority] ON 

INSERT [dbo].[Priority] ([PriorityId], [PriorityName], [PriorityImage]) VALUES (1, N'Minor', N'https://res.cloudinary.com/dfb1bpw8c/raw/upload/v1686642285/minor_lnrfea.svg_xml')
INSERT [dbo].[Priority] ([PriorityId], [PriorityName], [PriorityImage]) VALUES (2, N'Blocker', N'[2:46 CH] Huynh Thi Bao Khuyen (FA.G0.DN.C)

https://res.cloudinary.com/dfb1bpw8c/raw/upload/v1686642284/blocker_aa658u.svg_xml')
INSERT [dbo].[Priority] ([PriorityId], [PriorityName], [PriorityImage]) VALUES (3, N'Critical', N'https://res.cloudinary.com/dfb1bpw8c/raw/upload/v1686642284/critical_nrh1ii.svg_xml')
INSERT [dbo].[Priority] ([PriorityId], [PriorityName], [PriorityImage]) VALUES (4, N'Major', N'[2:46 CH] Huynh Thi Bao Khuyen (FA.G0.DN.C)

https://res.cloudinary.com/dfb1bpw8c/raw/upload/v1686642285/major_ksywlh.svg_xml')
INSERT [dbo].[Priority] ([PriorityId], [PriorityName], [PriorityImage]) VALUES (5, N'Trivial', N'https://res.cloudinary.com/dfb1bpw8c/raw/upload/v1686642285/trivial_y5ls6z.svg_xml')
INSERT [dbo].[Priority] ([PriorityId], [PriorityName], [PriorityImage]) VALUES (6, N'High', N'https://res.cloudinary.com/dfb1bpw8c/image/upload/v1686646806/priority_major_ssv22i.gif')
INSERT [dbo].[Priority] ([PriorityId], [PriorityName], [PriorityImage]) VALUES (7, N'Low', N'https://res.cloudinary.com/dfb1bpw8c/image/upload/v1686646806/priority_major_ssv22i.gif')
INSERT [dbo].[Priority] ([PriorityId], [PriorityName], [PriorityImage]) VALUES (8, N'Medium', N'https://res.cloudinary.com/dfb1bpw8c/image/upload/v1686646806/priority_major_ssv22i.gif')
SET IDENTITY_INSERT [dbo].[Priority] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [ProductName], [Status]) VALUES (1, N'Fsolf Academy Product', 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([ProjectId], [ProjectName], [ShortName], [Status]) VALUES (1, N'Fsoft Academy Training Course', N'FSOFTACADEMY', 1)
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [ShortName], [Status]) VALUES (2, N'IP Process', N'IPPROCESS', 1)
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [ShortName], [Status]) VALUES (3, N'Project Assessment 2023', N'PRJASS2023', 1)
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
SET IDENTITY_INSERT [dbo].[QCActivity] ON 

INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (1, N'None')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (2, N'Acceptance Review')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (3, N'Acceptance Test')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (4, N'CI/CD Code Scan')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (5, N'Code Review')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (6, N'Document Review')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (7, N'Final Inspection')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (8, N'Integration Test')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (9, N'Integration Test Inspection')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (10, N'Other Inspection')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (11, N'Other Review')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (12, N'Other Test')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (13, N'Systen Test')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (14, N'Unit Test Inspection')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (15, N'Unit Test')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (16, N'TQA Review')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (17, N'SSA Security Assessment')
INSERT [dbo].[QCActivity] ([QCActivityId], [QCActivityName]) VALUES (18, N'Funcional Test')
SET IDENTITY_INSERT [dbo].[QCActivity] OFF
GO
SET IDENTITY_INSERT [dbo].[Resolution] ON 

INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (1, N'Accepted', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (3, N'Avoid', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (4, N'ByDesign', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (6, N'Cancelled', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (7, N'Cannot Reproduce', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (8, N'Control', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (9, N'Defer', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (10, N'Done', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (11, N'Duplicated', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (12, N'External', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (13, N'Fixed', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (14, N'Incomplete', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (15, N'Limitation', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (16, N'Not Bug', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (17, N'Occurred', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (18, N'Spec', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (19, N'Transfer', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (20, N'Won''t Fix', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (21, N'Won''t Do', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (22, N'Rejected', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (23, N'Duplicate', 3)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (24, N'Accepted', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (25, N'Avoid', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (26, N'ByDesign', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (27, N'Cancelled', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (28, N'Cannot Reproduce', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (29, N'Control', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (30, N'Defer', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (31, N'Done', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (32, N'Duplicated', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (33, N'External', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (34, N'Fixed', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (35, N'Incomplete', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (36, N'Limitation', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (37, N'Not Bug', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (38, N'Occurred', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (39, N'Spec', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (40, N'Transfer', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (41, N'Won''t Fix', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (42, N'Won''t Do', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (43, N'Rejected', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (44, N'Duplicate', 6)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (45, N'Cannot Reproduce', 4)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (46, N'Fixed', 4)
INSERT [dbo].[Resolution] ([ResolutionId], [ResolutionContent], [StatusIssueId]) VALUES (47, N'Won''t Fix', 4)
SET IDENTITY_INSERT [dbo].[Resolution] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleIssue] ON 

INSERT [dbo].[RoleIssue] ([RoleIssueId], [RoleIssueName]) VALUES (1, N'None')
INSERT [dbo].[RoleIssue] ([RoleIssueId], [RoleIssueName]) VALUES (2, N'QA')
INSERT [dbo].[RoleIssue] ([RoleIssueId], [RoleIssueName]) VALUES (3, N'Tester')
INSERT [dbo].[RoleIssue] ([RoleIssueId], [RoleIssueName]) VALUES (4, N'Developer')
INSERT [dbo].[RoleIssue] ([RoleIssueId], [RoleIssueName]) VALUES (5, N'Designer')
INSERT [dbo].[RoleIssue] ([RoleIssueId], [RoleIssueName]) VALUES (6, N'Customer')
INSERT [dbo].[RoleIssue] ([RoleIssueId], [RoleIssueName]) VALUES (7, N'BA')
INSERT [dbo].[RoleIssue] ([RoleIssueId], [RoleIssueName]) VALUES (8, N'PM')
INSERT [dbo].[RoleIssue] ([RoleIssueId], [RoleIssueName]) VALUES (9, N'Team Leader')
INSERT [dbo].[RoleIssue] ([RoleIssueId], [RoleIssueName]) VALUES (10, N'Comter')
SET IDENTITY_INSERT [dbo].[RoleIssue] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleUser] ON 

INSERT [dbo].[RoleUser] ([RoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[RoleUser] ([RoleId], [RoleName]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[RoleUser] OFF
GO
SET IDENTITY_INSERT [dbo].[StatusIssue] ON 

INSERT [dbo].[StatusIssue] ([StatusIssueId], [StatusIssueName]) VALUES (1, N'Open')
INSERT [dbo].[StatusIssue] ([StatusIssueId], [StatusIssueName]) VALUES (2, N'In progress')
INSERT [dbo].[StatusIssue] ([StatusIssueId], [StatusIssueName]) VALUES (3, N'Resolved')
INSERT [dbo].[StatusIssue] ([StatusIssueId], [StatusIssueName]) VALUES (4, N'Cancelled')
INSERT [dbo].[StatusIssue] ([StatusIssueId], [StatusIssueName]) VALUES (5, N'Reopened')
INSERT [dbo].[StatusIssue] ([StatusIssueId], [StatusIssueName]) VALUES (6, N'Closed')
SET IDENTITY_INSERT [dbo].[StatusIssue] OFF
GO
SET IDENTITY_INSERT [dbo].[TechnicalCause] ON 

INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (1, N'510_WrongDefinition')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (2, N'511_InitializationError')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (3, N'512_PointerProcessingDefect')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (4, N'513_EventProcessingDefect')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (5, N'514_RedundantCoding')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (6, N'515_ErrorInVariableAttribute')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (7, N'516_SetWrongProperties')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (8, N'517_ReferToWrongReference')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (9, N'518_SetWrongParameter')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (10, N'519_UseWrongCommonModule')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (11, N'520_SetWrongDBItem')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (12, N'521_EditProcessingDefect')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (13, N'522_ProcessingMissing')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (14, N'523_SpecsDefect')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (15, N'524_TestEnviromentDeficiency')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (16, N'525_TestDataDeficiency')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (17, N'526_PlatformDefect')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (18, N'527_EviromentalDataError')
INSERT [dbo].[TechnicalCause] ([TechnicalCauseId], [TechnicalCauseName]) VALUES (19, N'528_LackOfMemoryFree')
SET IDENTITY_INSERT [dbo].[TechnicalCause] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [FullName], [Email], [Password], [Birthday], [AccountName], [Status], [RoleId]) VALUES (1, N'Võ Minh Hiếu', N'vmhsky@gmail.com', N'12345', CAST(N'2001-05-04' AS Date), N'HieuVM15', N'1', 2)
INSERT [dbo].[User] ([UserId], [FullName], [Email], [Password], [Birthday], [AccountName], [Status], [RoleId]) VALUES (2, N'Tuan', NULL, N'12345', NULL, N'Tuan', N'1', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[History] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Issue] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Issue] FOREIGN KEY([IssueId])
REFERENCES [dbo].[Issue] ([IssueId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Issue]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_User]
GO
ALTER TABLE [dbo].[FileAttachment]  WITH CHECK ADD  CONSTRAINT [FK_FileAttachment_Issue] FOREIGN KEY([IssueId])
REFERENCES [dbo].[Issue] ([IssueId])
GO
ALTER TABLE [dbo].[FileAttachment] CHECK CONSTRAINT [FK_FileAttachment_Issue]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_CauseCategory] FOREIGN KEY([CauseCategoryId])
REFERENCES [dbo].[CauseCategory] ([CauseCategoryId])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_CauseCategory]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_Component] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Component] ([ComponentId])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_Component]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_DefectOrigin] FOREIGN KEY([DefectOriginId])
REFERENCES [dbo].[DefectOrigin] ([DefectOriginId])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_DefectOrigin]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_DefectType] FOREIGN KEY([DefectTypeId])
REFERENCES [dbo].[DefectType] ([DefectTypeId])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_DefectType]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_IssueType] FOREIGN KEY([IssueTypeId])
REFERENCES [dbo].[IssueType] ([IssueTypeId])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_IssueType]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_LeakCause] FOREIGN KEY([LeakCauseId])
REFERENCES [dbo].[LeakCause] ([LeakCauseId])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_LeakCause]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_Priority] FOREIGN KEY([PriorityId])
REFERENCES [dbo].[Priority] ([PriorityId])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_Priority]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_Project]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_QCActivity] FOREIGN KEY([QCActivityId])
REFERENCES [dbo].[QCActivity] ([QCActivityId])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_QCActivity]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_RoleIssue] FOREIGN KEY([RoleIssueId])
REFERENCES [dbo].[RoleIssue] ([RoleIssueId])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_RoleIssue]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_StatusIssue] FOREIGN KEY([StatusIssueId])
REFERENCES [dbo].[StatusIssue] ([StatusIssueId])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_StatusIssue]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_TechnicalCause] FOREIGN KEY([TechnicalCauseId])
REFERENCES [dbo].[TechnicalCause] ([TechnicalCauseId])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_TechnicalCause]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_User] FOREIGN KEY([ReporterId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_User]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_User1] FOREIGN KEY([AssigneeId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_User1]
GO
ALTER TABLE [dbo].[Resolution]  WITH CHECK ADD  CONSTRAINT [FK_Resolution_StatusIssue] FOREIGN KEY([StatusIssueId])
REFERENCES [dbo].[StatusIssue] ([StatusIssueId])
GO
ALTER TABLE [dbo].[Resolution] CHECK CONSTRAINT [FK_Resolution_StatusIssue]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_RoleUser] FOREIGN KEY([RoleId])
REFERENCES [dbo].[RoleUser] ([RoleId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_RoleUser]
GO
USE [master]
GO
ALTER DATABASE [dbJiraClone] SET  READ_WRITE 
GO
