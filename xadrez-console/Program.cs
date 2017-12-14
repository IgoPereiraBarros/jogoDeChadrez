using System;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {

            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada) {
                    Console.Clear();
                    TelaTabuleiro.imprimirTabuleiro(partida.tab);

                    Console.WriteLine();
                    Console.WriteLine("-=-=-=-=-=-= Partida iniciada -=-=-=-=-=-=-");
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = TelaTabuleiro.lerPosicaoXadrez().toPosicao();


                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();


                    Console.Clear();
                    TelaTabuleiro.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.WriteLine();
                    Console.WriteLine("-=-=-=-=-=-= Partida iniciada -=-=-=-=-=-=-");
                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = TelaTabuleiro.lerPosicaoXadrez().toPosicao();

                    partida.executarMovimentos(origem, destino);
                }
                
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
