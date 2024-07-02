using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{

    public static ShopManager instance;

    public GameObject shopMenu, buyPanel, sellPanel;

    [SerializeField] TextMeshProUGUI currentMoney;

    public List<ItemManager> itemsForSale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  OpenShopMenu()
    {
        shopMenu.SetActive(true);
        GameManager.instance.shopOpen = true;
        currentMoney.text = GameManager.instance.money.ToString();
        buyPanel.SetActive(true);

    }

    public void CloseShopMenu()
    {
        shopMenu.SetActive(false);
        GameManager.instance.shopOpen = false;
    }

    public void OpenBuyPanel()
    {
        buyPanel.SetActive(true);
        sellPanel.SetActive(false);
    }

    public void OpenSellPanel()
    {
        buyPanel.SetActive(false);
        sellPanel.SetActive(true);
    }
}
