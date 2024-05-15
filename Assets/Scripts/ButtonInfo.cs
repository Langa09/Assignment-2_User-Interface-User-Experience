using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public int itemID;
    public TextMeshProUGUI price;
    public TextMeshProUGUI amount;
    public GameObject ShopManager;

    private void Start()
    {
        int ItemID = itemID - 1;

        price.text = "$" + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString();
        amount.text = ShopManager.GetComponent<ShopManagerScript>().shopItems[3, ItemID].ToString();
    }
}