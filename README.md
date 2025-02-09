# LoggingMicroService

The aim of this project is to have a microservice able to write log messages from external services to a text file. 
This microservice is built as a web API exposing one endpoint called /Log.

The messages that can be sent to this API must be in a JSON format following the following structure :

{
  "id": integer,
  "text": string of maximum 255 characters,
  "date": "yyyy-mm-dd"
}

A Log folder will be created with two log files.
One is for the message sent by external services and the other is for the log of the current service.
The date of the current day will be added to the file and there will be a new one created everyday.

## Running the application

Please make sure you have the prequisites installed:

.net sdk: 9.0.102

### Test coverage

```
dotnet test
```

### Docker

The main service project contains a docker file located at LoggingMicroService/Dockerfile.

This Dockerfile has been configured to run using the development environment to make swagger usable.

#### Development deployment
```
docker build -t logging_micro_service .
docker run -it --rm -p 8080:8080 --name logging_micro_service_sample logging_micro_service
```
