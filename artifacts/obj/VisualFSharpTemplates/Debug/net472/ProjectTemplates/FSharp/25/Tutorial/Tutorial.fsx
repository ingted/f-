// Этот пример поможет узнать о различных элементах языка F#.
//
// *******************************************************************************************************
//   Чтобы выполнить код в F# Interactive, выделите фрагмент кода и нажмите ALT+ВВОД или щелкните правой кнопкой мыши
//   и выберите команду "Выполнение в интерактивном режиме".  Интерактивное окно F# можно также открыть из меню "Вид".
// *******************************************************************************************************
//
// Дополнительные сведения о F# см. по адресу:
//     https://fsharp.org
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/
//
// Чтобы просмотреть это руководство в виде документа, см.:
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/tour
//
// Чтобы получить дополнительные сведения о прикладном программировании на языке F#, воспользуйтесь
//     https://fsharp.org/guides/enterprise/
//     https://fsharp.org/guides/cloud/
//     https://fsharp.org/guides/web/
//     https://fsharp.org/guides/data-science/
//
// Чтобы установить Visual F# Power Tools, используйте
//     "Сервис" --> "Расширения и обновления" --> "В сети" и выполните поиск
//
// Дополнительные шаблоны, которые можно использовать с F#, см. в разделе "Шаблоны в Интернете" в Visual Studio.
//     "Создать проект --> Шаблоны в Интернете"

// F# поддерживает три типа комментариев:

//  1. Комментарии с двойной косой чертой. Они используются в большинстве ситуаций.
(*  2. Комментарии блоков в стиле ML. Они используются довольно редко. *)
/// 3. Комментарии с тройной косой чертой. Они используются для документирования функций, типов и т. д.
///    При наведении указателя мыши на код, задекорированный этими комментариями, они отображаются в виде текста.
///
///    Кроме того, они поддерживают XML-комментарии в стиле .NET, делая возможным формирование справочной документации,
///    а также позволяют редакторам (таким как Visual Studio) извлекать из них информацию.
///    Подробности: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/xml-documentation


// Открывайте пространства имен с помощью ключевого слова "open".
//
// Подробности: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/import-declarations-the-open-keyword
open System


/// Модуль представляет собой группирование кода F#, например значений, типов и значений функций.
/// Группирование кода в модулях помогает держать связанный код в одном месте и предотвратить конфликты имен в программе.
///
/// Подробности: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/modules
module IntegersAndNumbers =

    /// Это пример целого числа.
    let sampleInteger = 176

    /// Это пример числа с плавающей запятой.
    let sampleDouble = 4.1

    /// Это новое число, вычисленное с помощью некоторых арифметических операций. Числовые типы преобразуются с помощью
    /// функций "int", "double" и т. п.
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    /// Это список чисел от 0 до 99.
    let sampleNumbers = [ 0 .. 99 ]

    /// Это список всех кортежей, содержащих все числа от 0 до 99 и их квадраты.
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // Следующая строка выводит список, включающий в себя кортежи, используя "%A" для универсальной печати.
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfSquares

    // Это пример целого числа с аннотацией типа
    let sampleInteger3: int = 1


/// В F# значения по умолчанию неизменяемы. Их невозможно изменить
/// во время выполнения программы, если только они явно не помечены как изменяемые.
///
/// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/values/index#why-immutable
module Immutability =

    /// Привязка значения к имени через let делает его неизменяемым.
    ///
    /// Сбой компиляции второй строки кода происходит, так как number неизменяем и привязан.
    /// Переопределение number в другое значение запрещено в F#.
    let number = 2
    // let number = 3

    /// Изменяемая привязка. Она необходима, чтобы иметь возможность изменять значение otherNumber.
    let mutable otherNumber = 2

    printfn "'otherNumber' is %d" otherNumber

    // При изменении значения используйте "<-", чтобы присвоить новое значение.
    //
    // Не удалось использовать "=" здесь и для этой цели, так как знак используется как оператор равенства.
    // или другие контексты, такие как "let" или "module"
    otherNumber <- otherNumber + 1

    printfn "'otherNumber' changed to be %d" otherNumber


/// Программирование на языке F# в основном заключается в определении функций, которые преобразуют входные данные и выдают
/// полезные результаты.
///
/// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/functions/
module BasicFunctions =

    /// let используется для определения функции. Эта функция принимает целочисленный аргумент и возвращает целое число.
    /// Круглые скобки необязательны для аргументов функции, если только не используется явная аннотация типа.
    let sampleFunction1 x = x*x + 3

    /// Применяйте функции, именуя возвращаемый функцией результат с помощью let.
    /// Тип переменной определяется типом возвращаемого значения функции.
    let result1 = sampleFunction1 4573

    // В этой строке используется "%d" для вывода результата как целого числа. Это типобезопасно.
    // Если бы result1 не принадлежал к типу int, при компиляции строки произошел бы сбой.
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    /// При необходимости аннотируйте тип имени параметра при помощи "(argument:type)". Скобки обязательны.
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn "The result of applying the 2nd sample function to (7 + 4) is %d" result2

    /// В условных выражениях используются операторы if, then, elid, elif и else.
    ///
    /// Обратите внимание, что в F# используется синтаксис с отступами в виде пробелов, аналогично таким языкам, как Python.
    let sampleFunction3 x =
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)

    // Эта строка использует "%f" для вывода результата в виде числа с плавающей запятой. Как и в случае с "%d" выше, это типобезопасно.
    printfn "The result of applying the 3rd sample function to (6.5 + 4.5) is %f" result3


/// Логические значения являются основными типами данных в F#. Ниже приведен ряд примеров логических типов данных и условной логики.
///
/// Подробности:
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/primitive-types
///     И
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/symbol-and-operator-reference/boolean-operators
module Booleans =

    /// Логические значения — это true и false.
    let boolean1 = true
    let boolean2 = false

    /// Операторы для логических значений — not, && и ||.
    let boolean3 = not boolean1 && (boolean2 || false)

    // В этой строке "%b" используется для вывода логического значения. Это типобезопасно.
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %b" boolean3


/// Строки являются основными типами данных в F#. Ниже приведено несколько примеров строк и основных действий с ними.
///
/// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/strings
module StringManipulation =

    /// В строках используются двойные кавычки.
    let string1 = "Hello"
    let string2  = "world"

    /// В строках также может использоваться @ для создания буквальных (verbatim) строковых литералов.
    /// Будут пропускаться escape-символы, такие как "\", "\n", "\t" и т. д.
    let string3 = @"C:\Program Files\"

    /// В строковых литералах также используются тройные кавычки.
    let string4 = """The computer said "hello world" when I told it to!"""

    /// Сцепление строк обычно выполняется при помощи оператора "+".
    let helloWorld = string1 + " " + string2

    // В этой строке "%s" используется для вывода строкового значения. Это типобезопасно.
    printfn "%s" helloWorld

    /// Подстроки используют нотацию индексатора. Эта строка кода извлекает первые семь символов в виде подстроки.
    /// Учтите, что, как и во многих других языках, в F# строки индексируются от нуля.
    let substring = helloWorld.[0..6]
    printfn "%s" substring


/// Кортеж — это простое сочетание значений данных в виде объединенного значения.
///
/// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/tuples
module Tuples =

    /// Простой кортеж целых чисел.
    let tuple1 = (1, 2, 3)

    /// Функция, меняющая местами два значения в кортеже.
    ///
    /// Определение типа F# будет автоматически назначать функции универсальный тип,
    /// что означает, что он будет работать с любым типом.
    let swapElems (a, b) = (b, a)

    printfn "The result of swapping (1, 2) is %A" (swapElems (1,2))

    /// Кортеж, состоящий из целого числа, строки
    /// и числа двойной точности с плавающей запятой.
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A\ttuple2: %A" tuple1 tuple2

    /// Простой кортеж целых чисел с аннотацией типа.
    /// Аннотации типов для кортежей используют символ * для разделения элементов.
    let tuple3: int * int = (5, 9)

    /// Кортежи обычно являются объектами, но они также могут быть представлены как структуры.
    ///
    /// Они полноценно взаимодействуют со структурами в C# и Visual Basic.NET; тем не менее
    /// кортежи структур нельзя явно преобразовать в кортежи объектов (часто называемые эталонными кортежами).
    ///
    /// Из-за этого произойдет сбой компиляции второй строки ниже. Раскомментируйте ее, чтобы увидеть, что произойдет.
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // Хотя кортежи-структуры и ссылочные кортежи невозможно преобразовывать неявно,
    // вы можете явно преобразовывать их с помощью сопоставления шаблонов, как показано ниже.
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)

    printfn "Struct Tuple: %A\nReference tuple made from the Struct Tuple: %A" sampleStructTuple (sampleStructTuple |> convertFromStructTuple)


/// Операторы конвейера F# ("|>", "<|" и т. д.) и операторы объединения F# (">>", "<<")
/// широко используются при обработке данных. Эти операторы сами по себе являются функциями,
/// использующими частичное применение.
///
/// Подробности об этих операторах: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/functions/#function-composition-and-pipelining.
/// Подробности о частичном применении: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/functions/#partial-application-of-arguments.
module PipelinesAndComposition =

    /// Возводит значение в квадрат.
    let square x = x * x

    /// Добавляет 1 к значению.
    let addOne x = x + 1

    /// Проверяет, является ли целое число нечетным по модулю.
    let isOdd x = x % 2 <> 0

    /// Список из 5 чисел. Дополнительно о списках позднее.
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// При наличии списка целых чисел выполняет фильтрацию по номерам событий,
    /// возводит полученные нечетные в квадрат, а затем добавляет 1 к нечетным, возведенным в квадрат.
    let squareOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" numbers (squareOddValuesAndAddOne numbers)

    /// Более короткий способ записи squareOddValuesAndAddOne — вложить каждый
    /// вложенный результат в сами вызовы функции.
    ///
    /// Это позволяет значительно сократить функцию, но будет сложно увидеть
    /// порядок, в котором обрабатываются данные.
    let squareOddValuesAndAddOneNested values =
        List.map addOne (List.map square (List.filter isOdd values))

    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers (squareOddValuesAndAddOneNested numbers)

    /// Предпочтительный способ записи squareOddValuesAndAddOne — использовать операторы конвейера F#.
    /// Это позволяет избежать создания промежуточных результатов, и при этом более удобно для чтения,
    /// чем вложение вызовов функций, таких как squareOddValuesAndAddOneNested.
    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    printfn "processing %A through 'squareOddValuesAndAddOnePipeline' produces: %A" numbers (squareOddValuesAndAddOnePipeline numbers)

    /// squareOddValuesAndAddOnePipeline можно сократить, переместив второй вызов List.map
    /// в первый, используя лямбда-функцию.
    ///
    /// Учтите, что конвейеры также используются внутри лямбда-функции. Операторы конвейера F#
    /// можно также использовать для отдельных значений. Это делает их очень эффективными при обработке данных.
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" numbers (squareOddValuesAndAddOneShorterPipeline numbers)

    /// И наконец, можно исключить необходимость явного принятия значений в качестве параметра при помощи ">>"
    /// для объединения двух основных операций: фильтрации четных чисел, а затем возведения в квадрат и добавления единицы.
    /// Аналогично, часть "fun x -> ..." лямбда-выражения также не требуется, так как x просто
    /// определяется в этой области действия, чтобы его можно было передать в функциональный конвейер. Таким образом, здесь также можно
    /// использовать ">>".
    ///
    /// Результат squareOddValuesAndAddOneComposition сам по себе является другой функцией, которая принимает
    /// список целых чисел в качестве входных данных. Если squareOddValuesAndAddOneComposition выполняется со списком
    /// целых чисел, вы заметите, что результаты соответствуют результатам предыдущих функций.
    ///
    /// Используется так называемая композиция функций. Это возможно, так как функции в F#
    /// используют частичное применение, а входные и выходные типы каждой операции обработки данных соответствуют
    /// сигнатурам функций, которые мы используем.
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneComposition' produces: %A" numbers (squareOddValuesAndAddOneComposition numbers)


/// Списки — это упорядоченные, неизменяемые однонаправленные списки. При вычислении они являются безотложными.
///
/// Этот модуль демонстрирует различные способы создания и обработки списков при помощи некоторых функций
/// в модуле List основной библиотеки F#.
///
/// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/lists.
module Lists =

    /// Списки определяются с помощью [ ... ]. Это пустой список.
    let list1 = [ ]

    /// Это — список с тремя элементами. Символ ";" используется для разделения элементов в одной строке.
    let list2 = [ 1; 2; 3 ]

    /// Элементы можно также разделить, поместив их в отдельные строки.
    let list3 = [
        1
        2
        3
    ]

    /// Это список целых чисел от 1 до 1000.
    let numberList = [ 1 .. 1000 ]

    /// Списки также могут создаваться в результате вычислений. Это список, содержащий
    /// все дни года.
    let daysList =
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                  yield System.DateTime(2017, month, day) ]

    // Вывод первых пяти элементов daysList при помощи List.take.
    printfn "The first 5 days of 2017 are: %A" (daysList |> List.take 5)

    /// Вычисления могут включать условные выражения. Это список, содержащий кортежи
    /// являющиеся координатами черных квадратов на шахматной доске.
    let blackSquares =
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do
                  if (i+j) % 2 = 1 then
                      yield (i, j) ]

    /// Списки можно преобразовывать с помощью List.map и других методов объединения, применяемых в функциональном программировании.
    /// Это определение создает новый список путем возведения в квадрат чисел из numberList с помощью конвейера.
    /// оператор для передачи аргумента в List.map.
    let squares =
        numberList
        |> List.map (fun x -> x*x)

    /// Существует множество других сочетаний списков. Приведенный ниже код вычисляет сумму квадратов.
    /// числа, кратные 3.
    let sumOfSquares =
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)

    printfn "The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d" sumOfSquares


/// Массивы — это изменяемые коллекции фиксированного размера, содержащие элементы одного типа.
///
/// Хотя они и похожи на списки (поддерживают перечисление и включают схожие методы объединения для обработки данных),
/// они, как правило, быстрее и поддерживают быстрый случайный доступ. С другой стороны, они менее безопасны, так как изменяемы.
///
/// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/arrays.
module Arrays =

    /// Это — пустой массив. Обратите внимание, что синтаксис похож на синтаксис списков, но используются квадратные скобки "[| ... |]".
    let array1 = [| |]

    /// Массивы задаются с помощью того же диапазона конструкций в виде списков.
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// Это массив чисел от 1 до 1000.
    let array3 = [| 1 .. 1000 |]

    /// Это — массив, содержащий только слова "hello" и "world".
    let array4 =
        [| for word in array2 do
               if word.Contains("l") then
                   yield word |]

    /// Это — массив, инициализируемый по индексу и содержащий четные числа от 0 до 2000.
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// Подмассивы извлекаются с помощью нотации выделения фрагмента.
    let evenNumbersSlice = evenNumbers.[0..500]

    /// Можно выполнять перебор массивов и списков при помощи циклов for.
    for word in array4 do
        printfn "word: %s" word

    // Изменить содержимое элемента массива можно с помощью оператора присваивания в виде стрелки влево.
    //
    // Подробности об этом операторе: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/values/index#mutable-variables.
    array2.[1] <- "WORLD!"

    /// Вы можете преобразовывать массивы при помощи Array.map и других операций функционального программирования.
    /// Следующий фрагмент вычисляет сумму длин слов, которые начинаются с буквы "h".
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn "The sum of the lengths of the words in Array 2 is: %d" sumOfLengthsOfWords


/// Последовательности — это логические серии элементов одного типа. Это — более общий тип, чем списки и массивы.
///
/// Последовательности вычисляются по требованию и заново вычисляются при каждом их переборе.
/// Последовательность F# является псевдонимом для .NET System.Collections.Generic.IEnumerable<'T>.
///
/// Функции обработки последовательностей можно также применять к спискам и массивам.
///
/// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/sequences
module Sequences =

    /// Это пустая последовательность.
    let seq1 = Seq.empty

    /// Это последовательность значений.
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    /// Это последовательность по требованию от 1 до 1000.
    let numbersSeq = seq { 1 .. 1000 }

    /// Это последовательность, создающая слова hello и world.
    let seq3 =
        seq { for word in seq2 do
                  if word.Contains("l") then
                      yield word }

    /// Эта последовательность выдает целые числа до 2000.
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    /// Это бесконечная последовательность, представляющая случайное блуждание.
    /// В этом примере используется оператор yield! для получения каждого элемента подпоследовательности.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// В этом примере показаны первые 100 элементов случайного блуждания.
    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList

    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk


/// Рекурсивные функции могут вызывать сами себя. В F# функции являются рекурсивными только
/// при объявлении с помощью let rec.
///
/// Рекурсия — это предпочтительный способ обработки последовательностей или коллекций в F#.
///
/// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/functions/index#recursive-functions.
module RecursiveFunctions =

    /// В этом примере показана рекурсивная функция, вычисляющая факториал
    /// целое число. В нем используется "let rec" для определения рекурсивной функции.
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n-1)

    printfn "Factorial of 6 is: %d" (factorial 6)

    /// Вычисляет наибольший общий делитель двух целых чисел.
    ///
    /// Так как все рекурсивные вызовы являются хвостовыми вызовами,
    /// компилятор сделает из функции цикл,
    /// что повысит производительность и снизит потребление памяти.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn "The Greatest Common Factor of 300 and 620 is %d" (greatestCommonFactor 300 620)

    /// Этот пример вычисляет сумму списка целых чисел при помощи рекурсии.
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    /// При этом sumList становится функцией с хвостовой рекурсией, использующей вспомогательную функцию с аккумулятором результатов.
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    /// Вызывается вспомогательная функция хвостовой рекурсии, предоставляющая "0" в качестве аккумулятора начальных значений.
    /// Подобный подход широко распространен в F#.
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn "The sum 1-10 is %d" (sumListTailRecursive oneThroughTen)


/// Записи являются агрегатами именованных значений с необязательными элементами (такими как методы).
/// Они являются неизменяемыми и обладают семантикой структурного равенства.
///
/// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/records.
module RecordTypes =

    /// В этом примере показано, как определить новый тип записи.
    type ContactCard =
        { Name     : string
          Phone    : string
          Verified : bool }

    /// В этом примере показано создание экземпляра типа записи.
    let contact1 =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false }

    /// Это также можно сделать в одной строке при помощи разделителя ";",
    let contactOnSameLine = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

    /// В этом примере показано, как использовать функцию "копировать и обновить" применительно к значениям записей. В нем создается
    /// новое значение записи, которое является копией contact1, но имеет другие значения для
    /// поля Phone и Verified.
    ///
    /// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/copy-and-update-record-expressions.
    let contact2 =
        { contact1 with
            Phone = "(206) 555-0112"
            Verified = true }

    /// В этом примере показано, как создать функцию, обрабатывающую значение записи.
    /// Он преобразует объект ContactCard в строку.
    let showContactCard (c: ContactCard) =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn "Alf's Contact Card: %s" (showContactCard contact1)

    /// Это — пример записи с элементом.
    type ContactCardAlternate =
        { Name     : string
          Phone    : string
          Address  : string
          Verified : bool }

        /// Элементы могут реализовать объектно-ориентированные элементы.
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified)" else "") + this.Address

    let contactAlternate =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false
          Address = "111 Alf Street" }

    // Доступ к элементам осуществляется через оператор "." для экземпляра типа.
    printfn "Alf's alternate contact card is %s" contactAlternate.PrintedContactCard

    /// Записи также могут быть представлены как структуры при помощи атрибута Struct.
    /// Это удобно в ситуациях, когда производительность структур важнее
    /// гибкости ссылочных типов.
    [<Struct>]
    type ContactCardStruct =
        { Name     : string
          Phone    : string
          Verified : bool }


/// Размеченные объединения (DU) — это значения, которые могут состоять из нескольких именованных форм или ветвей.
/// Данные, хранимые в размеченных объединениях, могут являться одними из нескольких различных значений.
///
/// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/discriminated-unions.
module DiscriminatedUnions =

    /// Следующий код представляет масть игральной карты.
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    /// Размеченное объединение также может использоваться для представления ранга игральной карты.
    type Rank =
        /// Представляет достоинство карт 2 .. 10
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        /// Кроме того, размеченные объединения могут реализовать объектно-ориентированные элементы.
        static member GetAllRanks() =
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]

    /// Это тип записи, объединяющий масть и достоинство.
    /// Как правило, при представлении данных используются как записи, так и размеченные объединения.
    type Card = { Suit: Suit; Rank: Rank }

    /// Вычисляется список, представляющий все карты в колоде.
    let fullDeck =
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do
                  yield { Suit=suit; Rank=rank } ]

    /// В этом примере объект Card преобразуется в строку.
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

    /// В этом примере печатаются все карты колоды.
    let printAllCards() =
        for card in fullDeck do
            printfn "%s" (showPlayingCard card)

    // Размеченные объединения с одной ветвью часто используются для моделирования доменов. Это более типобезопасно, чем использование
    // примитивных типов, таких как строки и целые числа.
    //
    // Размеченные объединения с одной ветвью нельзя неявно преобразовать в тип или из типа, оболочкой которого они служат.
    // Например, функция, которая принимает адрес, не может принять в качестве входных данных строку
    // или наоборот.
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    // Можно легко создать экземпляр размеченного объединения с одной ветвью следующим образом.
    let address = Address "111 Alf Way"
    let name = Name "Alf"
    let ssn = SSN 1234567890

    /// Если вам требуется значение, вы можете распаковать базовое значение при помощи простой функции.
    let unwrapAddress (Address a) = a
    let unwrapName (Name n) = n
    let unwrapSSN (SSN s) = s

    // Вывод размеченных объединений с одной ветвью не представляет сложности при использовании функций распаковки.
    printfn "Address: %s, Name: %s, and SSN: %d" (address |> unwrapAddress) (name |> unwrapName) (ssn |> unwrapSSN)

    /// Размеченные объединения также поддерживают рекурсивные определения.
    ///
    /// Это представляет двоичное дерево поиска, в котором одна ветвь является пустым деревом,
    /// а другая — узлом со значением и двумя поддеревьями.
    type BST<'T> =
        | Empty
        | Node of value:'T * left: BST<'T> * right: BST<'T>

    /// Проверка наличия элемента в двоичном дереве поиска.
    /// Рекурсивный поиск при помощи сопоставления шаблонов. Возвращает значение True, если существует; в противном случае — значение False.
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left) // Проверка левого поддерева.
            else (exists item right) // Проверка правого поддерева.

    /// Вставляет элемент в двоичное дерево поиска.
    /// Находит место для рекурсивной вставки при помощи сопоставления шаблонов, а затем вставляет новый узел.
    /// Если элемент уже существует, ничего не вставляется.
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node // Нет необходимости вставки, так как она уже существует; возврат узла.
            elif item < x then Node(x, insert item left, right) // Вызов левого поддерева.
            else Node(x, left, insert item right) // Вызов правого поддерева.

    /// Размеченные объединения также могут быть представлены как структуры при помощи атрибута Struct.
    /// Это удобно в ситуациях, когда производительность структур важнее
    /// гибкости ссылочных типов.
    ///
    /// Но при этом следует помнить о следующих двух важных вещах:
    ///     1. Размеченное объединение структуры не может определяться рекурсивно.
    ///     2. Каждой из ветвей размеченного объединения структуры должны быть присвоены уникальные названия.
    [<Struct>]
    type Shape =
        | Circle of radius: float
        | Square of side: float
        | Triangle of height: float * width: float


/// Сопоставление шаблонов — это возможность F#, которая позволяет использовать шаблоны,
/// что представляет способ сравнения данных с логической структурой или структурами,
/// разложение данных на составные части или извлечение информации из данных различными способами.
/// Затем можно передать "форму" шаблона при помощи сопоставления шаблонов.
///
/// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/pattern-matching.
module PatternMatching =

    /// Запись с именем и фамилией человека
    type Person = {
        First : string
        Last  : string
    }

    /// Размеченное соединение трех разных типов сотрудников
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// Подсчет всех сотрудников на уровнях иерархии управления, следующих за этим сотрудником,
    /// включая этого сотрудника.
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(id) ->
                0
            | Manager(id, reports) ->
                reports |> List.sumBy countReports
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    /// Поиск всех менеджеров и руководителей с именем Dave, не имеющих отчетов.
    /// При этом используется сокращение функции до лямбда-выражения.
    let rec findDaveWithOpenPosition(emps : List<Employee>) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true // [] соответствует пустому списку.
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false) // "_" — подстановочный знак, обозначающий любой набор символов.
                                     // Обрабатывается ветвь "or else".

    /// Для сопоставления шаблонов можно также использовать краткую форму конструкции функции,
    /// что удобно при написании функций, использующих частичное применение.
    let private parseHelper f = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDateTimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    // Определение некоторых других функций, которые выполняют анализ при помощи вспомогательной функции.
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

    // Активные шаблоны — это еще одна эффективная конструкция, используемая при сопоставлении шаблонов.
    // Они позволяют сегментировать входные данные в настраиваемые формы с декомпозицией в месте вызова сопоставления шаблонов.
    //
    // Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/active-patterns.
    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    /// Сопоставление шаблонов по ключевому слову function и активным шаблонам часто выглядит следующим образом.
    let printParseResult = function
        | Int x -> printfn "%d" x
        | Double x -> printfn "%f" x
        | Date d -> printfn "%s" (d.ToString())
        | TimeSpan t -> printfn "%s" (t.ToString())
        | _ -> printfn "Nothing was parse-able!"

    // Вызов принтера с несколькими разными значениями для анализа.
    printParseResult "12"
    printParseResult "12.045"
    printParseResult "12/28/2016"
    printParseResult "9:01PM"
    printParseResult "banana!"


/// Опциональные значения - это любой тип значений, отмеченных ключевым словом Some или None.
/// Они широко используются в коде F# для представления случаев, когда во многих
/// других языках используются пустые ссылки.
///
/// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/options.
module OptionValues =

    /// Во-первых, определите индекс при помощи размеченного объединения с одной ветвью.
    type ZipCode = ZipCode of string

    /// Далее определите тип, в котором ZipCode является необязательным.
    type Customer = { ZipCode: ZipCode option }

    /// Далее определите тип интерфейса, представляющий объект для вычисления зоны доставки по почтовому индексу заказчика,
    /// при заданных реализациях абстрактных методов getState и getShippingZone.
    type ShippingCalculator =
        abstract GetState : ZipCode -> string option
        abstract GetShippingZone : string -> int

    /// Затем определите зону доставки для заказчика при помощи экземпляра калькулятора.
    /// При этом используются методы объединения в модуле Option, чтобы обеспечить работу функционального конвейера для
    /// преобразования данных с помощью Optionals.
    let CustomerShippingZone (calculator: ShippingCalculator, customer: Customer) =
        customer.ZipCode
        |> Option.bind calculator.GetState
        |> Option.map calculator.GetShippingZone


/// Единицы измерения — это способ аннотации примитивных числовых типов типобезопасным способом.
/// Затем с этими значениями можно выполнять типобезопасные арифметические действия.
///
/// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/units-of-measure.
module UnitsOfMeasure =

    /// Сначала откройте коллекцию стандартных названий единиц измерения.
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    /// Определите константу с единицей измерения.
    let sampleValue1 = 1600.0<meter>

    /// Далее определите новый тип единицы.
    [<Measure>]
    type mile =
        /// Коэффициент пересчета миль в метры.
        static member asMeter = 1609.34<meter/mile>

    /// Определите константу с единицей измерения.
    let sampleValue2  = 500.0<mile>

    /// Вычислите константу в метрической системе.
    let sampleValue3 = sampleValue2 * mile.asMeter

    // Значения, использующие единицы измерения, можно применять как примитивные числовые типы для таких действий, как печать.
    printfn "After a %f race I would walk %f miles which would be %f meters" sampleValue1 sampleValue2 sampleValue3


/// Классы — это способ определения новых типов объектов в F#. Они поддерживают стандартные объектно-ориентированные конструкции.
/// Они могут содержать различные элементы (методы, свойства, события и т. д.)
///
/// Подробности о классах: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/classes.
///
/// Подробности об элементах: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/members.
module DefiningClasses =

    /// Простой двухмерный класс Vector.
    ///
    /// Конструктор класса находится в первой строке
    /// и принимает два аргумента: dx и dy, оба имеют тип double.
    type Vector2D(dx : double, dy : double) =

        /// В этом внутреннем поле хранится длина вектора, вычисляемая, когда
        /// объект создается
        let length = sqrt (dx*dx + dy*dy)

        // Ключевое слово this задает имя идентификатора самого объекта.
        // В методах экземпляров оно должно находиться перед именем элемента.
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        /// Этот элемент является методом. Предыдущие элементы были свойствами.
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    /// Вот как выполняется создание экземпляра класса Vector2D.
    let vector1 = Vector2D(3.0, 4.0)

    /// Получение нового объекта масштабируемого вектора без изменения исходного объекта.
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f\nLength of vector2: %f" vector1.Length vector2.Length


/// Универсальные классы позволяют определять типы с набором параметров типа.
/// В следующем примере 'T — это параметр типа для класса.
///
/// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/generics/.
module DefiningGenericClasses =

    type StateTracker<'T>(initialElement: 'T) =

        /// В этом внутреннем поле хранятся состояния в списке.
        let mutable states = [ initialElement ]

        /// Добавление нового элемента в список состояний.
        member this.UpdateState newState =
            states <- newState :: states  // Оператор "<-" служит для изменения значения.

        /// Получение полного списка исторических состояний.
        member this.History = states

        /// Получение последнего состояния.
        member this.Current = states.Head

    /// Экземпляр int класса отслеживания состояний. Обратите внимание, что параметр типа подразумевается.
    let tracker = StateTracker 10

    // Добавление состояния
    tracker.UpdateState 17


/// Интерфейсы — это типы объектов, которые имеют только абстрактные члены.
/// Типы объектов и выражения объектов могут реализовывать интерфейсы.
///
/// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/interfaces.
module ImplementingInterfaces =

    /// Это — тип, который реализует интерфейс IDisposable.
    type ReadFile() =

        let file = new System.IO.StreamReader("readme.txt")

        member this.ReadLine() = file.ReadLine()

        // Это — реализация элементов интерфейса IDisposable.
        interface System.IDisposable with
            member this.Dispose() = file.Close()


    /// Это — объект, реализующий интерфейс IDisposable через выражение объекта.
    /// В отличие от других языков, таких как C# или Java, новое определение типа не требуется
    /// для реализации интерфейса.
    let interfaceImplementation =
        { new System.IDisposable with
            member this.Dispose() = printfn "disposed" }


/// В библиотеке FSharp.Core определен ряд функций параллельной обработки. Здесь
/// вы используете определенные функции для параллельной обработки массивов.
///
/// Подробности: https://msdn.microsoft.com/ru-ru/visualfsharpdocs/conceptual/array.parallel-module-%5Bfsharp%5D.
module ParallelArrayProgramming =

    /// Сначала — массив входных данных.
    let oneBigArray = [| 0 .. 100000 |]

    // Далее определите функции, выполняющие ряд вычислений с интенсивным использованием ЦП.
    let rec computeSomeFunction x =
        if x <= 2 then 1
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)

    // Затем выполните параллельное сопоставление по большому входному массиву.
    let computeResults() =
        oneBigArray
        |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    // Далее напечатайте результаты.
    printfn "Parallel computation results: %A" (computeResults())



/// События представляют собой стандартные идиомы программирования .NET, особенно для приложений WinForms или WPF.
///
/// Подробности: https://docs.microsoft.com/ru-ru/dotnet/articles/fsharp/language-reference/members/events.
module Events =

    /// Сначала создайте экземпляр объекта Event, состоящий из точки подписки (event.Publish) и триггера события (event.Trigger).
    let simpleEvent = new Event<int>()

    // Затем добавьте обработчик для события.
    simpleEvent.Publish.Add(
        fun x -> printfn "this handler was added with Publish.Add: %d" x)

    // Затем активируйте событие.
    simpleEvent.Trigger(5)

    // Затем создайте экземпляр события в соответствии со стандартным соглашением .NET: (sender, EventArgs).
    let eventForDelegateType = new Event<EventHandler, EventArgs>()

    // Затем добавьте обработчик для этого нового события.
    eventForDelegateType.Publish.AddHandler(
        EventHandler(fun _ _ -> printfn "this handler was added with Publish.AddHandler"))

    // Затем вызовите событие (обратите внимание на то, что аргумент sender должен быть задан).
    eventForDelegateType.Trigger(null, EventArgs.Empty)



#if COMPILED
module BoilerPlateForForm =
    [<System.STAThread>]
    do ()
    do System.Windows.Forms.Application.Run()
#endif
