using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMouseover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject TextBox;
    bool InfoFilledOut = false;
    // Called when the mouse enters the UI element
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
    void FilleOutInfoBox()
    {
        InfoFilledOut = true;
    }
    private void OnHoverExit()
    {
        // Do something when un-hovered
        TextBox.SetActive(false);
    }

}
