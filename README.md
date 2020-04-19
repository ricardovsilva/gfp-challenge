# GFP Challenge

This repository contains all of GFP challenge for system architect job position. The challenge purposed was to create an API with .NET Core and implement a simple frontend to use this API.  
In this README I describe the steps to run the application and also the architectures and design decisions.

## Solution

This is a fullstack solution with .NET Core as backend and React for the frontend. The frontend is complete decoupled from the backend, so the frontend is going to work with any backend service that provides the same API endpoints.

It was developed using .NET Core 3.0 with Web API and provides a RestFull API.

Since .NET Core is multiplatform, I choose to develop all the solution in Ubuntu with VSCode.

## Running

Is possible to run with Docker and Docker Compose, and it is recommended. If you do not have docker and docker-compose installed yet, please, refeer to [Docker documentation](https://docs.docker.com/compose/install/).

### With Docker

Just clone this repository, navigate to it folder and run:

```shell
$ docker-compose build
$ docker-compose up
```

It is going to run the API and server.

### Without Docker

The installations steps is going to be different depending on the operational system that you are running this application. The dependencies are:

- [.NET Core v3.0](https://dotnet.microsoft.com/download)
- [NodeJS v12.6.0](https://nodejs.org/en/)

After installed .NET and Node, download this repository content and navigate to source folder (replace ~/git for your download path):

#### Starting the API

```shell
$ cd ~/git/gft-challenge/src
```

Then install all .NET packages:

```shell
$ dotnet restore
```

Then run the API:

```shell
$ dotnet run
```

You are going to receive the output bellow, it means that api is running.

```shell
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
```

#### Starting the frontend

Now that API is running, let's start the frontend. First of all, open a new terminal window and navigate to frontend folder:

```shell
$ cd frontend
```

Install all frontend dependencies:

```shell
$ npm install
```

So run the frontend:

```shell
$ npm start
```

You are going to receive the output bellow, so frontend is being available:

```shell
Compiled successfully!

You can now view frontend in the browser.

  Local:            http://localhost:3000
  On Your Network:  http://192.168.0.103:3000

Note that the development build is not optimized.
To create a production build, use yarn build.
```

## API Endpoints

The usage of API is really simple. It only exposes the resources **Order**, **Menu** and **Dish**.

### GET /order

Retrieve json with an array of order.  
| field | description |
| ------| ------------|
| id | id of order |
| dishes | collection of dishes, has same data retrieved on /dish |

This endpoint always returns `status 200`.

### POST /order

Adds a new order to database. Post data as json.  
| field | description |
| ------| ------------|
| timeOfDay | string containing "morning" or "night" |
| dishesTypes | An array with ids of dishes types to this order. They are _(1) Entree_, _(2) Side_, _(3) Drink_, _(4) Dessert_ |

PS: All the dishes in the order must have _timeOfDay_ equal to given _timeOfDay_, otherwise api is going to return status `400`.
PS2: Is not possible to add an order with dessert and timeOfDay morning, this is going to return status `400`, otherwise status is going to be `200`

## GET /menu

Returns json with id of menu and all dishes accepted.  
| field | description |
| ------| ------------|
| id | id of order |
| dishes | collection of dishes, has same data retrieved on /dish |

This endpoint always returns status `200`.

### GET /dish

Retrieve json with an array of all dishes.  
| field | description |
| ------| ------------|
| id | id of dish |
| timeOfDay | 0 or 1, 0 for morning and 1 for night |
| canBeOrderedMultipleTimes | true or false, indicates that dish can be ordered multiple times |
| description | string with description of dish, for example "Eggs" |

This endpoint always returns `status 200`.

## Backend Architectural Decisions

The backend was developed with .NET Core API because it was a requirement for this challenge. The project is splitted in some layers and is designed by the domain driven design principles.

### API layer

This api is the layer responsible to handle all the requests and responses from backend. This is the most top layer and the startup of the project.  
Resides in the API layer the dependency injection container configuration, configuration of database and configuration of the web service.  
The API Layer have dependencies with the layers of **domain**, **infra** and **service**.  
In the configuration of this project it is using in memory database, but is easy to change to another database since it is relying on the interface **IDatabase**, defined in **domain layer**, and is configured in the **dependency injection container** to resolve to **Database** implemented in **infra layer**.
The controllers of API are anemic, which means they does not have any kind of business logic, they only receive requests, pass it to the correct service at the **service** layer and return the response.  
Also the API relies on the **Unit of Work** pattern to ensure that data is only being saved to database when request ends. For that was created an attribute that decorate routes that are going to rely in some kind of persistence service. This filter have injected the **IDatabase** implementation and relies on it to commit any change made to database. You can have a good example of that looking to the _POST_ of **OrderController**.

### Domain Layer

This is the most important layer of the backend. Domain layer have all the interfaces definition and also all the entities of the project. This responsability is to abstract business rules from other layers, so all the business logic that relies at one entity is encapsulated in the entity itself.
It is totally decoupled from the other layers and if necessary to migrate the project to a new technology, this technology can be entirely built around the **domain layer** without lose business rules.
All the interfaces necessary to implement the **repository pattern** lives inside this layer. But only the interfaces, it does not have any implementation of repository.
Since this is a demo application, there is one factory inside **domain**, this factory is the _Menu Factory_ that returns a list of menu.

### Infra Layer

Infra layer knows the details of persistence. So it relies on **domain layer** to retrieve the interface of database that it implements. Is at infra layer that new database adapters should be implemented if needed to move from one database to another. Then is just point to this new database at API startup changing the configuration of dependency injection container.

### Service Layer

This is the layer of application service. It relies on **domain layer** to retrieve the repositories and services interfaces to implement it.  
Here is a good example of repositories that can return data from an object written in development time or get data from the database and, for that, uses the **IDatabase** interface defined on **domain layer** without even know that **infra layer** exists.  
The services implemented here abstracts the relationship between entities and relies in one or more repositories or services.

## Frontend architecture

The frontend architecture is more simple. It is a react + redux app, so there is no much to explain here since it is already well documented in react docs.

## Improvements

This is a demo aplication, so it is not production ready and some improvements would be made. They are:

- Implement a real SQL database, instead of in memory;
- Adds a Graphql layer between frontend and API, this speed up a lot the development process and also protect the API;
- The frontend designer can improve also, but since I'm not an UX professional I did not invest so much time on this;
- Adds a centralized cache to API, for example using Redis;
- Adds a load balancer in front of API;
- Since this api is already containerized it can be put on kubernetes cluster at production environment.
- The language itself. To be honestly, if it was not the requirement of this project I would study better the language and framework to do that. It is a simple API and the overhead of .NET do not pay that. Of course, as it grows, in a monolithic approach, .NET starts to be justified. A simple javascript + ApolloGraphql would be a better choice for this one and also would reduce the frontend development time.
