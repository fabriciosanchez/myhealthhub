--create table [#tempStudiesPerPhysicians] (
--[StudyId] [uniqueidentifier],
--[PhysicianId] [uniqueidentifier],
--[Id] [uniqueidentifier]);


insert [StudiesPerPhysicians] ([StudyId],[PhysicianId],[Id])
select '{b3473859-cd90-4778-8145-446e24c0a240}','{47232d67-460c-4d56-beae-8ba1141c3868}','{8c4ce1e5-5886-4a23-a1f0-533b60283b00}' UNION ALL
select '{cf8c25f3-e29b-4b5d-8a0f-cb01670948c3}','{47232d67-460c-4d56-beae-8ba1141c3868}','{60fa9f3a-783c-47d7-b8f5-6c2aba0d25ca}';