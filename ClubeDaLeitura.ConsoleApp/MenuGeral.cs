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
            MenuReserva menuReserva = new();
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
                    "6. Menu reserva\n" + 
                    "7. Sair");
                Console.Write("\nOpção: ");
                escolhaDoMenu = int.Parse(Console.ReadLine());
                switch (escolhaDoMenu)
                {
                    case 1:
                        menuAmigo.menuEmprestimo = menuEmprestimo;
                        menuAmigo.MostrarMenu();
                        break;
                    case 2:
                        menuRevista.mc = menuCaixa;
                        menuRevista.mctg = menuCategoria;
                        menuRevista.MostrarMenu();
                        break;
                    case 3:
                        menuCategoria.MostrarMenu();
                        break;
                    case 4:
                        menuCaixa.MostrarMenu();
                        break;
                    case 5:
                        menuEmprestimo.menuAmigo = menuAmigo;
                        menuEmprestimo.menuRevista = menuRevista;
                        menuEmprestimo.menuReserva = menuReserva;
                        menuEmprestimo.MostrarMenu();
                        break;
                    case 6:
                        menuReserva.menuAmigo = menuAmigo;
                        menuReserva.menuRevista = menuRevista;
                        menuReserva.MostrarMenu();
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