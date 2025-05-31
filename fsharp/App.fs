module App

open Fable.Core
open Fable.Core.JsInterop
open Fable.Vue

// Using existing Vue components
[<JSX.Component>]
let HelloWorld (msg: string) : VNode =
    importDefault "@/components/HelloWorld.vue"

let App (count: VueRef<int>) =
    let increment () = count.value <- count.value + 1

    h (
        "div",
        {| id = "app" |},
        h ("h1", {| ``class`` = "green" |}, text "This is the Root component, defined in F#"),
        h ("p", None, text $"Count:", h ("span", {| ``class`` = [| "green"; "bigger" |] |}, number count.value)),
        h ("button", {| onClick = fun () -> increment () |}, text "Increment"),
        h (HelloWorld("Hello Fable!"))
    )

// Component per "file" pattern
let setup: SetupFunction<unit> =
    fun () ->
        let count = ref 0
        provide ("count", count)

        fun () -> App(count)

exportDefault (Component.Create(setup = setup))
