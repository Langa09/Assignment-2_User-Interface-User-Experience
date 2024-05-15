using UnityEngine;
using UnityEngine.UI;

public class Filter : MonoBehaviour
{
    public GameObject[] shopItems;

   public void FilterItems(int FilterInt)
    {
        if (FilterInt == 0)
        {
            for(int i=0; i< shopItems.Length; i++)
            {
                shopItems[i].SetActive(true);
            }
        }
        if (FilterInt == 1)//pants
        {
            for (int i = 0; i < shopItems.Length; i++)
            {
                if (shopItems[i].gameObject.tag == "Pants")
                {
                    shopItems[i].SetActive(true);
                }
                else
                {
                    shopItems[i].SetActive(false);
                }
               
            }
        }
        if (FilterInt == 2)//shirts
        {
            for (int i = 0; i < shopItems.Length; i++)
            {
                if (shopItems[i].gameObject.tag == "Shirts")
                {
                    shopItems[i].SetActive(true);
                }
                else
                {
                    shopItems[i].SetActive(false);
                }

            }
        }
    }
}