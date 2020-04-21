// Questo esempio consente all'utente di familiarizzare con gli elementi del linguaggio F#.
//
// *******************************************************************************************************
//   Per eseguire il codice in F# Interactive, evidenziare una sezione di codice e premere ALT-INVIO oppure fare clic con il pulsante destro del mouse
//   e selezionare "Esegui in Interactive".  È possibile aprire la finestra di F# Interactive dal menu "Visualizza".
// *******************************************************************************************************
//
// Per altre informazioni su F#, vedere:
//     https://fsharp.org
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/
//
// Per visualizzare questa esercitazione sotto forma di documentazione, vedere:
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/tour
//
// Per altre informazioni sulla programmazione F# applicata, usare
//     https://fsharp.org/guides/enterprise/
//     https://fsharp.org/guides/cloud/
//     https://fsharp.org/guides/web/
//     https://fsharp.org/guides/data-science/
//
// Per installare Visual F# Power Tools, usare
//     'Strumenti' --> 'Estensioni e aggiornamenti' --> `Online` e cercare
//
// Per altri modelli da usare con F#, vedere 'Modelli online' in Visual Studio,
//     'Nuovo progetto' --> 'Modelli online'

// In F# sono supportati tre tipi di commenti:

//  1. Commenti introdotti da una doppia barra. Vengono usati nella maggior parte delle situazioni.
(*  2. Commenti per il blocco in stile ML. Non vengono usati molto spesso. *)
/// 3. Commenti introdotti da una tripla barra. Vengono usati per la documentazione di funzioni, tipi e così via.
///    Verranno visualizzati come testo quando si passa con il puntatore su un elemento decorato con questi commenti.
///
///    Supportano anche commenti XML in stile .NET, che consentono di generare documentazione di riferimento.
///    Consentono anche agli editor, come Visual Studio, di estrarre informazioni.
///    Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/xml-documentation


// Aprire gli spazi dei nomi con la parola chiave 'open'.
//
// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/import-declarations-the-open-keyword
open System


/// Un modulo è un raggruppamento di codice F#, ad esempio valori, tipi e valori di funzione.
/// Il raggruppamento del codice nei moduli consente di riunire il codice correlato e contribuisce a evitare conflitti di nome nel programma.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/modules
module IntegersAndNumbers =

    /// Questo è un valore integer di esempio.
    let sampleInteger = 176

    /// Questo è un numero a virgola mobile di esempio.
    let sampleDouble = 4.1

    /// Questo ha calcolato un nuovo numero in base a una certa aritmetica. I tipi numerici  vengono convertiti con
    /// funzioni 'int', 'double' e così via.
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    /// Questo è un elenco di numeri compresi tra 0 e 99.
    let sampleNumbers = [ 0 .. 99 ]

    /// Questo è un elenco di tutte le tuple che contengono tutti i numeri compresi tra 0 e 99 e i relativi quadrati.
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // La riga successiva stampa un elenco che include le tuple, usando '%A' per la stampa generica.
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfSquares

    // Questo è un intero di esempio con un'annotazione di tipo
    let sampleInteger3: int = 1


/// Per impostazione predefinita, i valori in F# non sono modificabili e non è possibile cambiarli
/// durante l'esecuzione di un programma a meno che non siano contrassegnati esplicitamente come modificabili.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/values/index#why-immutable
module Immutability =

    /// Il binding di un valore in un nome tramite 'let' lo rende non modificabile.
    ///
    /// La seconda riga di codice non viene compilata perché 'number' non è modificabile e ne è stato eseguito il binding.
    /// La ridefinizione di 'number' in un valore diverso non è consentita in F#.
    let number = 2
    // let number = 3

    /// Binding modificabile. È necessario per poter modificare il valore di 'otherNumber'.
    let mutable otherNumber = 2

    printfn "'otherNumber' is %d" otherNumber

    // Durante la modifica di un valore, usare '<-' per assegnare un nuovo valore.
    //
    // Non è possibile usare '=' in questo punto per questa finalità perché viene usato per l'uguaglianza
    // o altri contesti come 'let' o 'module'
    otherNumber <- otherNumber + 1

    printfn "'otherNumber' changed to be %d" otherNumber


/// Buona parte della programmazione F# consiste nella definizione di funzioni che trasformano i dati di input per produrre
/// risultati utili.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/functions/
module BasicFunctions =

    /// Usare 'let' per definire una funzione. Questa accetta un argomento Integer e restituisce un intero.
    /// Le parentesi sono facoltative per gli argomenti di funzione, ad eccezione dei casi in cui si usa un'annotazione di tipo esplicita.
    let sampleFunction1 x = x*x + 3

    /// Applicare la funzione, denominando il risultato restituito della funzione tramite 'let'.
    /// Il tipo variabile viene dedotto dal tipo restituito della funzione.
    let result1 = sampleFunction1 4573

    // Questa riga usa '%d' per stampare il risultato in formato Integer. È indipendente dai tipi.
    // Se il tipo di 'result1' non fosse 'int', la riga non verrebbe compilata.
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    /// Quando necessario, annotare il tipo di un nome di parametro usando '(argument:type)'. Le parentesi sono obbligatorie.
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn "The result of applying the 2nd sample function to (7 + 4) is %d" result2

    /// Nelle istruzioni condizionali si usano if/then/elid/elif/else.
    ///
    /// Si noti che F# usa la sintassi con riconoscimento degli spazi vuoti di rientro, in modo analogo a linguaggi come Python.
    let sampleFunction3 x =
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)

    // Questa riga usa '%f' per stampare il risultato in formato float. Come con '%d' in precedenza, è indipendente dai tipi.
    printfn "The result of applying the 3rd sample function to (6.5 + 4.5) is %f" result3


/// I valori booleani sono tipi di dati fondamentali in F#. Ecco alcuni esempi di valori booleani e logica condizionale.
///
/// Per altre informazioni, vedere:
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/primitive-types
///     e
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/symbol-and-operator-reference/boolean-operators
module Booleans =

    /// I valori booleani sono 'true' e 'false'.
    let boolean1 = true
    let boolean2 = false

    /// Gli operatori su valori booleani sono 'not', '&&' e '||'.
    let boolean3 = not boolean1 && (boolean2 || false)

    // Questa riga usa '%b' per stampare un valore booleano. È indipendente dai tipi.
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %b" boolean3


/// Le stringhe sono tipi di dati fondamentali in F#. Ecco alcuni esempi di stringhe e di manipolazione di base delle stringhe.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/strings
module StringManipulation =

    /// Per le stringhe si usano le virgolette doppie.
    let string1 = "Hello"
    let string2  = "world"

    /// Nelle stringhe si può anche usare @ per creare un valore letterale di stringa verbatim.
    /// In questo modo i caratteri di escape, come '\', '\n', '\t' e così via, verranno ignorati.
    let string3 = @"C:\Program Files\"

    /// Nei valori letterali si possono usare anche virgolette triple.
    let string4 = """The computer said "hello world" when I told it to!"""

    /// Per la concatenazione di stringhe viene in genere usato l'operatore '+'.
    let helloWorld = string1 + " " + string2

    // Questa riga usa '%s' per stampare un valore stringa. È indipendente dai tipi.
    printfn "%s" helloWorld

    /// Nelle sottostringhe si usa la notazione dell'indicizzatore. Questa riga estrae i primi sette caratteri come sottostringa.
    /// Si noti che, analogamente a molti linguaggi, le stringhe presentano indice zero in F#.
    let substring = helloWorld.[0..6]
    printfn "%s" substring


/// Le tuple sono semplici combinazioni di valori dati in un valore combinato.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/tuples
module Tuples =

    /// Tupla di interi semplice.
    let tuple1 = (1, 2, 3)

    /// Funzione che scambia l'ordine di due valori in una tupla.
    ///
    /// L'inferenza del tipo di F# consentirà di generalizzare automaticamente la funzione in modo che il relativo tipo sia generico,
    /// per indicare che funzionerà con qualsiasi tipo.
    let swapElems (a, b) = (b, a)

    printfn "The result of swapping (1, 2) is %A" (swapElems (1,2))

    /// Tupla costituita da un intero, una stringa
    /// e un numero a virgola mobile a precisione doppia.
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A\ttuple2: %A" tuple1 tuple2

    /// Tupla di interi semplice con annotazione di tipo.
    /// Nelle annotazioni di tipo per le tuple si usa il simbolo * per separare gli elementi
    let tuple3: int * int = (5, 9)

    /// Le tuple sono in genere oggetti, ma possono essere rappresentate anche come struct.
    ///
    /// Questi interagiscono completamente con gli struct in C# e Visual Basic.NET; tuttavia,
    /// le tuple di struct non sono convertibili in modo implicito con tuple di oggetto (spesso chiamate tuple di riferimento).
    ///
    /// A causa di questo problema la seconda riga sotto non verrà compilata. Rimuovere il commento per vedere cosa succede.
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // Anche se non è possibile eseguire la conversione in modo implicito tra tuple della struttura e tuple di riferimento,
    // è possibile eseguire la conversione in modo esplicito tramite i criteri di ricerca, come illustrato di seguito.
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)

    printfn "Struct Tuple: %A\nReference tuple made from the Struct Tuple: %A" sampleStructTuple (sampleStructTuple |> convertFromStructTuple)


/// Gli operatori pipe di F# ('|>', '<|' e così via) e gli operatori di composizione di F# ('>>', '<<')
/// sono particolarmente usati durante l'elaborazione dati. Questi operatori sono di per sé funzioni
/// che usano l'applicazione parziale.
///
/// Per altre informazioni su questi operatori, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/functions/#function-composition-and-pipelining
/// Per altre informazioni sull'applicazione parziale, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/functions/#partial-application-of-arguments
module PipelinesAndComposition =

    /// Calcola il quadrato di un valore.
    let square x = x * x

    /// Aggiunge 1 a un valore.
    let addOne x = x + 1

    /// Testa se un valore intero è dispari tramite modulo.
    let isOdd x = x % 2 <> 0

    /// Elenco di cinque numeri. Per altre informazioni sugli elenchi, vedere più avanti.
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// Dato un elenco di interi, filtra i numeri pari,
    /// calcola i quadrati dei numeri dispari risultati e aggiunge 1 ai numeri dispari quadrati.
    let squareOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" numbers (squareOddValuesAndAddOne numbers)

    /// Uno dei modi più brevi per scrivere 'squareOddValuesAndAddOne' consiste nell'annidare ogni
    /// risultato secondario nelle chiamate di funzione stesse.
    ///
    /// In questo modo la funzione è molto più breve, ma risulta più difficile visualizzare
    /// l'ordine in cui vengono elaborati i dati.
    let squareOddValuesAndAddOneNested values =
        List.map addOne (List.map square (List.filter isOdd values))

    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers (squareOddValuesAndAddOneNested numbers)

    /// Uno dei modi preferiti per scrivere 'squareOddValuesAndAddOne' consiste nell'usare gli operatori pipe di F#.
    /// In tal modo sarà possibile evitare risultati intermedi, ma si migliora la leggibilità
    /// rispetto all'annidamento di chiamate di funzione come 'squareOddValuesAndAddOneNested'
    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    printfn "processing %A through 'squareOddValuesAndAddOnePipeline' produces: %A" numbers (squareOddValuesAndAddOnePipeline numbers)

    /// È possibile abbreviare 'squareOddValuesAndAddOnePipeline' spostando la seconda chiamata a `List.map`
    /// nella prima usando una funzione lambda.
    ///
    /// Si noti che le pipeline vengono usate anche all'interno della funzione lambda. Gli operatori pipe di F#
    /// possono essere usati anche per singoli valori, di conseguenza sono particolarmente efficaci per l'elaborazione dei dati.
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" numbers (squareOddValuesAndAddOneShorterPipeline numbers)

    /// È infine possibile evitare di accettare in modo esplicito 'values' come parametro usando '>>'
    /// per comporre le due operazioni di base, ovvero filtrare i numeri pari, calcolare il quadrato e aggiungere 1.
    /// Analogamente, anche la parte 'fun x -> ...' dell'espressione lambda non è necessaria perché 'x' viene semplicemente
    /// definito in tale ambito in modo che sia possibile passarlo a una pipeline funzionale. In questo punto è quindi possibile
    /// usare anche '>>'.
    ///
    /// Il risultato di 'squareOddValuesAndAddOneComposition' è di per sé un'altra funzione che accetta come input un
    /// elenco di interi. Se si esegue 'squareOddValuesAndAddOneComposition' con un elenco
    /// di interi, si noterà che consente di ottenere gli stessi risultati delle funzioni precedenti.
    ///
    /// Usa la cosiddetta composizione di funzione. Tale operazione è possibile perché in F# le funzioni
    /// usano l'applicazione parziale e i tipi di input e output di ogni operazione di elaborazione dati corrispondono
    /// alle firme delle funzioni usate.
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneComposition' produces: %A" numbers (squareOddValuesAndAddOneComposition numbers)


/// Gli elenchi sono elenchi a un solo collegamento ordinati e non modificabili la cui valutazione è di tipo eager.
///
/// Questo modulo mostra diversi modi per generare elenchi ed elenchi i processi con alcune funzioni
/// nel modulo 'List' della libreria di base di F#.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/lists
module Lists =

    /// Per definire gli elenchi si usa [ ... ]. Questo è un elenco vuoto.
    let list1 = [ ]

    /// Questo è un elenco con tre elementi. Per delimitare gli elementi sulla stessa riga, viene usato il punto e virgola (';').
    let list2 = [ 1; 2; 3 ]

    /// È anche possibile delimitare gli elementi posizionandoli su righe distinte.
    let list3 = [
        1
        2
        3
    ]

    /// Questo è un elenco di numeri interi tra 1 e 1000
    let numberList = [ 1 .. 1000 ]

    /// Gli elenchi possono anche essere generati da calcoli. Questo è un elenco contenente
    /// tutti i giorni dell'anno.
    let daysList =
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                  yield System.DateTime(2017, month, day) ]

    // Stampa i primi cinque elementi di 'daysList' usando 'List.take'.
    printfn "The first 5 days of 2017 are: %A" (daysList |> List.take 5)

    /// I calcoli possono contenere istruzioni condizionali. Questo è un elenco contenente le tuple
    /// che rappresentano le coordinate dei quadrati neri su una scacchiera.
    let blackSquares =
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do
                  if (i+j) % 2 = 1 then
                      yield (i, j) ]

    /// Per trasformare gli elenchi, è possibile usare 'List.map' e altri combinatori di programmazione funzionale.
    /// Questa definizione consente di produrre un nuovo elenco mediante la quadratura dei numeri in numberList, usando l'operatore pipeline
    /// per passare un argomento a List.map.
    let squares =
        numberList
        |> List.map (fun x -> x*x)

    /// Esistono molte altre combinazioni di elenco. L'istruzione seguente calcola la somma dei quadrati dei
    /// numeri divisibili per 3.
    let sumOfSquares =
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)

    printfn "The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d" sumOfSquares


/// Le matrici sono raccolte modificabili di dimensioni fisse di elementi dello stesso tipo.
///
/// Anche se sono simili agli elenchi (supportano l'enumerazione e contengono combinatori simili per l'elaborazione dati),
/// sono in genere più veloci e supportano l'accesso casuale rapido. La maggiore velocità implica però una minore sicurezza perché questi elementi sono modificabili.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/arrays
module Arrays =

    /// Questa è la matrice vuota. Si noti che la sintassi è simile a quella degli elenchi, ma viene usato `[| ... |]`.
    let array1 = [| |]

    /// Per specificare le matrici viene usato lo stesso intervallo di costrutti degli elenchi.
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// Questo è una matrice di numeri compresi tra 1 e 1000.
    let array3 = [| 1 .. 1000 |]

    /// Questa è una matrice contenente solo le parole "hello" e "world".
    let array4 =
        [| for word in array2 do
               if word.Contains("l") then
                   yield word |]

    /// Questa è una matrice inizializzata dall'indice e contenente i numeri pari compresi tra 0 e 2000.
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// Le sottomatrici vengono estratte mediante una notazione di sezionamento.
    let evenNumbersSlice = evenNumbers.[0..500]

    /// Per eseguire il ciclo su matrici ed elenchi, si possono usare i cicli 'for'.
    for word in array4 do
        printfn "word: %s" word

    // È possibile modificare il contenuto di un elemento di matrice usando l'operatore di assegnazione freccia sinistra.
    //
    // Per altre informazioni su questo operatore, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/values/index#mutable-variables
    array2.[1] <- "WORLD!"

    /// Per trasformare le matrici, è possibile usare 'Array.map' e altre operazioni di programmazione funzionale.
    /// Il codice seguente consente di calcolare la somma delle lunghezze delle parole che iniziano con 'h'.
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn "The sum of the lengths of the words in Array 2 is: %d" sumOfLengthsOfWords


/// Le sequenze sono costituite da una serie logica di elementi, tutti dello stesso tipo. Sono di un tipo più generale rispetto ad elenchi e matrici.
///
/// Le sequenze vengono valutate su richiesta e rivalutate ogni volta che vengono iterate.
/// Una sequenza F# è un alias dell'elemento System.Collections.Generic.IEnumerable<'T> di .NET.
///
/// Le funzioni di elaborazione della sequenza possono essere applicate anche a elenchi e matrici.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/sequences
module Sequences =

    /// Questa è la sequenza vuota.
    let seq1 = Seq.empty

    /// Questa è una sequenza di valori.
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    /// Questa è una sequenza su richiesta compresa tra 1 e 1000.
    let numbersSeq = seq { 1 .. 1000 }

    /// Questa è una sequenza che produce le parole "hello" e "world"
    let seq3 =
        seq { for word in seq2 do
                  if word.Contains("l") then
                      yield word }

    /// Questa è la sequenza che produce i numeri pari fino a 2000.
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    /// Questa è una sequenza infinita, ovvero un percorso casuale.
    /// In questo esempio si usa yield! per restituire ogni elemento di una sottosequenza.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// Questo esempio mostra i primi 100 elementi del percorso casuale.
    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList

    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk


/// Le funzioni ricorsive possono chiamarsi da sole. In F# le funzioni sono ricorsive solo
/// quando per la dichiarazione si usa 'let rec'.
///
/// La ricorsione è il modo preferito per elaborare sequenze o raccolte in F#.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/functions/index#recursive-functions
module RecursiveFunctions =

    /// Questo esempio mostra una funzione ricorsiva che calcola il fattoriale di un
    /// numero intero. Usa 'let rec' per definire una funzione ricorsiva.
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n-1)

    printfn "Factorial of 6 is: %d" (factorial 6)

    /// Calcola il fattore comune maggiore di due interi.
    ///
    /// Dal momento che tutte le chiamate ricorsive sono chiamate tail,
    /// il compilatore convertirà la funzione in un ciclo,
    /// in modo da migliorare le prestazioni e ridurre il consumo di memoria.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn "The Greatest Common Factor of 300 and 620 is %d" (greatestCommonFactor 300 620)

    /// Questo esempio consente di calcolare la somma di un elenco di interi usando la ricorsione.
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    /// In questo modo la funzione tail 'sumList' viene resa ricorsiva, usando una funzione helper con un accumulatore di risultati.
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    /// Viene chiamata la funzione helper tail ricorsiva, fornendo '0' come accumulatore di seeding.
    /// Un approccio di questo tipo è comune in F#.
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn "The sum 1-10 is %d" (sumListTailRecursive oneThroughTen)


/// I record sono un aggregato di valori denominati, con membri facoltativi, ad esempio metodi.
/// Non sono modificabili e includono la semantica di uguaglianza strutturale.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/records
module RecordTypes =

    /// Questo esempio mostra come definire un nuovo tipo di record.
    type ContactCard =
        { Name     : string
          Phone    : string
          Verified : bool }

    /// Questo esempio mostra come creare un'istanza di un tipo di record.
    let contact1 =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false }

    /// È possibile eseguire questa operazione sulla stessa riga usando i separatori ';'.
    let contactOnSameLine = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

    /// Questo esempio mostra come usare il metodo di copia e aggiornamento su valori di record. Crea
    /// un nuovo valore di record che è una copia di contact1, ma contiene valori diversi per
    /// i campi 'Phone' e 'Verified'.
    ///
    /// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/copy-and-update-record-expressions
    let contact2 =
        { contact1 with
            Phone = "(206) 555-0112"
            Verified = true }

    /// Questo esempio mostra come scrivere una funzione che elabora un valore di record.
    /// Converte un oggetto 'ContactCard' in una stringa.
    let showContactCard (c: ContactCard) =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn "Alf's Contact Card: %s" (showContactCard contact1)

    /// Questo è un esempio di record con un membro.
    type ContactCardAlternate =
        { Name     : string
          Phone    : string
          Address  : string
          Verified : bool }

        /// I membri possono implementare membri orientati a oggetti.
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified)" else "") + this.Address

    let contactAlternate =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false
          Address = "111 Alf Street" }

    // In un tipo di cui è stata creata un'istanza l'accesso ai membri avviene tramite l'operatore '.'.
    printfn "Alf's alternate contact card is %s" contactAlternate.PrintedContactCard

    /// I record possono essere rappresentati anche come struct tramite l'attributo 'Struct'.
    /// Questo comportamento è utile in situazioni in cui la prestazioni degli struct sono prioritarie rispetto alla
    /// flessibilità dei tipi di riferimento.
    [<Struct>]
    type ContactCardStruct =
        { Name     : string
          Phone    : string
          Verified : bool }


/// Le unioni discriminate sono valori che potrebbero corrispondere a un certo numero di case o form denominati.
/// I dati archiviati nelle unioni discriminate possono essere uno di diversi valori distinti.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/discriminated-unions
module DiscriminatedUnions =

    /// L'istruzione seguente rappresenta il seme di una carta da gioco.
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    /// È possibile usare un'unione discriminata anche per rappresentare il valore di una carta da gioco.
    type Rank =
        /// Rappresenta il valore delle carte da 2 a 10
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        /// Le unioni discriminate possono inoltre implementare membri orientati a oggetti.
        static member GetAllRanks() =
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]

    /// Questo è un tipo di record che combina un seme e un valore.
    /// Per la rappresentazione dei dati si usano in genere record e unioni discriminate.
    type Card = { Suit: Suit; Rank: Rank }

    /// Calcola un elenco che rappresenta tutte le carte del mazzo.
    let fullDeck =
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do
                  yield { Suit=suit; Rank=rank } ]

    /// Questo esempio consente di convertire un oggetto 'Card' in una stringa.
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

    /// Questo esempio consente di stampare tutte le carte di un mazzo.
    let printAllCards() =
        for card in fullDeck do
            printfn "%s" (showPlayingCard card)

    // Le unioni discriminate a case singolo vengono spesso usate per la modellazione dei domini. In questo modo è possibile garantire una maggiore sicurezza dei tipi
    // rispetto a tipi primitivi come stringhe e valori int.
    //
    // Le unioni discriminate a case singolo non possono essere convertite in modo implicito nel o dal tipo di cui eseguono il wrapping.
    // Ad esempio, una funzione che accetta un indirizzo non può accettare come input una stringa,
    // o viceversa.
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    // È possibile creare facilmente un'istanza di una unione discriminata a case singolo come descritto di seguito.
    let address = Address "111 Alf Way"
    let name = Name "Alf"
    let ssn = SSN 1234567890

    /// Quando è necessario il valore, è possibile annullare il wrapping del valore sottostante con una funzione semplice.
    let unwrapAddress (Address a) = a
    let unwrapName (Name n) = n
    let unwrapSSN (SSN s) = s

    // Le funzioni di unwrapping semplificano la stampa di unioni discriminate a case singolo.
    printfn "Address: %s, Name: %s, and SSN: %d" (address |> unwrapAddress) (name |> unwrapName) (ssn |> unwrapSSN)

    /// Le unioni discriminate supportano anche definizioni ricorsive.
    ///
    /// Rappresenta un albero di ricerca binaria, in cui un caso è l'albero vuoto,
    /// e l'altro è un nodo con un valore e due sottoalberi.
    type BST<'T> =
        | Empty
        | Node of value:'T * left: BST<'T> * right: BST<'T>

    /// Verifica l'esistenza di un elemento nell'albero della ricerca binaria.
    /// Esegue la ricerca in modo ricorsivo usando i criteri di ricerca. Restituisce true se esiste; in caso contrario, false.
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left) // Verifica il sottoalbero di sinistra.
            else (exists item right) // Verifica il sottoalbero di destra.

    /// Inserisce un elemento nell'albero della ricerca binaria.
    /// Trova la posizione da inserire in modo ricorsivo con i criteri di ricerca, quindi inserisce un nuovo nodo.
    /// Se l'elemento è già presente, non inserisce nulla.
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node // Non è necessario inserirla perché esiste già; restituisce il nodo.
            elif item < x then Node(x, insert item left, right) // Chiamata nel sottoalbero di sinistra.
            else Node(x, left, insert item right) // Chiamata nel sottoalbero di destra.

    /// Le unioni discriminate possono essere rappresentate anche come struct tramite l'attributo 'Struct'.
    /// Questo comportamento è utile in situazioni in cui la prestazioni degli struct sono prioritarie rispetto alla
    /// flessibilità dei tipi di riferimento.
    ///
    /// Quando si esegue questa operazione, è però importante conoscere due aspetti:
    ///     1. Un'unione discriminata di struct non può essere definita in modo ricorsivo.
    ///     2. A ogni case di un'unione discriminata di struct deve essere assegnato un nome univoco.
    [<Struct>]
    type Shape =
        | Circle of radius: float
        | Square of side: float
        | Triangle of height: float * width: float


/// I criteri di ricerca sono una funzionalità di F# che consente di utilizzare i criteri,
/// che consentono di confrontare i dati con una o più strutture logiche,
/// scomporre i dati nelle parti costituenti o estrarre le informazioni dai dati in diversi modi.
/// È quindi possibile intervenire sulla "forma" di un criterio tramite i criteri di ricerca.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/pattern-matching
module PatternMatching =

    /// Record per il nome e il cognome di una persona
    type Person = {
        First : string
        Last  : string
    }

    /// Unione discriminata di tre diversi tipi di dipendenti
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// Conta chiunque sotto il dipendente nella gerarchia di gestione,
    /// includendo il dipendente.
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(id) ->
                0
            | Manager(id, reports) ->
                reports |> List.sumBy countReports
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    /// Trova tutti i manager/dirigenti il cui nome è "Dave" e per i quali non sono disponibili report.
    /// Usa la sintassi abbreviata di 'function' come espressione lambda.
    let rec findDaveWithOpenPosition(emps : List<Employee>) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true // [] corrisponde a un elenco vuoto.
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false) // '_' è un carattere jolly che corrisponde a qualsiasi stringa.
                                     // Gestisce il caso "or else".

    /// Per i criteri di ricerca è anche possibile usare il costrutto di funzione a sintassi abbreviata,
    /// che risulta utile quando si scrivono funzioni che usano l'applicazione parziale.
    let private parseHelper f = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDateTimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    // Consente di definire alcune altre funzioni che vengono analizzate con la funzione helper.
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

    // I criteri attivi sono un altro costrutto efficace da usare con i criteri di ricerca.
    // Consentono di partizionare i dati di input in form personalizzati, scomponendoli a livello del sito di chiamata dei criteri di ricerca.
    //
    // Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/active-patterns
    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    /// I criteri di ricerca con parola chiave 'function' e criteri attivi sono spesso simili a questi.
    let printParseResult = function
        | Int x -> printfn "%d" x
        | Double x -> printfn "%f" x
        | Date d -> printfn "%s" (d.ToString())
        | TimeSpan t -> printfn "%s" (t.ToString())
        | _ -> printfn "Nothing was parse-able!"

    // Chiama la stampante con alcuni valori diversi da analizzare.
    printParseResult "12"
    printParseResult "12.045"
    printParseResult "12/28/2016"
    printParseResult "9:01PM"
    printParseResult "banana!"


/// Il valore dell'opzione è qualsiasi valore con tag 'Some' o 'None'.
/// Questi valori sono ampiamente utilizzati nel codice F# per rappresentare i casi in cui molti altri
/// linguaggi utilizzerebbero riferimenti null.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/options
module OptionValues =

    /// Consente innanzitutto di definire un codice postale definito tramite l'unione discriminata a case singolo.
    type ZipCode = ZipCode of string

    /// Definire quindi un tipo in cui l'elemento ZipCode è facoltativo.
    type Customer = { ZipCode: ZipCode option }

    /// Definire quindi un tipo di interfaccia che rappresenta un oggetto per calcolare la zona di spedizione per il codice postale del cliente,
    /// date le implementazioni per i metodi astratti 'getState' e 'getShippingZone'.
    type ShippingCalculator =
        abstract GetState : ZipCode -> string option
        abstract GetShippingZone : string -> int

    /// Calcolare quindi una zona di spedizione per un cliente usando un'istanza della calcolatrice.
    /// Usa i combinatori del modulo Option per consentire una pipeline funzionale per
    /// la trasformazione di dati con Optionals.
    let CustomerShippingZone (calculator: ShippingCalculator, customer: Customer) =
        customer.ZipCode
        |> Option.bind calculator.GetState
        |> Option.map calculator.GetShippingZone


/// Le unità di misura consentono di annotare tipi numerici primitivi in modo indipendente dai tipi.
/// È quindi possibile eseguire operazioni aritmetiche indipendenti dai tipi su questi valori.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/units-of-measure
module UnitsOfMeasure =

    /// Aprire innanzitutto una raccolta di nomi di unità comuni
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    /// Definire una costante unificata
    let sampleValue1 = 1600.0<meter>

    /// Definire quindi un nuovo tipo di unità
    [<Measure>]
    type mile =
        /// Fattore di conversione da miglia a metri.
        static member asMeter = 1609.34<meter/mile>

    /// Definire una costante unificata
    let sampleValue2  = 500.0<mile>

    /// Calcola la costante del sistema metrico
    let sampleValue3 = sampleValue2 * mile.asMeter

    // I valori che usano unità di misura possono essere usati come il tipo numerico primitivo per elementi come la stampa.
    printfn "After a %f race I would walk %f miles which would be %f meters" sampleValue1 sampleValue2 sampleValue3


/// Le classi sono un modo per definire nuovi tipi di oggetto in F# e supportano costrutti standard orientati a oggetti.
/// Possono includere numerosi membri (metodi, proprietà, eventi e così via)
///
/// Per altre informazioni sulle classi, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/classes
///
/// Per altre informazioni sui membri, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/members
module DefiningClasses =

    /// Semplice classe di vettore bidimensionale.
    ///
    /// Il costruttore della classe si trova sulla prima riga
    /// e accetta due argomenti, dx e dy, entrambi di tipo 'double'.
    type Vector2D(dx : double, dy : double) =

        /// In questo campo interno è archiviata la lunghezza del vettore, calcolata durante
        /// la costruzione dell'oggetto
        let length = sqrt (dx*dx + dy*dy)

        // 'this' specifica un nome per l'autoidentificatore dell'oggetto.
        // Nei metodi di istanza, deve trovarsi prima del nome del membro.
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        /// Questo membro è un metodo. I membri precedenti erano proprietà.
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    /// In questo modo viene creata un'istanza della classe Vector2D.
    let vector1 = Vector2D(3.0, 4.0)

    /// Consente di ottenere un nuovo oggetto vettore scalato senza modificare l'oggetto originale.
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f\nLength of vector2: %f" vector1.Length vector2.Length


/// Le classi generiche consentono di definire tipi rispetto a un set di parametri di tipo.
/// Nel codice seguente 'T è il parametro di tipo per la classe.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/generics/
module DefiningGenericClasses =

    type StateTracker<'T>(initialElement: 'T) =

        /// Questo campo interno archivia gli stati in un elenco.
        let mutable states = [ initialElement ]

        /// Aggiunge un nuovo elemento all'elenco degli stati.
        member this.UpdateState newState =
            states <- newState :: states  // usare l'operatore '<-' per modificare il valore.

        /// Consente di ottenere l'intero elenco degli stati cronologici.
        member this.History = states

        /// Consente di ottenere l'ultimo stato.
        member this.Current = states.Head

    /// Istanza 'int' della classe di rilevamento stato. Si noti che il parametro di tipo è dedotto.
    let tracker = StateTracker 10

    // Viene aggiunto uno stato
    tracker.UpdateState 17


/// Le interfacce sono tipi di oggetto contenenti solo membri 'abstract'.
/// I tipi di oggetto e le espressioni di oggetto possono implementare interfacce.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/interfaces
module ImplementingInterfaces =

    /// Questo è un tipo che implementa IDisposable.
    type ReadFile() =

        let file = new System.IO.StreamReader("readme.txt")

        member this.ReadLine() = file.ReadLine()

        // Questa è l'implementazione dei membri di IDisposable.
        interface System.IDisposable with
            member this.Dispose() = file.Close()


    /// Questo è un oggetto che implementa IDisposable tramite un'espressione di oggetto
    /// Diversamente da altri linguaggi, come C# o Java, non è necessaria una nuova definizione di tipo
    /// per implementare un'interfaccia.
    let interfaceImplementation =
        { new System.IDisposable with
            member this.Dispose() = printfn "disposed" }


/// La libreria FSharp.Core definisce un intervallo di funzioni di elaborazione parallela. In questo caso
/// si usano alcune funzioni per l'elaborazione parallela sulle matrici.
///
/// Per altre informazioni, vedere: https://msdn.microsoft.com/it-it/visualfsharpdocs/conceptual/array.parallel-module-%5Bfsharp%5D
module ParallelArrayProgramming =

    /// Definire innanzitutto una matrice di input.
    let oneBigArray = [| 0 .. 100000 |]

    // Definire quindi una funzione che esegue alcuni calcoli intensivi della CPU.
    let rec computeSomeFunction x =
        if x <= 2 then 1
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)

    // Eseguire quindi un mapping parallelo su una matrice di input di grandi dimensioni.
    let computeResults() =
        oneBigArray
        |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    // Stampare quindi i risultati.
    printfn "Parallel computation results: %A" (computeResults())



/// Gli eventi sono un termine comune per la programmazione .NET, in particolare con le applicazioni Windows Form o WPF.
///
/// Per altre informazioni, vedere: https://docs.microsoft.com/it-it/dotnet/articles/fsharp/language-reference/members/events
module Events =

    /// Creare innanzitutto un'istanza dell'oggetto Event costituito dal punto di sottoscrizione (event.Publish) e dal trigger di evento (event.Trigger).
    let simpleEvent = new Event<int>()

    // Aggiungere quindi il gestore all'evento.
    simpleEvent.Publish.Add(
        fun x -> printfn "this handler was added with Publish.Add: %d" x)

    // Attivare quindi l'evento.
    simpleEvent.Trigger(5)

    // Creare quindi un'istanza dell'oggetto Event che segue la convenzione .NET standard: (sender, EventArgs).
    let eventForDelegateType = new Event<EventHandler, EventArgs>()

    // Aggiungere quindi un gestore per questo nuovo evento.
    eventForDelegateType.Publish.AddHandler(
        EventHandler(fun _ _ -> printfn "this handler was added with Publish.AddHandler"))

    // Attivare quindi questo evento (si noti che è necessario impostare l'argomento sender).
    eventForDelegateType.Trigger(null, EventArgs.Empty)



#if COMPILED
module BoilerPlateForForm =
    [<System.STAThread>]
    do ()
    do System.Windows.Forms.Application.Run()
#endif
