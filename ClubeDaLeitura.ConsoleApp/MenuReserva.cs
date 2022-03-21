using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class MenuReserva
    {
        public Reserva[] reserva = new Reserva[200];
        public MenuAmigo menuAmigo;
        public MenuRevista menuRevista;
        MenuEmprestimo menuEmprestimo = new();
        public void MostrarMenu()
        {
            Console.Clear();
            int escolhaDoMenu;
            do
            {
                Console.WriteLine("Menu geral > Menu reserva\n");
                Console.WriteLine("1. Registrar reserva\n2. Visualizar reservas\n3. Ir ao menu de empréstimos\n4. Sair");
                Console.Write("\nOpção: ");
                escolhaDoMenu = int.Parse(Console.ReadLine());
                switch (escolhaDoMenu)
                {
                    case 1:
                        RegistrarReserva();
                        break;
                    case 2:
                        VisualizarReservas();
                        break;
                    case 3:
                        menuEmprestimo.MostrarMenu();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (escolhaDoMenu != 4);
        }

        public void RegistrarReserva()
        {
            Console.Clear();
            PosicaoVazia posicoes = new();
            int posicaoVazia = posicoes.ObterPosicaoVazia(reserva);
            Console.WriteLine("Menu geral > Menu reserva > Registrar reserva\n");
            Console.WriteLine("ID: " + (posicaoVazia + 1));
            menuAmigo.VisualizarAmigo();
            reserva[posicaoVazia] = AtribuirValores();
            Console.Clear();
        }
        public Reserva AtribuirValores()
        {
            Reserva reservaTemporaria = new Reserva();
            Console.Write("\nQual desses amigos acima quer reservar? ");
            int posicaoDoAmigo = int.Parse(Console.ReadLine()) - 1;
            do
            {
                if (menuAmigo.amigo[posicaoDoAmigo].temEmprestimo == true || menuAmigo.amigo[posicaoDoAmigo].temReserva == true)
                {
                    Console.WriteLine("Desculpe " + menuAmigo.amigo[posicaoDoAmigo].nome + " já tem um empréstimo ou uma reserva. Selecione outro: ");
                    menuAmigo.VisualizarAmigo();
                    Console.Write("\nQual desses amigos acima quer reservar? ");
                    posicaoDoAmigo = int.Parse(Console.ReadLine()) - 1;
                }
                else
                    break;
            } while (menuAmigo.amigo[posicaoDoAmigo].temEmprestimo == false && menuAmigo.amigo[posicaoDoAmigo].temReserva == false);
            if (menuAmigo.amigo[posicaoDoAmigo].temEmprestimo == false && menuAmigo.amigo[posicaoDoAmigo].temReserva == false)
            {
                reservaTemporaria.amigoQueReservou = menuAmigo.amigo[posicaoDoAmigo];
                reservaTemporaria.amigoQueReservou.temReserva = true;
                menuRevista.VisualizarRevistas();
                Console.Write("Qual dessas revistas o(a) " + reservaTemporaria.amigoQueReservou.nome + " quer reservar? ");
                int posicaoDaRevista = int.Parse(Console.ReadLine()) - 1;
                reservaTemporaria.revistaReservada = menuRevista.revista[posicaoDaRevista];
                reservaTemporaria.revistaReservada.temReserva = true;
                Console.WriteLine("E quando foi que o(a) " + reservaTemporaria.amigoQueReservou.nome + " emprestou " + reservaTemporaria.revistaReservada.tipo + "? ");
                reservaTemporaria.dataDaReserva = DateTime.Parse(Console.ReadLine());
            }
            return reservaTemporaria;
        }
        public void VisualizarReservas()
        {
            Valores valores = new();
            bool temAlgo = valores.VerificarValores(reserva);
            if (temAlgo)
            {
                Console.WriteLine("\nRevistas:\n");
                for (int i = 0; i < reserva.Length; i++)
                {
                    if (reserva[i] != null)
                    {
                        reserva[i].validade = ObterValidade(i);
                        Console.WriteLine(
                            "iD.............: " + (i + 1) + "\n" +
                            "Amigo..........: " + reserva[i].amigoQueReservou.nome + "\n" +
                            "Revista........: " + reserva[i].revistaReservada.tipo + "\n" +
                            "Data...........: " + reserva[i].dataDaReserva.ToString("dd/MM/yyyy") + "\n" +
                            "Validade.......: " + reserva[i].validade.ToString("dd/MM/yyyy"));
                    }
                }
            }
            else
                Console.WriteLine("\nAinda não temos revistas cadastradas...\n");
        }
        public DateTime ObterValidade(int i)
        {
            DateTime validade = new();
            validade = reserva[i].dataDaReserva.AddDays(2);
            return validade;
        }
    }
}