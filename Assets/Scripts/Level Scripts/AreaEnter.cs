using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnter : MonoBehaviour
{
    public string area;

    // Start is called before the first frame update
    void Start()
    {
     
        if(area == Player.instance.transitionName)
        {
            Player.instance.transform.position = transform.position;
        }
    }

    
}
