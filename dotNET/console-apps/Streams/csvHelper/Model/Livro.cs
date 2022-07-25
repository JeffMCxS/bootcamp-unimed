using CsvHelper.Configuration.Attributes;
public class Livro
{

    /*
    Models são classes que devem ser anêmicas, são classes DTO (Data Transfer Object) ou seja, não devem possuir
    lógica nenhum no seu conteúdo.
    Nos últimos 2 modelos há lógica de como deve ser feito o mapeamento do arquivo na hora de fazer a serialização
    dos dados para a classe Livro.
    Sendo assim o primeiro exemplo abaixo foi feito abstraindo a lógica na classe Mapping/LivroMap.cs
    */

    //Método via Mapping
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public decimal Preco { get; set; }
    public DateOnly Lancamento { get; set; }


    /*
        //Método via Data Annotation

        [Name("titulo")] //Configurando para reconhecer nomes em minusculo, mesmo passando o parâmetro em maiusculo
        public string Titulo { get; set; }
        [Name("autor")]
        public string Autor { get; set; }
        [Name("preço")]
        [CultureInfo("pt-BR")] //Configurando para identificar que o delimitador de decimal é virgula e não ponto
        //Também pode ser configurado no csvConfig mas afetará todo o arquivo e não só a propriedade preço
        public decimal Preco { get; set; }
        [Name("lançamento")]
        [Format("dd/MM/yyyy")] //Formatando para reconhecer um formato de data diferente
        public DateOnly Lancamento { get; set; }
    */

    /*
        //Método via Data Annotation sem cabeçalho

        [Index(0)] //Configuração para caso o csv não tenha cabeçalho, a identificação será pelo index dos valores
        public string Titulo { get; set; }
        [Index(2)] //Configuração para caso o csv não tenha cabeçalho, a identificação será pelo index dos valores
        public string Autor { get; set; }
        [Index(1)] //Configuração para caso o csv não tenha cabeçalho, a identificação será pelo index dos valores
        [CultureInfo("pt-BR")]
        public decimal Preco { get; set; }
        [Index(3)] //Configuração para caso o csv não tenha cabeçalho, a identificação será pelo index dos valores
        [Format("dd/MM/yyyy")] //Formatando para reconhecer um formato de data diferente
        public DateOnly Lancamento { get; set; }
    */










}


