module TextBased


open Fable.Core
open Fable.Core.JsInterop
open Fable.Vue


// Component per "file" pattern
let setup: SetupFunction<unit> =
  fun () ->
    let counter = ref 0

    // setup requires a render function when not using .vue files
    fun () ->
      let increment() = counter.value <- counter.value + 1
      let decrement() = counter.value <- counter.value - 1
      let reset() = counter.value <- 0

      jsx
        $"""
        <section>
            <p>This Component is defined using Fable JSX support (text based)</p>
            <p>Count: <span class="green bigger">{counter.value}</span></p>
            <button onClick={increment}>Increment</button>
            <button onClick={decrement}>Decrement</button>
            <button onClick={reset}>Reset</button>
        </section>
        """

exportDefault(Component.Create(setup = setup))
