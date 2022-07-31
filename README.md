
# BpRobotics

This is a CodeCool team project from the last module of the curriculum. We are currently past our 4th sprint.

# Description

This is a web application for administering the distribution, installation and maintenance of smart devices (smart air conditioning, smart fridge, etc).


## Sprints

#### First sprint

- Planning out application Domain Model and REST API
- Basic ASP.NET Core routing
- Testing the API with Postman

#### Second sprint

- React basics and routing
- Repository pattern for accessing the data layer
- Consume REST API endpoints from React

#### Third sprint

- Replacing the in-memory data layer with Entity Framework + MSSQL

#### Fourth sprint

- Role based, JWT Authentication
- Role based feature & route access in React and ASP .NET

## Features

- Role based authentication (admin, customer, partner)
- Login / Logout
- Customer list, customer profile
- Order creation (admin & customer roles only)
- Device list (admin & customer only), adding service to Device*
- Partner list*, add new partner*, delete partner*, update partner*
- Products list, product detail page, add product*, delete product*
- Users list*, user detail page, add user*, delete user*

(features marked with `*` are admin-only)

### Login info
Use these to test features. Features vary based on user role.

- Admin user -  Username: `MainAdmin` Password: `1234`

- Partner user - Username: `RepairMan` Password: `1234`

- Customer user - Username: `ILoveRefrigerators` Password: `1234`

## Production build
[Deployed to Azure.](https://icy-mushroom-0411fdf0f.1.azurestaticapps.net/) The backend takes about 30-45 seconds to load for the first time if no requests were made in a while.

## Run Locally
##### Prerequisites
- Microsoft Visual Studio to run ASP .NET backend
- Node.js to run React frontend

Clone the project and navigate to the project folder

```bash
  git clone https://github.com/CodecoolGlobal/el-proyecte-grande-sprint-1-csharp-marcellgim
  cd .\el-proyecte-grande-sprint-1-csharp-marcellgim
```

Starting the backend:

- Open BpRobotics.sln in Microsoft Visual studio
- Run IIS Express server


Starting frontend:
Go back to the root directory of the repository and navigate to:

```bash
  cd .\el-proyecte-grande-sprint-1-csharp-marcellgim\BpRobotics\Client\bprobotics-client
```

Install packages

```bash
  npm i
```

Start the application 

```bash
  npm start
```
Client should be available at `localhost:3000`



## Roadmap

- Reliability improvements (error handling, UI consistency)
- Implement ticket management
- Improve application design (CSS)

