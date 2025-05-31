module App

open Fable.Core
open Fable.Core.JsInterop
open Fable.Vue

// Using existing Vue components
[<JSX.Component>]
let HelloWorld (msg: string) : VNode =
    importDefault "@/components/HelloWorld.vue"


// Component per "file" pattern
let setup: SetupFunction<unit> =
    fun () ->
        let count = ref 0
        let increment () = count.value <- count.value + 1
        provide ("count", count)

        fun () ->
            h (
                "div",
                children =
                    [| h ("h1", children = "Hello, Vue!")
                       h ("p", children = $"Count: {count.value}")
                       h ("button", props = {| onClick = fun () -> increment () |}, children = "Increment")
                       h (HelloWorld("Hello Fable!")) |]
            )

exportDefault (Component.Create(setup = setup))
