**Sample Blog multi-layered application, using .NET Core and ASP.NET Core Web API as the application server, SQL Server as the database**
=============

Basically, contains the following projects, each one references the previous listed in this order (Multi-Layer Onion Architecture):

- **SampleBlogModels**: Models, Constants, DTOs and Base Interfaces to Base Entities.
- **SampleBlogDatabaseCore**:  Entity Framework DbContext and Migrations.
- **SampleBlogDatabaseLayer**: Application Database Repository.
- **SampleBlogBusinessLayer**: Application Business Logic and Services.
- **SampleBlogSiteApi**: Application API implementation.

**INITIAL SETUP AND FIRST RUN**
=============

1. Go to the SampleBlogSiteApi project, find the appsettings.json file and edit the connection string so it matches the name of your Computer, Database Server and your authentication scheme. It should look like this:


    ```json
    "ConnectionStrings": {
    "SampleBlogDbConnection": "Data Source=CS880;Database=SampleBlogDB;Integrated Security=True; MultipleActiveResultSets=true"
    }
    ```
1. Select the AzyraCustoms.Api project as the default StartUp project.
1. Go to the Package Management Console and select the SampleBlogDatabaseCore project.
1. We need to create the Database Tables and Objects for the first time. Update the Database to Create the Table(s) by typing: `Update-Database -Context SampleBlogDbContext`
1. If everything go well you shuold see the Swagger endpoint browser screen.
