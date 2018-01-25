using tabuleiro;

namespace xadrez {
    class Rei : Peca {

        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor) {
            this.partida = partida;
        }

        public override string ToString() {
            return "R";
        }

        //verifica se a frente a uma peça adversária 
        public bool podeMover(Posicao pos) {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor; //(se está vazia, ou se possui uma peça com outra cor)
        }

        private bool testeTorreParaRoque(Posicao pos) {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qtdMovimentos == 0;
        }

        // metodo responsável pela movimentação do Rei
        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.rows, tab.columns];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(posicao.rows - 1, posicao.columns);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
            }

            //parte superior na diegonal da direita
            pos.definirValores(posicao.rows - 1, posicao.columns + 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
            }

            //direita
            pos.definirValores(posicao.rows, posicao.columns + 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
            }

            //parte inferior na diegonal da direita
            pos.definirValores(posicao.rows + 1, posicao.columns + 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
            }

            //abaixo
            pos.definirValores(posicao.rows + 1, posicao.columns);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
            }

            // parte inferior na diegonal da esquerda
            pos.definirValores(posicao.rows + 1, posicao.columns - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
            }

            //esquerda
            pos.definirValores(posicao.rows, posicao.columns - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
            }

            //parte superior na diegonal da esquerda
            pos.definirValores(posicao.rows - 1, posicao.columns - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
            }


            // #JogadasEspeciais Roque
            if (qtdMovimentos == 0 && !partida.xeque) {
                // #JogadaEspecial Roque Pequeno
                Posicao posT1 = new Posicao(posicao.rows, posicao.columns + 3);
                if (testeTorreParaRoque(posT1)) {
                    Posicao p1 = new Posicao(posicao.rows, posicao.columns + 1);
                    Posicao p2 = new Posicao(posicao.rows, posicao.columns + 2);
                    if (tab.peca(p1) == null && tab.peca(p2) == null) {
                        mat[posicao.rows, posicao.columns + 2] = true;
                    }
                }

                // #JogadaEspecial Roque Grande
                Posicao posT2 = new Posicao(posicao.rows, posicao.columns - 4);
                if (testeTorreParaRoque(posT2)) {
                    Posicao p1 = new Posicao(posicao.rows, posicao.columns - 1);
                    Posicao p2 = new Posicao(posicao.rows, posicao.columns - 2);
                    Posicao p3 = new Posicao(posicao.rows, posicao.columns - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null) {
                        mat[posicao.rows, posicao.columns - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
