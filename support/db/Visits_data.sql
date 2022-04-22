--create table [#tempVisits] (
--[Id] [uniqueidentifier],
--[Name] [nvarchar] (max),
--[Description] [nvarchar] (max) NULL);


insert [Visits] ([Id],[Name],[Description])
select '{a4ff5a90-d44f-48c7-83d4-1ef8d3db3a0d}',N'End of Trial',N'' UNION ALL
select '{551f0e4f-118b-4f16-a361-8937ca56f2af}',N'Baseline',N'' UNION ALL
select '{160f7911-59ad-4dd5-b8b6-d2f5aa6f02bb}',N'Trial',N'';