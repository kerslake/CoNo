[<AutoOpen>]
module Common

open System.IO
open System.Runtime.Serialization.Json
open System.Text
open System.Xml

let toJson<'t> (myObj:'t) =   
    use ms = new MemoryStream() 
    (new DataContractJsonSerializer(typeof<'t>)).WriteObject(ms, myObj) 
    Encoding.Default.GetString(ms.ToArray())

let fromJson<'t> (jsonString:string) : 't =  
    use ms = new MemoryStream(ASCIIEncoding.Default.GetBytes(jsonString)) 
    let obj = (new DataContractJsonSerializer(typeof<'t>)).ReadObject(ms) 
    obj :?> 't

let (|Int|_|) str =
   match System.Int32.TryParse(str) with
   | (true,int) -> Some(int)
   | _ -> None