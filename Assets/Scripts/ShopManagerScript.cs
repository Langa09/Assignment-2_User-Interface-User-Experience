using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{
    public static ShopManagerScript instance;

    public int[,] shopItems = new int[4, 6];
    public float coins;
    public TextMeshProUGUI cashTag;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cashTag.text = "Coins:       $" + coins.ToString();

        //shopID
        shopItems[1, 0] = 1; //Array position itemId 2 was removed by mistake now I can't bring it back
        shopItems[1, 2] = 3;
        shopItems[1, 3] = 4;

        //itemprice
        shopItems[2, 0] = 30;
        shopItems[2, 2] = 25;
        shopItems[2, 3] = 20;

        //amount
        shopItems[3, 0] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        
    }

    public void Buy()
    {
        GameObject buttonRef = EventSystem.current.currentSelectedGameObject;
        int itemID = buttonRef.GetComponent<ButtonInfo>().itemID - 1;
        int itemPrice = shopItems[2, itemID];
        int currentAmount = shopItems[3, itemID];

        bool canBuy = coins >= itemPrice && currentAmount < coins;
        if (canBuy)
        {
            coins -= itemPrice;
            shopItems[3, itemID]++;
            cashTag.text = $"Coins:       ${coins}";
            buttonRef.GetComponent<ButtonInfo>().amount.text = shopItems[3, itemID].ToString();

            UpdateStorageObjects(itemID + 1);
        }
    }

    public void Sell()
    {
        GameObject buttonRef = EventSystem.current.currentSelectedGameObject;
        int itemID = buttonRef.GetComponent<ButtonInfo>().itemID - 1;
        int itemPrice = shopItems[2, itemID];
        int currentAmount = shopItems[3, itemID];

        bool canSell = currentAmount > 0;
        if (canSell)
        {
            coins += itemPrice;
            shopItems[3, itemID]--;
            cashTag.text = $"Coins:       ${coins}";
            buttonRef.GetComponent<ButtonInfo>().amount.text = shopItems[3, itemID].ToString();

            UpdateStorageObjects(itemID + 1);
        }
    }

    private void UpdateStorageObjects(int itemID)
    {
        StorageObject[] storageObjects = FindObjectsOfType<StorageObject>();
        foreach (StorageObject storageObject in storageObjects)
        {
            if (storageObject.itemID == itemID)
            {
                storageObject.UpdateStorage();
            }
        }
    }

}