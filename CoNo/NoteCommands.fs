module NoteCommands

open Repository

let list (Notes notes) =
    let printNote note =
        printf "%A: %s\n" note.Id note.Note
    printf "\n"
    notes |> List.rev |> List.map printNote |> ignore
    printf "\n"

let stringsToNote strings =
    let note = strings |> List.reduce (fun r s -> r + " " + s)
    { EmptyNote with Note = note }

let write strings (Notes notes) =
    let note = stringsToNote strings
    let maxId = match notes with 
                | [] -> 0
                | _ -> (List.maxBy (fun n -> n.Id) notes).Id
    let notes' = Notes ({ note with Id = maxId + 1 }::notes)
    store notes'
    list notes'

let erase id (Notes notes) =
    let notes' = Notes (List.filter (fun n -> n.Id <> id) notes)
    store notes'
    list notes'

