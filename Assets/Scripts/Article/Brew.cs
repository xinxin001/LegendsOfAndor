
public class Brew : Article
{
    public enum BrewState {full, half};
    public BrewState state;

    public Brew(BrewState state = BrewState.full)
    {
        this.state = state;
    }

    public bool Use()
    {
        if (state.Equals(BrewState.full))
        {
            state = BrewState.half;
            return true;
        }
        else if (state.Equals(BrewState.half))
        {
            Destroy(gameObject);
            return false;
        }
        else throw new System.Exception("Brew State Error!");
    }
}
