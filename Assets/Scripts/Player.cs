using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public static Player instance;
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
    bool deactivateMove = false;

    public string transitionName;

    private void Awake()
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
    }
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


    }
    private void Update()
    {
        if (deactivateMove)

        {
            movement = Vector2.zero;
            xInput = 0;
            yInput = 0;
           
        }
        else
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

        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        movement = new Vector2(xInput, yInput);


        rig.velocity = movement * movementSpeed;

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
    public void SetBounds(Vector3 bottomScreen, Vector3 topScreen)
    {
        bottomLimit = bottomScreen + offset;
        topLimit = topScreen + -offset;
    }

    public bool DeactivateMovement(bool movement)
    {
        deactivateMove = movement;
        return movement;
    }
}