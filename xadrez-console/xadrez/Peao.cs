using tabuleiro;

namespace xadrez {
    class Peao : Peca {

        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }

        public override string ToString() {
            return "P";
        }

        private bool existeInimigo(Posicao pos) {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool livre(Posicao pos) {
            return tab.peca(pos) == null;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.rows, tab.columns];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca) {
                pos.definirValores(posicao.rows - 1, posicao.columns);
                if (tab.posicaoValida(pos) && livre(pos)) {
                    mat[pos.rows, pos.columns] = true;
                }

                pos.definirValores(posicao.rows - 2, posicao.columns);
                if (tab.posicaoValida(pos) && livre(pos) && qtdMovimentos == 0) {
                    mat[pos.rows, pos.columns] = true;
                }

                pos.definirValores(posicao.rows - 1, posicao.columns - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.rows, pos.columns] = true;
                }

                pos.definirValores(posicao.rows - 1, posicao.columns + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.rows, pos.columns] = true;
                }
            }
            else {
                pos.definirValores(posicao.rows + 1, posicao.columns);
                if (tab.posicaoValida(pos) && livre(pos)) {
                    mat[pos.rows, pos.columns] = true;
                }

                pos.definirValores(posicao.rows + 2, posicao.columns);
                if (tab.posicaoValida(pos) && livre(pos) && qtdMovimentos == 0) {
                    mat[pos.rows, pos.columns] = true;
                }

                pos.definirValores(posicao.rows + 1, posicao.columns - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.rows, pos.columns] = true;
                }

                pos.definirValores(posicao.rows + 1, posicao.columns + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.rows, pos.columns] = true;
                }
            }

            return mat;
        }
    }
}
