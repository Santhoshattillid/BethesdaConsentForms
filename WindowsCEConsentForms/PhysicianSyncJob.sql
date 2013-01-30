declare @count int
declare @serverName varchar(255)
declare @domainName varchar(255)
declare @userName varchar(255)
declare @password varchar(255)

declare @physicianRecords CURSOR
declare @User_oid int
declare @groupName varchar(255)
declare @syncID int
declare @physicianName varchar(255)

set @serverName = '10.108.64.157'
set @count = 0
set @domainName = ''
set @userName = 'consent'
set @password = 'support1!'


SELECT @count = COUNT(*)  FROM master.sys.servers where name = @serverName

set @syncID = DAY(CURRENT_TIMESTAMP)

if @count = 0 
	
	Begin
	
		EXEC sp_addlinkedserver @serverName, N'SQL Server' 
	
		EXEC sp_addlinkedsrvlogin 
				@serverName, 
				'false', 
				@domainName,		
				@userName, 
				@password
	End
	
SET @physicianRecords = CURSOR FOR (select user_oid,GroupName,UserDescription from [soariandbtest].[dbo].[Physician])

open @physicianRecords

Fetch NEXT FROM @physicianRecords INTO @User_oid,@groupName,@physicianName

While @@FETCH_STATUS = 0

	BEGIN
	
	select @count = count(*) from Physician where Fname = @physicianName
	
		if @count = 0
		Begin
		
			insert into Physician values('False','True',8,@physicianName,@User_oid,0,@groupName,@syncID)	
			
		End
	
	Fetch NEXT FROM @physicianRecords INTO @User_oid,@groupName,@physicianName

	END

CLOSE @physicianRecords

DEALLOCATE @physicianRecords
