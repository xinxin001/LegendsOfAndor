
public class Wineskin : Article
{
    public enum WineState { full, half };
    public WineState state;

    public Wineskin(WineState state = WineState.full)
    {
        this.state = state;
    }

    public bool Use()
    {
        if (state.Equals(WineState.full))
        {
            state = WineState.half;
            return true;
        }
        else if (state.Equals(WineState.half))
        {
            Destroy(gameObject);
            return false;
        }
        else throw new System.Exception("Wineskin State Error!");
    }
}
