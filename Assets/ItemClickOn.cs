using UnityEngine;


public class ItemClickOn : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void GotClicked()
    {

        SetName();
        EquipButton();
        UnEquipButton();
        SellButtons();
    }
    void SetName()
    {

    }
    void EquipButton()
    {
        if (GetComponentInParent<EquipButtonParentTag>() != null)
        {
            //        setactive
        }
        else
        {
            //      setinactive
        }
    }
    void UnEquipButton()
    {
        if (GetComponentInParent<UNEquipButtonParentTag>() != null)
        {
            //          setactive
            EquipOtherThings();

        }
        else
        {
            //          setinactive
        }
    }
    void EquipOtherThings()
    {

    }
    void SellButtons()
    {
        PopulateSellButtons();
    }
    void PopulateSellButtons()
    {

    }
}
