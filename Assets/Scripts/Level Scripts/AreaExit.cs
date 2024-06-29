using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AreaExit : MonoBehaviour
{
    [SerializeField] string sceneName;
     [SerializeField] string transitionNameAE;
     [SerializeField] AreaEnter newArea;
    // Start is called before the first frame update

    private void Awake()
    {
       newArea.areaName = transitionNameAE;   
    }
    private void Start()
    {
        
        // no confusion: transitionName is for this script... AreaName is for the AreaEnter Script.
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hero"))
        {
            Debug.Log("Entered");
            
            Player.instance.transitionName = transitionNameAE;
            UI_Manager.instance.FadeImage();
           

            StartCoroutine(Transition());

            
        }
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
