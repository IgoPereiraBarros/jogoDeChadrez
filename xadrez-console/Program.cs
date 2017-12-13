using System;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {

            PosicaoXadrez p = new PosicaoXadrez('a', 1);

            Console.WriteLine(p);
            Console.WriteLine(p.toPosicao());

            Console.ReadKey();
        }
    }
}
