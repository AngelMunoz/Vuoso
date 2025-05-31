module TextBased


open Fable.Core
open Fable.Core.JsInterop
open Fable.Vue

// Using existing Vue components
[<JSX.Component>]
let TextBased (counter: VueRef<int>) =
    let increment () = counter.value <- counter.value + 1
    let decrement () = counter.value <- counter.value - 1
    let reset () = counter.value <- 0

    JSX.jsx
        $"""
    <section>
        <p>This Component is defined using Fable JSX support (text based)</p>
        <p>Count: <span class="green bigger">{counter.value}</span></p>
        <button onClick={increment}>Increment</button>
        <button onClick={decrement}>Decrement</button>
        <button onClick={reset}>Reset</button>
    </section>
    """

// Component per "file" pattern
let setup: SetupFunction<unit> =
    fun () ->
        let count = ref 0
        fun () -> vuejsx (TextBased count)

exportDefault (Component.Create(setup = setup))
