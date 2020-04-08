
public class Rune : Article
{
    public enum Color {blue, gold, green};
    Color color;

    public Rune(Color color)
    {
        this.color = color;
    }

    public Rune(int color)
    {
        if (color == 0)
        {
            this.color = Color.blue;
        }
        else if (color == 1)
        {
            this.color = Color.gold;
        }
        else if (color == 2)
        {
            this.color = Color.green;
        }
        else throw new System.Exception("Invalid Rune Color Code!");
    }

    //public override bool Use()
    //{
    //    throw new System.Exception("Rune is not usable!");
    //}
}
