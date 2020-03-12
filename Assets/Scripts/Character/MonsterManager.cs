using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public List<Monster> monsterList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveAllMonsters()
    {
        // monsterList.Sort();
        print(monsterList);
        
        for(int i=0; i< monsterList.ToArray().Length; i++)
        {
            monsterList[i].move();
        }
    }
}
