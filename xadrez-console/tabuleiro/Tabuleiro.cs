
namespace tabuleiro {
    class Tabuleiro {

        public int rows { get; set; }
        public int columns { get; set; }
        private Peca[,] peca;

        public Tabuleiro(int rows, int columns) {
            this.rows = rows;
            this.columns = columns;
            peca = new Peca[rows, columns];
        }
    }
}
