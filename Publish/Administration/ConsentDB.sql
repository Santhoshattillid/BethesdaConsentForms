USE [master]
GO
/****** Object:  Database [BethesdaCollege]    Script Date: 01/03/2013 09:06:26 ******/

ALTER DATABASE [BethesdaCollege] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BethesdaCollege].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BethesdaCollege] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [BethesdaCollege] SET ANSI_NULLS OFF
GO
ALTER DATABASE [BethesdaCollege] SET ANSI_PADDING OFF
GO
ALTER DATABASE [BethesdaCollege] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [BethesdaCollege] SET ARITHABORT OFF
GO
ALTER DATABASE [BethesdaCollege] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [BethesdaCollege] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [BethesdaCollege] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [BethesdaCollege] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [BethesdaCollege] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [BethesdaCollege] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [BethesdaCollege] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [BethesdaCollege] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [BethesdaCollege] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [BethesdaCollege] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [BethesdaCollege] SET  DISABLE_BROKER
GO
ALTER DATABASE [BethesdaCollege] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [BethesdaCollege] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [BethesdaCollege] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [BethesdaCollege] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [BethesdaCollege] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [BethesdaCollege] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [BethesdaCollege] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [BethesdaCollege] SET  READ_WRITE
GO
ALTER DATABASE [BethesdaCollege] SET RECOVERY SIMPLE
GO
ALTER DATABASE [BethesdaCollege] SET  MULTI_USER
GO
ALTER DATABASE [BethesdaCollege] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [BethesdaCollege] SET DB_CHAINING OFF
GO
USE [BethesdaCollege]
GO
/****** Object:  Table [dbo].[EmployeeInformation]    Script Date: 01/03/2013 09:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeInformation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmpID] [nchar](255) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 01/03/2013 09:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor_Procedures]    Script Date: 01/03/2013 09:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor_Procedures](
	[ProcID] [int] NOT NULL,
	[UniqueID] [int] NOT NULL,
	[PrimaryDoctorID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Treatment_Signature]    Script Date: 01/03/2013 09:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treatment_Signature](
	[SignatureId] [int] NOT NULL,
	[TContent] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[TSID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Treatment]    Script Date: 01/03/2013 09:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treatment](
	[PatentId] [int] NOT NULL,
	[ConsentType] [int] NOT NULL,
	[IsPatientunabletosign] [bit] NOT NULL,
	[Unabletosignreason] [nvarchar](max) NOT NULL,
	[TrackingID] [int] NOT NULL,
	[Signatures] [int] NOT NULL,
	[DoctorandProcedure] [int] NOT NULL,
	[TransaltedBy] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
	[IsStatementOfConsentAccepted] [bit] NOT NULL,
	[IsAutologousUnits] [bit] NOT NULL,
	[IsDirectedUnits] [bit] NOT NULL,
	[EmpID] [varchar] (255) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrackingInformation]    Script Date: 01/03/2013 09:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrackingInformation](
	[Device] [nvarchar](max) NOT NULL,
	[IP] [nvarchar](50) NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TrackingInformation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Signatures]    Script Date: 01/03/2013 09:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Signatures](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Signatures] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhysicianCategory]    Script Date: 01/03/2013 09:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhysicianCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PhysicianCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PDFExportPaths]    Script Date: 01/03/2013 09:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PDFExportPaths](
	[ConsentID] [int] NOT NULL,
	[Path] [nvarchar](max) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 01/03/2013 09:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patient](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[Fname] [varchar](256) NULL,
	[Lname] [varchar](256) NULL,
	[FullName] [varchar](512) NULL,
	[BirthDate] [datetime] NULL,
	[Age] [int] NULL,
	[Gender] [varchar](10) NULL,
	[MR#] [varchar](250) NULL,
	[PrimaryDoctor] [int] NULL,
	[AssociatedDoctor] [int] NULL,
	[AdmDate] [datetime] NULL,
	[Location] [nchar](10) NULL,
	[ConsentFormType] [nvarchar](max) NULL,
	[Patient#] [nchar](255) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ConsentType]    Script Date: 01/03/2013 09:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsentType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ConsentType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsentForm]    Script Date: 01/03/2013 09:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsentForm](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ConsentForm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CFSignatures]    Script Date: 01/03/2013 09:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFSignatures](
	[SID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CFOrder] [smallint] NOT NULL,
 CONSTRAINT [PK_CFSignatures] PRIMARY KEY CLUSTERED 
(
	[SID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CFProcedures]    Script Date: 01/03/2013 09:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFProcedures](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ConsentTypeID] [int] NOT NULL,
 CONSTRAINT [PK_CFProcedures] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddTreatment]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddTreatment]
@PatientID INT,
@ConsentTypeID INT,
@isPatientUnableSign INT,
@isStatementOfConsentAccepted INT,
@isAutologousUnits INT,
@isDirectedUnits INT,
@unableToSignReason varchar(MAX),
@trackingID INT,
@signaturesID INT,
@doctorsAndProceduresID INT,
@translatedBy varchar(MAX),
@empID varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
    insert into Treatment(PatentId,ConsentType,IsPatientunabletosign,IsStatementOfConsentAccepted,
                IsAutologousUnits,IsDirectedUnits,Unabletosignreason,TrackingID,
                Signatures,DoctorandProcedure,TransaltedBy,Date,EmpID)
    values(@PatientID , @ConsentTypeID , @isPatientUnableSign , @isStatementOfConsentAccepted ,
			@isAutologousUnits , @isDirectedUnits , @unableToSignReason , @trackingID , @signaturesID ,
			@doctorsAndProceduresID ,@translatedBy ,GETDATE(),@empID);
END
GO
/****** Object:  StoredProcedure [dbo].[AddProcedures]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddProcedures]
	@procedureName varchar(MAX),
	@consentTypeID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into CFProcedures(Name,ConsentTypeID) values(@procedureName,@consentTypeID)
END
GO
/****** Object:  StoredProcedure [dbo].[ListProcedures]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ListProcedures]
@Name NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;

    select CFProcedures.Name as CFName from CFProcedures,ConsentType 
    where CFProcedures.ConsentTypeID=ConsentType.ID AND ConsentType.Name =@Name
END
GO
/****** Object:  StoredProcedure [dbo].[GetTypeFromSignatures]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTypeFromSignatures]
@ID INT
AS
BEGIN
	SET NOCOUNT ON;

    SELECT [TYPE] FROM SIGNATURES WHERE ID=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetTreatment]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTreatment] 
@consentType varchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select PatentId,ConsentType,IsPatientunabletosign,IsStatementOfConsentAccepted,
			IsAutologousUnits, IsDirectedUnits,Unabletosignreason,TrackingID,Signatures,
            DoctorandProcedure,TransaltedBy, Date, EmpID from Treatment,ConsentType as CT
    where   PatentId=1 and ConsentType=CT.ID and CT.Name=@consentType and
			date=(select MAX(date) from Treatment,ConsentType as CT
                  where PatentId=1 and ConsentType=CT.ID and CT.Name=@consentType)
                                                                                        
END
GO
/****** Object:  StoredProcedure [dbo].[GetTrackingInformation]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTrackingInformation]
@Id INT
AS
BEGIN
	SET NOCOUNT ON;

    select Device,IP from TrackingInformation where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetSignaturesInformation]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSignaturesInformation]
@TSID INT
AS
BEGIN
	SET NOCOUNT ON;

    SELECT S.[Type] as SType,TCONTENT,NAME FROM TREATMENT_SIGNATURE as TS, Signatures as S
    
    WHERE TSID=@TSID and TS.SignatureId = S.ID
    
    
    
    
END
GO
/****** Object:  StoredProcedure [dbo].[GetProcIDFromDoctorProcedures]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetProcIDFromDoctorProcedures]
@UniqueId INT,
@PrimaryDoctorID INT
AS
BEGIN
	SET NOCOUNT ON;

    select ProcID from Doctor_Procedures where UniqueID=@UniqueId and PrimaryDoctorID=@PrimaryDoctorID
END
GO
/****** Object:  StoredProcedure [dbo].[GetProcedures]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetProcedures]
	@consentType varchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select CFProcedures.Name as CFName,CFProcedures.ID as ID from CFProcedures,ConsentType 
	where CFProcedures.ConsentTypeID=ConsentType.ID and ConsentType.Name=@consentType
	    
END
GO
/****** Object:  StoredProcedure [dbo].[GetPrimaryDoctorIDFromDoctorProcedures]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPrimaryDoctorIDFromDoctorProcedures]
@UniqueId INT
AS
BEGIN
	SET NOCOUNT ON;

    select PrimaryDoctorID from Doctor_Procedures where UniqueID=@UniqueId group by PrimaryDoctorID
END
GO
/****** Object:  StoredProcedure [dbo].[GetPdFFolderPath]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPdFFolderPath]
	@consentName varchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select PEP.[Path] as [Path] from PDFExportPaths as PEP,ConsentType as CT where PEP.ConsentID = CT.ID and CT.Name=@consentName
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetPatientSignature]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPatientSignature]
	@signatureType varchar(MAX),
	@patientID INT,
	@consentType varchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select TS.TContent from dbo.Treatment_Signature as TS,
             dbo.Signatures as S, dbo.Treatment as T, dbo.ConsentType as CT
	where S.[Type] = @signatureType and TS.SignatureId = S.ID and TS.TSID = T.Signatures
		and T.PatentId = @patientID and T.ConsentType = CT.ID and CT.Name = @consentType and 
		date=(select MAX(date) from Treatment,ConsentType as CT
                 where PatentId=@patientID and ConsentType=CT.ID and CT.Name=@consentType)
    
END
GO
/****** Object:  StoredProcedure [dbo].[GetPatientfromLocation]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPatientfromLocation]
@LOCATION NVARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT * FROM PATIENT WHERE LOCATION=@LOCATION
END
GO
/****** Object:  StoredProcedure [dbo].[GetMaxFromTrackingInformation]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMaxFromTrackingInformation]
AS
BEGIN
	SET NOCOUNT ON;

    select max(ID) as ID from TrackingInformation
END
GO
/****** Object:  Table [dbo].[Physician]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Physician](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Associated] [bit] NOT NULL,
	[Primary_Doctor] [bit] NOT NULL,
	[ConsentTypeID] [int] NOT NULL,
	[Fname] [nvarchar](max) NOT NULL,
	[Lname] [nvarchar](max) NOT NULL,
	[PCID] [int] NOT NULL,
	[GroupName] [nvarchar] (max) NOT NULL,
	SyncID [int] NOT NULL,
 CONSTRAINT [PK_Physician_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[CountOfEmpIdFromEmployeeInformation]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CountOfEmpIdFromEmployeeInformation]
@EmpID NCHAR(510)
AS
BEGIN
	SET NOCOUNT ON;

    select count(*) from EmployeeInformation where EmpID=@EmpID 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProcedureName]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateProcedureName]
	@procedureName varchar(MAX),
	@procedureID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Update CFProcedures set Name=@procedureName where ID=@procedureID
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetConsentTypes]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetConsentTypes]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Name as CFName,ID from ConsentType order by Name asc
END
GO
/****** Object:  StoredProcedure [dbo].[GetConsentTypeId]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetConsentTypeId]
@name NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;

    select ID from ConsentType where name=@name
END
GO
/****** Object:  StoredProcedure [dbo].[GetAssociatedDoctors]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAssociatedDoctors]
@PCID INT
AS
BEGIN
	SET NOCOUNT ON;
	select Physician.Fname as FName, Physician.Lname as LName from Physician 
		where Physician.GroupName in (select Physician.GroupName from Physician where ID=@PCID) 
			And Physician.ID != @PCID
END
GO
/****** Object:  StoredProcedure [dbo].[GetDoctorsProceduresInformation]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDoctorsProceduresInformation]
	@uniqueID as INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select CF.Name as ProcedureName,P.ID as ID from CFProcedures as CF, Doctor_Procedures as DP, Physician as P 
	where DP.UniqueID=@uniqueID and CF.ID=DP.ProcID and P.ID = DP.PrimaryDoctorID
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetDoctorDetails]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDoctorDetails]
AS
BEGIN
	SET NOCOUNT ON;
	select Physician.Fname as FName, Physician.Lname as LName,Physician.ID as ID from Physician 
END
GO
/****** Object:  StoredProcedure [dbo].[GetDoctorDetail]    Script Date: 01/03/2013 09:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDoctorDetail]
@ID INT
AS
BEGIN
	SET NOCOUNT ON;
    select Physician.Fname as FName, Physician.Lname as LName from Physician where Physician.ID=@ID
END
GO
/****** Object:  ForeignKey [FK_Physician_PhysicianCategory1]    Script Date: 01/03/2013 09:06:29 ******/
ALTER TABLE [dbo].[Physician]  WITH CHECK ADD  CONSTRAINT [FK_Physician_PhysicianCategory1] FOREIGN KEY([ConsentTypeID])
REFERENCES [dbo].[PhysicianCategory] ([ID])
GO
ALTER TABLE [dbo].[Physician] CHECK CONSTRAINT [FK_Physician_PhysicianCategory1]
GO
