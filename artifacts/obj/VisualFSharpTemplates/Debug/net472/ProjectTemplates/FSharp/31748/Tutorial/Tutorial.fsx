// 此範例將引導您了解 F# 語言的項目。
//
// *******************************************************************************************************
//   若要執行 F# 互動中的程式碼，請反白顯示某個程式碼區段並按下 Alt-Enter，或者以滑鼠右鍵按一下
//   並選取 [以互動方式執行]。您可以從 [檢視] 功能表開啟 F# 互動式視窗。
// *******************************************************************************************************
//
// 如需有關 F# 的詳細資訊，請參閱:
//     https://fsharp.org
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/
//
// 若要參閱文件表單中的此教學課程，請參閱:
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/tour
//
// 如需深入了解套用的 F# 程式設計，請使用
//     https://fsharp.org/guides/enterprise/
//     https://fsharp.org/guides/cloud/
//     https://fsharp.org/guides/web/
//     https://fsharp.org/guides/data-science/
//
// 若要安裝 Visual F# Power Tools，請使用
//     [工具]5D; --> [延伸模組和更新]5D; --> [連線]5D; 並搜尋
//
// 如需有關搭配 F# 一起使用的其他範本，請參閱 Visual Studio 中的 [線上範本]5D;，
//     [新增專案]5D; --> [線上範本]5D;

// F# 支援三種註解:

//  1. 將註解加上雙斜線。適用於大部分的情況。
(*  2. 將註解加上 ML 樣式區塊。較不常使用。 *)
/// 3. 將註解加上三斜線。適用於記錄函式、類型等。
///    當您暫留在以這些註解為裝飾的項目上時，這些註解會顯示為文字。
///
///    這些註解也支援 .NET 樣式的 XML 註解，讓您可以產生參考文件，
///    也讓編輯者 (像是 Visual Studio) 可以從註解中擷取資訊。
///    若要深入了解，請參閱: https://docs.microsoft.com/zh-tw/dotnet/articles/fsharp/language-reference/xml-documentation


// 使用 'open' 關鍵字開啟命名空間。
//
// 若要深入了解，請參閱: https://docs.microsoft.com/zh-tw/dotnet/articles/fsharp/language-reference/import-declarations-the-open-keyword
open System


/// 模組是 F# 程式碼的分組，例如值、類型及函式值。
/// 將程式碼分組為模組有助於將相關的程式碼整合在一塊，且能避免程式發生名稱衝突。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/zh-tw/dotnet/articles/fsharp/language-reference/modules
module IntegersAndNumbers =

    /// 此為範例整數。
    let sampleInteger = 176

    /// 此為範例浮點數。
    let sampleDouble = 4.1

    /// 這使用了一些算數來計算新數字。使用函式 'int'、'double' 等
    /// 來轉換數字類型。
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    /// 此為從 0 到 99 的數字清單。
    let sampleNumbers = [ 0 .. 99 ]

    /// 此為所有 Tuple 的清單，內含從 0 到 99 的所有數字及其平方。
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // 下一行會使用 '%A' 執行一般列印，來列印包含 Tuple 的清單。
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfSquares

    // 此為具有型別註解的範例整數
    let sampleInteger3: int = 1


/// 根據預設，F# 中的值是不可變的。於程式執行過程中，除非明確標示為可變的
/// 否則無法對其進行變更。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/values/index#why-immutable
module Immutability =

    /// 透過 'let' 將值繫結到名稱，即可將它設為不可變動。
    ///
    /// 因為 'number' 無法變動並已繫結，所以無法編譯第二行程式碼。
    /// 在 F# 中，不得將 'number' 重新定義為不同的值。
    let number = 2
    // let number = 3

    /// 可變動的繫結。需要此項目才可變更 'otherNumber' 的值。
    let mutable otherNumber = 2

    printfn "'otherNumber' is %d" otherNumber

    // 變動值時，請使用 '<-' 指派新的值。
    //
    // '=' 在此表示等於，所以無法用於此用途
    // 或其他內容，例如 'let' 或 'module'
    otherNumber <- otherNumber + 1

    printfn "'otherNumber' changed to be %d" otherNumber


/// F# 程式設計時常需要定義函式來轉換輸入資料，從而產生
/// 實用的結果。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/
module BasicFunctions =

    /// 您可以使用 'let' 來定義函式。此接受整數引數，並會傳回整數。
    /// 對函式引數來說不一定要使用括號，但使用明確的型別註解時例外。
    let sampleFunction1 x = x*x + 3

    /// 套用函式，使用 'let' 命名函數會傳回結果。
    /// 變數型別是從函式傳回型別推斷出來。
    let result1 = sampleFunction1 4573

    // 此行使用 '%d' 以整數形式列印結果。這是型別安全。
    // 如果 'result1' 的類型不是 'int'，則無法編譯該行。
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    /// 需要時，請使用 '(argument:type)' 為參數名稱的類型加上標註。需要使用括號。
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn "The result of applying the 2nd sample function to (7 + 4) is %d" result2

    /// 條件使用 if/then/elid/elif/else。
    ///
    /// 請注意，F# 使用空白縮排感知語法，其與 Python 這類語言類似。
    let sampleFunction3 x =
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)

    // 此行使用 '%f' 以浮點形式列印結果。與上述 '%d' 相同，這是型別安全。
    printfn "The result of applying the 3rd sample function to (6.5 + 4.5) is %f" result3


/// 布林值是 F# 中的基本資料類型。以下是一些布林值與條件式邏輯的範例。
///
/// 若要深入了解，請參閱:
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/primitive-types
///     及
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/symbol-and-operator-reference/boolean-operators
module Booleans =

    /// 布林值為 'true' 和 'false'。
    let boolean1 = true
    let boolean2 = false

    /// 布林值上的運算子為 'not'、'&&' 和 '||'。
    let boolean3 = not boolean1 && (boolean2 || false)

    // 此行使用 '%b' 列印布林值。這是型別安全。
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %b" boolean3


/// 字串在 F# 中是基本的資料類型。以下是一些字串與基本字串操作的範例。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/strings
module StringManipulation =

    /// 字串使用雙引號。
    let string1 = "Hello"
    let string2  = "world"

    /// 字串也可使用 @ 來建立逐字字串常值。
    /// 這將會忽略逸出字元，例如 '\'、'\n'、'\t' 等等。
    let string3 = @"C:\Program Files\"

    /// 字串常值也可使用三引號。
    let string4 = """The computer said "hello world" when I told it to!"""

    /// 串連字串通常使用 '+' 運算子進行。
    let helloWorld = string1 + " " + string2

    // 此行使用 '%s' 列印字串值。這是型別安全。
    printfn "%s" helloWorld

    /// 子字串使用索引子標記法。此行會擷取前 7 個字元作為子字串。
    /// 請注意，就像許多語言一樣，字串在 F# 中會以零為基底編製索引。
    let substring = helloWorld.[0..6]
    printfn "%s" substring


/// 元組是簡單的資料值合併為合併值。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/tuples
module Tuples =

    /// 簡式整數元組。
    let tuple1 = (1, 2, 3)

    /// 將元組中兩個值的順序互換的函式。
    ///
    /// F# 型別推斷會自動將函式一般化成泛型類型，
    /// 表示其可與任何類型搭配運作。
    let swapElems (a, b) = (b, a)

    printfn "The result of swapping (1, 2) is %A" (swapElems (1,2))

    /// 元組，包含整數、字串、
    /// 和雙精確度浮點數。
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A\ttuple2: %A" tuple1 tuple2

    /// 具有類型註釋之整數的簡單元組。
    /// 元組的類型註釋會使用 * 符號分隔項目
    let tuple3: int * int = (5, 9)

    /// 元組一般是物件，但也可以用結構形式呈現。
    ///
    /// 這些會與 C# 和 Visual Basic .NET 中的結構完全相互操作; 不過，
    /// 結構元組無法利用物件元組 (通常稱為參考元組) 進行隱含轉換。
    ///
    /// 因此，將無法編譯以下的第二行。請取消它的註解，看看會如何。
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // 雖然您不能隱含地在結構元組及參考元組間進行轉換，
    // 但您可透過模式比對明確地轉換，如下所示。
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)

    printfn "Struct Tuple: %A\nReference tuple made from the Struct Tuple: %A" sampleStructTuple (sampleStructTuple |> convertFromStructTuple)


/// F# 管道運算子 ('|>'、'<|' 等) 與 F# 組合運算子 ('>>'、'<<')
/// 廣泛用於處理資料時。這些運算子本身就是函式
/// 其會利用局部應用程式。
///
/// 若要深入了解這些運算子，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/#function-composition-and-pipelining
/// 若要深入了解局部應用程式，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/#partial-application-of-arguments
module PipelinesAndComposition =

    /// 產生值的平方。
    let square x = x * x

    /// 將值加 1。
    let addOne x = x + 1

    /// 測試整數值是否為經過模數的奇數。
    let isOdd x = x % 2 <> 0

    /// 5 個數字的清單。清單上稍後會有更多項目。
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// 提供整數清單，它會篩選出偶數，
    /// 取結果奇數的平方值，並對平方後的奇數加 1。
    let squareOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" numbers (squareOddValuesAndAddOne numbers)

    /// 撰寫 'squareOddValuesAndAddOne' 較簡短的方式是巢狀每個項目
    /// 子結果進入函式呼叫本身。
    ///
    /// 這會將函式設成更短，但較難查看
    /// 資料的處理順序。
    let squareOddValuesAndAddOneNested values =
        List.map addOne (List.map square (List.filter isOdd values))

    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers (squareOddValuesAndAddOneNested numbers)

    /// 撰寫 'squareOddValuesAndAddOne' 的慣用方式是使用 F# 管道運算子。
    /// 這可讓您避免建立中繼結果，但比較容易閱讀
    /// ，相較於 'squareOddValuesAndAddOneNested' 這類的巢狀函式呼叫
    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    printfn "processing %A through 'squareOddValuesAndAddOnePipeline' produces: %A" numbers (squareOddValuesAndAddOnePipeline numbers)

    /// 您可以移動第二個 'List.map' 呼叫來縮短 'squareOddValuesAndAddOnePipeline'
    /// 到第一個項目，使用 Lambda 函式。
    ///
    /// 請注意，管線也會用於 lambda 函式內。F# 管道運算子
    /// 也可以用於單一值。如此可讓它們在處理資料時功能極為強大。
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" numbers (squareOddValuesAndAddOneShorterPipeline numbers)

    /// 最後，您不需要使用 '>>' 來明確接受 'values' 作為參數
    /// 以撰寫兩個核心作業: 篩選出偶數，然後取其平方值再加一。
    /// 同樣地，也不需要 lambda 運算式的 'fun x -> ...' 位元，因為 'x' 只是
    /// 定義於該範圍內，以將它傳遞至功能管線。因此，可以使用 '>>'
    /// 也會在該處。
    ///
    /// 'squareOddValuesAndAddOneComposition' 的結果本身是另一個函式，且該函式接受
    /// 作為輸入的整數清單。如果您執行 'squareOddValuesAndAddOneComposition' 時搭配清單
    /// (整數)，您將注意到它會產生與先前函式相同的結果。
    ///
    /// 這將使用所謂的函式組合。原因可能是 F# 中的函式
    /// 使用局部應用程式，以及每個資料處理作業相符的輸入與輸出類型
    /// 所使用之函式的簽章。
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneComposition' produces: %A" numbers (squareOddValuesAndAddOneComposition numbers)


/// 清單是已排序且不可變動的單向連結清單。它們於評估時會即刻進行運算。
///
/// 此模組示範產生清單及利用某些函式處理清單的各種方法
/// 在 F# 核心程式庫的 'List' 模組中。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/lists
module Lists =

    /// 清單使用 [ ... ] 定義。這是空白清單。
    let list1 = [ ]

    /// 這是內含 3 個項目的清單。使用 ';' 分隔同一行的項目。
    let list2 = [ 1; 2; 3 ]

    /// 您也可以將項目放在各自的行上加以分隔。
    let list3 = [
        1
        2
        3
    ]

    /// 此為從 1 到 1000 的整數清單
    let numberList = [ 1 .. 1000 ]

    /// 計算也可產生清單。此清單內含
    /// 當年每一天。
    let daysList =
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                  yield System.DateTime(2017, month, day) ]

    // 使用 'List.take' 列印 'daysList' 的前 5 個項目。
    printfn "The first 5 days of 2017 are: %A" (daysList |> List.take 5)

    /// 計算可包含條件。此為內含元組的清單
    /// 其為棋盤上黑方格的座標。
    let blackSquares =
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do
                  if (i+j) % 2 = 1 then
                      yield (i, j) ]

    /// 可以使用 'List.map' 及其他函式程式設計結合器轉換清單。
    /// 此定義會產生新的清單，方法是使用管線使 numberList 中的數字成平方
    /// 運算子以將引數傳遞到 List.map。
    let squares =
        numberList
        |> List.map (fun x -> x*x)

    /// 還有許多其他清單組合。以下會計算下項的平方總和:
    /// 可由 3 整除的數字。
    let sumOfSquares =
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)

    printfn "The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d" sumOfSquares


/// 陣列是固定大小且類型相同的可變動項目集合。
///
/// 陣列雖與清單 (支援列舉，並具有類似的結合器可用於資料處理) 相似，但
/// 陣列通常比較快，而且支援快速隨機存取。但可變動的代價是安全性變低。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/arrays
module Arrays =

    /// 此為空白的陣列。請注意與清單前置詞相似的前置詞，請改用 `[| ... |]`。
    let array1 = [| |]

    /// 使用與所列相同的建構範圍指定陣列。
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// 這是從 1 到 1000 的數字陣列。
    let array3 = [| 1 .. 1000 |]

    /// 這是僅包含 "hello" 與 "world" 字詞的陣列。
    let array4 =
        [| for word in array2 do
               if word.Contains("l") then
                   yield word |]

    /// 這是由索引初始化的陣列，內含從 0 到 2000 之間的偶數。
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// 使用了切割標記法來擷取子陣列。
    let evenNumbersSlice = evenNumbers.[0..500]

    /// 您可以使用 'for' 迴圈逐一反覆執行陣列與清單。
    for word in array4 do
        printfn "word: %s" word

    // 您可以使用向左鍵指派運算子來修改陣列元素的內容。
    //
    // 若要深入了解此運算子，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/values/index#mutable-variables
    array2.[1] <- "WORLD!"

    /// 您可以使用 'Array.map' 及其他功能程式設計作業來轉換陣列。
    /// 以下會計算 'h' 開頭的字組之長度總和。
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn "The sum of the lengths of the words in Array 2 is: %d" sumOfLengthsOfWords


/// 序列是一系列的邏輯項目，全部皆為相同的類型。它是比清單及陣列更常見的類型。
///
/// 序列是視需要評估，並在每次反覆執行時重新評估。
/// F# 序列是 .NET System.Collections.Generic.IEnumerable<'T> 的別名。
///
/// 序列處理函式也可以套用到清單和陣列。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/sequences
module Sequences =

    /// 此為空白序列。
    let seq1 = Seq.empty

    /// 這是值的序列。
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    /// 此為從 1 到 1000 的隨選序列。
    let numbersSeq = seq { 1 .. 1000 }

    /// 此為產生 "hello" 及 "world" 的序列
    let seq3 =
        seq { for word in seq2 do
                  if word.Contains("l") then
                      yield word }

    /// 此序列產生 2000 以下的偶數。
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    /// 這是屬於隨機漫步的無限序列。
    /// 此範例使用 yield! 傳回序列的每個元素。
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// 此範例顯示了隨機漫步的前 100 個項目。
    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList

    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk


/// 遞迴函式可以呼叫其本身。在 F# 中，函式均為遞迴
/// (於使用 'let rec' 宣告時)。
///
/// 遞迴是處理 F# 中序列或集合的慣用方法。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/index#recursive-functions
module RecursiveFunctions =

    /// 此範例顯示遞迴函式，其可計算下項的階乘:
    /// 整數。其使用 'let rec' 來定義遞迴函式。
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n-1)

    printfn "Factorial of 6 is: %d" (factorial 6)

    /// 計算兩個整數的最大公因數。
    ///
    /// 因為所有遞迴呼叫都是先計算細項的呼叫 (tail call)，所以
    /// 編譯器會將函式轉換為迴圈，
    /// 以改善效能並降低記憶體耗用。
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn "The Greatest Common Factor of 300 and 620 is %d" (greatestCommonFactor 300 620)

    /// 此範例會計算使用遞迴之整數清單的總和。
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    /// 這會將 'sumList' 設成尾遞迴，使用內含結果累加器的 Helper 函式。
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    /// 這會叫用尾遞迴 helper 函式，提供 '0' 作為種子累加器。
    /// 在 F# 中，這類方式十分常見。
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn "The sum 1-10 is %d" (sumListTailRecursive oneThroughTen)


/// 記錄是具有選擇性成員 (例如方法) 之具名值的彙總。
/// 它們不可變動，且具有結構相等的語意。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/records
module RecordTypes =

    /// 此範例示範如何定義新記錄類型。
    type ContactCard =
        { Name     : string
          Phone    : string
          Verified : bool }

    /// 此範例示範如何具現化記錄類型。
    let contact1 =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false }

    /// 您也可以使用 ';' 分隔符號，在同一行執行此作業。
    let contactOnSameLine = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

    /// 此範例顯示如何在記錄值上使用 "copy-and-update"。其會建立
    /// 新記錄值，其為 contact1 的複本，但對於下項有不同的值:
    /// [Phone]5D; 與 [Verified]5D; 欄位。
    ///
    /// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/copy-and-update-record-expressions
    let contact2 =
        { contact1 with
            Phone = "(206) 555-0112"
            Verified = true }

    /// 此範例示範如何寫入會處理記錄值的函式。
    /// 其會將 'ContactCard' 物件轉換為字串。
    let showContactCard (c: ContactCard) =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn "Alf's Contact Card: %s" (showContactCard contact1)

    /// 這是內含成員之記錄的範例。
    type ContactCardAlternate =
        { Name     : string
          Phone    : string
          Address  : string
          Verified : bool }

        /// 成員可以實作物件導向成員。
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified)" else "") + this.Address

    let contactAlternate =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false
          Address = "111 Alf Street" }

    // 成員透過在具現化類型上的 '.' 運算子加以存取。
    printfn "Alf's alternate contact card is %s" contactAlternate.PrintedContactCard

    /// 記錄也可透過 'Struct' 屬性以結構形式呈現。
    /// 它在結構效能較優的情況下很有用
    /// 參考類型的彈性。
    [<Struct>]
    type ContactCardStruct =
        { Name     : string
          Phone    : string
          Verified : bool }


/// 差異聯集 (簡寫為 DU) 是可能為數個具名表單或案例的值。
/// DU 中所儲存的資料可以是數個相異值中的一個。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/discriminated-unions
module DiscriminatedUnions =

    /// 以下代表一副撲克牌。
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    /// 差異聯集也可用以代表一張撲克牌的順位。
    type Rank =
        /// 代表 2 .. 10 這幾張牌的順位
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        /// 差異聯集也可以實作物件導向成員。
        static member GetAllRanks() =
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]

    /// 這是合併了 Suit 和 Rank 的記錄類型。
    /// 代表資料時，通常會使用記錄與差異聯集。
    type Card = { Suit: Suit; Rank: Rank }

    /// 這會計算代表一疊牌中所有牌的清單。
    let fullDeck =
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do
                  yield { Suit=suit; Rank=rank } ]

    /// 此範例將 'Card' 物件轉換為字串。
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

    /// 此範例會列印牌局的所有紙牌。
    let printAllCards() =
        for card in fullDeck do
            printfn "%s" (showPlayingCard card)

    // 單一案例 DU 通常用於網域模型。這讓使用類型變得更加安全
    // 針對基本類型，例如 strings 和 ints。
    //
    // 單一案例 DU 無法隱含地轉換成它們所包裝的類型，反之亦然。
    // 例如，接受位址的函式無法接受字串作為輸入，
    // 反之亦然。
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    // 您可以輕鬆地具現化單一案例 DU，如下所示。
    let address = Address "111 Alf Way"
    let name = Name "Alf"
    let ssn = SSN 1234567890

    /// 當您需要值時，可以使用簡單的函式來展開基礎值。
    let unwrapAddress (Address a) = a
    let unwrapName (Name n) = n
    let unwrapSSN (SSN s) = s

    // 使用展開 (unwrap) 函式來列印單一案例的 DU 十分簡單。
    printfn "Address: %s, Name: %s, and SSN: %d" (address |> unwrapAddress) (name |> unwrapName) (ssn |> unwrapSSN)

    /// 差異聯集也支援遞迴定義。
    ///
    /// 這代表二進位搜尋樹狀結構，其中有一個案例是空的樹狀結構，
    /// 而另一個是具有一個值和兩個子樹狀結構的節點。
    type BST<'T> =
        | Empty
        | Node of value:'T * left: BST<'T> * right: BST<'T>

    /// 請確認二進位搜尋樹狀結構中是否已有項目存在。
    /// 使用模式比對進行遞迴搜尋。若存在即傳回 true; 否則傳回 false。
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left) // 請檢查左樹狀子結構。
            else (exists item right) // 請檢查右樹狀子結構。

    /// 在二進位搜尋樹狀結構中插入項目。
    /// 尋找要使用模式比對遞迴插入的位置，然後插入新節點。
    /// 如果該項目已經存在，就不會插入任何內容。
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node // 其已存在，所以無須插入; 傳回該節點。
            elif item < x then Node(x, insert item left, right) // 呼叫左樹狀子結構。
            else Node(x, left, insert item right) // 呼叫右樹狀子結構。

    /// 差異聯集也可透過 'Struct' 屬性以結構形式呈現。
    /// 它在結構效能較優的情況下很有用
    /// 參考類型的彈性。
    ///
    /// 但執行這項作業時，需要知道兩件重要的事情:
    ///     1. 不可遞迴定義結構 DU。
    ///     2. 結構 DU 的每個案例都必須要有唯一的名稱。
    [<Struct>]
    type Shape =
        | Circle of radius: float
        | Square of side: float
        | Triangle of height: float * width: float


/// 模式比對是讓您能利用模式的一項 F# 功能，
/// 這是使用一或多個邏輯結構來比對資料的方式，
/// 將資料分解為構成組件，或透過各種方式來擷取資料中的資訊。
/// 接著可根據透過比對模式之模式的「形狀」加以分派。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/pattern-matching
module PatternMatching =

    /// 人員姓名的記錄
    type Person = {
        First : string
        Last  : string
    }

    /// 3 種不同種類員工的差異聯集
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// 計算管理階層中該員工下的每位人員，
    /// 包括員工。
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(id) ->
                0
            | Manager(id, reports) ->
                reports |> List.sumBy countReports
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    /// 尋找沒有任何報表且名為 "Dave" 的所有經理/主管。
    /// 這會使用 'function' 速記作為 lambda 運算式。
    let rec findDaveWithOpenPosition(emps : List<Employee>) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true // [] 代表空的清單。
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false) // '_' 是符合所有項目的萬用字元模式。
                                     // 這會處理 "or else" 案例。

    /// 您也可以使用速記函式建構來進行模式比對，
    /// 適用於撰寫可利用局部應用程式的函式時。
    let private parseHelper f = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDateTimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    // 再額外定義一些使用 Helper 函式進行剖析的函式。
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

    // 現用模式是另一項功能強大之建構，可與模式比對搭配使用。
    // 它們可讓您將輸入資料分割到多個自訂表單，於模式比對呼叫網站進行分解。
    //
    // 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/active-patterns
    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    /// 透過 'function' 關鍵字與現用模式進行模式比對，通常看來如下。
    let printParseResult = function
        | Int x -> printfn "%d" x
        | Double x -> printfn "%f" x
        | Date d -> printfn "%s" (d.ToString())
        | TimeSpan t -> printfn "%s" (t.ToString())
        | _ -> printfn "Nothing was parse-able!"

    // 透過解析一些不同的值來呼叫印表機。
    printParseResult "12"
    printParseResult "12.045"
    printParseResult "12/28/2016"
    printParseResult "9:01PM"
    printParseResult "banana!"


/// 選項值是以 'Some' 或 'None' 標記的任何一種值。
/// 它們廣泛用於 F# 程式碼中，來代表許多其他語言會
/// 使用 null 參考的狀況。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/options
module OptionValues =

    /// 首先，定義透過單一案例差異聯集所定義的郵遞區號。
    type ZipCode = ZipCode of string

    /// 接著，定義不一定需要 ZipCode 的類型。
    type Customer = { ZipCode: ZipCode option }

    /// 然後，定義代表物件的介面類型，以計算客戶郵遞區號的郵寄區域，
    /// 'getState' 和 'getShippingZone' 抽象方法的指定實作。
    type ShippingCalculator =
        abstract GetState : ZipCode -> string option
        abstract GetShippingZone : string -> int

    /// 接下來，為使用計算機執行個體的客戶計算出貨區。
    /// 這會在 Option 模組中使用結合器，以允許在執行下列功能時使用功能管線:
    /// 使用選用項目來轉換資料。
    let CustomerShippingZone (calculator: ShippingCalculator, customer: Customer) =
        customer.ZipCode
        |> Option.bind calculator.GetState
        |> Option.map calculator.GetShippingZone


/// 測量單位是以型別安全方式為基本數值類型加上註釋的方法。
/// 接著可以在這些值上執行型別安全算術。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/units-of-measure
module UnitsOfMeasure =

    /// 首先，開啟常用單位名稱的集合
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    /// 定義 unitized 常數
    let sampleValue1 = 1600.0<meter>

    /// 接著，定義新單位類型
    [<Measure>]
    type mile =
        /// 英哩到公尺的轉換因數。
        static member asMeter = 1609.34<meter/mile>

    /// 定義 unitized 常數
    let sampleValue2  = 500.0<mile>

    /// 計算計量系統常數
    let sampleValue3 = sampleValue2 * mile.asMeter

    // 使用測量單位之值的用法，就像是列印這類作業的基本數字類型一樣。
    printfn "After a %f race I would walk %f miles which would be %f meters" sampleValue1 sampleValue2 sampleValue3


/// 類別是在 F# 中定義新物件類型的一種方式，且支援標準物件導向建構。
/// 它們可以有各式不同的成員 (方法、屬性、事件等等)
///
/// 若要深入了解類別，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/classes
///
/// 若要深入了解成員，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/members
module DefiningClasses =

    /// 簡式二維向量類別。
    ///
    /// 類別的建構函式位於第一行，
    /// 並接受兩種引數: dx 與 dy，兩者的類型都是 'double'。
    type Vector2D(dx : double, dy : double) =

        /// 這個內部欄位會儲存向量長度，計算時機為
        /// 物件已建構
        let length = sqrt (dx*dx + dy*dy)

        // 'this' 會為物件的自我識別碼指定名稱。
        // 在執行個體方法中，它必須出現在成員名稱前面。
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        /// 此成員是方法。先前的成員是屬性。
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    /// 這是 Vector2D 類別的具現化方式。
    let vector1 = Vector2D(3.0, 4.0)

    /// 取得全新且可調整大小的向量物件，但不修改原始物件。
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f\nLength of vector2: %f" vector1.Length vector2.Length


/// 泛型類別可定義關乎一組類型參數的類型。
/// 在下列範例中，'T 是類別的型別參數。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/generics/
module DefiningGenericClasses =

    type StateTracker<'T>(initialElement: 'T) =

        /// 此內部欄位會以清單形式儲存狀態。
        let mutable states = [ initialElement ]

        /// 新增項目至狀態清單。
        member this.UpdateState newState =
            states <- newState :: states  // 使用 '<-' 運算子可變動值。

        /// 取得完整的歷程狀態清單。
        member this.History = states

        /// 取得最新狀態。
        member this.Current = states.Head

    /// 狀態追蹤器類別的 'int' 執行個體。請注意，型別參數是推斷出來的。
    let tracker = StateTracker 10

    // 加入狀態
    tracker.UpdateState 17


/// 介面為只有 'abstract' 成員的物件類型。
/// 物件類型與物件運算式可以實作介面。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/interfaces
module ImplementingInterfaces =

    /// 這是實作 IDisposable 的類型。
    type ReadFile() =

        let file = new System.IO.StreamReader("readme.txt")

        member this.ReadLine() = file.ReadLine()

        // 這是 IDisposable 成員的實作。
        interface System.IDisposable with
            member this.Dispose() = file.Close()


    /// 這是透過物件運算式實作 IDisposable 的物件
    /// 與 C# 或 Java 等其他這類語言不同，不需要新的類型定義
    /// 以實作介面。
    let interfaceImplementation =
        { new System.IDisposable with
            member this.Dispose() = printfn "disposed" }


/// FSharp.Core 程式庫定義一個範圍內的平行處理函式。這裡
/// 您可以使用一些函式對陣列進行平行處理。
///
/// 若要深入了解，請參閱: https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/array.parallel-module-%5Bfsharp%5D
module ParallelArrayProgramming =

    /// 首先，輸入的陣列。
    let oneBigArray = [| 0 .. 100000 |]

    // 接下來，定義執行某些 CPU 密集型計算的函式。
    let rec computeSomeFunction x =
        if x <= 2 then 1
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)

    // 接下來，對大型輸入陣列執行平行對應。
    let computeResults() =
        oneBigArray
        |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    // 接下來，列印結果。
    printfn "Parallel computation results: %A" (computeResults())



/// 事件是 .NET 程式設計的常見慣用語，特別是使用 WinForms 或 WPF 應用程式時。
///
/// 若要深入了解，請參閱: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/members/events
module Events =

    /// 首先，建立由訂閱點 (event.Publish) 與事件觸發程序 (event.Trigger) 所組成之事件物件的執行個體。
    let simpleEvent = new Event<int>()

    // 接下來，將處理常式新增到事件。
    simpleEvent.Publish.Add(
        fun x -> printfn "this handler was added with Publish.Add: %d" x)

    // 接下來，觸發該事件。
    simpleEvent.Trigger(5)

    // 接下來，為遵循標準 .NET 慣例的事件建立執行個體: (sender, EventArgs)。
    let eventForDelegateType = new Event<EventHandler, EventArgs>()

    // 接下來，為此新事件新增處理常式。
    eventForDelegateType.Publish.AddHandler(
        EventHandler(fun _ _ -> printfn "this handler was added with Publish.AddHandler"))

    // 接下來，觸發此事件 (請注意，應該設定 sender 引數)。
    eventForDelegateType.Trigger(null, EventArgs.Empty)



#if COMPILED
module BoilerPlateForForm =
    [<System.STAThread>]
    do ()
    do System.Windows.Forms.Application.Run()
#endif
