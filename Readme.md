# Onion Architecture In ASP.NET Core

![img.png](img.png)

- **Domain and Application Layer** will be at the center of the design. We can refer to these layers as the Core Layers. These layers will not depend on any other layers.
- **The presentation layer** is where you would Ideally want to put the Project that the User can Access. This can be a WebApi, Mvc Project, etc.
- **The infrastructure layer** is where you would want to add your Infrastructure. Infrastructure can be anything. Maybe an Entity Framework Core Layer for Accessing the DB, a Layer specifically made to generate JWT Tokens for Authentication or even a Hangfire Layer.

## List of features and tech
- Onion Architecture
- Entity Framework Core
- .NET Core 8.0
- Swagger
- CQRS / Mediator Pattern using MediatR Library
- Wrapper Class for Responses
- CRUD Operations
- Inverted Dependencies
- API Versioning
