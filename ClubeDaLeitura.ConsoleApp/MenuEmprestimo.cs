using System;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class MenuEmprestimo
    {
        Emprestimo[] emprestimo = new Emprestimo[200];
        public MenuAmigo mA;
        public MenuRevista mR;
        public void MostrarMenu()
        {
            Console.Clear();
            int escolhaDoMenu;
            do
            {
                Console.WriteLine("Menu geral > Menu amigo\n");
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
            mA.VisualizarAmigo();
            emprestimo[posicaoVazia] = AtribuirValores();
            Console.Clear();
        }


        public Emprestimo AtribuirValores()
        {
            Emprestimo emprestimoTemporario = new();
            Console.Write("\nQual desses amigos acima que emprestou? ");
            int posicaoDoAmigo = int.Parse(Console.ReadLine()) - 1;
            do
            {
                if (mA.amigo[posicaoDoAmigo].temEmprestimo == true)
                {
                    Console.WriteLine("Desculpe " + mA.amigo[posicaoDoAmigo].nome + " já tem um empréstimo. Selecione outro: ");
                    mA.VisualizarAmigo();
                    Console.Write("\nQual desses amigos acima que emprestou? ");
                    posicaoDoAmigo = int.Parse(Console.ReadLine()) - 1;
                }
                else
                    break;
            } while (mA.amigo[posicaoDoAmigo].temEmprestimo == false);
            if (mA.amigo[posicaoDoAmigo].temEmprestimo == false)
            {
                emprestimoTemporario.amigoQuePegou = mA.amigo[posicaoDoAmigo];
                emprestimoTemporario.amigoQuePegou.temEmprestimo = true;
                mR.VisualizarRevistas();
                Console.Write("Qual dessas revistas o(a) " + emprestimoTemporario.amigoQuePegou.nome + " emprestou? ");
                int posicaoDaRevista = int.Parse(Console.ReadLine()) - 1;
                emprestimoTemporario.revistaEmprestada = mR.revista[posicaoDaRevista];
                emprestimoTemporario.revistaEmprestada.estaDisponivel = false;
                Console.WriteLine("E quando foi que o(a) " + emprestimoTemporario.amigoQuePegou.nome + " emprestou " + emprestimoTemporario.revistaEmprestada.tipo + "? ");
                emprestimoTemporario.dataDoEmprestimo = DateTime.Parse(Console.ReadLine());
            }
            return emprestimoTemporario;
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
                            "Amigo.............: " + emprestimo[i].amigoQuePegou.nome + "\n" +
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
                            "Amigo.............: " + emprestimo[i].amigoQuePegou.nome + "\n" +
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
                            "Amigo.............: " + emprestimo[i].amigoQuePegou.nome + "\n" +
                            "Revista...........: " + emprestimo[i].revistaEmprestada.tipo + "\n" +
                            "Data empréstimo...: " + emprestimo[i].dataDoEmprestimo.ToString("dd/MM/yyyy") + "\n");
                }
                Console.ReadKey();
            }
        }
    }
}