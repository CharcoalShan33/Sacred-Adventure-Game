using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class LevelManager : MonoBehaviour
{
    [SerializeField] Tilemap[] tileMaps;

    //bounds
    private Vector3 bottomLimit;
    private Vector3 topLimit;

    private Vector3 offset = new Vector3(0.5f, 1f, 0f);
    // Start is called before the first frame update
    void Start()
    {
       foreach (var tiles in tileMaps)
        {
            bottomLimit = tiles.localBounds.min + offset;
            topLimit = tiles.localBounds.max + -offset;
        }

        Player.instance.SetBounds(bottomLimit, topLimit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
