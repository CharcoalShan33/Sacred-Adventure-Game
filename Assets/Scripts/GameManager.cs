using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;


    //[SerializeField] PlayerStats[] pStats;

    // public bool gameMenuOpen, dialogBoxOpen, shopOpen

    public bool isBattleActive;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool BattleIsAlive()
    {
        return true;
    }
}
