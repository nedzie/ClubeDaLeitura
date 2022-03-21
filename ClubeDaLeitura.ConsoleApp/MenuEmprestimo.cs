using System;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class MenuEmprestimo
    {
        Emprestimo[] emprestimo = new Emprestimo[200];
        public MenuAmigo menuAmigo;
        public MenuRevista menuRevista;
        public MenuReserva menuReserva;
        public void MostrarMenu()
        {
            Console.Clear();
            int escolhaDoMenu;
            do
            {
                Console.WriteLine("Menu geral > Menu empréstimo\n");
                Console.WriteLine("1. Registrar empréstimo\n2. Visualizar empréstimos (total)\n3. Visualizar empréstimos (Mensal)\n4. Visualizar empréstimos (Diário)\n5. Sair");
                Console.Write("\nOpção: ");
                escolhaDoMenu = int.Parse(Console.ReadLine());
                switch (escolhaDoMenu)
                {
                    case 1:
                        RegistrarEmprestimo();
                        break;
                    case 2:
                        VisualizarEmprestimo();
                        break;
                    case 3:
                        VisualizarMensal();
                        break;
                    case 4:
                        VisualizarDiario();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (escolhaDoMenu != 5);
        }

        public void RegistrarEmprestimo()
        {
            Console.Clear();
            PosicaoVazia posicoes = new();
            int posicaoVazia = posicoes.ObterPosicaoVazia(emprestimo);
            Console.WriteLine("Menu geral > Menu empréstimo > Registrar empréstimo\n");
            Console.WriteLine("ID: " + (posicaoVazia + 1));
            emprestimo[posicaoVazia] = AtribuirValores();
            Console.Clear();
        }


        public Emprestimo AtribuirValores()
        {
            menuAmigo.VisualizarAmigo();
            Emprestimo emprestimoTemporario = new();
            emprestimoTemporario.amigoQueQuerEmprestar = SelecionarAmigo();
            menuRevista.VisualizarRevistas();
            emprestimoTemporario.revistaEmprestada = SelecionarRevista(emprestimoTemporario);
            emprestimoTemporario.dataDoEmprestimo = SelecionarData();
            emprestimoTemporario.revistaEmprestada.temEmprestimo = true;
            emprestimoTemporario.amigoQueQuerEmprestar.temEmprestimo = true;
            return emprestimoTemporario;
        }

        public DateTime SelecionarData()
        {
            Console.Write("E quando foi feito o empréstimo? ");
            DateTime dataTemporaria = DateTime.Parse(Console.ReadLine());
            return dataTemporaria;
        }

        public Amigo SelecionarAmigo()
        {
            Console.Write("\nQual desses amigos acima que emprestou? ");
            int posicaoDoAmigo = int.Parse(Console.ReadLine()) - 1;
            do
            {
                if (menuAmigo.amigo[posicaoDoAmigo].temEmprestimo == true)
                {
                    Console.WriteLine("Desculpe " + menuAmigo.amigo[posicaoDoAmigo].nome + " já tem um empréstimo. Selecione outro: ");
                    menuAmigo.VisualizarAmigo();
                    Console.Write("\nQual desses amigos acima que emprestou? ");
                    posicaoDoAmigo = int.Parse(Console.ReadLine()) - 1;
                }
                else
                    break;
            } while (menuAmigo.amigo[posicaoDoAmigo].temEmprestimo == false);
            Amigo amigoTemporario = menuAmigo.amigo[posicaoDoAmigo];
            return amigoTemporario;
        }

        public Revista SelecionarRevista(Emprestimo emprestimoTemporario)
        {
            Revista revistaTemporaria = new();
            Console.Write("\nQual dessas revistas foi emprestada?");
            int posicaoDaRevista = int.Parse(Console.ReadLine()) - 1;
            do
            {
                if (menuRevista.revista[posicaoDaRevista].temEmprestimo == true)
                {
                    Console.WriteLine("Desculpe " + menuRevista.revista[posicaoDaRevista].tipo + " está emprestada. Selecione outra: ");
                    menuRevista.VisualizarRevistas();
                    Console.Write("\nQual dessas revistas foi emprestada? ");
                    posicaoDaRevista = int.Parse(Console.ReadLine()) - 1;
                }
                else
                    break;
            } while (menuRevista.revista[posicaoDaRevista].temEmprestimo == false);

            if (menuRevista.revista[posicaoDaRevista].temReserva == true)
            {
                bool podeEmprestar = ChecarReserva(emprestimoTemporario);
                if (podeEmprestar == true)
                {
                    revistaTemporaria = menuRevista.revista[posicaoDaRevista];
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Desculpe " + menuRevista.revista[posicaoDaRevista].tipo + " está emprestada. Selecione outra: ");
                        menuRevista.VisualizarRevistas();
                        Console.Write("\nQual dessas revistas foi emprestada? ");
                        posicaoDaRevista = int.Parse(Console.ReadLine()) - 1;
                        podeEmprestar = ChecarReserva(emprestimoTemporario);
                    } while (podeEmprestar == true);
                }
            }
            revistaTemporaria = menuRevista.revista[posicaoDaRevista];
            return revistaTemporaria;
        }

        public bool ChecarReserva(Emprestimo emprestimoTemporario)
        {
            bool status = false;
            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (menuReserva.reserva[i] == null)
                    continue;
                if (menuReserva.reserva[i].amigoQueReservou.nome == emprestimoTemporario.amigoQueQuerEmprestar.nome)
                {
                    status = true;
                    break;
                }
                else
                {
                    status = false;
                    break;
                }
            }
            return status;
        }
        public void VisualizarEmprestimo()
        {
            Valores valores = new Valores();
            bool temAlgo = valores.VerificarValores(emprestimo);
            if (temAlgo)
            {
                for (int i = 0; i < emprestimo.Length; i++)
                {
                    if (emprestimo[i] != null)
                    {
                        Console.WriteLine(
                            "iD................: " + (i + 1) + "\n" +
                            "Amigo.............: " + emprestimo[i].amigoQueQuerEmprestar.nome + "\n" +
                            "Revista...........: " + emprestimo[i].revistaEmprestada.tipo + "\n" +
                            "Data empréstimo...: " + emprestimo[i].dataDoEmprestimo.ToString("dd/MM/yyyy") + "\n");
                    }
                }
            }
            else
                Console.WriteLine("\nAinda não temos empréstimos cadastrados...\n");
        }

        public void VisualizarMensal()
        {
            DateTime hoje = DateTime.Now;
            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i] == null)
                    break;
                double diferenca = ((hoje - emprestimo[i].dataDoEmprestimo).TotalDays);
                if (diferenca < 30)
                {
                    Console.WriteLine(
                            "iD................: " + (i + 1) + "\n" +
                            "Amigo.............: " + emprestimo[i].amigoQueQuerEmprestar.nome + "\n" +
                            "Revista...........: " + emprestimo[i].revistaEmprestada.tipo + "\n" +
                            "Data empréstimo...: " + emprestimo[i].dataDoEmprestimo.ToString("dd/MM/yyyy") + "\n");
                }
                Console.ReadKey();
            }
        }

        public void VisualizarDiario()
        {
            DateTime hoje = DateTime.Today;
            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i] == null)
                    break;
                if (emprestimo[i].dataDoEmprestimo.Date == hoje.Date)
                {
                    Console.WriteLine(
                            "iD................: " + (i + 1) + "\n" +
                            "Amigo.............: " + emprestimo[i].amigoQueQuerEmprestar.nome + "\n" +
                            "Revista...........: " + emprestimo[i].revistaEmprestada.tipo + "\n" +
                            "Data empréstimo...: " + emprestimo[i].dataDoEmprestimo.ToString("dd/MM/yyyy") + "\n");
                }
                Console.ReadKey();
            }
        }
    }
}