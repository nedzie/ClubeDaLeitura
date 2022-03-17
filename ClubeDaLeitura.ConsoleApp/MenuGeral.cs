using System;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class MenuGeral
    {
        public void Mostrar()
        {
            int escolhaDoMenu;
            MenuAmigo menuAmigo = new();
            MenuCaixa menuCaixa = new();
            MenuRevista menuRevista = new();
            MenuEmprestimo menuEmprestimo = new();
            menuEmprestimo.mA = menuAmigo;
            menuEmprestimo.mR = menuRevista;
            menuRevista.mc = menuCaixa;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu geral\n");
                Console.WriteLine(
                    "1. Menu amigo\n" +
                    "2. Menu revista\n" +
                    "3. Menu caixa\n" +
                    "4. Menu empréstimo\n" +
                    "5. Visualizar empréstimos diários\n" +
                    "6. Visualizar empréstimos do mês \n" +
                    "7. Sair");
                Console.Write("\nOpção: ");
                escolhaDoMenu = int.Parse(Console.ReadLine());
                switch (escolhaDoMenu)
                {
                    case 1:
                        menuAmigo.MostrarMenu();
                        break;
                    case 2:
                        menuRevista.MostrarMenu();
                        break;
                    case 3:
                        menuCaixa.MostrarMenu();
                        //menuRevista.mc = menuCaixa;
                        break;
                    case 4:
                        menuEmprestimo.MostrarMenu();
                        //menuEmprestimo.mR = menuRevista;
                        //menuEmprestimo.mA = menuAmigo;
                        break;
                    case 5:
                        Console.WriteLine("5");
                        break;
                    case 6:
                        Console.WriteLine("6");
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (escolhaDoMenu != 7);
        }
    }
}