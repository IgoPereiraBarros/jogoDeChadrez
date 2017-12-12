using System;
using tabuleiro;

namespace xadrez_console {
    class TelaTabuleiro {

        public static void imprimirTabuleiro(Tabuleiro tab) {

            for (int i = 0; i < tab.rows; i++) {
                for (int j = 0; j < tab.columns; j++) {
                    if (tab.peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Console.Write(tab.peca(i, j) + " ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
