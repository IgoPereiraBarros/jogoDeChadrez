using System;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {

            try {
                PartidaDeXadrez p = new PartidaDeXadrez();

                while (!p.terminada) {
                    Console.Clear();
                    TelaTabuleiro.imprimirTabuleiro(p.tab);

                    Console.WriteLine();
                    Console.WriteLine("-=-=-=-=-=-= Partida iniciada -=-=-=-=-=-=-");
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = TelaTabuleiro.lerPosicaoXadrez().toPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = TelaTabuleiro.lerPosicaoXadrez().toPosicao();

                    p.executarMovimentos(origem, destino);
                }
                
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
