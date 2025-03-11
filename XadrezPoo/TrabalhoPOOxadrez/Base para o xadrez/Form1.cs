using System;

namespace xadrez;
partial class Form1 : Form
{
    public static int sizeOfTabuleiro = 8;
    private int origemX = -1, origemY = -1; 
    public Peça[,] tabuleiro = new Peça[sizeOfTabuleiro,sizeOfTabuleiro];
    private PictureBox pecaSelecionada = null;
    public bool  vezBranco = true;
    public int numerojogadas = 0;
    public Form1(){
        InitializeComponent();
    }

    public void cliqueNoTabuleiro(Peça peca)
    {
        if (origemX == -1 && origemY == -1) // Primeiro clique: seleciona a peça
        {
            if (peca is not CasaVazia)
            {
                if (vezBranco && peca.cor == Enumcor.Branco)
                {
                    pecaSelecionada = peca.pictureBox;
                    origemX = peca.X;
                    origemY = peca.Y;
                    MessageBox.Show($"Peça selecionada em ({peca.X}, {peca.Y})");
                }
                else if (!vezBranco && peca.cor == Enumcor.Preto)
                {
                    pecaSelecionada = peca.pictureBox;
                    origemX = peca.X;
                    origemY = peca.Y;
                    MessageBox.Show($"Peça selecionada em ({peca.X}, {peca.Y})");
                }
                else
                {
                    MessageBox.Show("Vez do outro jogador");
                }
            }
        }
        else // Segundo clique: tenta mover a peça
        {
            Peça pecaOrigem = tabuleiro[origemX, origemY];
            Peça pecaDestino = tabuleiro[peca.X, peca.Y];

            if (pecaOrigem.cor == pecaDestino.cor)
            {
                MessageBox.Show("Movimento Inválido, porque é do mesmo time!");
                pecaSelecionada = null;
                origemX = -1;
                origemY = -1;
                return;
            }

            if (pecaOrigem is Torre || pecaOrigem is Rainha || pecaOrigem is Bispo)
            {
                if (!CaminhoLivre(pecaOrigem, peca.X, peca.Y))
                {
                    MessageBox.Show("O caminho está bloqueado!");
                    pecaSelecionada = null;
                    origemX = -1;
                    origemY = -1;
                    return;
                }
            }

 
            if (!pecaOrigem.Verificarmovimento(peca.X, peca.Y))
            {
                MessageBox.Show("Movimento Inválido!");
                pecaSelecionada = null;
                origemX = -1;
                origemY = -1;
                return;
            }

            if (pecaDestino is CasaVazia) 
            {
                
                tabuleiro[origemX, origemY] = new CasaVazia(origemX * 50, origemY * 50, "casaVazia.png", Enumcor.vazio);
                tabuleiro[peca.X, peca.Y] = pecaOrigem;

                
                pecaOrigem.X = peca.X;
                pecaOrigem.Y = peca.Y;

                
                pecaOrigem.pictureBox.Location = new Point(peca.X * 50, peca.Y * 50);
            }
            else 
            {
                this.Controls.Remove(pecaDestino.pictureBox);
                tabuleiro[peca.X, peca.Y] = pecaOrigem;
                tabuleiro[origemX, origemY] = new CasaVazia(origemX * 50, origemY * 50, "casaVazia.png", Enumcor.vazio);

                
                pecaOrigem.X = peca.X;
                pecaOrigem.Y = peca.Y;
                pecaOrigem.pictureBox.Location = new Point(peca.X * 50, peca.Y * 50);
                if (pecaDestino is Rei){
                    switch(pecaDestino.cor){
                        case Enumcor.Branco:
                            MessageBox.Show("Time preto é o vencedor!");
                            Application.Exit();
                        break;

                        case Enumcor.Preto:
                            MessageBox.Show("Time branco é o vencedor!");
                            Application.Exit();
                        break;
                    }
                }
            }


            

            
            switch (vezBranco)
            {
                case true:
                    vezBranco = false;
                    break;
                case false:
                    vezBranco = true;
                    break;
            }

          
            this.Refresh();
            

      
            pecaSelecionada = null;
            origemX = -1;
            origemY = -1;
        }
    }
  
    private bool CaminhoLivre(Peça pecaOrigem, int destinoX, int destinoY)
    {
        if (pecaOrigem is Torre)
        {
            return VerificarCaminhoTorre(pecaOrigem.X, pecaOrigem.Y, destinoX, destinoY);
        }
        else if (pecaOrigem is Bispo)
        {
            return VerificarCaminhoBispo(pecaOrigem.X, pecaOrigem.Y, destinoX, destinoY);
        }
        else if (pecaOrigem is Rainha)
        {
            return VerificarCaminhoRainha(pecaOrigem.X, pecaOrigem.Y, destinoX, destinoY);
        }
        return true;
    }

   
    private bool VerificarCaminhoTorre(int origemX, int origemY, int destinoX, int destinoY)
    {
        if (origemX == destinoX) 
        {
            int start = Math.Min(origemY, destinoY) + 1;
            int end = Math.Max(origemY, destinoY);
            for (int y = start; y < end; y++)
            {
                if (tabuleiro[origemX, y] is not CasaVazia)
                {
                    return false;  
                }
            }
        }
        else if (origemY == destinoY)  
        {
            int start = Math.Min(origemX, destinoX) + 1;
            int end = Math.Max(origemX, destinoX);
            for (int x = start; x < end; x++)
            {
                if (tabuleiro[x, origemY] is not CasaVazia)
                {
                    return false;  
                }
            }
        }
        return true; 
    }

    
    private bool VerificarCaminhoBispo(int origemX, int origemY, int destinoX, int destinoY)
    {
        
        if (Math.Abs(origemX - destinoX) != Math.Abs(origemY - destinoY))
        {
            return false;  
        }

       
        int dx;
        int dy;

      
        if (destinoX > origemX)
        {
            dx = 1;
        }
        else
        {
            dx = -1;
        }

        if (destinoY > origemY)
        {
            dy = 1;
        }
        else
        {
            dy = -1;
        }

        int x = origemX + dx;
        int y = origemY + dy;

        for (; x != destinoX && y != destinoY; x += dx, y += dy)
        {
            if (tabuleiro[x, y] is not CasaVazia)
            {
                return false; 
            }
        }

        return true;  
    }

    
    private bool VerificarCaminhoRainha(int origemX, int origemY, int destinoX, int destinoY)
    {
        
        if (Math.Abs(origemX - destinoX) == Math.Abs(origemY - destinoY))
        {
            return VerificarCaminhoBispo(origemX, origemY, destinoX, destinoY);
        }
        
        else if (origemX == destinoX || origemY == destinoY)
        {
            return VerificarCaminhoTorre(origemX, origemY, destinoX, destinoY);
        }

        return false;  
    }
}