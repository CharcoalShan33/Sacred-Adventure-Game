using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    private Player player;

    private EnemyBase enemy;

   

    private void Awake()
    {
        player = GetComponent<Player>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<EnemyBase>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Initiate(bool isPlayerTeam)
    {


        if (isPlayerTeam)
        {
            player.inBattle = true;

        }
        else
        {
            enemy.BattleAction();
            Debug.Log("");
        }


    }

}
