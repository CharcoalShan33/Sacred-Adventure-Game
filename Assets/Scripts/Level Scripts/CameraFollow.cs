using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    private Player playTarget;

    CinemachineVirtualCamera virtualCam;

    // Start is called before the first frame update
    void Start()
    {
        playTarget = FindObjectOfType<Player>();
        virtualCam = GetComponent<CinemachineVirtualCamera>();


        virtualCam.Follow = playTarget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
