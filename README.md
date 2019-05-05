# Todos
Demo App demonstrating writing an API in F# with Giraffe and .NET Core

[![CircleCI](https://circleci.com/gh/rpmcdougall/FSharpTodos/tree/master.svg?style=svg)](https://circleci.com/gh/rpmcdougall/FSharpTodos/tree/master)

## Local Development Environment

- .NET Core 2.1+
- MongoDB

To install dependencies run:
```
dotnet restore
```

To start the applicaton:
```
dotnet run
```

## TODO

- [ ] Learn Testing for F#
- [ ] Figure out better error handling for Mongo DB connection (currently just times out, may be a limitation of the F# client)
- [x] Figure out dev/test/prod configuration
- [ ] Try deploying to a cloud service
