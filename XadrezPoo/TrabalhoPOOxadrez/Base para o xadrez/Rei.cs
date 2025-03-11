using System;
public class Rei : Peça{
    public Rei(int x, int y, string img, Enumcor cor) : base( x, y,  img, cor){
        
    }
    public override bool Verificarmovimento(int destinoX, int destinoY)
    {
        // Calcula a diferença entre as posições
        int difX = Math.Abs(destinoX - X);
        int difY = Math.Abs(destinoY - Y);

        // O Rei pode se mover apenas uma casa em qualquer direção
        return difX <= 1 && difY <= 1;
    }

}