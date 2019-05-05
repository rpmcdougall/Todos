module TodosLib.TodoMongoDB

open TodosLib
open MongoDB.Driver
open Microsoft.Extensions.DependencyInjection

let find (collection : IMongoCollection<Todo>) (criteria : TodoCriteria) : Todo [] =
    match criteria with
    | TodoCriteria.All -> collection.Find(Builders.Filter.Empty).ToEnumerable()
                          |> Seq.toArray
                          
let save (collection : IMongoCollection<Todo>) (todo : Todo) : Todo =
  let todos = collection.Find(fun x -> x.id = todo.id).ToEnumerable()

  match Seq.isEmpty todos with
  | true -> collection.InsertOne todo
  | false ->
    let filter = Builders<Todo>.Filter.Eq((fun x -> x.id), todo.id)
    let update =
      Builders<Todo>.Update
        .Set((fun x -> x.text), todo.text)
        .Set((fun x -> x.completed), todo.completed)

    collection.UpdateOne(filter, update) |> ignore

  todo
  
let delete (collection : IMongoCollection<Todo>) (id : string) : bool =
  collection.DeleteOne(Builders<Todo>.Filter.Eq((fun x-> x.id), id)).DeletedCount > 0L
  
type IServiceCollection with
  member this.AddTodoMongoDB(collection : IMongoCollection<Todo>) =
    this.AddSingleton<TodoFind>(find collection) |> ignore
    this.AddSingleton<TodoSave>(save collection) |> ignore
    this.AddSingleton<TodoDelete>(delete collection) |> ignore