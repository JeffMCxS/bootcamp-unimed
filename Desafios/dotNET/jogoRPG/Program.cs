
using jogoRPG.src.Entities;

BlackWizard hero1 = new BlackWizard("Suaron");
WhiteWizard hero2 = new WhiteWizard("Gandalf");
Elf hero3 = new Elf("Legolas");
Knight hero4 = new Knight("Aragorn", 1, 700, 20, 10);


System.Console.WriteLine(hero1.Attack(10));
System.Console.WriteLine("-------------------");
System.Console.WriteLine(hero2.Attack(10));
System.Console.WriteLine("-------------------");
System.Console.WriteLine(hero3.Attack(10));
System.Console.WriteLine("-------------------");
System.Console.WriteLine(hero4.Attack(10));
System.Console.WriteLine("-------------------");

System.Console.WriteLine("");
System.Console.WriteLine("Sequencia de ataques");
System.Console.WriteLine("");

System.Console.WriteLine(hero4.Attack(10));
System.Console.WriteLine("");
System.Console.WriteLine(hero4.Attack(10));
System.Console.WriteLine(hero4.Attack(10));
System.Console.WriteLine(hero4.Attack(10));



