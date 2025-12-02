using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int LiquidCash = 1000;
    public TextMeshProUGUI SidebarMoneyDisplay;
    public TextMeshProUGUI InventoryMoneyDisplay;
    GameObject FilledSlotsParent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InventoryMoneyDisplay = GetComponentInChildren<InventoryMoneyTag>().GetComponent<TextMeshProUGUI>();
        SidebarMoneyDisplay = GetComponentInParent<Canvas>().GetComponentInChildren<SidebarMoneyTag>().GetComponent<TextMeshProUGUI>();

        FilledSlotsParent = GetComponentInChildren<FilledBankSlotsTag>().gameObject;
        InventoryMoneyDisplay.text = "0";
    }
    void Update()
    {
        UpdateMoney();
    }
    public void ChangeMoney(int Change)
    {
        LiquidCash += Change;
        UpdateMoney();
    }
    public void UpdateMoney()
    {
        SidebarMoneyDisplay.text = LiquidCash.ToString("N0");
    }
    public void UpdateBankValue()
    {
        int Sum = 0;


        // Loop through all children of Holder
        for (int i = 0; i < FilledSlotsParent.transform.childCount; i++)
        {
            Transform child = FilledSlotsParent.transform.GetChild(i);
            InventoryItem item = child.GetComponent<InventoryItem>();

            if (item != null)
            {
                Sum += item.quantity * item.Cost;
            }
        }
        InventoryMoneyDisplay.text = Sum.ToString("N0");
    }
}
