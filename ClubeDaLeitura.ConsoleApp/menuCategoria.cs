using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    public class menuCategoria
    {
        public Categoria[] categoria = new Categoria[200];
        public void MostrarMenu()
        {
            Console.Clear();
            int escolhaDoMenu;
            do
            {
                Console.WriteLine("Menu geral > Menu amigo\n");
                Console.WriteLine("1. Registrar categoria\n2. Visualizar categorias\n3. Sair");
                Console.Write("\nOpção: ");
                escolhaDoMenu = int.Parse(Console.ReadLine());
                switch (escolhaDoMenu)
                {
                    case 1:
                        RegistrarCategoria();
                        break;
                    case 2:
                        VisualizarCategorias();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (escolhaDoMenu != 3);
        }

        public void RegistrarCategoria()
        {
            Console.Clear();
            PosicaoVazia posicoes = new();
            int posicaoVazia = posicoes.ObterPosicaoVazia(categoria);
            Console.WriteLine("Menu geral > Menu categoria > Registrar categoria\n");
            Console.WriteLine("ID: " + (posicaoVazia + 1));
            categoria[posicaoVazia] = AtribuirValores();
            Console.Clear();
        }

        public Categoria AtribuirValores()
        {
            Categoria categoriaTemporaria = new();
            Console.Write("Informe o nome da categoria: ");
            categoriaTemporaria.nome = Console.ReadLine();
            Console.Write("Digite a quantidade de dias que a categoria " + categoriaTemporaria.nome + " pode ficar emprestada: ");
            categoriaTemporaria.diasDeEmprestimo = int.Parse(Console.ReadLine());
            return categoriaTemporaria;
        }
        public void VisualizarCategorias()
        {
            Valores valores = new();
            bool temAlgo = valores.VerificarValores(categoria);
            if (temAlgo)
            {
                Console.WriteLine("\nCategorias:\n");
                for (int i = 0; i < categoria.Length; i++)
                {
                    if (categoria[i] != null)
                    {
                        Console.WriteLine(
                            "id................: " + (i + 1) + "\n" +
                            "Nº edição.........: " + categoria[i].nome + "\n" +
                            "Dias de empréstimo: " + categoria[i].diasDeEmprestimo + "\n");
                    }
                }
            }
            else
                Console.WriteLine("\nAinda não temos categorias cadastradas...\n");
        }
    }
}