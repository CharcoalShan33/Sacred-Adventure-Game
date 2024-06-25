using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{

    private static BattleHandler instance;

    public static BattleHandler GetInstance()
    {
        return instance;
    }
    


  [SerializeField]
    private Transform pfCharacterBattle;

    [SerializeField]
    private Transform spawnSpotPlayer;
    [SerializeField]
    private Transform spawnSpotEnemy;

    


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnCharacter(true);
        SpawnCharacter(false);
    }

    private void SpawnCharacter(bool isPlayerTeam)
    {
        Vector3 position;

        if(isPlayerTeam)
        {
            position = spawnSpotPlayer.position;
        }
        else
        {
            position = spawnSpotEnemy.position;
        }

       Transform charTransform =  Instantiate(pfCharacterBattle, position, Quaternion.identity);
        CharacterBattle character = charTransform.GetComponent<CharacterBattle>();
        character.Initiate(!isPlayerTeam);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
