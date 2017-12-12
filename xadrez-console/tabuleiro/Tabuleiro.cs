
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

        public Peca peca(int rows, int columns) {
            return pecas[rows, columns];
        }

        public void colocarPeca(Peca p, Posicao pos) {

            pecas[pos.rows, pos.columns] = p;
            p.posicao = pos;
        }
    }
}
