
-- drop table log 

CREATE TABLE [dbo].[Log](
	[ID] [int] IDENTITY(1,1) NOT NULL primary key,
	[CreatedDate] [datetime] NOT NULL,
	[User] [varchar](50) NULL,
	[LogType] [char](1) not null,
	[MethodName] [varchar](200) not NULL,
	[Description] [varchar](max) NULL,
	)

	--Log Type
	--	E
	--	S

	CREATE PROCEDURE CreateLog
	@CreatedDate datetime,
	@User varchar(50),
	@LogType char(1),
	@MethodName varchar(200),
	@Description varchar(max)
AS

	insert into log values(@CreatedDate,@User,@LogType,@MethodName,@Description)
	
--CreateLog '2013-02-01 12:16:52.490','test','E','test','test'	

select GETDATE()


	select * from log 

	Select * from INFORMATION_SCHEMA.ROUTINES