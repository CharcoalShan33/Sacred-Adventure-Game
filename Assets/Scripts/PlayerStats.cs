using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{


    [SerializeField] string playerName;

    [SerializeField] int maxLevel = 100;
    [SerializeField] int playerLevel = 1;
    [SerializeField] int currentXP;
    [SerializeField] int[] xpForEachLevel;
    [SerializeField] int baseLevelXP = 100;

    [SerializeField] int maxHP = 100;
    [SerializeField] int currentHP;


    [SerializeField] int maxMana = 30;
    [SerializeField] int currentMana;

    [SerializeField] int defense; // resist physical attacks
    [SerializeField] int physAttack;// physical attacks

    [SerializeField] int magAttack; // magical attacks
    [SerializeField] int magicRES; // resist magical attacks
    [SerializeField] int speed; ///  determines who will act first.


    //[SerializeField] int dexterity; -- ability to hold a weapon

    [ContextMenu("Level Up")]
    private void Start()
    {

        xpForEachLevel = new int[maxLevel];
        xpForEachLevel[1] = baseLevelXP;

        for (int i = 2; i < xpForEachLevel.Length; i++)
        {
            //print("Level: " + i);
            //xpForEachLevel[i] = baseLevelXP * i;

            xpForEachLevel[i] = (int)(.02f * i * i * i + 3.06f * i * i + 105.6f * i);

            // dark souls equation: y = 0.02x^3 + 3.06x^2 + 105.6x - 895.... no 895.
            // y is the experience and x is the level.

            // in this case, i is the level.

            //xpForEachLevel[i] = (int)(Mathf.Pow(.02f *i, 3) + (Mathf.Pow(3.06f * i, 2)) + (105.6f * i));
            //xpForEachLevel[i] = (int)((0.2 * i * Mathf.Exp(3)) + (3.06 * i * Mathf.Exp(2) + (105.6 * i)));
        }

        print(Mathf.Pow(6, 1.8f));
        print(Mathf.Exp(6));
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddExp(100);
        }
    }

    public void AddExp(int amount)
    {
        currentXP += amount; // current amount of xp == current amount + xp required.
        // if current xp is greater than the xp required for each level
        if (currentXP > xpForEachLevel[playerLevel])
        {
            // we subtract the remainer for the next level.
            currentXP -= xpForEachLevel[playerLevel];
            // raise level by one.
            playerLevel++;

            int randomStat = Random.Range(1, 5);
            if (playerLevel % 2 == 0)
            {


                physAttack += randomStat;
                defense += randomStat;
                speed += randomStat;



            }
            else
            {
                magAttack += randomStat;
                magicRES += randomStat;

            }

            maxHP = Mathf.FloorToInt(maxHP * 1.5f);
            currentHP = maxHP;

            maxMana = Mathf.FloorToInt(maxMana * 1.05f);
            currentHP = maxHP;
        }




    }
}
