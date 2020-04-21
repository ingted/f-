// Esta amostra guiará você pelos elementos da linguagem F#.
//
// *******************************************************************************************************
//   Para executar o código no F# Interativo, realce uma seção de código e pressione Alt-Enter ou clique com botão direito do mouse
//   e selecione "Executar em Interativo".  Você pode abrir a janela F# Interativo no menu "Exibir".
// *******************************************************************************************************
//
// Para obter mais informações sobre F#, consulte:
//     https://fsharp.org
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/
//
// Para ver este tutorial em forma de documentação, consulte:
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/tour
//
// Para saber mais sobre a programação F# aplicada, use
//     https://fsharp.org/guides/enterprise/
//     https://fsharp.org/guides/cloud/
//     https://fsharp.org/guides/web/
//     https://fsharp.org/guides/data-science/
//
// Para instalar o Visual F# Power Tools, use
//     'Ferramentas' --> 'Extensões e Atualizações' --> `Online` e pesquise
//
// Para obter modelos adicionais a serem usados com F#, consulte 'Modelos online' no Visual Studio,
//     'Novo projeto --> 'Modelos online'

// F# dá suporte a três tipos de comentários:

//  1. Comentários de barra dupla. São usados na maioria das situações.
(*  2. Comentários de bloco em estilo de ML. Eles não são usados com muita frequência. *)
/// 3. Comentários de barra tripla. São usados para funções de documentação, tipos, etc.
///    Eles aparecerão como texto quando você passar o mouse sobre algo decorado com esses comentários.
///
///    Eles também dão suporte a comentários XML em estilo .NET, que permitem que você gere documentação de referência,
///    além de permitirem que editores (como o Visual Studio) extraiam informações deles.
///    Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/xml-documentation


// Abra os namespaces usando a palavra-chave 'open'.
//
// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/import-declarations-the-open-keyword
open System


/// Um módulo é um agrupamento de código F#, assim como valores, valores de função e tipos.
/// Agrupar código em módulos ajuda a manter o código relacionado junto e ajuda a evitar conflitos de nome em seu programa.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/modules
module IntegersAndNumbers =

    /// Este é um inteiro de exemplo.
    let sampleInteger = 176

    /// Esta é uma amostra de número de ponto flutuante.
    let sampleDouble = 4.1

    /// Isso computou um novo número por meio de alguma aritmética. Tipos numéricos são convertidos usando
    /// funções 'int', 'double' e assim por diante.
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    /// Esta é uma lista de números de 0 a 99.
    let sampleNumbers = [ 0 .. 99 ]

    /// Isso é uma lista de todas as tuplas contendo todos os números de 0 a 99 e seus quadrados.
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // A próxima linha imprime uma lista que inclui tuplas, usando '%A' para impressão genérica.
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfSquares

    // Este é um inteiro de exemplo com uma anotação de tipo
    let sampleInteger3: int = 1


/// Os valores em F# são imutáveis por padrão. Eles não podem ser alterados
/// no decorrer da execução de um programa a menos que explicitamente marcados como mutáveis.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/values/index#why-immutable
module Immutability =

    /// Associar um valor a um nome via 'let' o torna imutável.
    ///
    /// A compilação da segunda linha de código falha porque 'number' é imutável e limitado.
    /// Não é permitido redefinir 'number' para um valor diferente em F#.
    let number = 2
    // let number = 3

    /// Uma associação mutável. Isso é necessário para que se possa modificar o valor de 'otherNumber'.
    let mutable otherNumber = 2

    printfn "'otherNumber' is %d" otherNumber

    // Ao converter um valor, use '<-' para atribuir um novo valor.
    //
    // Você não pode usar '=' aqui para essa finalidade, já que ele é usado para igualdade
    // ou outros contextos como 'let' ou 'module'
    otherNumber <- otherNumber + 1

    printfn "'otherNumber' changed to be %d" otherNumber


/// Grande parte da programação F# consiste em definir funções que transformam os dados de entrada para produzir
/// resultados úteis.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/
module BasicFunctions =

    /// Use 'let' para definir uma função. Ele aceita um argumento inteiro e retorna um inteiro.
    /// Parênteses são opcionais para os argumentos da função, exceto quando você usa uma anotação de tipo explícito.
    let sampleFunction1 x = x*x + 3

    /// Aplique a função, nomeando o resultado de retorno de função usando 'let'.
    /// O tipo de variável é deduzido do tipo de retorno de função.
    let result1 = sampleFunction1 4573

    // Esta linha usa '%d' para imprimir o resultado como um inteiro. Isso é fortemente tipado.
    // Se 'result1' não fosse do tipo 'int', a linha falharia na compilação.
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    /// Quando necessário, anote o tipo de um nome de parâmetro usando '(argument:type)'. É necessário usar parênteses.
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn "The result of applying the 2nd sample function to (7 + 4) is %d" result2

    /// Condicionais usam if/then/elid/elif/else.
    ///
    /// Observe que F# usa sintaxe com reconhecimento de recuo de espaço em branco, semelhante a linguagens como Python.
    let sampleFunction3 x =
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)

    // Esta linha usa '%f' para imprimir o resultado como um float. Como em '%d' acima, isso é fortemente tipado.
    printfn "The result of applying the 3rd sample function to (6.5 + 4.5) is %f" result3


/// Boolianos são tipos de dados fundamentais em F#. Aqui estão alguns exemplos de Boolianos e lógica condicional.
///
/// Para saber mais, acesse:
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/primitive-types
///     E
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/symbol-and-operator-reference/boolean-operators
module Booleans =

    /// Valores booliano são 'true' e 'false'.
    let boolean1 = true
    let boolean2 = false

    /// Operadores em boolianos são 'not', '&&' e '||'.
    let boolean3 = not boolean1 && (boolean2 || false)

    // Esta linha usa '%b' para imprimir um valor booliano. Isso é fortemente tipado.
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %b" boolean3


/// Cadeias de caracteres são tipos de dados fundamentais em F#. Aqui estão alguns exemplos de Cadeias de caracteres e a manipulação básicas de Cadeia de caracteres.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/strings
module StringManipulation =

    /// Cadeias de caracteres usam aspas duplas.
    let string1 = "Hello"
    let string2  = "world"

    /// Cadeias de caracteres também podem usar @ para criar um literal de cadeia de caracteres textual.
    /// Isso vai ignorar caracteres de escapada como '\', '\n', '\t', etc.
    let string3 = @"C:\Program Files\"

    /// Literais de cadeia de caracteres também podem usar aspas triplas.
    let string4 = """The computer said "hello world" when I told it to!"""

    /// A concatenação de cadeia de caracteres normalmente é feita com o operador '+'.
    let helloWorld = string1 + " " + string2

    // Esta linha usa '%s' para imprimir um valor de cadeia de caracteres. Isso é fortemente tipado.
    printfn "%s" helloWorld

    /// Subcadeias de caracteres usam a notação de indexador. Essa linha extrai os sete primeiros caracteres como uma subcadeia de caracteres.
    /// Observe que, como muitas linguagens, Cadeias de Caracteres são indexadas com zero em F#.
    let substring = helloWorld.[0..6]
    printfn "%s" substring


/// Tuplas são combinações simples de valores de dados em um valor combinado.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/tuples
module Tuples =

    /// Uma tupla simples de inteiros.
    let tuple1 = (1, 2, 3)

    /// Uma função que troca a ordem de dois valores em uma tupla.
    ///
    /// Inferência de Tipos F# generalizará automaticamente a função para ter um tipo genérico,
    /// significando que ele funcionará com qualquer tipo.
    let swapElems (a, b) = (b, a)

    printfn "The result of swapping (1, 2) is %A" (swapElems (1,2))

    /// Uma tupla consistindo em um inteiro, uma cadeia de caracteres,
    /// e um número de ponto flutuante de precisão dupla.
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A\ttuple2: %A" tuple1 tuple2

    /// Uma tupla simples de números inteiros com uma anotação de tipo.
    /// As anotações de tipo para tuplas usam o símbolo * para separar elementos
    let tuple3: int * int = (5, 9)

    /// Tuplas normalmente são objetos, mas também podem ser representados como structs.
    ///
    /// Esses interoperam completamente com structs em C# e Visual Basic.NET; entretanto,
    /// tuplas de struct não são implicitamente conversíveis com tuplas de objeto (geralmente chamadas de tuplas de referência).
    ///
    /// A compilação da segunda linha abaixo falhará por causa disso. Remova a marca de comentário para ver o que acontece.
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // Embora não seja possível converter implicitamente entre tuplas de struct e tuplas de referência,
    // você pode converter explicitamente via correspondência de padrões, conforme demonstrado abaixo.
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)

    printfn "Struct Tuple: %A\nReference tuple made from the Struct Tuple: %A" sampleStructTuple (sampleStructTuple |> convertFromStructTuple)


/// Os operadores de pipe F# ('|>', '<|', etc.) e os operadores de composição F# ('>>', '<<')
/// são usadas extensivamente durante o processamento de dados. Esses operadores são funções
/// que fazem uso do Aplicativo Parcial.
///
/// Para saber mais sobre esses operadores, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/#function-composition-and-pipelining
/// Para saber mais sobre Aplicativo Parcial, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/#partial-application-of-arguments
module PipelinesAndComposition =

    /// Eleva um valor ao quadrado.
    let square x = x * x

    /// Adiciona 1 a um valor.
    let addOne x = x + 1

    /// Testa se um valor inteiro for ímpar por meio do módulo.
    let isOdd x = x % 2 <> 0

    /// Uma lista de cinco números. Mais sobre listas posteriormente.
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// Dada uma lista de inteiros, ele filtra os números pares,
    /// eleva os ímpares resultantes ao quadrado e adiciona 1 aos ímpares elevados ao quadrado.
    let squareOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" numbers (squareOddValuesAndAddOne numbers)

    /// Uma maneira mais curta para gravar 'squareOddValuesAndAddOne' é aninhar cada
    /// sub-resultado em função invoca a si mesmo.
    ///
    /// Isso faz com que a função fique muito menor, mas é difícil ver a
    /// ordem em que os dados são processados.
    let squareOddValuesAndAddOneNested values =
        List.map addOne (List.map square (List.filter isOdd values))

    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers (squareOddValuesAndAddOneNested numbers)

    /// Uma maneira preferencial para gravar 'squareOddValuesAndAddOne' é usar operadores de pipe F#.
    /// Isso permite que você evite criar resultados intermediários, mas é muito mais legível
    /// que a função de aninhamento invoca como 'squareOddValuesAndAddOneNested'
    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    printfn "processing %A through 'squareOddValuesAndAddOnePipeline' produces: %A" numbers (squareOddValuesAndAddOnePipeline numbers)

    /// Você pode reduzir 'squareOddValuesAndAddOnePipeline' movendo a segunda chamada `List.map`
    /// no primeiro, usando uma Função Lambda.
    ///
    /// Observe que pipelines também estão sendo usados dentro da função lambda. Operadores de pipe F#
    /// podem ser usados para valores únicos também. Isso os torna muito eficientes para o processamento de dados.
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" numbers (squareOddValuesAndAddOneShorterPipeline numbers)

    /// Por fim, você pode eliminar a necessidade de incluir explicitamente 'valores' como um parâmetro usando '>>'
    /// para compor as duas principais operações: filtrar números pares e, em seguida, elevar ao quadrado e adicionar um.
    /// Da mesma forma, o bit 'fun x -> ...' da expressão lambda também não é necessário porque 'x' é simplesmente
    /// sendo definido nesse escopo para que possa ser passada a um pipeline funcional. Portanto, '>>' pode ser usado
    /// lá também.
    ///
    /// O resultado de 'squareOddValuesAndAddOneComposition' é em si outra função que leva um
    /// lista de inteiros como sua entrada. Se você executar 'squareOddValuesAndAddOneComposition' com uma lista
    /// de inteiros, você observará que ela produz os mesmos resultados que as funções anteriores.
    ///
    /// Isso está usando o que é conhecido como composição de função. Isso é possível porque funções em F#
    /// use Aplicativo Parcial e os tipos de entrada e saída de cada correspondência de operação de processamento de dados
    /// as assinaturas das funções que estamos usando.
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneComposition' produces: %A" numbers (squareOddValuesAndAddOneComposition numbers)


/// As listas são listas ordenadas, imutáveis, vinculadas de modo único. Elas são adiantadas em sua avaliação.
///
/// Este módulo mostra várias formas de gerar listas e listas de processo com algumas funções
/// no módulo 'Lista' na Biblioteca Principal de F#.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/lists
module Lists =

    /// As listas são definidas usando [ ... ]. Esta é uma lista vazia.
    let list1 = [ ]

    /// Esta é uma lista com 3 elementos. ';' é usado para separar elementos na mesma linha.
    let list2 = [ 1; 2; 3 ]

    /// Você também pode separar elementos colocando-os em suas próprias linhas.
    let list3 = [
        1
        2
        3
    ]

    /// Esta é uma lista de inteiros de 1 a 1.000
    let numberList = [ 1 .. 1000 ]

    /// Listas também podem ser geradas pelos cálculos. Esta é uma lista contendo
    /// todos os dias do ano.
    let daysList =
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                  yield System.DateTime(2017, month, day) ]

    // Imprima os primeiros cinco elementos de 'daysList' usando 'List.take'.
    printfn "The first 5 days of 2017 are: %A" (daysList |> List.take 5)

    /// Cálculos podem incluir condicionais. Esta é uma lista contendo as tuplas
    /// que são as coordenadas dos quadrados pretos em um tabuleiro de xadrez.
    let blackSquares =
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do
                  if (i+j) % 2 = 1 then
                      yield (i, j) ]

    /// Listas podem ser transformadas usando 'List. map' e outros combinadores de programação funcional.
    /// Essa definição produz uma nova lista ao elevar ao quadrado os números em numberList, usando o pipeline
    /// operador para passar um argumento para List.map.
    let squares =
        numberList
        |> List.map (fun x -> x*x)

    /// Há muitas outras combinações de lista. O exemplo a seguir computa a soma dos quadrados dos
    /// números divisíveis por 3.
    let sumOfSquares =
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)

    printfn "The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d" sumOfSquares


/// Matrizes são coleções de tamanho fixo, mutáveis de elementos do mesmo tipo.
///
/// Embora elas sejam semelhantes às Listas (eles dão suporte à enumeração e têm combinadores semelhantes para processamento de dados),
/// elas geralmente são mais rápidas e dão suporte ao acesso aleatório rápido. Isso vem com o custo de ser menos seguro por ser mutável.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/arrays
module Arrays =

    /// Esta é a matriz vazia. Observe que a sintaxe é semelhante à de Listas, mas usa '[| ... |]' em vez disso.
    let array1 = [| |]

    /// Matrizes são especificadas usando o mesmo intervalo de construções usado em listas.
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// Esta é uma matriz de números de 1 a 1.000.
    let array3 = [| 1 .. 1000 |]

    /// Esta é uma matriz que contém apenas as palavras "olá" e "mundo".
    let array4 =
        [| for word in array2 do
               if word.Contains("l") then
                   yield word |]

    /// Esta é uma matriz inicializada pelo índice e que contém os números pares de 0 a 2.000.
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// Submatrizes são extraídas usando a notação de divisão.
    let evenNumbersSlice = evenNumbers.[0..500]

    /// Você pode executar um loop através de matrizes e listas usando loops 'for'.
    for word in array4 do
        printfn "word: %s" word

    // Você pode modificar o conteúdo de um elemento de matriz usando o operador de atribuição de seta para a esquerda.
    //
    // Para saber mais sobre esse operador, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/values/index#mutable-variables
    array2.[1] <- "WORLD!"

    /// Você pode transformar as matrizes usando 'Array.map' e outras operações de programação funcional.
    /// O exemplo a seguir calcula a soma dos tamanhos de palavras que começam com 'h'.
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn "The sum of the lengths of the words in Array 2 is: %d" sumOfLengthsOfWords


/// Sequências são uma série lógica de elementos, todos do mesmo tipo. Eles são um tipo mais geral que Listas e Matrizes.
///
/// As sequências são avaliada sob demanda e reavaliadas sempre que são repetidas.
/// Uma sequência de F# é um alias para um System.Collections.Generic.IEnumerable .NET<' t>.
///
/// Funções de processamento de sequência também podem ser aplicadas a matrizes e listas.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/sequences
module Sequences =

    /// Esta é a sequência vazia.
    let seq1 = Seq.empty

    /// Esta é uma sequência de valores.
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    /// Esta é uma sequência sob demanda de 1 a 1000.
    let numbersSeq = seq { 1 .. 1000 }

    /// Esta é uma sequência produzindo as palavras "olá" e "mundo"
    let seq3 =
        seq { for word in seq2 do
                  if word.Contains("l") then
                      yield word }

    /// Esta sequência produzindo os números pares até 2.000.
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    /// Esta é uma sequência infinita, que é um exame aleatório.
    /// Este exemplo usa yield! para retornar cada elemento de uma subsequência.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// Este exemplo mostra os primeiros 100 elementos do exame aleatório.
    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList

    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk


/// Funções recursivas podem chamar a si mesmas. Em F#, funções são recursivas somente
/// quando declarada usando 'let rec'.
///
/// Recursão é a maneira preferencial de processar sequências ou coleções em F#.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/index#recursive-functions
module RecursiveFunctions =

    /// Este exemplo mostra uma função recursiva que computa o fatorial de um
    /// inteiro. Ele usa 'let gra' para definir uma função recursiva.
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n-1)

    printfn "Factorial of 6 is: %d" (factorial 6)

    /// Calcula o máximo divisor comum de dois inteiros.
    ///
    /// Como todas as chamadas recursivas são chamadas tail,
    /// o compilador transformará a função em um loop,
    /// que melhora o desempenho e reduz o consumo de memória.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn "The Greatest Common Factor of 300 and 620 is %d" (greatestCommonFactor 300 620)

    /// Este exemplo calcula a soma de uma lista de inteiros usando recursão.
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    /// Isso torna a cauda de 'sumList' recursiva usando uma função auxiliar com um acumulador de resultado.
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    /// Isso invoca a cauda da função auxiliar recursiva, fornecendo '0' como um acumulador de semente.
    /// Uma abordagem como essa é comum em F#.
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn "The sum 1-10 is %d" (sumListTailRecursive oneThroughTen)


/// Registros são uma agregação de valores nomeados com membros opcionais (como métodos).
/// Eles são imutáveis e têm semântica de igualdade estrutural.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/records
module RecordTypes =

    /// Este exemplo mostra como definir um novo tipo de registro.
    type ContactCard =
        { Name     : string
          Phone    : string
          Verified : bool }

    /// Este exemplo mostra como criar uma instância de um tipo de registro.
    let contact1 =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false }

    /// Você também pode fazer isso na mesma linha com separadores ';'.
    let contactOnSameLine = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

    /// Este exemplo mostra como usar o "copiar e atualizar" em valores do Registro. Ele cria
    /// um novo valor de registro é uma cópia de contact1, mas tem valores diferentes para
    /// os campos 'Telefone' e 'Verificado'.
    ///
    /// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/copy-and-update-record-expressions
    let contact2 =
        { contact1 with
            Phone = "(206) 555-0112"
            Verified = true }

    /// Este exemplo mostra como escrever uma função que processa um valor de Registro.
    /// Converte um objeto 'ContactCard' em uma cadeia de caracteres.
    let showContactCard (c: ContactCard) =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn "Alf's Contact Card: %s" (showContactCard contact1)

    /// Este é um exemplo de um Registro com um membro.
    type ContactCardAlternate =
        { Name     : string
          Phone    : string
          Address  : string
          Verified : bool }

        /// Os membros podem implementar membros orientados a objeto.
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified)" else "") + this.Address

    let contactAlternate =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false
          Address = "111 Alf Street" }

    // Os membros são acessados por meio do operador '.' em um tipo instanciado.
    printfn "Alf's alternate contact card is %s" contactAlternate.PrintedContactCard

    /// Registros também podem ser representados como structs por meio do atributo 'Struct'.
    /// Isso é útil em situações em que o desempenho de structs é superior
    /// a flexibilidade de tipos de referência.
    [<Struct>]
    type ContactCardStruct =
        { Name     : string
          Phone    : string
          Verified : bool }


/// Uniões Discriminadas (UD) são valores que podem ser vários formulários nomeados ou casos.
/// Dados armazenados em DUs podem ser um dos vários valores distintos.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/discriminated-unions
module DiscriminatedUnions =

    /// O exemplo a seguir representa o naipe de uma carta de baralho.
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    /// Uma União Discriminada também pode ser usada para representar a classificação de uma carta de baralho.
    type Rank =
        /// Representa posição das cartas 2 .. 10
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        /// Uniões Discriminadas também podem implementar membros orientados a objeto.
        static member GetAllRanks() =
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]

    /// Este é um tipo de registro que combina um Naipe e uma Classificação.
    /// É comum usar Registros e Uniões Discriminadas ao representar dados.
    type Card = { Suit: Suit; Rank: Rank }

    /// Isto calcula uma lista que representa todas as cartas do baralho.
    let fullDeck =
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do
                  yield { Suit=suit; Rank=rank } ]

    /// Este exemplo converte um objeto 'Carta' em uma cadeia de caracteres.
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

    /// Este exemplo imprime todas as cartas de um baralho de jogo.
    let printAllCards() =
        for card in fullDeck do
            printfn "%s" (showPlayingCard card)

    // UDs de caso único são frequentemente usadas para modelagem de domínio. Isso pode significar um tipo extra de segurança para você
    // sobre tipos primitivos como cadeias de caracteres e inteiros.
    //
    // UDs de caso único não podem ser convertidas implicitamente de ou para o tipo que elas encapsulam.
    // Por exemplo, uma função que compreende um Endereço não pode aceitar uma sequência de caracteres como essa entrada,
    // ou vice-versa.
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    // Você pode facilmente criar uma instância em uma UD de único caso conforme mostrado a seguir.
    let address = Address "111 Alf Way"
    let name = Name "Alf"
    let ssn = SSN 1234567890

    /// Quando precisar do valor, você pode decodificar o valor subjacente com uma função simples.
    let unwrapAddress (Address a) = a
    let unwrapName (Name n) = n
    let unwrapSSN (SSN s) = s

    // Imprimir UDs de caso único é simples com funções não encapsuladas.
    printfn "Address: %s, Name: %s, and SSN: %d" (address |> unwrapAddress) (name |> unwrapName) (ssn |> unwrapSSN)

    /// Uniões Discriminadas também dão suporte a definições recursivas.
    ///
    /// Isso representa uma Árvore de Pesquisa Binária, com um caso sendo a árvore Vazia,
    /// e o outro sendo um Nó com um valor e duas subárvores.
    type BST<'T> =
        | Empty
        | Node of value:'T * left: BST<'T> * right: BST<'T>

    /// Verifique se um item existe na árvore de pesquisa binária.
    /// Pesquisa recursivamente usando Correspondência de Padrões. Retorna verdadeiro se existir; caso contrário, falso.
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left) // Verifique a subárvore à esquerda.
            else (exists item right) // Verifique a subárvore à direita.

    /// Insere um item na Árvore de Pesquisa Binária.
    /// Encontra o local para inserir recursivamente usando Correspondência de Padrões e, em seguida, insere um novo nó.
    /// Se o item já estiver presente, ele não insere nada.
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node // Não é preciso inseri-lo, ele já existe; retorne o nó.
            elif item < x then Node(x, insert item left, right) // Chamar subárvore à esquerda.
            else Node(x, left, insert item right) // Chamar subárvore à direita.

    /// Uniões Discriminadas também podem ser representadas como structs por meio do atributo 'Struct'.
    /// Isso é útil em situações em que o desempenho de structs é superior
    /// a flexibilidade de tipos de referência.
    ///
    /// No entanto, existem duas coisas importantes a saber ao fazer isso:
    ///     1. Uma UD struct não pode ser definida recursivamente.
    ///     2. Uma UD struct deve ter nomes exclusivos para cada um dos seus casos.
    [<Struct>]
    type Shape =
        | Circle of radius: float
        | Square of side: float
        | Triangle of height: float * width: float


/// Correspondência de padrões é um recurso do F# que permite que você utilize Padrões,
/// que são uma forma de comparar dados com uma estrutura lógica ou com estruturas,
/// decompor os dados em partes constituintes ou extrair informações de dados de diversas maneiras.
/// Em seguida, você pode expedir na "forma" de um padrão por meio da Correspondência de Padrões.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/pattern-matching
module PatternMatching =

    /// Um registro de nome e sobrenome de uma pessoa
    type Person = {
        First : string
        Last  : string
    }

    /// Uma União Discriminada de 3 tipos diferentes de funcionários
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// Conta todos abaixo do funcionário na hierarquia de gerenciamento,
    /// incluindo o funcionário.
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(id) ->
                0
            | Manager(id, reports) ->
                reports |> List.sumBy countReports
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    /// Localize todos os gerentes/executivos chamados "Dave" que não têm nenhum relatório.
    /// Isso usa a forma abreviada de 'function' como uma expressão lambda.
    let rec findDaveWithOpenPosition(emps : List<Employee>) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true // [] corresponde a uma lista vazia.
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false) // '_' é um padrão de caractere curinga que coincide com qualquer coisa.
                                     // Isso identifica o caso "ou também".

    /// Você também pode usar o constructo da função abreviada para correspondência de padrões,
    /// que é útil quando você está gravando funções que fazem uso do Aplicativo Parcial.
    let private parseHelper f = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDateTimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    // Defina mais algumas funções que são analisadas com a função auxiliar.
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

    // Padrões Ativos são outro constructo avançado para usar com correspondência de padrões.
    // Eles permitem particionar os dados de entrada em formulários personalizados, decompondo-os no local da chamada de correspondência de padrão.
    //
    // Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/active-patterns
    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    /// Correspondência de Padrões por meio de palavra-chave 'function' e Padrões Ativos geralmente têm essa aparência.
    let printParseResult = function
        | Int x -> printfn "%d" x
        | Double x -> printfn "%f" x
        | Date d -> printfn "%s" (d.ToString())
        | TimeSpan t -> printfn "%s" (t.ToString())
        | _ -> printfn "Nothing was parse-able!"

    // Chamar a impressora com alguns valores diferentes para analisar.
    printParseResult "12"
    printParseResult "12.045"
    printParseResult "12/28/2016"
    printParseResult "9:01PM"
    printParseResult "banana!"


/// Os valores de opção são qualquer tipo de valor marcado com 'Algum' ou 'Nenhum'.
/// Eles são usados extensivamente no código F# para representar os casos em que muitos outros
/// idiomas usariam referências nulas.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/options
module OptionValues =

    /// Primeiro, determine um CEP definido por meio de União Discriminada de Único Caso.
    type ZipCode = ZipCode of string

    /// Em seguida, defina um tipo em que o CEP é opcional.
    type Customer = { ZipCode: ZipCode option }

    /// Em seguida, defina um tipo de interface que representa um objeto para computar a zona de remessa para o CEP do cliente,
    /// determinadas implementações para os métodos abstratos 'getState' e 'getShippingZone'.
    type ShippingCalculator =
        abstract GetState : ZipCode -> string option
        abstract GetShippingZone : string -> int

    /// Em seguida, calcule uma zona de remessa para um cliente usando uma instância da calculadora.
    /// Isso usa combinadores no módulo Option para permitir um pipeline funcional para
    /// transformando dados com Opcionais.
    let CustomerShippingZone (calculator: ShippingCalculator, customer: Customer) =
        customer.ZipCode
        |> Option.bind calculator.GetState
        |> Option.map calculator.GetShippingZone


/// Unidades de medida são uma forma de anotar tipos numéricos primitivos de um modo fortemente tipado.
/// Então, você pode executar a aritmética fortemente tipada nesses valores.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/units-of-measure
module UnitsOfMeasure =

    /// Primeiro, abra uma coleção de nomes comuns de unidade
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    /// Definir uma constante unitizada
    let sampleValue1 = 1600.0<meter>

    /// Em seguida, defina um novo tipo de unidade
    [<Measure>]
    type mile =
        /// Fator de conversão de milha para metro.
        static member asMeter = 1609.34<meter/mile>

    /// Definir uma constante unitizada
    let sampleValue2  = 500.0<mile>

    /// Computar a constante de sistema métrico
    let sampleValue3 = sampleValue2 * mile.asMeter

    // Valores que usam Unidades de Medida podem ser usados exatamente como o tipo numérico primitivo para coisas como impressão.
    printfn "After a %f race I would walk %f miles which would be %f meters" sampleValue1 sampleValue2 sampleValue3


/// Classes são uma maneira de definir novos tipos de objetos em F# e dão suporte a constructos padrão Orientados a objeto.
/// Elas podem ter uma variedade de membros (métodos, propriedades, eventos, etc.)
///
/// Para saber mais sobre Classes, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/classes
///
/// Para saber mais sobre Membros, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/members
module DefiningClasses =

    /// Uma classe de vetor bidimensional simples.
    ///
    /// O construtor da classe está na primeira linha,
    /// e leva dois argumentos: dx e dy, ambos do tipo 'duplo'.
    type Vector2D(dx : double, dy : double) =

        /// Este campo interno armazena o comprimento do vetor, computado quando o
        /// objeto é construído
        let length = sqrt (dx*dx + dy*dy)

        // 'this' especifica um nome para o identificador automático do objeto.
        // Em métodos de instância, ele deve aparecer antes do nome do membro.
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        /// Esse membro é um método. Os membros anteriores eram propriedades.
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    /// É assim que você cria uma instância de classe Vector2D.
    let vector1 = Vector2D(3.0, 4.0)

    /// Obter um novo objeto de vetor em escala, sem modificar o objeto original.
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f\nLength of vector2: %f" vector1.Length vector2.Length


/// Classes genéricas permitem que os tipos sejam definidos em relação a um conjunto de parâmetros de tipo.
/// No exemplo a seguir, 'T é o parâmetro de tipo para a classe.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/generics/
module DefiningGenericClasses =

    type StateTracker<'T>(initialElement: 'T) =

        /// Este campo interno armazena os estados em uma lista.
        let mutable states = [ initialElement ]

        /// Adicione um novo elemento à lista de estados.
        member this.UpdateState newState =
            states <- newState :: states  // use o operador '<-' para modificar o valor.

        /// Obter a lista completa de estados históricos.
        member this.History = states

        /// Obter o estado mais recente.
        member this.Current = states.Head

    /// Uma instância ' int' da classe de controlador do estado. Observe que o parâmetro de tipo é deduzido.
    let tracker = StateTracker 10

    // Adicionar um estado
    tracker.UpdateState 17


/// As interfaces são tipos de objeto com apenas membros 'abstract'.
/// Tipos de objeto e expressões de objeto podem implementar interfaces.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/interfaces
module ImplementingInterfaces =

    /// Este é um tipo que implementa IDisposable.
    type ReadFile() =

        let file = new System.IO.StreamReader("readme.txt")

        member this.ReadLine() = file.ReadLine()

        // Essa é a implementação de membros IDisposable.
        interface System.IDisposable with
            member this.Dispose() = file.Close()


    /// Este é um objeto que implementa IDisposable por meio de uma Expressão de Objeto
    /// Diferentemente de outras linguagens, como C# ou Java, uma nova definição de tipo não é necessária
    /// para implementar uma interface.
    let interfaceImplementation =
        { new System.IDisposable with
            member this.Dispose() = printfn "disposed" }


/// A biblioteca FSharp.Core define várias funções de processamento paralelo. Aqui
/// você usa algumas funções para processamento paralelo por matrizes.
///
/// Para saber mais, acesse: https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/array.parallel-module-%5Bfsharp%5D
module ParallelArrayProgramming =

    /// Primeiro, uma matriz de entradas.
    let oneBigArray = [| 0 .. 100000 |]

    // Em seguida, defina uma função que realiza computação com uso intensivo de CPU.
    let rec computeSomeFunction x =
        if x <= 2 then 1
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)

    // Em seguida, faça um mapa paralelo por uma grande matriz de entrada.
    let computeResults() =
        oneBigArray
        |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    // Em seguida, imprima os resultados.
    printfn "Parallel computation results: %A" (computeResults())



/// Eventos são uma linguagem comum para programação em .NET, especialmente com aplicativos WinForms ou WPF.
///
/// Para saber mais, acesse: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/members/events
module Events =

    /// Primeiro, crie a instância do objeto Evento que consiste em ponto de assinatura (event.Publish) e gatilho de eventos (event.Trigger).
    let simpleEvent = new Event<int>()

    // Em seguida, adicione o manipulador ao evento.
    simpleEvent.Publish.Add(
        fun x -> printfn "this handler was added with Publish.Add: %d" x)

    // Em seguida, dispare o evento.
    simpleEvent.Trigger(5)

    // Em seguida, crie uma instância do evento que segue a convenção padrão do .NET: (sender, EventArgs).
    let eventForDelegateType = new Event<EventHandler, EventArgs>()

    // Em seguida, adicione um manipulador para este novo evento.
    eventForDelegateType.Publish.AddHandler(
        EventHandler(fun _ _ -> printfn "this handler was added with Publish.AddHandler"))

    // Em seguida, dispare esse evento (observe que o argumento do remetente deve ser definido).
    eventForDelegateType.Trigger(null, EventArgs.Empty)



#if COMPILED
module BoilerPlateForForm =
    [<System.STAThread>]
    do ()
    do System.Windows.Forms.Application.Run()
#endif
