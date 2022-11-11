# Application Hosting in Azure

## Database offering in Azure
There are different ways to host applications in Azure
- Azure Virtual Machine (VM) - The traditional way (IaaS) of building a server to host your application. 
- Azure App Service - PaaS hosting solution to host Http-based (web-based) applications and APIs. The easiest and quickest way to host web applications on Azure.
- Azure Static Web Apps - PaaS hosting solution for static web apps/website. Think NodeJS client apps, HTML sites, Blazor WASM
- Azure Fuction Apps - Serverless event-driven code hosting
- Azure Spring Apps - For hosting Java SpringBoot apps/microservices
- Azure Kubernetes Services - Fully managed Kubernetes platform for orchestrating and managing container-based applications
- Azure Container Instance - Managed service for you to run an instance of your container-based app
- Azure Container Apps - Managed service for you to run your container-based app and provide scaling capabilities and integrates with Dapr (a microservice framework)
- Azure Batch - User for running high-performance and large-scale processing jobs within a pool of VMs

## Azure App Service
- To create an App Service, you first need to create an App Service Plan (ASP). In the Azure Portal, create an App Service Plan and choose the pricing tier that you are comfortable with
- Once you have the ASP created, create an App Service.
    - Name of App Service has to be unique as it forms part of the URL you use to access your app.
    - Make sure to use the ASP you have created earlier to host your App Service.
    - Make sure you choose the correct application framework to host your application
- Once you have created an App Service, you can deploy your web application using Visual Studio (directly) or if you have a CI/CD pipeline setup, you can set your CD pipeline to deploy directly to App Service

## Project
This is a continuation of last week's project based on the Use Case below

Use Case:
1. When a patient goes to a hospital for a surgery, the patient needs to be registered and admitted to the hospital.
2. During the patient's stay in the hosital, the patient will move around the hospital depending on the surgery need. It may be the patient is in a clinic for blood sample taking, in another clinic for health check, or in a ward waiting for the surgery etc.
3. When the patient is admitted, a link will be forwarded to the patient's next-of-kin.
4. When the next-of-kin access the link, the web app will show where the patient is currently at eg. which clinic/ward the patient is currently at.

### For today's session, we will build a web application to display the patient's current location to the next-of-kin

### Instruction:
1. Open last week's solution and create a new **Blazor WebAssembly** project. #NOTE that there are two types of Blazor application, **Blazor Server** and **Blazor WebAssembly**. Choose the right one.
2. Name the project **WhereIsPatient.Web**
3. Once the project is created, you will notice there are three projects:
    - WhereIsPatient.Web.Client - This is the UI project where you will create your Razor components to display the patient details
    - WhereIsPatient.Web.Server - This is the backend project where you will create an API controller to get the data from the database and used by the UI to get the data
    - WhereIsPatient.Web.Shared - This is used for hosting shared models/view-models/helper class that can be used both by the Client and Server project
