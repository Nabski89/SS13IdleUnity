using UnityEngine;
using TMPro;

public class SellOptions : MonoBehaviour
{
    InventoryItem Item;
    public TextMeshProUGUI Sell1;
    public TextMeshProUGUI Sell10;
    public TextMeshProUGUI Sell100;
    public TextMeshProUGUI Sell1000;
    public TextMeshProUGUI QuantityX;
    public TextMeshProUGUI SellX;
    public TextMeshProUGUI QuantityXMinus1;
    public TextMeshProUGUI SellXMinus1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Item = GetComponentInParent<InventoryItem>();
    }

    // Update is called once per frame
    void Update()
    {
        Sell1101001000();
        UpdateSellAll();
        UpdateSellAllButOne();
    }

    void Sell1101001000()
    {
        SetActiveOrNot(Sell1.transform.gameObject, 0);
        SetActiveOrNot(Sell10.transform.gameObject, 10);
        SetActiveOrNot(Sell100.transform.gameObject, 100);
        SetActiveOrNot(Sell1000.transform.gameObject, 1000);
    }
    void UpdateSellAll()
    {
        SetActiveOrNot(SellX.transform.gameObject, 1);
        QuantityX.text = Item.quantity.ToString("N0");
        SellX.text = (Item.quantity * Item.Cost).ToString("N0");
    }
    void UpdateSellAllButOne()
    {
        SetActiveOrNot(SellXMinus1.transform.gameObject, 3);
        QuantityXMinus1.text = (Item.quantity - 1).ToString("N0");
        SellXMinus1.text = ((Item.quantity - 1) * Item.Cost).ToString("N0");
    }
    void SetActiveOrNot(GameObject ThisGuy, int Threshold)
    {
        if (Item.quantity > Threshold)
            ThisGuy.SetActive(true);
        else
            ThisGuy.SetActive(false);
    }

}
