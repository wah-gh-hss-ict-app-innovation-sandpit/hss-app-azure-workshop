# Intro to Azure Portal and Azure Storage

## Azure Portal
Azure Portal is the main gate where you access all workloads in Azure.
- Access the Azure Portal through [https://portal.azure.com](https://portal.azure.com)
- Some main points to remember:
    - Everything starts with a [Resource Group](https://learn.microsoft.com/en-us/azure/azure-resource-manager/management/manage-resource-groups-portal#what-is-a-resource-group) which is a logical container for your workloads
    - Create resources in regions that are closest to you to minimise latency. Available regions and products: [Azure Region](https://azure.microsoft.com/en-us/explore/global-infrastructure/geographies/#geographies)
    - Tag - Use tag wherever possible to tag your workload for easier search and billing
    - Cost Management - check your credit usage!

## Azure Storage
A "one-stop shop" for storing things on Azure
- 4 types of storage - Blob, Queue, Table and File Share
- Redundancy - to protect from data loss
- Use the **Storage Browser** in Azure Portal to view your Storage account content
    - A local version of the Azure Storage Explorer is available at [https://aka.ms/portalfx/downloadstorageexplorer](https://aka.ms/portalfx/downloadstorageexplorer)

## Useful links
- [Azure Blob Storage](https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blobs-overview)
- [Azure Queue Storage](https://learn.microsoft.com/en-us/azure/storage/queues/storage-queues-introduction)
- [Azure Table Storage](https://learn.microsoft.com/en-us/azure/storage/tables/table-storage-overview)
- [Manipulate Azure Storage Table](https://learn.microsoft.com/en-us/azure/cosmos-db/table/quickstart-dotnet?tabs=azure-portal%2Cwindows#install-the-required-nuget-package)
