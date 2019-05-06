# Todos
Demo App demonstrating writing an API in F# with Giraffe and .NET Core

[![CircleCI](https://circleci.com/gh/rpmcdougall/Todos/tree/master.svg?style=svg)](https://circleci.com/gh/rpmcdougall/FSharpTodos/tree/master)

Note: I accidentally overwrote the git history with a force push. You can view past commits in closed PRs if you are curious [here](https://github.com/rpmcdougall/Todos/pulls?q=is%3Apr+is%3Aclosed).

## Local Development Environment

- .NET Core 2.1+
- MongoDB
  -Requires MONGO_URL environment variable for configuration. Ex. `mongodb://localhost:27017/`

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
