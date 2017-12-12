using System;
using tabuleiro;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {

            Posicao p;

            p = new Posicao(1, 2);

            Console.WriteLine("Posição: " + p);

            Console.ReadKey();
        }
    }
}
