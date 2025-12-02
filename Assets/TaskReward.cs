using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TaskRewards
{
    public GameObject RewardItem;
    public int RewardWeight;
}
//TODO gain different amounts of items
public class TaskReward : MonoBehaviour
{
    public TaskRewards[] Reward;
    public GameObject RewardBase;
    public InventoryManager Inventory;
    public GameObject RewardUIHolder;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Inventory = GetComponentInParent<InventoryManager>();
        SetUpRewards();
    }
    public void SetUpRewards()
    {
        //delete everyone but the first, which is the gives text
        for (int i = RewardUIHolder.transform.childCount - 1; i > 0; i--)
        {
            DestroyImmediate(RewardUIHolder.transform.GetChild(i).gameObject);
        }
        //spawn the different reward options
        if (Reward.Length == 0)
        {
            CreateRewardUI(0);
        }
        //we have extra text if there's more than one option
        else
        {
            int i = 0;
            while (i < Reward.Length)
            {
                CreateRewardUI(i);
                i++;
            }
        }
    }

    public void CreateRewardUI(int i)
    {
        GameObject instance = Instantiate(RewardBase, RewardUIHolder.transform);

        // Find the child Image component
        instance.GetComponentInChildren<Image>().sprite = Reward[i].RewardItem.GetComponent<Image>().sprite;
    }
    public void UpdateItemQuantity()
    {

    }
    public void GiveReward()
    {
        Debug.Log("We want to reward an item");

        if (Reward.Length == 0)
            Debug.LogWarning("No Reward Found");

        //find our total weight count
        int totalWeight = 0;
        for (int i = 0; i < Reward.Length; i++)
            totalWeight += Reward[i].RewardWeight;

        if (totalWeight == 0)
        {
            Inventory.AddItem(Reward[0].RewardItem);
            Debug.Log("We have rewarded an item successfully, it was unweighted");
        }
        //random value
        int randomValue = Random.Range(0, totalWeight);
        for (int i = 0; i < Reward.Length; i++)
        {
            //The total weight values
            randomValue -= Reward[i].RewardWeight;
            //what we rolled, with max exclusive offset vs the weight catagory
            if (randomValue < 1)
            //spawn it
            {
                Debug.Log("Actually what the fuck we are trying to spawn item " + i);
                Inventory.AddItem(Reward[i].RewardItem);
                //This ends the loop
                Debug.Log("We have rewarded an item successfully, we had to roll for it");
                return;
            }

        }
    }
}
