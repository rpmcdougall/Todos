// Learn more about F# at http://fsharp.org
open FsharpTodos
open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Giraffe
open MongoDB.Driver
open Todos.Http
open TodoMongoDB
open Todos

let routes =
    choose [
        TodoHttp.handlers
    ]

let configureApp (app: IApplicationBuilder) =
    app.UseGiraffe routes
    

let configureServices (services: IServiceCollection) =
    let mongo = MongoClient(Environment.GetEnvironmentVariable "MONGO_URL")
    let db = mongo.GetDatabase "todos"
    services.AddGiraffe() |> ignore
    services.AddTodoMongoDB(db.GetCollection<Todo>("todos")) |> ignore
    

[<EntryPoint>]
let main _ =
    WebHostBuilder()
        .UseKestrel()
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(configureServices)
        .Build()
        .Run()
    0 // return an integer exit code
