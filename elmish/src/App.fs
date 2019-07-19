module ElmishApp

open Elmish

type Model =
  { name : string
    editing : string }

type Msg =
  | Greet of string
  | Editing of string

let init() =
  { name = "Fable"
    editing = "" }

// UPDATE
let update msg model =
  match msg with
  | Greet str -> { model with name = str }
  | Editing str -> { model with editing = str }

// VIEW
open Fable.React
open Fable.React.Props
open Fable.Core.JsInterop

let view model dispatch =
  div [] [ input [ Id "greeting"
                   Type "text"
                   Value model.editing
                   OnInput(fun ev ->
                     !!ev.target?value
                     |> Editing
                     |> dispatch)
                   AutoFocus true ]
           button [ OnClick(fun _ ->
                      model.editing
                      |> Greet
                      |> dispatch) ] [ str "Greet!" ]
           div [] [ str (sprintf "Hello, %s!" model.name) ] ]

open Elmish.React

Program.mkSimple init update view
|> Program.withConsoleTrace
|> Program.withReactSynchronous "elmish-app"
|> Program.run
