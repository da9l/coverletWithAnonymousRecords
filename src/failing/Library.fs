namespace Failing

module WithAnonymousRecord =
    let hello name =
        sprintf "Hello %A" {| Name = name; TestType = "Anonymous Record" |}
