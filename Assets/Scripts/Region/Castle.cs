using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public CastleShield[] shields;
    public int CastleHealth;
    public Region region;

    private void Awake()
    {
        region = GetComponent<RegionHandler>().region;
    }

    void Start()
    {
        CastleHealth = 2;
    }
    void Update()
    {
        updateShields();
        if(region.monster != null)
        {
            MonsterManager monsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
            monsterManager.DestroyMonster(region.monster.gameObject.GetComponent<Monster>());
            region.monster = null;
            CastleHealth -= 1;
        }
    }

    void updateShields()
    {
        if (CastleHealth == 0)
        {
            shields[0].broken = true;
            shields[1].broken = true;
            shields[2].broken = true;
            shields[3].broken = true;
            shields[4].broken = true;
            shields[5].broken = true;
        }
        else if (CastleHealth == 1)
        {
            shields[0].broken = false;
            shields[1].broken = true;
            shields[2].broken = true;
            shields[3].broken = true;
            shields[4].broken = true;
            shields[5].broken = true;
        }
        else if (CastleHealth == 2)
        {
            shields[0].broken = false;
            shields[1].broken = false;
            shields[2].broken = true;
            shields[3].broken = true;
            shields[4].broken = true;
            shields[5].broken = true;
        }
        else if (CastleHealth == 3)
        {
            shields[0].broken = false;
            shields[1].broken = false;
            shields[2].broken = false;
            shields[3].broken = true;
            shields[4].broken = true;
            shields[5].broken = true;
        }
        else if (CastleHealth == 4)
        {
            shields[0].broken = false;
            shields[1].broken = false;
            shields[2].broken = false;
            shields[3].broken = false;
            shields[4].broken = true;
            shields[5].broken = true;
        }
        else if (CastleHealth == 5)
        {
            shields[0].broken = false;
            shields[1].broken = false;
            shields[2].broken = false;
            shields[3].broken = false;
            shields[4].broken = false;
            shields[5].broken = true;
        }
        else if (CastleHealth == 6)
        {
            shields[0].broken = false;
            shields[1].broken = false;
            shields[2].broken = false;
            shields[3].broken = false;
            shields[4].broken = false;
            shields[5].broken = false;
        }
    }
}
