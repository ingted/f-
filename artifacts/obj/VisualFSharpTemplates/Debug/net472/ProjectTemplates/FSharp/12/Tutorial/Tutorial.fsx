// Cet exemple est destiné à vous montrer les différents éléments du langage F#.
//
// *******************************************************************************************************
//   Pour exécuter le code dans F# Interactive, mettez en surbrillance une portion du code, puis appuyez sur Alt+Entrée ou cliquez avec le bouton droit,
//   puis sélectionnez Exécuter en mode interactif.  Pour ouvrir la fenêtre F# Interactive, accédez au menu Affichage.
// *******************************************************************************************************
//
// Pour en savoir plus sur F#, consultez :
//     https://fsharp.org
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/
//
// Pour afficher ce didacticiel au format documentation, consultez :
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/tour
//
// Pour en savoir plus sur la programmation F# appliquée, utilisez
//     https://fsharp.org/guides/enterprise/
//     https://fsharp.org/guides/cloud/
//     https://fsharp.org/guides/web/
//     https://fsharp.org/guides/data-science/
//
// Pour installer Visual F# Power Tools, utilisez
//     'Outils' --> 'Extensions et mises à jour' --> `En ligne` et rechercher
//
// Pour consulter d'autres modèles d'utilisation du langage F#, cliquez sur Modèles en ligne dans Visual Studio,
//     'Nouveau projet' --> 'Modèles en ligne'

// F# prend en charge trois genres de commentaires :

//  1. Commentaires avec double barre oblique (utilisés dans la plupart des cas).
(*  2. Commentaires de bloc de style ML (rarement utilisés). *)
/// 3. Commentaires avec triple barre oblique (utilisés pour documenter les fonctions, les types, etc.).
///    Ils apparaissent sous forme de texte quand vous pointez sur un élément décoré avec ces commentaires.
///
///    Ils prennent également en charge les commentaires XML de style .NET, ce qui vous permet de générer une documentation de référence.
///    Les éditeurs tels que Visual Studio peuvent également extraire des informations à partir de ces commentaires.
///    Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/xml-documentation


// Ouvrir des espaces de noms à l'aide du mot clé 'open'.
//
// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/import-declarations-the-open-keyword
open System


/// Un module est un regroupement d’éléments de code F#, comme des valeurs, des types et des valeurs de fonction.
/// Le regroupement du code dans les modules permet de conserver le code associé ensemble et d'éviter les conflits de noms dans votre programme.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/modules
module IntegersAndNumbers =

    /// Exemple d'entier.
    let sampleInteger = 176

    /// Exemple de nombre à virgule flottante.
    let sampleDouble = 4.1

    /// Nouveau nombre calculé par une opération arithmétique. Les types numériques sont convertis à l'aide des
    /// fonctions 'int', 'double', etc.
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    /// Liste des nombres de 0 à 99.
    let sampleNumbers = [ 0 .. 99 ]

    /// Liste de tous les tuples contenant tous les nombres de 0 à 99 et leur carré.
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // La ligne suivante imprime une liste comprenant des tuples, en utilisant '%A' pour l'impression générique.
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfSquares

    // Exemple d'entier avec une annotation de type.
    let sampleInteger3: int = 1


/// Les valeurs en F# sont immuables par défaut. Elles ne peuvent pas être changées
/// durant l'exécution d'un programme, sauf si elles sont explicitement marquées comme mutables.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/values/index#why-immutable
module Immutability =

    /// Le fait de lier une valeur à un nom au moyen de 'let' la rend non modifiable.
    ///
    /// La compilation de la deuxième ligne de code échoue, car 'number' est non modifiable et lié.
    /// La redéfinition de 'number' en une valeur différente n'est pas autorisée dans F#.
    let number = 2
    // let number = 3

    /// Liaison mutable. Obligatoire pour muter la valeur de 'otherNumber'.
    let mutable otherNumber = 2

    printfn "'otherNumber' is %d" otherNumber

    // En cas de mutation d'une valeur, utilisez '<-' pour assigner une nouvelle valeur.
    //
    // Vous ne pouvez pas utiliser '=' ici à cet effet, car il est utilisé pour l'égalité
    // ou autres contextes tels que 'let' ou 'module'
    otherNumber <- otherNumber + 1

    printfn "'otherNumber' changed to be %d" otherNumber


/// La programmation F# consiste en grande partie à définir des fonctions qui transforment des données d'entrée pour produire des
/// résultats utiles.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/
module BasicFunctions =

    /// Utilisez 'let' pour définir une fonction. Celle-ci accepte un argument entier et retourne un entier.
    /// Les parenthèses sont facultatives pour les arguments de fonction, sauf quand vous utilisez une annotation de type explicite.
    let sampleFunction1 x = x*x + 3

    /// Appliquez la fonction, en nommant le résultat de retour de la fonction à l'aide de 'let'.
    /// Le type de variable est déduit du type de retour de la fonction.
    let result1 = sampleFunction1 4573

    // Cette ligne utilise '%d' pour imprimer le résultat comme entier. Cette opération est de type sécurisé.
    // Si 'result1' n'est pas de type 'int', la compilation de la ligne échoue.
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    /// Si nécessaire, annotez le type d'un nom de paramètre en utilisant '(argument:type)'. Les parenthèses sont obligatoires.
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn "The result of applying the 2nd sample function to (7 + 4) is %d" result2

    /// Les conditions utilisent if/then/elid/elif/else.
    ///
    /// Notez que F# utilise une syntaxe prenant en charge la mise en retrait à l'aide d'espaces, comme Python.
    let sampleFunction3 x =
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)

    // Cette ligne utilise '%f' pour imprimer le résultat comme float. Comme '%d' ci-dessus, cette opération est de type sécurisé.
    printfn "The result of applying the 3rd sample function to (6.5 + 4.5) is %f" result3


/// Les booléens sont des types de données fondamentaux en F#. Voici quelques exemples illustrant des booléens et la logique conditionnelle.
///
/// Pour en savoir plus, consultez :
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/primitive-types
///     Et
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/symbol-and-operator-reference/boolean-operators
module Booleans =

    /// Les valeurs booléennes sont 'true' et 'false'.
    let boolean1 = true
    let boolean2 = false

    /// Les opérateurs sur les booléens sont 'not', '&&' et '||'.
    let boolean3 = not boolean1 && (boolean2 || false)

    // Cette ligne utilise '%b' pour imprimer une valeur booléenne. Cette opération est de type sécurisé.
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %b" boolean3


/// Les chaînes sont des types de données fondamentaux en F#. Voici quelques exemples illustrant des chaînes et la manipulation de chaînes de base.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/strings
module StringManipulation =

    /// Les chaînes utilisent des guillemets doubles.
    let string1 = "Hello"
    let string2  = "world"

    /// Les chaînes peuvent également utiliser @ pour créer un littéral de chaîne textuelle.
    /// Les caractères d'échappement tels que '\', '\n', '\t', etc. sont ainsi ignorés.
    let string3 = @"C:\Program Files\"

    /// Les littéraux de chaîne peuvent également utiliser des guillemets triples.
    let string4 = """The computer said "hello world" when I told it to!"""

    /// L'opérateur '+' est généralement utilisé pour la concaténation de chaînes.
    let helloWorld = string1 + " " + string2

    // Cette ligne utilise '%s' pour imprimer une valeur de chaîne. Cette opération est de type sécurisé.
    printfn "%s" helloWorld

    /// Les sous-chaînes utilisent la notation de l'indexeur. Cette ligne extrait les 7 premiers caractères comme sous-chaîne.
    /// Comme dans bien d'autres langages, les chaînes ont un index de base zéro en F#.
    let substring = helloWorld.[0..6]
    printfn "%s" substring


/// Les tuples sont des combinaisons simples de valeurs de données formant une valeur combinée.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/tuples
module Tuples =

    /// Tuple simple d'entiers.
    let tuple1 = (1, 2, 3)

    /// Fonction qui inverse l'ordre de deux valeurs d'un tuple.
    ///
    /// L'inférence de type F# généralise automatiquement la fonction pour qu'elle soit de type générique,
    /// ce qui signifie qu'elle peut fonctionner avec n'importe quel type.
    let swapElems (a, b) = (b, a)

    printfn "The result of swapping (1, 2) is %A" (swapElems (1,2))

    /// Tuple constitué d'un entier, d'une chaîne
    /// et d'un nombre à virgule flottante à double précision.
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A\ttuple2: %A" tuple1 tuple2

    /// Tuple simple d'entiers avec une annotation de type.
    /// Annotations de type pour les tuples qui utilisent le symbole * afin de séparer les éléments
    let tuple3: int * int = (5, 9)

    /// Les tuples sont généralement des objets, mais peuvent aussi être représentés sous forme de structs.
    ///
    /// Ils interagissent entièrement avec les structs en C# et Visual Basic .NET ; cependant,
    /// les tuples de type struct ne sont pas implicitement convertibles avec des tuples d'objet (souvent appelés tuples de référence).
    ///
    /// La compilation de la deuxième ligne ci-dessous échoue à cause de cela. Supprimez les marques de commentaire pour voir ce qui se passe.
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // Bien que vous ne puissiez pas effectuer de conversion implicite entre les tuples de type struct et les tuples de type référence,
    // vous pouvez effectuer une conversion explicite à l'aide de critères spéciaux, comme indiqué ci-dessous.
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)

    printfn "Struct Tuple: %A\nReference tuple made from the Struct Tuple: %A" sampleStructTuple (sampleStructTuple |> convertFromStructTuple)


/// Les opérateurs de canal F# ('|>', '<|', etc.) et les opérateurs de composition F# ('>>', '<<')
/// sont très utilisés de façon pour le traitement des données. Ces opérateurs sont eux-mêmes des fonctions
/// qui utilisent l'application partielle.
///
/// Pour en savoir plus sur ces opérateurs, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/#function-composition-and-pipelining
/// Pour en savoir plus sur l'application partielle, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/#partial-application-of-arguments
module PipelinesAndComposition =

    /// Met une valeur au carré.
    let square x = x * x

    /// Ajoute 1 à une valeur.
    let addOne x = x + 1

    /// Teste si une valeur entière est impaire à l'aide d'une opération modulo.
    let isOdd x = x % 2 <> 0

    /// Liste de 5 nombres. Nous reviendrons sur les listes plus tard.
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// Pour une liste d'entiers donnée, élimine les nombres pairs par filtrage,
    /// met au carré les nombres impairs résultants, puis ajoute 1 au carré des nombres impairs.
    let squareOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" numbers (squareOddValuesAndAddOne numbers)

    /// Pour écrire plus rapidement 'squareOddValuesAndAddOne', imbriquez chaque
    /// sous-résultat dans les appels de fonction.
    ///
    /// La fonction est ainsi considérablement raccourcie, mais il est difficile de voir
    /// l'ordre dans lequel les données sont traitées.
    let squareOddValuesAndAddOneNested values =
        List.map addOne (List.map square (List.filter isOdd values))

    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers (squareOddValuesAndAddOneNested numbers)

    /// Pour écrire 'squareOddValuesAndAddOne', utilisez de préférence des opérateurs de canal F#.
    /// Aucun résultat intermédiaire n'est créé, mais la syntaxe est beaucoup plus lisible
    /// que d'imbriquer des appels de fonction comme 'squareOddValuesAndAddOneNested'
    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    printfn "processing %A through 'squareOddValuesAndAddOnePipeline' produces: %A" numbers (squareOddValuesAndAddOnePipeline numbers)

    /// Vous pouvez raccourcir 'squareOddValuesAndAddOnePipeline' en déplaçant le second appel 'List.map'
    /// dans le premier en utilisant une fonction lambda.
    ///
    /// Notez que les pipelines sont également utilisés dans la fonction lambda. Les opérateurs de canal F#
    /// peuvent également être utilisés pour des valeurs uniques. Ils sont donc très efficaces dans le traitement des données.
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" numbers (squareOddValuesAndAddOneShorterPipeline numbers)

    /// Enfin, vous pouvez éliminer la nécessité d'accepter explicitement 'values' comme paramètre en utilisant '>>'
    /// pour composer les deux opérations principales : élimination des nombres pairs par filtrage, puis mise au carré et ajout d'une unité.
    /// De même, la partie 'fun x -> ...' de l'expression lambda n'est pas nécessaire, car 'x' est simplement
    /// défini dans cette portée pour pouvoir être passé à un pipeline fonctionnel. Vous pouvez donc utiliser '>>'
    /// ici aussi.
    ///
    /// Le résultat de 'squareOddValuesAndAddOneComposition' est une autre fonction qui accepte une
    /// liste d'entiers comme entrée. Si vous exécutez 'squareOddValuesAndAddOneComposition' avec une liste
    /// d'entiers, les résultats sont identiques à ceux des fonctions précédentes.
    ///
    /// C'est ce qui s'appelle la composition de fonctions. Cela vient du fait que les fonctions dans F#
    /// utilisent l'application partielle et que les types d'entrée et de sortie de chaque opération de traitement de données correspondent
    /// aux signatures des fonctions que nous utilisons.
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneComposition' produces: %A" numbers (squareOddValuesAndAddOneComposition numbers)


/// Les listes sont ordonnées, non modifiables et liées individuellement. Elles font l'objet d'une évaluation stricte.
///
/// Ce module montre différentes façons de générer et de traiter des listes à l'aide de fonctions
/// du module 'List' de la bibliothèque principale F#.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/lists
module Lists =

    /// Les listes sont définies à l'aide de [ ... ]. Il s'agit d'une liste vide.
    let list1 = [ ]

    /// Il s'agit d'une liste avec 3 éléments. ';' permet de séparer des éléments sur la même ligne.
    let list2 = [ 1; 2; 3 ]

    /// Vous pouvez également séparer des éléments en les plaçant chacun sur une ligne.
    let list3 = [
        1
        2
        3
    ]

    /// Il s'agit de la liste des entiers de 1 à 1 000
    let numberList = [ 1 .. 1000 ]

    /// Les listes peuvent également être générées par calculs. Il s'agit d'une liste contenant
    /// tous les jours de l'année.
    let daysList =
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                  yield System.DateTime(2017, month, day) ]

    // Imprimez les 5 premiers éléments de 'daysList' en utilisant 'List.take'.
    printfn "The first 5 days of 2017 are: %A" (daysList |> List.take 5)

    /// Les calculs peuvent inclure des conditions. Il s'agit d'une liste contenant les tuples
    /// qui sont les coordonnées des cases noires d'un échiquier.
    let blackSquares =
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do
                  if (i+j) % 2 = 1 then
                      yield (i, j) ]

    /// Les listes peuvent être transformées à l'aide de 'List.map' et d'autres combinateurs de programmation fonctionnelle.
    /// Cette définition produit une nouvelle liste en mettant au carré les nombres de numberList à l'aide de
    /// l'opérateur du pipeline pour passer un argument à List.map.
    let squares =
        numberList
        |> List.map (fun x -> x*x)

    /// Il existe de nombreuses autres combinaisons de listes. La combinaison suivante calcule la somme des carrés des
    /// nombres divisibles par 3.
    let sumOfSquares =
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)

    printfn "The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d" sumOfSquares


/// Les tableaux sont des collections de taille fixe et mutables d'éléments du même type.
///
/// Bien qu'ils soient semblables aux listes (prise en charge de l'énumération et combinateurs similaires pour le traitement des données),
/// ils offrent généralement une vitesse accrue et prennent en charge l'accès aléatoire rapide. Ils sont toutefois moins sécurisés du fait de leur mutabilité.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/arrays
module Arrays =

    /// Tableau vide. Notez que la syntaxe est semblable à celle des listes, mais '[| ... |]' est utilisé à la place.
    let array1 = [| |]

    /// Les tableaux sont spécifiés à l'aide de la même plage de constructions que les listes.
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// Il s'agit d'un tableau de nombres de 1 à 1 000.
    let array3 = [| 1 .. 1000 |]

    /// Il s'agit d'un tableau contenant uniquement les mots "hello" et "world".
    let array4 =
        [| for word in array2 do
               if word.Contains("l") then
                   yield word |]

    /// Il s'agit d'un tableau lancé par index, qui contient les nombres pairs de 0 à 2 000.
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// Les sous-tableaux sont extraits à l'aide de la notation de découpage.
    let evenNumbersSlice = evenNumbers.[0..500]

    /// Vous pouvez effectuer une boucle sur des tableaux et des listes à l'aide de boucles 'for'.
    for word in array4 do
        printfn "word: %s" word

    // Vous pouvez modifier le contenu d'un élément de tableau à l'aide de l'opérateur d'assignation flèche gauche.
    //
    // Pour en savoir plus sur cet opérateur, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/values/index#mutable-variables
    array2.[1] <- "WORLD!"

    /// Vous pouvez transformer des tableaux à l'aide de 'Array.map' et d'autres opérations de programmation fonctionnelle.
    /// L'opération suivante calcule la somme des longueurs des mots qui commencent par 'h'.
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn "The sum of the lengths of the words in Array 2 is: %d" sumOfLengthsOfWords


/// Les séquences sont des séries logiques d'éléments du même type. Elles sont plus générales que les listes et les tableaux.
///
/// Les séquences sont évaluées sur demande et sont réévaluées à chacune de leur itération.
/// Une séquence F# est un alias pour un System.Collections.Generic.IEnumerable .NET<'T>.
///
/// Les fonctions de traitement de séquence peuvent être appliquées aux listes et aux tableaux également.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/sequences
module Sequences =

    /// Il s'agit de la séquence vide.
    let seq1 = Seq.empty

    /// Il s'agit d'une séquence de valeurs.
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    /// Séquence à la demande de 1 à 1000.
    let numbersSeq = seq { 1 .. 1000 }

    /// Il s'agit d'une séquence produisant les mots "hello" et "world"
    let seq3 =
        seq { for word in seq2 do
                  if word.Contains("l") then
                      yield word }

    /// Cette séquence produit les nombres pairs jusqu'à 2 000.
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    /// Il s'agit d'une séquence infinie correspondant à une marche aléatoire.
    /// Cet exemple utilise yield! pour retourner chaque élément d'une sous-séquence.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// Cet exemple montre les 100 premiers éléments de la marche aléatoire.
    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList

    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk


/// Les fonctions récursives peuvent s'appeler elles-mêmes. En F#, les fonctions sont uniquement récursives
/// en cas de déclaration avec 'let rec'.
///
/// Il est recommandé d'utiliser la récursivité pour traiter des séquences ou des collections en F#.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/index#recursive-functions
module RecursiveFunctions =

    /// Cet exemple montre une fonction récursive qui calcule la factorielle d'un
    /// entier. Il utilise 'let rec' pour définir une fonction récursive.
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n-1)

    printfn "Factorial of 6 is: %d" (factorial 6)

    /// Calcule le plus grand commun diviseur de deux entiers.
    ///
    /// Comme tous les appels récursifs sont des appels terminaux,
    /// le compilateur transforme la fonction en boucle,
    /// ce qui améliore le niveau de performance et réduit la consommation de mémoire.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn "The Greatest Common Factor of 300 and 620 is %d" (greatestCommonFactor 300 620)

    /// Cet exemple calcule la somme d'une liste d'entiers à l'aide de la récursivité.
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    /// 'sumList' est converti en fonction à récursivité terminale, en utilisant une fonction d'assistance avec accumulateur de résultats.
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    /// La fonction d'assistance de récursivité terminale est appelée et fournit '0' comme accumulateur de valeurs initiales.
    /// Une telle approche est courante en F#.
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn "The sum 1-10 is %d" (sumListTailRecursive oneThroughTen)


/// Les enregistrements sont des agrégats de valeurs nommées, avec des membres facultatifs (comme des méthodes).
/// Ils ne sont pas modifiables et ont une sémantique d'égalité structurelle.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/records
module RecordTypes =

    /// Cet exemple montre comment définir un nouveau type d'enregistrement.
    type ContactCard =
        { Name     : string
          Phone    : string
          Verified : bool }

    /// Cet exemple montre comment instancier un type d'enregistrement.
    let contact1 =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false }

    /// Vous pouvez également effectuer cette opération sur la même ligne avec des séparateurs ';'.
    let contactOnSameLine = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

    /// Cet exemple montre comment utiliser "copy-and-update" sur des valeurs d'enregistrement. Il crée
    /// une nouvelle valeur d'enregistrement qui est une copie de contact1, mais qui a différentes valeurs pour
    /// les champs 'Phone' et 'Verified'.
    ///
    /// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/copy-and-update-record-expressions
    let contact2 =
        { contact1 with
            Phone = "(206) 555-0112"
            Verified = true }

    /// Cet exemple montre comment écrire une fonction qui traite une valeur d'enregistrement.
    /// Il convertit un objet 'ContactCard' en chaîne.
    let showContactCard (c: ContactCard) =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn "Alf's Contact Card: %s" (showContactCard contact1)

    /// Il s'agit d'un exemple d'enregistrement avec un membre.
    type ContactCardAlternate =
        { Name     : string
          Phone    : string
          Address  : string
          Verified : bool }

        /// Les membres peuvent implémenter des membres orientés objet.
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified)" else "") + this.Address

    let contactAlternate =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false
          Address = "111 Alf Street" }

    // Les membres sont accessibles au moyen de l'opérateur '.' sur un type instancié.
    printfn "Alf's alternate contact card is %s" contactAlternate.PrintedContactCard

    /// Les enregistrements peuvent également être représentés sous forme de structs par le biais de l'attribut 'Struct'.
    /// Cela peut s'avérer utile dans les situations où le niveau de performance des structs l'emporte
    /// sur la flexibilité des types de référence.
    [<Struct>]
    type ContactCardStruct =
        { Name     : string
          Phone    : string
          Verified : bool }


/// Les unions discriminées sont des valeurs qui peuvent correspondre à un certain nombre de formulaires ou de cas nommés.
/// Les données stockées dans les unions discriminées peuvent prendre une valeur parmi plusieurs valeurs distinctes.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/discriminated-unions
module DiscriminatedUnions =

    /// Ce qui suit représente la couleur d'une carte à jouer.
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    /// Une union discriminée peut également servir à représenter le rang d'une carte à jouer.
    type Rank =
        /// Représente le rang des cartes 2 .. 10
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        /// Les unions discriminées peuvent également implémenter des membres orientés objet.
        static member GetAllRanks() =
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]

    /// Il s'agit d'un type d'enregistrement qui combine une couleur et un rang.
    /// Il est fréquent d'utiliser à la fois des enregistrements et des unions discriminées pour représenter des données.
    type Card = { Suit: Suit; Rank: Rank }

    /// Ceci calcule une liste représentant toutes les cartes du paquet.
    let fullDeck =
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do
                  yield { Suit=suit; Rank=rank } ]

    /// Cet exemple convertit un objet 'Card' en chaîne.
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

    /// Cet exemple imprime toutes les cartes d'un jeu de cartes.
    let printAllCards() =
        for card in fullDeck do
            printfn "%s" (showPlayingCard card)

    // Les unions discriminées à cas unique sont souvent utilisées pour la modélisation de domaines. Il peut en résulter une meilleure cohérence des types
    // sur des types primitifs tels que les chaînes et les entiers.
    //
    // Les unions discriminées à cas unique ne peuvent pas être converties implicitement vers ou à partir du type qu'elles incluent dans un wrapper.
    // Par exemple, une fonction qui accepte une adresse ne peut pas accepter une chaîne comme entrée
    // ou vice versa.
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    // Vous pouvez facilement instancier une union discriminée à cas unique comme suit.
    let address = Address "111 Alf Way"
    let name = Name "Alf"
    let ssn = SSN 1234567890

    /// Quand vous avez besoin de la valeur, vous pouvez exclure la valeur sous-jacente du wrapper à l'aide d'une fonction simple.
    let unwrapAddress (Address a) = a
    let unwrapName (Name n) = n
    let unwrapSSN (SSN s) = s

    // Les fonctions d'exclusion d'un wrapper facilitent l'impression d'unions discriminées à cas unique.
    printfn "Address: %s, Name: %s, and SSN: %d" (address |> unwrapAddress) (name |> unwrapName) (ssn |> unwrapSSN)

    /// Les unions discriminées prennent également en charge les définitions récursives.
    ///
    /// Ceci représente un arbre de recherche binaire, l'un des cas étant l'arbre vide
    /// et l'autre étant un nœud avec une valeur et deux sous-arbres.
    type BST<'T> =
        | Empty
        | Node of value:'T * left: BST<'T> * right: BST<'T>

    /// Vérifiez si un élément existe dans l'arbre de recherche binaire.
    /// Effectue une recherche récursive à l'aide de critères spéciaux. Retourne true si l'élément existe ; sinon, false.
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left) // Vérifiez le sous-arbre gauche.
            else (exists item right) // Vérifiez le sous-arbre droit.

    /// Insère un élément dans l'arbre de recherche binaire.
    /// Recherche l'emplacement de l'insertion récursive à l'aide de critères spéciaux, puis insère un nouveau nœud.
    /// Si l'élément est déjà présent, rien n'est inséré.
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node // Insertion inutile, car l'élément existe déjà ; retournez le nœud.
            elif item < x then Node(x, insert item left, right) // Appelez le sous-arbre gauche.
            else Node(x, left, insert item right) // Appelez le sous-arbre droit.

    /// Les unions discriminées peuvent également être représentées sous forme de structs au moyen de l'attribut 'Struct'.
    /// Cela peut s'avérer utile dans les situations où le niveau de performance des structs l'emporte
    /// sur la flexibilité des types de référence.
    ///
    /// Cependant, retenez les deux points suivants si vous procédez de la sorte :
    ///     1. Une union discriminée struct ne peut pas être définie de manière récursive.
    ///     2. Une union discriminée struct doit avoir des noms uniques pour chacun de ses cas.
    [<Struct>]
    type Shape =
        | Circle of radius: float
        | Square of side: float
        | Triangle of height: float * width: float


/// Les critères spéciaux sont une fonctionnalité de F# qui vous permet d'utiliser des modèles
/// pour comparer des données avec une ou plusieurs structures logiques,
/// décomposer des données en parties constitutives ou extraire des informations à partir de données de plusieurs façons.
/// Vous pouvez ensuite effectuer une répartition selon la "forme" d'un modèle à l'aide de critères spéciaux.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/pattern-matching
module PatternMatching =

    /// Enregistrement contenant le nom et le prénom d'une personne
    type Person = {
        First : string
        Last  : string
    }

    /// Union discriminée de 3 genres d'employés différents
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// Comptez tout le monde sous l'employé dans la hiérarchie de gestion
    /// (employé inclus).
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(id) ->
                0
            | Manager(id, reports) ->
                reports |> List.sumBy countReports
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    /// Recherchez tous les responsables ou cadres dont le prénom est "Dave" et qui ne disposent d'aucun rapport.
    /// Le raccourci 'function' est utilisé comme expression lambda.
    let rec findDaveWithOpenPosition(emps : List<Employee>) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true // [] correspond à une liste vide.
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false) // '_' est un modèle générique qui correspond à n'importe quel élément.
                                     // Ceci permet de gérer le cas "or else".

    /// Vous pouvez également utiliser la construction de fonction raccourcie pour les critères spéciaux,
    /// ce qui peut s'avérer utile quand vous écrivez des fonctions qui utilisent l'application partielle.
    let private parseHelper f = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDateTimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    // Définissez d'autres fonctions d'analyse avec la fonction d'assistance.
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

    // Les modèles actifs sont une autre construction efficace à utiliser avec les critères spéciaux.
    // Ils permettent de partitionner des données d'entrée dans des formulaires personnalisés, en les décomposant au niveau du site d'appel de correspondance au modèle.
    //
    // Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/active-patterns
    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    /// Les critères spéciaux avec le mot clé 'function' et les modèles actifs ressemblent souvent à ceci.
    let printParseResult = function
        | Int x -> printfn "%d" x
        | Double x -> printfn "%f" x
        | Date d -> printfn "%s" (d.ToString())
        | TimeSpan t -> printfn "%s" (t.ToString())
        | _ -> printfn "Nothing was parse-able!"

    // Appelez l'imprimante avec des valeurs différentes à analyser.
    printParseResult "12"
    printParseResult "12.045"
    printParseResult "12/28/2016"
    printParseResult "9:01PM"
    printParseResult "banana!"


/// Les valeurs d'option sont tout type de valeur marquée avec 'Some' ou 'None'.
/// Elles sont très utilisées dans le code F# pour représenter les cas où de nombreux autres
/// langages utilisent des références null.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/options
module OptionValues =

    /// Commencez par définir un code postal au moyen d'une union discriminée à cas unique.
    type ZipCode = ZipCode of string

    /// Définissez ensuite un type où ZipCode est facultatif.
    type Customer = { ZipCode: ZipCode option }

    /// Ensuite, définissez un type d'interface qui représente un objet pour calculer la zone d'expédition correspondant au code postal du client,
    /// en fonction des implémentations des méthodes abstraites 'getState' et 'getShippingZone'.
    type ShippingCalculator =
        abstract GetState : ZipCode -> string option
        abstract GetShippingZone : string -> int

    /// Ensuite, calculez une zone d'expédition pour un client à l'aide d'une instance de calculatrice.
    /// Des combinateurs du module Option sont utilisés pour permettre à un pipeline fonctionnel de
    /// transformer les données avec Optionals.
    let CustomerShippingZone (calculator: ShippingCalculator, customer: Customer) =
        customer.ZipCode
        |> Option.bind calculator.GetState
        |> Option.map calculator.GetShippingZone


/// Les unités de mesure sont un moyen d'annoter les types numériques primitifs de manière sécurisée pour les types.
/// Vous pouvez ensuite effectuer des opérations arithmétiques de type sécurisé sur ces valeurs.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/units-of-measure
module UnitsOfMeasure =

    /// Pour commencer, ouvrez une collection de noms d'unité courants
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    /// Définissez une constante unifiée
    let sampleValue1 = 1600.0<meter>

    /// Ensuite, définissez un nouveau type d'unité
    [<Measure>]
    type mile =
        /// Facteur de conversion mile en mètre.
        static member asMeter = 1609.34<meter/mile>

    /// Définissez une constante unifiée
    let sampleValue2  = 500.0<mile>

    /// Calculez la constante de système métrique
    let sampleValue3 = sampleValue2 * mile.asMeter

    // Les valeurs avec des unités de mesure s'utilisent de la même façon que le type numérique primitif dans des opérations comme l'impression.
    printfn "After a %f race I would walk %f miles which would be %f meters" sampleValue1 sampleValue2 sampleValue3


/// Les classes sont un moyen de définir de nouveaux types d'objet en F#. Elles prennent en charge les constructions orientées objet standard.
/// Elles peuvent avoir différents membres (méthodes, propriétés, événements, etc.)
///
/// Pour en savoir plus sur les classes, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/classes
///
/// Pour en savoir plus sur les membres, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/members
module DefiningClasses =

    /// Classe Vector à deux dimensions simple.
    ///
    /// Le constructeur de la classe est sur la première ligne
    /// et accepte deux arguments : dx et dy (tous deux de type 'double').
    type Vector2D(dx : double, dy : double) =

        /// Ce champ interne stocke la longueur du vecteur, calculée quand
        /// l'objet est construit
        let length = sqrt (dx*dx + dy*dy)

        // 'this' spécifie un nom pour l'auto-identificateur de l'objet.
        // Dans les méthodes d'instance, il doit apparaître avant le nom du membre.
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        /// Ce membre est une méthode. Les membres précédents étaient des propriétés.
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    /// Voici comment instancier la classe Vector2D.
    let vector1 = Vector2D(3.0, 4.0)

    /// Obtenez un nouvel objet vector mis à l'échelle, sans modifier l'objet d'origine.
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f\nLength of vector2: %f" vector1.Length vector2.Length


/// Les classes génériques autorisent la définition des types par rapport à un jeu de paramètres de type.
/// Dans ce qui suit, 'T est le paramètre de type pour la classe.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/generics/
module DefiningGenericClasses =

    type StateTracker<'T>(initialElement: 'T) =

        /// Ce champ interne stocke les états dans une liste.
        let mutable states = [ initialElement ]

        /// Ajoutez un nouvel élément à la liste d'états.
        member this.UpdateState newState =
            states <- newState :: states  // utilisez l'opérateur '<-' pour muter la valeur.

        /// Obtenez la liste complète des états historiques.
        member this.History = states

        /// Obtenez le dernier état.
        member this.Current = states.Head

    /// Instance 'int' de la classe de suivi des états. Notez que le paramètre de type est déduit.
    let tracker = StateTracker 10

    // Ajouter un état
    tracker.UpdateState 17


/// Les interfaces sont des types d'objet avec des membres 'abstract' uniquement.
/// Les types et expressions d'objet peuvent implémenter des interfaces.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/interfaces
module ImplementingInterfaces =

    /// Type qui implémente IDisposable.
    type ReadFile() =

        let file = new System.IO.StreamReader("readme.txt")

        member this.ReadLine() = file.ReadLine()

        // Implémentation de membres IDisposable.
        interface System.IDisposable with
            member this.Dispose() = file.Close()


    /// Objet qui implémente IDisposable à l'aide d'une expression d'objet
    /// Contrairement à d'autres langages tels que C# ou Java, une nouvelle définition de type n'est pas nécessaire
    /// pour implémenter une interface.
    let interfaceImplementation =
        { new System.IDisposable with
            member this.Dispose() = printfn "disposed" }


/// La bibliothèque FSharp.Core définit une plage de fonctions de traitement parallèle. Ici
/// vous utilisez des fonctions pour le traitement parallèle des tableaux.
///
/// Pour en savoir plus, consultez : https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/array.parallel-module-%5Bfsharp%5D
module ParallelArrayProgramming =

    /// Tout d'abord, un tableau d'entrées.
    let oneBigArray = [| 0 .. 100000 |]

    // Ensuite, définissez une fonction qui effectue un calcul nécessitant une utilisation intensive du processeur.
    let rec computeSomeFunction x =
        if x <= 2 then 1
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)

    // Ensuite, effectuez un mappage parallèle sur un grand tableau d'entrée.
    let computeResults() =
        oneBigArray
        |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    // Ensuite, imprimez les résultats.
    printfn "Parallel computation results: %A" (computeResults())



/// Les événements sont un idiome courant de la programmation .NET, en particulier avec les applications WinForms ou WPF.
///
/// Pour en savoir plus, consultez : https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/members/events
module Events =

    /// Pour commencer, créez une instance d'objet Event qui se compose d'un point d'abonnement (event.Publish) et d'un déclencheur d'événements (event.Trigger).
    let simpleEvent = new Event<int>()

    // Ensuite, ajoutez un gestionnaire à l'événement.
    simpleEvent.Publish.Add(
        fun x -> printfn "this handler was added with Publish.Add: %d" x)

    // Ensuite, déclenchez l'événement.
    simpleEvent.Trigger(5)

    // Ensuite, créez une instance d'événement qui respecte la convention .NET standard : (sender, EventArgs).
    let eventForDelegateType = new Event<EventHandler, EventArgs>()

    // Ensuite, ajoutez un gestionnaire à ce nouvel événement.
    eventForDelegateType.Publish.AddHandler(
        EventHandler(fun _ _ -> printfn "this handler was added with Publish.AddHandler"))

    // Ensuite, déclenchez cet événement (notez que l'argument sender doit être défini).
    eventForDelegateType.Trigger(null, EventArgs.Empty)



#if COMPILED
module BoilerPlateForForm =
    [<System.STAThread>]
    do ()
    do System.Windows.Forms.Application.Run()
#endif
