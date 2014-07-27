open Repository
open NoteCommands

[<EntryPoint>]
let main argv =
    let notes = load
    let note = {EmptyNote with Note = "blah"}

    match Array.toList argv with
    | [] -> list notes
    | head::_ when head.Equals "list" -> list notes
    | head::rest when head.Equals "write" -> write rest notes
    | head::rest when head.Equals "erase" -> 
        match rest with
        | [] -> printf "erase: must supply note id"
        | head::_ -> 
            match head with
            | Int id -> erase id notes
            | _ -> printf "erase: id must be integer"
    | _ -> printf "unknown command"
    |> ignore

    0 // return an integer exit code
