using UnityEngine;

public class OpenWebLink : MonoBehaviour
{
    public string WebLink = "https://discord.com/invite/HwbK9XQ";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    public void ClickTheLink()
    {
        Application.OpenURL(WebLink);
    }
}
