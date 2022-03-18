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
            menuCategoria menuCategoria = new();
            MenuEmprestimo menuEmprestimo = new();
            menuEmprestimo.mA = menuAmigo;
            menuEmprestimo.mR = menuRevista;
            menuRevista.mc = menuCaixa;
            menuRevista.mctg = menuCategoria;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu geral\n");
                Console.WriteLine(
                    "1. Menu amigo\n" +
                    "2. Menu revista\n" +
                    "3. Menu categoria\n" +
                    "4. Menu caixa\n" +
                    "5. Menu empréstimo\n" +
                    "6. Sair");
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
                        menuCategoria.MostrarMenu();
                        break;
                    case 4:
                        menuCaixa.MostrarMenu();
                        break;
                    case 5:
                        menuEmprestimo.MostrarMenu();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (escolhaDoMenu != 6);
        }
    }
}