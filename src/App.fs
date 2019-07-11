module HelloApp

open Browser

let Greetings = "Hello, Fable!"

let content = Dom.document.getElementById "content"
content.innerHTML <- (sprintf "<h1>%s</h1>" Greetings)

Dom.console.log Greetings
