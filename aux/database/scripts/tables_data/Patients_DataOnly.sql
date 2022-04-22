--create table [#tempPatients] (
--[Id] [uniqueidentifier],
--[Email] [nvarchar] (max),
--[InternalId] [nvarchar] (max));


insert [Patients] ([Id],[Email],[InternalId])
select '{560001d0-bbed-4157-a8cd-81b2e649c1d8}',N'abc@def.com',N'12345';