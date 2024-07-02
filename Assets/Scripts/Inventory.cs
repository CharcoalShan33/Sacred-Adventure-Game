using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ItemManager> itemList;

    public static Inventory instance;

    // Start is called before the first frame update
    void Start()
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


        itemList = new List<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItems(ItemManager item)
    {

        if (item.isStackable)
        {
            bool itemInInventory = false;

            foreach (ItemManager itemStorage in itemList)
            {
                if (itemStorage.itemName == item.itemName)
                {
                    itemStorage.amountOfEffect += item.amountOfEffect;
                    itemInInventory = true;
                }
            }
            if (itemInInventory)
            {
                itemList.Add(item);
            }
        }
        else
        {
            itemList.Add(item);
        }

    }

    public List<ItemManager> GetItemList()
    {
        return itemList;
    }

}
