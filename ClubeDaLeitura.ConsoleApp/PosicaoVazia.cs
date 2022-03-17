using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    public class PosicaoVazia
    {
        public int ObterPosicaoVaziaAmigo(Amigo[] amigo)
        {
            int posicaoVazia = 0;
            for (int i = 0; i < amigo.Length; i++)
            {
                if (amigo[i] == null)
                {
                    posicaoVazia = i;
                    break;
                }
                else
                {
                    posicaoVazia = -1;
                }  
            }
            return posicaoVazia;
        }

        public int ObterPosicaoVaziaRevista(Revista[] revista)
        {
            int posicaoVazia = 0;
            for (int i = 0; i < revista.Length; i++)
            {
                if (revista[i] == null)
                {
                    posicaoVazia = i;
                    break;
                }
                else
                {
                    posicaoVazia = -1;
                }
            }
            return posicaoVazia;
        }

        public int ObterPosicaoVaziaCaixa(Caixa[] caixa)
        {
            int posicaoVazia = 0;
            for (int i = 0; i < caixa.Length; i++)
            {
                if (caixa[i] == null)
                {
                    posicaoVazia = i;
                    break;
                }
                else
                {
                    posicaoVazia = -1;
                }
            }
            return posicaoVazia;
        }

        public int ObterPosicaoVaziaEmprestimo(Emprestimo[] emprestimos)
        {
            int posicaoVazia = 0;
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if(emprestimos[i] == null)
                {
                    posicaoVazia = i;
                    break;
                }
                else
                {
                    posicaoVazia = -1;
                }
            }
            return posicaoVazia;
        }
    }
}