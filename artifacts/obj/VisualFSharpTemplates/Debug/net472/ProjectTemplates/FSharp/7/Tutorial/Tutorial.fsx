// Dieses Beispiel zeigt Ihnen verschiedene Elemente der F#-Programmiersprache.
//
// *******************************************************************************************************
//   Markieren Sie zum Ausführen des Codes in F# Interactive einen Codeabschnitt, und drücken Sie dann entweder ALT+EINGABETASTE oder klicken Sie mit der rechten Maustaste
//   und wählen Sie "In Interactive ausführen" aus.  Sie können das F# Interactive-Fenster über das Menü "Ansicht" öffnen.
// *******************************************************************************************************
//
// Weitere Informationen zu F# finden Sie unter:
//     https://fsharp.org
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/
//
// Dieses Tutorial ist auch als Dokumentation verfügbar. Siehe hierzu:
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/tour
//
// Verwenden Sie Folgendes, um weitere Informationen zur praktischen F#-Programmierung zu erhalten:
//     https://fsharp.org/guides/enterprise/
//     https://fsharp.org/guides/cloud/
//     https://fsharp.org/guides/web/
//     https://fsharp.org/guides/data-science/
//
// Verwenden Sie Folgendes, um die Visual F# Power Tools zu installieren:
//     "Extras" > "Erweiterungen und Updates" > "Online", und suchen Sie nach
//
// Weitere Vorlagen zum Verwenden mit F# finden Sie in Visual Studio unter "Onlinevorlagen",
//     "Neue Projekte" > "Onlinevorlagen".

// F# unterstützt drei Arten von Kommentaren:

//  1. Kommentare mit doppeltem Schrägstrich. Diese werden in den meisten Situationen verwendet.
(*  2. Blockkommentare im ML-Stil. Diese werden nicht sehr häufig verwendet. *)
/// 3. Kommentare mit drei Schrägstrichen. Diese werden zum Dokumentieren von Funktionen, Typen usw. verwendet.
///    Sie erscheinen als Text, wenn Sie den Mauszeiger über einem Element positionieren, das mit diesen Kommentaren versehen ist.
///
///    Sie bieten außerdem Unterstützung für XML-Kommentare im .NET-Stil zum Generieren von Referenzdokumentation,
///    und sie ermöglichen das Extrahieren von Informationen über Editoren (z.B. Visual Studio).
///    Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/xml-documentation.


// Öffnen Sie Namespaces mit dem Schlüsselwort "open".
//
// Weitere Informationen finden Sie hier: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/import-declarations-the-open-keyword.
open System


/// Ein Modul ist eine Gruppierung von F#-Code, z.B. Werte, Typen und Funktionswerte.
/// Die Codegruppierung in Modulen ermöglicht das Zusammenfassen von zueinander in Beziehung stehendem Code sowie das Vermeiden von Namenskonflikten in Ihrem Programm.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/modules.
module IntegersAndNumbers =

    /// Dies ist ein Beispiel für eine Ganzzahl.
    let sampleInteger = 176

    /// Dies ist ein Beispiel für eine Gleitkommazahl.
    let sampleDouble = 4.1

    /// Hier wird mithilfe einer arithmetischen Operation eine neue Zahl berechnet. Numerische Typen werden unter Verwendung der
    /// Funktionen "int", "double" usw. konvertiert.
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    /// Dies ist eine Liste der Zahlen von 0 bis 99.
    let sampleNumbers = [ 0 .. 99 ]

    /// Dies ist eine Liste aller Tupel, die alle Zahlen von 0 bis 99 sowie Ihre Quadratzahlen enthalten.
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // Die nächste Zeile gibt eine Liste mit Tupeln aus, wobei "%A" für die generische Ausgabe verwendet wird.
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfSquares

    // Dies ist ein Beispiel für eine ganze Zahl mit einer Typanmerkung.
    let sampleInteger3: int = 1


/// Werte in F# sind standardmäßig unveränderlich. Sie können im Verlauf
/// der Ausführung eines Programms nicht geändert werden – es sei denn, sie sind explizit als änderbar gekennzeichnet.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/values/index#why-immutable
module Immutability =

    /// Wenn ein Wert mithilfe von "let" an einen Namen gebunden wird, ist er unveränderlich.
    ///
    /// Die zweite Codezeile kann nicht kompiliert werden, da "number" unveränderlich und gebunden ist.
    /// "number" darf in F# nicht als ein anderer Wert neu definiert werden.
    let number = 2
    // let number = 3

    /// Eine veränderliche Bindung. Dies ist erforderlich, damit der Wert von "otherNumber" verändert werden kann.
    let mutable otherNumber = 2

    printfn "'otherNumber' is %d" otherNumber

    // Wenn Sie einen Wert verändern, weisen Sie mithilfe von "<-" einen neuen Wert zu.
    //
    // Sie können "=" hier nicht verwenden, da es für Gleichheit verwendet wird.
    // oder andere Kontexte wie "let" oder "module"
    otherNumber <- otherNumber + 1

    printfn "'otherNumber' changed to be %d" otherNumber


/// Bei der F#-Programmierung werden größtenteils Funktionen definiert, die Eingabedaten in hilfreiche
/// Ergebnisse umwandelt.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/functions/
module BasicFunctions =

    /// Verwenden Sie "let", um eine Funktion zu definieren. Diese akzeptiert ein Integer-Argument und gibt einen Integer zurück.
    /// Klammern sind für Funktionsargumente optional, außer wenn Sie eine explizite Typanmerkung verwenden.
    let sampleFunction1 x = x*x + 3

    /// Die Funktion anwenden, und das Rückgabeergebnis der Funktion mithilfe von "let" benennen.
    /// Der Variablentyp wird vom Rückgabetyp der Funktion abgeleitet.
    let result1 = sampleFunction1 4573

    // Diese Zeile verwendet "%d", um das Ergebnis als Integer zu drucken. Dies ist typsicher.
    // Wenn "result1" nicht vom Typ "int" wäre, käme es bei der Kompilierung der Zeile zu einem Fehler.
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    /// Blenden Sie bei Bedarf den Typ eines Parameternamens mithilfe von "(argument:type)" ein. Klammern sind erforderlich.
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn "The result of applying the 2nd sample function to (7 + 4) is %d" result2

    /// Für Bedingungen wird Folgendes verwendet: if/then/elid/elif/else.
    ///
    /// Bei der Syntax von F# werden ebenso wie bei Sprachen wie Python leerzeichenbasierte Einzüge beachtet.
    let sampleFunction3 x =
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)

    // Diese Zeile verwendet "%f", um das Ergebnis als float-Eigenschaft zu drucken. Wie auch zuvor bei "%d" ist dies typsicher.
    printfn "The result of applying the 3rd sample function to (6.5 + 4.5) is %f" result3


/// Boolesche Werte sind grundlegende Datentypen in F#. Hier finden Sie einige Beispiele für boolesche Werte und Bedingungen.
///
/// Weitere Informationen finden Sie unter:
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/primitive-types
///     Und
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/symbol-and-operator-reference/boolean-operators
module Booleans =

    /// Boolesche Werte sind "true" und "false".
    let boolean1 = true
    let boolean2 = false

    /// Operatoren für boolesche Werte sind "not", "&&" und "||".
    let boolean3 = not boolean1 && (boolean2 || false)

    // Diese Zeile verwendet "%b" zum Drucken eines booleschen Werts. Dies ist typsicher.
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %b" boolean3


/// Zeichenfolgen sind grundlegende Datentypen in F#. Hier finden Sie einige Beispiele für Zeichenfolgen und Zeichenfolgenmanipulationen.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/strings
module StringManipulation =

    /// Für Zeichenfolgen werden doppelte Anführungszeichen verwendet.
    let string1 = "Hello"
    let string2  = "world"

    /// Mit "@" lassen sich ausführliche Zeichenfolgenliterale erstellen.
    /// Dadurch werden Escapezeichen wie "\", "\n", "\t" usw. ignoriert.
    let string3 = @"C:\Program Files\"

    /// Für Zeichenfolgen können auch dreifache Anführungszeichen verwendet werden.
    let string4 = """The computer said "hello world" when I told it to!"""

    /// Die Verkettung von Zeichenfolgen erfolgt in der Regel mit dem Operator "+".
    let helloWorld = string1 + " " + string2

    // Diese Zeile verwendet "%s" zum Drucken eines Zeichenfolgewerts. Dies ist typsicher.
    printfn "%s" helloWorld

    /// Für Teilzeichenfolgen wird die Indexernotation verwendet. Diese Zeile extrahiert die ersten sieben Zeichen als Teilzeichenfolge.
    /// Im Gegensatz zu den meisten anderen Sprachen sind Zeichenfolgen in F# nullindiziert.
    let substring = helloWorld.[0..6]
    printfn "%s" substring


/// Tupel sind einfache Datenwertkombinationen.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/tuples
module Tuples =

    /// Ein einfaches Tupel aus Integerwerten.
    let tuple1 = (1, 2, 3)

    /// Eine Funktion, die die Reihenfolge von zwei Werten in einem Tupel austauscht.
    ///
    /// Der F#-Typrückschluss generalisiert die Funktion automatisch und erstellt einen generischen Typ,
    /// d. h. er funktioniert mit jedem Typ.
    let swapElems (a, b) = (b, a)

    printfn "The result of swapping (1, 2) is %A" (swapElems (1,2))

    /// Ein Tupel aus einem Integer, einer Zeichenfolge
    /// und einer Gleitkommazahl mit doppelter Genauigkeit.
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A\ttuple2: %A" tuple1 tuple2

    /// Ein einfaches Tupel aus Integerwerten mit einer Typanmerkung.
    /// Typanmerkungen für Tupel trennen Elemente durch das *-Symbol.
    let tuple3: int * int = (5, 9)

    /// Tupel sind normalerweise Objekte, sie können aber auch als Strukturen dargestellt werden.
    ///
    /// Sie arbeiten mit Strukturen in C# und Visual Basic.Net vollständig zusammen.
    /// Strukturtupel sind jedoch nicht implizit mit Objekttupeln (häufig als Referenztupel bezeichnet) konvertierbar.
    ///
    /// Die unten angezeigte zweite Zeile kann aus diesem Grund nicht kompiliert werden. Heben Sie die Auskommentierung auf, und sehen Sie, was passiert.
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // Sie können zwar nicht implizit zwischen Strukturtupeln und Verweistupeln konvertieren,
    // Sie können aber wie unten gezeigt eine explizite Konvertierung über den Musterabgleich durchführen.
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)

    printfn "Struct Tuple: %A\nReference tuple made from the Struct Tuple: %A" sampleStructTuple (sampleStructTuple |> convertFromStructTuple)


/// Die F#-PipeOperatoren ("|>", "<|" usw.) und die F#-Zusammensetzungsoperatoren (">>", "<<")
/// werden bei der Datenverarbeitung umfassend eingesetzt. Diese Operatoren sind Funktionen,
/// die die partielle Anwendung nutzen.
///
/// Weitere Informationen zu diesen Operatoren finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/functions/#function-composition-and-pipelining
/// Weitere Informationen zur partiellen Anwendung finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/functions/#partial-application-of-arguments
module PipelinesAndComposition =

    /// Quadriert einen Wert.
    let square x = x * x

    /// Addiert 1 zu einem Wert hinzu.
    let addOne x = x + 1

    /// Testet mit Modulo, ob ein Integerwert gerade ist.
    let isOdd x = x % 2 <> 0

    /// Eine Liste mit fünf Nummern. Weitere Informationen zu Listen finden Sie später.
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// Aus einer Liste mit Integern werden die geraden Zahlen herausgefiltert,
    /// die sich ergebenden ungeraden Zahlen werden quadratiert, und zu dem Ergebnis wird 1 hinzuaddiert.
    let squareOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" numbers (squareOddValuesAndAddOne numbers)

    /// Eine kürzere Möglichkeit zum Schreiben von "squareOddValuesAndAddOne" besteht im Verschachteln von jedem
    /// Teilergebnis im Funktionsaufruf selbst.
    ///
    /// Dadurch wird die Funktion viel kürzer,
    /// die Reihenfolge der Datenverarbeitung ist jedoch schlechter sichtbar.
    let squareOddValuesAndAddOneNested values =
        List.map addOne (List.map square (List.filter isOdd values))

    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers (squareOddValuesAndAddOneNested numbers)

    /// Eine bevorzugte Möglichkeit zum Schreiben von "squareOddValuesAndAddOne" besteht in der Verwendung von F#-Pipe-Operatoren.
    /// Dadurch können Sie verhindern, dass Zwischenergebnisse erstellt werden, dies ist jedoch besser lesbar
    /// als verschachtelte Funktionsaufrufe wie "squareOddValuesAndAddOneNested".
    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    printfn "processing %A through 'squareOddValuesAndAddOnePipeline' produces: %A" numbers (squareOddValuesAndAddOnePipeline numbers)

    /// Sie können "squareOddValuesAndAddOnePipeline" kürzen, indem Sie den zweiten "List.map"-Aufruf
    /// mithilfe einer Lambda-Funktion in den ersten verschieben.
    ///
    /// Pipelines werden auch innerhalb der Lambda-Funktion verwendet. F#-Pipe-Operatoren
    /// können auch für einzelne Werte verwendet werden. So ist eine leistungsstarke Datenverarbeitung möglich.
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" numbers (squareOddValuesAndAddOneShorterPipeline numbers)

    /// Es ist nicht mehr erforderlich, "values" als Parameter aufzunehmen, indem Sie mithilfe von ">>"
    /// die beiden zentralen Vorgänge erstellen: Herausfiltern von geraden Zahlen, Quadratieren und Addieren von 1.
    /// Der Teil "fun x -> ..." des Lambdaausdrucks ist dementsprechend ebenfalls nicht erforderlich, da "x" lediglich
    /// in dem Bereich definiert wird, damit es an eine Funktionspipeline übergeben werden kann. Daher kann ">>"
    /// dort ebenfalls verwendet werden.
    ///
    /// Das Ergebnis von "squareOddValuesAndAddOneComposition" selbst ist eine andere Funktion, die eine
    /// Liste von Integern als Eingabe verwendet. Wenn Sie "squareOddValuesAndAddOneComposition" mit einer Liste
    /// von Integern ausführen, erhalten Sie das gleiche Ergebnis wie bei vorherigen Funktionen.
    ///
    /// Dabei wird die so genannte Funktionskomposition verwendet. Das ist möglich, da Funktionen in F#
    /// die partielle Anwendung nutzen, und die Ein- und Ausgabetypen jedes Datenverarbeitungsvorgangs
    /// mit den Signaturen der verwendeten Funktionen übereinstimmen.
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneComposition' produces: %A" numbers (squareOddValuesAndAddOneComposition numbers)


/// Listen sind geordnete, unveränderliche, einfach verknüpfte Listen. Ihre Auswertung ist streng.
///
/// Dieses Modul zeigt verschiedene Möglichkeiten zum Erstellen von Listen und Prozesslisten mit einigen Funktionen
/// im Modul "List" in der F#-Kernbibliothek.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/lists
module Lists =

    /// Listen werden mithilfe von "[ ... ]" definiert. Dies ist eine leere Liste.
    let list1 = [ ]

    /// Dies ist eine Liste mit drei Elementen. ";" dient dazu, Elemente in der gleichen Zeile zu trennen.
    let list2 = [ 1; 2; 3 ]

    /// Sie können Elemente auch trennen, indem Sie sie in separaten Zeilen einfügen.
    let list3 = [
        1
        2
        3
    ]

    /// Dies ist eine Liste mit ganzen Zahlen von 1 bis 1000.
    let numberList = [ 1 .. 1000 ]

    /// Listen können auch mithilfe von Berechnungen generiert werden. Dies ist eine Liste mit
    /// allen Tagen des Jahres.
    let daysList =
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                  yield System.DateTime(2017, month, day) ]

    // Drucken Sie mithilfe von "List.take" die ersten fünf Elemente in "daysList".
    printfn "The first 5 days of 2017 are: %A" (daysList |> List.take 5)

    /// Berechnungen können Bedingungen enthalten. Dies ist eine Liste mit den Tupeln,
    /// bei denen es sich um die Koordinaten der schwarzen Felder auf einem Schachbrett handelt.
    let blackSquares =
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do
                  if (i+j) % 2 = 1 then
                      yield (i, j) ]

    /// Listen können mithilfe von "List.map" und anderen funktionalen Programmierkombinatoren umgewandelt werden.
    /// Diese Definition erzeugt eine neue Liste, indem die Zahlen in "numberList" quadriert werden. Dabei wird der Pipeline-
    /// Operator verwendet, um ein Argument an "List.map" zu übergeben.
    let squares =
        numberList
        |> List.map (fun x -> x*x)

    /// Es stehen noch viele andere Listenkombinationen zur Verfügung. Mit dem Folgenden wird die Summe der Quadrate der
    /// durch 3 teilbaren Zahlen berechnet.
    let sumOfSquares =
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)

    printfn "The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d" sumOfSquares


/// Arrays sind veränderliche Sammlungen fester Größe, die Elemente des gleichen Typs enthalten.
///
/// Sie ähneln Listen (sie unterstützen Enumeration und haben ähnliche Combinators für die Datenverarbeitung),
/// sind im Allgemeinen jedoch schneller und unterstützen einen schnellen wahlfreien Zugriff. Dafür sind sie jedoch weniger sicher, da sie veränderlich sind.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/arrays
module Arrays =

    /// Dies ist das leere Array. Die Syntax ähnelt der von Listen, verwendet jedoch stattdessen "[| ... |]".
    let array1 = [| |]

    /// Arrays werden mithilfe der gleichen Konstrukte angegeben wie Listen.
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// Dies ist ein Array mit Zahlen von 1 bis 1000.
    let array3 = [| 1 .. 1000 |]

    /// Dieses Array enthält nur die Wörter "hello" und "world".
    let array4 =
        [| for word in array2 do
               if word.Contains("l") then
                   yield word |]

    /// Dieses Array wurde per Index initialisiert und enthält gerade Zahlen von 0 bis 2000.
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// Teilarrays werden mithilfe der Segmentnotation extrahiert.
    let evenNumbersSlice = evenNumbers.[0..500]

    /// Mit For-Schleifen können Sie bei Arrays und Listen Schleifen ausführen.
    for word in array4 do
        printfn "word: %s" word

    // Sie können die Inhalte eines Arrayelements mithilfe des Zuweisungsoperators "Pfeil nach links" ändern.
    //
    // Weitere Informationen zu diesem Operator finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/values/index#mutable-variables
    array2.[1] <- "WORLD!"

    /// Sie können Arrays mithilfe von "Array.map" und anderen funktionalen Programmiervorgängen umwandeln.
    /// Mit Folgendem wird die Summe der Längen von Wörtern berechnet, die mit "h" beginnen.
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn "The sum of the lengths of the words in Array 2 is: %d" sumOfLengthsOfWords


/// Sequenzen sind logische Serien von Elementen, die alle vom gleichen Typ sind. Ihr Typ ist allgemeiner als Listen und Arrays.
///
/// Sequenzen werden bei Bedarf ausgewertet und bei jeder Iteration erneut ausgewertet.
/// Eine F#-Sequenz ist ein Alias für .NET System.Collections.Generic.IEnumerable<'T>.
///
/// Funktionen mit Sequenzverarbeitung können auch auf Listen und Arrays angewendet werden.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/sequences
module Sequences =

    /// Dies ist die leere Sequenz.
    let seq1 = Seq.empty

    /// Dies ist eine Sequenz mit Werten.
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    /// Dies ist eine bedarfsbasierte Sequenz von 1 bis 1000.
    let numbersSeq = seq { 1 .. 1000 }

    /// Diese Sequenz generiert die Wörter "hello" und "world".
    let seq3 =
        seq { for word in seq2 do
                  if word.Contains("l") then
                      yield word }

    /// Diese Sequenz erzeugt gerade Zahlen bis 2000.
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    /// Dies ist eine unendliche Sequenz und ermöglicht Zufallsdurchläufe.
    /// In diesem Beispiel werden mithilfe von "yield!" die einzelnen Elemente einer Untersequenz zurückgegeben.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// Dieses Beispiel zeigt die ersten 100 Elemente des Zufallsdurchlaufs.
    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList

    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk


/// Rekursive Funktionen können sich selbst aufrufen. In F# sind Funktionen nur rekursiv,
/// für die Deklaration mithilfe von "let rec".
///
/// Rekursion ist die bevorzugte Möglichkeit zum Verarbeiten von Sequenzen oder Sammlungen in F#.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/functions/index#recursive-functions
module RecursiveFunctions =

    /// Dieses Beispiel zeigt eine rekursive Funktion, die die Fakultät einer ganzen
    /// Zahl berechnet. Zum Definieren einer rekursiven Funktion wird "let rec" verwendet.
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n-1)

    printfn "Factorial of 6 is: %d" (factorial 6)

    /// Berechnet den höchsten gemeinsamen Faktor von zwei Integern.
    ///
    /// Da alle rekursiven Aufrufe Endeaufrufe sind,
    /// wandelt der Compiler die Funktion in eine Schleife um,
    /// was die Leistung verbessert und die Arbeitsspeicherbedarf reduziert.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn "The Greatest Common Factor of 300 and 620 is %d" (greatestCommonFactor 300 620)

    /// Dieses Beispiel berechnet mithilfe von Rekursion die Summe einer Liste von Integern.
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    /// Mithilfe einer Hilfsfunktion mit einem Ergebnisakkumulator wird "sumList" endrekursiv.
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    /// Dies ruft die endrekursive Hilfsfunktion auf und verwendet "0" als Startwertakkumulator.
    /// Dies ist eine häufige Vorgehensweise in F#.
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn "The sum 1-10 is %d" (sumListTailRecursive oneThroughTen)


/// Datensätze sind ein Aggregat aus benannten Werten mit optionalen Membern (wie etwa Methoden).
/// Sie sind nicht veränderlich und verfügen über eine strukturelle Gleichheitssemantik.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/records
module RecordTypes =

    /// Dieses Beispiel zeigt, wie ein neuer Datensatztyp definiert wird.
    type ContactCard =
        { Name     : string
          Phone    : string
          Verified : bool }

    /// In diesem Beispiel erfahren Sie, wie Sie einen Datensatztyp instanziieren.
    let contact1 =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false }

    /// Das ist in der gleichen Zeile auch mit dem Trennzeichen ";" möglich.
    let contactOnSameLine = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

    /// Dieses Beispiel zeigt die Verwendung von "Kopieren und aktualisieren" für Datensatzwerte. Es wird
    /// ein neuer Datensatz als Kopie von "contact1" erstellt, der jedoch über andere Werte
    /// für die Felder "Phone" und "Verified" verfügt.
    ///
    /// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/copy-and-update-record-expressions
    let contact2 =
        { contact1 with
            Phone = "(206) 555-0112"
            Verified = true }

    /// Dieses Beispiel veranschaulicht das Schreiben einer Funktion zum Verarbeiten eines Datensatzwerts.
    /// Es konvertiert ein Objekt vom Typ "ContactCard" in eine Zeichenfolge.
    let showContactCard (c: ContactCard) =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn "Alf's Contact Card: %s" (showContactCard contact1)

    /// Dies ist ein Beispiel für einen Datensatz mit einem Member.
    type ContactCardAlternate =
        { Name     : string
          Phone    : string
          Address  : string
          Verified : bool }

        /// Member können objektorientierte Member implementieren.
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified)" else "") + this.Address

    let contactAlternate =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false
          Address = "111 Alf Street" }

    // Auf Member wird über den Operator "." in einem instanziierten Typ zugegriffen.
    printfn "Alf's alternate contact card is %s" contactAlternate.PrintedContactCard

    /// Datensätze können mithilfe des Attributs "Struct" auch als Strukturen dargestellt werden.
    /// Dies ist in Situationen hilfreich, in denen die Leistung der Strukturen wichtiger ist als
    /// die Flexibilität der Verweistypen.
    [<Struct>]
    type ContactCardStruct =
        { Name     : string
          Phone    : string
          Verified : bool }


/// Diskriminierte Unions (DUs) sind Werte, die eine Anzahl benannter Formen oder Fälle sein können.
/// In DUs gespeicherte Daten können einer von verschiedenen eindeutigen Werten sein.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/discriminated-unions
module DiscriminatedUnions =

    /// Folgendes stellt die Farbe einer Spielkarte dar.
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    /// Eine diskriminierte Union kann auch verwendet werden, um den Rang einer Spielkarte darzustellen.
    type Rank =
        /// Stellt den Rang der Karten 2 bis 10 dar 10
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        /// Diskriminierte Unions können objektorientierte Member implementieren.
        static member GetAllRanks() =
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]

    /// Dieser Datensatztyp kombiniert eine Farbe und einen Rang.
    /// Beim Darstellen von Daten werden häufig sowohl Datensätze als auch diskriminierte Unions verwendet.
    type Card = { Suit: Suit; Rank: Rank }

    /// Dies berechnet eine Liste mit allen Karten im Stapel.
    let fullDeck =
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do
                  yield { Suit=suit; Rank=rank } ]

    /// Dieses Beispiel konvertiert ein Objekt vom Typ "Card" in eine Zeichenfolge.
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

    /// Dieses Beispiel gibt alle Karten in einem Kartenstapel aus.
    let printAllCards() =
        for card in fullDeck do
            printfn "%s" (showPlayingCard card)

    // Einzelfall-DUs werden häufig für die Domänenmodellierung verwendet. Dadurch erhalten Sie zusätzliche Typsicherheit
    // für primitive Typen wie Zeichenfolgen und Integer.
    //
    // Eine implizite Konvertierung von Einzelfall-DUs in den umschlossenen Typ oder aus diesem Typ ist nicht möglich.
    // Beispielsweise eine Funktion, die eine Adresse akzeptiert, kann keine Zeichenfolge als Eingabe akzeptieren
    // (oder umgekehrt).
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    // Sie können Einzelfall-DUs folgendermaßen instanziieren.
    let address = Address "111 Alf Way"
    let name = Name "Alf"
    let ssn = SSN 1234567890

    /// Wenn Sie den Wert benötigen, können Sie den zugrunde liegenden Wert mit einer einfachen Funktion entpacken.
    let unwrapAddress (Address a) = a
    let unwrapName (Name n) = n
    let unwrapSSN (SSN s) = s

    // Mit entpackten Funktionen lassen sich Einzelfall-DUs einfach drucken.
    printfn "Address: %s, Name: %s, and SSN: %d" (address |> unwrapAddress) (name |> unwrapName) (ssn |> unwrapSSN)

    /// Diskriminierte Unions unterstützen auch rekursive Definitionen.
    ///
    /// Dies stellt eine Struktur für die Binärsuche dar, wobei ein Fall eine leere Struktur ist
    /// und der andere Fall einen Knoten mit einem Wert und zwei Unterstrukturen darstellt.
    type BST<'T> =
        | Empty
        | Node of value:'T * left: BST<'T> * right: BST<'T>

    /// Prüfen Sie, ob die Struktur für die Binärsuche ein Element enthält.
    /// Sucht rekursiv mithilfe des Musterabgleichs. Gibt bei vorhandenem Element "true" aus, andernfalls "false".
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left) // Prüfen Sie die linke Unterstruktur.
            else (exists item right) // Prüfen Sie die rechte Unterstruktur.

    /// Fügt in die Struktur für die Binärsuche ein Element ein.
    /// Findet die Position für das rekursive Einfügen mithilfe des Musterabgleichs und fügt anschließend einen neuen Knoten ein.
    /// Wenn das Element bereits vorhanden ist, wird nichts eingefügt.
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node // Einfügen nicht erforderlich, da bereits vorhanden; Knoten zurückgeben.
            elif item < x then Node(x, insert item left, right) // Aufruf in linker Unterstruktur.
            else Node(x, left, insert item right) // Aufruf in rechter Unterstruktur.

    /// Diskriminierte Unions können mithilfe des Attributs "Struct" auch als Struktur dargestellt werden.
    /// Dies ist in Situationen hilfreich, in denen die Leistung der Strukturen wichtiger ist als
    /// die Flexibilität der Verweistypen.
    ///
    /// Dabei sind jedoch zwei Punkte zu beachten:
    ///     1. Eine Struktur-DU kann nicht rekursiv definiert werden.
    ///     2. In einer Struktur-DU muss jeder Fall einen eindeutigen Namen haben.
    [<Struct>]
    type Shape =
        | Circle of radius: float
        | Square of side: float
        | Triangle of height: float * width: float


/// Der Musterabgleich ist eine Funktion von F#, die Ihnen die Verwendung von Mustern ermöglicht,
/// die eine Möglichkeit sind, um Daten mit logischen Strukturen oder Strukturen zu vergleichen,
/// Daten in ihre Einzelteile zu zerlegen oder auf verschiedene Weise Informationen aus Daten zu extrahieren.
/// Das Verteilen ist anschließend mithilfe des Musterabgleichs anhand der Form eines Musters möglich.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/pattern-matching
module PatternMatching =

    /// Ein Datensatz für den Vor- und Nachnamen einer Person
    type Person = {
        First : string
        Last  : string
    }

    /// Eine diskriminierte Union mit drei verschiedenen Arten von Mitarbeitern
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// Zählen Sie alle Personen unterhalb des Angestellten in der Verwaltungshierarchie,
    /// einschließlich des Angestellten.
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(id) ->
                0
            | Manager(id, reports) ->
                reports |> List.sumBy countReports
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    /// Suchen Sie alle Manager/Führungskräfte mit dem Namen "Dave", die über keine Berichte verfügen.
    /// Dies verwendet die Kurzform "function" als Lambdaausdruck.
    let rec findDaveWithOpenPosition(emps : List<Employee>) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true // [] entspricht einer leeren Liste.
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false) // "_" ist ein Platzhaltermuster, das mit allem übereinstimmt
                                     // Dies behandelt den "or else"-Fall.

    /// Sie können das Kurzform-Funktionskonstrukt auch für den Musterabgleich verwenden,
    /// was beim Schreiben von Funktionen, die die partielle Anwendung nutzen, hilfreich ist.
    let private parseHelper f = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDateTimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    // Definieren Sie weitere Funktionen, die eine Analyse mithilfe der Hilfsfunktion durchführen.
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

    // Aktive Muster sind ein weiteres leistungsstarkes Konstrukt, das beim Musterabgleich verwendet werden kann.
    // Sie ermöglichen eine Partitionierung der Eingabedaten in benutzerdefinierte Formen, wobei sie an der Musterabgleichs-Aufrufsite zerlegt werden.
    //
    // Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/active-patterns
    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    /// Der Musterabgleich mithilfe des Schlüsselworts "function" und das aktive Muster sehen häufig wie folgt aus.
    let printParseResult = function
        | Int x -> printfn "%d" x
        | Double x -> printfn "%f" x
        | Date d -> printfn "%s" (d.ToString())
        | TimeSpan t -> printfn "%s" (t.ToString())
        | _ -> printfn "Nothing was parse-able!"

    // Rufen Sie den Drucker mit unterschiedlichen zu analysierenden Werten auf.
    printParseResult "12"
    printParseResult "12.045"
    printParseResult "12/28/2016"
    printParseResult "9:01PM"
    printParseResult "banana!"


/// Bei Optionswerten handelt es sich um eine beliebige Art von Werten, die entweder mit "Some" oder mit "None" markiert sind.
/// Sie werden in F#-Code umfassend verwendet, um die Fälle darzustellen, in denen viele
/// Sprachen NULL-Verweise verwenden würden.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/options
module OptionValues =

    /// Definieren Sie als Erstes eine Postleitzahl, die über eine diskriminierte Einzelfall-Union definiert ist.
    type ZipCode = ZipCode of string

    /// Definieren Sie als Nächstes einen Typ, bei dem "ZipCode" optional ist.
    type Customer = { ZipCode: ZipCode option }

    /// Definieren Sie dann einen Schnittstellentyp, der ein Objekt zum Berechnen der Versandkosten für die Postleitzahl des Kunden repräsentiert,
    /// sofern Implementierungen für die abstrakten Methoden "getState" und "getShippingZone" vorhanden sind.
    type ShippingCalculator =
        abstract GetState : ZipCode -> string option
        abstract GetShippingZone : string -> int

    /// Berechnen Sie nun mithilfe einer Rechnerinstanz die Versandkosten für einen Kunden.
    /// Dies verwendet Kombinatoren im Option-Modul für eine funktionale Pipeline zum
    /// Transformieren von Daten mit Optionen.
    let CustomerShippingZone (calculator: ShippingCalculator, customer: Customer) =
        customer.ZipCode
        |> Option.bind calculator.GetState
        |> Option.map calculator.GetShippingZone


/// Maßeinheiten sind eine Möglichkeit, um für primitive numerische Typen typsicher den Änderungsverlauf einzublenden.
/// Anschließend können Sie für diese Werte die typsichere Arithmetik ausführen.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/units-of-measure
module UnitsOfMeasure =

    /// Öffnen Sie zunächst eine Auflistung mit allgemeinen Einheitennamen.
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    /// Definieren Sie eine einheitliche Konstante.
    let sampleValue1 = 1600.0<meter>

    /// Definieren Sie als Nächstes einen neuen Einheitentyp.
    [<Measure>]
    type mile =
        /// Faktor für die Umrechnung von Meilen in Meter.
        static member asMeter = 1609.34<meter/mile>

    /// Definieren Sie eine einheitliche Konstante.
    let sampleValue2  = 500.0<mile>

    /// Berechnen Sie die Konstante für das metrische System.
    let sampleValue3 = sampleValue2 * mile.asMeter

    // Werte, die Maßeinheiten verwenden, können wie der primitive numerische Typ z.B. zum Drucken genutzt werden.
    printfn "After a %f race I would walk %f miles which would be %f meters" sampleValue1 sampleValue2 sampleValue3


/// Klassen sind eine Möglichkeit zum Definieren neuer Objekttypen in F#. Sie unterstützen standardmäßige objektorientierte Konstrukte.
/// Sie können über verschiedene Member verfügen (Methoden, Eigenschaften, Ereignisse usw.)
///
/// Weitere Informationen zu Klassen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/classes
///
/// Weitere Informationen zu Membern finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/members
module DefiningClasses =

    /// Eine einfache, zweidimensionale Vektorklasse.
    ///
    /// Der Konstruktor der Klasse befindet sich in der ersten Zeile
    /// und akzeptiert zwei Argumente: dx und dy, beide vom Typ "double".
    type Vector2D(dx : double, dy : double) =

        /// Dieses interne Feld speichert die Länge des Vektors, die berechnet wird, wenn
        /// das Objekt konstruiert wird.
        let length = sqrt (dx*dx + dy*dy)

        // "this" gibt einen Namen für den Selbstbezeichner des Objekts an.
        // In Instanzmethoden muss dies vor dem Membernamen angegeben werden.
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        /// Dieser Member ist eine Methode. Die vorherigen Member waren Eigenschaften.
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    /// So instanziieren Sie die Vector2D-Klasse.
    let vector1 = Vector2D(3.0, 4.0)

    /// Rufen Sie ein neues skaliertes Vektorobjekt ab, ohne das ursprüngliche Objekt zu verändern.
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f\nLength of vector2: %f" vector1.Length vector2.Length


/// Generische Klassen ermöglichen das Definieren von Typen in Bezug auf eine Gruppe von Typparametern.
/// Im Folgenden ist 'T der Typparameter für die Klasse.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/generics/
module DefiningGenericClasses =

    type StateTracker<'T>(initialElement: 'T) =

        /// Dieses interne Feld speichert die Zustände in einer Liste.
        let mutable states = [ initialElement ]

        /// Der Liste der Zustände ein neues Element hinzufügen
        member this.UpdateState newState =
            states <- newState :: states  // Den "<-"-Operator verwenden, um den Wert zu mutieren

        /// Die gesamte Liste der Verlaufszustände abrufen
        member this.History = states

        /// Den aktuellen Zustand abrufen
        member this.Current = states.Head

    /// Eine int-Instanz der state tracker-Klasse. Beachten Sie, dass der Typ-Parameter abgeleitet wird.
    let tracker = StateTracker 10

    // Einen Zustand hinzufügen
    tracker.UpdateState 17


/// Schnittstellen sind Objekttypen, die nur über abstrakte Member verfügen.
/// Objekttypen und Objektausdrücke können Schnittstellen implementieren.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/interfaces
module ImplementingInterfaces =

    /// Dieser Typ implementiert "IDisposable".
    type ReadFile() =

        let file = new System.IO.StreamReader("readme.txt")

        member this.ReadLine() = file.ReadLine()

        // Dies ist die Implementierung von IDisposable-Membern.
        interface System.IDisposable with
            member this.Dispose() = file.Close()


    /// Dies ist ein Objekt, das IDisposable über einen Objektausdruck implementiert.
    /// Im Gegensatz zu anderen Sprachen wie C# oder Java ist keine neue Typendefinition erforderlich,
    /// um eine Schnittstelle zu implementieren.
    let interfaceImplementation =
        { new System.IDisposable with
            member this.Dispose() = printfn "disposed" }


/// Die Bibliothek "FSharp.Core" definiert eine Reihe paralleler Verarbeitungsfunktionen. Hier
/// verwenden Sie einige Funktionen zur parallelen Verarbeitung über Arrays.
///
/// Weitere Informationen finden Sie unter: https://msdn.microsoft.com/de-de/visualfsharpdocs/conceptual/array.parallel-module-%5Bfsharp%5D
module ParallelArrayProgramming =

    /// Definieren Sie zunächst ein Array mit Eingaben.
    let oneBigArray = [| 0 .. 100000 |]

    // Definieren Sie dann eine Funktion mit CPU-intensiven Berechnungen.
    let rec computeSomeFunction x =
        if x <= 2 then 1
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)

    // Führen Sie als Nächstes eine parallele Zuordnung für ein umfangreiches Eingabearray durch.
    let computeResults() =
        oneBigArray
        |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    // Geben Sie die Ergebnisse aus.
    printfn "Parallel computation results: %A" (computeResults())



/// Ereignisse sind ein gängiger Begriff bei der .NET-Programmierung, v. a. bei WinForms oder WPF-Anwendungen.
///
/// Weitere Informationen finden Sie unter: https://docs.microsoft.com/de-de/dotnet/articles/fsharp/language-reference/members/events
module Events =

    /// Erstellen Sie zunächst eine Instanz des Event-Objekts mit Abonnementpunkt (event.Publish) und Ereignisauslöser (event.Trigger).
    let simpleEvent = new Event<int>()

    // Fügen Sie dem Ereignis einen Handler hinzu.
    simpleEvent.Publish.Add(
        fun x -> printfn "this handler was added with Publish.Add: %d" x)

    // Lösen Sie das Ereignis aus.
    simpleEvent.Trigger(5)

    // Erstellen Sie als Nächstes eine Event-Instanz gemäß der .NET-Standardkonvention: (sender, EventArgs)
    let eventForDelegateType = new Event<EventHandler, EventArgs>()

    // Fügen Sie einen Handler für das neue Ereignis hinzu.
    eventForDelegateType.Publish.AddHandler(
        EventHandler(fun _ _ -> printfn "this handler was added with Publish.AddHandler"))

    // Lösen Sie das Ereignis aus. (Hinweis: das sender-Argument muss festgelegt sein.)
    eventForDelegateType.Trigger(null, EventArgs.Empty)



#if COMPILED
module BoilerPlateForForm =
    [<System.STAThread>]
    do ()
    do System.Windows.Forms.Application.Run()
#endif
