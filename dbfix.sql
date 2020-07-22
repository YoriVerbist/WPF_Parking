CREATE TABLE [dbo].[Parking] (
    [ID]   INT IDENTITY(1,1) NOT NULL,
    [Naam] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Parking] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Rij] (
    [ID]               INT IDENTITY(1,1) NOT NULL,
    [Parking_ID]       INT NOT NULL,
    [Totale_plaatsen]  INT NOT NULL,
    [Bezette_plaatsen] INT NOT NULL,
    [Volzet]           BIT DEFAULT ((0)) NOT NULL,
    FOREIGN KEY ([Parking_ID]) REFERENCES [dbo].[Parking] ([ID]),
    CONSTRAINT [PK_Rij] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Plaats] (
    [ID]       INT IDENTITY(1,1) NOT NULL,
    [Rij_Id]   INT NULL,
    [Is_bezet] BIT DEFAULT ((0)) NOT NULL,
    FOREIGN KEY ([Rij_Id]) REFERENCES [dbo].[Rij] ([ID]),
    CONSTRAINT [PK_Plaats] PRIMARY KEY CLUSTERED ([ID] ASC)
);

SET IDENTITY_INSERT [dbo].[Parking] ON
INSERT [dbo].[Parking] ([ID], [Naam]) VALUES (0, N'School')
SET IDENTITY_INSERT [dbo].[Parking] OFF

SET IDENTITY_INSERT [dbo].[Rij] ON
INSERT [dbo].[Rij] ([ID], [Parking_ID], [Totale_plaatsen], [Bezette_plaatsen], [Volzet]) VALUES (0, 0, 5, 3, 0)
INSERT [dbo].[Rij] ([ID], [Parking_ID], [Totale_plaatsen], [Bezette_plaatsen], [Volzet]) VALUES (1, 0, 6, 6, 1)
INSERT [dbo].[Rij] ([ID], [Parking_ID], [Totale_plaatsen], [Bezette_plaatsen], [Volzet]) VALUES (2, 0, 10, 5, 0)
SET IDENTITY_INSERT [dbo].[Rij] OFF

SET IDENTITY_INSERT [dbo].[Plaats] ON
INSERT [dbo].[Plaats] ([ID], [Rij_id], [Is_bezet]) VALUES (0, 0, 0)
INSERT [dbo].[Plaats] ([ID], [Rij_id], [Is_bezet]) VALUES (1, 0, 1)
INSERT [dbo].[Plaats] ([ID], [Rij_id], [Is_bezet]) VALUES (2, 0, 1)
INSERT [dbo].[Plaats] ([ID], [Rij_id], [Is_bezet]) VALUES (3, 0, 0)
INSERT [dbo].[Plaats] ([ID], [Rij_id], [Is_bezet]) VALUES (4, 0, 0)
INSERT [dbo].[Plaats] ([ID], [Rij_id], [Is_bezet]) VALUES (5, 1, 1)
INSERT [dbo].[Plaats] ([ID], [Rij_id], [Is_bezet]) VALUES (6, 1, 1)
INSERT [dbo].[Plaats] ([ID], [Rij_id], [Is_bezet]) VALUES (7, 2, 1)
INSERT [dbo].[Plaats] ([ID], [Rij_id], [Is_bezet]) VALUES (8, 2, 0)
INSERT [dbo].[Plaats] ([ID], [Rij_id], [Is_bezet]) VALUES (9, 2, 0)
INSERT [dbo].[Plaats] ([ID], [Rij_id], [Is_bezet]) VALUES (10, 2, 0)
SET IDENTITY_INSERT [dbo].[Plaats] OFF
