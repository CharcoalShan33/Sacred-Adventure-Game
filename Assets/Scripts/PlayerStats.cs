using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{


    public string playerName;

    [SerializeField] int maxLevel = 100;
    public int playerLevel = 1;
    public int currentXP;
    [SerializeField] int[] xpForEachLevel;
    [SerializeField] int baseLevelXP = 100;

    public int maxHP = 100;
    public int currentHP;
    public  int maxMana = 30;
    public int currentMana;

   public  int defense; // resist physical attacks
    public int physAttack;// physical attacks

    public int magAttack; // magical attacks
    public int magicRES; // resist magical attacks
    public int speed; ///  determines who will act first.


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


               physAttack =  physAttack += randomStat;
                defense = defense += randomStat;
                speed = speed += randomStat;

            }
            else
            {
                magAttack = magAttack += randomStat;
                magicRES = magicRES += randomStat;

            }

            maxHP = Mathf.FloorToInt(maxHP * 1.5f);
            //currentHP = maxHP;
            maxHP = currentHP;

            maxMana = Mathf.FloorToInt(maxMana * 1.05f);
            //currentHP = maxHP;
            maxMana = currentMana;
        }
    }
    

}
