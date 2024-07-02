using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacter : MonoBehaviour
{
    [SerializeField] bool isPlayer;

    public string characterName;

    [SerializeField] string[] attacksAvailable;

    public int currentHP, maxHp, currentMana, maxMana, speed,
    strength, defense, magicRes, magicAttack,dexterity, weaponPower, armorValue;
    public bool isDead;
    // Start is called before the first frame update
    public bool IsPlayer()
    {

        return isPlayer;
    }

    public string[] AttacksAvailable()
    {
        return attacksAvailable;
    }
    public void TakeDamage(int damageTaken)
    {
        currentHP -= damageTaken;

        if(currentHP < 0)
        {
            currentHP = 0;
        }
    }
}
