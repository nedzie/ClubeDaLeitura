using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class MenuAmigo
    {
        public Amigo[] amigo = new Amigo[200];
        public void MostrarMenu()
        {
            Console.Clear();
            int escolhaDoMenu;
            do
            {
                Console.WriteLine("Menu geral > Menu amigo\n");
                Console.WriteLine("1. Registrar amigo\n2. Visualizar amigos\n3. Sair");
                Console.Write("\nOpção: ");
                escolhaDoMenu = int.Parse(Console.ReadLine());
                switch (escolhaDoMenu)
                {
                    case 1:
                        RegistrarAmigo();
                        break;
                    case 2:
                        VisualizarAmigo();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (escolhaDoMenu != 3);
        }
        public void RegistrarAmigo()
        {
            Console.Clear();
            PosicaoVazia posicoes = new();
            int posicaoVazia = posicoes.ObterPosicaoVazia(amigo);
            Amigo amigoTemporario = new();
            Console.WriteLine("Menu geral > Menu amigo > Registrar amigo\n");
            Console.WriteLine("ID: " + (posicaoVazia + 1));
            Console.Write("Informe o nome do amigo: ");
            amigoTemporario.nome = Console.ReadLine();
            Console.Write("Informe o nome do responsável pelo " + amigoTemporario.nome + ": ");
            amigoTemporario.nomeDoResponsavel = Console.ReadLine();
            Console.Write("Informe o telefone deles: ");
            amigoTemporario.telefone = Console.ReadLine();
            Console.Write("E o endereço deles: ");
            amigoTemporario.endereco = Console.ReadLine();
            amigo[posicaoVazia] = amigoTemporario;
            Console.Clear();
        }

        public void VisualizarAmigo()
        {
            Valores valores = new Valores();
            bool temAlgo = valores.VerificarValores(amigo);
            if (temAlgo == true)
            {
                Console.WriteLine("\nAmigos:\n");
                for (int i = 0; i < amigo.Length; i++)
                {
                    if (amigo[i] != null)
                    {
                        Console.WriteLine(
                            "iD.........: " + (i + 1) + "\n" +
                            "Nome.......: " + amigo[i].nome + "\n" +
                            "Responsável: " + amigo[i].nomeDoResponsavel + "\n" +
                            "Telefone...: " + amigo[i].telefone + "\n" +
                            "Endereço...: " + amigo[i].endereco + "\n");
                    }
                }
            }
            else
                Console.WriteLine("\nAinda não temos amigos cadastrados...\n");
        }
    }
}