using System.Collections.Generic;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {

        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> peca;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            xeque = false;
            peca = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        // logica do movimentos das peças
        public Peca executarMovimentos(Posicao origem, Posicao destino) {

            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca capiturarPeca = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if (capiturarPeca != null) {
                capturadas.Add(capiturarPeca);
            }

            return capiturarPeca;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapiturada) {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQtdMovimentos();
            if (pecaCapiturada != null) {
                tab.colocarPeca(pecaCapiturada, destino);
                capturadas.Remove(pecaCapiturada);
            }

            tab.colocarPeca(p, origem);
        }

        //metodo que faz a efetuação dos movimentos
        public void realizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapiturada = executarMovimentos(origem, destino);

            if (estaEmCheque(jogadorAtual)) {
                desfazMovimento(origem, destino, pecaCapiturada);
                throw new TabuleiroException("Você não pode se colocar em cheque!");
            }

            if (estaEmCheque(adversario(jogadorAtual))) {
                xeque = true;
            }
            else {
                xeque = false;
            }

            turno++;
            mudaJogador();
        }

        // verifica os possíveis erros
        public void validarPosicaoDeOrigem(Posicao pos) {
            //verifica se há peça na movimentação de origem
            if (tab.peca(pos) == null) {
                throw new TabuleiroException("Não existe peca na posição de origem escolhida!");
            }

            //não deixa o jogadorAtual mecher na peça do jogador adversário
            if (jogadorAtual != tab.peca(pos).cor) {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }

            //se não for possível movimentar a peça, é efetuado uma exeção
            if (!tab.peca(pos).existMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        // impede a peça a movimentar para posições que não está possivel a mesma
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!tab.peca(origem).podeMoverPara(destino)) {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        //muda de jogador, verificando se a cor da peça é branca ou preta
        private void mudaJogador() {
            if (jogadorAtual == Cor.Branca) {
                jogadorAtual = Cor.Preta;
            }
            else {
                jogadorAtual = Cor.Branca;
            }
        }

        //diferencia as peças capturadas em relação as suas cor
        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in this.peca) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));

            return aux;
        }

        private Cor adversario(Cor cor) {

            if (cor == Cor.Branca) {
                return Cor.Preta;
            }
            else {
                return Cor.Branca;
            }
        }

        private Peca rei(Cor cor) {
            foreach (Peca x in pecasEmJogo(cor)) {
                if (x is Rei) {
                    return x;
                }
            }
            return null;
        }

        public bool estaEmCheque(Cor cor) {
            Peca R = rei(cor);
            if (R == null) {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }

            foreach (Peca x in pecasEmJogo(adversario(cor))) {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.posicao.rows, R.posicao.columns]) {
                    return true;
                }
            }
            return false;
        }

        public void colocarNovaPeca(char columns, int rows, Peca peca) {
            tab.colocarPeca(peca, new PosicaoXadrez(columns, rows).toPosicao());
            this.peca.Add(peca);
        }

        public void colocarPecas() {

            //pecas Brancas
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));

            //pecas Pretas
            colocarNovaPeca('c', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.Preta));
            colocarNovaPeca('e', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.Preta));

        }
    }
}
