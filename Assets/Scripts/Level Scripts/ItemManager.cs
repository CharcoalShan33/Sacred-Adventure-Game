using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public enum ItemType { Consumable, Weapon, Armor, Key}

    public ItemType itemType;

    public string itemName, itemDescription;
    public int count;
    public int amountOfEffect;

    public Sprite itemImage;

    public enum effectType { HP, MP}
    public int weaponDexterity;
    public int armorDefense;

    public bool isStackable;

    public int quantitiy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Hero"))
        {
            print(itemName);
            Inventory.instance.AddItems(this);
            OnDestroyItem();
        }
    }

    public void OnDestroyItem()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

}
