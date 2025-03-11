using System.ComponentModel.DataAnnotations;
public enum Enumcor{
    Branco,
    Preto,
    vazio
}

public abstract class Peça{
    public int X, Y;
    public string img = "";
    public PictureBox pictureBox = new PictureBox();
    public Enumcor cor {get; set;}

    public Peça(int x, int y, string img, Enumcor cor){
        
        this.X = x/50;
        this.Y = y/50;
        this.cor = cor;

        pictureBox.Location = new Point(x , y);
        pictureBox.Size = new Size(50, 50); // O Tamanho é fixo
        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        
        try{
            this.img = Path.Combine(Application.StartupPath, "imagens", img);
             pictureBox.Image = Image.FromFile(this.img); 
             
        }catch (Exception ex){
        }

    }
    public abstract bool Verificarmovimento(int destinoX, int destinoY);

}