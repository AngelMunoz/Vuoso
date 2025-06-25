module Main

open Fable.Core.JsInterop
open Fable.Vue

importSideEffects "./assets/main.css"

let App: obj = importDefault "./App.fs"

Vue.createApp(App).mount("#app")
