using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject[] willShowItems;
    public float delay = 6;

    private void Start()
    {
        Invoke("ActivateObjectsWithChildren", delay);
    }

    private void ActivateObjectsWithChildren()
    {
        foreach (GameObject obj in willShowItems)
        {
            obj.SetActive(true);
            ActivateChildren(obj.transform);
        }
    }

    private void ActivateChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            child.gameObject.SetActive(true);
            ActivateChildren(child);
        }
    }
}