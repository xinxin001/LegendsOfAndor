using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MonsterManager : MonoBehaviour
{
    public List<Monster> monsterList;
    public static PrinceThorald princeThorald;
    // Start is called before the first frame update
    void Start()
    {
        princeThorald = GameObject.Find("PrinceThorald").GetComponent<PrinceThorald>();
    }

    // Update is called once per frame
    void Update()
    {
        //finds all monsters
        GameObject[] monsterGameObjects = GameObject.FindGameObjectsWithTag("Monster");
        foreach(GameObject monsterGameObject in monsterGameObjects)
        {
            if(monsterList.IndexOf(monsterGameObject.GetComponent<Monster>()) < 0)
            {
                monsterList.Add(monsterGameObject.GetComponent<Monster>());
            }
        }
        //finds prince thorald
        princeThorald = GameObject.Find("PrinceThorald").GetComponent<PrinceThorald>();
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

    public void DestroyMonster(Monster monster)
    {
        monsterList.Remove(monster);
        Destroy(monster.gameObject);
    }
}
