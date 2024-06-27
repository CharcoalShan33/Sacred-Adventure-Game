using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    SpriteRenderer spRender;

    [SerializeField]
    float movementSpeed;

    [SerializeField]
    Tilemap tileMap;

    private Rigidbody2D rig;
    public Animator _anim;

    [SerializeField]
    private float attackRate;
    private float lastAttack;

    //bounds
    private Vector3 bottomLimit;
    private Vector3 topLimit;

    float xInput;
    float yInput;
    Vector2 movement;

    AnimationClip aClip;

    private Vector3 offset = new Vector3(.5f, .1f, 0f);
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


        bottomLimit = tileMap.localBounds.min + offset;
        topLimit = tileMap.localBounds.max + -offset;
        
    }
    private void FixedUpdate()
    {
        movement = new Vector2(xInput, yInput);
        rig.velocity = movement * movementSpeed;

    }


    private void Update()
    {
        if (!inBattle)
        {

            Movement();
        }

        Attack();

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLimit.x, topLimit.x), Mathf.Clamp(transform.position.y, bottomLimit.y, topLimit.y), transform.position.z);

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
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");



        if (movement.x != 0 || movement.y != 0)
        {
            _anim.SetFloat("moveX", movement.x);
            _anim.SetFloat("moveY", movement.y);
        }

        if (xInput != 0 || yInput != 0)
        {
            _anim.SetFloat("lastX", movement.x);
            _anim.SetFloat("lastY", movement.y);
        }



    }

    
}