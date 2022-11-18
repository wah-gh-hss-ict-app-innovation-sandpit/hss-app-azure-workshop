# Azure Container Apps

## Different ways of hosting containers in Azure
To store your container image:
- Azure Container Registry - a container repository to host and store your container images.

To host your container image for usage:
- Azure App Service (AS) - deploy containers to App Service
- Azure Container Instance (ACI) - Fully managed serverless container hosting environment to host your containers without orchestration
- Azure Container Apps (ACA) - Fully managed serverless container **service** for building and deploing applications at scale
- Azure Kubernetes Service (AKS) - Fully managed Kubernetes platform to provide container orchestration service for your containers

## Azure Container Apps
A fully managed container services by Azure that has the following features:
- Ability to run multiple revisions of your container
- Autoscale based on CPU or memory load, HTTP traffic, event, KEDA-supported scaler
- Enable HTTPS ingress without any infrastructure – support TLS certificates, port 443 routing
- Split HTTP traffic across different revisions – enabling Blue-Green deployment and testing
- DAPR support out-of-the-box which is a Microservices building framework
- Virtual Network (VNET) integration
- Securely manage secrets directly from the application container

## Project
### For today's session, we will turn the WhereIsPatient web app into a Docker container application

### Instruction:
1. Go to Azure Portal and create a Container Registry in the resource group. (This will be used for you to publish a Docker image)
    - Choose the "Basic" SKU for your Container Registry
    - Once the Container Registry is created, go to **Access Keys** on the left menu and enable "**Admin User**". *Note down the username and password
2. If you haven't installed Docker Desktop on your machine, install it using winget or download the installer from [https://www.docker.com/](https://www.docker.com/)
3. Once you have installed Docker Desktop:
    - Add your HE number to the "docker-users" local group on your machine
    - Login using your Docker credentials that has been assigned to you (firstname.lastname@health.wa.gov.au)
4. If you want to use Linux-based containers (default in Docker Desktop), you will need to install WSL2 [https://learn.microsoft.com/en-us/windows/wsl/install](https://learn.microsoft.com/en-us/windows/wsl/install)
5. If you do not want to use Linux-based containers, you can change Docker Desktop to use Windows containers, however you need to enable HyperV on your machine first.
6. Once you have done the above, make a copy of the WhereIsPatient solution from last week into another folder.
7. Open this newly copied solution.
8. Right click on the Web.Server project and Add "Docker Support".
9. Depending on whether you are using Windows or Linux container in Docker Desktop, choose the right OS on the "Target OS" page
10. This will then create a Dockerfile in the project.
11. Right click on the project and "Publish".
12. Choose **Docker Container Registry** in the publish options and then choose the **Azure Container Registry** you create in the first step.
13. Once the container image is published to the Container Registry, you can proceed to create an Azure Container Apps based on that container image.
14. In the resource group, create an Azure Container Apps:
    - Create a new "Azure Container Environment"
    - Under App Settings, uncheck "Use quickstart image" and then choose the image you publish to your Azure Container Registry.
    - Make sure to enable "Ingress" and "Accepting traffic from anywhere".
15. Once the Container Apps is created, you will be able to launch the application using the URL endpoint.

#### Homework
- Make sure changes to your web application and publish again to the registry as a new revision
- Split the traffic 50/50 between your current version and new version of the Container Apps

