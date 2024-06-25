using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer spRender;

    [SerializeField]
    float movementSpeed;


    private Rigidbody2D rig;
   public Animator _anim;

    [SerializeField]
    private float attackRate;
    private float lastAttack;

    //bounds
    //private Vector3 bottomLimit;
    // private Vector3 topLimit;

    float xInput;
    float yInput;
   Vector2 movement;

    
    // facing sprite direction
    Vector2 direction;

   

    bool faceX;
    bool faceY;

   public bool inBattle;

    private void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Enemy").transform;
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
    private void FixedUpdate()
    {
        rig.velocity = movement * movementSpeed;

    }


    private void Update()
    {
        if (!inBattle)
        {
           
            Movement();
        }

        Attack();

    }

    void Attack()
    {
        float decreaseTime = Time.time - lastAttack;

        if (Input.GetKeyDown(KeyCode.Space) && decreaseTime > attackRate)
        {
            lastAttack = Time.time;
            _anim.SetTrigger("Hit Target");
        }
    }

    void Movement()
    {
        inBattle = false;
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        movement = new Vector2(xInput, yInput);

        if (movement.x != 0 || movement.y != 0)
        {
            _anim.SetFloat("moveX", movement.x);
            _anim.SetFloat("moveY", movement.y);


            if(xInput == 1 || xInput == -1 || yInput == 1 || yInput == -1)
            {
                _anim.SetFloat("lastX", xInput);
                _anim.SetFloat("lastY", yInput);
            }
        }

       
        

    }

    
    
}