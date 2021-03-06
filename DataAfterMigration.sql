USE [SonOfCod]
GO
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'01c7430a-bbf2-43e6-bbcb-676bc9fac1d1', N'cbdde804-edef-49e2-a1c3-2150f8857cbe', N'Admin', N'ADMIN')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'66b1bc48-0475-4517-8f19-d6c551f2cc66', N'f8b75b76-d29d-4035-931f-6d89c1a2d0c1', N'Random', N'RANDOM')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'9f264225-8606-492a-ba30-291c7457d231', 0, N'09127436-ad31-42c5-8fe2-72edd649b5a9', NULL, 0, 1, NULL, NULL, N'MOOCOW@GMAIL.COM', N'AQAAAAEAACcQAAAAEEJBFMCF7u6VNnajwzVrUgaT0CxEsTh6fnkB6tpoRHxJ4Jej40Eg0pcDJ3mZyETz6A==', NULL, 0, N'9712b2fe-0a82-44c7-93cf-2e45cef71f2c', 0, N'moocow@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'b00b0161-423f-468e-a3de-c5422bf75a34', 0, N'b4b5496d-8dc5-4f46-93db-2e84f1441bc5', NULL, 0, 1, NULL, NULL, N'MOOMOO@GMAIL.COM', N'AQAAAAEAACcQAAAAEEgYJSJNysV9d8ogr0fP4qu/U86agD9y0X2WnzpK3xVVQKwaQiimkkgcdJ+qh6QecA==', NULL, 0, N'08296822-e768-4862-ad32-8d3f77405548', 0, N'moomoo@gmail.com')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9f264225-8606-492a-ba30-291c7457d231', N'01c7430a-bbf2-43e6-bbcb-676bc9fac1d1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b00b0161-423f-468e-a3de-c5422bf75a34', N'01c7430a-bbf2-43e6-bbcb-676bc9fac1d1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170217183834_Initial', N'1.0.0-rtm-21431')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170217190840_AddNewsletterMemberTable', N'1.0.0-rtm-21431')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170217205945_AddNameToNewletter', N'1.0.0-rtm-21431')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170218003312_AddRequired', N'1.0.0-rtm-21431')
SET IDENTITY_INSERT [dbo].[NewsletterMembers] ON 

INSERT [dbo].[NewsletterMembers] ([NewsletterMemberId], [Birthday], [Email], [FirstName], [LastName]) VALUES (15, CAST(N'1982-07-02T00:00:00.0000000' AS DateTime2), N'petejoe@gmail.com', N'Peter', N'Jones')
INSERT [dbo].[NewsletterMembers] ([NewsletterMemberId], [Birthday], [Email], [FirstName], [LastName]) VALUES (16, CAST(N'1961-01-03T00:00:00.0000000' AS DateTime2), N'tomandjerry@yahoo.com', N'Tom', N'Jerry')
SET IDENTITY_INSERT [dbo].[NewsletterMembers] OFF
