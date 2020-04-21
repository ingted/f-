// Tato ukázka vás provede elementy jazyka F#.
//
// *******************************************************************************************************
//   Pokud chcete kód provést v nástroji F# Interactive, zvýrazněte oddíl kódu a stiskněte Alt-Enter nebo klikněte pravým tlačítkem myši
//   a vyberte Provést v Interactive. Okno F# Interactive můžete otevřít z nabídky Zobrazit.
// *******************************************************************************************************
//
// Další informace o F# najdete na:
//     https://fsharp.org
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/
//
// Na tomto webu najdete tento kurz v podobě dokumentace:
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/tour
//
// K získání dalších informací o použitém programovém kódu F# použijte
//     https://fsharp.org/guides/enterprise/
//     https://fsharp.org/guides/cloud/
//     https://fsharp.org/guides/web/
//     https://fsharp.org/guides/data-science/
//
// K instalaci Visual F# Power Tools použijte
//     Nástroje --> Rozšíření a aktualizace --> Online a potom hledejte
//
// Další šablony, které můžete používat s F#, najdete tak, že v sadě Visual Studio vyberete Online šablony,
//     Nový projekt --> Online šablony.

// F# podporuje tři typy komentářů:

//  1. Komentáře se dvěma lomítky. Ty se používají ve většině situací.
(*  2. Blokové komentáře ve stylu ML. Ty se moc často nepoužívají. *)
/// 3. Komentáře se třemi lomítky. Ty se používají k dokumentaci funkcí, typů a podobně.
///    Když na elementy s těmito komentáři nastavíte ukazatel myši, zobrazí se komentáře jako text.
///
///    Podporují se také komentáře XML ve stylu .NET, které umožňují generovat referenční dokumentaci.
///    Umožňují také, aby z nich editory (jako například Visual Studio) extrahovaly informace.
///    Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/xml-documentation


// Otevírejte obory názvů pomocí klíčového slova open.
//
// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/import-declarations-the-open-keyword
open System


/// Modul je seskupení kódu F#, například hodnot, typů a hodnot funkcí.
/// Seskupování kódu do modulů pomáhá zachovat související kód pohromadě a vyhnout se v programu konfliktům názvů.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/modules
module IntegersAndNumbers =

    /// Toto je ukázkové celé číslo.
    let sampleInteger = 176

    /// Toto je ukázkové číslo s plovoucí desetinnou čárkou.
    let sampleDouble = 4.1

    /// Tady se pomocí aritmetiky vypočítalo nové číslo. Číselné typy se převádějí pomocí
    /// funkcí int, double atd.
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    /// Toto je seznam čísel od 0 do 99.
    let sampleNumbers = [ 0 .. 99 ]

    /// Toto je seznam všech řazených kolekcí členů obsahujících všechna čísla od 0 do 99 a jejich druhé mocniny.
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // Další řádek vytiskne seznam, který zahrnuje řazené kolekce členů, s použitím %A pro obecný tisk.
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfSquares

    // Toto je ukázkové celé číslo s anotací typu.
    let sampleInteger3: int = 1


/// Hodnoty v F# jsou ve výchozím nastavení neměnné. Nedají se změnit
/// během provádění programu, pokud nejsou explicitně označené jako měnitelné.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/values/index#why-immutable
module Immutability =

    /// Po navázání hodnoty na název pomocí klíčového slova „let“ se hodnota stane neměnnou.
    ///
    /// Druhý řádek kódu nejde zkompilovat, protože proměnná number je neměnná a vázaná.
    /// Předefinování položky number na jinou hodnotu se v jazyce F# nepovoluje.
    let number = 2
    // let number = 3

    /// Změnitelná vazba. Je to nutné, aby bylo možné měnit hodnotu otherNumber.
    let mutable otherNumber = 2

    printfn "'otherNumber' is %d" otherNumber

    // Při změnách hodnoty použijte <- pro přiřazení nové hodnoty.
    //
    // Znak = tady pro tento účel nemůžete použít, protože se používá pro rovnost
    // nebo jiné kontexty jako let nebo module
    otherNumber <- otherNumber + 1

    printfn "'otherNumber' changed to be %d" otherNumber


/// Velká část programování v F# spočívá v definování funkcí, které transformují vstupní data na
/// užitečné výsledky.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/functions/
module BasicFunctions =

    /// Pomocí klíčového slova „let“ můžete definovat funkci. Tato přebírá celočíselný argument a vrací celé číslo.
    /// Závorky jsou pro argumenty funkce nepovinné – s výjimkou použití anotace explicitního typu.
    let sampleFunction1 x = x*x + 3

    /// Použití funkce a pojmenování výsledku vrácení funkce pomocí klíčového slova let
    /// Typ proměnné je odvozený z návratového typu funkce.
    let result1 = sampleFunction1 4573

    // Tento řádek používá %d k vytištění výsledku jako celého čísla. Je to typově bezpečné.
    // Pokud by result1 nebyl typu int, pak by se kompilace řádku nezdařila.
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    /// V případě potřeby anotujte typ názvu parametru pomocí (argument:typ). Závorky jsou povinné.
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn "The result of applying the 2nd sample function to (7 + 4) is %d" result2

    /// Podmíněné výrazy používají příkazy if, then, elid, elif, else.
    ///
    /// Všimněte si, že F# používá syntaxi rozpoznávající odsazení pomocí mezer – je to podobné jako u jazyků, jako je Python.
    let sampleFunction3 x =
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)

    // Tento řádek používá %f k vytištění výsledku jako hodnoty s plovoucí desetinnou čárkou. Stejně jako u výše uvedeného parametru %d je to typově bezpečné.
    printfn "The result of applying the 3rd sample function to (6.5 + 4.5) is %f" result3


/// Logické hodnoty představují základní datové typy v jazyce F#. Tady je několik příkladů logických hodnot a podmíněné logiky.
///
/// Další informace:
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/primitive-types
///     a
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/symbol-and-operator-reference/boolean-operators
module Booleans =

    /// Logické hodnoty jsou true a false.
    let boolean1 = true
    let boolean2 = false

    /// Operátory u logických hodnot jsou not, && a ||.
    let boolean3 = not boolean1 && (boolean2 || false)

    // Tento řádek používá %b k vytištění logické hodnoty. Je to typově bezpečné.
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %b" boolean3


/// Řetězce představují základní datové typy v jazyce F#. Tady je několik příkladů řetězců a základní manipulace s nimi.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/strings
module StringManipulation =

    /// Pro řetězce se používají dvojité uvozovky.
    let string1 = "Hello"
    let string2  = "world"

    /// V řetězcích je také možné použít @ k vytvoření řetězcového literálu verbatim.
    /// Tím se budou ignorovat řídicí znaky jako \, \n, \t apod.
    let string3 = @"C:\Program Files\"

    /// Řetězcové literály můžou používat také trojité uvozovky.
    let string4 = """The computer said "hello world" when I told it to!"""

    /// Zřetězení se obvykle provádí operátorem +.
    let helloWorld = string1 + " " + string2

    // Tento řádek používá %s k vytištění řetězcové hodnoty. Je to typově bezpečné.
    printfn "%s" helloWorld

    /// Podřetězce používají notaci indexeru. Tento řádek extrahuje prvních 7 znaků jako podřetězec.
    /// Všimněte si, že jako v mnoha jiných jazycích mají řetězce v jazyce F# nulový index.
    let substring = helloWorld.[0..6]
    printfn "%s" substring


/// Řazená kolekce členů představuje jedinou hodnotu vytvořenou jednoduchým zkombinováním hodnot dat.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/tuples
module Tuples =

    /// Jednoduchá řazená kolekce členů v podobě celých čísel.
    let tuple1 = (1, 2, 3)

    /// Funkce, která zamění pořadí dvou hodnot v řazené kolekci členů
    ///
    /// Odvození typu proměnné v jazyce F# automaticky generalizuje funkci tak, aby byla obecného typu,
    /// což znamená, že bude fungovat s jakýmkoli typem.
    let swapElems (a, b) = (b, a)

    printfn "The result of swapping (1, 2) is %A" (swapElems (1,2))

    /// Řazená kolekce členů skládající se z celého čísla, řetězce
    /// a čísla s plovoucí desetinnou čárkou a dvojitou přesností
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A\ttuple2: %A" tuple1 tuple2

    /// Jednoduchá řazená kolekce členů celých čísel s anotací typu
    /// Anotace typů pro řazené kolekce členů používají k oddělování elementů symbol *.
    let tuple3: int * int = (5, 9)

    /// Řazené kolekce členů jsou obvykle objekty, ale můžou být vyjádřeny i jako struktury.
    ///
    /// Ty zcela spolupracují se strukturami v jazycích C# a Visual Basic .NET. Platí ale, že
    /// řazené kolekce členů představující struktury nejsou implicitně převeditelné na řazené kolekce členů představující objekty (často označované jako řazené kolekce členů odkazů).
    ///
    /// Kompilace druhého řádku uvedeného níže se z tohoto důvodu nezdaří. Odkomentujte ho a podívejte se, co se stane.
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // Mezi řazenými kolekcemi členů představujícími struktury a řazenými kolekcemi členů odkazů nemůžete provést implicitní převod,
    // ale můžete převod provést explicitně přes porovnávání vzorů, jak je znázorněno níže.
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)

    printfn "Struct Tuple: %A\nReference tuple made from the Struct Tuple: %A" sampleStructTuple (sampleStructTuple |> convertFromStructTuple)


/// Operátory kanálu (|>, <| atd.) a operátory složení (>>, <<) v jazyce F#
/// se při zpracovávání dat používají ve velkém měřítku. Tyto operátory představují samy o sobě funkce,
/// které využívají částečné použití argumentů.
///
/// Další informace o těchto operátorech: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/functions/#function-composition-and-pipelining
/// Další informace o částečném použití argumentů: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/functions/#partial-application-of-arguments
module PipelinesAndComposition =

    /// Umocní hodnotu na druhou.
    let square x = x * x

    /// Přičte 1 k hodnotě.
    let addOne x = x + 1

    /// Otestuje, jestli je celočíselná hodnota lichá na základě zbytku po dělení.
    let isOdd x = x % 2 <> 0

    /// Seznam 5 čísel. Více o seznamech později.
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// V daném seznamu celých čísel odfiltruje sudá čísla,
    /// umocní výsledná lichá čísla na druhou a přičte 1 k lichým číslům umocněným na druhou.
    let squareOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" numbers (squareOddValuesAndAddOne numbers)

    /// Kratší způsob, jak napsat squareOddValuesAndAddOne, je vnořit jednotlivé
    /// dílčí výsledky přímo do volání funkcí.
    ///
    /// Díky tomu může být funkce mnohem kratší, ale je obtížné sledovat
    /// pořadí, v jakém se data zpracovávají.
    let squareOddValuesAndAddOneNested values =
        List.map addOne (List.map square (List.filter isOdd values))

    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers (squareOddValuesAndAddOneNested numbers)

    /// Preferovaným způsobem, jak napsat squareOddValuesAndAddOne, je použití operátorů kanálu v jazyce F#.
    /// To vám umožní vyhnout se vytváření mezivýsledků, ale je to mnohem čitelnější
    /// než vnoření volání funkcí, jak je vidět v squareOddValuesAndAddOneNested.
    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    printfn "processing %A through 'squareOddValuesAndAddOnePipeline' produces: %A" numbers (squareOddValuesAndAddOnePipeline numbers)

    /// Můžete zkrátit squareOddValuesAndAddOnePipeline přesunutím druhého volání List.map
    /// do prvního, pomocí funkce lambda.
    ///
    /// Všimněte si, že kanály se používají i ve funkci lambda. Operátory kanálu v jazyce F#
    /// se dají použít i pro jednotlivé hodnoty. Díky tomu jsou velmi efektivní při zpracovávání dat.
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" numbers (squareOddValuesAndAddOneShorterPipeline numbers)

    /// A konečně, můžete eliminovat nutnost explicitně převzít values jako parametr pomocí >>
    /// s cílem sestavit dvě základní operace: odfiltrování sudých čísel a následné umocnění na druhou a přičtení jedné.
    /// Obdobně není nutná část výrazu lambda „fun x -> ...“, protože x se jednoduše
    /// v tomto oboru definuje tak, aby ho bylo možné předat jako funkční kanál. Proto je tam >> možné použít
    /// také.
    ///
    /// Výsledek squareOddValuesAndAddOneComposition je sám o sobě další funkcí, která přebírá
    /// jako vstup seznam celých čísel. Pokud provedete squareOddValuesAndAddOneComposition se seznamem
    /// celých čísel, všimnete si, že dává stejné výsledky jako předchozí funkce.
    ///
    /// Označuje se to jako složení funkcí. Je to možné, protože funkce v jazyce F#
    /// používají částečné použití argumentů a vstupní a výstupní typy každé operace zpracování dat odpovídají
    /// signaturám funkcí, které používáme.
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneComposition' produces: %A" numbers (squareOddValuesAndAddOneComposition numbers)


/// Seznamy jsou uspořádané, neměnné a jednorázově propojené. Velmi dynamicky se vyhodnocují.
///
/// Tento modul zobrazuje různé způsoby, jak generovat seznamy a jak je zpracovat pomocí některých funkcí
/// v modulu List v knihovně F# Core.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/lists
module Lists =

    /// Seznamy se definují pomocí syntaxe [ ... ]. Toto je prázdný seznam.
    let list1 = [ ]

    /// Toto je seznam se 3 elementy. K oddělení prvků na stejném řádku se používá středník (;).
    let list2 = [ 1; 2; 3 ]

    /// Elementy můžete oddělit i jejich umístěním na samostatné řádky.
    let list3 = [
        1
        2
        3
    ]

    /// Toto je seznam celých čísel od 1 do 1000
    let numberList = [ 1 .. 1000 ]

    /// Seznamy je možné generovat pomocí výpočtů. Toto je seznam obsahující
    /// všechny dny v roce.
    let daysList =
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                  yield System.DateTime(2017, month, day) ]

    // Vytiskněte prvních 5 elementů daysList pomocí List.take.
    printfn "The first 5 days of 2017 are: %A" (daysList |> List.take 5)

    /// Výpočty můžou obsahovat podmíněné výrazy. Toto je seznam obsahující řazené kolekce členů
    /// což jsou souřadnice černých polí na šachovnici.
    let blackSquares =
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do
                  if (i+j) % 2 = 1 then
                      yield (i, j) ]

    /// Seznamy se dají transformovat pomocí souboru List.map a dalších funkčních programových kombinátorů.
    /// Tato definice vytvoří nový seznam vypočítáním druhých mocnin hodnot v seznamu numberList pomocí kanálu
    /// operátor pro předání argumentu do souboru List.map.
    let squares =
        numberList
        |> List.map (fun x -> x*x)

    /// Existuje mnoho dalších kombinací seznamů. Následující kód vypočítá součet druhých mocnin
    /// čísel dělitelných 3.
    let sumOfSquares =
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)

    printfn "The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d" sumOfSquares


/// Pole jsou měnitelné kolekce s pevně stanovenou velikostí, které obsahují elementy stejného typu.
///
/// I když se podobají seznamům (podporují výčet a mají podobné kombinátory pro zpracování dat),
/// jsou obecně rychlejší a podporují rychlý náhodný přístup. Nevýhodou je nižší zabezpečení, protože je možné je měnit.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/arrays
module Arrays =

    /// Toto je prázdné pole. Všimněte si, že syntaxe je podobná seznamům, ale používá se [| ... |].
    let array1 = [| |]

    /// Pole jsou definovaná pomocí stejného rozsahu konstruktorů jako seznamy.
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// Toto je pole čísel od 1 do 1000.
    let array3 = [| 1 .. 1000 |]

    /// Toto je pole obsahující pouze slova hello a world.
    let array4 =
        [| for word in array2 do
               if word.Contains("l") then
                   yield word |]

    /// Toto je pole inicializované indexem, které obsahuje sudá čísla od 0 do 2000.
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// Dílčí pole se extrahují pomocí slicingové notace.
    let evenNumbersSlice = evenNumbers.[0..500]

    /// Přes pole a seznamy se můžete přesunovat pomocí smyček for.
    for word in array4 do
        printfn "word: %s" word

    // Můžete upravit obsah elementu pole pomocí operátoru přiřazení s šipkou doleva.
    //
    // Další informace o tomto operátoru: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/values/index#mutable-variables
    array2.[1] <- "WORLD!"

    /// Pole můžete transformovat pomocí Array.map a dalších funkčních programových operací.
    /// Následující kód vypočítá součet délek slov, která začínají na „h“.
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn "The sum of the lengths of the words in Array 2 is: %d" sumOfLengthsOfWords


/// Sekvence jsou logické řady elementů, které jsou všechny stejného typu. Jedná se o obecnější typ než seznamy a pole.
///
/// Sekvence se vyhodnocují na vyžádání a při každé iteraci se vyhodnocují znovu.
/// Sekvence F# je alias pro .NET System.Collections.Generic.IEnumerable<'T>.
///
/// Funkce na zpracování sekvencí je možné použít také na seznamy a pole.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/sequences
module Sequences =

    /// Toto je prázdná sekvence.
    let seq1 = Seq.empty

    /// Toto je sekvence hodnot.
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    /// Toto je sekvence na vyžádání od 1 do 1000.
    let numbersSeq = seq { 1 .. 1000 }

    /// Toto je sekvence, která vrátí slova hello a world
    let seq3 =
        seq { for word in seq2 do
                  if word.Contains("l") then
                      yield word }

    /// Tato sekvence vrátí sudá čísla až do 2000.
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    /// Toto je nekonečná sekvence, která je náhodnou funkcí walk.
    /// Tento příklad vrací pomocí příkazu yield! jednotlivé elementy dílčí sekvence.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// Tento příklad ukazuje prvních 100 elementů náhodné funkce walk.
    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList

    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk


/// Rekurzivní funkce můžou volat samy sebe. V F# jsou všechny funkce rekurzivní
/// při deklarování pomocí let rec.
///
/// Rekurze je preferovaný způsob zpracování sekvencí nebo kolekcí v jazyce F#.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/functions/index#recursive-functions
module RecursiveFunctions =

    /// Tento příklad ukazuje rekurzivní funkci, která vypočítá faktoriál
    /// integer. Pomocí let rec se definuje rekurzivní funkce.
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n-1)

    printfn "Factorial of 6 is: %d" (factorial 6)

    /// Vypočítá největšího společného dělitele dvou celých čísel.
    ///
    /// Vzhledem k tomu, že všechna rekurzivní volání jsou volání funkce Tail,
    /// kompilátor změní funkci na smyčku,
    /// což zvyšuje výkon a snižuje spotřebu paměti.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn "The Greatest Common Factor of 300 and 620 is %d" (greatestCommonFactor 300 620)

    /// Tento příklad zjistí součet seznamu celých čísel pomocí rekurze.
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    /// Tím se funkce Tail sumList stane rekurzivní, a to s použitím pomocné funkce s akumulátorem výsledků.
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    /// Tím se vyvolá rekurzivní pomocná funkce Tail, poskytující 0 jako zdrojový akumulátor.
    /// Takový postup je v jazyce F# běžný.
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn "The sum 1-10 is %d" (sumListTailRecursive oneThroughTen)


/// Záznamy jsou agregátem pojmenovaných hodnot s volitelnými členy (jako jsou metody).
/// Jsou neměnné a mají sémantiku se strukturální rovností.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/records
module RecordTypes =

    /// Tento příklad ukazuje, jak definovat nový typ záznamu.
    type ContactCard =
        { Name     : string
          Phone    : string
          Verified : bool }

    /// Tento příklad ukazuje, jak vytvořit instanci typu záznamu.
    let contact1 =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false }

    /// Můžete to udělat i na stejném řádku se středníky (;) jako oddělovači.
    let contactOnSameLine = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

    /// Tento příklad ukazuje, jak použít copy-and-update pro hodnoty záznamu. Vytvoří
    /// hodnotu nového záznamu, která je kopií záznamu contact1, ale má jiné hodnoty pro
    /// pole Telefon a Ověřeno.
    ///
    /// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/copy-and-update-record-expressions
    let contact2 =
        { contact1 with
            Phone = "(206) 555-0112"
            Verified = true }

    /// Tento příklad ukazuje, jak napsat funkci, která zpracuje hodnotu záznamu.
    /// Převádí objekt ContactCard na řetězec.
    let showContactCard (c: ContactCard) =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn "Alf's Contact Card: %s" (showContactCard contact1)

    /// Toto je příklad záznamu se členem.
    type ContactCardAlternate =
        { Name     : string
          Phone    : string
          Address  : string
          Verified : bool }

        /// Členové můžou implementovat objektově orientované členy.
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified)" else "") + this.Address

    let contactAlternate =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false
          Address = "111 Alf Street" }

    // Ke členům se přistupuje prostřednictvím operátoru „.“ u typu tvořícího instanci.
    printfn "Alf's alternate contact card is %s" contactAlternate.PrintedContactCard

    /// Záznamy můžou být vyjádřeny i jako struktury prostřednictvím atributu Struct.
    /// To je užitečné v situacích, kdy má výkon struktur větší váhu než
    /// flexibilita odkazových typů.
    [<Struct>]
    type ContactCardStruct =
        { Name     : string
          Phone    : string
          Verified : bool }


/// Rozlišovaná sjednocení (zkratka: DU) jsou hodnoty, které můžou představovat celou řadu pojmenovaných forem nebo případů.
/// Data uložená v DU můžou představovat jednu z několika různých hodnot.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/discriminated-unions
module DiscriminatedUnions =

    /// Následující příklad představuje barvu hrací karty.
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    /// Rozlišované sjednocení může také představovat hodnotu hrací karty.
    type Rank =
        /// Představuje hodnotu karet 2 .. 10.
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        /// Rozlišovaná sjednocení můžou také implementovat objektově orientované členy.
        static member GetAllRanks() =
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]

    /// Toto je typ záznamu, který kombinuje barvu a hodnotu hrací karty.
    /// Při vyjadřování dat se běžně používají záznamy i rozlišovaná sjednocení.
    type Card = { Suit: Suit; Rank: Rank }

    /// Tady se vypočítá seznam představující všechny karty z balíčku.
    let fullDeck =
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do
                  yield { Suit=suit; Rank=rank } ]

    /// Tento příklad převede objekt Card na řetězec.
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

    /// Tento příklad vytiskne všechny karty v hracím balíčku.
    let printAllCards() =
        for card in fullDeck do
            printfn "%s" (showPlayingCard card)

    // Rozlišovaná sjednocení s jedním případem se často používají pro modelování domén. Tím můžete získat dodatečnou bezpečnost typů
    // oproti primitivním typům, jako jsou řetězce a celá čísla.
    //
    // Rozlišovaná sjednocení s jedním případem nejde implicitně převést na typ nebo z typu, který obalují.
    // Například funkce, která přebírá adresu, nemůže jako vstup převzít řetězec
    // a naopak.
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    // Instanci rozlišovaného sjednocení s jedním případem můžete snadno vytvořit následujícím způsobem.
    let address = Address "111 Alf Way"
    let name = Name "Alf"
    let ssn = SSN 1234567890

    /// Pokud danou hodnotu potřebujete, můžete základní hodnotu rozbalit pomocí jednoduché funkce.
    let unwrapAddress (Address a) = a
    let unwrapName (Name n) = n
    let unwrapSSN (SSN s) = s

    // Tisk rozlišovaných sjednocení s jedním případem je jednoduchý s použitím rozbalovacích funkcí.
    printfn "Address: %s, Name: %s, and SSN: %d" (address |> unwrapAddress) (name |> unwrapName) (ssn |> unwrapSSN)

    /// Rozlišovaná sjednocení podporují i rekurzivní definice.
    ///
    /// Toto představuje binární vyhledávací strom, přičemž jeden případ je prázdný strom
    /// a druhý je uzel s hodnotou a dvěma podstromy.
    type BST<'T> =
        | Empty
        | Node of value:'T * left: BST<'T> * right: BST<'T>

    /// Zkontroluje, jestli položka existuje v binárním vyhledávacím stromu.
    /// Rekurzivně vyhledává porovnáváním vzorů. Vrátí hodnotu true, pokud existuje; v opačném případě false.
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left) // Zkontroluje levý podstrom.
            else (exists item right) // Zkontroluje pravý podstrom.

    /// Vloží položku do binárního vyhledávacího stromu.
    /// Najde místo pro rekurzivní vložení pomocí porovnávání vzorů a pak vloží nový uzel.
    /// Pokud je už položka přítomna, nevloží nic.
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node // Nemusí se vkládat, už existuje; vrátí se uzel.
            elif item < x then Node(x, insert item left, right) // Provede volání do levého podstromu.
            else Node(x, left, insert item right) // Provede volání do pravého podstromu.

    /// Rozlišovaná sjednocení můžou být vyjádřena i jako struktury prostřednictvím atributu Struct.
    /// To je užitečné v situacích, kdy má výkon struktur větší váhu než
    /// flexibilita odkazových typů.
    ///
    /// Při tomto postupu je ale třeba vědět dvě důležité věci:
    ///     1. Rozlišované sjednocení typu struktura nemůže být definované rekurzivně.
    ///     2. Rozlišované sjednocení typu struktura musí mít jedinečné názvy pro každý ze svých případů.
    [<Struct>]
    type Shape =
        | Circle of radius: float
        | Square of side: float
        | Triangle of height: float * width: float


/// Porovnávání vzorů je funkce jazyka F#, která umožňuje používat vzory,
/// což představuje způsob, jak porovnávat data s logickou strukturou nebo strukturami,
/// jak rozložit data na základní části nebo extrahovat informace z dat různými způsoby.
/// Odesílání pak můžete provádět na základě vzoru v rámci porovnávání vzorů.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/pattern-matching
module PatternMatching =

    /// Záznam pro jméno a příjmení daného člověka
    type Person = {
        First : string
        Last  : string
    }

    /// Rozlišované sjednocení se 3 různými typy zaměstnanců
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// Spočítají se všichni zaměstnanci pod daným zaměstnancem v hierarchii řízení,
    /// včetně tohoto zaměstnance.
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(id) ->
                0
            | Manager(id, reports) ->
                reports |> List.sumBy countReports
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    /// Vyhledá všechny nadřízené/výkonné pracovníky se jménem Dave, kteří nemají žádné podřízené.
    /// Tady se používá zkrácený název function jako výraz lambda.
    let rec findDaveWithOpenPosition(emps : List<Employee>) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true // [] odpovídá prázdnému seznamu.
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false) // „_“ je zástupný vzor, kterému odpovídá úplně všechno.
                                     // Toto řeší případ „or else“

    /// Můžete také použít zkrácenou konstrukci function pro porovnávání vzorů,
    /// což je užitečné při psaní funkcí, které využívají částečné použití argumentů.
    let private parseHelper f = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDateTimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    // Definujte pár dalších funkcí, které se analyzují s pomocnou funkcí.
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

    // Aktivní vzory představují další efektivní konstrukci pro použití s porovnáváním vzorů.
    // Umožňují rozdělit vstupní data do vlastních forem, přičemž se rozkládají v místě volání porovnávání vzorů.
    //
    // Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/active-patterns
    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    /// Porovnávání vzorů přes klíčové slovo function a aktivní vzory často vypadá takto.
    let printParseResult = function
        | Int x -> printfn "%d" x
        | Double x -> printfn "%f" x
        | Date d -> printfn "%s" (d.ToString())
        | TimeSpan t -> printfn "%s" (t.ToString())
        | _ -> printfn "Nothing was parse-able!"

    // Volání tiskárny s nějakými jinými hodnotami k parsování
    printParseResult "12"
    printParseResult "12.045"
    printParseResult "12/28/2016"
    printParseResult "9:01PM"
    printParseResult "banana!"


/// Hodnotami parametru můžou být hodnoty jakéhokoliv typu s označením Some (Nějaké) nebo None (Žádné).
/// Používají se často v kódu F#, kde reprezentují případy, ve kterých by se v řadě jiných
/// jazyků používaly odkazy null.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/options
module OptionValues =

    /// Nejprve definujte PSČ prostřednictvím rozlišovaného sjednocení s jedním případem.
    type ZipCode = ZipCode of string

    /// Dále definujte typ, kde je PSČ volitelné.
    type Customer = { ZipCode: ZipCode option }

    /// Potom definujte typ rozhraní, který bude představovat objekt pro výpočet expediční oblasti pro PSČ zákazníka
    /// se zohledněním implementací pro abstraktní metody getState a getShippingZone.
    type ShippingCalculator =
        abstract GetState : ZipCode -> string option
        abstract GetShippingZone : string -> int

    /// Dále vypočítejte expediční oblast pro zákazníka pomocí instance kalkulačky.
    /// Tady se používají kombinátory v modulu Option, pomocí kterých se povoluje funkční kanál pro
    /// transformaci dat s volitelnými hodnotami.
    let CustomerShippingZone (calculator: ShippingCalculator, customer: Customer) =
        customer.ZipCode
        |> Option.bind calculator.GetState
        |> Option.map calculator.GetShippingZone


/// Měrné jednotky jsou způsob, jak anotovat primitivní číselné typy typově bezpečnou metodou.
/// Pak u těchto hodnot můžete provádět typově bezpečnou aritmetiku.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/units-of-measure
module UnitsOfMeasure =

    /// Nejdříve otevřete kolekci běžných názvů jednotek.
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    /// Definovat unifikovanou konstantu
    let sampleValue1 = 1600.0<meter>

    /// Potom definujte nový typ jednotky
    [<Measure>]
    type mile =
        /// Přepočtový koeficient pro přepočet mílí na metry
        static member asMeter = 1609.34<meter/mile>

    /// Definovat unifikovanou konstantu
    let sampleValue2  = 500.0<mile>

    /// Vypočítat konstantu v metrickém systému
    let sampleValue3 = sampleValue2 * mile.asMeter

    // Hodnoty s měrnými jednotkami je možné používat stejně jako primitivní číselný typ pro operace, jako je tisk.
    printfn "After a %f race I would walk %f miles which would be %f meters" sampleValue1 sampleValue2 sampleValue3


/// Třídy představují způsob definice nových objektových typů v jazyce F# a podporují standardní objektově orientované konstrukce.
/// Můžou mít celou řadu členů (metody, vlastnosti, události atd.).
///
/// Další informace o třídách: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/classes
///
/// Další informace o členech: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/members
module DefiningClasses =

    /// Jednoduchá dvojrozměrná vektorová třída.
    ///
    /// Konstruktor třídy je na prvním řádku
    /// a přebírá dva argumenty: dx a dy, oba typu double.
    type Vector2D(dx : double, dy : double) =

        /// Toto interní pole ukládá délku vektoru vypočítanou při
        /// zkonstruování objektu
        let length = sqrt (dx*dx + dy*dy)

        // this určuje název identifikátoru samotného objektu.
        // V metodách instancí se musí objevovat před názvem člena.
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        /// Tento člen je metoda. Předchozí členové představují vlastnosti.
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    /// Toto je způsob, jak vytvořit instanci třídy Vector2D.
    let vector1 = Vector2D(3.0, 4.0)

    /// Získá nový škálovaný vektorový objekt, aniž by se změnil původní objekt.
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f\nLength of vector2: %f" vector1.Length vector2.Length


/// Obecné třídy umožňují definování typů s ohledem na sadu parametrů typu.
/// V následujícím příkladu „T“ představuje parametr typu pro třídu.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/generics/
module DefiningGenericClasses =

    type StateTracker<'T>(initialElement: 'T) =

        /// Toto interní pole ukládá stavy v seznamu.
        let mutable states = [ initialElement ]

        /// Přidá nový element do seznamu stavů.
        member this.UpdateState newState =
            states <- newState :: states  // Použije operátor <- ke změně (mutaci) hodnoty.

        /// Získá celý seznam historických stavů.
        member this.History = states

        /// Získá nejnovější stav.
        member this.Current = states.Head

    /// Instance int třídy pro sledování stavů. Poznámka: Parametr typu je odvozený.
    let tracker = StateTracker 10

    // Přidat stav
    tracker.UpdateState 17


/// Rozhraní jsou typy objektů pouze s členy abstract.
/// Objektové typy a výrazy můžou implementovat rozhraní.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/interfaces
module ImplementingInterfaces =

    /// Toto je typ, který implementuje rozhraní IDisposable.
    type ReadFile() =

        let file = new System.IO.StreamReader("readme.txt")

        member this.ReadLine() = file.ReadLine()

        // Toto je implementace členů IDisposable.
        interface System.IDisposable with
            member this.Dispose() = file.Close()


    /// Toto je objekt, který implementuje IDisposable pomocí výrazu objektu.
    /// Na rozdíl od jiných jazyků, jako jsou C# nebo Java, není nutná nová definice typu
    /// pro implementaci rozhraní.
    let interfaceImplementation =
        { new System.IDisposable with
            member this.Dispose() = printfn "disposed" }


/// Knihovna FSharp.Core definuje rozsah funkcí paralelního zpracování. Tady
/// použijete některé funkce pro paralelní zpracování polí.
///
/// Další informace: https://msdn.microsoft.com/cs-cz/visualfsharpdocs/conceptual/array.parallel-module-%5Bfsharp%5D
module ParallelArrayProgramming =

    /// Nejdříve pole vstupů.
    let oneBigArray = [| 0 .. 100000 |]

    // Dále definujte funkci, která bude provádět výpočty náročné na procesor.
    let rec computeSomeFunction x =
        if x <= 2 then 1
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)

    // Dále proveďte paralelní mapování přes velké vstupní pole.
    let computeResults() =
        oneBigArray
        |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    // Potom vytiskněte výsledky.
    printfn "Parallel computation results: %A" (computeResults())



/// Události jsou běžné základní struktury programového kódu .NET, zejména s aplikacemi WinForms nebo WPF.
///
/// Další informace: https://docs.microsoft.com/cs-cz/dotnet/articles/fsharp/language-reference/members/events
module Events =

    /// Nejdříve vytvořte instanci objektu Event, který se bude skládat z bodu odběru (event.Publish) a aktivační události (event.Trigger).
    let simpleEvent = new Event<int>()

    // Potom přidejte obslužnou rutinu pro událost.
    simpleEvent.Publish.Add(
        fun x -> printfn "this handler was added with Publish.Add: %d" x)

    // Potom spusťte událost.
    simpleEvent.Trigger(5)

    // Potom vytvořte instanci objektu Event podle standardní konvence .NET: (sender, EventArgs).
    let eventForDelegateType = new Event<EventHandler, EventArgs>()

    // Dále přidejte obslužnou rutinu pro tuto novou událost.
    eventForDelegateType.Publish.AddHandler(
        EventHandler(fun _ _ -> printfn "this handler was added with Publish.AddHandler"))

    // Potom spusťte tuto událost (poznámka: musí být nastavený argument odesílatele).
    eventForDelegateType.Trigger(null, EventArgs.Empty)



#if COMPILED
module BoilerPlateForForm =
    [<System.STAThread>]
    do ()
    do System.Windows.Forms.Application.Run()
#endif
