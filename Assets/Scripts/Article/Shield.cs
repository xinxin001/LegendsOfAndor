
public class Shield : Article
{
    public enum ShieldState { front, back };
    public ShieldState state;

    public Shield(ShieldState state = ShieldState.front)
    {
        this.state = state;
    }

    public bool Use()
    {
        if (state.Equals(ShieldState.front))
        {
            state = ShieldState.back;
            return true;
        }
        else if (state.Equals(ShieldState.back))
        {
            Destroy(gameObject);
            return false;
        }
        else throw new System.Exception("Shield State Error!");
    }
}
