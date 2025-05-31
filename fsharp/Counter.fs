module Counter

open Fable.Core
open Fable.Core.JsInterop
open Fable.Vue

let Counter (initial: int, counter: VueRef<int>) =
    let increment () = counter.value <- counter.value + 1
    let decrement () = counter.value <- counter.value - 1
    let reset () = counter.value <- 0

    h (
        "section",
        {| style =
            {| padding = "20px"
               border = "1px solid hsla(160, 100%, 37%, 1)" |} |},
        h ("p", None, text "This Counter is an F# defined component taking 'initial' as a prop"),
        h ("p", None, text "Count: ", h ("span", {| ``class`` = [| "green"; "bigger" |] |}, number counter.value)),
        h ("button", {| onClick = fun () -> increment () |}, text "Increment"),
        h ("button", {| onClick = fun () -> decrement () |}, text "Decrement"),
        h ("button", {| onClick = fun () -> reset () |}, text "Reset")
    )

type CounterProps =
    abstract initial: int

let setup: SetupFunction<CounterProps> =
    fun props ->
        let count = ref props.initial

        onMounted (fun () -> printfn "Counter component mounted")

        fun () -> Counter(props.initial, count)

exportDefault (Component.Create(setup = setup, props = [ "initial" ]))
