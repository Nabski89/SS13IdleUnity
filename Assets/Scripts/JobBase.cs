using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JobBase : MonoBehaviour
{
    public Image ProgressBar;
    public float XP;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI LevelTextSIDEBAR;
    public TextMeshProUGUI XPText;
    public int MaxLevel = 50;
    public int Level = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeXP(0);
        UnlockNewTasks();
    }
    public void ChangeXP(float value)
    {
        XP += value;
        //Level Down
        if (XP < (LevelXPCalc(Level - 1)))
        {
            Level = Mathf.Max(Level - 1, 1);
            if (XP < 1)
                XP = 1;
            UnlockNewTasks();
        }
        //Level Up
        if (XP > (LevelXPCalc(Level + 1)))
        {
            Level = Mathf.Min(Level + 1, MaxLevel);
            UnlockNewTasks();
        }

        //XP / XP Required for level-1
        ProgressBar.fillAmount = (XP - LevelXPCalc(Level)) / (LevelXPCalc(Level + 1) - LevelXPCalc(Level));

        XPText.text = XP + " / " + LevelXPCalc(Level + 1);
        LevelText.text = Level + " / " + MaxLevel;
        //Set the Sidebar
        if (LevelTextSIDEBAR != null)
            LevelTextSIDEBAR.text = Level + " / " + MaxLevel;
    }
    int LevelXPCalc(int CalcLevel)
    {
        if (CalcLevel <= 1)
            return 0;

        float top = Mathf.Pow(2f, (CalcLevel - 1f) / 7f) - 1f;

        // This is a constant, no need to calculate it here
        // But I did anyways
        float BOTTOM = (1f - Mathf.Pow(2f, -1f / 7f)) / 75f;

        // This offset will primarily affect the first couple of numbers, lowering them so the leveling experience isn't so awful
        float offset = 121f - Mathf.Log10((CalcLevel + 1f) * (CalcLevel + 1f) * 0.45f + 1.5f) * 230f;

        return Mathf.FloorToInt(top / BOTTOM + offset);
    }

    public void UnlockNewTasks()
    {
        JobTask[] tasks = GetComponentsInChildren<JobTask>(true); // true includes inactive objects

        foreach (JobTask task in tasks)
        {
            if (task.requiredLevel <= Level)
            {
                task.LevelUnlock();
            }
            else
            {
                task.LevelLock();
            }
        }
    }
}


/*
    private const double BOTTOM = (1 - Math.Pow(2, -1.0 / 7)) / 75;

    public static int XpFromLevel(int level)
    {
        if (level <= 1) return 0;

        double top = Math.Pow(2, ((level - 1) / 7.0)) - 1;
        double offset = 121 - Math.Log10((level + 1) * (level + 1) * 0.45 + 1.5) * 230;

        return (int)Math.Floor(top / BOTTOM + offset);
    }

    public static int LevelFromXP(int xp)
    {
        int level = 1;
        while (XpFromLevel(level + 1) <= xp)
        {
            level++;
        }
        return level;
    }

    */