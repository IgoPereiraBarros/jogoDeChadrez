
namespace tabuleiro {
    abstract class Peca {

        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor) {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qtdMovimentos = 0;
        }

        public void incrementarQtdMovimentos() {
            qtdMovimentos++;
        }

        public void decrementarQtdMovimentos() {
            qtdMovimentos--;
        }

        public bool existMovimentosPossiveis() {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tab.rows; i++) {
                for (int j = 0; j < tab.columns; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }

            return false;
        }

        //verifica se uma peça pode mover para uma dada posição
        public bool podeMoverPara(Posicao pos) {
            return movimentosPossiveis()[pos.rows, pos.columns];
        }

        public abstract bool[,] movimentosPossiveis();

    }
}
