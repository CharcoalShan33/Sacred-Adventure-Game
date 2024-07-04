using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetButtons : MonoBehaviour
{
    public string moveName;
    public int activeBattleTarget;
    public TextMeshProUGUI targetName;
    // Start is called before the first frame update
    void Start()
    {
        targetName = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Press()
    {
        BattleManager.instance.OpenTargetMenu(moveName);
    }
}
