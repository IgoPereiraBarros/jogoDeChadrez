using System;
using tabuleiro;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {

            Tabuleiro t = new Tabuleiro(8, 8);

            TelaTabuleiro.imprimirTabuleiro(t);

            Console.ReadKey();
        }
    }
}
