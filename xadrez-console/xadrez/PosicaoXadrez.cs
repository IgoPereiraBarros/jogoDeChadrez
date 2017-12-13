using tabuleiro;

namespace xadrez {
    class PosicaoXadrez {

        public char columns { get; set; }
        public int rows { get; set; }

        public PosicaoXadrez(char columns, int rows) {
            this.columns = columns;
            this.rows = rows;
        }

        public Posicao toPosicao() {
            return new Posicao(8 - rows, columns - 'a');
        }

        public override string ToString() {
            return "" + columns + rows;
        }
    }
}
