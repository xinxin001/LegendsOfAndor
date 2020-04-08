
public class Bow : Article
{
    Hero holder;

    public Bow(Hero holder)
    {
        this.holder = holder;
    }

    public bool Use(Monster monster)
    {
        //TODO: check adjacency of the monster to the holder, return true if adjacent
        return true;
    }
}
