using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    [SerializeField] GameObject battleBG;

    [SerializeField] Transform[] playerPosition,  enemiesPosition;

    [SerializeField] BattleCharacters[] playerPref, enemyPref;

    private void Awake()
    {
        instance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBatttle(string[] multiple )
    {
        //if(battleActive == true)
        {
            
        }
    }


}
