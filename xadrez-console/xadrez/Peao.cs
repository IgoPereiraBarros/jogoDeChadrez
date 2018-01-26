using tabuleiro;

namespace xadrez {
    class Peao : Peca {

        private PartidaDeXadrez partida;

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor) {
            this.partida = partida;
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

                // #jogadaespecial en passant
                if (posicao.rows == 3) {
                    Posicao esquerda = new Posicao(posicao.rows, posicao.columns - 1);
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant) {
                        mat[esquerda.rows - 1, esquerda.columns] = true;
                    }

                    Posicao direita = new Posicao(posicao.rows, posicao.columns + 1);
                    if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant) {
                        mat[direita.rows - 1, direita.columns] = true;
                    }
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

                // #jogadaespecial en passant
                if (posicao.rows == 4) {
                    Posicao esquerda = new Posicao(posicao.rows, posicao.columns - 1);
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant) {
                        mat[esquerda.rows + 1, esquerda.columns] = true;
                    }

                    Posicao direita = new Posicao(posicao.rows, posicao.columns + 1);
                    if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant) {
                        mat[direita.rows + 1, direita.columns] = true;
                    }

                }
            }

            return mat;
        }
    }
}
