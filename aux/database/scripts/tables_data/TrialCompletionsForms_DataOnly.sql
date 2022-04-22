--create table [#tempTrialCompletionForms] (
--[Id] [uniqueidentifier],
--[FormLabelId] [uniqueidentifier],
--[VisitId] [uniqueidentifier],
--[PhysicianId] [uniqueidentifier],
--[DateTrialImplant] [datetime2],
--[SiteName] [nvarchar] (max),
--[SiteId] [nvarchar] (max),
--[SubjectId] [nvarchar] (max),
--[PainLocationNatureStatus] [bit],
--[StudyTreatmentFeedbackStatus] [bit],
--[VideoMotorAssessmentStatus] [bit],
--[BloodPressure] [nvarchar] (max),
--[BodyWeight] [nvarchar] (max),
--[APIImagesCollectionStatus] [bit],
--[LateralImagesCollectionStatus] [bit],
--[SpinalLevelCoverageLead1] [nvarchar] (max),
--[SpinalLevelCoverageLead2] [nvarchar] (max),
--[ImageAddedEncryptedDriveStatus] [bit],
--[DateTimeRemovalNeuromodulation] [datetime2],
--[AdjustmentsMadeTrialPeriodStatus] [bit]);


insert [TrialCompletionForms] ([Id],[FormLabelId],[VisitId],[PhysicianId],[DateTrialImplant],[SiteName],[SiteId],[SubjectId],[PainLocationNatureStatus],[StudyTreatmentFeedbackStatus],[VideoMotorAssessmentStatus],[BloodPressure],[BodyWeight],[APIImagesCollectionStatus],[LateralImagesCollectionStatus],[SpinalLevelCoverageLead1],[SpinalLevelCoverageLead2],[ImageAddedEncryptedDriveStatus],[DateTimeRemovalNeuromodulation],[AdjustmentsMadeTrialPeriodStatus])
select '{325255ed-ee0c-48b5-8014-72ff83dc6a8f}','{95e3b46e-0a3b-4a58-a3b9-7d7acf1dda97}','{551f0e4f-118b-4f16-a361-8937ca56f2af}','{47232d67-460c-4d56-beae-8ba1141c3868}','2022-04-15 10:10:00.0000000',N'Quest Diagnostics',N'56',N'235',0,1,1,N'120/80',N'230',1,1,N'T2',N'T3',1,'2022-04-07 01:13:55.0000000',1;