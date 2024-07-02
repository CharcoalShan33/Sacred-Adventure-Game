using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator _anim;
    private Transform target;

    [SerializeField]
    float speed = 4f, minRange = 2f, maxRange = 5f; 

    [SerializeField] Transform home;

    float deltaX;
    float deltaY;
     
    // Start is called before the first frame update
    void Start()
    {
        home.parent = null;
        _anim = GetComponentInChildren<Animator>();
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(target.position, transform.position) <= maxRange && Vector2.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
        else if(Vector2.Distance(target.position, transform.position)> maxRange)
        {
            GoHome();
        }
    }

    public void FollowPlayer()
    {

        float deltaX = Mathf.Abs(target.position.x - transform.position.x);
        float deltaY = Mathf.Abs(target.position.y - transform.position.y);

        _anim.SetBool("isMoving", true);
        _anim.SetFloat("moveX", deltaX);
        _anim.SetFloat("moveY", deltaY);
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        
    }

    public void GoHome()
    {
        float deltaX = Mathf.Abs(home.position.x - transform.position.x);
        float deltaY = Mathf.Abs(home.position.y - transform.position.y);
        _anim.SetFloat("moveX", deltaX);
        _anim.SetFloat("moveY", deltaY);
        transform.position = Vector2.MoveTowards(transform.position, home.transform.position, speed* Time.deltaTime);
    }
     public void AttackPlayer()
    {

    }

}
