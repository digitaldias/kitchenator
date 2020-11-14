<img src="../doc/images/taco.png" width="200px" alt="Terrible Taco" style="float:left;"></img>
# The Kitchenator
This is a sample playground project used to explore the Dolittle platform. 
It builds and expands on the tutorial [found here](https://dolittle.io/tutorials/getting-started/csharp/). 
The project contains several applications, some WPF, and some Web applications (Asp.Net Core). 

The general idea behind this project is to build up an empire named **Terrible Tacos**, a slew of Taco-serving restaurants, 
meant to take over the world! Why settle for less, right? 

The project manages everything, from renting realestate to use for 
restaurants, to hiring chefs, introducing new, delicious recepies, and taking orders. 

This project builds heavily on the *event driven architecture*, and attempts to leverage the platform to create
a realistic, scaleable solution. As the Dolittle platform expands in capabilities, this project will follow to test and 
utilize the new stuff. 


### Current capabilities
* A Property management WebApp (Blazor) for handling restaurants and staffing them with chefs
* A Customer WebApp (Blazor) for handling customer orders
* A Monitoring application (WPF) for displaying current orders across all restaurants
* An (very ugly) application (WPF) as an alternative app for staffing


### Your first run
In order to fully appreciate this application, you should start running the applications in the following order: 

- [ ] Populate the countries and cities tables with some data
- [ ] Run the Property Manager to create a few Restaurants
- [ ] Add staffing to those restaurants by hiring people
- [ ] Add a few Taco-dishes to the menu
- [ ] Start taking orders
- [ ] Monitor the orders coming in on the Monitoring Application




---- 
## Project Requirements
- `.Net 5.0` SDK must be installed. You can find that [here](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Docker](https://www.docker.com/products/docker-desktop) must be installed on your computer. 
- Using [Project Tye](https://github.com/dotnet/tye) will help you greatly during development. <br /> `$> tye run --port 8083 --dashboard --watch`
- A valid `Azure Storage Account` for storing readmodels.

## Setting up Countries and Cities
The solution *ASSUMES* that the two tables exist in your Azure Table Storage, and are populated:

| Table Name | Primary Key | Secondary Key | 
| ---------- | ----------- | ------------- |
| countries  | 2-letter country code | country name | 
| cities     | 2-letter country code | city name | 


For convenience, you can populate the two tables using the following CSV files
- [countries.csv](../doc/datafiles/countries.csv)
- [cities.csv](../doc/datafiles/cities.csv)

You can do this using a tool such as [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/)


## User Secrets
The project relies on a few user secretes that can be set using the following method: 

#### Visual Studio 2019
* Load the `Kitchenator.sln` solution from your source folder
* Expand the folder `30 Domain Layer` and right click on the `kitchenator.Domain` project
* Select `User Secrets` in the context menu. A blank Json file appears. This is your user-secrets file. It is stored somewhere other than your source code, so that you won't have to worry about committing secrets into your source.

Add the following configuration: 
```json
{
  "Dolittle": {
    "ServiceId": "f39b1f61-d360-4675-b859-53c05c87c0e6",
    "HostName": "localhost",
    "HostPort": 50053
  },
  "AzureStorage": {
    "ConnectionString": "<Your Azure Storage Connection String>"
  }
}
```

---- 

## Debugging
Before debugging, make sure that the Dolittle runtime is active: 
- Execute `$> docker run -p 50053:50053 -p 27017:27017 dolittle/runtime:latest-development` before debugging. This will start the Dolittle Runtime and other required services. 

For example: 
To run the 

---- 

## Project contributions
