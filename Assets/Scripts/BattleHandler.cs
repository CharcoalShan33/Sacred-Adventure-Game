using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    [SerializeField]
    private Transform pfCharacterBattle;
    [SerializeField]
    private Transform spawnSpotPlayer;
    [SerializeField]
    private Transform spawnSpotEnemy;
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

        Instantiate(pfCharacterBattle, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
