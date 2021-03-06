USE [LineaSupermercado]
GO
/****** Object:  Table [dbo].[CajaCliente]    Script Date: 24/04/2020 12:36:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CajaCliente](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDCaja] [int] NOT NULL,
	[IDCliente] [int] NOT NULL,
	[Orden] [int] NOT NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_CajaCliente] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CajaCliente] ON 

INSERT [dbo].[CajaCliente] ([ID], [IDCaja], [IDCliente], [Orden], [Estado]) VALUES (139, 232, 338, 1, 1)
INSERT [dbo].[CajaCliente] ([ID], [IDCaja], [IDCliente], [Orden], [Estado]) VALUES (140, 232, 339, 1, 1)
INSERT [dbo].[CajaCliente] ([ID], [IDCaja], [IDCliente], [Orden], [Estado]) VALUES (141, 232, 340, 1, 0)
INSERT [dbo].[CajaCliente] ([ID], [IDCaja], [IDCliente], [Orden], [Estado]) VALUES (142, 232, 341, 2, 0)
INSERT [dbo].[CajaCliente] ([ID], [IDCaja], [IDCliente], [Orden], [Estado]) VALUES (143, 232, 342, 3, 0)
SET IDENTITY_INSERT [dbo].[CajaCliente] OFF
ALTER TABLE [dbo].[CajaCliente] ADD  CONSTRAINT [DF__CajaClien__Estad__20C1E124]  DEFAULT ((0)) FOR [Estado]
GO
ALTER TABLE [dbo].[CajaCliente]  WITH CHECK ADD  CONSTRAINT [FK_CajaCliente_Caja] FOREIGN KEY([IDCaja])
REFERENCES [dbo].[Caja] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CajaCliente] CHECK CONSTRAINT [FK_CajaCliente_Caja]
GO
ALTER TABLE [dbo].[CajaCliente]  WITH CHECK ADD  CONSTRAINT [FK_CajaCliente_Cliente] FOREIGN KEY([IDCliente])
REFERENCES [dbo].[Cliente] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CajaCliente] CHECK CONSTRAINT [FK_CajaCliente_Cliente]
GO
