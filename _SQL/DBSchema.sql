--Force all connections closed.
use master
go

alter database ContentManagement set single_user with rollback immediate
go

use master
go

--Drop the database so we can re-create it.
drop database ContentManagement
go

create database ContentManagement
go

use ContentManagement
go

create table dbo.ContentType(
	Id int identity(1,1) not null,
	Name varchar(50) not null,
	constraint PK_ContentType primary key(Id)
)
go	

create table dbo.ContentSubType(
	Id int identity(1,1) not null,
	Name varchar(50) not null,
	constraint PK_ContentSubType primary key(Id)
)
go

create table dbo.ContentSource(
	Id int identity(1,1) not null,
	Name varchar(50) not null,
	constraint PK_ContentSource primary key(Id)
)
go

create table dbo.Content(
	Id int identity(1,1) not null,
	Name varchar(100) not null,
	CreateDateTime datetime2(7) not null,
	ContentTypeId int not null,
	ContentSubTypeId int not null,
	constraint PK_Content primary key(Id),
	constraint FK_Content_ContentType foreign key(ContentTypeId) references dbo.ContentType(Id),
	constraint FK_Content_ContentSubType foreign key(ContentSubTypeId) references dbo.ContentSubType(Id)
)
go

create table dbo.ContentCollection(
	Id int identity(1,1) not null,
	ContentId int not null,
	ContentOwnerId int not null,
	constraint PK_ContentCollection primary key(Id),
	constraint FK_ContentCollection_Content foreign key(ContentId) references dbo.Content(Id),
	constraint FK_ContentCollection_Owner foreign key(ContentOwnerId) references dbo.Content(Id)
)
go

create table dbo.SecurityType(
	Id int identity(1,1) not null,
	Name varchar(50) not null,
	constraint PK_SecurityType primary key(Id)
)
go

create table dbo.ContentSecurity(
	Id int identity(1,1) not null,
	ContentId int not null,
	ContentControllerId int not null,
	SecurityTypeId int not null,
	constraint PK_ContentSecurity primary key(Id),
	constraint FK_ContentSecurity_Content foreign key(ContentId) references dbo.Content(Id),
	constraint FK_ContentSecurity_ContentConroller foreign key(ContentControllerId) references dbo.Content(Id),
	constraint FK_ContentSecurity_SecurityType foreign key(SecurityTypeId) references dbo.SecurityType(Id)
)
go

create table dbo.ContentPublication(
	Id int identity(1,1) not null,
	ContentId int not null,
	ContentSourceId int not null,
	PublicationDateTime datetime2(7) null,
	CreateDateTime datetime2(7) not null,
	Published bit not null,
	Deleted bit not null,
	constraint PK_ContentPublication primary key(Id),
	constraint FK_ContentPublication_Content foreign key(ContentId) references dbo.Content(Id),
	constraint FK_ContentPublication_ContentSourceId foreign key(ContentSourceId) references dbo.ContentSource(Id)
)
go

create table dbo.TextFragment(
	Id int identity(1,1) not null,
	ContentPublicationId int not null,
	Context varchar(1000) not null,
	constraint PK_TextFragment primary key(Id),
	constraint FK_TextFragment_ContentPublication foreign key(ContentPublicationId) references dbo.ContentPublication
)
go

create table dbo.ContentMedata(
	Id int identity(1,1) not null,
	ContentPublicationId int not null,
	[Key] varchar(50) not null,
	[Value] varchar(500) null,
	constraint PK_ContentMedata primary key (Id),
	constraint FK_ContentMedata_ContentPublication foreign key(ContentPublicationId) references dbo.ContentPublication(Id)
)
go

--Wire Framing
insert into dbo.ContentSource(Name)
values ('File System'), ('Database'), ('DLL'), ('Remote URL')

insert into dbo.ContentType(Name)
values ('User'), ('User Group'), ('Users Collection'), ('User Groups Collection'), ('Content Collection'), ('Page'), ('Place Holder'), ('Navigation Structure')
go

insert into dbo.ContentSubType(Name)
values ('Text'), ('Binary Data'), ('XML'), ('HTML'), ('Generic')
go

insert into dbo.SecurityType(Name)
values ('None'), ('Read'), ('Write'), ('Create'), ('Delete'), ('Full')
go

declare @GenericSubTypeId int = (select top(1) Id from dbo.ContentSubType where Name = 'Generic');

declare @FullPermissionId int = (select top(1) Id from dbo.SecurityType where Name = 'Full');
declare @ReadPermissionId int = (select top(1) Id from dbo.SecurityType where Name = 'Read');

declare @DatabaseSourceId int = (select top(1) Id from dbo.ContentSource where Name = 'Database');

declare @ContentCollectionTypeId int = (select top(1) Id from dbo.ContentType where Name = 'Content Collection');
declare @UserGroupsCollectionTypeId int = (select top(1) Id from dbo.ContentType where Name = 'User Groups Collection');
declare @UsersCollectionTypeId int = (select top(1) Id from dbo.ContentType where Name = 'Users Collection');
declare @UserTypeId int = (select top(1) Id from dbo.ContentType where Name = 'User');
declare @UserGroupTypeId int = (select top(1) Id from dbo.ContentType where Name = 'User Group');

insert into dbo.Content(Name, ContentTypeId, ContentSubTypeId, CreateDateTime)
values ('User Groups', @UserGroupsCollectionTypeId, @GenericSubTypeId, GETDATE()),
	('Sys Admins', @UserGroupTypeId, @GenericSubTypeId, GETDATE()),
	('General Users', @UserGroupTypeId, @GenericSubTypeId, GETDATE()),
	('Users', @UsersCollectionTypeId, @GenericSubTypeId, GETDATE()),
	('System', @UserTypeId, @GenericSubTypeId, GETDATE()),
	('Main Collection', @ContentCollectionTypeId, @GenericSubTypeId, GETDATE()),
	('Anonymous User', @UserTypeId, @GenericSubTypeId, GETDATE()),
	('Content Collection', @ContentCollectionTypeId, @GenericSubTypeId, GETDATE())

declare @ContentCollectionId int = (select top(1) Id from dbo.Content where Name = 'Content Collection');
declare @MainCollectionId int = (select top(1) Id from dbo.Content where Name = 'Main Collection');
declare @UserGroupsId int = (select top(1) Id from dbo.Content where Name = 'User Groups');
declare @UsersId int = (select top(1) Id from dbo.Content where Name = 'Users');
declare @SysAdminsId int = (select top(1) Id from dbo.Content where Name = 'Sys Admins');
declare @GeneralUsersGroupId int = (select top(1) Id from dbo.Content where Name = 'General Users');
declare @SystemId int = (select top(1) Id from dbo.Content where Name = 'System');
declare @AnonymousUserId int = (select top(1) Id from dbo.Content where Name = 'Anonymous User');

insert into dbo.ContentCollection(ContentId, ContentOwnerId)
values (@ContentCollectionId, @MainCollectionId),
	(@UserGroupsId, @MainCollectionId),
	(@UsersId, @MainCollectionId),
	(@SysAdminsId, @UserGroupsId),
	(@GeneralUsersGroupId, @UserGroupsId),
	(@SystemId, @UsersId),
	(@SystemId, @SysAdminsId),
	(@AnonymousUserId, @UsersId),
	(@AnonymousUserId, @GeneralUsersGroupId)

insert into dbo.ContentSecurity(ContentId, ContentControllerId, SecurityTypeId)
values (@MainCollectionId, @SysAdminsId, @FullPermissionId),
	(@ContentCollectionId, @GeneralUsersGroupId, @ReadPermissionId)

insert into dbo.ContentPublication(ContentId, ContentSourceId, PublicationDateTime, CreateDateTime, Published, Deleted)
values (@ContentCollectionId, @DatabaseSourceId, GETDATE(), GETDATE(), 1, 0),
	(@MainCollectionId, @DatabaseSourceId, GETDATE(), GETDATE(), 1, 0),
	(@UserGroupsId, @DatabaseSourceId, GETDATE(), GETDATE(), 1, 0),
	(@UsersId, @DatabaseSourceId, GETDATE(), GETDATE(), 1, 0),
	(@SysAdminsId, @DatabaseSourceId, GETDATE(), GETDATE(), 1, 0),
	(@GeneralUsersGroupId, @DatabaseSourceId, GETDATE(), GETDATE(), 1, 0),
	(@SystemId, @DatabaseSourceId, GETDATE(), GETDATE(), 1, 0),
	(@AnonymousUserId, @DatabaseSourceId, GETDATE(), GETDATE(), 1, 0)

----View Creation
--create view dbo.vw_PublishedContent
--as

--select ct.*
--from dbo.Content ct
--	join dbo.ContentMetadata mt
--		on ct.MetadataId = mt.Id
--where mt.[Enabled] = 1
--	and mt.Published = 1

--go

--create table dbo.Player(
--	PlayerId int identity(1,1) primary key not null,
--	PlayerName varchar(50) not null,
--	unique(PlayerName)
--)
--go

--create table dbo.Match(
--	MatchId int identity(1,1) primary key not null,
--	CreateDate datetime2(7) not null,
--	WonDate datetime2(7) null,
--	EndDate datetime2(7) null,
--	StateDate datetime2(7) not null,
--	NumberOfRounds int not null,
--	PlayerOneId int foreign key references dbo.Player not null,
--	PlayerOneAccepted bit null,
--	PlayerTwoId int foreign key references dbo.Player not null,
--	PlayerTwoAccepted bit null,
--	WinningPlayerId int foreign key references dbo.Player null,
--	constraint CK_Match_TwoPlayers check(PlayerOneId <> PlayerTwoId),
--	constraint CK_Match_WinnerPlaying check(WinningPlayerId is null
--										or WinningPlayerId = PlayerOneId
--										or WinningPlayerId = PlayerTwoId),
--)
--go

--create table dbo.ConfigSection(
--	SectionId int identity(1,1) primary key not null,
--	MatchId int foreign key references dbo.Match not null,
--	Section varchar(500) not null
--)
--go

--create table dbo.AuditLog(
--	LogId int identity(1,1) primary key not null,
--	LogType varchar(50) not null,
--	LogDateTime datetime2(7) not null,
--	Metadata varchar(250) null
--)
--go

--create table dbo.AuditLogSection(
--	SectionId int identity(1,1) primary key not null,
--	AuditLogId int foreign key references dbo.AuditLog not null,
--	Section varchar(500) not null
--)
--go

--create table dbo.Game(
--	GameId int identity(1,1) primary key not null,
--	MatchId int foreign key references dbo.Match not null,
--	PlayerOneId int foreign key references dbo.Player not null,
--	PlayerOneAccepted bit null,
--	PlayerTwoId int foreign key references dbo.Player not null,
--	PlayerTwoAccepted bit null,
--	WinningPlayerId int foreign key references dbo.Player null,
--	CurrentPlayerId int foreign key references dbo.Player null,
--	StateDate datetime2(7) not null,
--	CreateDate datetime2(7) not null,
--	WonDate datetime2(7) null,
--	EndDate datetime2(7) null,
--	DeathMatchMode bit not null, 
--	constraint CK_Game_TwoPlayers check(PlayerOneId <> PlayerTwoId),
--	constraint CK_Game_WinnerPlaying check(WinningPlayerId is null
--										or WinningPlayerId = PlayerOneId
--										or WinningPlayerId = PlayerTwoId),
--	constraint CK_Game_CurrentPlayerPlaying check(CurrentPlayerId is null
--												or CurrentPlayerId = PlayerOneId
--												or CurrentPlayerId = PlayerTwoId)
--)
--go

--alter table dbo.Match
--add CurrentGameId int foreign key references dbo.Game null
--go

--create table dbo.AIGame(
--	AIGameId int identity(1,1) primary key not null,
--	MatchId int foreign key references dbo.Match null,
--	GameId int foreign key references dbo.Game not null,
--	PlayerId int foreign key references dbo.Player not null,
--	EvaluatingMove bit not null,
--)
--go

--create table dbo.GameMove(
--	MoveId int identity(1,1) primary key not null,
--	GameId int foreign key references dbo.Game not null,
--	PlayerId int foreign key references dbo.Player not null,
--	MoveDate datetime2(7) not null,
--	IsSettingPiece bit not null,
--	X int not null,
--	y int not null,
--)
--go

--create table dbo.CentralServerSession(
--	CentralServerSessionId int identity(1,1) primary key not null,
--	CentralServerGameId int null,
--	GameId int foreign key references dbo.Game not null,
--)
--go

--User Creation
if not exists (select name from master.sys.server_principals where name = 'ContentManagementUser')
begin
	use master
	create login ContentManagementUser with password = '3oN73ntM2nA9em3nT', default_database = ContentManagement
end

if not exists (select name from ContentManagement.sys.database_principals where name = 'ContentManagementUser')
begin
	use ContentManagement
	create user ContentManagementUser for login ContentManagementUser;
end
go

----Stored Procedure Creation
--create procedure dbo.sp_GetAIGamesForEvaluation
--as
--begin
--	declare @GamesForEvaluation table (GameId int, PlayerId int);
	
--	--Mark the games requiring AI attention as being attended to and retrieve them.
--	update ai
--	set ai.EvaluatingMove = 1
--	output inserted.GameId, inserted.PlayerId into @GamesForEvaluation
--	from dbo.AIGame ai
--		join dbo.Game gm
--			on ai.GameId = gm.GameId
--				and ai.PlayerId = gm.CurrentPlayerId
--	where gm.WonDate is null
--		and gm.WinningPlayerId is null
--		and ai.EvaluatingMove = 0;

--	select * from @GamesForEvaluation
--end
--go

--create procedure dbo.sp_GetAllLogsForMatch(@matchId int)
--as
--begin
--select lg.*
--from dbo.AuditLog lg
--	join dbo.Game gm
--		on Metadata like '%GameId:' + cast(gm.GameId as varchar) + '%'
--where gm.MatchId = @matchId
--end
--go

--exec sp_addrolemember 'db_datareader', 'TicTacUser'
--exec sp_addrolemember 'db_datawriter', 'TicTacUser'

--grant execute on dbo.sp_GetAIGamesForEvaluation to TicTacUser
--go

--grant execute on dbo.sp_GetAllLogsForMatch to TicTacUser
--go