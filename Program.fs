// Learn more about F# at http://fsharp.org
open FsharpTodos
open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Giraffe
open Todos.Http
open TodoInMemory
open System.Collections

let routes =
    choose [
        TodoHttp.handlers
    ]

let configureApp (app: IApplicationBuilder) =
    app.UseGiraffe routes
    

let configureServices (services: IServiceCollection) =
    services.AddGiraffe() |> ignore
    services.AddTodoInMemory(Hashtable()) |> ignore

[<EntryPoint>]
let main _ =
    WebHostBuilder()
        .UseKestrel()
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(configureServices)
        .Build()
        .Run()
    0 // return an integer exit code
