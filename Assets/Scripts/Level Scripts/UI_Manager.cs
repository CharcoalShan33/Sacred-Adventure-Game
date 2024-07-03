using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Manager : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] GameObject menu;
    PlayerStats[] players;
    [Header("Character Information")]
    [SerializeField] TextMeshProUGUI[] nameText, healthText, manaText, lvlText, totalRequiredXp;
    [SerializeField] Slider[] xpSlider;
    [SerializeField] GameObject[] characterPanel;
    [SerializeField] Image[] characterImages;


    [SerializeField] GameObject[] statsButton;
    [SerializeField] TextMeshProUGUI statName, statHP, statMP, statMAG, statDEX, statATK, statDEF, StatMRES;
    [SerializeField] Image characterIcon;
    public static UI_Manager instance;

    [SerializeField] GameObject itemSlotObject; // instatiated
    [SerializeField] Transform itemContainerParent; //The parent object;

    public TextMeshProUGUI itemName, itemDescription;

    public ItemManager activeItem;

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
                UpdateItems();
                menu.SetActive(true);
                GameManager.instance.gameMenuOpen = true;

            }
        }

    }

    public void UpdateStats()
    {
        players = GameManager.instance.GetPlayerStats();
        for (int i = 0; i < players.Length; i++)
        {
            characterPanel[i].SetActive(true);

            nameText[i].text = players[i].playerName;
            characterImages[i].sprite = players[i].character;
            healthText[i].text = players[i].currentHP + "/" + players[i].maxHP;
            manaText[i].text = players[i].currentMana + "/" + players[i].maxMana;
            lvlText[i].text = players[i].playerLevel.ToString();
            totalRequiredXp[i].text = players[i].totalXP.ToString();
            xpSlider[i].maxValue = players[i].xpForEachLevel[players[i].playerLevel];
            xpSlider[i].value = players[i].totalXP;
            //players[i].ToString().

        }

    }

    public void UpdateStatusMenu(int playerSelectedNum)
    {
        PlayerStats playerSelected = players[playerSelectedNum];
        statName.text = playerSelected.playerName;
        statHP.text = playerSelected.currentHP.ToString() + " / " + playerSelected.maxHP.ToString();
        statMP.text = playerSelected.currentMana.ToString() + " / " + playerSelected.maxMana.ToString();
        statMAG.text = playerSelected.magAttack.ToString();
        statDEX.text = playerSelected.dexterity.ToString();
        statATK.text = playerSelected.physAttack.ToString();
        statDEF.text = playerSelected.defense.ToString();
        StatMRES.text = playerSelected.magicRES.ToString();
        characterIcon.sprite = playerSelected.character;


    }
    public void StatMenu()
    {
        for (int i = 0; i < players.Length; i++)
        {
            statsButton[i].SetActive(true);
            statsButton[i].GetComponentInChildren<TextMeshProUGUI>().text = players[i].playerName;
        }
        UpdateStatusMenu(0);
    }

    void UpdateItems() // inventory.
    {
       
        foreach (Transform itemSlot in itemContainerParent)
        {
            Destroy(itemSlot.gameObject);

        }
        foreach(ItemManager item in Inventory.instance.GetItemList())
        {
            RectTransform itemSlot = Instantiate(itemSlotObject, itemContainerParent).GetComponent<RectTransform>();

            Image itemImage = itemSlot.Find("Icon").GetComponent<Image>();
                 itemImage.sprite = item.itemImage;

           TextMeshProUGUI itemsAmountText = itemSlot.Find("Quantity").GetComponent<TextMeshProUGUI>();

            if(item.quantitiy > 1)
            {
                itemsAmountText.text = item.quantitiy.ToString();
            }
            else
            {
                itemsAmountText.text = "";
            }

           itemSlot.GetComponent<ItemButton>().itemPressed = item;
        }

    }


    public void Discard()
    {
        print("Discard " + itemName);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void FadeImage()
    {
        fadeImage.GetComponent<Animator>().SetTrigger("StartFade");
    }
}