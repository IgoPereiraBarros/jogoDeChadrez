using System;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {

            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada) {

                    try {
                        Console.Clear();
                        TelaTabuleiro.imprimirPartida(partida);

                        Console.WriteLine();
                        Console.WriteLine("-=-=-=-=-=-= Partida iniciada -=-=-=-=-=-=-");
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = TelaTabuleiro.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();


                        Console.Clear();
                        TelaTabuleiro.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.WriteLine("-=-=-=-=-=-= Partida iniciada -=-=-=-=-=-=-");
                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = TelaTabuleiro.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException t) {
                        Console.WriteLine(t.Message);
                        Console.ReadKey();
                    }
                }

                Console.Clear();
                TelaTabuleiro.imprimirPartida(partida);

            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
