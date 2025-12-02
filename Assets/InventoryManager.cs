using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public TextMeshProUGUI EmptySlotsText;
    GameObject EmptySlotsParent;
    public GameObject EmptySlotsPrefab;
    GameObject FilledSlotsParent;
    public ToasterMachine Toaster;
    MoneyManager Money;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Toaster = GetComponent<ToasterMachine>();
        Money = GetComponentInChildren<MoneyManager>();
        EmptySlotsParent = GetComponentInChildren<EmptySlotsTag>().gameObject;
        FilledSlotsParent = GetComponentInChildren<FilledBankSlotsTag>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpaceUsed();
    }
    public void AddItem(GameObject NewItem)
    {
        bool HaveItemYet = false;
        //Check if we already have the item
        {
            for (int i = 0; i < FilledSlotsParent.transform.childCount; i++)
            {
                Transform child = FilledSlotsParent.transform.GetChild(i);

                if (child.name == NewItem.name)
                {
                    InventoryItem item = child.GetComponent<InventoryItem>();
                    if (item != null)
                    {
                        HaveItemYet = true;
                        item.quantity += NewItem.GetComponent<InventoryItem>().quantity;

                        Debug.Log($"Increased {child.name} quantity to {item.quantity}");
                        Toaster.GetItemToast("+ " + NewItem.GetComponent<InventoryItem>().quantity);
                    }
                }
            }
            //Check if we have space for a new item
            if (HaveItemYet == false)
            {
                if (FilledSlotsParent.transform.childCount < EmptySlotsParent.transform.childCount)
                {
                    GameObject instance = Instantiate(NewItem, FilledSlotsParent.transform);
                    //rename it to get rid of the clone because we are using the object name later
                    instance.name = NewItem.name;
                    Toaster.GetItemToast("+ " + NewItem.GetComponent<InventoryItem>().quantity);
                }
                //Throw up a you failed to get the item result
                else
                    Toaster.GetTextToast("Inventory Full");
            }
            //update our bank value
            Money.UpdateBankValue();
        }
    }
    public void SubtractItem(GameObject MinusItem, int MinusQuantity)
    {
        //update our bank value
        Money.UpdateBankValue();
    }
    public void RemoveAllItem(GameObject GoneItem)
    {
        //update our bank value
        Money.UpdateBankValue();
    }

    public void UpdateSpaceUsed()
    {
        EmptySlotsText.text = FilledSlotsParent.transform.childCount + "/" + EmptySlotsParent.transform.childCount;

    }
}
