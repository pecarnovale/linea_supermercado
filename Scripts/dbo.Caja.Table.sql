USE [LineaSupermercado]
GO
/****** Object:  Table [dbo].[Caja]    Script Date: 24/04/2020 12:36:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Caja](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NumeroCaja] [int] NOT NULL,
	[Cajero] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Caja] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Caja] ON 

INSERT [dbo].[Caja] ([ID], [NumeroCaja], [Cajero]) VALUES (232, 1, N'Pablo Carnovale')
SET IDENTITY_INSERT [dbo].[Caja] OFF
