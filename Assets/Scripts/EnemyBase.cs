using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    bool inBattle;

    [SerializeField]
    float enemySpeed;

    float xMove;
    float yMove;


    [SerializeField]
    float chaseDistance;

    [SerializeField]
    float attackRange;

    

    SpriteRenderer spRender;

    Rigidbody2D rig;

   public Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        if (rig == null)
        {
            Debug.Log("Find the component... or add one");
        }

        spRender = GetComponentInChildren<SpriteRenderer>();
        if (spRender == null)
        {
            Debug.Log("Find the component... or add one");
        }


        _anim = GetComponentInChildren<Animator>();
        if (_anim == null)
        {
            Debug.Log("Find the component... or add one");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inBattle)
        {
            BattleAction();
        }
        else
        {
            EnemyStates();
        }
    }

    void EnemyStates()
    {


    }


    public void BattleAction()
    {

        if (inBattle)
        {
                _anim.SetFloat("moveX", -1);
                _anim.SetTrigger("Hit Target");

        }

    }

    

}

