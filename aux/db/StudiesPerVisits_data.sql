--create table [#tempStudiesPerVisits] (
--[VisitId] [uniqueidentifier],
--[StudyId] [uniqueidentifier],
--[Id] [uniqueidentifier]);


insert [StudiesPerVisits] ([VisitId],[StudyId],[Id])
select '{551f0e4f-118b-4f16-a361-8937ca56f2af}','{b3473859-cd90-4778-8145-446e24c0a240}','{fada2ed7-5800-468a-81e0-8d940c955b7f}' UNION ALL
select '{160f7911-59ad-4dd5-b8b6-d2f5aa6f02bb}','{b3473859-cd90-4778-8145-446e24c0a240}','{d1e270a0-ddb7-46d0-97fe-e9e0f09b0152}' UNION ALL
select '{a4ff5a90-d44f-48c7-83d4-1ef8d3db3a0d}','{cf8c25f3-e29b-4b5d-8a0f-cb01670948c3}','{c6e0fbc6-ffbd-41b8-bef4-4e58cc50b36a}';