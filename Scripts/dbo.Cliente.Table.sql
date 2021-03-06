USE [LineaSupermercado]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 24/04/2020 12:36:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](70) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ID], [Nombre]) VALUES (338, N'Cliente 1')
INSERT [dbo].[Cliente] ([ID], [Nombre]) VALUES (339, N'Cliente 2')
INSERT [dbo].[Cliente] ([ID], [Nombre]) VALUES (340, N'Cliente 3')
INSERT [dbo].[Cliente] ([ID], [Nombre]) VALUES (341, N'Cliente 4')
INSERT [dbo].[Cliente] ([ID], [Nombre]) VALUES (342, N'Cliente 5')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
