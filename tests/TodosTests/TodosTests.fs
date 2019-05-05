module TodosTests

open System.Net.Http
open System.Text
open Microsoft.AspNetCore.TestHost
open Xunit
open Newtonsoft.Json
open HttpFunc
open Fixtures

[<Fact>]
let ``GET /todos should respond empty`` () =
    use server = new TestServer(createHost()) 
    use client = server.CreateClient()

    get client "todos"
    |> ensureSuccess
    |> readText
    |> shouldEqual "[]"


[<Fact>]
let ``POST /todos should add a new todo`` () =
    
    use server =  new TestServer(createHost()) 
    use client = server.CreateClient()
    let data = JsonConvert.SerializeObject(getTestTodoRequest)
    use content = new StringContent(data, Encoding.UTF8, "application/json");
    
    post client "todos" content
    |> ensureSuccess
    |> readText
    |> shouldContains "\"text\":\"This is a test todo\""
    
    
[<Fact>]
let ``DELETE /todos/$id should remove an added todo todo`` () =
    
    use server =  new TestServer(createHost()) 
    use client = server.CreateClient()
    let data = JsonConvert.SerializeObject(getTestTodoRequest)
    use content = new StringContent(data, Encoding.UTF8, "application/json");
    
    
    let res =
        post client "todos" content
        |> ensureSuccess
        |> readText
        |> deserializeTodo
        
    let path = "todos/" + res.id
    delete client path 
        |> ensureSuccess
        |> readText
        |> shouldContains "true"
    