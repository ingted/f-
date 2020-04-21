// Ten przykład zawiera opis elementów języka F#.
//
// *******************************************************************************************************
//   Aby wykonać kod w programie F# Interactive, zaznacz sekcję kodu i naciśnij kombinację klawiszy Alt-Enter lub kliknij prawym przyciskiem myszy,
//   a następnie wybierz opcję „Wykonaj w trybie interaktywnym”. Okno narzędzia F# Interactive można otworzyć z menu „Widok”.
// *******************************************************************************************************
//
// Aby uzyskać więcej informacji o języku F#, zobacz:
//     https://fsharp.org
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/
//
// Aby wyświetlić ten samouczek w formie dokumentacji, zobacz:
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/tour
//
// Aby dowiedzieć się więcej o programowaniu w języku F# w praktyce, użyj
//     https://fsharp.org/guides/enterprise/
//     https://fsharp.org/guides/cloud/
//     https://fsharp.org/guides/web/
//     https://fsharp.org/guides/data-science/
//
// Aby zainstalować narzędzia Visual F# Power Tools, użyj
//     „Narzędzia” --> „Rozszerzenia i aktualizacje” --> „Online” i wyszukaj
//
// Aby uzyskać informacje o dodatkowych szablonach do użycia w języku F#, zobacz sekcję dotyczącą szablonów w trybie online w programie Visual Studio,
//     „Nowy projekt” --> „Szablony w trybie online”

// Język F# obsługuje trzy rodzaje komentarzy:

//  1. Komentarze z podwójnym ukośnikiem. Są używane w większości sytuacji.
(*  2. Komentarze blokowe w stylu ML. Nie są używane zbyt często. *)
/// 3. Komentarze z potrójnymi ukośnikami. Są używane do dokumentowania funkcji, typów itd.
///    Będą wyświetlane jako tekst po zatrzymaniu wskaźnika myszy nad tym, do czego zostały dodane.
///
///    Obsługują także komentarze XML w stylu programu .NET, które pozwalają na generowanie dokumentacji referencyjnej,
///    a także umożliwiają edytorom (takim jak program Visual Studio) na wydobywanie z nich informacji.
///    Aby dowiedzieć się więcej, zobacz: https://docs.microsoft.com/pl-pl/dotnet/articles/fsharp/language-reference/xml-documentation


// Otwieraj przestrzenie nazw, używając słowa kluczowego „open”.
//
// Aby dowiedzieć się więcej, zobacz: https://docs.microsoft.com/pl-pl/dotnet/articles/fsharp/language-reference/import-declarations-the-open-keyword
open System


/// Moduł to zbiór kodu w języku F#, takiego jak wartości, typy i wartości funkcji.
/// Grupowanie kodu w modułach pomaga trzymać razem powiązany kod i unikać konfliktów nazw w programie.
///
/// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/pl-pl/dotnet/articles/fsharp/language-reference/modules
module IntegersAndNumbers =

    /// To jest przykładowa liczba całkowita.
    let sampleInteger = 176

    /// To jest przykładowa liczba zmiennoprzecinkowa.
    let sampleDouble = 4.1

    /// To obliczyło nową liczbę, wykonując pewne operacje arytmetyczne. Typy liczbowe są konwertowane za pomocą
    /// funkcji „int”, „double” itd.
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    /// To jest lista liczb od 0 do 99.
    let sampleNumbers = [ 0 .. 99 ]

    /// To jest lista wszystkich krotek zawierających wszystkie liczby od 0 do 99 i ich kwadraty.
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // Następny wiersz wyświetla listę z krotkami, używając symbolu „%A” do wyświetlania ogólnego.
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfSquares

    // To jest przykładowa liczba całkowita z adnotacją typu
    let sampleInteger3: int = 1


/// Wartości w języku F# są domyślnie niezmienialne. Nie można ich modyfikować
/// w trakcie wykonywania programu, chyba że zostaną jawnie oznaczone jako zmienialne.
///
/// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/values/index#why-immutable
module Immutability =

    /// Powiązanie wartości z nazwą za pomocą polecenia „let” sprawia, że będzie ona niezmienna.
    ///
    /// Nie można skompilować drugiego wiersza kodu, ponieważ element „number” jest niezmienny i powiązany.
    /// Ponowne definiowanie elementu „number” na inną wartość nie jest dozwolone w języku F#.
    let number = 2
    // let number = 3

    /// Modyfikowalne powiązanie. Jest to wymagane w celu modyfikowania wartości elementu „otherNumber”.
    let mutable otherNumber = 2

    printfn "'otherNumber' is %d" otherNumber

    // Podczas modyfikowania wartości użyj strzałki „<-”, aby przydzielić nową wartość.
    //
    // Nie możesz w tym celu użyć tutaj znaku „=”, ponieważ jest on używany do oznaczania równości
    // lub innych kontekstów, np. „let” lub „module”
    otherNumber <- otherNumber + 1

    printfn "'otherNumber' changed to be %d" otherNumber


/// Duża część programowania w języku F# to definiowanie funkcji, które przekształcają dane wejściowe w celu utworzenia
/// przydatne wyniki.
///
/// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/
module BasicFunctions =

    /// Polecenia „let” używa się do definiowania funkcji. To polecenie akceptuje argument w postaci liczby całkowitej i zwraca liczbę całkowitą.
    /// Nawiasy są opcjonalne w przypadku argumentów funkcji, z wyjątkiem użycia jawnego typu adnotacji.
    let sampleFunction1 x = x*x + 3

    /// Zastosuj funkcję i nadaj jej wynikowi zwrotnemu nazwę, używając instrukcji „let”.
    /// Typ zmiennej jest wywnioskowany na podstawie zwracanego typu funkcji.
    let result1 = sampleFunction1 4573

    // Ten wiersz używa elementu „%d”, aby wydrukować wynik jako liczbę całkowitą. Jest to bezpieczne.
    // Jeśli element „result1” nie miałby typu „int”, kompilacja wiersza zakończyłaby się niepowodzeniem.
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    /// W razie potrzeby adnotuj typ nazwy parametru przy użyciu polecenia „(argument:typ)”. Nawiasy są wymagane.
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn "The result of applying the 2nd sample function to (7 + 4) is %d" result2

    /// Wyrażenia warunkowe używają słów kluczowych if/then/elid/elif/else.
    ///
    /// Należy zauważyć, że język F# używa składni uwzględniającej wcięcia w postaci odstępów, tak jak w przypadku języków podobnych do języka Python.
    let sampleFunction3 x =
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)

    // Ten wiersz używa elementu „%f”, aby wydrukować wynik jako liczbę zmiennoprzecinkową. Podobnie jak w przypadku elementu „%d” powyżej jest to bezpieczne.
    printfn "The result of applying the 3rd sample function to (6.5 + 4.5) is %f" result3


/// Wartości logiczne są fundamentalnymi typami danych w języku F#. Oto kilka przykładów wartości logicznych i logiki warunkowej.
///
/// Aby dowiedzieć się więcej, zobacz:
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/primitive-types
///     oraz
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/symbol-and-operator-reference/boolean-operators
module Booleans =

    /// Wartości logiczne przyjmują wartość „true” i „false”.
    let boolean1 = true
    let boolean2 = false

    /// Operatory wartości logicznych to „not”, „&&” i „||”.
    let boolean3 = not boolean1 && (boolean2 || false)

    // Ten wiersz używa elementu „%b”, aby wydrukować wartość logiczną. Jest to bezpieczne.
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %b" boolean3


/// Ciągi są fundamentalnymi typami danych w języku F#. Oto kilka przykładów ciągów i podstawowych manipulacji ciągami.
///
/// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/strings
module StringManipulation =

    /// Ciągi używają cudzysłowów.
    let string1 = "Hello"
    let string2  = "world"

    /// W ciągach można także używać znaku @ do tworzenia dosłownych literałów ciągu.
    /// Spowoduje to ignorowanie znaków ucieczki, np. „\”, „\n”, „\t” itp.
    let string3 = @"C:\Program Files\"

    /// Literały ciągu mogą także używać potrójnych cudzysłowów.
    let string4 = """The computer said "hello world" when I told it to!"""

    /// Łączenie ciągów wykonuje się zazwyczaj przy użyciu operatora „+”.
    let helloWorld = string1 + " " + string2

    // Ten wiersz używa elementu „%s”, aby wydrukować wartość ciągu. Jest to bezpieczne.
    printfn "%s" helloWorld

    /// Podciągi używają notacji indeksatora. Ten wiersz wyodrębnia pierwsze 7 znaków w formie podciągu.
    /// Należy zauważyć, że w języku F# ciągi znaków są indeksowane od zera, podobnie jak w wielu innych językach.
    let substring = helloWorld.[0..6]
    printfn "%s" substring


/// Krotki to proste kombinacje wartości danych tworzące połączoną wartość.
///
/// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/tuples
module Tuples =

    /// Prosta krotka liczb całkowitych.
    let tuple1 = (1, 2, 3)

    /// Funkcja zamieniająca kolejność dwóch wartości w krotce.
    ///
    /// Wnioskowanie o typie języka F# będzie automatycznie uogólniać funkcję do typu ogólnego,
    /// co oznacza, że będzie działać z dowolnym typem.
    let swapElems (a, b) = (b, a)

    printfn "The result of swapping (1, 2) is %A" (swapElems (1,2))

    /// Krotka składająca się z liczby całkowitej, ciągu
    /// i liczby zmiennoprzecinkowej podwójnej precyzji.
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A\ttuple2: %A" tuple1 tuple2

    /// Prosta krotka składająca się z liczb całkowitych z adnotacją typu.
    /// Adnotacje typu w krotkach korzystają z symbolu * do oddzielania elementów
    let tuple3: int * int = (5, 9)

    /// Krotki są zazwyczaj obiektami, niemniej mogą być również reprezentowane w formie struktur.
    ///
    /// Całkowicie współpracują ze strukturami w języku C# i Visual Basic.NET; niemniej
    /// krotki w formie struktur nie mogą być niejawnie konwertowane na krotki w formie obiektów (często zwane krotkami odwołań).
    ///
    /// Z tego powodu nie będzie można skompilować drugiego wiersza poniżej. Usuń komentarz z tego wiersza, aby zobaczyć, co się stanie.
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // Mimo że nie możesz przeprowadzać niejawnej konwersji między krotkami struktury i krotkami odwołania,
    // możesz konwertować jawnie za pośrednictwem dopasowywania do wzorców, jak pokazano poniżej.
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)

    printfn "Struct Tuple: %A\nReference tuple made from the Struct Tuple: %A" sampleStructTuple (sampleStructTuple |> convertFromStructTuple)


/// Operatory potoków języka F# („|>”, „<|” itp.) oraz operatory kompozycji języka F# („>>”, „<<”)
/// są często używane podczas przetwarzania danych. Operatory te są funkcjami
/// wykorzystującymi częściową aplikację.
///
/// Aby dowiedzieć się więcej o tych operatorach, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/#function-composition-and-pipelining
/// Aby dowiedzieć się więcej o częściowej aplikacji, zobacz: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/#partial-application-of-arguments
module PipelinesAndComposition =

    /// Podnosi wartość do potęgi drugiej.
    let square x = x * x

    /// Dodaje 1 do wartości.
    let addOne x = x + 1

    /// Sprawdza, czy wartość liczby całkowitej jest nieparzysta za pomocą operacji modulo.
    let isOdd x = x % 2 <> 0

    /// Lista 5 liczb. Więcej informacji na temat list znajduje się dalej.
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// W oparciu o podaną listę liczb całkowitych funkcja filtruje liczby parzyste,
    /// podnosi nieparzyste wyniki do potęgi drugiej, a następnie dodaje 1 do podniesionych do potęgi drugiej liczb nieparzystych.
    let squareOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" numbers (squareOddValuesAndAddOne numbers)

    /// Krótszym sposobem zapisu „squareOddValuesAndAddOne” jest zagnieżdżenie każdego
    /// wyniku podrzędnego w samych wywołaniach funkcji.
    ///
    /// Dzięki temu funkcja będzie znacznie krótsza, ale trudno będzie zobaczyć
    /// kolejność przetwarzania danych.
    let squareOddValuesAndAddOneNested values =
        List.map addOne (List.map square (List.filter isOdd values))

    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers (squareOddValuesAndAddOneNested numbers)

    /// Preferowanym sposobem zapisu funkcji „squareOddValuesAndAddOne” jest użycie operatorów potoków języka F#.
    /// Dzięki temu unika się tworzenia wyników pośrednich, a całość jest znacznie bardziej czytelna
    /// niż w przypadku zagnieżdżania wywołań funkcji, np. „squareOddValuesAndAddOneNested”
    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    printfn "processing %A through 'squareOddValuesAndAddOnePipeline' produces: %A" numbers (squareOddValuesAndAddOnePipeline numbers)

    /// Możesz skrócić wywołanie „squareOddValuesAndAddOnePipeline” przez przeniesienie drugiego wywołania „List.map”
    /// do pierwszego, korzystając z funkcji lambda.
    ///
    /// Należy zauważyć, że potoki są również używane w funkcji lambda. Operatorów potoków języka F#
    /// można również użyć w przypadku pojedynczych wartości. Dzięki temu jest to bardzo zaawansowane narzędzie do przetwarzania danych.
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" numbers (squareOddValuesAndAddOneShorterPipeline numbers)

    /// W końcu możesz wyeliminować potrzebę jawnego przyjmowania elementu „values” jako parametru, używając wyrażenia „>>”,
    /// aby zredagować dwie kluczowe operacje: odfiltrowywanie liczb parzystych, a następnie podnoszenie do potęgi drugiej i dodawanie jedynki.
    /// Podobnie fragment „fun x -> ...” wyrażenia lambda nie jest wymagany, ponieważ wartość „x” jest po prostu
    /// definiowana w tym zakresie w celu przekazania do potoku funkcyjnego. Dlatego można również użyć wyrażenia „>>”
    /// w tym miejscu.
    ///
    /// Wynikiem funkcji „squareOddValuesAndAddOneComposition” jest inna funkcja, która przyjmuje
    /// listę liczb całkowitych w formie danych wejściowych. Jeśli wykonasz funkcję „squareOddValuesAndAddOneComposition” z listą
    /// liczb całkowitych, funkcja będzie podawać takie same wyniki jak poprzednie funkcje.
    ///
    /// Używa się tu kompozycji funkcji. Jest to możliwe, ponieważ funkcje w języku F#
    /// używają częściowej aplikacji, a typy danych wejściowych i wyjściowych dla każdej operacji przetwarzania danych są dopasowane do
    /// podpisów funkcji, których używamy.
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneComposition' produces: %A" numbers (squareOddValuesAndAddOneComposition numbers)


/// Listy są uporządkowane, niezmienne i jednokierunkowe. Są wartościowane przed przetworzeniem.
///
/// Ten moduł pokazuje różne sposoby generowania list i ich przetwarzania przy użyciu niektórych funkcji
/// w module „Lista” w bibliotece podstawowej języka F#.
///
/// Aby dowiedzieć się więcej, zobacz: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/lists
module Lists =

    /// Listy definiuje się za pomocą zapisu [ ... ]. To jest pusta lista.
    let list1 = [ ]

    /// Jest to lista z 3 elementami. Znak „;” oddziela elementy w tym samym wierszu.
    let list2 = [ 1; 2; 3 ]

    /// Możesz również oddzielić elementy przez umieszczenie ich w osobnych wierszach.
    let list3 = [
        1
        2
        3
    ]

    /// To jest lista liczb całkowitych z zakresu od 1 do 1000
    let numberList = [ 1 .. 1000 ]

    /// Listy można także generować za pomocą obliczeń. To jest lista zawierająca
    /// wszystkie dni roku.
    let daysList =
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                  yield System.DateTime(2017, month, day) ]

    // Wydrukuj 5 pierwszych elementów listy „daysList” przy użyciu wyrażenia „List.take”.
    printfn "The first 5 days of 2017 are: %A" (daysList |> List.take 5)

    /// Obliczenia mogą obejmować wyrażenia warunkowe. To jest lista zawierająca krotki
    /// które są współrzędnymi czarnych kwadratów na szachownicy.
    let blackSquares =
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do
                  if (i+j) % 2 = 1 then
                      yield (i, j) ]

    /// Listy można przekształcać za pomocą elementu „List.map” i innych kombinatorów programowania funkcjonalnego.
    /// Ta definicja umożliwia utworzenie nowej listy przez podniesienie do kwadratu elementów na liście numberList za pomocą potoku
    /// operatora, aby przekazać argument do elementu List.map.
    let squares =
        numberList
        |> List.map (fun x -> x*x)

    /// Istnieje wiele innych kombinacji listy. Następujący kod oblicza sumę kwadratów
    /// liczby podzielne przez 3.
    let sumOfSquares =
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)

    printfn "The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d" sumOfSquares


/// Tablice to zmienialne kolekcje o stałym rozmiarze, w których zawierają się elementy tego samego typu.
///
/// Chociaż są podobne do list (obsługują wyliczenia i mają podobne kombinatory przetwarzania danych),
/// ogólnie są szybsze i obsługują szybki dostęp losowy. Niemniej oznacza to mniejsze bezpieczeństwo związane z możliwością ich modyfikacji.
///
/// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/arrays
module Arrays =

    /// To jest pusta tablica. Należy zauważyć, że składnia jest podobna do składni list, ale tutaj używa się zapisu „[| ... |]”.
    let array1 = [| |]

    /// Tablice określa się za pomocą tego samego zestawu konstrukcji co listy.
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// To jest tablica liczb z zakresu od 1 do 1000.
    let array3 = [| 1 .. 1000 |]

    /// To jest tablica zawierająca tylko słowa „hello” i „world”.
    let array4 =
        [| for word in array2 do
               if word.Contains("l") then
                   yield word |]

    /// To jest tablica zainicjowana za pomocą indeksu i zawierająca liczby parzyste z zakresu od 0 do 2000.
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// Tablice podrzędne wyodrębnia się za pomocą notacji wycinania.
    let evenNumbersSlice = evenNumbers.[0..500]

    /// Możesz zapętlić tablice i listy przy użyciu pętli „for”.
    for word in array4 do
        printfn "word: %s" word

    // Możesz zmodyfikować zawartość elementu tablicy za pomocą operatora przypisania „strzałka w lewo”.
    //
    // Aby dowiedzieć się więcej o tym operatorze, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/values/index#mutable-variables
    array2.[1] <- "WORLD!"

    /// Możesz przekształcić tablice za pomocą operacji „Array.map” i innych operacji programowania funkcjonalnego.
    /// Następujący kod oblicza sumę długości słów zaczynających się od litery „h”.
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn "The sum of the lengths of the words in Array 2 is: %d" sumOfLengthsOfWords


/// Sekwencje są logicznymi seriami elementów tego samego typu. Jest to typ bardziej ogólny niż listy i tablice.
///
/// Sekwencje są sprawdzane na żądanie, a ich ponowne sprawdzenie następuje za każdym razem, gdy są one iterowane.
/// Sekwencja języka F# jest aliasem dla elementu .NET System.Collections.Generic.IEnumerable<'T>.
///
/// Funkcje przetwarzania sekwencji można także zastosować dla list i tablic.
///
/// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/sequences
module Sequences =

    /// To jest pusta sekwencja.
    let seq1 = Seq.empty

    /// To jest sekwencja wartości.
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    /// To jest sekwencja na żądanie zawierająca liczby od 1 do 1000.
    let numbersSeq = seq { 1 .. 1000 }

    /// To jest sekwencja generująca słowa „hello” i „world”
    let seq3 =
        seq { for word in seq2 do
                  if word.Contains("l") then
                      yield word }

    /// Ta sekwencja generuje numery parzyste nie większe niż 2000.
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    /// To jest nieskończona sekwencja stanowiąca losowe przechodzenie.
    /// W tym przykładzie użyto instrukcji yield! do zwrócenia każdego elementu sekwencji podrzędnej.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// Ten przykład przedstawia pierwszych 100 elementów losowego przechodzenia.
    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList

    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk


/// Funkcje rekursywne mogą wywoływać same siebie. W języku F# funkcje to jedyne rekursywne
/// w przypadku deklarowania przy użyciu wyrażenia „let rec”.
///
/// Rekursja jest preferowanym sposobem przetwarzania sekwencji lub kolekcji w języku F#.
///
/// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/index#recursive-functions
module RecursiveFunctions =

    /// Ten przykład przedstawia funkcję rekursywną, która oblicza silnię
    /// liczba całkowita. Używa deklaratora „let rec” do zdefiniowania funkcji rekursywnej.
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n-1)

    printfn "Factorial of 6 is: %d" (factorial 6)

    /// Oblicza największy wspólny dzielnik dwóch liczb całkowitych.
    ///
    /// Jako że wszystkie wywołania rekurencyjne są wywołaniami ogonowymi,
    /// kompilator zamieni funkcję w pętlę,
    /// która umożliwi zwiększenie wydajności i zmniejszenie zużycia pamięci.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn "The Greatest Common Factor of 300 and 620 is %d" (greatestCommonFactor 300 620)

    /// Ten przykład oblicza sumę listy liczb całkowitych przy użyciu rekursji.
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    /// Operacja zamieni listę „sumList” w listę z rekursją ogonową przy użyciu funkcji pomocniczej z akumulatorem wyników.
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    /// Spowoduje to wywołanie funkcji pomocniczej z rekursją ogonową, z wartością „0” jako akumulatorem początkowym.
    /// Takie podejście jest typowe dla języka F#.
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn "The sum 1-10 is %d" (sumListTailRecursive oneThroughTen)


/// Rekordy są agregacjami nazwanych wartości z opcjonalnymi elementami członkowskimi (np. metodami).
/// Są niezmienne i mają semantykę równości strukturalnej.
///
/// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/records
module RecordTypes =

    /// Ten przykład przedstawia sposób definiowania nowego typu rekordu.
    type ContactCard =
        { Name     : string
          Phone    : string
          Verified : bool }

    /// W tym przykładzie pokazano sposób tworzenia wystąpienia typu rekordu.
    let contact1 =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false }

    /// Możesz to również zrobić w tym samym wierszu, korzystając z separatorów „;”.
    let contactOnSameLine = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

    /// Ten przykład przedstawia sposób użycia operacji „kopiuj i aktualizuj” na wartościach rekordu. Tworzy
    /// nową wartość rekordu, która jest kopią elementu contact1, lecz ma inne wartości dla
    /// pola „Phone” i „Verified”.
    ///
    /// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/copy-and-update-record-expressions
    let contact2 =
        { contact1 with
            Phone = "(206) 555-0112"
            Verified = true }

    /// Ten przykład przedstawia, jak napisać funkcję przetwarzającą wartość rekordu.
    /// Konwertuje obiekt „ContactCard” na ciąg.
    let showContactCard (c: ContactCard) =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn "Alf's Contact Card: %s" (showContactCard contact1)

    /// Jest to przykład rekordu z elementem członkowskim.
    type ContactCardAlternate =
        { Name     : string
          Phone    : string
          Address  : string
          Verified : bool }

        /// Elementy członkowskie mogą implementować elementy członkowskie zorientowane obiektowo.
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified)" else "") + this.Address

    let contactAlternate =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false
          Address = "111 Alf Street" }

    // Do elementów członkowskich uzyskuje się dostęp za pośrednictwem operatora „.” w typie skonkretyzowanym.
    printfn "Alf's alternate contact card is %s" contactAlternate.PrintedContactCard

    /// Rekordy można również reprezentować jako struktury za pośrednictwem atrybutu „Struct”.
    /// Jest to przydatne w sytuacjach, w których wydajność struktur przewyższa
    /// elastyczność typów odwołań.
    [<Struct>]
    type ContactCardStruct =
        { Name     : string
          Phone    : string
          Verified : bool }


/// Unie rozłączne (DU, Discriminated Union) są wartościami, które mogą być liczbą nazwanych formularzy lub przypadków.
/// Dane przechowywane w uniach rozłącznych mogą mieć jedną z kilku różnych wartości.
///
/// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/discriminated-unions
module DiscriminatedUnions =

    /// Następująca wartość reprezentuje kolor karty do gry.
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    /// Unii rozłącznej można również użyć do reprezentowania wartości karty do gry.
    type Rank =
        /// Reprezentuje wartości kart 2 .. 10
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        /// Unie rozłączne mogą również implementować elementy członkowskie zorientowane obiektowo.
        static member GetAllRanks() =
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]

    /// To jest typ rekordu łączący kolor i wysokość.
    /// Często używa się rekordów i unii rozłącznych w przypadku reprezentowania danych.
    type Card = { Suit: Suit; Rank: Rank }

    /// Operacja oblicza listę reprezentującą wszystkie karty w talii.
    let fullDeck =
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do
                  yield { Suit=suit; Rank=rank } ]

    /// Ten przykład umożliwia przekonwertowanie elementu „Card” na ciąg.
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

    /// Ten przykład umożliwia wyświetlenie wszystkich kart w talii.
    let printAllCards() =
        for card in fullDeck do
            printfn "%s" (showPlayingCard card)

    // Unie rozłączne o pojedynczych przypadkach są często używane podczas modelowania domeny. Może to zapewnić większe bezpieczeństwo typów
    // niż typy pierwotne, np. ciągi i liczby całkowite.
    //
    // Unie rozłączne o pojedynczych przypadkach nie mogą być niejawnie konwertowane do lub z typu przez nich opakowywanego.
    // Przykładowo funkcja przyjmująca adres nie może zaakceptować ciągu jako danych wejściowych
    // i na odwrót.
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    // Możesz z łatwością utworzyć wystąpienie dla unii rozłącznej o pojedynczym przypadku w następujący sposób.
    let address = Address "111 Alf Way"
    let name = Name "Alf"
    let ssn = SSN 1234567890

    /// Jeśli potrzebujesz wartości, możesz cofnąć opakowywanie wartości bazowej za pomocą prostej funkcji.
    let unwrapAddress (Address a) = a
    let unwrapName (Name n) = n
    let unwrapSSN (SSN s) = s

    // Drukowanie unii rozłącznych o pojedynczych przypadkach jest proste z funkcjami cofającymi opakowywanie.
    printfn "Address: %s, Name: %s, and SSN: %d" (address |> unwrapAddress) (name |> unwrapName) (ssn |> unwrapSSN)

    /// Unie rozłączne obsługują również definicje rekursywne.
    ///
    /// Reprezentuje to binarne drzewo wyszukiwania, gdzie jeden przypadek jest pustym drzewem,
    /// a drugi węzłem z wartością i dwoma poddrzewami.
    type BST<'T> =
        | Empty
        | Node of value:'T * left: BST<'T> * right: BST<'T>

    /// Sprawdź, czy element istnieje w binarnym drzewie wyszukiwania.
    /// Wyszukuje rekursywnie przy użyciu dopasowywania wzorca. Zwraca wartość true, jeśli element istnieje; w przeciwnym wypadku zwraca wartość false.
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left) // Sprawdź lewe poddrzewo.
            else (exists item right) // Sprawdź prawe poddrzewo.

    /// Wstawia element do binarnego drzewa wyszukiwania.
    /// Znajduje miejsce do wstawienia rekursywnego przy użyciu dopasowania wzorca, a następnie wstawia nowy węzeł.
    /// Jeśli element jest już obecny, nie wstawia niczego.
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node // Wstawianie nie jest konieczne, element już istnieje; zwróć węzeł.
            elif item < x then Node(x, insert item left, right) // Wywołanie do lewego poddrzewa.
            else Node(x, left, insert item right) // Wywołanie do prawego poddrzewa.

    /// Unie rozłączne mogą być również reprezentowane w formie struktur za pośrednictwem atrybutu „Struct”.
    /// Jest to przydatne w sytuacjach, w których wydajność struktur przewyższa
    /// elastyczność typów odwołań.
    ///
    /// Niemniej w przypadku tej operacji należy pamiętać o dwóch ważnych rzeczach:
    ///     1. Unii rozłącznej w formie struktury nie można zdefiniować rekursywnie.
    ///     2. Unia rozłączna w formie struktury musi mieć unikatowe nazwy dla każdego ze swoich przypadków.
    [<Struct>]
    type Shape =
        | Circle of radius: float
        | Square of side: float
        | Triangle of height: float * width: float


/// Dopasowywanie wzorca jest funkcją języka F# umożliwiającą wykorzystywanie wzorców,
/// które są sposobem na porównywanie danych ze strukturami logicznymi lub strukturami,
/// rozkładanie danych na części składowe lub wyodrębnianie informacji z danych na różne sposoby.
/// Następnie możesz wysłać „kształt” wzorca za pośrednictwem funkcji dopasowywania wzorca.
///
/// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/pattern-matching
module PatternMatching =

    /// Rekord zawierający imię i nazwisko osoby
    type Person = {
        First : string
        Last  : string
    }

    /// Unia rozłączna 3 różnych rodzajów pracowników
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// Licz wszystkich podlegających pracownikowi w hierarchii zarządzania,
    /// z uwzględnieniem pracownika.
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(id) ->
                0
            | Manager(id, reports) ->
                reports |> List.sumBy countReports
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    /// Znajdź wszystkich kierowników/dyrektorów o imieniu „Dave”, którzy nie mają żadnych podwładnych.
    /// Operacja używa skrótu słowa „function” jako wyrażenia lambda.
    let rec findDaveWithOpenPosition(emps : List<Employee>) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true // [] dopasuje pustą listę.
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false) // „_” to wzorzec wieloznaczny, który pasuje do wszystkiego.
                                     // Obsługuje przypadek „w przeciwnym razie”.

    /// Możesz również użyć konstrukcji funkcji skrótu w przypadku dopasowywania wzorców,
    /// co jest przydatne podczas pisania funkcji wykorzystujących częściową aplikację.
    let private parseHelper f = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDateTimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    // Zdefiniuj więcej funkcji, które będą analizować przy użyciu funkcji pomocniczej.
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

    // Wzorce aktywne to kolejna zaawansowana konstrukcja do zastosowania podczas dopasowywania wzorców.
    // Umożliwiają one partycjonowanie danych wejściowych do formularzy niestandardowych przez ich rozkładanie w lokacji wywołania dopasowania wzorca.
    //
    // Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/active-patterns
    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    /// Dopasowywanie wzorców za pośrednictwem słowa kluczowego „function” i wzorców aktywnych często wygląda w następujący sposób.
    let printParseResult = function
        | Int x -> printfn "%d" x
        | Double x -> printfn "%f" x
        | Date d -> printfn "%s" (d.ToString())
        | TimeSpan t -> printfn "%s" (t.ToString())
        | _ -> printfn "Nothing was parse-able!"

    // Wywołaj drukarkę za pomocą innych wartości do przeanalizowania.
    printParseResult "12"
    printParseResult "12.045"
    printParseResult "12/28/2016"
    printParseResult "9:01PM"
    printParseResult "banana!"


/// Wartości opcji to dowolne wartości otagowane jako „Some” lub „None”.
/// Są one bardzo często używane w kodzie języka F# do reprezentowania przypadków, w których w wielu innych
/// językach użyte zostałyby odwołania o wartości null.
///
/// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/options
module OptionValues =

    /// Najpierw zdefiniuj kod pocztowy zdefiniowany za pośrednictwem unii rozłącznej o pojedynczym przypadku.
    type ZipCode = ZipCode of string

    /// Następnie zdefiniuj typ, w którym element ZipCode jest opcjonalny.
    type Customer = { ZipCode: ZipCode option }

    /// Następnie zdefiniuj typ interfejsu reprezentujący obiekt, aby obliczyć strefę wysyłki dla kodu pocztowego klienta
    /// przy użyciu danych implementacji metod abstrakcyjnych „getState” i „getShippingZone”.
    type ShippingCalculator =
        abstract GetState : ZipCode -> string option
        abstract GetShippingZone : string -> int

    /// Następnie oblicz strefę wysyłki dla klienta za pomocą wystąpienia kalkulatora.
    /// Operacja używa kombinatorów w module opcji, aby umożliwiać potokowi funkcjonalnemu
    /// przekształcanie danych z wykorzystaniem elementów opcjonalnych.
    let CustomerShippingZone (calculator: ShippingCalculator, customer: Customer) =
        customer.ZipCode
        |> Option.bind calculator.GetState
        |> Option.map calculator.GetShippingZone


/// Jednostki miary są bezpiecznym sposobem dodawania adnotacji do pierwotnych typów numerycznych.
/// Następnie możesz przeprowadzić bezpieczne operacje arytmetyczne dla tych wartości.
///
/// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/units-of-measure
module UnitsOfMeasure =

    /// Najpierw otwórz kolekcję typowych nazw jednostek
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    /// Definiuj stałą w jednostkach
    let sampleValue1 = 1600.0<meter>

    /// Następnie zdefiniuj nowy typ jednostki
    [<Measure>]
    type mile =
        /// Współczynnik konwersji mil na metry.
        static member asMeter = 1609.34<meter/mile>

    /// Definiuj stałą w jednostkach
    let sampleValue2  = 500.0<mile>

    /// Oblicz stałą systemu metryk
    let sampleValue3 = sampleValue2 * mile.asMeter

    // Wartości używające jednostek miary można dostosować tak jak pierwotny typ numeryczny, np. w przypadku drukowania.
    printfn "After a %f race I would walk %f miles which would be %f meters" sampleValue1 sampleValue2 sampleValue3


/// Klasy są sposobem definiowania nowych typów obiektów w języku F# i obsługują standardowe konstrukcje zorientowane obiektowo.
/// Mogą mieć różne elementy członkowskie (metody, właściwości, zdarzenia itp.)
///
/// Aby dowiedzieć się więcej o klasach, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/classes
///
/// Aby dowiedzieć się więcej o elementach członkowskich, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/members
module DefiningClasses =

    /// Prosta, dwuwymiarowa klasa Vector.
    ///
    /// Konstruktor klasy znajduje się w pierwszym wierszu
    /// i przyjmuje dwa argumenty: dx i dy, oba typu „double”.
    type Vector2D(dx : double, dy : double) =

        /// To pole wewnętrzne przechowuje długość wektora obliczoną podczas
        /// obiekt jest skonstruowany
        let length = sqrt (dx*dx + dy*dy)

        // Wyraz „this” określa nazwę własnego identyfikatora obiektu.
        // W metodach wystąpień musi on znajdować się przed nazwą elementu członkowskiego.
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        /// Ten element członkowski jest metodą. Poprzednie elementy członkowskie były właściwościami.
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    /// Jest to sposób tworzenia wystąpienia dla klasy Vector2D.
    let vector1 = Vector2D(3.0, 4.0)

    /// Pobierz nowy skalowany obiekt wektora bez modyfikowania obiektu oryginalnego.
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f\nLength of vector2: %f" vector1.Length vector2.Length


/// Klasy ogólne umożliwiają definiowanie typów z uwzględnieniem zestawu parametrów typu.
/// W następującym przykładzie 'T jest parametrem typu dla klasy.
///
/// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/generics/
module DefiningGenericClasses =

    type StateTracker<'T>(initialElement: 'T) =

        /// To wewnętrzne pole przechowuje stany na liście.
        let mutable states = [ initialElement ]

        /// Dodaj nowy element do listy stanów.
        member this.UpdateState newState =
            states <- newState :: states  // użyj operatora „<-”, aby zmodyfikować wartość.

        /// Pobierz całą listę stanów historycznych.
        member this.History = states

        /// Pobierz najnowszy stan.
        member this.Current = states.Head

    /// Wystąpienie typu „int” klasy procedury śledzenia stanu. Należy zwrócić uwagę, że parametr typu jest wywnioskowany.
    let tracker = StateTracker 10

    // Dodaj stan
    tracker.UpdateState 17


/// Interfejsy to typy obiektu, których wszystkie elementy członkowskie są abstrakcyjne.
/// Typy obiektu i wyrażenia obiektu mogą implementować interfejsy.
///
/// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/interfaces
module ImplementingInterfaces =

    /// To jest typ implementujący interfejs IDisposable.
    type ReadFile() =

        let file = new System.IO.StreamReader("readme.txt")

        member this.ReadLine() = file.ReadLine()

        // To jest implementacja elementów członkowskich interfejsu IDisposable.
        interface System.IDisposable with
            member this.Dispose() = file.Close()


    /// To jest obiekt implementujący interfejs IDisposable za pośrednictwem wyrażenia obiektu
    /// W przeciwieństwie do innych języków, np. C# lub Java, nowy typ definicji nie jest wymagany
    /// do zaimplementowania interfejsu.
    let interfaceImplementation =
        { new System.IDisposable with
            member this.Dispose() = printfn "disposed" }


/// Biblioteka FSharp.Core definiuje zestaw funkcji przetwarzania równoległego. Tutaj
/// niektóre funkcje są używane do równoległego przetwarzania tablic.
///
/// Aby dowiedzieć się więcej, zobacz https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/array.parallel-module-%5Bfsharp%5D
module ParallelArrayProgramming =

    /// Najpierw tablica wartości wejściowych.
    let oneBigArray = [| 0 .. 100000 |]

    // Następnie zdefiniuj funkcje, które wykonują obliczenia intensywnie korzystające z procesora.
    let rec computeSomeFunction x =
        if x <= 2 then 1
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)

    // Następnie wykonaj równoległe mapowanie dla dużej tablicy wejściowej.
    let computeResults() =
        oneBigArray
        |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    // Następnie wyświetl wyniki.
    printfn "Parallel computation results: %A" (computeResults())



/// Zdarzenia są wspólnym idiomem dla programowania na platformie .NET, zwłaszcza przy użyciu aplikacji WinForms lub WPF.
///
/// Aby dowiedzieć się więcej, zobacz https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/members/events
module Events =

    /// Najpierw utwórz wystąpienie obiektu Event, które składa się z punktu subskrypcji (event.Publish) i wyzwalacza zdarzenia (event.Trigger).
    let simpleEvent = new Event<int>()

    // Następnie dodaj procedurę obsługi do zdarzenia.
    simpleEvent.Publish.Add(
        fun x -> printfn "this handler was added with Publish.Add: %d" x)

    // Następnie wyzwól zdarzenie.
    simpleEvent.Trigger(5)

    // Następnie utwórz wystąpienie zdarzenia zgodne ze standardową konwencją platformy .NET: (sender, EventArgs).
    let eventForDelegateType = new Event<EventHandler, EventArgs>()

    // Następnie dodaj procedurę obsługi dla tego nowego zdarzenia.
    eventForDelegateType.Publish.AddHandler(
        EventHandler(fun _ _ -> printfn "this handler was added with Publish.AddHandler"))

    // Następnie wyzwól to zdarzenie (zwróć uwagę, że argument elementu wysyłającego powinien być ustawiony).
    eventForDelegateType.Trigger(null, EventArgs.Empty)



#if COMPILED
module BoilerPlateForForm =
    [<System.STAThread>]
    do ()
    do System.Windows.Forms.Application.Run()
#endif
