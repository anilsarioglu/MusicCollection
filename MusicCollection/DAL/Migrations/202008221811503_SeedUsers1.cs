namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'92a675eb-2594-4777-b6fe-84f5719bf8fc', N'guest@music.com', 0, N'AD0sRG/1g7FyiES2YAnRX9LPlk4Cr7Tux4drijcIpmuaNfOwmPXj5WpxPo2CG6lFmQ==', N'156c3127-bffc-4c3c-ad28-97e5b3471b72', NULL, 0, 0, NULL, 1, 0, N'guest@music.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aa879350-b7b9-48d3-90dc-816ae0d6a605', N'admin@music.com', 0, N'AG9VySsiCD22fLiwPhM1unOIjeqtXbH/IwzB+9q55QH403DCAt7JLsTdnXe9U8ousQ==', N'38639329-cd0a-4e18-a08e-0735bc636c70', NULL, 0, 0, NULL, 1, 0, N'admin@music.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fd9bab44-89b5-4572-9c8c-abf02587516a', N'CanManageEverything')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'aa879350-b7b9-48d3-90dc-816ae0d6a605', N'fd9bab44-89b5-4572-9c8c-abf02587516a')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
