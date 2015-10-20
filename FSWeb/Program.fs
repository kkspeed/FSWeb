open System
open Suave
open Suave.Http
open Suave.Http.Applicatives
open Suave.Http.Successful
open Suave.Web

type MyWord = {word: string}

let app =
  choose [
    path "/home" >>= OK "Home"
    path "/template" >>= DotLiquid.page "base.html" {word = "Hello World!"}
    pathRegex "/static/.*\.(css|js|png)" >>= Files.browseHome
  ]

DotLiquid.setTemplatesDir (AppDomain.CurrentDomain.BaseDirectory + "templates")

startWebServer defaultConfig app
