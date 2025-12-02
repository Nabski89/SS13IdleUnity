using UnityEngine;

public class ToasterMachine : MonoBehaviour
{
    public GameObject ToastHolder;
    public GameObject ItemToast;
    public GameObject TextToast;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GetTextToast(string text)
    {
        GameObject Toast = Instantiate(TextToast, ToastHolder.transform);
        Destroy(Toast, 3);
    }
    public void GetItemToast(string text)
    {
        GameObject Toast = Instantiate(ItemToast, ToastHolder.transform);
        Destroy(Toast, 3);
    }
}

/*

//GPT slop but I will mess with it at some point

Fade in
exist
fade out
    public GameObject toastPanel;
    public TextMeshProUGUI toastText;
    public CanvasGroup canvasGroup;

    public float fadeDuration = 0.3f;
    public float displayDuration = 2f;

    Coroutine toastRoutine;

    public void ShowToast(string message)
    {
        if (toastRoutine != null)
            StopCoroutine(toastRoutine);

        toastRoutine = StartCoroutine(ToastSequence(message));
    }

    IEnumerator ToastSequence(string message)
    {
        toastText.text = message;
        toastPanel.SetActive(true);
        canvasGroup.alpha = 0;

        // Fade in
        float t = 0;
        while (t < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            t += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1;

        // Wait
        yield return new WaitForSeconds(displayDuration);

        // Fade out
        t = 0;
        while (t < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            t += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0;
        toastPanel.SetActive(false);
    }
}
**/