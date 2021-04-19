# Reproduce Instrumentation error with FSharp Anonymous Records

When one use fsharp anonymous records

```fsharp
let hello name =
    sprintf "Hello %A" {| Name = name; TestType = "Anonymous Record" |}
```

The code coverage analysis tool [Coverlet](https://github.com/coverlet-coverage/coverlet) fails to instrument the resulting assembly.

If one use [JetBrains dotpeek](https://www.jetbrains.com/decompiler/) to decompile the assembly
and select Metadata->Portable PDB Metadata, right click "Show PDB Metadata"

It can be seen that there is a reference to the file "unknown".

Coverlet fails to Instrument the assembly due to this.

To run the tests with coverlet:

```powershell
PS>dotnet test /p:CollectCoverage=true
```

Expected result:
Show coverage for both libraries failing and successful.

Actual result:
Show coverage for only successful.


```xml
<Document Index="1" DocumentType="Text" Language="F#" LanguageVendor="Microsoft">C:\Projects\CoverletUnknowsSrcFileInstrumentationError\src\failing\Library.fs</Document>
<Document Index="2" DocumentType="Text" Language="F#" LanguageVendor="Microsoft">C:\Projects\CoverletUnknowsSrcFileInstrumentationError\src\failing\unknown</Document>
```

```xml
<Type Name="&lt;&gt;f__AnonymousType2220235920`2">
  <File>C:\Projects\CoverletUnknowsSrcFileInstrumentationError\src\failing\unknown</File>
</Type>
```