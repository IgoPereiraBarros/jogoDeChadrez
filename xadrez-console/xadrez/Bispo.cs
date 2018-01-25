using tabuleiro;

namespace xadrez {
    class Bispo : Peca {

        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }

        public override string ToString() {
            return "B";
        }

        private bool podeMover(Posicao pos) {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.rows, tab.columns];

            Posicao pos = new Posicao(0, 0);

            //NOROESTE
            pos.definirValores(posicao.rows - 1, posicao.columns - 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.rows - 1, pos.columns - 1);
            }

            //NORDESTE
            pos.definirValores(posicao.rows - 1, posicao.columns + 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.rows - 1, pos.columns + 1);
            }

            //SULDESTE
            pos.definirValores(posicao.rows + 1, posicao.columns + 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.rows + 1, pos.columns + 1);
            }

            //SULDOESTE
            pos.definirValores(posicao.rows + 1, posicao.columns - 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.rows + 1, pos.columns - 1);
            }

            return mat;
        }
    }
}
