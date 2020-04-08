
public class Falcon : Article
{
    Hero holder;
    public enum Side {front, back};
    public Side side;

    public Falcon(Hero holder)
    {
        this.holder = holder;
        side = Side.front;
    }

    public void Flip()
    {
        side = side.Equals(Side.front) ? Side.back : Side.front;
    }

    public void FlipToFront()
    {
        side = Side.front;
    }

    public void FlipToBack()
    {
        side = Side.back;
    }

    public bool Use(Article article, int quantity, Hero from, Hero to)
    {
        //TODO: take article of quantity from Hero "from" to Hero "to"

        return true;
    }
}
