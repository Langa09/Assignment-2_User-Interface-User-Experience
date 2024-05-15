using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageObject: MonoBehaviour
{
    public int itemID;
    public Image itemImage;
    public GameObject thing;

    private void Start()
    {
        UpdateStorage();
    }
    public void Update()
    {
        int ItemID = itemID - 1;
        int amount = ShopManagerScript.instance.shopItems[3, ItemID];
        if (amount == 0)
        {
            thing.SetActive(false);
        }
        else
        {
            thing.SetActive(true);
        }
    }
    public void UpdateStorage()
    {
        int ItemID = itemID - 1;
        int amount = ShopManagerScript.instance.shopItems[3, ItemID];

        if (amount > 0)
        {
            itemImage.enabled = true;
        }
        else
        {
            itemImage.enabled = false;

        }
    }
}