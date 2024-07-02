using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    CinemachineVirtualCamera cam;

    [SerializeField] PlayerStats[] pStats;

    public bool gameMenuOpen, dialogBoxOpen, shopOpen, craftOpen;

    public bool isBattleActive;

    public int money;

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
        if(gameMenuOpen || dialogBoxOpen || shopOpen || craftOpen || isBattleActive)
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
