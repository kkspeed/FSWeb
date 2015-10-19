#r "packages/FAKE/tools/FakeLib.dll"

open Fake

let buildDir = "./build/"

Target "Clean" (fun _ ->
    CleanDir buildDir
)

Target "Web" (fun _ ->
    !! "FSWeb/*.fsproj"
    |> MSBuildRelease buildDir "Build"
    |> ignore
)

Target "Default" (fun _ ->
    trace "Deploy"
)

"Clean" ==> "Web" ==> "Default"

RunTargetOrDefault "Default"
