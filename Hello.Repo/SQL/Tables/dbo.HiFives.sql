CREATE TABLE [dbo].[HiFives]
(
[HiFiveID] [int] NOT NULL IDENTITY(1, 1),
[HiFiver] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
[HiFivee] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
[EventID] [int] NOT NULL
)
GO
ALTER TABLE [dbo].[HiFives] ADD CONSTRAINT [FK_HiFives_HiFivee] FOREIGN KEY ([HiFivee]) REFERENCES [dbo].[Users] ([Username])
GO
ALTER TABLE [dbo].[HiFives] ADD CONSTRAINT [FK_HiFives_HiFiver] FOREIGN KEY ([HiFiver]) REFERENCES [dbo].[Users] ([Username])
GO
