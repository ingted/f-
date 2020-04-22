// <auto-generated>

namespace Microsoft.VisualStudio.FSharp.Editor

open System.Reflection

module internal SR =
    type private C (_dummy:System.Object) = class end
    let mutable Culture = System.Globalization.CultureInfo.CurrentUICulture
    let ResourceManager = new System.Resources.ResourceManager("FSharp.Editor", C(null).GetType().GetTypeInfo().Assembly)
    let GetString(name:System.String) : System.String = ResourceManager.GetString(name, Culture)
    let GetObject(name:System.String) : System.Object = ResourceManager.GetObject(name, Culture)

    /// <summary>Add 'new' keyword</summary>
    let AddNewKeyword() = GetString("AddNewKeyword")

    /// <summary>Implement interface</summary>
    let ImplementInterface() = GetString("ImplementInterface")

    /// <summary>Implement interface without type annotation</summary>
    let ImplementInterfaceWithoutTypeAnnotation() = GetString("ImplementInterfaceWithoutTypeAnnotation")

    /// <summary>Prefix '{0}' with underscore</summary>
    let PrefixValueNameWithUnderscore() = GetString("PrefixValueNameWithUnderscore")

    /// <summary>Rename '{0}' to '_'</summary>
    let RenameValueToUnderscore() = GetString("RenameValueToUnderscore")

    /// <summary>Simplify name</summary>
    let SimplifyName() = GetString("SimplifyName")

    /// <summary>Name can be simplified.</summary>
    let NameCanBeSimplified() = GetString("NameCanBeSimplified")

    /// <summary>F# Functions / Methods</summary>
    let FSharpFunctionsOrMethodsClassificationType() = GetString("FSharpFunctionsOrMethodsClassificationType")

    /// <summary>F# Mutable Variables / Reference Cells</summary>
    let FSharpMutableVarsClassificationType() = GetString("FSharpMutableVarsClassificationType")

    /// <summary>F# Printf Format</summary>
    let FSharpPrintfFormatClassificationType() = GetString("FSharpPrintfFormatClassificationType")

    /// <summary>F# Properties</summary>
    let FSharpPropertiesClassificationType() = GetString("FSharpPropertiesClassificationType")

    /// <summary>F# Disposable Types</summary>
    let FSharpDisposablesClassificationType() = GetString("FSharpDisposablesClassificationType")

    /// <summary>Remove unused open declarations</summary>
    let RemoveUnusedOpens() = GetString("RemoveUnusedOpens")

    /// <summary>Open declaration can be removed.</summary>
    let UnusedOpens() = GetString("UnusedOpens")

    /// <summary>IntelliSense</summary>
    let _6008() = GetString("6008")

    /// <summary>QuickInfo</summary>
    let _6009() = GetString("6009")

    /// <summary>Add an assembly reference to '{0}'</summary>
    let AddAssemblyReference() = GetString("AddAssemblyReference")

    /// <summary>Add a project reference to '{0}'</summary>
    let AddProjectReference() = GetString("AddProjectReference")

    /// <summary>Code Fixes</summary>
    let _6010() = GetString("6010")

    /// <summary>Performance</summary>
    let _6011() = GetString("6011")

    /// <summary>Advanced</summary>
    let _6012() = GetString("6012")

    /// <summary>CodeLens</summary>
    let _6013() = GetString("6013")

    /// <summary>Formatting</summary>
    let _6014() = GetString("6014")

    /// <summary>The value is unused</summary>
    let TheValueIsUnused() = GetString("TheValueIsUnused")

    /// <summary>Cannot determine the symbol under the caret</summary>
    let CannotDetermineSymbol() = GetString("CannotDetermineSymbol")

    /// <summary>Cannot navigate to the requested location</summary>
    let CannotNavigateUnknown() = GetString("CannotNavigateUnknown")

    /// <summary>Locating the symbol under the caret...</summary>
    let LocatingSymbol() = GetString("LocatingSymbol")

    /// <summary>Navigating to symbol...</summary>
    let NavigatingTo() = GetString("NavigatingTo")

    /// <summary>Navigate to symbol failed: {0}</summary>
    let NavigateToFailed() = GetString("NavigateToFailed")

    /// <summary>Exceptions:</summary>
    let ExceptionsHeader() = GetString("ExceptionsHeader")

    /// <summary>Generic parameters:</summary>
    let GenericParametersHeader() = GetString("GenericParametersHeader")

    /// <summary>Rename '{0}' to '__'</summary>
    let RenameValueToDoubleUnderscore() = GetString("RenameValueToDoubleUnderscore")