using tabuleiro;

namespace xadrez {
    class Cavalo : Peca {

        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }

        public override string ToString() {
            return "C";
        }

        private bool podeMover(Posicao pos) {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.rows, tab.columns];

            Posicao pos = new Posicao(0, 0);

            pos.definirValores(posicao.rows - 1, posicao.columns - 2);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
            }

            pos.definirValores(posicao.rows - 2, posicao.columns - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
            }

            pos.definirValores(posicao.rows - 2, posicao.columns + 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
            }

            pos.definirValores(posicao.rows - 1, posicao.columns + 2);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
            }

            pos.definirValores(posicao.rows + 1, posicao.columns + 2);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
            }

            pos.definirValores(posicao.rows + 2, posicao.columns + 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
            }

            pos.definirValores(posicao.rows + 2, posicao.columns - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
            }

            pos.definirValores(posicao.rows + 1, posicao.columns - 2);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
            }

            return mat;
        }
    }
}
