using System;
public class Peao : Peça
{
    public Peao(int x, int y, string imagem, Enumcor cor) : base(x, y, imagem, cor) { }

    public override bool Verificarmovimento(int destinoX, int destinoY)
    {
        
        int direcao = cor == Enumcor.Branco ? 1 : -1; // o ponto de interrogação é como se fosse if e else, só que bem menor

       
        if (destinoX == X && destinoY == Y + direcao)
        {
            return true;
        }

       
        if (destinoX == X && (Y == 1 && cor == Enumcor.Branco || Y == 6 && cor == Enumcor.Preto) && destinoY == Y + (direcao * 2))
        {
            return true;
        }

       
        if (Math.Abs(destinoX - X) == 1 && destinoY == Y + direcao)
        {
            return true;
        }

        return false;
    }
}
