using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    public ItemManager itemPressed;

    public void OnPress()
    {
        UI_Manager.instance.itemName.text = itemPressed.itemName;
        UI_Manager.instance.itemDescription.text = itemPressed.itemDescription;
    }
}
