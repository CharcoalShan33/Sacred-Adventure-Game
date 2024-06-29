using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;


    [SerializeField] PlayerStats[] pStats;

    public bool gameMenuOpen, dialogBoxOpen, shopOpen, craftOpen;

    public bool isBattleActive;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);

        pStats = FindObjectsOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMenuOpen || dialogBoxOpen || shopOpen || craftOpen)
        {
            Player.instance.DeactivateMovement(true);
        }
        else
        {
            Player.instance.DeactivateMovement(false);
        }
    }

    public PlayerStats[] GetPlayerStats()
    {
        return pStats;
    }
    public bool BattleIsAlive(bool battle)
    {
        return battle;
    }
}
