using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float _pSpeed;


    private Vector2 shootDir = Vector2.right;
    private void Start()
    {

      
    }

    
    private void Update()
    {
        //transform.position += shootDir * _pSpeed * Time.deltaTime;
        transform.Translate( shootDir * _pSpeed * Time.deltaTime);

        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "BattleEnemy")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
