using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffects : MonoBehaviour
{
    [SerializeField] float duration;
   // [SerializeField] int number;


    // Start is called before the first frame update
    void Start()
    {
       // AudioManager.instance.PlaySFX(number);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, duration);
    }
}
