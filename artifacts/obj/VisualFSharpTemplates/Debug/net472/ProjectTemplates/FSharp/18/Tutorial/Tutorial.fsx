// 이 샘플에서는 F# 언어의 요소에 대해 안내합니다.
//
// *******************************************************************************************************
//   F# 대화형에서 코드를 실행하려면 코드 섹션을 강조 표시하고 <Alt+Enter>를 누르거나 마우스 오른쪽 단추를 클릭한 다음
//   "대화형으로 실행"을 선택하세요.  "보기" 메뉴에서 F# 대화형 창을 열 수 있습니다.
// *******************************************************************************************************
//
// F#에 대한 자세한 내용은 다음을 참조하세요.
//     https://fsharp.org
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/
//
// 이 자습서를 설명서 형식으로 보려면 다음을 참조하세요.
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/tour
//
// 적용된 F# 프로그래밍에 대해 자세히 알아보려면 다음을 사용하세요.
//     https://fsharp.org/guides/enterprise/
//     https://fsharp.org/guides/cloud/
//     https://fsharp.org/guides/web/
//     https://fsharp.org/guides/data-science/
//
// Visual F# Power 도구를 설치하려면 다음을 사용하세요.
//     '도구' --> '확장 및 업데이트' --> `온라인`으로 이동하고 검색합니다.
//
// F#과 함께 사용할 수 있는 추가 템플릿은 Visual Studio의 다음 위치에서 '온라인 템플릿'을 참조하세요.
//     '새 프로젝트' --> '온라인 템플릿'

// F#에서는 세 가지 종류의 주석을 지원합니다.

//  1. 이중 슬래시 주석은 대부분의 경우에 사용됩니다.
(*  2. ML 스타일 블록 주석은 자주 사용되지 않습니다. *)
/// 3. 삼중 슬래시 주석은 함수, 형식 등을 설명하는 경우에 사용됩니다.
///    이러한 주석으로 데코레이트된 항목 위에 마우스를 올리면 텍스트로 표시됩니다.
///
///    참조 문서를 생성할 수 있는 .NET 스타일 XML 주석도 지원하며,
///    또한 편집기(예: Visual Studio)에서 정보를 추출할 수 있도록 합니다.
///    자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/xml-documentation


// 'open' 키워드를 사용하여 네임스페이스를 엽니다.
//
// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/import-declarations-the-open-keyword
open System


/// 모듈은 값, 형식, 함수 값 같은 F# 코드의 그룹화입니다.
/// 모듈로 코드를 그룹화하면 관련 코드를 함께 유지하고 프로그램에서 이름 충돌을 방지하는 데 도움이 됩니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/modules
module IntegersAndNumbers =

    /// 샘플 정수입니다.
    let sampleInteger = 176

    /// 샘플 부동 소수점 숫자입니다.
    let sampleDouble = 4.1

    /// 산술을 사용하여 새 수를 계산했습니다. 숫자 형식은
    /// 'int', 'double' 등의 함수를 사용하여 변환됩니다.
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    /// 0에서 99까지의 숫자 목록입니다.
    let sampleNumbers = [ 0 .. 99 ]

    /// 0에서 99까지의 모든 숫자와 제곱을 포함하는 모든 튜플 목록입니다.
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // 다음 줄은 제네릭 출력에 대해 '%A'을(를) 사용하여 튜플을 포함하는 목록을 출력합니다.
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfSquares

    // 형식 주석이 있는 샘플 정수입니다.
    let sampleInteger3: int = 1


/// F#의 값은 기본적으로 변경할 수 없습니다. 변경 가능으로
/// 명시적으로 표시되지 않는 한 프로그램 실행 중 변경할 수 없습니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/values/index#why-immutable
module Immutability =

    /// 'let'을 통해 값을 이름에 바인딩하면 값을 변경할 수 없게 됩니다.
    ///
    /// 'number'는 변경이 불가능하고 바인딩되어 있으므로 코드의 두 번째 줄이 컴파일되지 않습니다.
    /// F#에서는 'number'를 다른 값으로 다시 정의할 수 없습니다.
    let number = 2
    // let number = 3

    /// 변경할 수 있는 바인딩은 'otherNumber' 값을 변경하기 위해 필요합니다.
    let mutable otherNumber = 2

    printfn "'otherNumber' is %d" otherNumber

    // 값을 변경할 때는 '<-'를 사용하여 새 값을 할당하세요.
    //
    // '='이 같음에 대해 사용되지 않으므로 여기에서 이 용도로 '='을 사용할 수 없습니다.
    // 또는 'let'이나 'module' 같은 기타 컨텍스트
    otherNumber <- otherNumber + 1

    printfn "'otherNumber' changed to be %d" otherNumber


/// 대부분의 F# 프로그래밍은 유용한 결과를 생성하기 위해 입력 데이터를 변환하는 함수 정의로
/// 구성됩니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/
module BasicFunctions =

    /// 'let'을 사용하여 정수 인수를 받고 정수를 반환하는 함수를 정의합니다.
    /// 괄호는 명시적 형식 주석을 사용하는 경우 외에는 함수 인수에 선택적으로 사용할 수 있습니다.
    let sampleFunction1 x = x*x + 3

    /// 함수를 적용하고, 'let'을 사용하여 함수 반환 결과에 이름을 지정합니다.
    /// 변수 형식은 함수 반환 형식에서 유추됩니다.
    let result1 = sampleFunction1 4573

    // 이 줄은 '%d'을(를) 사용하여 결과를 integer로 인쇄합니다. 이 코드는 형식이 안전합니다.
    // 'result1'이 'int' 형식이 아닌 경우 줄이 컴파일되지 않습니다.
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    /// 필요한 경우 '(argument:type)'을 사용하여 매개 변수 이름 형식에 대한 주석을 답니다. 괄호가 필요합니다.
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn "The result of applying the 2nd sample function to (7 + 4) is %d" result2

    /// 조건은 if/then/elid/elif/else를 사용합니다.
    ///
    /// F#은 Python과 같은 언어처럼 공백 들여쓰기 인식 구문을 사용합니다.
    let sampleFunction3 x =
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)

    // 이 줄은 '%f'을(를) 사용하여 결과를 float으로 인쇄합니다. 위의 '%d'처럼 이 코드는 형식이 안전합니다.
    printfn "The result of applying the 3rd sample function to (6.5 + 4.5) is %f" result3


/// 부울은 F#에서 기본적인 데이터 형식입니다. 다음은 부울 및 조건부 논리의 몇 가지 예입니다.
///
/// 자세히 알아보려면 다음을 참조하세요.
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/primitive-types
///     그리고
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/symbol-and-operator-reference/boolean-operators
module Booleans =

    /// 부울 값은 'true' 및 'false'입니다.
    let boolean1 = true
    let boolean2 = false

    /// 부울의 연산자는 'not', '&&' 및 '||'입니다.
    let boolean3 = not boolean1 && (boolean2 || false)

    // 이 줄은 '%b'을(를) 사용하여 부울 값을 인쇄합니다. 이 코드는 형식이 안전합니다.
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %b" boolean3


/// 문자열은 F#에서 기본적인 데이터 형식입니다. 다음은 문자열 및 기본 문자열 조작의 몇 가지 예입니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/strings
module StringManipulation =

    /// 문자열은 큰따옴표를 사용합니다.
    let string1 = "Hello"
    let string2  = "world"

    /// 또한 문자열은 @을 사용하여 축자 문자열 리터럴을 만듭니다.
    /// 이 경우 '\', '\n', '\t' 등과 같은 이스케이프 문자열을 무시합니다.
    let string3 = @"C:\Program Files\"

    /// 또한 문자열 리터럴은 세 따옴표를 사용합니다.
    let string4 = """The computer said "hello world" when I told it to!"""

    /// 문자열 연결은 일반적으로 '+' 연산자로 합니다.
    let helloWorld = string1 + " " + string2

    // 이 줄은 '%s'을(를) 사용하여 문자열 값을 인쇄합니다. 이 코드는 형식이 안전합니다.
    printfn "%s" helloWorld

    /// 부분 문자열은 인덱서 표기법을 사용합니다. 이 줄은 처음 7개 문자를 부분 문자열로 추출합니다.
    /// 다른 여러 언어처럼 F#에서는 문자열이 0으로 인덱싱됩니다.
    let substring = helloWorld.[0..6]
    printfn "%s" substring


/// 튜플은 데이터 값을 조합된 값으로 만드는 간단한 조합입니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/tuples
module Tuples =

    /// 단순한 정수 튜플입니다.
    let tuple1 = (1, 2, 3)

    /// 튜플에 있는 두 값의 순서를 바꾸는 함수입니다.
    ///
    /// F# 형식 유추에서는 자동으로 함수를 제너릭 형식으로 일반화하므로,
    /// 모든 형식에 사용할 수 있습니다.
    let swapElems (a, b) = (b, a)

    printfn "The result of swapping (1, 2) is %A" (swapElems (1,2))

    /// 정수, 문자열 및 배정밀도 부동 소수점
    /// 숫자로 구성된 튜플입니다.
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A\ttuple2: %A" tuple1 tuple2

    /// 형식 주석이 포함된 단순한 정수 튜플입니다.
    /// 튜플에 대한 형식 주석은 * 기호를 사용하여 요소를 구분합니다.
    let tuple3: int * int = (5, 9)

    /// 튜플은 일반적으로 개체이지만 구조체로 나타낼 수도 있습니다.
    ///
    /// 이러한 구조체는 C# 및 Visual Basic.NET의 구조체와 완벽히 상호 운용되지만,
    /// 구조체 튜플은 개체 튜플(참조 튜플이라고도 함)로 암시적인 변환을 할 수 없습니다.
    ///
    /// 이로써 아래 두 번째 줄은 컴파일되지 않으며 결과를 확인하려면 이 줄의 주석 처리를 제거하세요.
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // 구조체 튜플과 참조 튜플 간을 암시적으로 변환할 수 없지만,
    // 아래 설명된 것처럼 패턴 일치를 통해 명시적으로 변환할 수 있습니다.
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)

    printfn "Struct Tuple: %A\nReference tuple made from the Struct Tuple: %A" sampleStructTuple (sampleStructTuple |> convertFromStructTuple)


/// F# 파이프 연산자('|>', '<|' 등) 및 F# 합성 연산자('>>', '<<')는
/// 데이터를 처리할 때 광범위하게 사용됩니다. 이러한 연산자는 자체가 함수이며
/// 부분 애플리케이션을 사용합니다.
///
/// 이러한 연산자에 대해 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/#function-composition-and-pipelining
/// 부분 애플리케이션에 대해 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/#partial-application-of-arguments
module PipelinesAndComposition =

    /// 값을 제곱합니다.
    let square x = x * x

    /// 값에 1을 더합니다.
    let addOne x = x + 1

    /// 모듈로를 통해 정수 값이 홀수인지 테스트합니다.
    let isOdd x = x % 2 <> 0

    /// 5개 숫자 목록입니다. 추가 숫자는 나중에 표시됩니다.
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// 정수 목록인 경우 짝수를 필터링하고,
    /// 결과 홀수를 제곱하고 제곱한 홀수에 1을 더합니다.
    let squareOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" numbers (squareOddValuesAndAddOne numbers)

    /// 'squareOddValuesAndAddOne'을 더 짧게 작성하려면
    /// 각 하위 결과를 함수 호출 자체에 중첩합니다.
    ///
    /// 그러면 함수가 더 짧아지지만 데이터가 처리되는 순서를
    /// 알아보기 어렵습니다.
    let squareOddValuesAndAddOneNested values =
        List.map addOne (List.map square (List.filter isOdd values))

    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers (squareOddValuesAndAddOneNested numbers)

    /// 'squareOddValuesAndAddOne'을 작성하려면 기본적으로 F# 파이프 연산자를 사용합니다.
    /// 그러면 중간 결과를 생성하지 않아도 되며
    /// 'squareOddValuesAndAddOneNested'와 같이 함수 호출을 중첩할 때보다 읽기도 쉽습니다.
    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    printfn "processing %A through 'squareOddValuesAndAddOnePipeline' produces: %A" numbers (squareOddValuesAndAddOnePipeline numbers)

    /// 'squareOddValuesAndAddOnePipeline'을 줄이려면 두 번째 `List.map` 호출을
    /// 람다 함수를 사용하여 첫 번째로 이동합니다.
    ///
    /// 파이프라인은 람다 함수 내에도 사용됩니다. F# 파이프 연산자는
    /// 단일 값에도 사용할 수 있습니다. 따라서 데이터 처리에 매우 유용합니다.
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" numbers (squareOddValuesAndAddOneShorterPipeline numbers)

    /// 마지막으로 명시적으로 'values'를 매개 변수로 사용할 필요가 없습니다. '>>'를 사용하여
    /// 짝수를 필터링한 다음 제곱하고 1을 더하는 두 가지 핵심 작업을 작성하면 됩니다.
    /// 마찬가지로 'fun x -> ...' 람다 식도 필요하지 않습니다. 'x'를 해당 범위에서 간단히
    /// 정의하여 함수 파이프라인에 전달할 수 있기 때문입니다. 따라서 여기에서도 '>>'를
    /// 사용할 수 있습니다.
    ///
    /// 'squareOddValuesAndAddOneComposition'의 결과 자체도 정수 목록을 입력으로 사용하는
    /// 다른 함수입니다. 'squareOddValuesAndAddOneComposition'을 정수 목록을 사용하여
    /// 실행하는 경우 이전 함수와 동일한 결과를 생성합니다.
    ///
    /// 여기서는 이른바 함수 컴퍼지션을 사용합니다. 이것이 가능한 이유는 F#의 함수가
    /// 부분 애플리케이션을 사용하고 각 데이터 처리 작업의 입력 및 출력 형식이 사용 중인 함수의
    /// 시그니처와 일치하기 때문입니다.
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneComposition' produces: %A" numbers (squareOddValuesAndAddOneComposition numbers)


/// 순서가 지정되고 변경 불가능한 단일 연결 목록으로 즉시 평가됩니다.
///
/// 이 모듈에서는 F# 주요 라이브러리의 'List' 모듈에 있는 일부 함수를 사용하여 목록을 생성하고
/// 목록을 처리하는 다양한 방법을 보여 줍니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/lists
module Lists =

    /// 목록은 [ ... ]을 사용하여 정의됩니다. 이것은 빈 목록입니다.
    let list1 = [ ]

    /// 3개 요소가 포함된 목록입니다. 동일한 줄에서 ';'을 사용하여 요소를 구분합니다.
    let list2 = [ 1; 2; 3 ]

    /// 요소를 다른 줄에 배치하여 요소를 구분할 수도 있습니다.
    let list3 = [
        1
        2
        3
    ]

    /// 이것은 1에서 1000까지의 정수 리스트입니다.
    let numberList = [ 1 .. 1000 ]

    /// 리스트는 계산에 의해서도 생성될 수 있습니다. 다음은
    /// 연중 모든 날짜를 포함하는 리스트입니다.
    let daysList =
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                  yield System.DateTime(2017, month, day) ]

    // 'daysList'의 처음 5개 요소를 'List.take'를 사용하여 인쇄합니다.
    printfn "The first 5 days of 2017 are: %A" (daysList |> List.take 5)

    /// 계산은 조건을 포함할 수 있습니다. 다음은
    /// 체스 보드에서 검은색 칸의 좌표를 가리키는 튜플이 포함된 리스트입니다.
    let blackSquares =
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do
                  if (i+j) % 2 = 1 then
                      yield (i, j) ]

    /// 리스트는 'List.map' 및 기타 함수 프로그래밍 조합기를 사용하여 변환될 수 있습니다.
    /// 이 정의는 인수를 List.map으로 전달하기 위해 파이프라인 연산자를 사용하여 numberList의 숫자를
    /// 제곱하여 새 리스트를 생성합니다.
    let squares =
        numberList
        |> List.map (fun x -> x*x)

    /// 다른 리스트 조합이 많이 있습니다. 다음은
    /// 3으로 나눠지는 수의 제곱의 합을 계산합니다.
    let sumOfSquares =
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)

    printfn "The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d" sumOfSquares


/// 배열은 고정 크기이며 같은 형식의 요소로 구성된 변경 가능한 컬렉션입니다.
///
/// 배열은 목록과 마찬가지로 열거형을 지원하고 데이터 처리를 위한 유사한 조합기를 사용하지만,
/// 배열은 일반적으로 더 빠르고 빠른 임의 액세스를 지원합니다. 변경이 가능하므로 덜 안전하다는 단점은 있습니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/arrays
module Arrays =

    /// 빈 배열입니다. 목록의 구문과 유사하지만 `[| ... |]`을 대신 사용합니다.
    let array1 = [| |]

    /// 배열은 리스트와 같은 범위의 구문을 사용하여 지정됩니다.
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// 1에서 1000까지의 숫자 배열입니다.
    let array3 = [| 1 .. 1000 |]

    /// "hello"와 "world"라는 단어만 포함된 배열입니다.
    let array4 =
        [| for word in array2 do
               if word.Contains("l") then
                   yield word |]

    /// 0에서 2000까지의 짝수가 포함되고 인덱스로 초기화된 배열입니다.
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// 하위 배열은 조각화 표기법을 사용하여 추출됩니다.
    let evenNumbersSlice = evenNumbers.[0..500]

    /// 'for' 루프를 사용하여 배열 및 목록을 반복할 수 있습니다.
    for word in array4 do
        printfn "word: %s" word

    // 왼쪽 화살표 대입 연산자를 사용하여 배열 요소의 내용을 수정할 수 있습니다.
    //
    // 이 연산자에 대해 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/values/index#mutable-variables
    array2.[1] <- "WORLD!"

    /// 'Array'map' 및 기타 함수 프로그래밍 연산을 사용하여 배열을 변환할 수 있습니다.
    /// 다음은 'h'로 시작하는 단어 길이의 합을 계산합니다.
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn "The sum of the lengths of the words in Array 2 is: %d" sumOfLengthsOfWords


/// 시퀀스는 모두 형식이 같은 요소가 논리적으로 연속되는 것입니다. 목록 및 배열보다 일반적인 형식입니다.
///
/// 시퀀스는 요청 시 계산되며 반복될 때마다 다시 계산됩니다.
/// F# 시퀀스는 .NET System.Collections.Generic.IEnumerable<'T>의 별칭입니다.
///
/// 시퀀스 처리 함수는 리스트와 배열 모두에 적용할 수 있습니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/sequences
module Sequences =

    /// 빈 시퀀스입니다.
    let seq1 = Seq.empty

    /// 시퀀스 값입니다.
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    /// 1에서 1000까지의 요청 시 시퀀스입니다.
    let numbersSeq = seq { 1 .. 1000 }

    /// "hello"와 "world"라는 단어를 생성하는 시퀀스입니다.
    let seq3 =
        seq { for word in seq2 do
                  if word.Contains("l") then
                      yield word }

    /// 2000까지의 짝수를 생성하는 시퀀스입니다.
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    /// 임의 행로인 무한 시퀀스입니다.
    /// 이 예에서는 yield!를 사용하여 하위 시퀀스의 각 요소를 반환합니다.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// 이 예에서는 임의 행로의 처음 100개 요소를 보여 줍니다.
    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList

    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk


/// 재귀 함수는 자신을 호출할 수 있습니다. F#에서 함수는
/// 'let rec'을 사용하여 선언할 때에만 반복됩니다.
///
/// 재귀는 F#에서 시퀀스 또는 컬렉션을 처리하는 기본 방법입니다.
///
/// 자세히 알아보려면 https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/index#recursive-functions를 참조하세요.
module RecursiveFunctions =

    /// 이 예에서는 정수의 계승을 계산하는 재귀 함수를 보여 줍니다.
    /// 'let rec'를 사용하여 재귀 함수를 정의합니다.
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n-1)

    printfn "Factorial of 6 is: %d" (factorial 6)

    /// 두 정수의 최대 공약수를 계산합니다.
    ///
    /// 모든 재귀 호출은 마무리 호출이므로,
    /// 컴파일러에서는 함수를 루프로 전환합니다.
    /// 루프는 성능을 향상시키고 메모리 소비량을 줄여 줍니다.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn "The Greatest Common Factor of 300 and 620 is %d" (greatestCommonFactor 300 620)

    /// 이 예제에서는 재귀를 사용하여 정수 목록의 합을 계산합니다.
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    /// 도우미 함수와 결과 누적기를 사용하여 'sumList'를 마무리 재귀 함수로 만듭니다.
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    /// '0'을 시드 누적기로 제공하여 마무리 재귀 도우미 함수를 호출합니다.
    /// F#에서 이와 같은 접근 방식이 일반적입니다.
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn "The sum 1-10 is %d" (sumListTailRecursive oneThroughTen)


/// 레코드는 명명된 값의 집계이며, 필요에 따라 메서드와 같은 선택적 멤버도 포함합니다.
/// 레코드는 변경 불가능하며 구조적으로 같음 의미 체계가 있습니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/records
module RecordTypes =

    /// 이 예에서는 새 레코드 형식을 정의하는 방법을 보여 줍니다.
    type ContactCard =
        { Name     : string
          Phone    : string
          Verified : bool }

    /// 이 예제에서는 레코드 형식을 인스턴스화하는 방법을 보여 줍니다.
    let contact1 =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false }

    /// 동일한 줄에서 ';' 구분 기호를 사용하여 이 작업을 수행할 수도 있습니다.
    let contactOnSameLine = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

    /// 이 예에서는 레코드 값에 "copy-and-update"를 사용하는 방법을 보여 줍니다.
    /// contact1의 복사본인 새 레코드 값을 만들지만
    /// 'Phone'과 'Verified' 필드의 값이 다릅니다.
    ///
    /// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/copy-and-update-record-expressions
    let contact2 =
        { contact1 with
            Phone = "(206) 555-0112"
            Verified = true }

    /// 이 예에서는 레코드 값을 처리하는 함수를 작성하는 방법을 보여 줍니다.
    /// 'ContactCard' 개체를 문자열로 변환합니다.
    let showContactCard (c: ContactCard) =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn "Alf's Contact Card: %s" (showContactCard contact1)

    /// 멤버가 하나인 레코드의 예제입니다.
    type ContactCardAlternate =
        { Name     : string
          Phone    : string
          Address  : string
          Verified : bool }

        /// 멤버는 개체 지향 멤버를 구현할 수 있습니다.
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified)" else "") + this.Address

    let contactAlternate =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false
          Address = "111 Alf Street" }

    // 인스턴스화된 형식에서 '.' 연산자를 통해 멤버에 액세스합니다.
    printfn "Alf's alternate contact card is %s" contactAlternate.PrintedContactCard

    /// 'Struct' 특성을 통해 레코드를 구조체로 나타낼 수도 있습니다.
    /// 구조체 성능이 참조 형식의 유연성보다 중요한 경우에
    /// 유용합니다.
    [<Struct>]
    type ContactCardStruct =
        { Name     : string
          Phone    : string
          Verified : bool }


/// 구분된 공용 구조체(줄여서 DU)는 여러 명명된 폼 또는 케이스일 수 있는 값입니다.
/// DU에 저장된 데이터는 여러 고유한 값 중 하나일 수 있습니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/discriminated-unions
module DiscriminatedUnions =

    /// 다음은 플레인 카드의 짝패를 나타냅니다.
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    /// 구분된 공용 구조체를 사용하여 플레잉 카드의 순위를 나타낼 수도 있습니다.
    type Rank =
        /// 카드 2부터 10까지의 순위를 나타냅니다.
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        /// 구분된 공용 구조체는 개체 지향 멤버도 구현할 수 있습니다.
        static member GetAllRanks() =
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]

    /// 짝패와 순위를 조합하는 레코드 형식입니다.
    /// 일반적으로 레코드와 구분된 공용 구조체를 모두 사용하여 데이터를 나타냅니다.
    type Card = { Suit: Suit; Rank: Rank }

    /// 데크에 있는 모든 카드를 나타내는 목록을 계산합니다.
    let fullDeck =
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do
                  yield { Suit=suit; Rank=rank } ]

    /// 이 예에서는 'Card' 개체를 문자열로 변환합니다.
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

    /// 이 예에서는 플레잉 데크의 모든 카드를 인쇄합니다.
    let printAllCards() =
        for card in fullDeck do
            printfn "%s" (showPlayingCard card)

    // 단일 케이스 DU를 도메인 모델링에 사용하는 경우가 많습니다. 그러면 문자열 및 정수와 같은
    // 기본 형식보다 형식 안전성을 추가로 얻을 수 있습니다.
    //
    // 단일 케이스 DU를 래핑하는 형식으로 암시적으로 변환하거나 반대로 변환할 수 없습니다.
    // 예를 들어 주소에서 사용하는 함수는 문자열을 입력으로 사용할 수 없으며,
    // 그 반대도 마찬가지입니다.
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    // 다음과 같이 단일 케이스 DU를 쉽게 인스턴스화할 수 있습니다.
    let address = Address "111 Alf Way"
    let name = Name "Alf"
    let ssn = SSN 1234567890

    /// 값이 필요하면 간단한 함수로 내부 값을 래핑 해제할 수 있습니다.
    let unwrapAddress (Address a) = a
    let unwrapName (Name n) = n
    let unwrapSSN (SSN s) = s

    // 래핑 해제 함수로 단일 케이스 DU를 간단히 인쇄할 수 있습니다.
    printfn "Address: %s, Name: %s, and SSN: %d" (address |> unwrapAddress) (name |> unwrapName) (ssn |> unwrapSSN)

    /// 구분된 공용 구조체는 재귀 정의도 지원합니다.
    ///
    /// 이진 검색 트리를 나타냅니다. 여기서 한 케이스는 빈 트리이고
    /// 다른 케이스는 값과 두 개의 하위 트리를 포함하는 노드입니다.
    type BST<'T> =
        | Empty
        | Node of value:'T * left: BST<'T> * right: BST<'T>

    /// 이진 검색 트리에 항목이 있는지 확인합니다.
    /// 패턴 일치를 사용하여 재귀적으로 검색합니다. 있으면 true를 반환하고 그렇지 않은 경우 false를 반환합니다.
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left) // 왼쪽 하위 트리를 확인합니다.
            else (exists item right) // 오른쪽 하위 트리를 확인합니다.

    /// 이진 검색 트리에 항목을 삽입합니다.
    /// 패턴 일치를 사용하여 재귀적으로 삽입할 위치를 찾은 다음 새 노드를 삽입합니다.
    /// 항목이 이미 있으면 아무 항목도 삽입하지 않습니다.
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node // 이미 항목이 있으므로 삽입할 필요가 없습니다. 노드를 반환합니다.
            elif item < x then Node(x, insert item left, right) // 왼쪽 하위 트리를 호출합니다.
            else Node(x, left, insert item right) // 오른쪽 하위 트리를 호출합니다.

    /// 'Struct' 특성을 통해 구분된 공용 구조체를 구조체로 나타낼 수도 있습니다.
    /// 구조체 성능이 참조 형식의 유연성보다 중요한 경우에
    /// 유용합니다.
    ///
    /// 하지만 이 작업을 수행할 때는 다음 두 가지 중요한 사항을 알고 있어야 합니다.
    ///     1. 구조체 DU는 재귀적으로 정의할 수 없습니다.
    ///     2. 각 케이스마다 구조체 DU의 이름이 고유해야 합니다.
    [<Struct>]
    type Shape =
        | Circle of radius: float
        | Square of side: float
        | Triangle of height: float * width: float


/// 패턴 일치는 패턴을 활용할 수 있는 F#의 기능이며,
/// 패턴을 사용하면 데이터를 논리 구조와 비교하거나,
/// 데이터를 구성 부분으로 분해하거나, 다양한 방법으로 데이터에서 정보를 추출할 수 있습니다.
/// 그런 다음 패턴 일치를 사용하여 패턴의 "모양"을 디스패치할 수 있습니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/pattern-matching
module PatternMatching =

    /// 사람의 성과 이름에 대한 레코드입니다.
    type Person = {
        First : string
        Last  : string
    }

    /// 세 가지 다른 직원 유형이 있는 구분된 공용 구조체
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// 관리 계층 구조에서 이 직원을 포함하여 이 아래에 있는 모든 직원의 수를
    /// 셉니다.
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(id) ->
                0
            | Manager(id, reports) ->
                reports |> List.sumBy countReports
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    /// 이름이 "Dave"이고 부하직원이 없는 모든 관리자/간부를 찾습니다.
    /// 여기서는 'function' 약어를 람다 식으로 사용합니다.
    let rec findDaveWithOpenPosition(emps : List<Employee>) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true // []는 빈 목록과 일치합니다.
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false) // '_'는 모든 항목과 일치하는 와일드카드 패턴입니다.
                                     // 이 와일드카드 패턴은 "or else" 케이스를 처리합니다.

    /// 패턴 일치에 약어 형식 함수 구문을 사용할 수도 있습니다.
    /// 이 구문은 부분 애플리케이션을 사용하는 함수를 작성할 때 유용합니다.
    let private parseHelper f = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDateTimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    // 도우미 함수를 사용하여 구문 분석하는 함수를 더 정의합니다.
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

    // 활성 패턴은 패턴 일치와 함께 사용하면 유용한 다른 구문입니다.
    // 활성 패턴을 사용하면 입력 데이터를 사용자 지정 폼으로 분할하고, 패턴 일치 호출 사이트에서 이 폼을 분해할 수 있습니다.
    //
    // 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/active-patterns
    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    /// 'function' 키워드 및 활성 패턴을 통한 패턴 일치는 이처럼 보이는 경우가 많습니다.
    let printParseResult = function
        | Int x -> printfn "%d" x
        | Double x -> printfn "%f" x
        | Date d -> printfn "%s" (d.ToString())
        | TimeSpan t -> printfn "%s" (t.ToString())
        | _ -> printfn "Nothing was parse-able!"

    // 구문 분석할 다른 값을 사용하여 프린터를 호출합니다.
    printParseResult "12"
    printParseResult "12.045"
    printParseResult "12/28/2016"
    printParseResult "9:01PM"
    printParseResult "banana!"


/// 옵션 값에는 'Some' 또는 'None'으로 태그 처리된 모든 종류의 값을 사용할 수 있습니다.
/// F# 코드에서 광범위하게 사용되어 다른 언어에서는 null 참조를 사용하는 케이스를
/// 나타냅니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/options
module OptionValues =

    /// 먼저 단일 케이스 구분된 공용 구조체를 통해 정의된 우편 번호를 정의합니다.
    type ZipCode = ZipCode of string

    /// 다음으로 ZipCode가 선택 사항인 형식을 정의합니다.
    type Customer = { ZipCode: ZipCode option }

    /// 그리고 고객의 우편 번호에 대한 배송 영역을 계산하기 위해 개체를 나타내는 인터페이스 형식을 정의합니다.
    /// 고객의 우편 번호에 대한 쇼핑 지역을 계산하는 추상 클래스입니다.
    type ShippingCalculator =
        abstract GetState : ZipCode -> string option
        abstract GetShippingZone : string -> int

    /// 다음으로 계산기 인스턴스를 사용하여 고객의 배송 영역을 계산합니다.
    /// 여기서는 Option 모듈 내의 조합기를 사용하여 함수 파이프라인에서
    /// Optionals를 통해 데이터를 변환할 수 있게 합니다.
    let CustomerShippingZone (calculator: ShippingCalculator, customer: Customer) =
        customer.ZipCode
        |> Option.bind calculator.GetState
        |> Option.map calculator.GetShippingZone


/// 측정 단위를 사용하면 형식이 안전한 방식으로 기본 숫자 형식에 주석을 달 수 있습니다.
/// 그런 다음 이러한 값에 대해 형식이 안전한 산술 연산을 수행할 수 있습니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/units-of-measure
module UnitsOfMeasure =

    /// 먼저 일반적인 단위 이름의 컬렉션을 엽니다.
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    /// 결합된 상수 정의
    let sampleValue1 = 1600.0<meter>

    /// 다음으로 새 단위 형식을 정의합니다.
    [<Measure>]
    type mile =
        /// 마일 대 미터 변환 비율입니다.
        static member asMeter = 1609.34<meter/mile>

    /// 결합된 상수 정의
    let sampleValue2  = 500.0<mile>

    /// 미터 단위 상수를 계산합니다.
    let sampleValue3 = sampleValue2 * mile.asMeter

    // 측정 단위를 사용하는 값은 인쇄와 같은 작업에 기본 숫자 형식처럼 사용할 수 있습니다.
    printfn "After a %f race I would walk %f miles which would be %f meters" sampleValue1 sampleValue2 sampleValue3


/// 클래스는 F#에서 새 개체 형식을 정의하는 방법이며 표준 개체 지향 구문을 지원합니다.
/// 클래스는 다양한 멤버(메서드, 속성, 이벤트 등)를 포함할 수 있습니다.
///
/// 클래스에 대해 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/classes
///
/// 멤버에 대해 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/members
module DefiningClasses =

    /// 단순한 2차원 벡터 클래스입니다.
    ///
    /// 클래스의 생성자는 첫 줄에 있고,
    /// 'double' 형식의 두 인수 dx 및 dy를 사용합니다.
    type Vector2D(dx : double, dy : double) =

        /// 이 내부 필드는 개체가 생성될 때 계산된 벡터 길이를
        /// 저장합니다.
        let length = sqrt (dx*dx + dy*dy)

        // 'this'는 개체 자체의 식별자에 대한 이름을 지정합니다.
        // 인스턴스 메서드에서는 멤버 이름 앞에 와야 합니다.
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        /// 이 멤버는 메서드입니다. 이전 멤버는 속성이었습니다.
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    /// Vector2D 클래스를 인스턴스화하는 방법은 다음과 같습니다.
    let vector1 = Vector2D(3.0, 4.0)

    /// 원래 개체를 수정하지 않고 비율이 조정된 새 벡터 개체를 가져옵니다.
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f\nLength of vector2: %f" vector1.Length vector2.Length


/// 제네릭 클래스를 통해 형식 매개변수 집합에 대해 형식을 정의할 수 있습니다.
/// 다음에서 'T는 클래스의 형식 매개 변수입니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/generics/
module DefiningGenericClasses =

    type StateTracker<'T>(initialElement: 'T) =

        /// 이 내부 필드는 목록에 상태를 저장합니다.
        let mutable states = [ initialElement ]

        /// 상태 리스트에 새 요소를 추가합니다.
        member this.UpdateState newState =
            states <- newState :: states  // '<-' 연산자를 사용하여 값을 변경합니다.

        /// 기록 상태의 전체 목록을 가져옵니다.
        member this.History = states

        /// 최신 상태를 가져옵니다.
        member this.Current = states.Head

    /// 상태 추적기 클래스의 'int' 인스턴스입니다. 형식 매개 변수는 유추됩니다.
    let tracker = StateTracker 10

    // 상태를 추가합니다.
    tracker.UpdateState 17


/// 인터페이스는 '추상' 멤버만 있는 개체 형식입니다.
/// 개체 형식 및 개체 식은 인터페이스를 구현할 수 있습니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/interfaces
module ImplementingInterfaces =

    /// IDisposable를 구현하는 형식입니다.
    type ReadFile() =

        let file = new System.IO.StreamReader("readme.txt")

        member this.ReadLine() = file.ReadLine()

        // IDisposable 멤버의 구현입니다.
        interface System.IDisposable with
            member this.Dispose() = file.Close()


    /// 개체 식을 통해 IDisposable을 구현하는 개체입니다.
    /// C# 또는 Java와 같은 다른 언어와 달리 인터페이스를 구현하기 위해 새 형식 정의가
    /// 필요하지 않습니다.
    let interfaceImplementation =
        { new System.IDisposable with
            member this.Dispose() = printfn "disposed" }


/// FSharp.Core 라이브러리는 병렬 처리 함수 범위를 정의합니다.
/// 여기에서 배열에 대해 병렬 처리 함수를 사용합니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/array.parallel-module-%5Bfsharp%5D
module ParallelArrayProgramming =

    /// 먼저 입력 배열입니다.
    let oneBigArray = [| 0 .. 100000 |]

    // 다음으로 CPU를 많이 사용하는 계산을 수행하는 함수를 정의합니다.
    let rec computeSomeFunction x =
        if x <= 2 then 1
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)

    // 다음으로 큰 입력 배열에 대해 병렬 맵을 수행합니다.
    let computeResults() =
        oneBigArray
        |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    // 다음으로 결과를 인쇄합니다.
    printfn "Parallel computation results: %A" (computeResults())



/// 이벤트는 특히 WinForms 또는 WPF 애플리케이션을 사용하는 .NET 프로그래밍에서 일반적으로 사용되는 말입니다.
///
/// 자세히 알아보려면 다음을 참조하세요. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/members/events
module Events =

    /// 먼저 구독 지점(event.Publish)과 이벤트 트리거(event.Trigger)로 구성된 Event 개체의 인스턴스를 만듭니다.
    let simpleEvent = new Event<int>()

    // 다음으로 이벤트에 처리기를 추가합니다.
    simpleEvent.Publish.Add(
        fun x -> printfn "this handler was added with Publish.Add: %d" x)

    // 다음으로 이벤트를 트리거합니다.
    simpleEvent.Trigger(5)

    // 다음으로 표준 .NET 규칙(sender, EventArgs)을 따르는 Event의 인스턴스를 만듭니다.
    let eventForDelegateType = new Event<EventHandler, EventArgs>()

    // 다음으로 이 새 이벤트에 대한 처리기를 추가합니다.
    eventForDelegateType.Publish.AddHandler(
        EventHandler(fun _ _ -> printfn "this handler was added with Publish.AddHandler"))

    // 다음으로 이 이벤트를 트리거합니다(sender 인수를 설정해야 함).
    eventForDelegateType.Trigger(null, EventArgs.Empty)



#if COMPILED
module BoilerPlateForForm =
    [<System.STAThread>]
    do ()
    do System.Windows.Forms.Application.Run()
#endif
