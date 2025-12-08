using Unity.VisualScripting;
using UnityEngine;

public class UIOverlayDisableOnClick : MonoBehaviour
{
    void Update()
    {
        // Detect left mouse click anywhere
        if (Input.GetMouseButtonDown(0))
        {

            transform.gameObject.SetActive(false);
        }

    }
}
