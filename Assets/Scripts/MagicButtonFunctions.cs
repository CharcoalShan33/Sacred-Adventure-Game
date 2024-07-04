using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagicButtonFunctions : MonoBehaviour
{
    public  string spellName;
    public int spellCost;
    public TextMeshProUGUI spellNameText, spellCostText;
    // Start is called before the first frame update



    public void Press()
    {
        if (BattleManager.instance.GetBattleCharacter().currentMana >= spellCost)
        {
            BattleManager.instance.magicMenu.SetActive(false);
            BattleManager.instance.OpenMagicMenu(spellName);
            BattleManager.instance.GetBattleCharacter().currentMana -= spellCost;

        }
    }
   
}
