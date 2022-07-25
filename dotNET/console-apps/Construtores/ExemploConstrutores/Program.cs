using ExemploConstrutores.Models;


// //--- Pessoa ---------------------------------------------

// Pessoa p1 = new Pessoa(); //Instanciando com o primeiro construtor, sem parâmetros
// Pessoa p2 = new Pessoa("Leonardo", "Buta"); //Instanciando com o segundo construtor, com parâmetros

// p1.Apresentar();
// p2.Apresentar();

// //--- Log ---------------------------------------------

// Log log = Log.GetInstance();

// log.PropriedadeLog = "Teste instancia";

// Log log2 = Log.GetInstance();
// System.Console.WriteLine(log2.PropriedadeLog); //Retorno: "Teste instancia"
// //PropriedadeLog compartilha a memsa instancia de log e log2

// //--- Aluno ---------------------------------------------

// Aluno a1 = new Aluno("Leonardo", "Buta", "Teste");
// a1.Apresentar();

// //--- Data ---------------------------------------------

// Data data = new Data();
// data.SetMes(20);
// data.ApresentarMes();

// data.Mes = 12;
// System.Console.WriteLine(data.Mes);
// data.ApresentarMes();

// //--- Constante ---------------------------------------------

// const double pi = 3.14; //Constante
// System.Console.WriteLine(pi);

// //--- Delegate ---------------------------------------------

// //Passar método como parâmetro, chama um método de uma classe através de outro método de mesma assinatura

// Operacao op = new Operacao(Calculadora.Somar); //Referenciando
// op += Calculadora.Subtrair; // += Adicionando outra referência (os dois executarão), = Substituindo a referêcia

// op.Invoke(10, 10);
// //op (10, 10); //Maneira alternativa
// public delegate void Operacao(int x, int y); //Declarando o método alternativo com delegate

//--- Evento ---------------------------------------------

Matematica m = new Matematica(10, 20);
m.Somar();
