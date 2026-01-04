using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIManager : MonoBehaviour
{
    EnemyStats Stats;
    public TextMeshProUGUI NameText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Stats = GetComponent<EnemyStats>();
        NameText.text = Stats.Name;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
