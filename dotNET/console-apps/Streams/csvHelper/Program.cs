using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;

//LerCsvDynamic();
//LerCsvComClasse();
//LerCsvComOutroDelimitador();
EscreverCsv();

Console.WriteLine("\nDigite [enter] para finalizar");
Console.ReadLine();



static void EscreverCsv()
{
    var path = Path.Combine(
    Environment.CurrentDirectory,
    "Saida");

    var di = new DirectoryInfo(path);

    if (!di.Exists)
        di.Create();

    path = Path.Combine(path, "usuarios.csv");

    var pessoas = new List<Pessoa>()
    {
        new Pessoa()
        {
            Nome = "José da Silva",
            Email = "js@gmail.com",
            Telefone = 123456,
        },
        new Pessoa()
        {
            Nome = "Pedro Paiva",
            Email = "pp@gmail.com",
            Telefone = 456789,
        },
        new Pessoa()
        {
            Nome = "Maria Antonia",
            Email = "ma@gmail.com",
            Telefone = 123456,
        },
        new Pessoa()
        {
            Nome = "Carla Moraes",
            Email = "cms@gmail.com",
            Telefone = 9987411,

        },
    };

    using var sr = new StreamWriter(path);
    using var csvWriter = new CsvWriter(sr, CultureInfo.InvariantCulture);
    csvWriter.WriteRecords(pessoas);

    /* 
        //Método caso deseje mudar o delimitador do CSV

        using var sr = new StreamWriter(path);
        var csvConfig = new CsvConfiguration(CultureInfo.InstalledUICulture)
        {
            Delimiter = "|"
        }
        using var csvWriter = new CsvWriter(sr, csvConfig);
        csvWriter.WriteRecords(pessoas);
    */
}

static void LerCsvComOutroDelimitador()
{
    var path = Path.Combine(
    Environment.CurrentDirectory,
    "Entrada",
    "Livros-preco-com-virgula.csv");

    var fi = new FileInfo(path);

    if (!fi.Exists)
        throw new FileNotFoundException($"O arquivo {path} não existe!");

    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
    //var csvConfig = new CsvConfiguration(CultureInfo.GetCultureInfo("pt-BR")) //Também poderia ser feito assim,
    //mas o pt-BR afetaria todo o arquivo e não só a propriedade preço
    //var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture) //Dessa forma pega o Culture do sistema operacional
    {
        Delimiter = ";" //Alterando a leitura do delimitador de virgula para ponto e virgula
    };

    var csvReader = new CsvReader(sr, csvConfig);
    csvReader.Context.RegisterClassMap<LivroMap>(); //Necessário somente ao abstrair a lógica utlizando o mapping de LivroMap

    var registros = csvReader.GetRecords<Livro>().ToList(); //Usanso ToList apenas para teste, não recomendado pois
    //carrega toda a lista antes mesmo de fazer a iteração abaixo

    foreach (var registro in registros)
    {
        Console.WriteLine($"Título: {registro.Titulo}");
        Console.WriteLine($"Preço: {registro.Preco}");
        Console.WriteLine($"Autor: {registro.Autor}");
        Console.WriteLine($"Lançamento: {registro.Lancamento}");
        Console.WriteLine("----------------");
    }
}

static void LerCsvComClasse()
//Basicamente é a mesma coisa, apenas substitui Dynamic pela classe Usuario
{
    var path = Path.Combine(
    Environment.CurrentDirectory,
    "Entrada",
    "novos-usuarios.csv");

    var fi = new FileInfo(path);

    if (!fi.Exists)
        throw new FileNotFoundException($"O arquivo {path} não existe!");

    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
    var csvReader = new CsvReader(sr, csvConfig);

    var registros = csvReader.GetRecords<Usuario>();

    foreach (var registro in registros)
    {
        Console.WriteLine($"Nome: {registro.Nome}");
        Console.WriteLine($"Email: {registro.Email}");
        Console.WriteLine($"Telefone: {registro.Telefone}");
        Console.WriteLine("----------------");
    }
}

static void LerCsvDynamic()
//Funciona mas é propenso a erros, por exemplo uma letra minuscula pode acarretar em erro
{
    var path = Path.Combine(
    Environment.CurrentDirectory,
    "Entrada",
    "Produtos.csv");

    var fi = new FileInfo(path);

    if (!fi.Exists)
        throw new FileNotFoundException($"O arquivo {path} não existe!");

    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
    var csvReader = new CsvReader(sr, csvConfig);

    var registros = csvReader.GetRecords<dynamic>();

    foreach (var registro in registros)
    {
        Console.WriteLine($"nome: {registro.Produto}");
        Console.WriteLine($"marca: {registro.Marca}");
        Console.WriteLine($"preço: {registro.Preco}");
        Console.WriteLine("----------------");
    }

}


