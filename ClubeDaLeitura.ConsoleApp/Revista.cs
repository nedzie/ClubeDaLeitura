using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Revista
    {
        public string tipo;
        public int numeroDaEdicao;
        public int ano;
        public Caixa caixaOndeEstaGuardada;
        public Categoria categoriaDaRevista;
        public bool temEmprestimo;
        public bool temReserva;
    }
}