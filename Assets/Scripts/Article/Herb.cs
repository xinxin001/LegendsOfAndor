
public class Herbe : Article
{
    public int strength;

    public Herbe(int strength)
    {
        if (strength != 3 && strength != 4) throw new System.Exception("Herb Value Error!");
        this.strength = strength;
    }

    public bool Use()
    {
        Destroy(gameObject);
        return true;
    }
}
