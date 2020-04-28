using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCombat : MonoBehaviour
{

    public Sprite gors;
    public Sprite skral;
    public Sprite wardrak;

    public Image monsterIcon;
    public Text monsterName;
    public Text monsterWillpower;
    public Text monsterStrength;
    public Text monsterRewardPoints;
    public Text monsterRoll;
    public Text attackPower;

    public Monster monster;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        monsterWillpower.text = "Willpower: " + monster.willpower;
        monsterStrength.text = "Strength: " + monster.strength;
        monsterRewardPoints.text = "Reward Points: " + monster.rewardPoints;
        monsterRoll.text = "Highest rolled: " + monster.roll;
        attackPower.text = "Attack Power: " + monster.attackPower;
    }

    public void initMonsterCombat(Monster fightingMonster)
    {
        monster = fightingMonster;
        print(monster is Skral);
        if(monster is Gors)
        {
            monsterIcon.sprite = gors;
        } else if(monster is Skral)
        {
            monsterIcon.sprite = skral;
        } else if(monster is Wardrak)
        {
            monsterIcon.sprite = wardrak;
        }
        monsterName.text = monster.GetType().ToString();
    }
}
