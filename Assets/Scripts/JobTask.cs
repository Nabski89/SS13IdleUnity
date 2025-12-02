using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JobTask : MonoBehaviour
{
    public string VERB;
    public TextMeshProUGUI VerbText;
    public string NOUN;
    public TextMeshProUGUI NounText;
    public float TaskXP;
    public float TaskTime;
    public TextMeshProUGUI TimeXPText;
    public int requiredLevel;
    public bool ValidTask;
    public bool TaskActive;
    public Image ProgressBar;
    public float Progress;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Clear out stuff
        ProgressBar.fillAmount = 0;

        if (VERB != null)
            VerbText.text = VERB;
        else
            ThrowError();
        if (NOUN != null)
            NounText.text = NOUN;
        else
            ThrowError();
        if (TaskXP != 0 && TaskTime != 0)
            TimeXPText.text = $"{TaskXP} XP / {TaskTime} SECONDS";
        else
            ThrowError();

        RefreshTask();
    }
    void ThrowError()
    {
        Debug.Log("You fucked up");
    }
    // Update is called once per frame
    void Update()
    {
        if (TaskActive == true)
        {
            Progress += Time.deltaTime;
            ProgressBar.fillAmount = Progress / TaskTime;
            if (Progress > TaskTime)
                CompleteTask();
        }
    }
    public void ClickOnTask()
    {
        if (TaskActive == true)
            CancelTask();
        else
            StartTask();
    }
    public void StartTask()
    {
        //Get the parent holder
        JobBase jobBase = GetComponentInParent<JobBase>();
        if (jobBase == null)
        {
            Debug.LogWarning("No JobBase found in parent hierarchy.");
            return;
        }
        // Find the other tasks
        JobTask[] jobTasks = jobBase.GetComponentsInChildren<JobTask>();

        // Cancel them
        foreach (JobTask task in jobTasks)
        {
            task.CancelTask();
        }

        //check if we have required items
        GetComponent<TaskRequires>().CompareQuantities();

        TaskActive = true;

    }
    public void ContinueTask()
    {
        //check if we have required items
        GetComponent<TaskRequires>().CompareQuantities();
    }
    public void CompleteTask()
    {
        Progress -= TaskTime;
        GetComponentInParent<JobBase>().ChangeXP(TaskXP);


        GetComponent<TaskRequires>().UseRequiredItems();
        GetComponent<TaskReward>().GiveReward();

        ContinueTask();
    }
    public void CancelTask()
    {
        TaskActive = false;
        Progress = 0;
        ProgressBar.fillAmount = 0;
    }

    //LockUnlock
    public Image GivesImg;
    public TextMeshProUGUI GivesText;
    Color UnlockColor = new Color(0.03921569f, 0.427451f, 0.8509804f);
    Color LockMainColor = new Color(1f, .4764151f, .4764151f);
    Color LockColor = new Color(0.5960785f, 0.1568628f, 0.1568628f);

    public void LevelUnlock()
    {
        ValidTask = true;
        GetComponent<Image>().color = Color.white;
        GivesImg.color = UnlockColor;
        GivesText.text = "GIVES";
    }
    public void LevelLock()
    {
        ValidTask = false;
        GetComponent<Image>().color = LockMainColor;
        GivesImg.color = LockColor;
        GivesText.text = "LEVEL " + requiredLevel;
    }
    public void TaskShow()
    { }
    public void TaskHide()
    { }


    public void RefreshTask()
    {
        //This will mostly be triggered when you buy an upgrade or equip a potion or at start
        ProgressBar.fillAmount = 0;
        if (TaskXP != 0 && TaskTime != 0)
            TimeXPText.text = $"{TaskXP} XP / {TaskTime} SECONDS";
        //turn off the uses on everything that doesn't require items
        TaskRequiresTag[] taggedChildren = GetComponentsInChildren<TaskRequiresTag>(true);

        if (GetComponentInChildren<TaskRequires>(true).RequiredItems.Length == 0)
            foreach (var child in taggedChildren)
                child.gameObject.SetActive(false);
        //this true lets us re enable it once it is disabled
        if (GetComponentInChildren<TaskRequires>(true).RequiredItems.Length > 0)
            foreach (var child in taggedChildren)
                child.gameObject.SetActive(true);
    }
}
