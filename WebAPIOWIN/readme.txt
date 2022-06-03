Do the following steps

    1.Change the database connection string
    2.open Tools-->Nuget-->Package Manager Console then run below commands
    3.enable-migrations -ContextTypeName WebAPIOWIN.OwinAuthDbContext
    4.Add-Migration Initial
    5.Update-Database
    6.Insert below reocrd
    
        INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp],
        [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled],
        [AccessFailedCount], [UserName])
        VALUES (N'9f15bdd0fcd5423190c2e877ba0228ee', N'Tester@testing.com', 1,
        N'ALkHGax/i5KBYWJ7q4jhJmMKmm2quBtnnqS8KcmLWd2kQpN6FaGVulDmmX12s7YAyQ==',
        N'a7bc5c5c-6169-4911-b935-6fc4df01d313', NULL, 0, 0, NULL, 0, 0, N'Adam')

    8. Run the solution. You can see the screenshots to test the code using postman.
    
