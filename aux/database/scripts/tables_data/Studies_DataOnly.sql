--create table [#tempStudies] (
--[Id] [uniqueidentifier],
--[Name] [nvarchar] (max),
--[Description] [nvarchar] (max) NULL);


insert [Studies] ([Id],[Name],[Description])
select '{b3473859-cd90-4778-8145-446e24c0a240}',N'Tru-Burst',N'' UNION ALL
select '{cf8c25f3-e29b-4b5d-8a0f-cb01670948c3}',N'Xanadu',N'';