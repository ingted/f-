// このサンプルは、F# 言語の要素を紹介します。
//
// *******************************************************************************************************
//   F# インタラクティブでコードを実行するには、コードの一部を強調表示して、Alt キーを押しながら Enter キーを押すか、右マウス ボタンをクリックし
//   [対話形式で実行]5D; を選択します。[表示]5D; メニューから F# インタラクティブ ウィンドウを開くことができます。
// *******************************************************************************************************
//
// F# の詳細については、次のページを参照してください:
//     https://fsharp.org
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/
//
// このチュートリアルをドキュメント形式で表示するには、次を参照してください:
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/tour
//
// 適用された F# プログラミングの詳細については、次を使用します
//     https://fsharp.org/guides/enterprise/
//     https://fsharp.org/guides/cloud/
//     https://fsharp.org/guides/web/
//     https://fsharp.org/guides/data-science/
//
// Visual F# Power Tools をインストールするには、次を使用します
//     [ツール]5D; --> [拡張機能と更新プログラム]5D; --> [オンライン]5D; と検索
//
// F# で使用するその他のテンプレートについては、Visual Studio の 'オンライン テンプレート' を参照してください。
//     ([新しいプロジェクト]5D; --> [オンライン テンプレート]5D;) を参照してください。

// F# は、3 種類のコメントをサポートしています:

//  1. ダブルスラッシュ コメント。これはほとんどの場合に使用されます。
(*  2. ML スタイル ブロック コメント。これはそれほど頻繁には使用されません。 *)
/// 3. トリプル スラッシュ コメント。これは、関数や型などの文書化に使用されます。
///    このコメントで修飾されているものをポイントすると、これがテキストとして表示されます。
///
///    これは .NET スタイルの XML コメントもサポートしています。このコメントを使用すると、リファレンス ドキュメントを生成できます。
///    また、(Visual Studio などの) エディターでそこから情報を抽出することもできます。
///    詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/xml-documentation


// 'open' キーワードを使用して名前空間を開きます。
//
// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/import-declarations-the-open-keyword
open System


/// モジュールは、値、型、関数値などの、F# コードのグループ化です。
/// コードをモジュールにグループ化することで、関連コードを 1 つにまとめて、プログラムでの名前の競合を回避することができます。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/modules
module IntegersAndNumbers =

    /// これは、サンプルの整数値です。
    let sampleInteger = 176

    /// これは、サンプルの浮動小数点数です。
    let sampleDouble = 4.1

    /// 算術によって新しい数値が算出されました。数値型は以下を使用するよう変換されています
    /// 関数の 'int'、'double' などです。
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    /// これは 0 ～ 99 の数値のリストです。
    let sampleNumbers = [ 0 .. 99 ]

    /// これは、0 ～ 99 のすべての数値とその二乗を含むすべてのタプルのリストです。
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // 次の行は、タプルを含むリストを出力します。一般的な出力に '%A' を使用しています。
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfSquares

    // これは、型の注釈付きのサンプルの整数です
    let sampleInteger3: int = 1


/// 既定では、F# の値は不変です。明示的に変更可能として指定しない限り、
/// プログラムの実行の過程で変更することはできません。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/values/index#why-immutable
module Immutability =

    /// 'let' を介して値を名前にバインドすると、変更できなくなります。
    ///
    /// コードの 2 番目の行は、'number' が変更できず、バインドされているため、コンパイルに失敗します。
    /// F# では、'number' を別の値に再定義することはできません。
    let number = 2
    // let number = 3

    /// 変更可能なバインド。これは 'otherNumber' の値を変更できるようにするために必要です。
    let mutable otherNumber = 2

    printfn "'otherNumber' is %d" otherNumber

    // 値を変換する場合は、'<-' を使用して新しい値を割り当てます。
    //
    // この場合、'=' は等価を示すために使用するため、ここで使用することはできません
    // または、'let' や 'module' などの他のコンテキスト
    otherNumber <- otherNumber + 1

    printfn "'otherNumber' changed to be %d" otherNumber


/// F# プログラミングの多くは、生成する入力データを変換する定義する関数で構成されています
/// 有用な結果。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/functions/
module BasicFunctions =

    /// 関数を定義するには、'let' を使用します。これは整数の引数を受け取り、整数を返します。
    /// 明示的な型の注釈を使用する場合を除いて、かっこは関数引数では省略可能です。
    let sampleFunction1 x = x*x + 3

    /// 関数を適用します。'let' を使用し、関数の戻り値の結果に名前を付けます。
    /// 変数の型は、関数の戻り値の型から推論されます。
    let result1 = sampleFunction1 4573

    // この行は '%d' を使用して結果を整数として出力します。これはタイプ セーフです。
    // 'result1' が 'int' 型でなかった場合、行はコンパイルに失敗します。
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    /// 必要であれば、'(引数:型)' を使用してパラメーター名の型に注釈を付けます。かっこは必須です。
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn "The result of applying the 2nd sample function to (7 + 4) is %d" result2

    /// 条件は、if/then/elid/elif/else を使用します。
    ///
    /// F# は Python などの言語のように、空白のインデント対応構文を使用することに注意してください。
    let sampleFunction3 x =
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)

    // この行は  '%f' を使用して結果を浮動小数として出力します。上記の '%d' と同様に、これはタイプ セーフです。
    printfn "The result of applying the 3rd sample function to (6.5 + 4.5) is %f" result3


/// ブール値は F# の基本のデータ型です。ブール値と条件ロジックの例をいくつか示します。
///
/// 詳細については、次を参照してください:
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/primitive-types
///     AND
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/symbol-and-operator-reference/boolean-operators
module Booleans =

    /// ブール型の値は 'true' と 'false' です。
    let boolean1 = true
    let boolean2 = false

    /// ブール値の演算子は 'not'、'&&'、および '||' です。
    let boolean3 = not boolean1 && (boolean2 || false)

    // この行は '%b' を使用してブール値を出力します。これはタイプ セーフです。
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %b" boolean3


/// 文字列は F# の基本のデータ型です。文字列と基本的な文字列操作の例をいくつか示します。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/strings
module StringManipulation =

    /// 文字列は二重引用符を使用します。
    let string1 = "Hello"
    let string2  = "world"

    /// 文字列は @ を使用して、verbatim 文字列リテラルを作成することもできます。
    /// これは、'\'、'\n'、'\t' などのエスケープ文字を無視します。
    let string3 = @"C:\Program Files\"

    /// 文字列リテラルは三重引用符を使用することもできます。
    let string4 = """The computer said "hello world" when I told it to!"""

    /// 通常、文字列の連結は '+' 演算子を使用して実行されます。
    let helloWorld = string1 + " " + string2

    // この行は、'%s' を使用して文字列値を出力します。これはタイプ セーフです。
    printfn "%s" helloWorld

    /// サブ文字列はインデクサー表記を使用します。この行はサブ文字列として最初の 7 文字を抽出します。
    /// 多くの言語と同様に、F# では、文字列のインデックスは 0 から始まることに注意してください。
    let substring = helloWorld.[0..6]
    printfn "%s" substring


/// タプルは、データ値と合計値の単純な組み合わせです。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/tuples
module Tuples =

    /// 整数のシンプルなタプルです。
    let tuple1 = (1, 2, 3)

    /// タプルの 2 つの値の順序を入れ替える関数。
    ///
    /// F# 型の推定は、ジェネリック型を持つように関数を自動的に一般化し、
    /// 任意の型で動作することを意味します。
    let swapElems (a, b) = (b, a)

    printfn "The result of swapping (1, 2) is %A" (swapElems (1,2))

    /// タプルを構成するのは、整数、文字列、
    /// および倍精度浮動小数点数です。
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A\ttuple2: %A" tuple1 tuple2

    /// 型の注釈が指定された整数のシンプルなタプル。
    /// タプルの型の注釈では、要素を区切るために * の記号を使用します
    let tuple3: int * int = (5, 9)

    /// タプルは通常はオブジェクトですが、構造体として表すこともできます。
    ///
    /// C# と Visual Basic.NET では、これらは構造体と完全に相互運用されます。ただし、
    /// 構造体のタプルは、オブジェクト タプル (参照タプルと呼ばれることが多い) と暗黙的に変換できません。
    ///
    /// このため、以下の 2 番目の行はコンパイルに失敗します。発生する事象を確認するには、コメントを解除します。
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // 構造体タプルと参照タプル間で暗黙的に変換することはできませんが、
    // 以下に示すように、パターン マッチングを使用して明示的に変換できます。
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)

    printfn "Struct Tuple: %A\nReference tuple made from the Struct Tuple: %A" sampleStructTuple (sampleStructTuple |> convertFromStructTuple)


/// F# パイプ演算子 ('|>'、'<|' など) と F# 合成演算子 ('>>'、'<<')
/// は、データの処理時に幅広く使用されます。これらの演算子はそれ自体が関数であり、
/// 部分適用を利用します。
///
/// これらの演算子の詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/functions/#function-composition-and-pipelining
/// 部分適用の詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/functions/#partial-application-of-arguments
module PipelinesAndComposition =

    /// 値を 2 乗します。
    let square x = x * x

    /// 値に 1 を追加します。
    let addOne x = x + 1

    /// 剰余を使って整数値が奇数であるかどうかをテストします。
    let isOdd x = x % 2 <> 0

    /// 5 個の数値のリストです。リストの詳細については後述。
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// 整数のリストを指定すると、偶数を除外し、
    /// 結果の奇数を 2 乗し、2 乗した奇数に 1 を加算します。
    let squareOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" numbers (squareOddValuesAndAddOne numbers)

    /// 'squareOddValuesAndAddOne' を記述するためのより簡単な方法は、
    /// それぞれのサブ結果を関数呼び出し自体に入れ子にすることです。
    ///
    /// これにより、関数は大幅に短くなりますが、データが処理される順序を
    /// 判別するのは難しくなります。
    let squareOddValuesAndAddOneNested values =
        List.map addOne (List.map square (List.filter isOdd values))

    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers (squareOddValuesAndAddOneNested numbers)

    /// 'squareOddValuesAndAddOne' を記述するための推奨される方法は、F# パイプ演算子を使用する方法です。
    /// これにより、中間結果を作成しなくてもよくなります。また、
    /// 'squareOddValuesAndAddOneNested' のような関数呼び出しを入れ子にするよりもはるかに読みやすくすることができます
    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    printfn "processing %A through 'squareOddValuesAndAddOnePipeline' produces: %A" numbers (squareOddValuesAndAddOnePipeline numbers)

    /// ラムダ関数を使用して、2 番目の `List.map` 呼び出しを先頭に移動することにより、
    /// 'squareOddValuesAndAddOnePipeline' を短くすることができます。
    ///
    /// パイプラインはラムダ関数の内部でも使用されることに注意してください。F# パイプ演算子は、
    /// 単一の値にも使用できます。これにより、データ処理能力が向上します。
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" numbers (squareOddValuesAndAddOneShorterPipeline numbers)

    /// 最後に、'>>' を使用して次の 2 つのコア操作を作成すると、'values' をパラメーターとして
    /// 明示的に受け取る必要がなくなります: 偶数を除外してから、2 乗して 1 を加算する。
    /// 同様に、ラムダ式の 'fun x -> ...' ビットも必要ありません。 'x' は単に、
    /// 関数型パイプラインに渡すことができるようにそのスコープ内で定義されているだけだからです。そのため、
    /// そこでも同様に '>>' を使用できます。
    ///
    /// 'squareOddValuesAndAddOneComposition' の結果は、それ自体が別の関数です。その関数は、
    /// 整数のリストを入力として受け取ります。整数のリストを指定して 'squareOddValuesAndAddOneComposition' を
    /// 実行すると、前の関数と同じ結果が生成されることがわかります。
    ///
    /// これは、関数合成と呼ばれるものを使用しています。これが可能なのは、F# の関数が
    /// 部分適用を使用しており、各データ処理操作の入力と出力の型が、使用している
    /// 関数のシグネチャと一致するためです。
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneComposition' produces: %A" numbers (squareOddValuesAndAddOneComposition numbers)


/// リストは、順序指定された、変更できない単方向リストです。  リストは集中評価されます。
///
/// このモジュールは、リストを生成し、F# コア ライブラリ内の 'List' モジュールに含まれる
/// いくつかの関数を使用してリストを処理するためのさまざまな方法を示しています。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/lists
module Lists =

    /// リストは [ ... ] を使用して定義されます。これは空のリストです。
    let list1 = [ ]

    /// これは 3 つの要素を含むリストです。';' は同じ行にある要素を区切るために使用されます。
    let list2 = [ 1; 2; 3 ]

    /// 要素は、それぞれの行に配置することで分割することもできます。
    let list3 = [
        1
        2
        3
    ]

    /// これは 1 ～ 1000 の整数のリストです
    let numberList = [ 1 .. 1000 ]

    /// リストは計算によっても生成できます。これは、次を含むリストです:
    /// 1 年のすべての日。
    let daysList =
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                  yield System.DateTime(2017, month, day) ]

    // 'List.take' を使用して 'daysList' の最初の 5 つの要素を出力します。
    printfn "The first 5 days of 2017 are: %A" (daysList |> List.take 5)

    /// 計算には条件を含めることができます。これはタプルを含むリストです
    /// チェス盤の黒いマス目の座標のタプルを含むリストです。
    let blackSquares =
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do
                  if (i+j) % 2 = 1 then
                      yield (i, j) ]

    /// リストは 'List.map' と他の関数型プログラミング連結子を使用して変換することができます。
    /// この定義は、パイプラインを使用して numberList 内の数値を 2 乗することによって新しいリストを生成します
    /// 引数を List.map に渡す演算子です。
    let squares =
        numberList
        |> List.map (fun x -> x*x)

    /// 他に多くのリストの組み合わせがあります。次の二乗和をコンピューティングします:
    /// 3 で割り切れる数。
    let sumOfSquares =
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)

    printfn "The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d" sumOfSquares


/// 配列は、型が同じ要素の固定サイズの変更可能なコレクションです。
///
/// これらはリストと似ています (列挙型をサポートし、データ処理のための同様の連結子を備えています) が、
/// 一般的により高速であり、高速ランダム アクセスをサポートしています。その代わり、変更可能であるため安全性が低下します。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/arrays
module Arrays =

    /// これは空の配列です。構文はリストの構文と似ていますが、代わりに `[| ... |]` を使用することにご注意ください。
    let array1 = [| |]

    /// 配列は、リストと同じコンストラクトの範囲を使用して指定されます。
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// これは 1 ～ 1000 の数値の配列です。
    let array3 = [| 1 .. 1000 |]

    /// これは "hello" と "world" のみを含む配列です。
    let array4 =
        [| for word in array2 do
               if word.Contains("l") then
                   yield word |]

    /// これはインデックスによって初期化され、0 ～ 2000 の間の偶数を含む配列です。
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// サブ配列はスライス表記法を使用して抽出されます。
    let evenNumbersSlice = evenNumbers.[0..500]

    /// 'for' ループを使用して、配列とリストに渡ってループできます。
    for word in array4 do
        printfn "word: %s" word

    // 左矢印代入演算子を使用して、配列要素の内容を変更できます。
    //
    // この演算子の詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/values/index#mutable-variables
    array2.[1] <- "WORLD!"

    /// 'Array.map' と他の関数型プログラミング操作を使用して、配列を変換できます。
    /// 以下は、'h' で始まる単語の長さの合計を計算します。
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn "The sum of the lengths of the words in Array 2 is: %d" sumOfLengthsOfWords


/// シーケンスは論理的な一連の要素であり、すべてが同じ型です。これらはリストや配列よりも一般的な型です。
///
/// シーケンスはオンデマンドで評価され、繰り返されるたびに再評価されます。
/// F# シーケンスは .NET System.Collections.Generic.IEnumerable<'T> のエイリアスです。
///
/// シーケンス処理関数はリストと配列にも適用できます。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/sequences
module Sequences =

    /// これは空のシーケンスです。
    let seq1 = Seq.empty

    /// これは一連の値です。
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    /// これは 1 ～ 1000 のオンデマンドのシーケンスです。
    let numbersSeq = seq { 1 .. 1000 }

    /// これは 単語 "hello" と "world" を生成するシーケンスです
    let seq3 =
        seq { for word in seq2 do
                  if word.Contains("l") then
                      yield word }

    /// このシーケンスは、2000 までの偶数を生成します。
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    /// これはランダム ウォークである無限シーケンスです。
    /// この例では、yield! を使用して、サブシーケンスの各要素を返します。
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// この例では、ランダム ウォークの最初の 100 要素を示します。
    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList

    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk


/// 再帰関数は自身を呼び出すことができます。F# では、関数は単に再帰的です
/// 'let rec' を使用して宣言される場合。
///
/// 再帰は、F# でシーケンスまたはコレクションを処理するための推奨される方法です。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/functions/index#recursive-functions
module RecursiveFunctions =

    /// この例では、次の階乗をコンピューティングする再帰関数を示します
    /// 整数。'let rec' を使用して、再帰関数を定義します。
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n-1)

    printfn "Factorial of 6 is: %d" (factorial 6)

    /// 2 つの整数の最大公約数をコンピューティングします。
    ///
    /// すべての再帰呼び出しは末尾呼び出しであるため、
    /// コンパイラは関数をループにします
    /// これによりパフォーマンスが向上し、メモリの消費を抑えることができます。
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn "The Greatest Common Factor of 300 and 620 is %d" (greatestCommonFactor 300 620)

    /// この例では、再帰を使用して整数のリストの合計をコンピューティングします。
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    /// これは、ヘルパー関数を結果アキュムレータと共に使用して 'sumList' を末尾再帰にします。
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    /// これは、シード アキュムレータとして '0' を指定して、末尾再帰的なヘルパー関数を呼び出します。
    /// F# では、このようなアプローチは一般的です。
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn "The sum 1-10 is %d" (sumListTailRecursive oneThroughTen)


/// レコードは、オプションのメンバー (メソッドなど) を含む名前付きの値の集約です。
/// これらは変更できず、構造上の等価セマンティクスを持ちます。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/records
module RecordTypes =

    /// この例では、新しいレコード型を定義する方法を示します。
    type ContactCard =
        { Name     : string
          Phone    : string
          Verified : bool }

    /// この例では、レコードの種類をインスタンス化する方法を示します。
    let contact1 =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false }

    /// ';' 区切りを使用して、同じ行でこれを行うこともできます。
    let contactOnSameLine = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

    /// この例では、レコード値で "copy-and-update" を使用する方法を示します。次を作成します:
    /// contact1 のコピーであるレコード値。ただし、次の値は異なります:
    /// [電話番号]5D; および [検証済み]5D; フィールド。
    ///
    /// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/copy-and-update-record-expressions
    let contact2 =
        { contact1 with
            Phone = "(206) 555-0112"
            Verified = true }

    /// この例では、レコード値を処理する関数を書き込む方法を示します。
    /// 'ContactCard' オブジェクトを文字列に変換します。
    let showContactCard (c: ContactCard) =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn "Alf's Contact Card: %s" (showContactCard contact1)

    /// これは、メンバーを含むレコードの例です。
    type ContactCardAlternate =
        { Name     : string
          Phone    : string
          Address  : string
          Verified : bool }

        /// メンバーはオブジェクト指向のメンバーを実装できます。
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified)" else "") + this.Address

    let contactAlternate =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false
          Address = "111 Alf Street" }

    // メンバーには、インスタンス化された型に対する '.' 演算子を介してアクセスできます。
    printfn "Alf's alternate contact card is %s" contactAlternate.PrintedContactCard

    /// レコードは 'Struct' 属性を介して構造体として表すこともできます。
    /// これは、構造体のパフォーマンスが参照型の柔軟性よりも
    /// 重要である場合に役立ちます。
    [<Struct>]
    type ContactCardStruct =
        { Name     : string
          Phone    : string
          Verified : bool }


/// 判別共用体 (略して DU) は、多数の名前付きのフォームまたはケースである可能性のある値です。
/// DU の格納データは、複数の個別の値のいずれかになります。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/discriminated-unions
module DiscriminatedUnions =

    /// たとえば、次は一揃いのトランプを表します。
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    /// 判別共用体はトランプのランクを表すためにも使用できます。
    type Rank =
        /// 2 ～ 10 の札のランクを表します
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        /// 判別共用体はオブジェクト指向のメンバーを実装することもできます。
        static member GetAllRanks() =
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]

    /// これは Suit と Rank を組み合わせたレコード型です。
    /// データを表すときには、レコードと判別共用体の両方を使用するのが一般的です。
    type Card = { Suit: Suit; Rank: Rank }

    /// これは、一組のトランプのすべてのカードを表すリストをコンピューティングします。
    let fullDeck =
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do
                  yield { Suit=suit; Rank=rank } ]

    /// この例では 'Card' オブジェクトを文字列に変換します。
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

    /// この例では、一組のトランプのカードすべてを印刷します。
    let printAllCards() =
        for card in fullDeck do
            printfn "%s" (showPlayingCard card)

    // 単一ケースの DU は、ドメイン モデリングで多く使用されます。これにより、文字列や整数などの
    // プリミティブ型に加えて、さらにタイプ セーフが追加されます。
    //
    // 単一ケースの DU は、ラップする型との間で暗黙的に変換することはできません。
    // たとえば、アドレスを受け取る関数は文字列をその入力として受け入れることはできません
    // (その逆もできません)。
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    // 次のように、単一ケースの DU のインスタンスを簡単に作成できます。
    let address = Address "111 Alf Way"
    let name = Name "Alf"
    let ssn = SSN 1234567890

    /// 値が必要な場合は、簡単な関数を使用して基になる値のラップを解除できます。
    let unwrapAddress (Address a) = a
    let unwrapName (Name n) = n
    let unwrapSSN (SSN s) = s

    // 単一ケースの DU は、関数のラップを解除するだけで出力できます。
    printfn "Address: %s, Name: %s, and SSN: %d" (address |> unwrapAddress) (name |> unwrapName) (ssn |> unwrapSSN)

    /// 判別共用体は再帰的な定義もサポートしています。
    ///
    /// これはバイナリ検索ツリーを表します。片方のケースは空のツリーであり、
    /// もう片方は値と 2 つのサブツリーを含む Node です。
    type BST<'T> =
        | Empty
        | Node of value:'T * left: BST<'T> * right: BST<'T>

    /// バイナリ検索ツリーにアイテムが存在するかどうかを確認します。
    /// パターン マッチングを使用して再帰的に検索します。存在する場合は true を返し、そうでない場合は false を返します。
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left) // 左側のサブツリーを確認します。
            else (exists item right) // 右側のサブツリーを確認します。

    /// バイナリ検索ツリーにアイテムを挿入します。
    /// パターン マッチングを使用して再帰的に挿入する場所を検索し、新しいノードを挿入します。
    /// アイテムが既に存在する場合は、何も挿入しません。
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node // 既に存在しているため、挿入する必要はありません。ノードを返します。
            elif item < x then Node(x, insert item left, right) // 左側のサブツリーに呼び出します。
            else Node(x, left, insert item right) // 右側のサブツリーに呼び出します。

    /// 判別共用体は、'Struct' 属性を介して構造体として表すこともできます。
    /// これは、構造体のパフォーマンスが参照型の柔軟性よりも
    /// 重要である場合に役立ちます。
    ///
    /// ただし、これを行うときに理解しておく必要のある重要な点が 2 つあります:
    ///     1. 構造体 DU は再帰的に定義できません。
    ///     2. 構造体 DU の名前は各ケースに対して一意である必要があります。
    [<Struct>]
    type Shape =
        | Circle of radius: float
        | Square of side: float
        | Triangle of height: float * width: float


/// パターン マッチングはパターンを使用できるようにする F# の機能です。
/// これは、データと 1 つまたは複数の論理構造を比較したり、
/// データを構成要素部分に分解したり、さまざまな方法でデータから情報を抽出したりするための方法です。
/// その後、パターン マッチングを介してパターンの "形" でディスパッチできます。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/pattern-matching
module PatternMatching =

    /// 個人の姓および名のレコード
    type Person = {
        First : string
        Last  : string
    }

    /// 3 種類の社員の判別共用体
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// 管理階層構造の中で、ある社員の下にいる全員の数を数えます
    /// (その社員自身を含む)。
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(id) ->
                0
            | Manager(id, reports) ->
                reports |> List.sumBy countReports
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    /// 名前が "Dave" で、レポートのないすべてのマネージャー/役員を検索します。
    /// これは、ラムダ式として 'function' の短縮形を使用します。
    let rec findDaveWithOpenPosition(emps : List<Employee>) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true // [] は空白のリストに一致します。
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false) // '_' は、任意のものに一致するワイルドカード パターンです。
                                     // これは "or else" ケースを処理します。

    /// パターン マッチングのために、短縮形の関数コンストラクトを使用することもできます。
    /// これは、部分適用を利用する関数を記述している場合に役立ちます。
    let private parseHelper f = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDateTimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    // ヘルパー関数で解析する別の関数をいくつか定義します。
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

    // アクティブなパターンは、パターン マッチングで使用するもう 1 つの強力なコンストラクトです。
    // パターン マッチの呼び出しサイトで分解して、入力データをカスタム フォームにパーティション分割できるようにします。
    //
    // 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/active-patterns
    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    /// 'function' キーワードとアクティブ パターンによるパターン マッチングは、多くの場合、次のようになります。
    let printParseResult = function
        | Int x -> printfn "%d" x
        | Double x -> printfn "%f" x
        | Date d -> printfn "%s" (d.ToString())
        | TimeSpan t -> printfn "%s" (t.ToString())
        | _ -> printfn "Nothing was parse-able!"

    // 解析するいくつかの異なる値でプリンターを呼び出します。
    printParseResult "12"
    printParseResult "12.045"
    printParseResult "12/28/2016"
    printParseResult "9:01PM"
    printParseResult "banana!"


/// オプション値とは、'Some' または 'None' がタグされたあらゆる種類の値です。
/// F# コードで広く使用され、他の多くの言語で null 参照が使用される
/// ケースを表します。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/options
module OptionValues =

    /// まず、単一ケースの判別共用体を介して定義した郵便番号を定義します。
    type ZipCode = ZipCode of string

    /// 次に、郵便番号が省略可能である型を定義します。
    type Customer = { ZipCode: ZipCode option }

    /// 次に、オブジェクトを表すインターフェイスの型を定義して、顧客の郵便番号の出荷ゾーンをコンピューティングし、
    /// 'getState' および 'getShippingZone' 抽象メソッドの実装が指定されています。
    type ShippingCalculator =
        abstract GetState : ZipCode -> string option
        abstract GetShippingZone : string -> int

    /// 次に、電卓のインスタンスを使用して顧客の出荷ゾーンを計算します。
    /// これは、オプション モジュール内の連結子を使用することにより、オプションを使用したデータ変換のために
    /// 関数型パイプラインを使用できるようにします。
    let CustomerShippingZone (calculator: ShippingCalculator, customer: Customer) =
        customer.ZipCode
        |> Option.bind calculator.GetState
        |> Option.map calculator.GetShippingZone


/// 測定単位は、タイプ セーフな方法でプリミティブな数値型に注釈を付ける方法です。
/// 次に、これらの値に対してタイプ セーフの算術を実行できます。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/units-of-measure
module UnitsOfMeasure =

    /// まず、共通の単位名のコレクションを開きます
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    /// 単位化された定数を定義します
    let sampleValue1 = 1600.0<meter>

    /// 次に、新しい単位の種類を定義します
    [<Measure>]
    type mile =
        /// マイルからメートルへの変換係数。
        static member asMeter = 1609.34<meter/mile>

    /// 単位化された定数を定義します
    let sampleValue2  = 500.0<mile>

    /// メートル法の定数をコンピューティングします
    let sampleValue3 = sampleValue2 * mile.asMeter

    // 測定単位を使用する値は、印刷などに対するプリミティブな数値型と同じように使用できます。
    printfn "After a %f race I would walk %f miles which would be %f meters" sampleValue1 sampleValue2 sampleValue3


/// クラスは、F# で新しいオブジェクト型を定義する方法であり、標準のオブジェクト指向のコンストラクトをサポートします。
/// さまざまなメンバー (メンバー、プロパティ、イベントなど) を含めることができます
///
/// クラスの詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/classes
///
/// メンバーの詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/members
module DefiningClasses =

    /// 単純な 2 次元のベクター クラス。
    ///
    /// クラスのコンストラクターは最初の行にあり、
    /// また、dx と dy の 2 つの引数を取ります。どちらも 'double' 型です。
    type Vector2D(dx : double, dy : double) =

        /// この内部フィールドはベクトルの長さを格納します。これは、次の時点でにコンピューティングされます:
        /// オブジェクトが構築されます
        let length = sqrt (dx*dx + dy*dy)

        // 'this' は、オブジェクトの自己識別子の名前を指定します。
        // インスタンス メソッドでは、メンバー名の前に表示される必要があります。
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        /// このメンバーはメソッドです。前のメンバーはプロパティでした。
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    /// これは、Vector2D クラスのインスタンスを作成する方法です。
    let vector1 = Vector2D(3.0, 4.0)

    /// 元のオブジェクトを変更せずに、新しく調節されたベクター オブジェクトを取得します。
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f\nLength of vector2: %f" vector1.Length vector2.Length


/// ジェネリック クラスでは、型パラメーターのセットに対して型を定義することができます。
/// 以下では、'T はクラスの型パラメーターです。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/generics/
module DefiningGenericClasses =

    type StateTracker<'T>(initialElement: 'T) =

        /// この内部フィールドは状態をリストに保存します。
        let mutable states = [ initialElement ]

        /// 状態のリストに新しい要素を追加します。
        member this.UpdateState newState =
            states <- newState :: states  // '<-' 演算子を使用して、値を変換します。

        /// 状態の履歴のリスト全体を取得します。
        member this.History = states

        /// 最新の状態を取得します。
        member this.Current = states.Head

    /// 状態トラッカー クラスの 'int' インスタンス。型パラメーターは推論されていることに注意してください。
    let tracker = StateTracker 10

    // 状態を追加します
    tracker.UpdateState 17


/// インターフェイスは 'abstract' メンバーのみを持つオブジェクト型です。
/// オブジェクト型とオブジェクト式はインターフェイスを実装できます。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/interfaces
module ImplementingInterfaces =

    /// これは IDisposable を実装する型です。
    type ReadFile() =

        let file = new System.IO.StreamReader("readme.txt")

        member this.ReadLine() = file.ReadLine()

        // これは IDisposable メンバーの実装です。
        interface System.IDisposable with
            member this.Dispose() = file.Close()


    /// これは、オブジェクト式を使用して IDisposable を実装するオブジェクトです
    /// C# や Java などの他の言語とは異なり、インターフェイスを実装するために
    /// 新しい型定義は必要ありません。
    let interfaceImplementation =
        { new System.IDisposable with
            member this.Dispose() = printfn "disposed" }


/// FSharp.Core ライブラリは並列処理関数の範囲を定義します。ここでは
/// アレイ全体で並列処理に対していくつかの関数を使用できます。
///
/// 詳細については、次を参照してください: https://msdn.microsoft.com/ja-jp/visualfsharpdocs/conceptual/array.parallel-module-%5Bfsharp%5D
module ParallelArrayProgramming =

    /// まず、入力の配列です。
    let oneBigArray = [| 0 .. 100000 |]

    // 次に、CPU 集約型の計算を実行する関数を定義します。
    let rec computeSomeFunction x =
        if x <= 2 then 1
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)

    // 次に、大きい入力配列に対して並列マップを実行します。
    let computeResults() =
        oneBigArray
        |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    // 次に、結果を印刷します。
    printfn "Parallel computation results: %A" (computeResults())



/// イベントは、特に WinForms または WPF アプリケーションでの .NET プログラミングの一般的な用法です。
///
/// 詳細については、次を参照してください: https://docs.microsoft.com/ja-jp/dotnet/articles/fsharp/language-reference/members/events
module Events =

    /// まず、サブスクリプション ポイント (event.Publish) およびイベント トリガー (event.Trigger) で構成されるイベント オブジェクトのインスタンスを作成します。
    let simpleEvent = new Event<int>()

    // 次に、ハンドラーをイベントに追加します。
    simpleEvent.Publish.Add(
        fun x -> printfn "this handler was added with Publish.Add: %d" x)

    // 次に、イベントをトリガーします。
    simpleEvent.Trigger(5)

    // 次に、標準的な .NET 表記規則に従うイベントのインスタンスを作成します: (sender, EventArgs)。
    let eventForDelegateType = new Event<EventHandler, EventArgs>()

    // 次に、この新しいイベントのハンドラーを追加します。
    eventForDelegateType.Publish.AddHandler(
        EventHandler(fun _ _ -> printfn "this handler was added with Publish.AddHandler"))

    // 次に、このイベントをトリガーします (sender 引数を設定する必要があります)。
    eventForDelegateType.Trigger(null, EventArgs.Empty)



#if COMPILED
module BoilerPlateForForm =
    [<System.STAThread>]
    do ()
    do System.Windows.Forms.Application.Run()
#endif
