using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour
{
     private EnemyBase enemy;



    private void Awake()
    {
        enemy = GetComponent<EnemyBase>();
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
        switch (isPlayerTeam)
        {
            case true:
                {
                    enemy._anim.SetFloat("moveX", -1);
                    enemy._anim.Play("Idle");
                    
                }
                break;

            case false:
                {
                    enemy.BattleAction();
                }
                break;


        }

    }
}
