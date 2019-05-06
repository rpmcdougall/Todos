# Todos
Demo App demonstrating writing an API in F# with Giraffe and .NET Core

[![CircleCI](https://circleci.com/gh/rpmcdougall/Todos/tree/master.svg?style=svg)](https://circleci.com/gh/rpmcdougall/FSharpTodos/tree/master)

Note: I accidentally overwrote the git history with a force push. You can view past commits in closed PRs if you are curious [here](https://github.com/rpmcdougall/Todos/pulls?q=is%3Apr+is%3Aclosed).

## Local Development Environment

- .NET Core 2.1+
- MongoDB
  - Requires MONGO_URL environment variable for configuration. Ex. `mongodb://localhost:27017/`
  - [Local MongoDB Install](https://treehouse.github.io/installation-guides/mac/mongo-mac.html)

To install dependencies run:
```
dotnet restore
```

To start the applicaton:
```
MONGO_URL=mongodb://localhost:27017/ dotnet run --project Todos/
```

## TODO

- [ ] Learn Basic Testing Strategies for web apps in F#
    - [x]  [Integration Testing](https://github.com/rpmcdougall/Todos/blob/master/tests/TodosTests/TodosTests.fs) 
    - [ ] Unit Testing 
    - [ ] Property Testing 
- [ ] Figure out better error handling for Mongo DB connection (currently just times out, may be a limitation of the F# client)
- [x] Figure out basic environment management for dev/test/prod
- [ ] Try deploying to a cloud service (Azure or Heroku)
- [x] [Set up CI for automated builds/testing](https://github.com/rpmcdougall/Todos/blob/master/.circleci/config.yml)
- [ ] Provide more documentation
