module Tests

open System
open Xunit

[<Fact>]
let ``Anonymous record`` () =
    let result = Failing.WithAnonymousRecord.hello "Bob"
    Assert.Equal("Hello { Name = \"Bob\"\n  TestType = \"Anonymous Record\" }", result)

[<Fact>]
let ``Named record`` () =
    let result = Successful.WithNamedRecord.hello "Bob"
    Assert.Equal("Hello { Name = \"Bob\"\n  TestType = \"Named record\" }", result)
