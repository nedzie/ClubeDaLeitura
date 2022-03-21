using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class MenuRevista
    {
        public Revista[] revista = new Revista[200];
        public MenuCaixa mc; // Acessar tudo de "MenuCaixa"
        public menuCategoria mctg;
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
            int posicaoVazia = posicoes.ObterPosicaoVazia(revista);
            Console.WriteLine("Menu geral > Menu revista > Registrar revista\n");
            Console.WriteLine("ID: " + (posicaoVazia + 1));
            revista[posicaoVazia] = AtribuirValores();
            Console.Clear();
        }

        public Revista AtribuirValores()
        {
            Revista revistaTemporaria = new();
            Console.Write("Informe o tipo da coleção..: ");
            revistaTemporaria.tipo = Console.ReadLine();
            Console.Write("Informe o número da edição.: ");
            revistaTemporaria.numeroDaEdicao = int.Parse(Console.ReadLine());
            Console.Write("Informe o ano de lançamento: ");
            revistaTemporaria.ano = int.Parse(Console.ReadLine());
            mctg.VisualizarCategorias();
            Console.Write("Se encaixa na categoria: ");
            int posicaoDaCategoria = int.Parse(Console.ReadLine()) - 1;
            revistaTemporaria.categoriaDaRevista = mctg.categoria[posicaoDaCategoria];
            mc.VisualizarCaixas();
            Console.Write("Guardar na caixa nº: ");
            int posicaoDaCaixa = int.Parse(Console.ReadLine()) - 1;
            revistaTemporaria.caixaOndeEstaGuardada = mc.caixa[posicaoDaCaixa];
            return revistaTemporaria;
        }
        public void VisualizarRevistas()
        {
            Valores valores = new();
            bool temAlgo = valores.VerificarValores(revista);
            if (temAlgo)
            {
                Console.WriteLine("\nRevistas:\n");
                for (int i = 0; i < revista.Length; i++)
                {
                    if (revista[i] != null)
                    {
                        Console.WriteLine(
                            "iD.............: " + (i + 1) + "\n" +
                            "Coleção........: " + revista[i].tipo + "\n" +
                            "Nº edição......: " + revista[i].numeroDaEdicao + "\n" +
                            "Ano............: " + revista[i].ano + "\n" +
                            "Categoria......: " + revista[i].categoriaDaRevista.nome + "\n" +
                            "Na caixa.......: " + revista[i].caixaOndeEstaGuardada.cor + "\n");
                    }
                }
            }
            else        
                Console.WriteLine("\nAinda não temos revistas cadastradas...\n");
        }
    }
}