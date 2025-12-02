using UnityEngine;

public class SidebarController : MonoBehaviour
{
    public GameObject ActiveSelectionHolder;
    public GameObject InactiveSelectionsHolder;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //There is no reason that this should have more than one child, but just in case
    public void TransferSelections()
    {
        int childCount = ActiveSelectionHolder.transform.childCount;

        for (int i = childCount - 1; i >= 0; i--) // reverse to avoid indexing issues
        {
            Transform child = ActiveSelectionHolder.transform.GetChild(i);
            child.SetParent(InactiveSelectionsHolder.transform, false);
        }
    }

}
