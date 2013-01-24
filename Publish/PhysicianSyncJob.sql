

declare @count int
declare @serverName varchar(255)
declare @domainName varchar(255)
declare @userName varchar(255)
declare @password varchar(255)
declare @physicianRecords CURSOR
declare @User_oid int

set @serverName = '192.168.1.158'
set @count = 0
set @domainName = ''
set @userName = 'sa'
set @password = 'sa@123'


SELECT @count = COUNT(*)  FROM master.sys.servers where name = @serverName

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
	
SET @physicianRecords = CURSOR FOR (select user_oid from [BethesdaTest].[dbo].[Physician])

open @physicianRecords

Fetch NEXT FROM @physicianRecords INTO @User_oid

While @@FETCH_STATUS = 0

	BEGIN
	
	--select @count = count(*) from 
	

	Fetch NEXT FROM @physicianRecords INTO @User_oid

	END

CLOSE @physicianRecords

DEALLOCATE @physicianRecords
