--create table [#tempFormLabelsPerVisits] (
--[Id] [uniqueidentifier],
--[FormLabelId] [uniqueidentifier],
--[VisitId] [uniqueidentifier]);


insert [FormLabelsPerVisits] ([Id],[FormLabelId],[VisitId])
select '{1e171e1c-e296-4f67-9508-3a98eb4b0c55}','{95e3b46e-0a3b-4a58-a3b9-7d7acf1dda97}','{a4ff5a90-d44f-48c7-83d4-1ef8d3db3a0d}' UNION ALL
select '{1e171e1c-e296-4f67-9508-3a98eb4b0c55}','{d5b296e5-b554-4941-81da-9cdeedd327cb}','{551f0e4f-118b-4f16-a361-8937ca56f2af}' UNION ALL
select '{1e171e1c-e296-4f67-9508-3a98eb4b0c55}','{36076aa4-9a05-4db9-957c-c54f366dfd4c}','{160f7911-59ad-4dd5-b8b6-d2f5aa6f02bb}';