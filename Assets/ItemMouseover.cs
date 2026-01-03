using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMouseover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject TextBox;
    bool InfoFilledOut = false;
    ItemInfoBaseReferences Reference;
    // Called when the mouse enters the UI element
    void Start()
    {
        Reference = GetComponent<ItemInfoBaseReferences>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse entered " + gameObject.name);
        OnHoverEnter();
    }

    // Called when the mouse exits the UI element
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exited " + gameObject.name);
        OnHoverExit();
    }

    private void OnHoverEnter()
    {
        // Do something when hovered
        if (InfoFilledOut == false)
            FilleOutInfoBox();

        TextBox.SetActive(true);
    }
    private void OnHoverExit()
    {
        // Do something when un-hovered
        TextBox.SetActive(false);
    }



    void FilleOutInfoBox()
    {
        InfoFilledOut = true;
        Basics();
        Slot();
        Requirements();
        Food();
        BonusText();
        Stats();
    }
    void Basics()
    {
        InventoryItem Basics = GetComponent<InventoryItem>();
        //Name
        Reference.Name.text = Basics.Name;
        //Cost
        if (Basics.Cost == 0)
        {
            Reference.Price.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            Reference.Price.transform.parent.gameObject.SetActive(true);
            Reference.Price.text = Basics.Cost.ToString("N0");

        }
    }
    void Slot()
    {
        /*
        //TODO Icon Pictures
        ItemStats Stats = GetComponent<ItemStats>();
        if (Stats == null)
        {
            Reference.HP.transform.parent.parent.gameObject.SetActive(false);
        }
        else
        {
            Reference.HP.transform.parent.parent.gameObject.SetActive(true);
            Reference.HP.text = Stats.MaxHealth.ToString("N0");
        }
        */
    }
    void Requirements()
    {
        //TODO Highlight if it is right or not
     /*   ItemStats Stats = GetComponent<ItemStats>();
        if (Stats == null)
        {
            Reference.HP.transform.parent.parent.gameObject.SetActive(false);
        }
        else
        {
            Reference.HP.transform.parent.parent.gameObject.SetActive(true);
            Reference.HP.text = Stats.MaxHealth.ToString("N0");
        }
        */
    }
    void Food()
    {
        ItemFood Stats = GetComponent<ItemFood>();
        if (Stats == null)
        {
            Reference.Heals.transform.gameObject.SetActive(false);
        }
        else
        {
            Reference.Heals.transform.gameObject.SetActive(true);
            if (Stats.HealsAmount > 0)
                Reference.Heals.text = "Heals +" + Stats.HealsAmount.ToString("N0") + " HP";
            else
                Reference.Heals.text = "Heals -" + Stats.HealsAmount.ToString("N0") + " HP";
        }
    }
    void BonusText()
    {/*
        ItemStats Stats = GetComponent<ItemStats>();
        if (Stats == null)
        {
            Reference.HP.transform.parent.parent.gameObject.SetActive(false);
        }
        else
        {
            Reference.HP.transform.parent.parent.gameObject.SetActive(true);
            Reference.HP.text = Stats.MaxHealth.ToString("N0");
        }
        */
    }
    void Stats()
    {
        ItemStats Stats = GetComponent<ItemStats>();
        if (Stats == null)
        {
            Reference.HP.transform.parent.parent.gameObject.SetActive(false);
        }
        else
        {
            Reference.HP.transform.parent.parent.gameObject.SetActive(true);
            Reference.HP.text = Stats.MaxHealth.ToString("N0");
            Reference.Regen.text = Stats.HPRegen.ToString("N0");
            Reference.Evasion.text = Stats.Evasion.ToString("N0");
            Reference.Command.text = Stats.Command.ToString("N0");
            Reference.Brute.text = Stats.BruteProtection.ToString("N0");
            Reference.Burn.text = Stats.BurnProtection.ToString("N0");
            Reference.Precision.text = Stats.Precision.ToString("N0");
            Reference.Power.text = Stats.Power.ToString("N0");
            Reference.Luck.text = Stats.Luck.ToString("N0");
        }
    }
}