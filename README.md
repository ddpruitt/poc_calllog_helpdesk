# poc_calllog_helpdesk

Used ASP.Net MVC Core to create the application.  I used MVC since I am more familiar with this and wanted to get the app up and running quickly.

The data is stored in a SQL Server database, used migrations to generate the tables and relationships.  Also used migrations to generate a SQL script to run to create the tables.

The controllers and views were scaffold from the HelpDeskDbContext.  

It wasn't asked for but I created an OData API example.  Each of the entities in the OData example implement an IEntity interface.  This allows me to create a single base controller for OData then each of the entities inherit  the base controller. 

The OData example uses swagger and an in-memory database so it can be ran locally with no SQL Server support.