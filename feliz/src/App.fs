module ElmishApp

open Elmish

type Model =
  { name : string
    editing : string }

type Msg =
  | Greet
  | Editing of string

let init() =
  { name = "Fable"
    editing = "" }

// UPDATE
let update msg model =
  match msg with
  | Greet -> { model with 
                name = model.editing
                editing = ""
              }
  | Editing str -> { model with editing = str }

// VIEW
open Feliz
open Zanaptak.TypedCssClasses
type Bulma = CssClasses<"https://cdnjs.cloudflare.com/ajax/libs/bulma/0.7.4/css/bulma.min.css", Naming.PascalCase>
type FA = CssClasses<"https://use.fontawesome.com/releases/v5.8.1/css/all.css", Naming.PascalCase>

let title =
  Html.p [
    prop.className "title"
    prop.text "Greetings"
  ]
let newGreetingInput (currentName:string) dispatch =
  Html.div [
    prop.classes [Bulma.Field; Bulma.HasAddons]
    prop.children [
      Html.div [
        prop.classes [Bulma.Control; Bulma.IsExpanded]
        prop.children [
          Html.input[
            prop.classes [Bulma.Input]
            prop.valueOrDefault currentName
            prop.onKeyUp (fun ev -> if ev.keyCode = 13.0 then Greet |> dispatch)
            prop.onTextChange (Editing >> dispatch)
          ]
        ]
      ]
      Html.div [
        prop.classes [Bulma.Control]
        prop.children [
          Html.button [
            prop.classes [Bulma.Button; Bulma.IsPrimary]
            prop.onClick (fun _ -> Greet |> dispatch)
            prop.children [
              Html.i [prop.classes [FA.Fa; FA.FaExclamation]]
            ]
          ]
        ]
      ]
    ]
  ]

let greeting name dispatch =
  Html.p [
    prop.className Bulma.Heading
    prop.text (sprintf "Hello, %s!" name)
  ]

let view model dispatch =
  Html.div [
    prop.style [style.margin 10]
    prop.children [
      title
      newGreetingInput model.editing dispatch
      greeting model.name dispatch
    ]
  ] 
  
open Elmish.React

Program.mkSimple init update view
|> Program.withConsoleTrace
|> Program.withReactSynchronous "elmish-app"
|> Program.run
