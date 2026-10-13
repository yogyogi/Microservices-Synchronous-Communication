# Synchronous Communication between Microservices built in ASP.NET Core

<img src="https://www.yogihosting.com/wp-content/uploads/2026/10/ASP.NET-Core-Microservices-Synchronous-Communication.png" alt="Synchronous Communication between Microservices built in ASP.NET Core"  title="Synchronous Communication between Microservices built in ASP.NET Core">

In this tutorial we will build our second Microservice in ASP.NET Core. Then we will perform communication between the 2 Microservices in Synchronous way using HttpClient class. We will also look into Timeout Policy via Polly and Circuit Breaker Pattern. 

**Repository is updated to .NET 10.0

Read the entire article here - https://www.yogihosting.com/aspnet-core-microservice-synchronous-communication/

# Tutorial Contents

1. Creating ProcessCenter Microservice in ASP.NET Core
2. Data Transfer objects
3. MongoDB Connection String, Configuration, Repository and Settings
4. HttpClient class to communicate with First Microservice
5. Creating Web API Controller
6. Blazor Web APP: User Interface of Microservice
7. Adding ProcessCenter, PCUI, and MongoDB to Docker Compose
8. Testing Microservices Operations with PCUI (Blazor Web App)
9. Testing ProcessCenter Microservice with Swagger
10. Create records through Swagger
11. Read records through Swagger
12. Timeout Policy via Polly
13. Circuit Breaker Pattern

# How to run the app

You need to have Docker installed on your PC. Then in command prompt navigate to the directory of `docker-compose.yml` file and run the following 2 commands:

```
docker-compose build
docker-compose up -d
```

<img src="https://www.yogihosting.com/wp-content/uploads/2026/10/second-microservice-docker-compose.png" alt="Second ASP.NET Core Microservice Docker Compose"  title="Second ASP.NET Core Microservice Docker Compose">

Now access the PCUI project on the browser. It’s url being – `https://localhost:7001/`

<img src="https://www.yogihosting.com/wp-content/uploads/2026/10/processcenter-microservice-add-record.png" alt="ProcessCenter Microservice Add Record"  title="ProcessCenter Microservice Add Record">

Also access the Web API with Swagger. It's url being - https://localhost:6001/swagger

<img src="https://www.yogihosting.com/wp-content/uploads/2026/10/swagger-processcenter.png" alt="ProcessCenter Swagger"  title="ProcessCenter Swagger">

## Want to support me ?

Your support of every $5 will be a great reward for me to carry on my work. Thank you!

<a href="https://www.buymeacoffee.com/YogYogi" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/v2/default-yellow.png" alt="Buy Me A Coffee" width="200"  style="height: 60px !important;width: 200px !important;" ></a>
<a href="https://www.paypal.com/paypalme/yogihosting" target="_blank"><img src="https://raw.githubusercontent.com/yogyogi/yogyogi/main/paypal.png" alt="Paypal Me" width="300"></a>
