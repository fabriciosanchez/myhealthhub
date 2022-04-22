--create table [#tempUploads] (
--[Id] [uniqueidentifier],
--[FileName] [nvarchar] (max),
--[VisitId] [uniqueidentifier]);


insert [Uploads] ([Id],[FileName],[VisitId])
select '{5d094b52-a0a6-46e3-a93d-34229fa17c42}',N'4-22-2022_102641db-f1c4-44e5-90e7-0b03110a4ec9_12345-Baseline.jpeg','{551f0e4f-118b-4f16-a361-8937ca56f2af}' UNION ALL
select '{bae5a3ac-921f-470b-8ba5-3ce71bd78b27}',N'4-22-2022_dda80d13-4259-458f-bf49-8835e5758901_12345-Baseline.pdf','{551f0e4f-118b-4f16-a361-8937ca56f2af}' UNION ALL
select '{5c5ac1dd-bba3-4fdf-9003-af2dc3d3603c}',N'4-22-2022_259aad06-4195-4657-9610-09494da9fd05_12345-Baseline.ics','{551f0e4f-118b-4f16-a361-8937ca56f2af}' UNION ALL
select '{1e8c9400-6432-4c05-8d2e-b88769197c58}',N'4-22-2022_6fc3a8fa-97ba-4686-ad9e-3fd59847fef7_12345-Baseline.pdf','{551f0e4f-118b-4f16-a361-8937ca56f2af}';