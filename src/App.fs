module HelloApp

open Fable.Import

let Greetings = "Hello, Fable!"

let content = Browser.document.getElementById "content"
content.innerHTML <- (sprintf "<h1>%s</h1>" Greetings)

Browser.window.console.log Greetings
