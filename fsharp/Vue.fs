[<AutoOpen>]
module Fable.Vue

open System

open Fable.Core
open Fable.Core.JsInterop


type Record<'Key, 'Value> =

  [<Emit("$0[$1]")>]
  abstract Item: key: 'Key -> 'Value with get, set


type DebuggerEvent =
  abstract effect: obj
  abstract target: obj
  abstract ``type``: string
  abstract key: obj

type DebuggerHook = DebuggerEvent -> unit
type ErrorCapturedHook = (obj * obj * string) -> bool


type VueRef<'T> =
  abstract value: 'T with get, set

type VNode = interface end

type Slot = obj -> VNode

type Slots = Record<string, Slot>

type SetupFunction<'Props> = 'Props -> (unit -> VNode)


[<Erase; AutoOpen>]
type Vue =

  static member h(tag: string) : VNode = importMember "vue"
  static member h(tag: string, props: 'Props) : VNode = importMember "vue"
  static member h(tag: string, children: VNode) : VNode = importMember "vue"

  static member h(tag: string, props: 'Props, children: VNode) : VNode =
    importMember "vue"

  static member h(tag: string, [<ParamArray>] children: VNode[]) : VNode =
    importMember "vue"

  static member h
    (tag: string, props: 'Props, [<ParamArray>] children: VNode[])
    : VNode =
    importMember "vue"

  static member h(tag: string, children: Slot) : VNode = importMember "vue"

  static member h(tag: string, props: 'Props, children: Slot) : VNode =
    importMember "vue"

  static member h(tag: string, children: Slots) : VNode = importMember "vue"

  static member h(tag: string, props: 'Props, children: Slots) : VNode =
    importMember "vue"


  static member h(node: VNode) : VNode = importMember "vue"
  static member h(node: VNode, children: Slot) : VNode = importMember "vue"
  static member h(node: VNode, children: Slots) : VNode = importMember "vue"
  static member h(node: VNode, props: 'Props) : VNode = importMember "vue"

  static member h(node: VNode, props: 'Props, children: Slot) : VNode =
    importMember "vue"

  static member h(node: VNode, props: 'Props, children: Slots) : VNode =
    importMember "vue"

  static member inject<'T>(key: string, ?defaultValue: 'T) : 'T =
    importMember "vue"

  static member inject<'T>
    (key: string, defaultValue: unit -> 'T, treatValueAsFactory: bool)
    : 'T =
    importMember "vue"

  static member provide<'T>(key: string, value: 'T) : unit = importMember "vue"

let text(content: string) : VNode = emitJsExpr content "$0"
let number(content: float) : VNode = emitJsExpr content "$0"
let boolean(content: bool) : VNode = emitJsExpr content "$0"

let vuejsx(content: JSX.Element) : VNode = unbox content

let ref<'T>(initialValue: 'T) : VueRef<'T> = importMember "vue"

let onMounted(callback: unit -> unit) : unit = importMember "vue"

let onUpdated(callback: unit -> unit) : unit = importMember "vue"
let onUnmounted(callback: unit -> unit) : unit = importMember "vue"
let onBeforeMount(callback: unit -> unit) : unit = importMember "vue"
let onBeforeUpdate(callback: unit -> unit) : unit = importMember "vue"
let onBeforeUnmount(callback: unit -> unit) : unit = importMember "vue"
let onErrorCaptured(callback: ErrorCapturedHook) : unit = importMember "vue"
let onRenderTracked(callback: DebuggerHook) : unit = importMember "vue"
let onRenderTriggered(callback: DebuggerHook) : unit = importMember "vue"
let onActivated(callback: unit -> unit) : unit = importMember "vue"
let onDeactivated(callback: unit -> unit) : unit = importMember "vue"

[<Erase>]
type Component<'Props>
  [<ParamObject; Emit "$0">]
  (?props: string[], ?emits: string[], ?setup: Func<'Props, unit -> VNode>) =

  member val props: string[] = jsNative
  member val setup: Func<'Props, unit -> VNode> = jsNative


  static member inline Create
    (setup: 'Props -> unit -> VNode, ?props: string seq, ?emits: string seq)
    =
    Component<'Props>(
      ?props = (props |> Option.map Array.ofSeq),
      ?emits = (emits |> Option.map Array.ofSeq),
      setup = Func<_, _> setup
    )
