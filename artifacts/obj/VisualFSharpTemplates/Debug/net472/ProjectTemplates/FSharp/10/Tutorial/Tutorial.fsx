// Este ejemplo le guiará por los elementos del lenguaje F#.
//
// *******************************************************************************************************
//   Para ejecutar el código en F# interactivo, resalte una sección de código y presione Alt+Entrar, o bien haga clic con el botón secundario
//   y seleccione "Ejecutar en modo interactivo". Puede abrir la ventana de F# interactivo desde el menú "Ver".
// *******************************************************************************************************
//
// Para obtener más información acerca de F#, vea:
//     https://fsharp.org
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/
//
// Para ver este tutorial en forma de documentación, vea:
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/tour
//
// Para obtener más información sobre la programación de F# aplicada, use
//     https://fsharp.org/guides/enterprise/
//     https://fsharp.org/guides/cloud/
//     https://fsharp.org/guides/web/
//     https://fsharp.org/guides/data-science/
//
// Para instalar Visual F# Power Tools, use
//     "Herramientas" --> "Extensiones y actualizaciones" --> "En línea" y busque
//
// Para obtener plantillas adicionales para su uso con F#, consulte 'Plantillas en línea' en Visual Studio,
//     "Nuevo proyecto" --> "Plantillas en línea"

// F# admite tres tipos de comentarios:

//  1. Comentarios con doble barra diagonal. Se usan en la mayoría de las situaciones.
(*  2. Comentarios de bloque de estilo ML. No se usan con tanta frecuencia. *)
/// 3. Comentarios de triple barra diagonal. Se utilizan para funciones de documentación, tipos, etc.
///    Aparecerán como texto al mantener el puntero por encima de algo decorado con estos comentarios.
///
///    También admiten comentarios XML de estilo .NET, que le permite generar documentación de referencia,
///    y también permite a los editores (como Visual Studio) extraer información de ellos.
///    Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/xml-documentation


// Abra los espacios de nombres con la palabra clave "open".
//
// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/import-declarations-the-open-keyword
open System


/// Un módulo es una agrupación de código de F#, como valores, tipos y valores de función.
/// El código de agrupación de los módulos ayuda a mantener el código relacionado en conjunto y ayuda a evitar los conflictos de nombres en su programa.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/modules
module IntegersAndNumbers =

    /// Este es un entero de ejemplo.
    let sampleInteger = 176

    /// Este es un número de punto flotante de ejemplo.
    let sampleDouble = 4.1

    /// Se calcula un número nuevo aplicando cierta aritmética. Los tipos numéricos se convierten mediante
    /// funciones "int", "double", etc.
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    /// Esta es una lista de números del 0 al 99.
    let sampleNumbers = [ 0 .. 99 ]

    /// Esta es una lista de todas las tuplas que contienen todos los números de 0 a 99 y sus cuadrados.
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // La línea siguiente imprime una lista que incluye tuplas, utilizando "%A" para la impresión genérica.
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfSquares

    // Este es un entero de ejemplo con una anotación de tipo
    let sampleInteger3: int = 1


/// Los valores de F# son inmutables de manera predeterminada. No se pueden cambiar
/// en el transcurso de la ejecución de un programa a menos que se marquen explícitamente como mutable.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/values/index#why-immutable
module Immutability =

    /// Al enlazar un valor a un nombre con "let", se convierte en inmutable.
    ///
    /// La segunda línea de código no se compila porque "number" es inmutable y está enlazado.
    /// En F#, no se puede redefinir "number" para darle otro valor.
    let number = 2
    // let number = 3

    /// Enlace mutable. Es necesario para poder mutar el valor de "otherNumber".
    let mutable otherNumber = 2

    printfn "'otherNumber' is %d" otherNumber

    // Para la mutación de un valor, use "<-" para asignar un valor nuevo.
    //
    // No pudo usar "=" con este propósito, porque se usa para la igualdad
    // u otros contextos, como "let" o "module"
    otherNumber <- otherNumber + 1

    printfn "'otherNumber' changed to be %d" otherNumber


/// Gran parte de la programación de F# consiste en definir funciones que transforman los datos de entrada para generar
/// resultados útiles.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/
module BasicFunctions =

    /// "let" se utiliza para definir una función. En este caso, acepta un argumento de entero y devuelve un entero.
    /// Los paréntesis son opcionales para argumentos de función, excepto cuando se utiliza una anotación de tipo explícito.
    let sampleFunction1 x = x*x + 3

    /// Aplicar la función, asignando un nombre al resultado devuelto por la función mediante 'let'.
    /// El tipo de variable se infiere del tipo de valor devuelto por la función.
    let result1 = sampleFunction1 4573

    // Esta línea utiliza "%d" para imprimir el resultado de un entero. Cuenta con seguridad de tipos.
    // Si "result1" no fuese de tipo "int", la línea no se compilaría.
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    /// Si es necesario, anote el tipo de un nombre de parámetro usando "(argument:type)". Los paréntesis son obligatorios.
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn "The result of applying the 2nd sample function to (7 + 4) is %d" result2

    /// Los condicionales usan if/then/elid/elif/else.
    ///
    /// Tenga en cuenta que F# utiliza una sintaxis que tiene en cuenta la sangría de espacios en blanco, de forma parecida a lenguajes como Python.
    let sampleFunction3 x =
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)

    // Esta línea utiliza "%f" para imprimir el resultado como un valor float. Al igual que "%d", cuenta con seguridad de tipos.
    printfn "The result of applying the 3rd sample function to (6.5 + 4.5) is %f" result3


/// Los valores booleanos son tipos de datos fundamentales en F#. Estos son algunos ejemplos de valores booleanos y lógica condicional.
///
/// Para obtener más información, vea:
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/primitive-types
///     Y
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/symbol-and-operator-reference/boolean-operators
module Booleans =

    /// Los valores booleanos son "true" y "false".
    let boolean1 = true
    let boolean2 = false

    /// Los operadores de valores booleanos son "not", "&&" y "||".
    let boolean3 = not boolean1 && (boolean2 || false)

    // Esta línea utiliza "%b" para imprimir un valor booleano. Cuenta con seguridad de tipos.
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %b" boolean3


/// Las cadenas son tipos de datos fundamentales en F#. Estos son algunos ejemplos de cadenas y de manipulación básica de cadenas.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/strings
module StringManipulation =

    /// Las cadenas usan comillas dobles.
    let string1 = "Hello"
    let string2  = "world"

    /// Las cadenas también pueden usar @ para crear un literal de cadena textual.
    /// No tiene en cuenta los caracteres de escape, como "\", "\n", "\t", etc.
    let string3 = @"C:\Program Files\"

    /// Los literales de cadena también pueden usar comillas triples.
    let string4 = """The computer said "hello world" when I told it to!"""

    /// La concatenación de cadenas suele hacerse con el operador "+".
    let helloWorld = string1 + " " + string2

    // Esta línea utiliza "%s" para imprimir un valor de cadena. Cuenta con seguridad de tipos.
    printfn "%s" helloWorld

    /// Las subcadenas utilizan la notación del indexador. Esta línea extrae los 7 primeros caracteres como una subcadena.
    /// Tenga en cuenta que, al igual que en otros muchos lenguajes, las cadenas tienen índice 0 en F#.
    let substring = helloWorld.[0..6]
    printfn "%s" substring


/// Las tuplas son combinaciones simples de valores de datos en un valor combinado.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/tuples
module Tuples =

    /// Tupla de enteros sencilla.
    let tuple1 = (1, 2, 3)

    /// Una función que intercambia el orden de dos valores en una tupla.
    ///
    /// La inferencia de tipos de F# generalizará la función de forma automática para que tenga un tipo genérico,
    /// lo que significa que funcionará con cualquier tipo.
    let swapElems (a, b) = (b, a)

    printfn "The result of swapping (1, 2) is %A" (swapElems (1,2))

    /// Una tupla que consta de un entero, una cadena,
    /// y un número de punto flotante de doble precisión.
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A\ttuple2: %A" tuple1 tuple2

    /// Una tupla de enteros sencilla con una anotación de tipo.
    /// Las anotaciones de tipo para las tuplas usan el símbolo * para separar los elementos
    let tuple3: int * int = (5, 9)

    /// Las tuplas suelen ser objetos, pero también se pueden representar como estructuras.
    ///
    /// Interoperan completamente con estructuras de C# y Visual Basic.NET; sin embargo,
    /// las tuplas de estructuras no son implícitamente convertibles con tuplas de objeto (a menudo denominadas tuplas de referencia).
    ///
    /// La segunda línea no se compilará por esto. Quite las marcas de comentario para ver qué ocurre.
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // Aunque no puede convertir tuplas de struct en tuplas de referencia y viceversa de forma implícita,
    // puede hacer la conversión de forma explícita mediante coincidencia de patrones, como se muestra a continuación.
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)

    printfn "Struct Tuple: %A\nReference tuple made from the Struct Tuple: %A" sampleStructTuple (sampleStructTuple |> convertFromStructTuple)


/// Los operadores de canalización ("|>", "<|", etc.) y de composición (">>", "<<") de F#
/// se utilizan mucho en el procesamiento de datos. Estos operadores son en sí mismos funciones.
/// que usan aplicación parcial.
///
/// Para obtener más información sobre estos operadores, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/#function-composition-and-pipelining
/// Para obtener más información sobre la aplicación parcial, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/#partial-application-of-arguments
module PipelinesAndComposition =

    /// Eleva un valor la cuadrado.
    let square x = x * x

    /// Suma 1 a un valor.
    let addOne x = x + 1

    /// Comprueba si un valor entero es impar mediante un módulo.
    let isOdd x = x % 2 <> 0

    /// Lista de 5 números. Más adelante, se proporciona más información sobre listas.
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// Dada una lista de enteros, aplica un filtro para excluir los números pares,
    /// eleva al cuadrado los impares resultantes y les suma 1.
    let squareOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" numbers (squareOddValuesAndAddOne numbers)

    /// Una forma más corta de escribir "squareOddValuesAndAddOne" es anidar cada
    /// subresultado en las propias llamadas a la función.
    ///
    /// Esto hace la función mucho más corta, pero es difícil ver el
    /// orden en el que se procesan los datos.
    let squareOddValuesAndAddOneNested values =
        List.map addOne (List.map square (List.filter isOdd values))

    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers (squareOddValuesAndAddOneNested numbers)

    /// Una forma recomendable de escribir "squareOddValuesAndAddOne" es usar operadores de canalización de F#.
    /// Esto permite evitar que se creen resultados intermedios, pero es mucho más fácil de leer
    /// que anidar las llamadas a la función como "squareOddValuesAndAddOneNested"
    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    printfn "processing %A through 'squareOddValuesAndAddOnePipeline' produces: %A" numbers (squareOddValuesAndAddOnePipeline numbers)

    /// No puede acortar "squareOddValuesAndAddOnePipeline" moviendo la segunda llamada de "List.map"
    /// a la primera, usando una función lambda.
    ///
    /// Tenga en cuenta que las canalizaciones se usan también en la función lambda. Los operadores de canalización de F#
    /// se puede usar también para valores individuales. Esto les confiere una gran capacidad para el procesamiento de datos.
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" numbers (squareOddValuesAndAddOneShorterPipeline numbers)

    /// Por último, puede eliminar la necesidad de tomar "valores" de forma explícita como parámetro usando ">>"
    /// para componer las dos operaciones principales: aplicar un filtro para excluir los números pares, elevar al cuadrado y sumar uno.
    /// De igual modo, no se necesita tampoco la parte "fun x -> ..." de la expresión lambda, porque "x"
    /// se define en ese ámbito para poderlo pasar a una canalización funcional. Por tanto, ">>" se pude usar
    /// aquí también.
    ///
    /// El resultado de "squareOddValuesAndAddOneComposition" es en sí mismo otra función que toma una
    /// lista de enteros como entrada. Si ejecuta "squareOddValuesAndAddOneComposition" con una lista
    /// de enteros, notará que produce los mismos resultados que las funciones anteriores.
    ///
    /// Aquí se utiliza lo que se conoce como composición de funciones. Es posible porque las funciones en F#
    /// utilizan aplicación parcial y los tipos de entrada y salida de cada operación de procesamiento de datos buscan
    /// las signaturas de las funciones que estamos usando.
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneComposition' produces: %A" numbers (squareOddValuesAndAddOneComposition numbers)


/// Las listas están ordenadas, son inmutables y están vinculadas individualmente. Son diligentes en su evaluación.
///
/// Este módulo muestra varias formas de generar listas y procesarlas con algunas funciones
/// en el módulo "List" de la biblioteca principal de F#.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/lists
module Lists =

    /// Las listas se definen mediante [ ... ]. Esta es una lista vacía.
    let list1 = [ ]

    /// Esta es una lista de 3 elementos. Se utiliza ";" para separar los elementos que están en la misma línea.
    let list2 = [ 1; 2; 3 ]

    /// También puede separar los elementos poniendo cada uno en su propia línea.
    let list3 = [
        1
        2
        3
    ]

    /// Esta es una lista de enteros del 1 al 1000
    let numberList = [ 1 .. 1000 ]

    /// Las listas también pueden generarse mediante cálculos. Esta es una lista que contiene
    /// todos los días del año.
    let daysList =
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                  yield System.DateTime(2017, month, day) ]

    // Imprime los 5 primeros elementos de "daysList" usando "List.take".
    printfn "The first 5 days of 2017 are: %A" (daysList |> List.take 5)

    /// Los cálculos pueden incluir condicionales. Esta es una lista que contiene las tuplas
    /// que son las coordenadas de los cuadrados negros de un tablero de ajedrez.
    let blackSquares =
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do
                  if (i+j) % 2 = 1 then
                      yield (i, j) ]

    /// Las listas se pueden transformas mediante "List.map" y otros combinadores de programación funcionales.
    /// Esta definición genera una nueva lista al elevar al cuadrado los números incluidos en numberList y usa el operador
    /// de canalización para pasar un argumento a List.map.
    let squares =
        numberList
        |> List.map (fun x -> x*x)

    /// Hay otras muchas combinaciones de listas. La siguiente, calcula la suma de los cuadrados de los
    /// números divisibles por 3.
    let sumOfSquares =
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)

    printfn "The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d" sumOfSquares


/// Las matrices son colecciones mutables de tamaño fijo de elementos del mismo tipo.
///
/// Aunque son parecidas a las listas (admiten enumeración y tienen combinadores parecidos para el procesamiento de datos),
/// suelen ser más rápidas y admitir acceso aleatorio rápido. A cambio, tiene el inconveniente de que es menos seguro porque es mutable.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/arrays
module Arrays =

    /// Esta es una matriz vacía. Observe que la sintaxis es parecida a la de las listas, pero utiliza "[| ... |]" en su lugar.
    let array1 = [| |]

    /// Las matrices se especifican con el mismo intervalo de construcciones que las listas.
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// Esta es una matriz de números del 1 al 1000.
    let array3 = [| 1 .. 1000 |]

    /// Esta es una matriz que solo contiene las palabras "hola" y "todos".
    let array4 =
        [| for word in array2 do
               if word.Contains("l") then
                   yield word |]

    /// Esta es una matriz inicializada con un índice que contiene los números pares del 0 al 2000.
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// Las submatrices se extraen mediante la notación divisoria.
    let evenNumbersSlice = evenNumbers.[0..500]

    /// Puede ejecutar un bucle en matrices y listas usando bucles "for".
    for word in array4 do
        printfn "word: %s" word

    // Puede modificar el contenido de un elemento de matriz mediante el operador de asignación de flecha izquierda.
    //
    // Para obtener más información sobre este operador, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/values/index#mutable-variables
    array2.[1] <- "WORLD!"

    /// Para transformar matrices, use "Array.map" y otras operaciones de programación funcionales.
    /// La operación siguiente calcula la suma de las longitudes de las palabras que empiezan por "h".
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn "The sum of the lengths of the words in Array 2 is: %d" sumOfLengthsOfWords


/// Las secuencias son una serie lógica de elementos del mismo tipo. Son de un tipo más general que las listas o las matrices.
///
/// Las secuencias se evalúan previa petición y se vuelven a evaluar cada vez que se recorren en iteración.
/// Una secuencia de F# es un alias para un elemento System.Collections.Generic.IEnumerable<'T> de .NET.
///
/// Las funciones de procesamiento de secuencias también pueden aplicarse a las listas y a las matrices.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/sequences
module Sequences =

    /// Esta es una secuencia vacía.
    let seq1 = Seq.empty

    /// Esta es una secuencia de valores.
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    /// Esta es una secuencia a petición del 1 al 1000.
    let numbersSeq = seq { 1 .. 1000 }

    /// Esta es una secuencia que genera las palabras "hola" y "todos"
    let seq3 =
        seq { for word in seq2 do
                  if word.Contains("l") then
                      yield word }

    /// Esta secuencia genera los números pares hasta el 2000.
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    /// Esta es una secuencia infinita que constituye un recorrido aleatorio.
    /// Este ejemplo usa yield! para devolver cada uno de los elementos de una subsecuencia.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// Este ejemplo muestra los 100 primeros elementos del recorrido aleatorio.
    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList

    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk


/// Las funciones recursivas pueden llamarse a sí mismas. En F#, las funciones solo son recursivas
/// cuando se declara con "let rec".
///
/// La recursión es la forma recomendada de procesar secuencias o colecciones en F#.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/index#recursive-functions
module RecursiveFunctions =

    /// Este ejemplo muestra una función recursiva que calcula el factorial de un
    /// entero. Usa "let rec" para definir una función recursiva.
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n-1)

    printfn "Factorial of 6 is: %d" (factorial 6)

    /// Calcula el mayor factor común de dos enteros.
    ///
    /// Puesto que todas las llamadas recursivas son llamadas de cola,
    /// el compilador devolverá la función en un bucle,
    /// lo que mejora el rendimiento y reduce el consumo de memoria.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn "The Greatest Common Factor of 300 and 620 is %d" (greatestCommonFactor 300 620)

    /// Este ejemplo calcula la suma de una lista de enteros con recursión.
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    /// Esto convierte la función "sumList" en recursiva de cola, usando una función auxiliar con un acumulador de resultados.
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    /// Este código invoca la función auxiliar recursiva de cola, proporcionando "0" como acumulador de valores de inicialización.
    /// Este método es habitual en F#.
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn "The sum 1-10 is %d" (sumListTailRecursive oneThroughTen)


/// Los registros son un agregado de valores con nombre, con miembros opcionales (como los métodos).
/// Son inmutables y tienen semántica de igualdad estructural.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/records
module RecordTypes =

    /// Este ejemplo muestra cómo definir un nuevo tipo de registro.
    type ContactCard =
        { Name     : string
          Phone    : string
          Verified : bool }

    /// Este ejemplo muestra cómo crear una instancia de un tipo de registro.
    let contact1 =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false }

    /// También puede hacer esto en la misma línea usando ";" como separador.
    let contactOnSameLine = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

    /// Este ejemplo muestra cómo usar "copy-and-update" en los valores de registro. Crea
    /// un nuevo valor de registro que es una copia de contact1, pero con valores distintos para
    /// los campos "Phone" y "Verified".
    ///
    /// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/copy-and-update-record-expressions
    let contact2 =
        { contact1 with
            Phone = "(206) 555-0112"
            Verified = true }

    /// Este ejemplo muestra cómo escribir una función que procesa un valor del registro.
    /// Convierte un objeto "ContactCard" en una cadena.
    let showContactCard (c: ContactCard) =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn "Alf's Contact Card: %s" (showContactCard contact1)

    /// Este es un ejemplo de un registro con un miembro.
    type ContactCardAlternate =
        { Name     : string
          Phone    : string
          Address  : string
          Verified : bool }

        /// Los miembros pueden implementar miembros orientados a objetos.
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified)" else "") + this.Address

    let contactAlternate =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false
          Address = "111 Alf Street" }

    // A los miembros se accede con el operador "." en un tipo del que se ha creado una instancia.
    printfn "Alf's alternate contact card is %s" contactAlternate.PrintedContactCard

    /// Los registros se pueden representar también como estructuras con el atributo "Struct".
    /// Esto es útil en situaciones donde el rendimiento de las estructuras es superior a
    /// la flexibilidad de los tipos de referencia.
    [<Struct>]
    type ContactCardStruct =
        { Name     : string
          Phone    : string
          Verified : bool }


/// Las uniones discriminadas (DU) son valores que podrían ser un gran número de formas o casos con nombre.
/// Los datos almacenados en uniones discriminadas pueden ser uno de varios valores diferentes.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/discriminated-unions
module DiscriminatedUnions =

    /// El siguiente código representa el palo de una carta.
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    /// También se puede usar una unión discriminada para representar el rango de una carta.
    type Rank =
        /// Representa el rango de cartas 2 .. 10
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        /// Las uniones discriminadas pueden implementar también miembros orientados a objetos.
        static member GetAllRanks() =
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]

    /// Este es un tipo de registro que combina un palo y un rango.
    /// Es habitual utilizar tanto registros como uniones discriminadas cuando se representan datos.
    type Card = { Suit: Suit; Rank: Rank }

    /// Este código calcula una lista que representa todas las cartas de la baraja.
    let fullDeck =
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do
                  yield { Suit=suit; Rank=rank } ]

    /// Este ejemplo convierte un objeto "Card" en una cadena.
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

    /// Este ejemplo imprime todas las cartas de una baraja.
    let printAllCards() =
        for card in fullDeck do
            printfn "%s" (showPlayingCard card)

    // Las uniones discriminadas de un solo caso se usan con frecuencia en el modelado de dominios. Esto puede aportar mayor seguridad de tipos
    // en tipos primitivos, como cadenas y enteros.
    //
    // Las uniones discriminadas de un solo caso no se pueden convertir de forma implícita en el tipo que encapsulan, ni viceversa.
    // Por ejemplo, una función que toma una dirección no puede aceptar una cadena como esa entrada,
    // o viceversa.
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    // Puede crear fácilmente una instancia de una unión discriminada de un solo caso del siguiente modo.
    let address = Address "111 Alf Way"
    let name = Name "Alf"
    let ssn = SSN 1234567890

    /// Cuando necesite el valor, puede desencapsular el valor subyacente con una función sencilla.
    let unwrapAddress (Address a) = a
    let unwrapName (Name n) = n
    let unwrapSSN (SSN s) = s

    // Imprimir uniones discriminadas de un solo caso es muy sencillo con funciones de desencapsulamiento.
    printfn "Address: %s, Name: %s, and SSN: %d" (address |> unwrapAddress) (name |> unwrapName) (ssn |> unwrapSSN)

    /// Las uniones discriminadas admiten también definiciones recursivas.
    ///
    /// Esto representa un árbol de búsqueda binaria, donde un caso es el árbol vacío
    /// y el otro es un nodo con un valor y dos subárboles.
    type BST<'T> =
        | Empty
        | Node of value:'T * left: BST<'T> * right: BST<'T>

    /// Comprueba si existe un elemento en el árbol de búsqueda binaria.
    /// Hace búsquedas de forma recursiva usando coincidencia de patrones. Devuelve true si existe; de lo contrario, false.
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left) // Comprueba el subárbol de la izquierda.
            else (exists item right) // Comprueba el subárbol de la derecha.

    /// Inserta un elemento en el árbol de búsqueda binaria.
    /// Busca dónde insertar de forma recursiva un nuevo nodo usando coincidencia de patrones y lo inserta.
    /// Si el elemento ya está presente, no inserta nada.
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node // No es necesario insertarlo, ya existe; devuelve el nodo.
            elif item < x then Node(x, insert item left, right) // Llama al subárbol de la izquierda.
            else Node(x, left, insert item right) // Llama al subárbol de la derecha.

    /// Las uniones discriminadas se pueden representar también como estructuras con el atributo "Struct".
    /// Esto es útil en situaciones donde el rendimiento de las estructuras es superior a
    /// la flexibilidad de los tipos de referencia.
    ///
    /// No obstante, hay dos cosas importantes que deben tenerse en cuenta cuando se hace esto:
    ///     1. Una unión discriminada de estructura no se puede definir de forma recursiva.
    ///     2. Una unión discriminada de estructura debe tener un nombre único para cada uno de sus casos.
    [<Struct>]
    type Shape =
        | Circle of radius: float
        | Square of side: float
        | Triangle of height: float * width: float


/// La coincidencia de patrones es una característica de F# que permite utilizar patrones,
/// que son una forma de comparar datos con estructuras lógicas,
/// descomponer datos en partes constituyentes o extraer información de datos de varias formas.
/// Después, puede hacer envíos en función de la "forma" de un patrón mediante coincidencia de patrones.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/pattern-matching
module PatternMatching =

    /// Un registro para el nombre y los apellidos de una persona
    type Person = {
        First : string
        Last  : string
    }

    /// Una unión discriminada de 3 tipos de empleados diferentes
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// Cuenta a todos por debajo del empleado en la jerarquía de administración,
    /// incluido el empleado.
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(id) ->
                0
            | Manager(id, reports) ->
                reports |> List.sumBy countReports
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    /// Buscar a todos los directores o ejecutivos que se llamen "Dave" que no tengan jefes.
    /// Aquí se utiliza la forma abreviada "function" como una expresión lambda.
    let rec findDaveWithOpenPosition(emps : List<Employee>) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true // [] coincide con una lista vacía.
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false) // "_" es un patrón comodín que busca cualquier cosa.
                                     // Este código controla el caso "or else".

    /// También puede usar la construcción abreviada de funciones para la coincidencia de patrones,
    /// que es muy útil cuando se escriben funciones que utilizan aplicación parcial.
    let private parseHelper f = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDateTimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    // Define algunas funciones más que se analizan con la función auxiliar.
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

    // Los patrones activos son también una construcción muy eficaz para usarla con coincidencia de patrones.
    // Permiten particionar los datos de entrada en formas personalizadas, descomponiéndolos en el sitio de llamada de coincidencia de patrones.
    //
    // Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/active-patterns
    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    /// La coincidencia de patrones con la palabra clave "function" y patrones activos suele ser similar a este código.
    let printParseResult = function
        | Int x -> printfn "%d" x
        | Double x -> printfn "%f" x
        | Date d -> printfn "%s" (d.ToString())
        | TimeSpan t -> printfn "%s" (t.ToString())
        | _ -> printfn "Nothing was parse-able!"

    // Llamar a la impresora con algunos valores diferentes para analizar.
    printParseResult "12"
    printParseResult "12.045"
    printParseResult "12/28/2016"
    printParseResult "9:01PM"
    printParseResult "banana!"


/// Los valores de opción son cualquier tipo de valor etiquetado como 'Some' o 'None'.
/// Se usan de forma exhaustiva en el código de F# para representar los casos en los que muchos otros
/// lenguajes usarían referencias NULL.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/options
module OptionValues =

    /// En primer lugar, defina un código postal con una unión discriminada de un solo caso.
    type ZipCode = ZipCode of string

    /// Después, defina un tipo donde ZipCode sea opcional.
    type Customer = { ZipCode: ZipCode option }

    /// Después, defina un tipo de interfaz que represente un objeto para calcular la zona de envío del código postal del cliente,
    /// especificando implementaciones para los métodos abstractos 'getState' y 'getShippingZone'.
    type ShippingCalculator =
        abstract GetState : ZipCode -> string option
        abstract GetShippingZone : string -> int

    /// Después, calcule una zona de envío para un cliente con una instancia de la calculadora.
    /// Aquí se utilizan combinadores en el módulo Option para permitir que una canalización funcional
    /// transforme datos con valores opcionales.
    let CustomerShippingZone (calculator: ShippingCalculator, customer: Customer) =
        customer.ZipCode
        |> Option.bind calculator.GetState
        |> Option.map calculator.GetShippingZone


/// Las unidades de medida son una forma de anotar tipos numéricos primitivos con seguridad de tipos.
/// Después, puede realizar operaciones aritméticas con seguridad de tipos en estos valores.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/units-of-measure
module UnitsOfMeasure =

    /// Primero, abra una colección de nombres de unidad comunes
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    /// Defina una constante dividida en unidades
    let sampleValue1 = 1600.0<meter>

    /// Después, defina un nuevo tipo de unidad
    [<Measure>]
    type mile =
        /// Factor de conversión de millas a metros.
        static member asMeter = 1609.34<meter/mile>

    /// Defina una constante dividida en unidades
    let sampleValue2  = 500.0<mile>

    /// Calcular constante del sistema métrico
    let sampleValue3 = sampleValue2 * mile.asMeter

    // Los valores que usan unidades de medida se pueden usar simplemente como tipo numérico primitivo para cosas como la impresión.
    printfn "After a %f race I would walk %f miles which would be %f meters" sampleValue1 sampleValue2 sampleValue3


/// Las clases son una forma de definir tipos de objeto nuevos en F# y admiten construcciones orientadas a objetos estándar.
/// Pueden tener una gran variedad de miembros (métodos, propiedades, eventos, etc.)
///
/// Para obtener más información sobre las clases, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/classes
///
/// Para obtener más información sobre miembros, vea https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/members
module DefiningClasses =

    /// Clase Vector bidimensional sencilla.
    ///
    /// El constructor de la clase está en la primera línea
    /// y toma dos argumentos: dx y dy, ambos de tipo "double".
    type Vector2D(dx : double, dy : double) =

        /// Este campo interno almacena la longitud del vector, que se calcula cuando
        /// se construye el objeto
        let length = sqrt (dx*dx + dy*dy)

        // 'this' especifica un nombre para el propio identificador del objeto.
        // En los métodos de instancia, debe aparecer delante del nombre del miembro.
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        /// Este miembro es un método. Los miembros anteriores eran propiedades.
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    /// Así es cómo se crea una instancia de la clase Vector2D.
    let vector1 = Vector2D(3.0, 4.0)

    /// Obtener un nuevo objeto de vector a escala sin modificar el objeto original.
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f\nLength of vector2: %f" vector1.Length vector2.Length


/// Las clases genéricas permiten definir tipos con respecto a un conjunto de parámetros de tipo.
/// En el siguiente código, 'T es el parámetro de tipo para la clase.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/generics/
module DefiningGenericClasses =

    type StateTracker<'T>(initialElement: 'T) =

        /// Este campo interno almacena los estados en una lista.
        let mutable states = [ initialElement ]

        /// Agregar un nuevo elemento a la lista de estados.
        member this.UpdateState newState =
            states <- newState :: states  // Use el operador "<-" para mutar el valor.

        /// Obtener la lista completa de estados históricos.
        member this.History = states

        /// Obtener el último estado.
        member this.Current = states.Head

    /// Una instancia 'int' de la clase del rastreador de estados. Observe que se ha inferido el parámetro de tipo.
    let tracker = StateTracker 10

    // Agregar un estado
    tracker.UpdateState 17


/// Las interfaces son tipos de objeto que solo tienen miembros "abstract".
/// Los tipos de objeto y las expresiones de objeto pueden implementar interfaces.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/interfaces
module ImplementingInterfaces =

    /// Este es un tipo que implementa IDisposable.
    type ReadFile() =

        let file = new System.IO.StreamReader("readme.txt")

        member this.ReadLine() = file.ReadLine()

        // Esta es la implementación de los miembros de IDisposable.
        interface System.IDisposable with
            member this.Dispose() = file.Close()


    /// Este es un objeto que implementa IDisposable mediante una expresión de objeto
    /// A diferencia de otros lenguajes, como C# o Java, no es necesaria una nueva definición de tipo
    /// para implementar una interfaz.
    let interfaceImplementation =
        { new System.IDisposable with
            member this.Dispose() = printfn "disposed" }


/// La biblioteca FSharp.Core define un intervalo de funciones de procesamiento paralelo. Aquí
/// se usan algunas funciones de procesamiento paralelo en matrices.
///
/// Para obtener más información, vea: https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/array.parallel-module-%5Bfsharp%5D
module ParallelArrayProgramming =

    /// Primero, una matriz de entradas.
    let oneBigArray = [| 0 .. 100000 |]

    // Después, defina una función que realice algunos cálculos con gran consumo de CPU.
    let rec computeSomeFunction x =
        if x <= 2 then 1
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)

    // Después, realice una asignación en paralelo en una matriz de entrada grande.
    let computeResults() =
        oneBigArray
        |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    // Después, imprima los resultados.
    printfn "Parallel computation results: %A" (computeResults())



/// Los eventos son algo habitual en la programación para .NET, especialmente con aplicaciones de WinForms o WPF.
///
/// Para obtener más información, vea: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/members/events
module Events =

    /// Primero, cree una instancia del objeto Event que conste de un punto de suscripción (event.Publish) y un desencadenador de eventos (event.Trigger).
    let simpleEvent = new Event<int>()

    // Después, agregue un controlador al evento.
    simpleEvent.Publish.Add(
        fun x -> printfn "this handler was added with Publish.Add: %d" x)

    // Después, desencadene el evento.
    simpleEvent.Trigger(5)

    // Después, cree una instancia de Event que siga la convención estándar de .NET: (sender, EventArgs).
    let eventForDelegateType = new Event<EventHandler, EventArgs>()

    // Después, agregue un controlador para este nuevo evento.
    eventForDelegateType.Publish.AddHandler(
        EventHandler(fun _ _ -> printfn "this handler was added with Publish.AddHandler"))

    // Después, desencadene este evento (tenga en cuenta que el argumento sender debe estar establecido).
    eventForDelegateType.Trigger(null, EventArgs.Empty)



#if COMPILED
module BoilerPlateForForm =
    [<System.STAThread>]
    do ()
    do System.Windows.Forms.Application.Run()
#endif
