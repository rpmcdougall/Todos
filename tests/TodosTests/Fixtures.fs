module Fixtures

open System.Net.Http
open System.Text
open Microsoft.AspNetCore.TestHost
open Xunit
open Newtonsoft.Json
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open System
open System.IO
open HttpFunc
open TodosLib
open Todos
open Giraffe

type testTodoRequest =
    {
        Text: string
    }

let getTestTodoRequest : testTodoRequest =
    {
        Text = "This is a test todo"
    }


let shouldContains actual expected = Assert.Contains(actual, expected)
let shouldEqual expected actual = Assert.Equal(expected, actual)
let shouldNotNull expected = Assert.NotNull(expected)

let createHost() =
    WebHostBuilder()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseEnvironment("Test")
        .Configure(Action<IApplicationBuilder> App.configureApp)
        .ConfigureServices(Action<IServiceCollection> App.configureServices)
