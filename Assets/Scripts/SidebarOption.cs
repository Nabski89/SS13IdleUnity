using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SidebarOption : MonoBehaviour
{
    public GameObject SidebarSelection;
    SidebarController sidebarController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sidebarController = GetComponentInParent<SidebarController>();

        // Find the child named "Level Text"
        Transform levelTextTransform = transform.Find("Level Text");

        if (levelTextTransform != null)
        {
            // Get the TextMeshProUGUI component
            SidebarSelection.GetComponent<JobBase>().LevelTextSIDEBAR = levelTextTransform.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogWarning("No child GameObject named 'Level Text' found.");
        }

    }

    // Update is called once per frame
    public void ButtonPress()
    {
        if (sidebarController != null)
        {
            //clear out the old
            sidebarController.TransferSelections();
            //and in with the new
            SidebarSelection.transform.SetParent(sidebarController.ActiveSelectionHolder.transform, false);
        }
    }
}
