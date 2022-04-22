--create table [#tempVisitsPerPatients] (
--[PatientId] [uniqueidentifier],
--[VisitId] [uniqueidentifier],
--[Id] [uniqueidentifier]);


insert [VisitsPerPatients] ([PatientId],[VisitId],[Id])
select '{560001d0-bbed-4157-a8cd-81b2e649c1d8}','{a4ff5a90-d44f-48c7-83d4-1ef8d3db3a0d}','{fc66964a-bee5-42b0-9fe3-36a84a90925e}' UNION ALL
select '{560001d0-bbed-4157-a8cd-81b2e649c1d8}','{551f0e4f-118b-4f16-a361-8937ca56f2af}','{243560b1-d0c3-498c-8721-cd1d419225e5}' UNION ALL
select '{560001d0-bbed-4157-a8cd-81b2e649c1d8}','{160f7911-59ad-4dd5-b8b6-d2f5aa6f02bb}','{d1d71fd5-4547-453e-bc7a-39bc56880678}';