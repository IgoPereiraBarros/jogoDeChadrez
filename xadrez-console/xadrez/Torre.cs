using tabuleiro;

namespace xadrez {
    class Torre : Peca {

        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }

        public override string ToString() {
            return "T";
        }

        //verifica se a frente a uma peça adiversária 
        private bool podeMover(Posicao pos) {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor; //(se está vazia, ou se possui uma peça com outra cor)
        }

        // metodo responsável pela movimentação da torre
        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.rows, tab.columns];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(posicao.rows - 1, posicao.columns);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) { // força a torre parar caso encontre uma peca adiversária
                    break;
                }
                pos.rows--; // aqui a torre continua avancando as linhas do tabuleiro, caso seja necessário
            }

            //abaixo
            pos.definirValores(posicao.rows + 1, posicao.columns);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) { // força a torre parar caso encontre uma peca adiversária
                    break;
                }

                pos.rows++; //aqui a torre continua voltando as linhas do tabuleiro, caso seja necessário
            }

            //direita
            pos.definirValores(posicao.rows, posicao.columns + 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) { // força a torre parar caso encontre uma peca adiversária
                    break;
                }

                pos.columns++; //aqui a torre continua avancando a coluna para a direita, caso seja necessário
            }

            //esquerda
            pos.definirValores(posicao.rows, posicao.columns - 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.rows, pos.columns] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) { // força a torre parar caso encontre uma peca adiversária
                    break;
                }

                pos.columns--; //aqui a torre continua voltando a coluna para a esquerda, caso seja necessário
            }

            return mat;
        }
    }
}
