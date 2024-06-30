using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    private Player playTarget;

    CinemachineVirtualCamera virtualCam;

    

    // Start is called before the first frame update
    void Start()
    {
        playTarget = FindObjectOfType<Player>();
        virtualCam = GetComponent<CinemachineVirtualCamera>();

        //SceneManager.sceneLoaded += OnSceneLoaded;
        virtualCam.Follow = playTarget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "BattleScene" || scene.name == "Boss")
        {




            //SceneManager.sceneLoaded -= OnSceneLoaded;
            // virtualCam.enabled = true;
            // virtualCam.Follow = playTarget.transform;
            //virtualCam.Follow = null;
            //playTarget.enabled = false;

            virtualCam.gameObject.SetActive(false);
        }
        else
        {
            virtualCam.gameObject.SetActive(true);
        }
    }
    public void StartCamera()
    {
        virtualCam.enabled = true;
        virtualCam.Follow = playTarget.transform;
    }
}
