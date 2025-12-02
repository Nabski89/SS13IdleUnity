using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class RequiredItems
{
    public GameObject item;
    public int quantity;
}


public class TaskRequires : MonoBehaviour
{
    InventoryManager Inventory;
    public RequiredItems[] RequiredItems;
    public GameObject RequiredBase;
    public GameObject RequiresUIHolder;
    public GameObject UsesArrow;

    public void Start()
    {
        SpawnRequiredItems();
    }
    public void SpawnRequiredItems()
    {
        //delete everyone but the first, which is the text
        for (int i = RequiresUIHolder.transform.childCount - 1; i > 0; i--)
        {
            DestroyImmediate(RequiresUIHolder.transform.GetChild(i).gameObject);
        }
        //spawn the different requirement options
        if (RequiredItems.Length == 0)
        {
            UsesArrow.SetActive(false);
            RequiresUIHolder.SetActive(false);
        }
        //we have extra text if there's more than one option
        else
        {
            UsesArrow.SetActive(true);
            RequiresUIHolder.SetActive(true);
            int i = 0;
            while (i < RequiredItems.Length)
            {
                CreateRequiredUI(i);
                i++;
            }
        }
    }
    public void CreateRequiredUI(int i)
    {
        Debug.Log("Trying to spawn the requirement item " + RequiredItems[i].item.name);
        GameObject instance = Instantiate(RequiredBase, RequiresUIHolder.transform);

        // Find the child Image component
        instance.GetComponentInChildren<Image>().sprite = RequiredItems[i].item.GetComponent<Image>().sprite;
    }
    public void CompareQuantities()
    {
        // Loop through each item in the array
        foreach (var item in RequiredItems)
        {
            // Loop through each child of Holder
            for (int i = 0; i < Inventory.transform.childCount; i++)
            {
                Transform child = Inventory.transform.GetChild(i);
                InventoryItem invItem = child.GetComponent<InventoryItem>();

                if (invItem != null && invItem.Name == item.item.name)
                {
                    // Compare quantities
                    if (invItem.quantity == item.quantity)
                    {
                        Debug.Log($"{item.item.name}: quantities match ({item.quantity})");
                    }
                    else
                    {
                        Debug.Log($"{item.item.name}: array={item.quantity}, child={invItem.quantity}");
                    }
                }
            }
        }
    }


    public void UseRequiredItems()
    {
        Debug.Log("Write the UseRequired Items Function Bozo");
    }
}
