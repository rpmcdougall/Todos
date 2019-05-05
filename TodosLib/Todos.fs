namespace TodosLib

type Todo = {
    id: string
    text: string
    completed: bool
}

type TodoSave = Todo -> Todo

type TodoCriteria = | All

type TodoFind = TodoCriteria -> Todo[]

type TodoDelete = string -> bool