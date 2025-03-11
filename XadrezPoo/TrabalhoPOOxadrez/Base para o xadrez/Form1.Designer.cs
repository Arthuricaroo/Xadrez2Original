using System;
using System.Runtime.CompilerServices;
namespace xadrez;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
        
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(500, 500);
        this.Text = "Xadrez";

        
        InicializarTabuleiro();
              
        
    }

    public void InicializarTabuleiro()
    {
      
  
    
                for(int X = 0; X < 8; X ++){
                for(int Y = 0; Y < 8; Y++){
                        int i = X; int j = Y;
                        if (i % 2 == 0 ^ j % 2 == 0){
                                tabuleiro[i, j] = new CasaVazia( i*50, j*50, "casaVaziaclaro.png", Enumcor.vazio);
                                this.Controls.Add(tabuleiro[i,j].pictureBox);
                                tabuleiro[i,j].pictureBox.BringToFront();
                                tabuleiro[i,j].pictureBox.Click += (sender,args) => {cliqueNoTabuleiro(tabuleiro[i,j]);};
                        }
                        else{
                                tabuleiro[i, j] = new CasaVazia( i*50, j*50, "casaVaziaescuro.png", Enumcor.vazio);
                                this.Controls.Add(tabuleiro[i,j].pictureBox);
                                tabuleiro[i,j].pictureBox.BringToFront();
                                tabuleiro[i,j].pictureBox.Click += (sender,args) => {cliqueNoTabuleiro(tabuleiro[i,j]);};
                        }
                }
        }
           
        

        Rei reiBranco = new Rei(200,0,"reiBranco.png", Enumcor.Branco);
        criarpeça(reiBranco);

        Rei reiPreto = new Rei(200,350,"reiPreto.png", Enumcor.Preto);
        criarpeça(reiPreto);

        Rainha rainhaBranca = new Rainha(150, 0, "rainhaBranca.png", Enumcor.Branco);
        criarpeça(rainhaBranca);

        Rainha rainhaPreta = new Rainha(150, 350, "rainhaPreta.png", Enumcor.Preto);
        criarpeça(rainhaPreta);

        Torre torreBranca = new Torre(0,0, "torreBranca.png", Enumcor.Branco);
        criarpeça(torreBranca);
        Torre torreBranca1 = new Torre(350,0, "torreBranca.png", Enumcor.Branco);
        criarpeça(torreBranca1);


        Torre torrePreta = new Torre(0, 350, "torrePreta.png", Enumcor.Preto);
        criarpeça(torrePreta);
        Torre torrePreta1 = new Torre(350, 350, "torrePreta.png", Enumcor.Preto);
        criarpeça(torrePreta1);


        Bispo bispoBranco = new Bispo(100, 0, "bispoBranco.png", Enumcor.Branco);
        criarpeça(bispoBranco);
        Bispo bispoBranco1 = new Bispo(250, 0, "bispoBranco.png", Enumcor.Branco);
        criarpeça(bispoBranco1);


        Bispo bispoPreto = new Bispo(100, 350, "bispoPreto.png", Enumcor.Preto);

        criarpeça(bispoPreto);
        Bispo bispoPreto1 = new Bispo(250, 350, "bispoPreto.png", Enumcor.Preto);
        criarpeça(bispoPreto1);

       
        Cavalo cavaloBranco = new Cavalo(50, 0, "cavaloBranco.png", Enumcor.Branco);
        criarpeça(cavaloBranco);
        Cavalo cavaloBranco1 = new Cavalo(300, 0, "cavaloBranco.png", Enumcor.Branco);
        criarpeça(cavaloBranco1);

        Cavalo cavaloPreto = new Cavalo(50, 350, "cavaloPreto.png", Enumcor.Preto);

        criarpeça(cavaloPreto);
        Cavalo cavaloPreto1 = new Cavalo(300, 350, "cavaloPreto.png", Enumcor.Preto);
        criarpeça(cavaloPreto1);
        
    for (int j = 0; j < 8; j++)
    {
        Peao peaoBranco = new Peao(j * 50, 50, "peaoBranco.png", Enumcor.Branco);
        criarpeça(peaoBranco);
    }

    
    for (int j = 0; j < 8; j++)
    {
        Peao peaoPreto = new Peao(j * 50, 300, "peaoPreto.png", Enumcor.Preto);
        criarpeça(peaoPreto);
    }


   



    
    }

    
    public void criarpeça(Peça peca)
    {
     tabuleiro[peca.X, peca.Y] = peca;
        this.Controls.Add(peca.pictureBox);
        peca.pictureBox.BringToFront();
        peca.pictureBox.Click += (sender, args) => 
        {
            cliqueNoTabuleiro(peca);
        };
    }
     #endregion
}

