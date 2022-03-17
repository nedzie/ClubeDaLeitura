using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Revista
    {
        public string tipo;
        public int numeroDaEdicao;
        public string dataDoEmprestimo;
        public string dataDaDevolucao;
        public Caixa caixaOndeEstaGuardada;
    }
}