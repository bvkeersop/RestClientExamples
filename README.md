# RestClientExamples

This repository demos different ways to implement REST clients for service-to-service communication.
See my blog post for detailed information.

The following implementations are demoed:
1. Creating a REST client using `Flurl`.
2. `Manually` creating a REST client.
3. Generating a REST client using `NSwag`.
4. Creating a REST client using `Refit`.
5. Creating a REST client using `RestEase`.
6. Creating a rest client using `RestSharp`.

You can open the solution in visual studio and run it, this will do the following:

1. Start the `RestClientExamples.ExampleApi`.
2. Start the `RestClientExamples.Cli`.
    - The `Cli` will make HTTP calls to the `ExampleApi` using the different types of clients.

Inside the `RestClientExamples` solution you will find the following:

## RestClientExamples.Cli

Contains a simple command line demo on how to use the clients.

## RestClientExamples.ExampleApi

Contains an ExampleApi with the default WeatherForecastController.

## RestClientExamples.ExampleApi.Models

Contains the Models used by the `ExampleApi`.

## RestClientExamples.Flurl

Shows how you can use [Flurl](https://github.com/tmenier/Flurl) to make HTTP requests.

## RestClientExamples.Manual

Shows how you can manually create a REST client using [typed clients](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#how-to-use-typed-clients-with-ihttpclientfactory).

## RestClientExamples.NSwag

Shows how you can leverage [NSwag](https://github.com/RicoSuter/NSwag) to automatically generate REST clients based on an openapi specification.

## RestClientExamples.Refit

Shows how you can leverage [Refit](https://github.com/reactiveui/refit) to generate a REST client using an interface.

## RestClientExamples.RestEase

Shows how you can use [RestEase](https://github.com/canton7/RestEase) to generate a REST client using an interface.

## RestClientExamples.RestSharp

Shows how you can use [RestSharp](https://github.com/restsharp/RestSharp) to make HTTP requests.