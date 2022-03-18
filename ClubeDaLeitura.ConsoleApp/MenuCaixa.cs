using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class MenuCaixa
    {
        public Caixa[] caixa = new Caixa[200];
        public void MostrarMenu()
        {
            Console.Clear();
            int escolhaDoMenu;
            do
            {
                Console.WriteLine("Menu geral > Menu caixa\n");
                Console.WriteLine("1. Registrar caixa\n2. Visualizar caixas\n3. sair");
                Console.Write("\nOpção: ");
                escolhaDoMenu = int.Parse(Console.ReadLine());
                switch (escolhaDoMenu)
                {
                    case 1:
                        RegistrarCaixa();
                        break;
                    case 2:
                        VisualizarCaixas();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (escolhaDoMenu != 3);
        }
        public void RegistrarCaixa()
        {
            Console.Clear();
            PosicaoVazia posicoes = new();
            int posicaoVazia = posicoes.ObterPosicaoVazia(caixa);
            Console.WriteLine("Menu geral > Menu caixa > Registrar caixa\n");
            Console.WriteLine("ID: " + (posicaoVazia + 1));
            caixa[posicaoVazia] = AtribuirValores();
            Console.Clear();
        }

        public Caixa AtribuirValores()
        {
            Caixa caixaTemporaria = new();
            Console.Write("Informe a cor da caixa: ");
            caixaTemporaria.cor = Console.ReadLine();
            Console.Write("Informe a etiqueta da caixa: ");
            caixaTemporaria.etiqueta = (Console.ReadLine());
            Console.Write("Informe o número da caixa: ");
            caixaTemporaria.numero = int.Parse(Console.ReadLine());
            return caixaTemporaria;
        }
        public void VisualizarCaixas()
        {
            Valores valores = new();
            bool temAlgo = valores.VerificarValores(caixa);
            if (temAlgo)
            {
                Console.WriteLine("\nCaixas:\n");
                for (int i = 0; i < caixa.Length; i++)
                {
                    if (caixa[i] != null)
                    {
                        Console.WriteLine(
                            "iD.........: " + (i + 1) + "\n" +
                            "Cor........: " + caixa[i].cor + "\n" +
                            "Etiqueta...: " + caixa[i].etiqueta + "\n" +
                            "Número.....: " + caixa[i].numero + "\n");
                    }
                }
            }
            else
                Console.WriteLine("\nAinda não temos caixas cadastradas...\n");
            }
        }
    }