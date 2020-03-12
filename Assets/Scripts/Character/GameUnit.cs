using UnityEngine;
[System.Serializable]
public abstract class GameUnit : MonoBehaviour
{
    private int SP;
    private int WP;
    public GameObject currentRegion;

    int getSP()
    {
        return SP;
    }

    int getWP()
    {
        return WP;
    }

    void setSP(int SP)
    {
        this.SP = SP;
    }

    void setWP(int WP)
    {
        this.WP = WP;
    }
}
