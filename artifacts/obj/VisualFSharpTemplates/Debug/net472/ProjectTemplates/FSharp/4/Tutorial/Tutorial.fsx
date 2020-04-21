// 此示例将引导你了解 F# 语言的各个元素。
//
// *******************************************************************************************************
//   若要在 F# 交互窗口中执行代码，请突出显示一个代码节并按 Alt-Enter 或右击
//   并选择“在 Interactive 中执行”。  可从“视图”菜单中打开 F# 交互窗口。
// *******************************************************************************************************
//
// 有关 F# 的详细信息，请参见:
//     https://fsharp.org
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/
//
// 若要以文档的形式查看此教程，请参阅:
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/tour
//
// 若要了解有关已应用的 F# 编程的详细信息，请使用
//     https://fsharp.org/guides/enterprise/
//     https://fsharp.org/guides/cloud/
//     https://fsharp.org/guides/web/
//     https://fsharp.org/guides/data-science/
//
// 若要安装 Visual F# Power Tools，请使用
//     “工具”-->“扩展和更新”-->“联机”和搜索
//
// 有关要用于 F# 的其他模板，请参见 Visual Studio 中的“联机模板”，
//     “新建项目”-->“联机模板”

// F# 支持三种注释:

//  1. 双斜线注释。  此类注释用于大多数情况。
(*  2. ML 样式块注释。此类注释不经常使用。 *)
/// 3. 三斜线注释。此类注释用于记录功能和类型等。
///    光标悬停在附带有注释的位置时，这些注释会以文本形式显示。
///
///    它们还支持 .NET 样式的 XML 注释，这些注释可生成参考文档，
///    还可允许编辑器(例如 Visual Studio)从其中提取信息。
///    有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/xml-documentation


// 使用 "open" 关键字打开命名空间。
//
// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/import-declarations-the-open-keyword
open System


/// 模块是值、类型和函数值等 F# 代码的分组。
/// 用模块分组代码有助于汇集相关代码和避免程序中出现名称冲突。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/modules
module IntegersAndNumbers =

    /// 此为示例整数。
    let sampleInteger = 176

    /// 此为示例浮点数。
    let sampleDouble = 4.1

    /// 这按照某种运算方法计算新的数字。数字类型通过
    /// "int"、"double" 等函数进行转换。
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    /// 这是从 0 到 99 的数字列表
    let sampleNumbers = [ 0 .. 99 ]

    /// 这是包含从 0 到 99 的所有数字及其平方的所有元组的列表.
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // 下一行打印包含元组的列表，使用 "%A" 来进行一般打印。
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfSquares

    // 这是一个具有类型注释的示例整数
    let sampleInteger3: int = 1


/// F# 中的值默认为不可变。程序执行过程中
/// 这些值无法更改，除非被显式标记为可变。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/values/index#why-immutable
module Immutability =

    /// 通过 "let" 将值绑定到名称可使其不可变。
    ///
    /// 未能编译第二行代码，因为 "number" 不可变且已绑定。
    /// F# 中不允许将 "number" 重定义为其他值。
    let number = 2
    // let number = 3

    /// 一个可变绑定。必须提供这种绑定才能改变 "otherNumber" 的值。
    let mutable otherNumber = 2

    printfn "'otherNumber' is %d" otherNumber

    // 若要改变值，请使用 "<-" 分配新值。
    //
    // 在这里不能将 "=" 用作此目的，因为该符号用于表示等式
    // 或者 "let" 或 "module" 等其他上下文
    otherNumber <- otherNumber + 1

    printfn "'otherNumber' changed to be %d" otherNumber


/// 大部分 F# 编程包括定义函数，该函数转换输入数据以生成
/// 有用的结果。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/functions/
module BasicFunctions =

    /// 可使用 "let" 定义函数。它将接受整数参数，然后返回整数。
    /// 括号对函数参数是可选的，但使用显示类型注释时除外。
    let sampleFunction1 x = x*x + 3

    /// 应用函数，并使用“let”命名函数返回结果。
    /// 变量类型是从函数返回类型推导出来的。
    let result1 = sampleFunction1 4573

    // 该行用 "%d" 将结果作为整数进行打印。这属于类型安全。
    // 如果 "result1" 不是类型 "int"，则将无法编译该行。
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    /// 如有需要，可使用 "(argument:type)" 批注参数名称类型。括号是必需的。
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn "The result of applying the 2nd sample function to (7 + 4) is %d" result2

    /// 条件语句使用 if/then/elid/elif/else。
    ///
    /// 注意，F# 使用可识别空格缩进的语法，与 Python 等语言类似。
    let sampleFunction3 x =
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)

    // 此行使用 "%f" 将结果作为浮点打印。与上述 "%d" 情况一样，属于类型安全。
    printfn "The result of applying the 3rd sample function to (6.5 + 4.5) is %f" result3


/// 布尔是 F# 中的基本数据类型。下面是一些布尔值和条件逻辑示例。
///
/// 有关详细信息，请参阅:
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/primitive-types
///     和
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/symbol-and-operator-reference/boolean-operators
module Booleans =

    /// 布尔值为 "true" 和 "false"。
    let boolean1 = true
    let boolean2 = false

    /// 布尔运算符为 "not"、"&&" 和 "||"。
    let boolean3 = not boolean1 && (boolean2 || false)

    // 本行用 "%b" 打印布尔值。这属于类型安全。
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %b" boolean3


/// 字符串是 F# 中的基本数据类型。下面是一些字符串和基本的字符串操作示例。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/strings
module StringManipulation =

    /// 字符串使用双引号。
    let string1 = "Hello"
    let string2  = "world"

    /// 字符串也可使用 @ 创建逐字的字符串。
    /// 这将忽略转义字符，如 "\", "\n", "\t" 等。
    let string3 = @"C:\Program Files\"

    /// 字符串文本也可使用三重引号。
    let string4 = """The computer said "hello world" when I told it to!"""

    /// 字符串串联通常是用 "+" 运算符完成的。
    let helloWorld = string1 + " " + string2

    // 本行用 "%s" 打印字符串值。这属于类型安全。
    printfn "%s" helloWorld

    /// 子字符串使用索引表示法。此行提取前 7 个字符作为子字符串。
    /// 注意，与许多语言相同，字符串在 F# 中从零开始编制索引。
    let substring = helloWorld.[0..6]
    printfn "%s" substring


/// 元组是组合成组合值的简单数据值组合。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/tuples
module Tuples =

    /// 一个包含整数的简单元组。
    let tuple1 = (1, 2, 3)

    /// 一个用于交换两个值在元组中的顺序的函数。
    ///
    /// F# 类型推理可自动泛化函数，使其具有泛型类型，
    /// 意味着它可与任何类型兼容。
    let swapElems (a, b) = (b, a)

    printfn "The result of swapping (1, 2) is %A" (swapElems (1,2))

    /// 一个整数，一个字符串以及
    /// 一个双精度浮点数字组成的元组。
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A\ttuple2: %A" tuple1 tuple2

    /// 一个具有类型批注的简单的整数元组。
    /// 元组的类型批注使用 * 号来分隔元素
    let tuple3: int * int = (5, 9)

    /// 元组通常为对象，但也可表示为结构。
    ///
    /// 这些可在 C# 和 Visual Basic.NET 中与结构完全进行交互操作；然而，
    /// 结构元组不隐式转换为对象元组(通常称为引用元组)。
    ///
    /// 下面的第二行将因此无法编译。取消注释观察将发生什么。
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // 尽管不能在结构元组和引用元组之间进行隐式转换，
    // 可通过模式匹配进行显式转换，如下所示。
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)

    printfn "Struct Tuple: %A\nReference tuple made from the Struct Tuple: %A" sampleStructTuple (sampleStructTuple |> convertFromStructTuple)


/// F# 管道运算符("|>"、"<|" 等 )和 F# 组合运算符(">>"、"<<")
/// 广泛用于数据处理。这些运算符本身就是函数，
/// 它使用偏函数应用。
///
/// 若要深入了解这些运算符，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/functions/#function-composition-and-pipelining
/// 若要深入了解偏函数应用，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/functions/#partial-application-of-arguments
module PipelinesAndComposition =

    /// 计算值的平方。
    let square x = x * x

    /// 将值加 1。
    let addOne x = x + 1

    /// 通过取模测试整数是否为奇数。
    let isOdd x = x % 2 <> 0

    /// 包含 5 个数字的列表。稍后列表上会有更多数字。
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// 如果是整数列表，它会筛选出偶数，
    /// 将产生的奇数平方，然后将奇数平方值加 1。
    let squareOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" numbers (squareOddValuesAndAddOne numbers)

    /// 编写 "squareOddValuesAndAddOne" 的简便方法是将每个
    /// 子结果嵌入函数调用本身。
    ///
    /// 这将使函数短得多，但难以查看
    /// 处理数据的顺序。
    let squareOddValuesAndAddOneNested values =
        List.map addOne (List.map square (List.filter isOdd values))

    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers (squareOddValuesAndAddOneNested numbers)

    /// 编写 "squareOddValuesAndAddOne" 的首选方法是使用 F# 管道运算符。
    /// 这可使你避免产生中间结果，而且可读性更好
    /// 嵌入式函数调用(如 "squareOddValuesAndAddOneNested")更具可读性
    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    printfn "processing %A through 'squareOddValuesAndAddOnePipeline' produces: %A" numbers (squareOddValuesAndAddOnePipeline numbers)

    /// 使用 Lambda 函数，通过将第二个 "List.map" 调用移动到第一个，
    /// 可以缩短 "squareOddValuesAndAddOnePipeline"。
    ///
    /// 注意，管道也在 lambda 函数内使用。F# 管道运算符
    /// 还可用于单个值。这使它们处理数据的功能很强大。
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" numbers (squareOddValuesAndAddOneShorterPipeline numbers)

    /// 最后，无需再将 "value" 显式作为参数，你可使用 ">>"
    /// 以合成两个核心运算: 筛选出偶数，然后平方并加 1。
    /// 同样，lambda 表达式的 "fun x -> ..." 也不需要了，因为 "x" 只是
    /// 在该范围内定义，以便可传递到功能管道。因此，也可将 ">>"
    /// 用在该处。
    ///
    /// "squareOddValuesAndAddOneComposition" 的结果本身就是另一个函数，它
    /// 将整数列表作为其输入值。如果使用整数列表执行 "squareOddValuesAndAddOneComposition"，
    /// 你将发现它与上述函数产生的结果相同。
    ///
    /// 这使用的就是所谓的函数组合。这是可能的，因为 F# 中的函数
    /// 使用偏函数应用，并且每个数据处理操作的输入和输出类型与
    /// 我们使用的函数签名。
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneComposition' produces: %A" numbers (squareOddValuesAndAddOneComposition numbers)


/// 列表属于有序、不可变、单向链接的列表。它们都采用主动求值方式。
///
/// 本模块介绍使用某些函数生成列表和处理列表的各种方法
/// 在 F# 核心库的 "List" 模块中。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/lists
module Lists =

    /// 使用 [ ... ] 定义列表。这是空列表。
    let list1 = [ ]

    /// 这是一个包含 3 个元素的列表。";" 用于分隔同一行的元素。
    let list2 = [ 1; 2; 3 ]

    /// 也可通过将各元素放在其自身行来分隔。
    let list3 = [
        1
        2
        3
    ]

    /// 这是从 1 到 1000 的整数列表
    let numberList = [ 1 .. 1000 ]

    /// 也可通过计算来生成列表。此列表包含
    /// 一年的所有天。
    let daysList =
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                  yield System.DateTime(2017, month, day) ]

    // 使用 "List.take" 打印 "daysList" 的前 5 个元素。
    printfn "The first 5 days of 2017 are: %A" (daysList |> List.take 5)

    /// 计算可以包括条件。这是包含元组的列表
    /// 这是棋盘上黑色方格的坐标。
    let blackSquares =
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do
                  if (i+j) % 2 = 1 then
                      yield (i, j) ]

    /// 列表可使用 "List.map" 和其他函数编程连结符进行转换。
    /// 此定义通过使用管道将 numberList 中的数字进行平方运算来生成新列表
    /// 将参数传递给 List.map 的运算符。
    let squares =
        numberList
        |> List.map (fun x -> x*x)

    /// 还有许多其他列表组合。下面计算以下内容的平方和:
    /// 数字可被 3 整除。
    let sumOfSquares =
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)

    printfn "The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d" sumOfSquares


/// 数组是固定大小，同类型元素的可变集合。
///
/// 尽管它们与列表相同(支持枚举，且具有用于数据处理的类似连接符)，
/// 它们通常速度更快，且支持快速随机访问。代价是因为可变而不太安全。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/arrays
module Arrays =

    /// 这是空数组。注意，语法与列表类似，但改用 `[| ... |]`。
    let array1 = [| |]

    /// 使用与列表相同的构造范围来指定数组。
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// 这是从 1 到 1000 的数字数组。
    let array3 = [| 1 .. 1000 |]

    /// 这是只包含单词 "hello" 和 "world" 的数组。
    let array4 =
        [| for word in array2 do
               if word.Contains("l") then
                   yield word |]

    /// 这是由索引初始化的数组，包含从 0 到 2000 之间的偶数。
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// 使用切片表示法提取子数组。
    let evenNumbersSlice = evenNumbers.[0..500]

    /// 可使用 "for" 循环循环数组和列表。
    for word in array4 do
        printfn "word: %s" word

    // 可使用左箭头赋值运算符来修改数组元素的内容。
    //
    // 若要深入了解此运算符，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/values/index#mutable-variables
    array2.[1] <- "WORLD!"

    /// 可使用 "Array.map" 和其他功能性编程运算来转换数组。
    /// 下面的函数计算以 "h" 开头的单词的总长度。
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn "The sum of the lengths of the words in Array 2 is: %d" sumOfLengthsOfWords


/// 序列是类型相同的所有元素的逻辑系列。序列是比列表和数组更常规的类型。
///
/// 将根据需要计算序列，并在每次循环访问它们时重新进行计算。
/// F# 序列是 .NET System.Collections.Generic.IEnumerable<'T> 的别名。
///
/// 序列处理函数也可以应用于列表和数组。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/sequences
module Sequences =

    /// 这是空序列。
    let seq1 = Seq.empty

    /// 这是一个值的序列。
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    /// 这是从 1 到 1000 的按需序列。
    let numbersSeq = seq { 1 .. 1000 }

    /// 这是生成单词 "hello" 和 "world" 的序列
    let seq3 =
        seq { for word in seq2 do
                  if word.Contains("l") then
                      yield word }

    /// 此序列生成最大为 2000 的偶数。
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    /// 这是可随机访问的无限序列。
    /// 此示例使用 yield! 返回子序列的每个元素。
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// 此示例演示随机访问的前 100 个元素。
    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList

    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk


/// 递归函数可调用其自身。在 F# 中，函数只递归
/// 使用 "let rec" 声明时。
///
/// 递归是 F# 中处理序列或集合的首选方式。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/functions/index#recursive-functions
module RecursiveFunctions =

    /// 此示例演示递归函数，计算以下内容的阶乘:
    /// 整数。它使用 "let rec" 来定义递归函数。
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n-1)

    printfn "Factorial of 6 is: %d" (factorial 6)

    /// 计算两个整数的最大公因数。
    ///
    /// 由于所有递归调用都是尾调用，
    /// 因此编译器会将该函数转变成一个循环，
    /// 这可提高性能并减少内存消耗。
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn "The Greatest Common Factor of 300 and 620 is %d" (greatestCommonFactor 300 620)

    /// 本示例使用递归计算整数列表的总和。
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    /// 通过将 Helper 函数与结果累加器一起使用，使 "sumList" 成为尾递归函数。
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    /// 假如 "0" 作为种子累加器，这将调用尾递归 helper 函数。
    /// 此类方法在 F# 中很常见。
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn "The sum 1-10 is %d" (sumListTailRecursive oneThroughTen)


/// 记录是已命名值的聚合，同时具有可选成员(例如，方法)。
/// 它们不可变且具有结构相等性语义。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/records
module RecordTypes =

    /// 此示例演示如何定义新记录类型。
    type ContactCard =
        { Name     : string
          Phone    : string
          Verified : bool }

    /// 本示例演示如何实例化记录类型。
    let contact1 =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false }

    /// 也可使用 ";" 分隔符在同一行上执行此操作。
    let contactOnSameLine = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

    /// 此示例演示如何对记录值使用 "copy-and-update"。它创建了
    /// 新的记录值，该值是 contact1 的副本，但对以下内容具有不同的值:
    /// “电话”和“已验证”字段。
    ///
    /// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/copy-and-update-record-expressions
    let contact2 =
        { contact1 with
            Phone = "(206) 555-0112"
            Verified = true }

    /// 此示例演示如何编写处理记录值的函数。
    /// 它将 "ContactCard" 对象转换为字符串。
    let showContactCard (c: ContactCard) =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn "Alf's Contact Card: %s" (showContactCard contact1)

    /// 这是一个具有成员的记录示例。
    type ContactCardAlternate =
        { Name     : string
          Phone    : string
          Address  : string
          Verified : bool }

        /// 成员可实现面向对象的成员。
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified)" else "") + this.Address

    let contactAlternate =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false
          Address = "111 Alf Street" }

    // 可通过实例化类型上的 "." 运算符访问成员。
    printfn "Alf's alternate contact card is %s" contactAlternate.PrintedContactCard

    /// 记录也可通过 "Struct" 属性表示为结构。
    /// 这在结构性能更重要的情况下很有用
    /// 引用类型的灵活性。
    [<Struct>]
    type ContactCardStruct =
        { Name     : string
          Phone    : string
          Verified : bool }


/// 可区分联合(简称 DU)的值可以是一系列已命名窗体或用例。
/// DU 中存储的数据可以为多个不同值之一。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/discriminated-unions
module DiscriminatedUnions =

    /// 下面代表一套扑克牌。
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    /// 可区分联合还可用来表示纸牌的设置级别。
    type Rank =
        /// 表示扑克牌点数 2 .. 10
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        /// 可区分联合还可实现面向对象的成员。
        static member GetAllRanks() =
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]

    /// 这是结合花色和牌面大小的记录类型。
    /// 表示数据时同时使用记录和可区分联合是很常见的。
    type Card = { Suit: Suit; Rank: Rank }

    /// 它将计算代表牌组中所有扑克牌的列表。
    let fullDeck =
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do
                  yield { Suit=suit; Rank=rank } ]

    /// 此示例将“纸牌”对象转换为字符串。
    let showPlayingCard (c: Card) =
        let rankString =
            match c.Rank with
            | Ace -> "Ace"
            | King -> "King"
            | Queen -> "Queen"
            | Jack -> "Jack"
            | Value n -> string n
        let suitString =
            match c.Suit with
            | Clubs -> "clubs"
            | Diamonds -> "diamonds"
            | Spades -> "spades"
            | Hearts -> "hearts"
        rankString  + " of " + suitString

    /// 此示例打印扑克牌中的所有牌。
    let printAllCards() =
        for card in fullDeck do
            printfn "%s" (showPlayingCard card)

    // 单用例 DU 常用于域建模。这可确保额外类型的安全
    // 字符串和整数等基元类型。
    //
    // 单用例 DU 无法隐式转换为其包装的类型或从其包装的类型进行转换。
    // 例如，地址中采用的函数无法接受字符串作为输入，
    // 反之亦然。
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    // 可轻松实例化单用例 DU，如下所示。
    let address = Address "111 Alf Way"
    let name = Name "Alf"
    let ssn = SSN 1234567890

    /// 需要值时，可使用单个函数解包基础值。
    let unwrapAddress (Address a) = a
    let unwrapName (Name n) = n
    let unwrapSSN (SSN s) = s

    // 打印单用例 DU 与解包函数一样简单。
    printfn "Address: %s, Name: %s, and SSN: %d" (address |> unwrapAddress) (name |> unwrapName) (ssn |> unwrapSSN)

    /// 可区分联合还支持递归定义。
    ///
    /// 这代表一个二进制文件搜索树，且有一个用例为空树，
    /// 而另一个用例为具有一个值和两个子树的节点。
    type BST<'T> =
        | Empty
        | Node of value:'T * left: BST<'T> * right: BST<'T>

    /// 检查项是否存在于二进制文件搜索树中。
    /// 使用模式匹配进行递归搜索。如果存在，则返回 true，否则返回 false。
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left) // 检查左子树。
            else (exists item right) // 检查右子树。

    /// 在二进制文件搜索树中插入项。
    /// 查找使用模式匹配递归插入的位置，然后插入新节点。
    /// 如果项已存在，则不会插入任何内容。
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node // 无需插入，该项已存在；返回节点。
            elif item < x then Node(x, insert item left, right) // 调入左子树。
            else Node(x, left, insert item right) // 调入右子树。

    /// 可区分联合也可通过 "Struct" 属性表示为结构。
    /// 这在结构性能更重要的情况下很有用
    /// 引用类型的灵活性。
    ///
    /// 然而，执行此操作时需了解两个重要事项:
    ///     1. 无法以递归方式定义结构 DU。
    ///     2. 结构 DU 必须对其每个用例均有唯一名称。
    [<Struct>]
    type Shape =
        | Circle of radius: float
        | Square of side: float
        | Triangle of height: float * width: float


/// 模式匹配是 F# 的一个功能，使你能够利用模式，
/// 它们是将数据与逻辑结构或结构进行比较的方法，
/// 将数据分解为各个构成部分，或通过各种方式从数据中提取信息。
/// 然后，你便可以在模式的“形状”上通过模式匹配进行派遣。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/pattern-matching
module PatternMatching =

    /// 人员的姓氏和名字的记录
    type Person = {
        First : string
        Last  : string
    }

    /// 具有 3 种不同员工的可区分联合
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// 在管理层次结构下对员工进行计数，
    /// 其中包括员工。
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(id) ->
                0
            | Manager(id, reports) ->
                reports |> List.sumBy countReports
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    /// 查找所有名为 "Dave" 且没有任何下属的经理/主管。
    /// 这使用 "function" 简写为 lambda 表达式。
    let rec findDaveWithOpenPosition(emps : List<Employee>) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true // [] 匹配空列表。
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false) // "_" 是与任何对象均匹配的通配符模式。
                                     // 它处理 "or else" 情况。

    /// 你也可将简写函数构造用于模式匹配，
    /// 这在编写使用偏函数应用的函数时很有用。
    let private parseHelper f = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDateTimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    // 定义更多使用 helper 函数分析的函数。
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

    // 活动模式是另一个与模式匹配配合使用的强大构造。
    // 它们使你能够将输入数据分区到自定义窗体，然后在模式匹配调用站点分解它们。
    //
    // 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/active-patterns
    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    /// 通过 "function" 关键字的匹配模式和活动模式通常如下所示。
    let printParseResult = function
        | Int x -> printfn "%d" x
        | Double x -> printfn "%f" x
        | Date d -> printfn "%s" (d.ToString())
        | TimeSpan t -> printfn "%s" (t.ToString())
        | _ -> printfn "Nothing was parse-able!"

    // 使用一些其他值调用打印机进行分析。
    printParseResult "12"
    printParseResult "12.045"
    printParseResult "12/28/2016"
    printParseResult "9:01PM"
    printParseResult "banana!"


/// 选项值是用“Some”或“None”标记的任何类型的值。
/// 它们在 F# 代码中广泛用于表示许多其他
/// 语言使用 null 引用的用例。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/options
module OptionValues =

    /// 首先，定义通过单用例可区分联合定义的邮政编码。
    type ZipCode = ZipCode of string

    /// 接下来，定义一个类型，其中 ZipCode 是可选项。
    type Customer = { ZipCode: ZipCode option }

    /// 接下来，定义表示对象的接口类型，用于计算客户邮政编码的送货区域，
    /// 假定提供了“getState”和“getShippingZone”抽象方法的实现。
    type ShippingCalculator =
        abstract GetState : ZipCode -> string option
        abstract GetShippingZone : string -> int

    /// 接下来，使用计算器实例计算客户的发货区域。
    /// 它在选项模块中使用连接符以允许功能管道
    /// 用于使用可选项转换数据。
    let CustomerShippingZone (calculator: ShippingCalculator, customer: Customer) =
        customer.ZipCode
        |> Option.bind calculator.GetState
        |> Option.map calculator.GetShippingZone


/// 度量单位是一种以类型安全方式批注基元数值类型的方式。
/// 然后，你便可以对这些值执行类型安全算术。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/units-of-measure
module UnitsOfMeasure =

    /// 首先，打开常用单位名称集合
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    /// 定义单元化常量
    let sampleValue1 = 1600.0<meter>

    /// 接下来，定义新的单位类型
    [<Measure>]
    type mile =
        /// 英里到米的换算系数。
        static member asMeter = 1609.34<meter/mile>

    /// 定义单元化常量
    let sampleValue2  = 500.0<mile>

    /// 计算公制常量
    let sampleValue3 = sampleValue2 * mile.asMeter

    // 使用度量单位的值可像基元数值类型用于打印等操作一样直接使用。
    printfn "After a %f race I would walk %f miles which would be %f meters" sampleValue1 sampleValue2 sampleValue3


/// 类是 F# 中定义新对象类型的一种方式，且支持标准的面向对象的构造。
/// 它们可以有各种成员(如，方法、属性、事件等)
///
/// 若要了解关于类的详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/classes
///
/// 若要深入了解成员，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/members
module DefiningClasses =

    /// 简单的二维矢量类。
    ///
    /// 该类的构造函数位于第一行，
    /// 并且采用两个参数: dx 和 dy，二者均属于类型 "double"。
    type Vector2D(dx : double, dy : double) =

        /// 此内部字段存储矢量的长度，当发生以下情况时进行计算:
        /// 对象已构造
        let length = sqrt (dx*dx + dy*dy)

        // “this”用于指定对象的自我标识符的名称。
        // 在实例方法中，它必须出现在成员名称之前。
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        /// 该成员属于方法。以前的成员属于属性。
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    /// 这就是你实例化 Vector2D 类的方式。
    let vector1 = Vector2D(3.0, 4.0)

    /// 获取新的缩放矢量对象而不修改原始对象。
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f\nLength of vector2: %f" vector1.Length vector2.Length


/// 通用类允许考虑使用一组类型参数来定义类型。
/// 以下示例中，"T" 表示类的类型参数。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/generics/
module DefiningGenericClasses =

    type StateTracker<'T>(initialElement: 'T) =

        /// 此内部字段将状态存储在列表中。
        let mutable states = [ initialElement ]

        /// 将新元素添加到状态列表中。
        member this.UpdateState newState =
            states <- newState :: states  // 使用 "<-" 运算符改变值。

        /// 获取历史状态的完整列表。
        member this.History = states

        /// 获取最新状态。
        member this.Current = states.Head

    /// 状态跟踪程序类的一个“int”实例。请注意，已推断类型参数。
    let tracker = StateTracker 10

    // 添加状态
    tracker.UpdateState 17


/// 接口是只有“抽象”成员的对象类型。
/// 对象类型和对象表达式可以实现接口。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/interfaces
module ImplementingInterfaces =

    /// 它是实现 IDisposable 的类型。
    type ReadFile() =

        let file = new System.IO.StreamReader("readme.txt")

        member this.ReadLine() = file.ReadLine()

        // 它是 IDisposable 成员的实现。
        interface System.IDisposable with
            member this.Dispose() = file.Close()


    /// 该对象可通过对象表达式实现 IDisposable
    /// 与 C# 或 Java 等其他语言不同，无需新的类型定义
    /// 以实现接口。
    let interfaceImplementation =
        { new System.IDisposable with
            member this.Dispose() = printfn "disposed" }


/// FSharp.Core 库定义了一系列并行处理函数。此处
/// 可使用某些函数对数组进行并行处理。
///
/// 有关详细信息，请参阅: https://msdn.microsoft.com/zh-cn/visualfsharpdocs/conceptual/array.parallel-module-%5Bfsharp%5D
module ParallelArrayProgramming =

    /// 首先，输入一个数组。
    let oneBigArray = [| 0 .. 100000 |]

    // 接下来，定义执行某些 CPU 密集型计算的函数。
    let rec computeSomeFunction x =
        if x <= 2 then 1
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)

    // 接下来，对大型输入数组执行并行映射。
    let computeResults() =
        oneBigArray
        |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    // 接下来，打印结果。
    printfn "Parallel computation results: %A" (computeResults())



/// 事件是 .NET 编程的常见习惯用语，尤其是使用 WinForms 或 WPF 应用程序编程时。
///
/// 有关详细信息，请参阅: https://docs.microsoft.com/zh-cn/dotnet/articles/fsharp/language-reference/members/events
module Events =

    /// 首先，创建包含订阅点(event.Publish)和事件触发器(event.Trigger)的事件对象实例。
    let simpleEvent = new Event<int>()

    // 接下来，将处理程序添加到事件。
    simpleEvent.Publish.Add(
        fun x -> printfn "this handler was added with Publish.Add: %d" x)

    // 接下来，触发该事件。
    simpleEvent.Trigger(5)

    // 接下来，创建遵循标准 .NET 约定的事件的实例: (sender, EventArgs)。
    let eventForDelegateType = new Event<EventHandler, EventArgs>()

    // 接下来，为此新事件添加处理程序。
    eventForDelegateType.Publish.AddHandler(
        EventHandler(fun _ _ -> printfn "this handler was added with Publish.AddHandler"))

    // 接下来，触发此事件(请注意，应设置 sender 参数)。
    eventForDelegateType.Trigger(null, EventArgs.Empty)



#if COMPILED
module BoilerPlateForForm =
    [<System.STAThread>]
    do ()
    do System.Windows.Forms.Application.Run()
#endif
