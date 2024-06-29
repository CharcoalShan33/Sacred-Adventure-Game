using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Battle Stats.asset",menuName =" Characters" )]

public class BattleCharacters : ScriptableObject
{
    public bool isPlayer;

    public string characterName;

    public string[] attacksAvailable;

    public int currentHP, maxHp, currentMana, maxMana, speed, strength, defence, weaponPower, armorValue;

    public bool isDead;

   
}
