# Serverless in Azure

## Different type of serverless offering from Azure
- Azure Functions – code-first development that reacts to an event
- Azure Logic Apps – designer-based development that reacts to an event
- Power Automate (prev. known as Microsoft Flow) – very similar to Azure Logic Apps but with less connector and more tailored to the Power Platform-type of development
- Azure App Service WebJobs – Similar to Azure Functions but it can only run on App Service and can only be written in C#

## Azure Functions
"It’s a “compute on-demand” type of “application” where it reacts to an event (**trigger**), process the event (**action**) and produce some outputs from the processing (**output**)."
- You can create an Azure Function using the Azure Portal or create an Azure Function in Visual Studio and publish to Azure

## Project
This is a continuation of last week's project based on the Use Case below

Use Case:
1. When a patient goes to a hospital for a surgery, the patient needs to be registered and admitted to the hospital.
2. During the patient's stay in the hosital, the patient will move around the hospital depending on the surgery need. It may be the patient is in a clinic for blood sample taking, in another clinic for health check, or in a ward waiting for the surgery etc.
3. When the patient is admitted, a link will be forwarded to the patient's next-of-kin.
4. When the next-of-kin access the link, the web app will show where the patient is currently at eg. which clinic/ward the patient is currently at.

### For today's session, we will create an Azure Function to process messages to update the database

### Instruction:
1. Go to Azure Portal and go to the Azure Storage that you have created.
2. Create a queue called "patient-message-queue".
3. Go to Access Keys on the left menu and copy one of the two connection strings. NOTE this down as you need it in the project.
4. Open last week's solution and create a new **Azure Functions** project.
5. Name the project **WhereIsPatient.ProcessQueueFunction**
6. When prompted, use the following options:
    - Functions Worker: .NET 6.0
    - Function: Queue Trigger
    - Use Azurite for runtime storage account – Untick this unless you have Azurite installed on your machine
    - Authorisation Level: Anonymous
    - Connect to dependency – Choose Azure Storage
    - When prompted to choose the Azure Storage, choose your Azure Storage and click Create
7. Once the project is created, install these NuGet packages:
    - Microsoft.Extensions.DependencyInjection
    - Microsoft.Azure.Functions.Extensions
8. Add a reference to the WhereIsPatient database project.
9. Create a class called **Startup.cs** and add the following code.
```
using System;
using System.Threading.Tasks;
using WhereIsPatient.DB;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

[assembly: FunctionsStartup(typeof(WhereIsPatient.ProcessQueueFunction.Startup))]

namespace WhereIsPatient.ProcessQueueFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
            builder.Services.AddDbContext<WhereIsPatientContext>(
                options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
        }
    }
}
```
10. Make sure your local.settings.json file has the connection string to your Azure Storage and Database within the "Values" block.

