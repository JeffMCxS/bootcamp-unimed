using System.Globalization;
using CsvHelper.Configuration;


public class LivroMap : ClassMap<Livro>
//Implemetando a classe ClassMap passando a model Livro para que seja feito o mapeamento de suas propriedades
{
    public LivroMap() //Construtor
    {
        //Configurando para identificar minusculoe maiusculo. Também poderia usar Index com csv sem cabeçalho
        Map(x => x.Titulo).Name("titulo");
        Map(x => x.Preco)
            .Name("preço")
            .TypeConverterOption
            .CultureInfo(CultureInfo.GetCultureInfo("pt-BR")); //Configurando o decimal do preço
        Map(x => x.Autor).Name("autor");
        Map(x => x.Lancamento)
            .Name("lançamento")
            .TypeConverterOption
            .Format(new[] { "dd/MM/yyyy" }); //Configurando formato da data

    }
}
