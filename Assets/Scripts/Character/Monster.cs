
public class Monster : GameUnit
{
    new string name;
    int maxWillPower;
    int maxStrength;

    void createMonster(string name)
    {
        this.name = name;
    }

    string getName()
    {
        return name;
    }

    int getMaxWillPower()
    {
        return maxWillPower;
    }

    int getMaxStrength()
    {
        return maxStrength;
    }

    void setMaxWillPower(int wp)
    {
        maxWillPower = wp;
    }

    void setMaxStrength(int sp)
    {
        maxStrength = sp;
    }
}
