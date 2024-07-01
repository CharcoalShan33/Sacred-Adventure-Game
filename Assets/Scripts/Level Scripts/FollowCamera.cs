using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    Transform _target;

    [SerializeField]
    Tilemap _tile;

    private Vector3 bottomLimit;
    private Vector3 topLimit;

    private float height;
    private float width;

    private Camera _cam;

    private void Awake()
    {
        _cam = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        _target = FindObjectOfType<Player>().transform;

        if(_target == null)
        {
            Debug.LogError("Find the Object. Check the name or the type of object.");
        }
        //half of the camera in orthographic mode
        height = _cam.orthographicSize;
        // how wide the screen is. the aspect ratio
        width = height * _cam.aspect;
        // the bounds on the top and the bottom
        Vector3 newLimitOne = new Vector3(width, height, 0f);
        Vector3 newLimitTwo = new Vector3(-width, - height, 0f);
        bottomLimit = _tile.localBounds.min + newLimitOne ;
        topLimit = _tile.localBounds.max + newLimitTwo;


        Player playerMove = _target.GetComponent<Player>();
        playerMove.SetBounds(_tile.localBounds.min, _tile.localBounds.max);
       

    }

    // Update is called once per frame
    
    void LateUpdate()
    {
        transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);

        //keep the camera into bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLimit.x, topLimit.x), Mathf.Clamp(transform.position.y, bottomLimit.y, topLimit.y), transform.position.z);
    }
}
