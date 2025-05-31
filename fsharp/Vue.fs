[<AutoOpen>]
module Fable.Vue

open System

open Fable.Core
open Fable.Core.JsInterop

type DebuggerEvent =
    abstract effect: obj
    abstract target: obj
    abstract ``type``: string
    abstract key: obj

type DebuggerHook = DebuggerEvent -> unit
type ErrorCapturedHook = (obj * obj * string) -> bool

[<Erase>]
type VueRef<'T> = { mutable value: 'T }

[<Erase>]
type VNode = interface end

[<Erase>]
type Slot = unit -> obj

[<Erase>]
type Slots = Map<string, Slot>

[<Erase; AutoOpen>]
type Vue =

    static member h<'Props>(tag: string, ?props: 'Props, ?children: VNode) : VNode = importMember "vue"
    static member h<'Props>(tag: string, ?props: 'Props, ?children: VNode[]) : VNode = importMember "vue"
    static member h<'Props>(tag: string, ?props: 'Props, ?children: obj) : VNode = importMember "vue"
    static member h<'Props>(tag: string, ?props: 'Props, ?children: obj[]) : VNode = importMember "vue"
    static member h(node: VNode) : VNode = importMember "vue"

    static member inject<'T>(key: string, ?defaultValue: 'T) : 'T = importMember "vue"
    static member inject<'T>(key: string, defaultValue: unit -> 'T, treatValueAsFactory: bool) : 'T = importMember "vue"

let ref<'T> (initialValue: 'T) : VueRef<'T> = importMember "vue"

let onMounted (callback: unit -> unit) : unit = importMember "vue"

let onUpdated (callback: unit -> unit) : unit = importMember "vue"
let onUnmounted (callback: unit -> unit) : unit = importMember "vue"
let onBeforeMount (callback: unit -> unit) : unit = importMember "vue"
let onBeforeUpdate (callback: unit -> unit) : unit = importMember "vue"
let onBeforeUnmount (callback: unit -> unit) : unit = importMember "vue"
let onErrorCaptured (callback: ErrorCapturedHook) : unit = importMember "vue"
let onRenderTracked (callback: DebuggerHook) : unit = importMember "vue"
let onRenderTriggered (callback: DebuggerHook) : unit = importMember "vue"
let onActivated (callback: unit -> unit) : unit = importMember "vue"
let onDeactivated (callback: unit -> unit) : unit = importMember "vue"



[<Erase>]
type Component<'Props> [<ParamObject; Emit "$0">] (?props: string[], ?setup: Func<'Props, unit -> VNode>) =

    member val props: string[] = jsNative
    member val setup: Func<'Props, unit -> VNode> = jsNative


    static member inline Create(setup: 'Props -> unit -> VNode, ?props: string seq) =
        Component<'Props>(?props = (props |> Option.map Array.ofSeq), setup = Func<_, _> setup)
