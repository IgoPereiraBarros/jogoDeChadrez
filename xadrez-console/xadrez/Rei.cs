using tabuleiro;

namespace xadrez {
    class Rei : Peca {

        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }

        public override string ToString() {
            return "R";
        }

        //verifica se a frente a uma peça adiversária 
        public bool podeMover(Posicao pos) {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor; //(se está vazia, ou se possui uma peça com outra cor)
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

            return mat;
        }
    }
}
