# Lab Polly Framework 

> Polly is a resilience framework for .NET available as a .NET Standard Library so it can run on your web services, desktop apps, mobile apps and inside your containers—anywhere .NET can run. 

## Usage

Change the access method from the request Controller:

    //var response = await _clientPolicy.ImmediateHttpRetry.ExecuteAsync(
    //var response = await _clientPolicy.LinearHttpRetry.ExecuteAsync(    
    //var response = await _clientPolicy.ExponentialHttpRetry.ExecuteAsync(

## Service
```
cd ResponseService

# Run app
dotnet run
```

## Request
```
cd RequestService

# Run app
dotnet run
```

If there's any conflict with ports, you might want to use dotnet run --urls="http://localhost:5010" to change the default port in one of the applications.

- Version: 1.0.0
- Credit: Les Jackson