# Database in Azure

## Database offering in Azure
Azure offers relational, NoSQL and in-memory Database
- Database offered
    - Microsoft SQL Server
        - Azure SQL Database
        - Azure SQL Managed Instance
        - SQL Server on Azure VM
    - PostgreSQL
    - MySQL
    - MariaDB
    - Azure Cosmos DB - NoSQL offering from Azure
    - Azure Cache for Redis - In-memory database mainly used for cachig

## Microsoft SQL Server
- Azure SQL Database - Database-as-a-Service
- Azure SQL Managed Instance - Database platform as a service
- SQL Server on Azure VM - traditional-style database on a server

## Project
In the next few sessions, we will try create a web app with the following use case.

Use Case:
1. When a patient goes to a hospital for a surgery, the patient needs to be registered and admitted to the hospital.
2. During the patient's stay in the hosital, the patient will move around the hospital depending on the surgery need. It may be the patient is in a clinic for blood sample taking, in another clinic for health check, or in a ward waiting for the surgery etc.
3. When the patient is admitted, a link will be forwarded to the patient's next-of-kin.
4. When the next-of-kin access the link, the web app will show where the patient is currently at eg. which clinic/ward the patient is currently at.

### For today's session, we will build up a database structure to record these details
I will walk you through the creation of Azure SQL Database and use .NET EntityFrameworkCore to create the database schema.
We will be creating 2 tables today with the schema below:

#### Patient

| Column Name | Data Type | Length |
|-----------|---------|------|
| UMRN       | varchar  | 8     |
| FirstName  | varchar  | 80    |
| LastName   | varchar  | 80    |
| DateOfBirth | datetime |      |
| Gender     | string   | 2     |
| CreatedDate | datetime |      |
| UpdatedDate | datetime |      |

#### Admission

| Column Name | Data Type | Length |
|-----------|---------|------|
| VisitNumber |varchar  | 12    |
| AppointmentDate | datetime  |    |
| AdmissionDate   | datetime  |    |
| DischargeDate   | datetime |      |
| HospitalName    | string   | 80    |
| HospitalAddress   | string   | 300    |
| CurrentWard   | string   | 300    |
| CreatedDate | datetime |      |
| UpdatedDate| datetime |      |

### Instruction:
1. Open Visual Studio Professional/Enterprise/Code and create a Class Library project. 
2. Name the solution **WhereIsPatient** and the class project **WhereIsPatient.DB**
3. If you are using Visual Studio Code:
	- Change directory to where you want your solution to be.
    - Create a directory to store your solution: **mkdir WhereIsPatient**
    - Navigate to the new directory: **cd WhereIsPatient**
    - Create a solution for your application: **dotnet new sln**
    - Create a class project: **dotnet new classlib -o WhereIsPatient.DB**
    - Add the new class project to the solution: **dotnet sln add WhereIsPatient.DB\WhereIsPatient.DB.csproj**
    - Open the **WhereIsPatient** folder in Visual Studio Code
4. Add the following Nuget Package:
    - **Microsoft.EntityFrameworkCore**
    - **Microsoft.EntityframeworkCore.Relational**
    - **Microsoft.EntityFrameworkCore.SqlServer**
    - **Microsoft.EntityFrameworkCore.Tools**
