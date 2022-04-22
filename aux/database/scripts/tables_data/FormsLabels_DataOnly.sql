--create table [#tempFormsLabels] (
--[Id] [uniqueidentifier],
--[Name] [nvarchar] (max),
--[Description] [nvarchar] (max) NULL);


insert [FormsLabels] ([Id],[Name],[Description])
select '{95e3b46e-0a3b-4a58-a3b9-7d7acf1dda97}',N'Trial Completion',N'' UNION ALL
select '{d5b296e5-b554-4941-81da-9cdeedd327cb}',N'Baseline',N'' UNION ALL
select '{36076aa4-9a05-4db9-957c-c54f366dfd4c}',N'Trial',N'';