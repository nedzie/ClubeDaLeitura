using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Valores
    {
        public bool VerificarValores(Emprestimo[] emprestimo)
        {
            bool temAlgo = false;
            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i] != null)
                {
                    temAlgo = true;
                    break;
                }
                else
                    temAlgo = false;
            }
            return temAlgo;
        }
        public bool VerificarValores(Amigo[] amigo)
        {
            bool temAlgo = false;
            for (int i = 0; i < amigo.Length; i++)
            {
                if (amigo[i] != null)
                {
                    temAlgo = true;
                    break;
                }
                else
                    temAlgo = false;
            }
            return temAlgo;
        }

        public bool VerificarValores(Revista[] revista)
        {
            bool temAlgo = false;
            for (int i = 0; i < revista.Length; i++)
            {
                if (revista[i] != null)
                {
                    temAlgo = true;
                    break;
                }
                else
                    temAlgo = false;
            }
            return temAlgo;
        }

        public bool VerificarValores(Caixa[] caixa)
        {
            bool temAlgo = false;
            for (int i = 0; i < caixa.Length; i++)
            {
                if (caixa[i] != null)
                {
                    temAlgo = true;
                    break;
                }
                else
                    temAlgo = false;
            }
            return temAlgo;
        }

        public bool VerificarValores(Categoria[] categoria)
        {
            bool temAlgo = false;
            for (int i = 0; i < categoria.Length; i++)
            {
                if (categoria[i] != null)
                {
                    temAlgo = true;
                    break;
                }
                else
                    temAlgo = false;
            }
            return temAlgo;
        }

        public bool VerificarValores(Reserva[] reserva)
        {
            bool temAlgo = false;
            for (int i = 0; i < reserva.Length; i++)
            {
                if (reserva[i] != null)
                {
                    temAlgo = true;
                    break;
                }
                else
                    temAlgo = false;
            }
            return temAlgo;
        }
    }
}
