// Bu örnek, size F# dilinin öğelerini gösterir.
//
// *******************************************************************************************************
//   Kodu F# Etkileşimli’de yürütmek için kodun bir bölümünü vurgulayın ve Alt-Enter'a basın veya sağ tıklatın
//   ve "Etkileşimlide Yürüt" seçeneğini belirleyin. F# Etkileşimli Penceresini "Görünüm" menüsünden açabilirsiniz.
// *******************************************************************************************************
//
// F# hakkında daha fazla bilgi için bkz:
//     https://fsharp.org
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/
//
// Bu öğreticiyi belge biçiminde görmek için, bkz:
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/tour
//
// Uygulamalı F# programlama hakkında daha fazla bilgi edinmek için şunu kullanın:
//     https://fsharp.org/guides/enterprise/
//     https://fsharp.org/guides/cloud/
//     https://fsharp.org/guides/web/
//     https://fsharp.org/guides/data-science/
//
// Visual F# Power Tools'u yüklemek için
//     'Araçlar' --> 'Uzantılar ve Güncelleştirmeler' --> `Çevrimiçi` seçeneğini kullanın ve arama yapın
//
// F# ile kullanabileceğiniz ek şablonlar için Visual Studio'daki 'Çevrimiçi Şablonlar'a bakın,
//     'Yeni Proje' --> 'Çevrimiçi Şablonlar'

// F# üç açıklama türünü destekler:

//  1. Çift eğik çizgili açıklamalar. Çoğu durumda bunlar kullanılır.
(*  2. ML stili Blok açıklamaları. Bunlar sık kullanılmaz. *)
/// 3. Üç eğik çizgili açıklamalar. Bunlar işlevleri, türleri vb. belgelemek için kullanılır.
///    Bu açıklamalarla belirlenmiş bir öğenin üzerine geldiğinizde, açıklamalar metin olarak görüntülenir.
///
///    Ayrıca başvuru belgeleri oluşturmanıza olanak sağlayan .NET stili XML açıklamalarını destekler,
///    bilgi ayıklamak için düzenleyicilerin (örneğin Visual Studio) kullanılmasına da olanak sağlar.
///    Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/xml-documentation


// 'Open' anahtar sözcüğünü kullanarak ad alanlarını açın.
//
// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/import-declarations-the-open-keyword
open System


/// Modül; değer, tür ve işlev değeri gibi bir F# kodu gruplandırmasıdır.
/// Kodu modüller içinde gruplandırmak ilgili kodların bir arada bulunmasını sağlar ve programınızda ad çakışmalarını önlemeye yardımcı olur.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/modules
module IntegersAndNumbers =

    /// Bu, örnek bir tamsayıdır.
    let sampleInteger = 176

    /// Bu, örnek bir kayan noktalı sayıdır.
    let sampleDouble = 4.1

    /// Bu, aritmetik kullanarak yeni bir sayı hesaplar. Sayısal türler
    /// 'int', 'double' vb. işlevler kullanılarak dönüştürülür.
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    /// Bu, 0'dan 99'a kadar olan sayıların listesidir.
    let sampleNumbers = [ 0 .. 99 ]

    /// Bu, 0'dan 99'a kadar olan sayıları ve bunların karelerini içeren bir listedir.
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // Sonraki satır genel yazdırma için '%A' kullanarak demetleri içeren bir liste yazdırır.
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfSquares

    // Bu tür açıklaması olan örnek bir tamsayıdır
    let sampleInteger3: int = 1


/// F# değerleri varsayılan olarak sabittir. Bu değerler
/// değiştirilebilir olarak açıkça işaretlenmediği sürece bir programın yürütülmesi sırasında değiştirilemez.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/values/index#why-immutable
module Immutability =

    /// Bir değeri 'let' ile bir ada bağlamak, değeri sabit yapar.
    ///
    /// 'Number' değişmez ve bağlı olduğu için ikinci kod satırı derlenemiyor.
    /// F# içinde 'number' değerini farklı bir değer olarak yeniden tanımlamaya izin verilmez.
    let number = 2
    // let number = 3

    /// Değiştirilebilir bir bağlama. Bu, 'otherNumber' değerini değiştirmek için gereklidir.
    let mutable otherNumber = 2

    printfn "'otherNumber' is %d" otherNumber

    // Bir değeri değiştirirken, yeni bir değer atamak için '<-' kullanın.
    //
    // Eşitlik amacıyla kullanıldığından, burada '=' kullanamazsınız
    // veya 'let' ya da 'module' gibi diğer bağlamlar
    otherNumber <- otherNumber + 1

    printfn "'otherNumber' changed to be %d" otherNumber


/// F# programlama çoğunlukla, giriş verilerini kullanışlı sonuçlara dönüştüren işlevleri
/// tanımlamaktan oluşur.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/
module BasicFunctions =

    /// Bir işlevi tanımlamak için 'let' kullanın. Bu, bir tamsayı bağımsız değişkenini kabul ederek bir tamsayı döndürür.
    /// İşlev bağımsız değişkenlerinde ayraçlar, açık tür ek açıklaması kullanılan durumlar dışında isteğe bağlıdır.
    let sampleFunction1 x = x*x + 3

    /// İşlev döndürme sonucunu 'let' ile adlandırarak işlevi uygulayın.
    /// Değişken türü, işlev dönüş türü olarak algılanır.
    let result1 = sampleFunction1 4573

    // Bu satır, sonucu bir tamsayı olarak yazdırmak için '%d' kullanır. Tür kullanımıyla uyumludur.
    // 'Result1' 'int' türünde değilse, satır derleme işlemi başarısız olur.
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    /// Gerekli olduğunda, '(argument:type)' kullanarak parametre adı türü için ek açıklama girin. Ayraçlar gereklidir.
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn "The result of applying the 2nd sample function to (7 + 4) is %d" result2

    /// Koşullu deyimlerde if/then/elid/elif/else kullanılır.
    ///
    /// F#'ın, Python gibi diller ile benzer şekilde, boşluk girintisini tanıyan söz dizimi kullandığını unutmayın.
    let sampleFunction3 x =
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)

    // Bu satır, sonucu kayan noktalı sayı olarak yazdırmak için '%f' kullanır. Yukarıdaki '%d' gibi bu da tür kullanımıyla uyumludur.
    printfn "The result of applying the 3rd sample function to (6.5 + 4.5) is %f" result3


/// Boole değerleri, F# içindeki temel veri türleridir. Aşağıda bazı Boole ve koşullu mantık örnekleri verilmiştir.
///
/// Daha fazla bilgi için bkz.
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/primitive-types
///     ve
///     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/symbol-and-operator-reference/boolean-operators
module Booleans =

    /// Boole değerleri şunlardır: 'true' ve 'false'.
    let boolean1 = true
    let boolean2 = false

    /// Boole değerleri üzerindeki işleçler: 'not', '&&' ve '||'.
    let boolean3 = not boolean1 && (boolean2 || false)

    // Bu satır, bir boole değeri yazdırmak için '%b' kullanır. Tür kullanımıyla uyumludur.
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %b" boolean3


/// Dizeler, F# içindeki temel veri türleridir. Aşağıda bazı Dizeler ve temel dize işleme örnekleri verilmiştir.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/strings
module StringManipulation =

    /// Dizeler çift tırnak kullanır.
    let string1 = "Hello"
    let string2  = "world"

    /// Dizeler ayrıca, tam harf dizisi oluşturmak için @ kullanabilir.
    /// Bu; '\', '\n', '\t' vb. kaçış karakterlerini yoksayar.
    let string3 = @"C:\Program Files\"

    /// Harf dizileri ayrıca üçlü tırnak da kullanabilir.
    let string4 = """The computer said "hello world" when I told it to!"""

    /// Dizi bitiştirme normalde '+' işleci ile yapılır.
    let helloWorld = string1 + " " + string2

    // Bu satır, bir dize değeri yazdırmak için '%s' kullanır. Tür kullanımıyla uyumludur.
    printfn "%s" helloWorld

    /// Alt dizeler dizin oluşturucu gösterimini kullanır. Bu satır, ilk 7 karakteri alt dize olarak ayıklar.
    /// Birçok dilde olduğu gibi F#'ta da Dizeler sıfır dizinlidir.
    let substring = helloWorld.[0..6]
    printfn "%s" substring


/// Demetler, veri değerlerinin birleşik bir değer halindeki basit bileşimleridir.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/tuples
module Tuples =

    /// Basit bir tamsayı demeti.
    let tuple1 = (1, 2, 3)

    /// Bir demetteki iki değerin sırasını değiştiren bir işlev.
    ///
    /// F# Tür Çıkarımı, işlevi genel türe sahip olacak şekilde otomatik olarak genelleştirir,
    /// yani, herhangi bir tür ile çalışabilir.
    let swapElems (a, b) = (b, a)

    printfn "The result of swapping (1, 2) is %A" (swapElems (1,2))

    /// Bir tamsayı, bir dize ve bir çift duyarlıklı kayan nokta sayısından
    /// oluşan bir demet.
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A\ttuple2: %A" tuple1 tuple2

    /// Tür ek açıklaması içeren basit bir tamsayı tanımlama grubu.
    /// Tanımlama grupları için tür ek açıklamaları öğeleri ayırmak için * sembolünü kullanır
    let tuple3: int * int = (5, 9)

    /// Demetler, normalde nesnedir ancak yapı olarak da gösterilebilir.
    ///
    /// Bunlar C# ve Visual Basic.NET ile tamamen uyumlu olarak birlikte çalışır ancak
    /// yapı demetleri, nesne demetleri ile (genellikle başvuru demetleri olarak adlandırılır) örtük olarak dönüştürülebilir değildir.
    ///
    /// Bu nedenle aşağıdaki ikinci satırı derleme işlemi başarısız olacak. Ne olacağını görmek için açıklamayı kaldırın.
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // Yapı demetleri ile başvuru demetleri arasında örtük dönüştürme gerçekleştiremezsiniz, ancak
    // aşağıda gösterildiği gibi, desen eşleştirme aracılığıyla açık dönüştürme gerçekleştirebilirsiniz.
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)

    printfn "Struct Tuple: %A\nReference tuple made from the Struct Tuple: %A" sampleStructTuple (sampleStructTuple |> convertFromStructTuple)


/// F# kanal işleçleri ('|>', '<|', vb.) ve F# birleştirme işleçleri ('>>', '<<')
/// veriler işlenirken yaygın olarak kullanılır. Bu işleçler, başı başına birer işlevdir ve
/// Kısmi Uygulamadan yararlanır.
///
/// Bu işleçler hakkında daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/#function-composition-and-pipelining
/// Kısmi Uygulama hakkında daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/#partial-application-of-arguments
module PipelinesAndComposition =

    /// Bir değerin karesini alır.
    let square x = x * x

    /// Bir değere 1 ekler.
    let addOne x = x + 1

    /// Mod aracılığıyla bir tamsayı değerinin tek sayı olup olmadığını test eder.
    let isOdd x = x % 2 <> 0

    /// 5 numaradan oluşan bir liste. Listeler hakkında daha fazla bilgiyi ilerleyen bölümlerde bulabilirsiniz.
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// Bir tamsayı listesinde, çift sayıları filtreler,
    /// kalan tek sayıların karesini alır ve karesi alınan tek sayılara 1 ekler.
    let squareOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" numbers (squareOddValuesAndAddOne numbers)

    /// 'squareOddValuesAndAddOne' yazmanın daha kısa bir yolu, her bir
    /// alt sonucu işlev hücrelerinin kendisinde iç içe yerleştirmektir.
    ///
    /// Bu, işlevi çok daha kısa hale getirir ancak
    /// verilerin işlenme sırasını görmek zordur.
    let squareOddValuesAndAddOneNested values =
        List.map addOne (List.map square (List.filter isOdd values))

    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers (squareOddValuesAndAddOneNested numbers)

    /// 'squareOddValuesAndAddOne' yazmanın tercih edilen bir yolu, F# kanal işleçlerini kullanmaktır.
    /// Bu, ara sonuçlar oluşturmaktan kaçınmanızı sağlar ancak
    /// 'squareOddValuesAndAddOneNested' gibi iç içe geçmiş işlev çağrılarından daha okunaklıdır
    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    printfn "processing %A through 'squareOddValuesAndAddOnePipeline' produces: %A" numbers (squareOddValuesAndAddOnePipeline numbers)

    /// 'squareOddValuesAndAddOnePipeline' öğesini kısaltmak için ikinci `List.map` çağrısını
    /// bir Lambda İşlevi kullanarak birinciye taşıyabilirsiniz.
    ///
    /// Komut zincirleri, lambda işlevi içinde de kullanılıyor. F# kanal işleçleri
    /// tek değerler için de kullanılabilir. Bu, işleçlerin veri işleme işlevlerini geliştirir.
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" numbers (squareOddValuesAndAddOneShorterPipeline numbers)

    /// Son olarak, şu iki temel işlemi oluşturmak için '>>' kullanarak 'values' öğesini parametre olarak
    /// açıkça alma ihtiyacını ortadan kaldırabilirsiniz: çift sayıları filtreleme ve ardından karelerini alıp bir ekleme.
    /// Benzer şekilde, 'x' bir işlevsel komut zincirine geçirilmek için bu kapsamda tanımlandığından
    /// lambda ifadesindeki 'fun x -> ...' bölümü de gerekli değildir. Bu nedenle, '>>'
    /// burada da kullanılabilir.
    ///
    /// 'squareOddValuesAndAddOneComposition' sonucunun kendisi, giriş olarak bir tamsayı listesi alan
    /// diğer bir işlevdir. 'squareOddValuesAndAddOneComposition' öğesini bir tamsayı listesi ile
    /// yürütürseniz, önceki işlevler ile aynı sonuçları ürettiğini fark görürsünüz.
    ///
    /// Bu, işlev kompozisyonu olarak bilinen işlemi kullanır. Bu, F# içindeki işlevler Kısmi Uygulama kullandığı
    /// ve her bir bilgi işlem işleminin giriş ve çıkış türleri kullandığımız işlevlerin imzaları ile eşleştiği için
    /// mümkün olmaktadır.
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneComposition' produces: %A" numbers (squareOddValuesAndAddOneComposition numbers)


/// Listeler sıralı, sabit ve tek bağlantılıdır. Bu listelerde erken değerlendirme yapılır.
///
/// Bu modül, liste oluşturmanın çeşitli yollarını gösterir ve listeleri F# Core Kitaplığı'ndaki
/// 'List' modülünde yer alan işlevlerle işler.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/lists
module Lists =

    /// Listeler [ ... ] kullanılarak tanımlanır. Bu boş bir listedir.
    let list1 = [ ]

    /// Bu, 3 öğeden oluşan bir listedir.  ';' aynı satırdaki öğeleri ayırmak için kullanılır.
    let list2 = [ 1; 2; 3 ]

    /// Öğeleri, ayrı satırlara yerleştirerek de ayırabilirsiniz.
    let list3 = [
        1
        2
        3
    ]

    /// Bu, 1'den 1000'e kadar olan tamsayıların listesidir
    let numberList = [ 1 .. 1000 ]

    /// Listeler ayrıca hesaplamalar aracılığıyla da üretilebilir. Bu, yılın tüm
    /// günlerini içeren bir listedir.
    let daysList =
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                  yield System.DateTime(2017, month, day) ]

    // 'List.take' kullanarak 'daysList'in ilk 5 öğesini yazdırın.
    printfn "The first 5 days of 2017 are: %A" (daysList |> List.take 5)

    /// Hesaplamalar, koşullu deyimler içerebilir. Bu, bir satranç tahtasındaki siyah karelerin
    /// koordinatları olan demetleri içeren bir listedir.
    let blackSquares =
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do
                  if (i+j) % 2 = 1 then
                      yield (i, j) ]

    /// Listeler, 'List.map' ve diğer işlevsel programlama birleştiricileri kullanılarak dönüştürülebilir.
    /// Bu tanım, numberList içindeki sayıların karelerini alıp, List.map'e bir bağımsız değişken geçirmek üzere
    /// komut zinciri işlecini kullanarak yeni bir liste oluşturur.
    let squares =
        numberList
        |> List.map (fun x -> x*x)

    /// Başka birçok liste bileşimi daha vardır. Aşağıda, 3'e bölünebilen sayıların karelerinin
    /// toplamı hesaplanır.
    let sumOfSquares =
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)

    printfn "The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d" sumOfSquares


/// Diziler, aynı türdeki sabit boyutlu, değiştirilebilir öğe koleksiyonlarıdır.
///
/// Lists'e benzer olsalar da (numaralandırmayı desteklerler ve bilgi işlem için benzer birleştiricilere sahiptirler)
/// genellikle daha hızlıdırlar ve hızlı rastgele erişimi desteklerler. Buna karşılık, değişken oldukları için daha az güvenlidirler.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/arrays
module Arrays =

    /// Bu, boş dizidir. Söz diziminin Lists'e benzediğine ancak `[| ... |]` kullandığına dikkat edin.
    let array1 = [| |]

    /// Diziler, listeler ile aynı yapı aralıkları kullanılarak belirtilir.
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// Bu, 1'den 1000'e kadar olan sayıların dizisidir.
    let array3 = [| 1 .. 1000 |]

    /// Bu, yalnızca "hello" ve "world" sözcüklerini içeren bir dizidir.
    let array4 =
        [| for word in array2 do
               if word.Contains("l") then
                   yield word |]

    /// Bu, dizin tarafından başlatılan ve 0'dan 2000'e kadar olan çift sayıları içeren bir dizidir.
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// Alt diziler dilimleme gösterimi aracılığıyla ayıklanır.
    let evenNumbersSlice = evenNumbers.[0..500]

    /// Diziler ve listeler üzerinden döngü oluşturmak için 'for' döngülerini kullanabilirsiniz.
    for word in array4 do
        printfn "word: %s" word

    // Bir dizi öğesinin içeriğini sol ok atama işlecini kullanarak değiştirebilirsiniz.
    //
    // Bu işleç hakkında daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/values/index#mutable-variables
    array2.[1] <- "WORLD!"

    /// 'Array.map' ve diğer işlevsel programlama işlemlerini kullanarak dizileri dönüştürebilirsiniz.
    /// Aşağıdaki, 'h' ile başlayan sözcüklerin uzunluklarının toplamını hesaplar.
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn "The sum of the lengths of the words in Array 2 is: %d" sumOfLengthsOfWords


/// Sıralar, aynı türdeki öğelerden oluşan mantıksal öğe serileridir. Bunlar, Lists ve Arrays'e kıyasla daha genel türlerdir.
///
/// Sıralar isteğe bağlı olarak değerlendirilir ve her yinelendiklerinde yeniden değerlendirilir.
/// F# sırası, .NET System.Collections.Generic.IEnumerable<'T> için diğer addır.
///
/// Seri işleme işlevleri, Listeler ve Dizilere de uygulanabilir.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/sequences
module Sequences =

    /// Bu, boş bir seridir.
    let seq1 = Seq.empty

    /// Bu bir değerler serisidir.
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    /// Bu, 1'den 1000'e kadar olan isteğe bağlı bir seridir.
    let numbersSeq = seq { 1 .. 1000 }

    /// Bu, "hello" ve "world" sözcüklerini üreten bir seridir
    let seq3 =
        seq { for word in seq2 do
                  if word.Contains("l") then
                      yield word }

    /// Bu, 2000'e kadar olan çift sayıları üreten bir seridir.
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    /// Bu, rastgele olan sonsuz bir seridir.
    /// Bu örnek, alt serinin her öğesini döndürmek için yield! kullanır.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// Bu örnek rastgele serinin ilk 100 öğesini gösterir.
    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList

    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk


/// Özyinelemeli işlevler kendilerini çağırabilir. F# içinde, işlevler yalnızca
/// 'let rec' kullanılarak bildirildiğinde özyinelemeli olur.
///
/// Özyineleme, F# içinde sıraları veya koleksiyonları işlemek için tercih edilen yöntemdir.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/functions/index#recursive-functions
module RecursiveFunctions =

    /// Bu örnek, bir tamsayının faktöriyelini hesaplayan özyinelemeli bir işlevi
    /// gösterir. Özyinelemeli işlevi tanımlamak için 'let rec' kullanır.
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n-1)

    printfn "Factorial of 6 is: %d" (factorial 6)

    /// İki tamsayının en büyük ortak çarpanını hesaplar.
    ///
    /// Özyinelemeli tüm çağrılar tail çağrısı olduğundan,
    /// derleyici, işlevi bir döngüye dönüştürür,
    /// bu da performansı artırır ve bellek tüketimini azaltır.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn "The Greatest Common Factor of 300 and 620 is %d" (greatestCommonFactor 300 620)

    /// Bu örnek, özyineleme kullanarak bir tamsayılar listesinin toplamını hesaplar.
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    /// Bu, bir sonuç biriktirici ile bir yardımcı işlev kullanarak 'sumList' tail öğesini özyinelemeli yapar.
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    /// Bu, çekirdek biriktirici olarak '0' sağlayarak özyinelemeli tail yardımcı işlevini çağırır.
    /// Benzer yaklaşımlar F# içinde yaygındır.
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn "The sum 1-10 is %d" (sumListTailRecursive oneThroughTen)


/// Kayıtlar, isteğe bağlı üyeleri (örneğin, metotlar) içeren adlandırılmış değerlerin kümesidir.
/// Bunlar sabittir ve yapısal eşitlik semantiğine sahiptir.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/records
module RecordTypes =

    /// Bu örnek yeni bir kayıt türü tanımlamayı gösterir.
    type ContactCard =
        { Name     : string
          Phone    : string
          Verified : bool }

    /// Bu örnekte, bir kayıt türünün örneğinin nasıl oluşturulacağı gösterilmektedir.
    let contact1 =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false }

    /// Bunu ';' ayırıcıları ile aynı satırda da yapabilirsiniz.
    let contactOnSameLine = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

    /// Bu örnek kayıt değerlerinde "kopyalama ve güncelleştirme" kullanımını gösterir. contact1'in
    /// kopyası olan, ama 'Telefon' ve 'Doğrulanmış' alanları için farklı değerleri olan
    /// yeni bir kayıt değeri oluşturur.
    ///
    /// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/copy-and-update-record-expressions
    let contact2 =
        { contact1 with
            Phone = "(206) 555-0112"
            Verified = true }

    /// Bu örnek kayıt değerini işleyen bir işlev yazmayı gösterir.
    /// 'ContactCard' nesnesini dizeye dönüştürür.
    let showContactCard (c: ContactCard) =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn "Alf's Contact Card: %s" (showContactCard contact1)

    /// Bu, üye içeren bir Kayıt örneğidir.
    type ContactCardAlternate =
        { Name     : string
          Phone    : string
          Address  : string
          Verified : bool }

        /// Üyeler, nesne yönelimli üyeleri uygulayabilir.
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified)" else "") + this.Address

    let contactAlternate =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false
          Address = "111 Alf Street" }

    // Örnekli bir tür üzerinde, üyelere '.' işleci ile erişilir.
    printfn "Alf's alternate contact card is %s" contactAlternate.PrintedContactCard

    /// Kayıtlar 'Struct' özniteliği ile yapı olarak da gösterilebilir.
    /// Bu, yapıların performansının, başvuru türlerinin esnekliğinden daha önemli
    /// olduğu durumlarda kullanışlıdır.
    [<Struct>]
    type ContactCardStruct =
        { Name     : string
          Phone    : string
          Verified : bool }


/// Ayırt Edici Birleşimler (kısaca DU), bir dizi adlandırılmış form veya durum olabilen değerleri ifade eder.
/// DU'larda depolanan veriler birkaç farklı değerden biri olabilir.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/discriminated-unions
module DiscriminatedUnions =

    /// Aşağıdaki, bir iskambil kartının cinsini gösterir.
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    /// Bir iskambil kartının sırasını göstermek için bir Ayırt Edici Birleşim de kullanılabilir.
    type Rank =
        /// 2 .. 10 arasındaki kartları temsil eder
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        /// Ayırt Edici Birleşimler ayrıca nesne yönelimli üyeleri uygulayabilir.
        static member GetAllRanks() =
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]

    /// Bu, Cins ve Sırayı birleştiren bir kayıt türüdür.
    /// Verileri temsil ederken Kayıtları ve Ayırt Edici Birleşimleri birlikte kullanmak yaygındır.
    type Card = { Suit: Suit; Rank: Rank }

    /// Bu, destedeki tüm kartları gösteren bir liste hesaplar.
    let fullDeck =
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do
                  yield { Suit=suit; Rank=rank } ]

    /// Bu örnek, bir 'Card' nesnesini dizeye dönüştürür.
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

    /// Bu örnek bir iskambil destesindeki tüm kartları yazdırır.
    let printAllCards() =
        for card in fullDeck do
            printfn "%s" (showPlayingCard card)

    // Tek Olaylı DU'lar genellikle etki alanı modelleme için kullanılır. Bu, dizeler ve tamsayılar gibi temel türlere göre
    // ek tür güvenliği sağlamanıza yardımcı olabilir.
    //
    // Tek durumlu DU'lar, sarmaladıkları türe veya bu türden örtük olarak dönüştürülemez.
    // Örneğin, Adres alan bir işlev bu giriş için dize kabul edemez
    // veya bu durumun tersi olamaz.
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    // Tek Olaylı DU'ları aşağıdaki gibi kolayca örnekleyebilirsiniz.
    let address = Address "111 Alf Way"
    let name = Name "Alf"
    let ssn = SSN 1234567890

    /// Değere ihtiyacınız olduğunda, basit bir işlev ile temel değerin sarmalamasını açabilirsiniz.
    let unwrapAddress (Address a) = a
    let unwrapName (Name n) = n
    let unwrapSSN (SSN s) = s

    // Sarmalama açma işlevleri ile tek olayı DU'ları yazdırmak kolaydır.
    printfn "Address: %s, Name: %s, and SSN: %d" (address |> unwrapAddress) (name |> unwrapName) (ssn |> unwrapSSN)

    /// Ayırt Edici Birleşimler ayrıca özyinelemeli tanımları da destekler.
    ///
    /// Bu, bir olayı Boş ağacı ve diğeri bir değer ile iki alt ağaç içeren bir Düğüme sahip
    /// İkili Arama Ağacı'nı gösterir.
    type BST<'T> =
        | Empty
        | Node of value:'T * left: BST<'T> * right: BST<'T>

    /// İkili arama ağacında bir öğe olup olmadığını denetleyin.
    /// Desen Eşleştirme kullanarak özyinelemeli olarak arar. Varsa true, aksi takdirde false döndürür.
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left) // Sol alt ağacı denetleyin.
            else (exists item right) // Sağ alt ağacı denetleyin.

    /// İkili Arama Ağacı'na bir öğe ekler.
    /// Desen Eşleştirme kullanarak özyinelemeli olarak eklenecek yeri bulur ve ardından yeni bir düğüm ekler.
    /// Öğe zaten varsa yeni bir öğe eklenmez.
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node // Eklemeye gerek yok, öğe zaten var; düğümü döndürün.
            elif item < x then Node(x, insert item left, right) // Sol alt ağaca çağırın.
            else Node(x, left, insert item right) // Sağ alt ağaca çağırın.

    /// Ayırt Edici Birleşimler, 'Struct' özniteliği aracılığıyla yapı olarak da gösterilebilir.
    /// Bu, yapıların performansının, başvuru türlerinin esnekliğinden daha önemli
    /// olduğu durumlarda kullanışlıdır.
    ///
    /// Ancak, bunu yaparken bilmeniz gereken iki önemli nokta vardır:
    ///     1. Bir yapı DU'su, özyinelemeli olarak tanımlanamaz.
    ///     2. Bir yapı DU'su, her bir durumu için benzersiz adlara sahip olmalıdır.
    [<Struct>]
    type Shape =
        | Circle of radius: float
        | Square of side: float
        | Triangle of height: float * width: float


/// Desen Eşleştirme, Desenleri kullanmanızı sağlayan bir F# özelliğidir.
/// Desenler, verileri mantıksal yapı veya yapılar ile karşılaştırmak,
/// verileri bileşenlerine ayırmak veya verilerden bilgileri çeşitli şekillerde ayıklamak için harika bir yol sunar.
/// Daha sonra Desen Eşleştirme ile bir desenin "şeklini" gönderebilirsiniz.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/pattern-matching
module PatternMatching =

    /// Bir kişinin ad ve soyadı kaydı
    type Person = {
        First : string
        Last  : string
    }

    /// 3 farklı çalışan türünden oluşan bir Ayırt Edici Birleşim
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// Çalışan da dahil olmak üzere, yönetim hiyerarşisinde çalışanın altındaki
    /// herkesi sayın.
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(id) ->
                0
            | Manager(id, reports) ->
                reports |> List.sumBy countReports
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    /// Herhangi bir raporu olmayan, "Dave" adlı tüm yöneticileri bulun.
    /// Bu, 'function' kısaltmasını bir lambda ifadesi olarak kullanır.
    let rec findDaveWithOpenPosition(emps : List<Employee>) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true // [] boş bir liste ile eşleşir.
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false) // '_' herhangi bir öğeyle eşleşen bir joker karakter desenidir.
                                     // Bu, "or else" durumunu ele alır.

    /// Kısaltma özellik yapısını desen eşleştirme için de kullanabilirsiniz,
    /// bu Kısmi Uygulamayı kullanan işlevler yazarken kullanışlıdır.
    let private parseHelper f = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDateTimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    // Yardımcı işlev ile ayrıştırılan birkaç işlev daha tanımlayın.
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

    // Etkin Desenler, desen eşleştirme ile kullanabileceğiniz diğer bir güçlü yapıdır.
    // Giriş verilerini desen eşleştirme çağrı sitesinde bölerek özel formlara ayırmanıza olanak sağlar.
    //
    // Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/active-patterns
    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    /// 'Function' anahtar sözcüğü ve Etkin Desenler aracılığıyla Desen Eşleştirme, genellikle böyle görünür.
    let printParseResult = function
        | Int x -> printfn "%d" x
        | Double x -> printfn "%f" x
        | Date d -> printfn "%s" (d.ToString())
        | TimeSpan t -> printfn "%s" (t.ToString())
        | _ -> printfn "Nothing was parse-able!"

    // Ayrıştırılacak farklı değerlerle yazıcıyı çağırın.
    printParseResult "12"
    printParseResult "12.045"
    printParseResult "12/28/2016"
    printParseResult "9:01PM"
    printParseResult "banana!"


/// Seçenek değerleri 'Some' veya 'None' ile etiketlenmiş herhangi bir değer türü olabilir.
/// Bunlar yaygın olarak diğer birçok dilin null başvurular kullandığı durumları temsil
/// etmek üzere F# kodunda kullanılır.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/options
module OptionValues =

    /// İlk olarak, Tek Durumlu Ayırt Edici Birleşim ile tanımlanan bir posta kodu tanımlayın.
    type ZipCode = ZipCode of string

    /// Sonra, ZipCode’un isteğe bağlı olduğu bir tür tanımlayın.
    type Customer = { ZipCode: ZipCode option }

    /// Sonra, müşterinin posta kodu için sevkiyat alanını hesaplayan bir nesneyi temsil eden arabirim türünü tanımlayın,
    /// 'getState' ve 'getShippingZone' soyut metotları uygulamalarından faydalanır.
    type ShippingCalculator =
        abstract GetState : ZipCode -> string option
        abstract GetShippingZone : string -> int

    /// Sonra, hesaplayıcı örneğini kullanarak müşteri için sevkiyat bölgesi hesaplayın.
    /// Bu, Optionals ile veri dönüştürülmesini sağlamak için
    /// Option modülünde birleştiricilerin kullanılmasını sağlar.
    let CustomerShippingZone (calculator: ShippingCalculator, customer: Customer) =
        customer.ZipCode
        |> Option.bind calculator.GetState
        |> Option.map calculator.GetShippingZone


/// Ölçü birimleri, basit sayısal türler için tür açısından güvenli bir şekilde ek açıklama girmenin bir yoludur.
/// Böylece bu değerler üzerinde tür açısından güvenli aritmetik gerçekleştirebilirsiniz.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/units-of-measure
module UnitsOfMeasure =

    /// İlk olarak, ortak birim adlarından oluşan bir koleksiyon açın
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    /// Birimlere ayrılmış bir sabit tanımlayın
    let sampleValue1 = 1600.0<meter>

    /// Sonra, yeni bir birim türü tanımlayın
    [<Measure>]
    type mile =
        /// Milden metreye dönüştürme faktörü.
        static member asMeter = 1609.34<meter/mile>

    /// Birimlere ayrılmış bir sabit tanımlayın
    let sampleValue2  = 500.0<mile>

    /// Metrik sistem sabitini hesaplayın
    let sampleValue3 = sampleValue2 * mile.asMeter

    // Ölçü Birimleri kullanan değerler, yazdırma gibi işler için temel sayısal tür ile aynı şekilde kullanılabilir.
    printfn "After a %f race I would walk %f miles which would be %f meters" sampleValue1 sampleValue2 sampleValue3


/// Sınıflar, F# içinde yeni nesneleri tanımlamanın bir yoludur ve standart Nesne yönelimli yapıları destekler.
/// Çeşitli üyelere sahip olabilirler (metotlar, özellikler, olaylar vb.)
///
/// Sınıflar hakkında daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/classes
///
/// Üyeler hakkında daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/members
module DefiningClasses =

    /// Basit bir iki boyutlu Vektör sınıfı.
    ///
    /// Sınıfın oluşturucusu ilk satırdadır
    /// ve ikisi de 'double' türünde olan iki bağımsız değişken alır: dx ve dy.
    type Vector2D(dx : double, dy : double) =

        /// Bu dahili alan, nesne oluşturulduğunda hesaplanan vektör
        /// uzunluğunu depolar
        let length = sqrt (dx*dx + dy*dy)

        // 'this', nesnenin kendi tanımlayıcısı için bir ad belirtir.
        // Örnek metotlarında üye adından önce gelmelidir.
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        /// Bu üye, bir metot. Önceki üyeler özellikti.
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    /// Vector2D sınıfının örneğini bu şekilde oluşturabilirsiniz.
    let vector1 = Vector2D(3.0, 4.0)

    /// Özgün nesneyi değiştirmeden, yeni bir ölçekli vektör nesnesi alın.
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f\nLength of vector2: %f" vector1.Length vector2.Length


/// Genel sınıflar, türlerin bir tür parametreleri kümesine göre tanımlanmasına izin verir.
/// Aşağıda, 'T', sınıf için tür parametresidir.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/generics/
module DefiningGenericClasses =

    type StateTracker<'T>(initialElement: 'T) =

        /// Bu dahili alan, bir listedeki durumları depolar.
        let mutable states = [ initialElement ]

        /// Durumlar listesine yeni bir öğe ekleyin.
        member this.UpdateState newState =
            states <- newState :: states  // değeri değiştirmek için '<-' işlecini kullanın.

        /// Geçmiş durumların tam listesini alın.
        member this.History = states

        /// Son durumu alın.
        member this.Current = states.Head

    /// Durum izleyicisi sınıfının bir 'int' örneği. Tür parametresinin algılandığını unutmayın.
    let tracker = StateTracker 10

    // Durum ekle
    tracker.UpdateState 17


/// Arabirimler, yalnızca 'abstract' üyelere sahip olan nesne türleridir.
/// Nesne türleri ve nesne ifadeleri arabirim uygulayabilir.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/interfaces
module ImplementingInterfaces =

    /// Bu, IDisposable uygulayan bir türdür.
    type ReadFile() =

        let file = new System.IO.StreamReader("readme.txt")

        member this.ReadLine() = file.ReadLine()

        // Bu, IDisposable üyelerinin uygulamasıdır.
        interface System.IDisposable with
            member this.Dispose() = file.Close()


    /// Bu, bir Object İfadesi ile IDisposable uygulayan bir nesnedir
    /// C# veya Java gibi diğer dillerin aksine, bir arabirim uygulamak için yeni bir tür tanımı
    /// gerekli değildir.
    let interfaceImplementation =
        { new System.IDisposable with
            member this.Dispose() = printfn "disposed" }


/// FSharp.Core kitaplığı bir paralel işleme işlevleri aralığı tanımlar. Burada
/// diziler üzerinde çeşitli paralel işleme işlevleri kullanırsınız.
///
/// Daha fazla bilgi için bkz. https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/array.parallel-module-%5Bfsharp%5D
module ParallelArrayProgramming =

    /// İlk olarak, bir giriş dizisi.
    let oneBigArray = [| 0 .. 100000 |]

    // Sonra, yoğun CPU kullanarak hesaplama yapan bir işlev tanımlayın.
    let rec computeSomeFunction x =
        if x <= 2 then 1
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)

    // Sonra, büyük bir giriş dizisi üzerinde paralel bir eşleme oluşturun.
    let computeResults() =
        oneBigArray
        |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    // Sonra, sonuçları yazdırın.
    printfn "Parallel computation results: %A" (computeResults())



/// Events, .NET programlamasında özellikle WinForms veya WPF uygulamaları ile yaygın olarak kullanılan bir deyimdir.
///
/// Daha fazla bilgi için bkz. https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/members/events
module Events =

    /// İlk olarak, abonelik noktası (event.Publish) ve olay tetikleyicisinden (event.Trigger) oluşan Olay nesnesi örneğini oluşturun.
    let simpleEvent = new Event<int>()

    // Sonra, olaya işleyici ekleyin.
    simpleEvent.Publish.Add(
        fun x -> printfn "this handler was added with Publish.Add: %d" x)

    // Sonra, olayı tetikleyin.
    simpleEvent.Trigger(5)

    // Sonra, olayın standart .NET kuralını takip eden bir örneğini oluşturun: (sender, EventArgs).
    let eventForDelegateType = new Event<EventHandler, EventArgs>()

    // Sonra, bu yeni olay için bir işleyici ekleyin.
    eventForDelegateType.Publish.AddHandler(
        EventHandler(fun _ _ -> printfn "this handler was added with Publish.AddHandler"))

    // Sonra, bu olayı tetikleyin (sender bağımsız değişkeninin ayarlanmış olması gerektiğine dikkat edin).
    eventForDelegateType.Trigger(null, EventArgs.Empty)



#if COMPILED
module BoilerPlateForForm =
    [<System.STAThread>]
    do ()
    do System.Windows.Forms.Application.Run()
#endif
