namespace Successful

type NamedRecord = {
    Name : string
    TestType : string
}

module WithNamedRecord =
    let hello name =
        sprintf "Hello %A" { Name = name; TestType = "Named record"}
