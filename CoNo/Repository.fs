module Repository

open System.IO

let store (Notes notes) =
    File.WriteAllLines("CoNo.txt", notes |> List.map toJson<Note>)

let load =
    let notes = (File.ReadAllLines("CoNo.txt")) |> Array.map fromJson<Note> |> Array.toList
    Notes notes

