
namespace tabuleiro {
    class Posicao {

        public int rows { get; set; }
        public int columns { get; set; }

        public Posicao(int rows, int columns) {
            this.rows = rows;
            this.columns = columns;
        }

        public void definirValores(int rows, int columns) {
            this.rows = rows;
            this.columns = columns;
        }

        public override string ToString() {
            return rows
                    + ", "
                    + columns;
        }
    }
}
