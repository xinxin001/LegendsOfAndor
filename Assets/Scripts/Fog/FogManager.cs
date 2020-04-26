using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Fog> Fogs;
    private List<string> FogTypes = new List<string>() { "EC", "EC", "EC", "EC", "EC", "SP", "WP2", "WP3", "GD", "GD", "GD", "GR", "GR", "WS", "BR" };
    private static Random rng = new Random();
    public Sprite ImageFogGold;
    public Sprite ImageFogEventCard;
    public Sprite ImageFogWineskin;
    public Sprite ImageFogWillpower2;
    public Sprite ImageFogWillpower3;
    public Sprite ImageFogGor;
    public Sprite ImageForBrew;
    public Sprite ImageFogStrengthPoint;
    public Sprite ImageFogHidden;

    void Start()
    {
        //shuffle the fogtypes list
        var count = FogTypes.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = FogTypes[i];
            FogTypes[i] = FogTypes[r];
            FogTypes[r] = tmp;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void randomizeFogTokens()
    {
        for (int i = 0; i < Fogs.ToArray().Length; i++)
        {
            Sprite CurrentSprite;
            if (FogTypes[i] == "EC") {
                CurrentSprite = ImageFogEventCard;
                Fogs[i].SetType(FogTypes[i], CurrentSprite);
            }
            else if (FogTypes[i] == "SP")
            {
                CurrentSprite = ImageFogStrengthPoint;
                Fogs[i].SetType(FogTypes[i], CurrentSprite);
            }
            else if (FogTypes[i] == "WP2")
            {
                CurrentSprite = ImageFogWillpower2;
                Fogs[i].SetType(FogTypes[i], CurrentSprite);
            }
            else if (FogTypes[i] == "WP3")
            {
                CurrentSprite = ImageFogWillpower3;
                Fogs[i].SetType(FogTypes[i], CurrentSprite);
            }
            else if (FogTypes[i] == "GD")
            {
                CurrentSprite = ImageFogGold;
                Fogs[i].SetType(FogTypes[i], CurrentSprite);
            }
            else if (FogTypes[i] == "GR")
            {
                CurrentSprite = ImageFogGor;
                Fogs[i].SetType(FogTypes[i], CurrentSprite);
            }
            else if (FogTypes[i] == "WS")
            {
                CurrentSprite = ImageFogWineskin;
                Fogs[i].SetType(FogTypes[i], CurrentSprite);
            }
            else if (FogTypes[i] == "BR")
            {
                CurrentSprite = ImageForBrew;
                Fogs[i].SetType(FogTypes[i], CurrentSprite);
            }


            
        }
    }
    
}
