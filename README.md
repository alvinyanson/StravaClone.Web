
# Clone my repository


## Overview
![E-commerce Website Logo](https://raw.githubusercontent.com/alvinyanson/StravaClone.Web/refs/heads/master/localhost_7083_Club.png?token=GHSAT0AAAAAACUI5WEVOOT2FSIC3QT4GPP4ZXT5TZQ)

Open your terminal and run the following command to clone the repository.

    git clone https://github.com/alvinyanson/StravaClone.Web.git


## Features

- Clubs Near Me
- Dashboard
- Runners
- Clubs
- Races
- Login
- Register
- Profile




# How to Setup


### Add Connection String

Update the appsettings.json with your SQL Server connection string. 

Look for the **DefaultConnection** property and update it to match your server name. It should look like the same below after you configure it:

    "DefaultConnection": "Data Source=ALAYANSON\\SQLEXPRESS;Initial Catalog=StravaCloneWeb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"

### Cloudinary

Register for a Cloudinary Account (free) and add Cloudname, ApiKey, and Api secret to appsettings.json.

Register here https://cloudinary.com/users/register_free


# Technologies Used

- NET 8.0
- Entity Framework Core
- SQL Server
- Identity Provider for Authentication
- CQRS Mediatr
- Mapster
- XUnit
- CloudinaryDotNet
- FakeItEasy
- FluentAssertions

