using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("1. Registrar empréstimo\n2. Visualizar empréstimos\n3. Sair");
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
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (escolhaDoMenu != 3);
        }

        public void RegistrarEmprestimo()
        {
            Console.Clear();
            PosicaoVazia posicoes = new();
            Emprestimo emprestimoTemporario = new();
            int posicaoVazia = posicoes.ObterPosicaoVaziaEmprestimo(emprestimo);
            Console.WriteLine("Menu geral > Menu empréstimo > Registrar empréstimo\n");
            Console.WriteLine("ID: " + (posicaoVazia + 1));
            mA.VisualizarAmigo();
            Console.Write("\nQual desses amigos acima que emprestou? ");
            int posicaoDoAmigo = int.Parse(Console.ReadLine()) - 1;
            emprestimoTemporario.amigoQuePegou = mA.amigo[posicaoDoAmigo];
            mR.VisualizarRevistas();
            Console.Write("Qual dessas revistas o(a)" + emprestimoTemporario.amigoQuePegou.nome + " emprestou? ");
            int posicaoDaRevista = int.Parse(Console.ReadLine()) - 1;
            emprestimoTemporario.revistaEmprestada = mR.revista[posicaoDaRevista];
            Console.WriteLine("E quando foi que o(a) " + emprestimoTemporario.amigoQuePegou.nome + " emprestou " + emprestimoTemporario.revistaEmprestada.tipo + "? ");
            emprestimoTemporario.dataDoEmprestimo = Console.ReadLine();
            emprestimo[posicaoVazia] = emprestimoTemporario;
            Console.Clear();
        }

        public void VisualizarEmprestimo()
        {
            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i] != null)
                {
                    Console.WriteLine(
                        "iD................: " + (i + 1) + "\n" +
                        "Amigo.............: " + emprestimo[i].amigoQuePegou.nome + "\n" +
                        "Revista...........: " + emprestimo[i].revistaEmprestada.tipo + "\n" +
                        "Data empréstimo...: " + emprestimo[i].dataDoEmprestimo + "\n");
                }
            }
            Console.ReadLine();
        }
    }
}