[<AutoOpen>]
module DomainTypes

type Note = { Id : int; Note: string}
type Notebook = Notes of Note list

let EmptyNote = { Id = 0; Note = "" }
let EmptyNotebook = Notes []

