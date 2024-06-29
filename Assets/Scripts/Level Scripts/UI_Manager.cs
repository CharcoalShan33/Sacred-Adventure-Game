using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Manager : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] GameObject menu;
    [SerializeField] TextMeshProUGUI[] nameText, healthText, manaText, lvlText, xpText;
    [SerializeField] Slider[] xpSlider;
    [SerializeField] GameObject[] characterPanel;
     PlayerStats[] players;

    public static UI_Manager instance;
    // Start is called before the first frame update
    void Awake()
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (menu.activeInHierarchy)
            {
               
                menu.SetActive(false);
                GameManager.instance.gameMenuOpen = false;
                
            }
            else
            {
                UpdateStats();
                menu.SetActive(true);
                GameManager.instance.gameMenuOpen = true;
                
            }
        }

    }

    public void UpdateStats()
    {
        players = GameManager.instance.GetPlayerStats();
        for(int i = 0; i < players.Length; i++)
        {
            characterPanel[i].SetActive(true);

            nameText[i].text = players[i].playerName;

            healthText[i].text = players[i].currentHP + "/" + players[i].maxHP;
            manaText[i].text = players[i].currentMana + "/" + players[i].maxMana;
            lvlText[i].text = players[i].playerLevel.ToString();
            xpText[i].text = players[i].currentXP.ToString();

            //players[i].ToString().

        }

    }

    public void FadeImage()
    {
        fadeImage.GetComponent<Animator>().SetTrigger("StartFade");
    }
}
