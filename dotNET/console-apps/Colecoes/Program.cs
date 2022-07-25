using System;
using System.Collections.Generic;
using System.Linq;
using Colecoes.Helper;

namespace Colecoes
{
    class Program
    {
        static void Main(string[] args)
        {

            // --- TryCatch --------------------------------------------------

            int a = 100, b = 0;
            double resultado = 0;

            try //Tenta executar o escopo abaixo
            {
                resultado = Dividir(a, b);
                System.Console.WriteLine("{0} dividido por {1} = {2}", a, b, resultado);
            }
            catch (DivideByZeroException ex) //Se falhar, captura a exceção em "ex"
            {
                System.Console.WriteLine(ex.Message); //Exibe a mensagem da exceção
            }
            catch (Exception ex) //Pode haver multiplos catchs
            //Se entrar no primeiro catch, os seguintes são pulados
            {
                System.Console.WriteLine(ex.Message); //Exibe a mensagem da exceção
            }
            finally //Executa idenpendente de cair em uma exceção ou não, salvo raras exceções
            {
                System.Console.WriteLine("Finalmente a divisão foi finalizada!");
            }

            //Classe
            static double Dividir(int x, int y)
            {
                if (y == 0)
                {
                    //throw new DivideByZeroException(); //Forçando o lançamento de uma exceção
                    //throw new ArithmeticException();

                    throw new MyClassException("Minha mensagem customizada de erro!");
                    //Usando classe customizada de exceção
                }

                return (x / y);
            }

            // --- TryCatch end ----------------------------------------------





            // --- LINQ ------------------------------------------------------

            // //Listar números pares sem For

            // int[] arrayNumeros = new int[5] { 1, 4, 8, 15, 19 };

            // var numerosParesQuery =
            //         from num in arrayNumeros
            //         where num % 2 == 0
            //         orderby num
            //         select num;

            // var numerosParesMetodo = arrayNumeros.Where(x => x % 2 == 0).OrderBy(x => x).ToList();

            // System.Console.WriteLine("Números pares query: " + string.Join(", ", numerosParesQuery));
            // System.Console.WriteLine("Números pares método: " + string.Join(", ", numerosParesMetodo));

            //-------

            // //Valores Mínimo, Máximo e Médio com LINQ

            // int[] arrayNumeros = new int[10] { 100, 1, 4, 0, 8, 15, 19, 19, 4, 100 };

            // var minimo = arrayNumeros.Min();
            // var maximo = arrayNumeros.Max();
            // var medio = arrayNumeros.Average();

            // System.Console.WriteLine($"Minimo: {minimo}");
            // System.Console.WriteLine($"Maximo: {maximo}");
            // System.Console.WriteLine($"Médio: {medio}");

            // //Sum e Distinct, Soma todos os valores e lista valores Distintos (não repetidos)
            /* Distinct não deixará de listar os números que possuem repetições,
            apenas não exibirá as repetições extras de cada um quando houverem */

            // var soma = arrayNumeros.Sum();
            // var arrayUnico = arrayNumeros.Distinct().ToArray();

            // System.Console.WriteLine($"Soma: {soma}");

            // System.Console.WriteLine($"Array original: {string.Join(", ", arrayNumeros)}");
            // System.Console.WriteLine($"Array distinto: {string.Join(", ", arrayUnico)}");

            // --- LINQ end ------------------------------------------------------

            // Dictionary<string, string> estados = new Dictionary<string, string>();

            // estados.Add("SP", "São Paulo");
            // estados.Add("MG", "Minas Gerais");
            // estados.Add("BA", "Bahia");

            // foreach (KeyValuePair<string, string> item in estados)
            // {
            //     System.Console.WriteLine($"Chave: {item.Key}, Valor: {item.Value}");
            // }

            // string valorProcurado = "BA";

            // //var teste = estados["SC"];

            // if (estados.TryGetValue(valorProcurado, out string estadoEncontrado))
            // {
            //     System.Console.WriteLine(estadoEncontrado);
            // }
            // else
            // {
            //     System.Console.WriteLine($"Chave {valorProcurado} não existe no dicionário");
            // }

            // System.Console.WriteLine(estados[valorProcurado]);

            // estados[valorProcurado] = "BA - teste atualização";

            // System.Console.WriteLine("Valor atualizado:");
            // System.Console.WriteLine(estados[valorProcurado]);


            // estados.Remove(valorProcurado);

            // foreach (KeyValuePair<string, string> item in estados)
            // {
            //     System.Console.WriteLine($"Chave: {item.Key}, Valor: {item.Value}");
            // }

            //-------

            // Stack<string> pilhaLivros = new Stack<string>();

            // pilhaLivros.Push(".NET");
            // pilhaLivros.Push("DDD");
            // pilhaLivros.Push("Código limpo");

            // System.Console.WriteLine($"Livros para a leitura: {pilhaLivros.Count}");
            // while (pilhaLivros.Count > 0)
            // {
            //     System.Console.WriteLine($"Próximo livro para a leitura: {pilhaLivros.Peek()}");
            //     System.Console.WriteLine($"{pilhaLivros.Pop()} lido com sucesso");
            // }

            // System.Console.WriteLine($"Livros para a leitura: {pilhaLivros.Count}");

            //-------

            // Queue<string> fila = new Queue<string>();

            // fila.Enqueue("Leonardo");
            // fila.Enqueue("Eduardo");
            // fila.Enqueue("André");

            // System.Console.WriteLine($"Pessoas na fila: {fila.Count}");
            // while (fila.Count > 0)
            // {
            //     System.Console.WriteLine($"Vez de: {fila.Peek()}");
            //     System.Console.WriteLine($"{fila.Dequeue()} atendido");
            // }

            // System.Console.WriteLine($"Pessoas na fila: {fila.Count}");

            //-------

            // OperacoesLista opLista = new OperacoesLista();
            // List<string> estados = new List<string>();
            //Listas são como arrays que não precisa definir tamanho

            // List<string> estados = new List<string> { "SP", "MG", "BA" };
            // string[] estadosArray = new string[2] { "SC", "MT" };

            // estados.Add("SP");
            // estados.Add("MG");
            // estados.Add("BA");

            // System.Console.WriteLine($"Quantidade de elementos na lista: {estados.Count}");

            // foreach (var item in estados)
            // {
            //     System.Console.WriteLine(item);
            // }

            // opLista.ImprimirListaString(estados);

            // System.Console.WriteLine("Removendo o elemento");
            // estados.Remove("MG");
            /* Na listas, ao remover um elemento, o tamanho da lista é redefinido e a poisções de todos os
            elementos seguintes são reajustadas */

            // estados.AddRange(estadosArray); //Adiciona os elementos de um Array em uma Lista
            // estados.Insert(1, "RJ"); //Adicionando o valor no indice "1"

            // opLista.ImprimirListaString(estados);



            //-------

            // OperacoesArray op = new OperacoesArray();
            // int[] array = new int[5] { 6, 3, 8, 1, 9 };

            // int[] arrayCopia = new int[10];

            // int valorProcurado = 9;

            //-------

            // string[] arrayString = op.ConverterParaArrayString(array);

            //-------

            // System.Console.WriteLine($"Capacidade atual do array: {array.Length}");

            // op.RedimensionarArray(ref array, array.Length * 2);

            // System.Console.WriteLine($"Capacidade atual do array após redimensionar: {array.Length}");

            //-------

            // int indice = op.ObterIndice(array, valorProcurado);

            // if (indice > -1)
            // {
            //     System.Console.WriteLine("O indice do elemento {0} é: {1}", valorProcurado, indice);
            //     System.Console.WriteLine($"O indice do elemento {valorProcurado} é: {indice}");
            // }
            // else
            // {
            //     System.Console.WriteLine("Valor não existente no array");
            // }

            //-------

            // int valorAchado = op.ObterValor(array, valorProcurado);

            // if (valorAchado > 0)
            // {
            //     System.Console.WriteLine("Encontrei o vlaor");
            // }
            // else
            // {
            //     System.Console.WriteLine("Não encontrei o valor");
            // }

            //-------

            // bool todosMaiorQue = op.TodosMaiorQue(array, valorProcurado);

            // if (todosMaiorQue)
            // {
            //     System.Console.WriteLine("Todos os valores são maior que {0}", valorProcurado);
            //     // {0} representa o conteúdo da variável "valorProcurado"
            // }
            // else
            // {
            //     System.Console.WriteLine("Existe valores que não são maiores do que {0}", valorProcurado);
            // }

            //-------

            // 
            // bool existe = op.Existe(array, valorProcurado);

            // if (existe)
            // {
            //     System.Console.WriteLine("Encontrei o valor {0}", valorProcurado);
            // }
            // else
            // {
            //     System.Console.WriteLine("Não encontrei o valor: {0}", valorProcurado);
            // }

            //-----------------------------------------------------------

            // System.Console.WriteLine("Array original:");
            // op.ImprimirArray(array);

            //op.OrdenarBubbleSort(ref array);
            //op.Ordenar(ref array);

            // System.Console.WriteLine("Array ordenado:");
            // op.ImprimirArray(array);

            //-----------------------------

            // System.Console.WriteLine("Array antes da cópia:");
            // op.ImprimirArray(arrayCopia);

            // op.Copiar(ref array, ref arrayCopia);
            // System.Console.WriteLine("Array após a cópia:");
            // op.ImprimirArray(arrayCopia);

            //-----------------------------------------------------------

            // int[,] matriz = new int[4, 2]
            // {
            //     {8, 8},
            //     {18, 28},
            //     {38, 48},
            //     {58, 68}
            // };
            // matriz[0, 0] = 5;

            // for (int i = 0; i < matriz.GetLength(0); i++)
            // {
            //     for (int j = 0; j < matriz.GetLength(1); j++)
            //     {
            //         System.Console.WriteLine(matriz[i, j]);
            //     }
            // }
            //-----------------------------------------------------------

            // int[] arrayInteiros = new int[3];

            // arrayInteiros[0] = 10;
            // arrayInteiros[1] = 20;
            // arrayInteiros[2] = 30;

            // System.Console.WriteLine("Percorrendo o array pelo For");
            // for (int i = 0; i < arrayInteiros.Length; i++)
            // {
            //     System.Console.WriteLine(arrayInteiros[i]);
            // }

            // System.Console.WriteLine("Percorrendo o array pelo ForEach");
            // foreach (int item in arrayInteiros)
            // {
            //     System.Console.WriteLine(item);
            // }


        }
    }
}
