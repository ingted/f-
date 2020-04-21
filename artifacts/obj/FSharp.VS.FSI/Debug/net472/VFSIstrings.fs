// This is a generated file; the original input is 'VFSIstrings.txt'
namespace VFSIstrings

open Microsoft.FSharp.Core.LanguagePrimitives.IntrinsicOperators
open Microsoft.FSharp.Reflection
open System.Reflection
// (namespaces below for specific case of using the tool to compile FSharp.Core itself)
open Microsoft.FSharp.Core
open Microsoft.FSharp.Core.Operators
open Microsoft.FSharp.Text
open Microsoft.FSharp.Collections
open Printf

type internal SR private() =

    // BEGIN BOILERPLATE

    static let getCurrentAssembly () = System.Reflection.Assembly.GetExecutingAssembly()

    static let getTypeInfo (t: System.Type) = t

    static let resources = lazy (new System.Resources.ResourceManager("VFSIstrings", getCurrentAssembly()))

    static let GetString(name:string) =
        let s = resources.Value.GetString(name, System.Globalization.CultureInfo.CurrentUICulture)
    #if DEBUG
        if null = s then
            System.Diagnostics.Debug.Assert(false, sprintf "**RESOURCE ERROR**: Resource token %s does not exist!" name)
    #endif
        s

    static let mkFunctionValue (tys: System.Type[]) (impl:obj->obj) = 
        FSharpValue.MakeFunction(FSharpType.MakeFunctionType(tys.[0],tys.[1]), impl)

    static let funTyC = typeof<(obj -> obj)>.GetGenericTypeDefinition()  

    static let isNamedType(ty:System.Type) = not (ty.IsArray ||  ty.IsByRef ||  ty.IsPointer)
    static let isFunctionType (ty1:System.Type)  =
        isNamedType(ty1) && getTypeInfo(ty1).IsGenericType && (ty1.GetGenericTypeDefinition()).Equals(funTyC)

    static let rec destFunTy (ty:System.Type) =
        if isFunctionType ty then
            ty, ty.GetGenericArguments() 
        else
            match getTypeInfo(ty).BaseType with 
            | null -> failwith "destFunTy: not a function type"
            | b -> destFunTy b 

    static let buildFunctionForOneArgPat (ty: System.Type) impl =
        let _,tys = destFunTy ty
        let rty = tys.[1]
        // PERF: this technique is a bit slow (e.g. in simple cases, like 'sprintf "%x"')
        mkFunctionValue tys (fun inp -> impl rty inp)

    static let capture1 (fmt:string) i args ty (go : obj list -> System.Type -> int -> obj) : obj =
        match fmt.[i] with
        | '%' -> go args ty (i+1)
        | 'd'
        | 'f'
        | 's' -> buildFunctionForOneArgPat ty (fun rty n -> go (n :: args) rty (i+1))
        | _ -> failwith "bad format specifier"

    // newlines and tabs get converted to strings when read from a resource file
    // this will preserve their original intention
    static let postProcessString (s : string) =
        s.Replace("\\n","\n").Replace("\\t","\t").Replace("\\r","\r").Replace("\\\"", "\"")

    static let createMessageString (messageString : string) (fmt : Printf.StringFormat<'T>) : 'T =
        let fmt = fmt.Value // here, we use the actual error string, as opposed to the one stored as fmt
        let len = fmt.Length 

        /// Function to capture the arguments and then run.
        let rec capture args ty i =
            if i >= len ||  (fmt.[i] = '%' && i+1 >= len) then
                let b = new System.Text.StringBuilder()
                b.AppendFormat(messageString, [| for x in List.rev args -> x |]) |> ignore
                box(b.ToString())
            // REVIEW: For these purposes, this should be a nop, but I'm leaving it
            // in incase we ever decide to support labels for the error format string
            // E.g., "<name>%s<foo>%d"
            elif System.Char.IsSurrogatePair(fmt,i) then
                capture args ty (i+2)
            else
                match fmt.[i] with
                | '%' ->
                    let i = i+1
                    capture1 fmt i args ty capture
                | _ ->
                    capture args ty (i+1)

        (unbox (capture [] (typeof<'T>) 0) : 'T)

    static let mutable swallowResourceText = false

    static let GetStringFunc((messageID : string),(fmt : Printf.StringFormat<'T>)) : 'T =
        if swallowResourceText then
            sprintf fmt
        else
            let mutable messageString = GetString(messageID)
            messageString <- postProcessString messageString
            createMessageString messageString fmt

    /// If set to true, then all error messages will just return the filled 'holes' delimited by ',,,'s - this is for language-neutral testing (e.g. localization-invariant baselines).
    static member SwallowResourceText with get () = swallowResourceText
                                        and set (b) = swallowResourceText <- b
    // END BOILERPLATE

    /// Cannot create window F# Interactive ToolWindow
    /// (Originally from VFSIstrings.txt:3)
    static member cannotCreateToolWindow() = (GetStringFunc("cannotCreateToolWindow",",,,") )
    /// Exception raised when creating remoting client for launched fsi.exe\n%s
    /// (Originally from VFSIstrings.txt:4)
    static member exceptionRaisedWhenCreatingRemotingClient(a0 : System.String) = (GetStringFunc("exceptionRaisedWhenCreatingRemotingClient",",,,%s,,,") a0)
    /// Exception raised when requesting FSI ToolWindow.\n%s
    /// (Originally from VFSIstrings.txt:5)
    static member exceptionRaisedWhenRequestingToolWindow(a0 : System.String) = (GetStringFunc("exceptionRaisedWhenRequestingToolWindow",",,,%s,,,") a0)
    /// Could not load F# language service
    /// (Originally from VFSIstrings.txt:6)
    static member couldNotObtainFSharpLS() = (GetStringFunc("couldNotObtainFSharpLS",",,,") )
    /// Session termination detected. Press Enter to restart.
    /// (Originally from VFSIstrings.txt:7)
    static member sessionTerminationDetected() = (GetStringFunc("sessionTerminationDetected",",,,") )
    /// F# Interactive
    /// (Originally from VFSIstrings.txt:8)
    static member fsharpInteractive() = (GetStringFunc("fsharpInteractive",",,,") )
    /// Could not find fsi.exe, the F# Interactive executable.\nThis file does not exist:\n\n%s\n
    /// (Originally from VFSIstrings.txt:9)
    static member couldNotFindFsiExe(a0 : System.String) = (GetStringFunc("couldNotFindFsiExe",",,,%s,,,") a0)
    /// Killing process raised exception:\n%s
    /// (Originally from VFSIstrings.txt:10)
    static member killingProcessRaisedException(a0 : System.String) = (GetStringFunc("killingProcessRaisedException",",,,%s,,,") a0)
    /// The current F# Interactive session is not configured for debugging. For the best experience, enable debugging in F# Interactive settings, then reset the session.\n\nAttempt debugging with current settings?
    /// (Originally from VFSIstrings.txt:11)
    static member sessionIsNotDebugFriendly() = (GetStringFunc("sessionIsNotDebugFriendly",",,,") )
    /// Don't show this warning again
    /// (Originally from VFSIstrings.txt:12)
    static member doNotShowWarningInFuture() = (GetStringFunc("doNotShowWarningInFuture",",,,") )

    /// Call this method once to validate that all known resources are valid; throws if not
    static member RunStartupValidation() =
        ignore(GetString("cannotCreateToolWindow"))
        ignore(GetString("exceptionRaisedWhenCreatingRemotingClient"))
        ignore(GetString("exceptionRaisedWhenRequestingToolWindow"))
        ignore(GetString("couldNotObtainFSharpLS"))
        ignore(GetString("sessionTerminationDetected"))
        ignore(GetString("fsharpInteractive"))
        ignore(GetString("couldNotFindFsiExe"))
        ignore(GetString("killingProcessRaisedException"))
        ignore(GetString("sessionIsNotDebugFriendly"))
        ignore(GetString("doNotShowWarningInFuture"))
        ()
