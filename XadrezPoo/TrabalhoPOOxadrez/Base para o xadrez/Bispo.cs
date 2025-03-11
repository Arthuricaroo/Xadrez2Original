using System;

public class Bispo : Peça{
    public Bispo(int x, int y, string img, Enumcor cor) : base( x, y,  img, cor){
        
    }
    public override bool Verificarmovimento(int destinoX, int destinoY)
    {
        int difX = Math.Abs(destinoX - X);
        int difY = Math.Abs(destinoY - Y);

        return difX == difY;
     // falta a movimentação
       
    }

}