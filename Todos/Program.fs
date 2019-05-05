// Learn more about F# at http://fsharp.org
module Todos.App


open TodosLib
open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Giraffe
open MongoDB.Driver
open TodosLib.Http
open TodosLib.TodoMongoDB
open TodosLib.TodoInMemory
open System.Collections

let routes =
    choose [
        TodoHttp.handlers
    ]

let configureApp (app: IApplicationBuilder) =
    app.UseGiraffe routes
    

let configureServices (services: IServiceCollection) =
    let env = services.BuildServiceProvider().GetService<IHostingEnvironment>()
    match env.IsEnvironment("Test") with
        |true ->
            let inMemory = Hashtable()
            services.AddGiraffe() |> ignore
            services.AddTodoInMemory(inMemory) |> ignore
        |false ->
            let mongo = MongoClient(Environment.GetEnvironmentVariable "MONGO_URL")
            let db = mongo.GetDatabase "todos"
            services.AddGiraffe() |> ignore
            services.AddTodoMongoDB(db.GetCollection<TodosLib.Todo>("todos")) |> ignore
            
[<EntryPoint>]
let main _ =
    WebHostBuilder()
        .UseKestrel()
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(configureServices)
        .Build()
        .Run()
    0 // return an integer exit code
    