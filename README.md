# dotnet-boiler-api

C# .NET Api boiler plate

# Description

C# .NET Api boiler plate to kick off backend projects

## Requirements

- Git
- .NET 7 SDK

## Installation

Clone the repo, make it your own, install the dependencies and add remote

```bash
git https://github.com/fletch0098/dotnet-boiler-api
cd dotnet-boiler-api
```


```bash
rm -rf .git && git init
```

```bash
git remote add origin {REMOTE_URL}
```

```bash
dotnet build
```

## Settings

The apps settings all have defaults with no sensitive data.

  "AppName": "dotnet-boiler-api",
  "Urls": "http://localhost:5001",

## Starting the api

Start the api and recieve requests.

```bash
dotnet run
```

or in development mode

```bash
dotnet watch run
```

## Api Docs

Api is documented using swagger. You can view the documentation at /doc

## ATesting

## Roadmap

Some possible oppurtunities for enhacement in the future could be:

- Finish - AFinish this boiler

## Logs

## License

[GNU](https://choosealicense.com/licenses/gpl-3.0/)
