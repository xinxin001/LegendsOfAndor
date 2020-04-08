
public class Telescope : Article
{
    Hero holder;
    Region region;

    public Telescope(Hero holder)
    {
        this.holder = holder;
    }

    public bool Use(Article article)
    {
        //TODO: check whether Hero holder is stopped on a space
        //TODO: uncover the article
        return true;
    }
}
