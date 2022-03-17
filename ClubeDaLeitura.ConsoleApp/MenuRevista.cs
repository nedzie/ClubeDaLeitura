using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class MenuRevista
    {
        public Revista[] revista = new Revista[200];
        public MenuCaixa mc; // Acessar tudo de "MenuCaixa"
        public void MostrarMenu()
        {
            Console.Clear();
            int escolhaDoMenu;
            do
            {
                Console.WriteLine("Menu geral > Menu revista\n");
                Console.WriteLine("1. Registrar revista\n2. Visualizar revistas\n3. Sair");
                Console.Write("\nOpção: ");
                escolhaDoMenu = int.Parse(Console.ReadLine());
                switch (escolhaDoMenu)
                {
                    case 1:
                        RegistrarRevista();
                        break;
                    case 2:
                        VisualizarRevistas();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (escolhaDoMenu != 3);
        }

        public void RegistrarRevista()
        {
            Console.Clear();
            PosicaoVazia posicoes = new();
            int posicaoVazia = posicoes.ObterPosicaoVaziaRevista(revista);
            Revista revistaTemporaria = new();
            Console.WriteLine("Menu geral > Menu revista > Registrar revista\n");
            Console.WriteLine("ID: " + (posicaoVazia + 1));
            Console.Write("Informe o tipo da coleção: ");
            revistaTemporaria.tipo = Console.ReadLine();
            Console.Write("Informe o número da edição: ");
            revistaTemporaria.numeroDaEdicao = int.Parse(Console.ReadLine());
            Console.Write("Informe a data de empréstimo: ");
            revistaTemporaria.dataDoEmprestimo = Console.ReadLine();
            mc.VisualizarCaixas();
            Console.Write("Guardar na caixa nº: ");
            int posicaoDaCaixa = int.Parse(Console.ReadLine()) - 1;
            revistaTemporaria.caixaOndeEstaGuardada = mc.caixa[posicaoDaCaixa];
            revista[posicaoVazia] = revistaTemporaria;
            Console.Clear();
        }

        public void VisualizarRevistas()
        {
            for (int i = 0; i < revista.Length; i++)
            {
                if (revista[i] != null)
                {
                    Console.WriteLine(
                        "Coleção........: " + (i + 1) + "\n" +
                        "Nº edição......: " + revista[i].numeroDaEdicao + "\n" +
                        "Data empréstimo: " + revista[i].dataDoEmprestimo + "\n" +
                        "Guardada.......: " + revista[i].caixaOndeEstaGuardada.cor + "\n");
                }
            }
            Console.ReadLine();
        }
    }
}