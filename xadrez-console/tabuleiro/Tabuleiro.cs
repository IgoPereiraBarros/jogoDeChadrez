
namespace tabuleiro {
    class Tabuleiro {

        public int rows { get; set; }
        public int columns { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int rows, int columns) {
            this.rows = rows;
            this.columns = columns;
            pecas = new Peca[rows, columns];
        }

        // aqui é uma especie de get, aqui é para eu ter acesso na classe TelaTabuliero, para imprimir o tabuleiro
        public Peca peca(int rows, int columns) {
            return pecas[rows, columns];
        }

        public Peca peca(Posicao pos) {
            return pecas[pos.rows, pos.columns];
        }

        // verifica se existe peça no tabuleiro
        public bool existPeca(Posicao pos) {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        // adiciona peca no tabuleiro
        public void colocarPeca(Peca p, Posicao pos) {

            if (existPeca(pos)) {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.rows, pos.columns] = p;
            p.posicao = pos;
        }

        // retira uma peça do tabuleiro
        public Peca retirarPeca(Posicao pos) {
            if (peca(pos) == null) {
                return null;
            }

            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.rows, pos.columns] = null;
            return aux;
        }

        // verifica se a posicao está no limite da matriz do tabuleiro
        public bool posicaoValida(Posicao pos) {
            if (pos.rows < 0 || pos.rows >= rows || pos.columns < 0 || pos.columns >= columns) {
                return false;
            }
            else {
                return true;
            }
        }

        // verifica se a posicao da peca do tabuliero é válida
        public void validarPosicao(Posicao pos) {
            if (!posicaoValida(pos)) {
                throw new TabuleiroException("Erro: Posição inválida");
            }
        }
    }
}
