using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    bool canOpenShop;
    [SerializeField] List<ItemManager> sellItems;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canOpenShop && Input.GetKeyDown(KeyCode.E) && Player.instance.DeactivateMovement(false))
        {
           ShopManager.instance.itemsForSale = sellItems;
            ShopManager.instance.OpenShopMenu();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
      if(collision.tag == "Hero")
        {
            canOpenShop = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Hero")
        {
            canOpenShop = false;
        }
    }


}

