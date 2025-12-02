using UnityEngine;
using UnityEngine.EventSystems;
public class ItemPopup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject targetToToggle;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (targetToToggle != null)
            targetToToggle.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (targetToToggle != null)
            targetToToggle.SetActive(false);
    }
}
